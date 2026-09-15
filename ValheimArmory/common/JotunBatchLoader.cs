using BepInEx.Configuration;
using Jotunn;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using ValheimArmory;
using ValheimArmory.common;
using ValheimArmory.patches;

namespace ValheimArmory.Common {
    class JotunBatchLoader {
        internal static List<ItemDefinition> resourceDefinitions = new List<ItemDefinition>();
        internal static bool runningQueuedChanges = false;
        internal static AssetBundle Assets;
        internal static Dictionary<string, string> AddedItems = new Dictionary<string, string>();
        internal static List<string> ArcheryAmmoToAdd = new List<string>();

        // Pending in-world item updates, drained once per frame so an entire burst of SettingChanged
        // handlers (e.g. a full server config sync) costs a single pass over the live item drops
        // instead of one pass per changed setting.
        private static readonly List<KeyValuePair<string, Action<ItemDrop.ItemData>>> pendingWorldUpdates = new List<KeyValuePair<string, Action<ItemDrop.ItemData>>>();
        private static bool worldUpdateScheduled = false;

        // When non-null, GetRecipeIndexByPrefab resolves indexes via this map (O(1)) instead of a linear
        // FindIndex over ObjectDB.instance.m_recipes. Built for the duration of a ReapplyAllRecipeConfig pass.
        private static Dictionary<string, int> recipeIndexCache = null;

        internal static readonly AcceptableValueList<string> allowedModifiers = new AcceptableValueList<string>(new string[] {
            HitData.DamageModifier.Normal.ToString(),
            HitData.DamageModifier.VeryWeak.ToString(),
            HitData.DamageModifier.Weak.ToString(),
            HitData.DamageModifier.VeryWeak.ToString(),
            HitData.DamageModifier.Resistant.ToString(),
            HitData.DamageModifier.VeryResistant.ToString(),
            HitData.DamageModifier.Immune.ToString()
        });

        public bool BatchSetup(AssetBundle assetBundle, bool reverse_order = true) {
            Assets = assetBundle;
            // Since configs are ordered by when they are connected this allows us to add things in the order they are defined.
            if (reverse_order) {
                resourceDefinitions.Reverse();
            }
            WireConfigDefs();

            // BatchSetup runs from plugin Awake, before any world exists -- ZNet.instance is always null
            // here, so the ZNet probe could never detect a server. The headless graphics-device check is
            // what actually identifies a dedicated server this early.
            bool on_server = UnityEngine.SystemInfo.graphicsDeviceType == UnityEngine.Rendering.GraphicsDeviceType.Null;

            if (on_server == false) {
                // This is not needed on the server
                // The server does not actually do anything with prefabs, and is not responsible for modifying them
                BatchAddItems();
                SetupOnChange();
                ItemManager.OnItemsRegistered += AddAmmoItemsToArcheryTarget;
                // Re-apply config driven recipe values whenever the ObjectDB is (re)built. Jotunn re-adds the
                // cached (local-config) recipes on every ObjectDB.Awake, so this reconciles them to the current
                // (possibly server-synced) config values. Also re-apply when admin config arrives from the server.
                ItemManager.OnItemsRegistered += ReapplyAllRecipeConfig;
                SynchronizationManager.OnConfigurationSynchronized += OnModConfigsChanged;
            }

            // Flush to disk. SaveOnConfigSet stays off; later changes are written in batches (ValConfig.EnableDeferredSave).
            ValConfig.Save();
            return true;
        }

        public bool AddDefinition(ItemDefinition itemdef) {
            resourceDefinitions.Add(itemdef);
            return true;
        }

        private static bool WireConfigDefs() {
            // Ensure save on set is false, we will save at the end of this process.
            foreach (ItemDefinition itemdef in resourceDefinitions) {
                // A definition registered without a Recipe (or with a null item list) used to NRE here,
                // killing the whole mod during Awake. Normalize instead: the item is still registered,
                // it just gets no crafting recipe (see BatchAddItems).
                if (itemdef.Recipe == null) { itemdef.Recipe = new RecipeDefinition(); }
                if (itemdef.Recipe.RecipeItems == null) {
                    Logger.LogError($"Item definition '{itemdef.Name}' has no recipe items; it will be registered without a crafting recipe.");
                    itemdef.Recipe.RecipeItems = new List<RecipeIngredient>();
                }
                // Build a compacted display name for reference, this primarily just needs spaces removed.
                itemdef.DisplayName = string.Join("", itemdef.Name.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
                // Skip over all loading of items that are disabled.
                // Blow up if adding a non-unique data control
                AddedItems.Add(itemdef.DisplayName, itemdef.Prefab);
                // if (!itemdef.enabled) { continue; }
                itemdef.CraftableCfg = ValConfig.BindServerConfig($"{itemdef.Category} - {itemdef.Name}", $"{itemdef.DisplayName}-craftable", itemdef.Craftable, $"Enable/Disable the crafting recipe for {itemdef.Name}.");
                itemdef.StationLVLCfg = ValConfig.BindServerConfig($"{itemdef.Category} - {itemdef.Name}", $"{itemdef.DisplayName}-stationRequiredLevel", itemdef.ReqStationlevel, $"Sets the required minimum crafting station level to craft {itemdef.Name}", true, 1, 4);
                itemdef.CraftAmountCfg = ValConfig.BindServerConfig($"{itemdef.Category} - {itemdef.Name}", $"{itemdef.DisplayName}-craftAmount", itemdef.CraftAmount, $"Sets the amount of {itemdef.Name} crafted per recipe.", true, 1, 50);
                itemdef.CraftedAtCfg = ValConfig.BindServerConfig($"{itemdef.Category} - {itemdef.Name}", $"{itemdef.DisplayName}-craftedAt", itemdef.CraftedAt, $"Sets the crafting station for {itemdef.Name}.");
                // Setup the modifiable stats that this item has defined
                foreach (KeyValuePair<ItemStat, ItemStatConfig> stat in itemdef.ModifableStats) {
                    if (stat.Value.Configurable == false) { continue; }
                    if (stat.Value.IsInt) {
                        stat.Value.CfgInt = ValConfig.BindServerConfig($"{itemdef.Category} - {itemdef.Name}", $"{itemdef.DisplayName}-{stat.Key}", (int)stat.Value.Default_value, $"Value for {stat.Key} on {itemdef.Name}", true, (int)stat.Value.Min, (int)stat.Value.Max);
                    } else {
                        stat.Value.Cfg = ValConfig.BindServerConfig($"{itemdef.Category} - {itemdef.Name}", $"{itemdef.DisplayName}-{stat.Key}", stat.Value.Default_value, $"Value for {stat.Key} on {itemdef.Name}", true, stat.Value.Min, stat.Value.Max);
                    }
                }
                // Set the damage modifiers for this item
                if (itemdef.DamageMods != null) {
                    foreach (KeyValuePair<HitData.DamageType, HitCustomDamageMod> dmgmod in itemdef.DamageMods) {
                        dmgmod.Value.DmgModCfg = ValConfig.BindServerConfig($"{itemdef.Category} - {itemdef.Name}", $"{itemdef.DisplayName}-{dmgmod.Key}-DamageModifier", dmgmod.Value.DamageModifier.ToString(), $"Damage modifier for {dmgmod.Key} on {itemdef.Name}", true, allowedModifiers);
                    }
                }

                // Build the item recipe
                itemdef.Recipe.RecipeConfig = ValConfig.BindServerConfig($"{itemdef.Category} - {itemdef.Name}", $"{itemdef.DisplayName}-recipe", BuildStringRecipeFromItemDef(itemdef), $"Recipe for {itemdef.Name}. Should be in the format of Prefab,Amount,AmountPerLevel|Prefab,Amount,AmountPerLevel eg: Wood,12,2|Stone,2,0");
                if (ValidateRecipeConfig(itemdef) == false) {
                    BuildRecipeReqsFromDefault(itemdef);
                }
                // itemdef.recipe.resolvedRecipe = BuildRecipeFromConfig(itemdef);
                // Idol consumed per refinement at the Forge of Potential. Only upgradeable items define one.
                if (itemdef.UpgraderResource != null) {
                    itemdef.UpgraderResourceCfg = ValConfig.BindServerConfig($"{itemdef.Category} - {itemdef.Name}", $"{itemdef.DisplayName}-upgraderResource", itemdef.UpgraderResource, $"Item consumed for each refinement attempt when upgrading {itemdef.Name} past its max level at the Forge of Potential. Vanilla idols are Upgrader0Weapon-Upgrader7Weapon and Upgrader0Armor-Upgrader7Armor. Leave empty to disable refinement for this item.");
                }

                // Collapse this item's entries into a single grouped custom drawer to keep the in-game
                // Configuration Manager responsive (one visible row per item instead of ~10-20).
                ItemConfigDrawer.Attach(itemdef);
            }
            return true;
        }

        // TODO: Change batch onchange actions to pass to a queue and execute queue from a couroutine.
        private bool SetupOnChange() {
            foreach (ItemDefinition itemdef in resourceDefinitions) {
                // Need to have config onchange settings available for items which are not enabled to ensure that we can enable them when joining a remote server with different items enabled
                // if (!itemdef.enabled) { continue; }
                // Craftable config toggle
                itemdef.CraftableCfg.SettingChanged += (_, _) => {
                    ConfigChangeDebouncer.Schedule(itemdef.CraftableCfg, () => EnableDisableItemInDB(itemdef, itemdef.CraftableCfg.Value));
                };
                // Logger.LogInfo("Setup Craftable toggle");
                // Station level config
                itemdef.StationLVLCfg.SettingChanged += (_, _) => {
                    ConfigChangeDebouncer.Schedule(itemdef.StationLVLCfg, () => ModifyItemRecipeLevel(itemdef, itemdef.StationLVLCfg.Value));
                };
                // Logger.LogInfo("Setup Crafting station level");
                // Modify where the item is crafted
                itemdef.CraftedAtCfg.SettingChanged += (_, _) => {
                    ConfigChangeDebouncer.Schedule(itemdef.CraftedAtCfg, () => ModifyItemRecipeCraftedAt(itemdef));
                };
                // Modify how many of the item are crafted per recipe
                itemdef.CraftAmountCfg.SettingChanged += (_, _) => {
                    ConfigChangeDebouncer.Schedule(itemdef.CraftAmountCfg, () => ModifyItemRecipeCraftAmount(itemdef, itemdef.CraftAmountCfg.Value));
                };
                // Logger.LogInfo("Setup single value changes");

                // All of the configurable stat variables
                foreach (KeyValuePair<ItemStat, ItemStatConfig> stat in itemdef.ModifableStats) {
                    if (stat.Value.Configurable == false) { continue; }
                    object statKey = stat.Value.IsInt ? (object)stat.Value.CfgInt : stat.Value.Cfg;
                    void UpdateFromConfig(object sender, EventArgs args) {
                        ConfigChangeDebouncer.Schedule(statKey, () => {
                            if (ZNet.instance == null || ZNet.instance.enabled == false) { return; }
                            if (stat.Value.IsInt) {
                                stat.Value.Default_value = stat.Value.CfgInt.Value;
                            } else {
                                stat.Value.Default_value = stat.Value.Cfg.Value;
                            }
                            // Update player items
                            UpdateItemInPlayerInventory(itemdef.Prefab, (ItemDrop.ItemData item) => { ItemDataConfigModifier(stat.Key, stat.Value.Default_value, item); });
                            // Update in world items, batched into a single scan to prevent lag spikes (e.g. on server config sync).
                            EnqueueWorldUpdate(itemdef.Prefab, (ItemDrop.ItemData item) => { ItemDataConfigModifier(stat.Key, stat.Value.Default_value, item); });
                        });
                    }

                    if (stat.Value.IsInt) {
                        stat.Value.CfgInt.SettingChanged += UpdateFromConfig;
                    } else {
                        stat.Value.Cfg.SettingChanged += UpdateFromConfig;
                    }

                }
                // Logger.LogInfo("Setup stat changes");

                // Modify the recipe in the object DB
                itemdef.Recipe.RecipeConfig.SettingChanged += (sender, args) => {
                    ConfigChangeDebouncer.Schedule(itemdef.Recipe.RecipeConfig, () => {
                        if (ValidateRecipeConfig(itemdef)) {
                            ModifyItemRecipeInODB(itemdef);
                        }
                    });
                };
                // Logger.LogInfo("Setup recipe changes");

                // The Forge of Potential idol is rebuilt as part of the recipe requirements
                if (itemdef.UpgraderResourceCfg != null) {
                    itemdef.UpgraderResourceCfg.SettingChanged += (_, _) => {
                        ConfigChangeDebouncer.Schedule(itemdef.UpgraderResourceCfg, () => ModifyItemRecipeInODB(itemdef));
                    };
                }

                //Modify the damage modifiers
                if (itemdef.DamageMods == null) { continue; }
                foreach (KeyValuePair<HitData.DamageType, HitCustomDamageMod> dmgmod in itemdef.DamageMods) {
                    dmgmod.Value.DmgModCfg.SettingChanged += (_, _) => {
                        ConfigChangeDebouncer.Schedule(dmgmod.Value.DmgModCfg, () => {
                            if (ZNet.instance == null || ZNet.instance.enabled == false) { return; }
                            HitData.DamageModifier modifier = (HitData.DamageModifier)Enum.Parse(typeof(HitData.DamageModifier), dmgmod.Value.DmgModCfg.Value);
                            // Update player items
                            UpdateItemInPlayerInventory(itemdef.Prefab, (ItemDrop.ItemData item) => { SetItemDamageModifier(modifier, dmgmod.Key, item); });
                            // Update world items, batched into a single scan to prevent lag spikes (e.g. on server config sync).
                            EnqueueWorldUpdate(itemdef.Prefab, (ItemDrop.ItemData item) => { SetItemDamageModifier(modifier, dmgmod.Key, item); });
                        });
                    };
                }
            }
            return true;
        }


        // Idempotently reconciles every item recipe in the live ObjectDB to the current config values.
        // Safe to call repeatedly and from multiple lifecycle events; self guards when no ObjectDB exists.
        private static void ReapplyAllRecipeConfig() {
            if (ObjectDB.instance == null || ObjectDB.instance.m_recipes == null) { return; }
            // Every item below looks its recipe up several times. Without the index each lookup is a linear
            // search of the whole recipe list reading m_item.name (a native call that allocates), which made
            // this pass - run on every client for every config sync - one of the larger stalls.
            BuildRecipeIndexCache();
            try {
                foreach (ItemDefinition itemdef in resourceDefinitions) {
                    // Make sure the recipe is present before we try to modify it. A prior ObjectDB.CopyOtherDB
                    // (server join) can drop our custom recipes, so re-add disabled items too - their config is
                    // applied here and EnableDisableItemInDB sets the disabled flag last.
                    EnsureRecipeInDB(itemdef);
                    if (ValidateRecipeConfig(itemdef)) { ModifyItemRecipeInODB(itemdef); }
                    ModifyItemRecipeLevel(itemdef, itemdef.StationLVLCfg.Value);
                    ModifyItemRecipeCraftedAt(itemdef);
                    ModifyItemRecipeCraftAmount(itemdef, itemdef.CraftAmountCfg.Value);
                    EnableDisableItemInDB(itemdef, itemdef.CraftableCfg.Value);
                }
            } finally {
                recipeIndexCache = null;
            }
            // Refresh an open crafting panel so changed recipes/amounts/enabled state are reflected immediately.
            if (Player.m_localPlayer != null) { Player.m_localPlayer.UpdateKnownRecipesList(); }
        }

        // Fires when admin (server) config is synchronized to this client. Only re-apply when our plugin's
        // config was part of the sync payload to avoid needless work when other mods sync.
        private static void OnModConfigsChanged(object sender, ConfigurationSynchronizationEventArgs e) {
            if (e.UpdatedPluginGUIDs != null && e.UpdatedPluginGUIDs.Count > 0 && !e.UpdatedPluginGUIDs.Contains(global::ValheimArmory.ValheimArmory.PluginGUID)) {
                return;
            }
            ReapplyAllRecipeConfig();
        }

        private static bool BatchAddItems() {
            foreach (ItemDefinition itemdef in resourceDefinitions) {
                GameObject ItemPrefab = Assets.LoadAsset<GameObject>($"Assets/Custom/Weapons/{itemdef.Category}/{itemdef.Prefab}.prefab");
                Sprite ItemSprite = Assets.LoadAsset<Sprite>($"Assets/Custom/Icons/{itemdef.Icon}.png");
                //Logger.LogInfo($"Adding {itemdef.Name} gopath: {prefabPath} go: {ItemPrefab} sprite: {ItemSprite}");
                ItemDrop ItemD = ItemPrefab.GetComponent<ItemDrop>();
                // Modify this items stats
                foreach (KeyValuePair<ItemStat, ItemStatConfig> modstat in itemdef.ModifableStats) {
                    if (modstat.Value.Configurable == false) {
                        ItemDataConfigModifier(modstat.Key, modstat.Value.Default_value, ItemD.m_itemData);
                    } else {
                        if (modstat.Value.IsInt) {
                            ItemDataConfigModifier(modstat.Key, modstat.Value.CfgInt.Value, ItemD.m_itemData);
                        } else {
                            ItemDataConfigModifier(modstat.Key, modstat.Value.Cfg.Value, ItemD.m_itemData);
                        }
                    }
                }
                // Modify this items resistances
                if (itemdef.DamageMods != null) {
                    foreach (KeyValuePair<HitData.DamageType, HitCustomDamageMod> dmgmod in itemdef.DamageMods) {
                        if (dmgmod.Value.Configurable == false || dmgmod.Value.DmgModCfg == null) { continue; }
                        HitData.DamageModifier modifier = (HitData.DamageModifier)Enum.Parse(typeof(HitData.DamageModifier), dmgmod.Value.DmgModCfg.Value);
                        SetItemDamageModifier(modifier, dmgmod.Key, ItemD.m_itemData);
                    }
                }
                if (itemdef.Recipe.RecipeReqs == null || itemdef.Recipe.RecipeReqs.Count == 0) {
                    // No valid requirements resolved (empty/missing recipe definition and no usable config
                    // value). Registering a recipe with zero requirements would make the item free to craft,
                    // so register the item without one.
                    Logger.LogError($"Item '{itemdef.Name}' has no valid recipe requirements; registering it without a crafting recipe.");
                    ItemManager.Instance.AddItem(new CustomItem(ItemPrefab, fixReference: true));
                } else {
                    ItemConfig itemcfg = new ItemConfig() {
                        Amount = itemdef.CraftAmountCfg.Value,
                        CraftingStation = $"{itemdef.CraftedAtCfg.Value}",
                        MinStationLevel = itemdef.StationLVLCfg.Value,
                        // Always register as enabled so the recipe is added to and retained in the ObjectDB (a
                        // recipe registered disabled never gets cached/retained). The real craftable state is
                        // applied immediately after by ReapplyAllRecipeConfig -> EnableDisableItemInDB, so a
                        // disabled item still lives in the DB (m_enabled=false), stays modifiable, and re-enables
                        // correctly - including after a server ObjectDB copy replaces the recipe list.
                        Enabled = true,
                        Icons = new[] { ItemSprite },
                        Requirements = itemdef.Recipe.RecipeReqs.ToArray()
                    };
                    ItemManager.Instance.AddItem(new CustomItem(ItemPrefab, fixReference: true, itemcfg));
                }

                // This item needs to be included as a returnable arrow/bolt
                if (itemdef.Category == ItemCategory.Arrows) {
                    ArcheryAmmoToAdd.Add(itemdef.Prefab);
                }

                // This weapon also trains other skills when used
                if (itemdef.HybridSkills != null) {
                    HybridBloodWeapon.RegisterHybridWeapon(ItemD, itemdef.HybridSkills);
                }
            }
            return true;
        }



        private static void ItemDataConfigModifier(ItemStat target_attribute, float updatedValue, ItemDrop.ItemData itemData) {
            if (itemData == null) { return; }
            switch (target_attribute) {
                // Standard Dmg types
                case ItemStat.slash:
                    itemData.m_shared.m_damages.m_slash = updatedValue;
                    break;
                case ItemStat.slash_per_level:
                    itemData.m_shared.m_damagesPerLevel.m_slash = updatedValue;
                    break;
                case ItemStat.blunt:
                    itemData.m_shared.m_damages.m_blunt = updatedValue;
                    break;
                case ItemStat.blunt_per_level:
                    itemData.m_shared.m_damagesPerLevel.m_blunt = updatedValue;
                    break;
                case ItemStat.pierce:
                    itemData.m_shared.m_damages.m_pierce = updatedValue;
                    break;
                case ItemStat.pierce_per_level:
                    itemData.m_shared.m_damagesPerLevel.m_pierce = updatedValue;
                    break;
                // Special Damage Types
                case ItemStat.pickaxe:
                    itemData.m_shared.m_damages.m_pickaxe = updatedValue;
                    break;
                case ItemStat.pickaxe_per_level:
                    itemData.m_shared.m_damagesPerLevel.m_pickaxe = updatedValue;
                    break;
                case ItemStat.chop:
                    itemData.m_shared.m_damages.m_chop = updatedValue;
                    break;
                case ItemStat.chop_per_level:
                    itemData.m_shared.m_damagesPerLevel.m_chop = updatedValue;
                    break;
                case ItemStat.attack_force:
                    itemData.m_shared.m_attackForce = updatedValue;
                    break;
                case ItemStat.secondary_attack_force_multiply:
                    itemData.m_shared.m_secondaryAttack.m_forceMultiplier = updatedValue;
                    break;
                case ItemStat.primary_attack_force_multiply:
                    itemData.m_shared.m_attack.m_forceMultiplier = updatedValue;
                    break;
                // Elemental Damage Types
                case ItemStat.fire:
                    itemData.m_shared.m_damages.m_fire = updatedValue;
                    break;
                case ItemStat.fire_per_level:
                    itemData.m_shared.m_damagesPerLevel.m_fire = updatedValue;
                    break;
                case ItemStat.lightning:
                    itemData.m_shared.m_damages.m_lightning = updatedValue;
                    break;
                case ItemStat.lightning_per_level:
                    itemData.m_shared.m_damagesPerLevel.m_lightning = updatedValue;
                    break;
                case ItemStat.frost:
                    itemData.m_shared.m_damages.m_frost = updatedValue;
                    break;
                case ItemStat.frost_per_level:
                    itemData.m_shared.m_damagesPerLevel.m_frost = updatedValue;
                    break;
                case ItemStat.poison:
                    itemData.m_shared.m_damages.m_poison = updatedValue;
                    break;
                case ItemStat.poison_per_level:
                    itemData.m_shared.m_damagesPerLevel.m_poison = updatedValue;
                    break;
                case ItemStat.spirit:
                    itemData.m_shared.m_damages.m_spirit = updatedValue;
                    break;
                case ItemStat.spirit_per_level:
                    itemData.m_shared.m_damagesPerLevel.m_spirit = updatedValue;
                    break;
                // Block and parry
                case ItemStat.block_armor:
                    itemData.m_shared.m_blockPower = updatedValue;
                    break;
                case ItemStat.block_armor_per_level:
                    itemData.m_shared.m_blockPowerPerLevel = updatedValue;
                    break;
                case ItemStat.parry:
                    itemData.m_shared.m_timedBlockBonus = updatedValue;
                    break;
                case ItemStat.block_force:
                    itemData.m_shared.m_deflectionForce = updatedValue;
                    break;
                case ItemStat.block_force_per_level:
                    itemData.m_shared.m_deflectionForcePerLevel = updatedValue;
                    break;
                // Costs for attack types
                case ItemStat.primary_attack_stamina:
                    itemData.m_shared.m_attack.m_attackStamina = updatedValue;
                    break;
                case ItemStat.primary_attack_eitr:
                    itemData.m_shared.m_attack.m_attackEitr = updatedValue;
                    break;
                case ItemStat.primary_attack_flat_health_cost:
                    itemData.m_shared.m_attack.m_attackHealth = updatedValue;
                    break;
                case ItemStat.primary_attack_percent_health_cost:
                    itemData.m_shared.m_attack.m_attackHealthPercentage = updatedValue;
                    break;
                case ItemStat.primary_attack_health_returned:
                    itemData.m_shared.m_attack.m_attackHealthReturnHit = updatedValue;
                    break;
                case ItemStat.primary_attack_damage_bonus_per_missing_hp:
                    itemData.m_shared.m_attack.m_damageMultiplierPerMissingHP = updatedValue;
                    break;
                case ItemStat.primary_attack_projectile_count:
                    itemData.m_shared.m_attack.m_projectiles = (int)updatedValue;
                    break;
                case ItemStat.secondary_attack_stamina:
                    itemData.m_shared.m_secondaryAttack.m_attackStamina = updatedValue;
                    break;
                case ItemStat.secondary_attack_eitr:
                    itemData.m_shared.m_secondaryAttack.m_attackEitr = updatedValue;
                    break;
                case ItemStat.secondary_attack_flat_health_cost:
                    itemData.m_shared.m_secondaryAttack.m_attackHealth = updatedValue;
                    break;
                case ItemStat.secondary_attack_percent_health_cost:
                    itemData.m_shared.m_secondaryAttack.m_attackHealthPercentage = updatedValue;
                    break;
                // Speed Modifiers
                case ItemStat.movement_speed:
                    itemData.m_shared.m_movementModifier = updatedValue;
                    break;
                case ItemStat.bow_draw_speed:
                    itemData.m_shared.m_attack.m_drawDurationMin = updatedValue;
                    break;
                case ItemStat.crossbow_reload_speed:
                    itemData.m_shared.m_attack.m_reloadTime = updatedValue;
                    break;
                case ItemStat.crossbow_reload_stamina_drain:
                    itemData.m_shared.m_attack.m_reloadStaminaDrain = updatedValue;
                    break;
                case ItemStat.draw_stamina_drain:
                    itemData.m_shared.m_attack.m_drawStaminaDrain = updatedValue;
                    break;
                case ItemStat.projectile_velocity:
                    itemData.m_shared.m_attack.m_projectileVel = updatedValue;
                    break;
                case ItemStat.projectile_accuracy_max:
                    itemData.m_shared.m_attack.m_projectileAccuracy = (100f - updatedValue);
                    break;
                // Item Modifiers
                case ItemStat.durability:
                    itemData.m_shared.m_maxDurability = updatedValue;
                    break;
                case ItemStat.durability_per_level:
                    itemData.m_shared.m_durabilityPerLevel = updatedValue;
                    break;
                case ItemStat.max_item_level:
                    itemData.m_shared.m_maxQuality = (int)updatedValue;
                    break;
                case ItemStat.tool_level:
                    itemData.m_shared.m_toolTier = (int)updatedValue;
                    break;
                default:
                    Logger.LogWarning($"Unknown item stat {target_attribute} for {itemData.m_shared.m_name}");
                    break;
            }
        }

        private static bool ValidateRecipeConfig(ItemDefinition itemdef) {
            List<RequirementConfig> requirements = new List<RequirementConfig>();
            try {
                string[] recipeConfig = itemdef.Recipe.RecipeConfig.Value.Split('|');
                foreach (string ingredient in recipeConfig) {
                    // Logger.LogInfo($"Ingrediant details: {ingredient}");
                    string[] ingredientConfig = ingredient.Split(',');
                    if (ingredientConfig.Length == 1) {
                        // This is the first run or deleted config entry scenario
                        return false;
                    }
                    if (ingredientConfig.Length != 3) {
                        Logger.LogWarning($"Invalid ({itemdef.Name}) recipe config detected: {ingredient}. Needs three entries eg: Wood,1,1");
                        return false;
                    }
                    requirements.Add(new RequirementConfig { Item = ingredientConfig[0], Amount = int.Parse(ingredientConfig[1]), AmountPerLevel = int.Parse(ingredientConfig[2]) });
                }
                // Only happens if the recipe is valid
                itemdef.Recipe.RecipeReqs = requirements;
                return true;
            } catch {
                Logger.LogWarning($"Recipe is Invalid. Should have the format of Wood,1,1|Stone,2,0 - Prefab,cost,upgrade.");
                return false;
            }
        }

        private static void BuildRecipeReqsFromDefault(ItemDefinition itemdef) {
            List<RequirementConfig> requirements = new List<RequirementConfig>();
            foreach (var recipeIng in itemdef.Recipe.RecipeItems) {
                requirements.Add(new RequirementConfig { Item = recipeIng.Prefab, Amount = recipeIng.Amount, AmountPerLevel = recipeIng.UpgradeCost });
            }
            itemdef.Recipe.RecipeReqs = requirements;
        }

        private static string BuildStringRecipeFromItemDef(ItemDefinition itemdef) {
            List<string> recipe = new();
            foreach (var req in itemdef.Recipe.RecipeItems) {
                recipe.Add($"{req.Prefab},{req.Amount},{req.UpgradeCost}");
            }
            return string.Join("|", recipe);
        }

        private static bool ModifyItemRecipeCraftedAt(ItemDefinition itemdef) {
            if (ObjectDB.instance == null || ObjectDB.instance.m_recipes == null) { return false; }

            int index = GetRecipeIndexByPrefab(itemdef.Prefab);
            if (index == -1) {
                Logger.LogWarning($"Recipe of {itemdef.Prefab} not found in ObjectDB, recipe will not be modified.");
                // ObjectDB.instance.m_recipes.Add(BuildRecipeForItem(itemdef));
                return false;
            }
            CraftingStation craftable_at = PrefabManager.Instance.GetPrefab(itemdef.CraftedAtCfg.Value)?.GetComponent<CraftingStation>();
            if (craftable_at == null) {
                Logger.LogWarning($"Crafting Station {itemdef.CraftedAtCfg.Value} prefab not found, or does not have a crafting station componet.");
                return false;
            }
            ObjectDB.instance.m_recipes[index].m_craftingStation = craftable_at;
            // repair station should likely be split out into a seperate config
            ObjectDB.instance.m_recipes[index].m_repairStation = craftable_at;
            return true;
        }


        private static void ModifyItemRecipeInODB(ItemDefinition itemdef) {
            if (ObjectDB.instance == null || ObjectDB.instance.m_recipes == null) { return; }

            // if (itemdef.enabled == false) { return; }
            // Logger.LogInfo($"Modifying {itemdef.Name} recipe in OODB");
            int recipe_index = GetRecipeIndexByPrefab(itemdef.Prefab);
            if (recipe_index == -1) {
                Logger.LogWarning($"Recipe of {itemdef.Prefab} not found in ObjectDB, Recipe will not be modified.");
                //ObjectDB.instance.m_recipes.Add(BuildRecipeForItem(itemdef));
                return;
            }
            Recipe current_recipe = ObjectDB.instance.m_recipes[recipe_index];
            Recipe newRecipe = current_recipe;
            List<Piece.Requirement> newRequirements = new List<Piece.Requirement>();
            foreach (var req in itemdef.Recipe.RecipeReqs) {
                GameObject resgo = ObjectDB.instance.GetItemPrefab(req.Item);
                if (resgo == null) {
                    Logger.LogWarning($"Recipe for {itemdef.Prefab} has an invalid requirement {req.Item}.");
                    return;
                }
                newRequirements.Add(new Piece.Requirement { m_resItem = resgo.GetComponent<ItemDrop>(), m_amount = req.Amount, m_amountPerLevel = req.AmountPerLevel });
            }
            Piece.Requirement upgraderReq = BuildUpgraderRequirement(itemdef);
            if (upgraderReq != null) { newRequirements.Add(upgraderReq); }
            // newRecipe is the list's own entry at recipe_index and is edited in place, so there is nothing to
            // put back (an IndexOf to find it again was a second linear search per item).
            newRecipe.m_resources = newRequirements.ToArray();
            itemdef.Recipe.ResolvedRecipe = newRecipe;
        }

        // Builds the Forge of Potential requirement for this item, mirroring vanilla idol requirements: one idol per
        // attempt, only consumed at an upgrader station (normal stations ignore m_upgraderResource requirements).
        // Jotunn's RequirementConfig can't carry the upgrader flag, so this is only ever added directly to the ObjectDB recipe.
        private static Piece.Requirement BuildUpgraderRequirement(ItemDefinition itemdef) {
            if (itemdef.UpgraderResourceCfg == null) { return null; }
            string idolName = itemdef.UpgraderResourceCfg.Value?.Trim();
            if (string.IsNullOrEmpty(idolName)) { return null; }
            ItemDrop idol = ObjectDB.instance.GetItemPrefab(idolName)?.GetComponent<ItemDrop>();
            if (idol == null) {
                Logger.LogWarning($"Upgrader resource {idolName} for {itemdef.Prefab} not found, it will not be refinable at the Forge of Potential.");
                return null;
            }
            return new Piece.Requirement { m_resItem = idol, m_amount = 1, m_amountPerLevel = 0, m_upgraderResource = true, m_recover = false };
        }

        // Re-add itemdef's cached recipe to the live ObjectDB if a prior ObjectDB.CopyOtherDB (server join)
        // replaced m_recipes and dropped it. Keeps even disabled items present so their recipe can still be
        // modified and correctly re-enabled later.
        private static void EnsureRecipeInDB(ItemDefinition itemdef) {
            if (ObjectDB.instance == null || ObjectDB.instance.m_recipes == null) { return; }
            if (GetRecipeIndexByPrefab(itemdef.Prefab) != -1) { return; }
            if (itemdef.Recipe.ResolvedRecipe != null) {
                AddRecipeToDB(itemdef.Prefab, itemdef.Recipe.ResolvedRecipe);
            }
        }

        private static void EnableDisableItemInDB(ItemDefinition itemdef, bool enable) {
            if (ObjectDB.instance == null || ObjectDB.instance.m_recipes == null) { return; }

            int index = GetRecipeIndexByPrefab(itemdef.Prefab);
            if (index == -1) {
                // Recipe was dropped (e.g. server ObjectDB copy). Re-add our cached recipe so a disabled
                // item still lives in the DB and can be modified / re-enabled later.
                if (itemdef.Recipe.ResolvedRecipe != null) {
                    itemdef.Recipe.ResolvedRecipe.m_enabled = enable;
                    AddRecipeToDB(itemdef.Prefab, itemdef.Recipe.ResolvedRecipe);
                } else {
                    Logger.LogWarning($"Recipe of {itemdef.Prefab} not found in ObjectDB and no cached recipe to re-add.");
                }
                return;
            }
            // recipe exists in the ODB
            ObjectDB.instance.m_recipes[index].m_enabled = enable;
            itemdef.Recipe.ResolvedRecipe = ObjectDB.instance.m_recipes[index];
        }

        private static void ModifyItemRecipeLevel(ItemDefinition itemdef, int level) {
            if (ObjectDB.instance == null || ObjectDB.instance.m_recipes == null) { return; }
            // if (itemdef.enabled == false) { return; }
            int index = GetRecipeIndexByPrefab(itemdef.Prefab);
            if (index == -1) {
                Logger.LogWarning($"Recipe of {itemdef.Prefab} not found in ObjectDB, required level will not be modified.");
                // ObjectDB.instance.m_recipes.Add(BuildRecipeForItem(itemdef));
                return;
            }
            ObjectDB.instance.m_recipes[index].m_minStationLevel = level;
            // Update the stored recipe so if we use it to target things again it will still be accurate
            itemdef.Recipe.ResolvedRecipe = ObjectDB.instance.m_recipes[index];
        }

        private static void ModifyItemRecipeCraftAmount(ItemDefinition itemdef, int amount) {
            if (ObjectDB.instance == null || ObjectDB.instance.m_recipes == null) { return; }
            int index = GetRecipeIndexByPrefab(itemdef.Prefab);
            if (index == -1) {
                Logger.LogWarning($"Recipe of {itemdef.Prefab} not found in ObjectDB, craft amount will not be modified.");
                return;
            }
            ObjectDB.instance.m_recipes[index].m_amount = amount;
            // Update the stored recipe so if we use it to target things again it will still be accurate
            itemdef.Recipe.ResolvedRecipe = ObjectDB.instance.m_recipes[index];
        }

        private static int GetRecipeIndexByPrefab(string prefab) {
            if (recipeIndexCache != null) {
                return recipeIndexCache.TryGetValue(prefab, out int index) ? index : -1;
            }
            return ObjectDB.instance.m_recipes.FindIndex(m => m.m_item != null && m.m_item.name == prefab);
        }

        // Indexes the live recipe list by crafted prefab for one ReapplyAllRecipeConfig pass. Keeps the first
        // match for each prefab, so lookups land on the same recipe the FindIndex above would.
        private static void BuildRecipeIndexCache() {
            List<Recipe> recipes = ObjectDB.instance.m_recipes;
            recipeIndexCache = new Dictionary<string, int>(recipes.Count);
            for (int i = 0; i < recipes.Count; i++) {
                if (recipes[i] == null || recipes[i].m_item == null) { continue; }
                string name = recipes[i].m_item.name;
                if (recipeIndexCache.ContainsKey(name) == false) { recipeIndexCache.Add(name, i); }
            }
        }

        // Appends a recipe to the live ObjectDB, keeping an in-progress pass's index in step so the rest of
        // that pass can find it.
        private static void AddRecipeToDB(string prefab, Recipe recipe) {
            ObjectDB.instance.m_recipes.Add(recipe);
            if (recipeIndexCache != null && recipeIndexCache.ContainsKey(prefab) == false) {
                recipeIndexCache.Add(prefab, ObjectDB.instance.m_recipes.Count - 1);
            }
        }

        private static void SetItemDamageModifier(HitData.DamageModifier modifier, HitData.DamageType type, ItemDrop.ItemData itemData) {
            // Logger.LogInfo($"Setting {itemData.m_shared.m_name} damage modifier {modifier} for {type}");
            List<HitData.DamageModPair> temp = itemData.m_shared.m_damageModifiers.Where(entry => entry.m_type != type).ToList();
            if (temp.Count == 0) {
                itemData.m_shared.m_damageModifiers.Clear();
                itemData.m_shared.m_damageModifiers.Add(new HitData.DamageModPair() { m_modifier = modifier, m_type = type });
            } else {
                temp.Add(new HitData.DamageModPair() { m_modifier = modifier, m_type = type });
                itemData.m_shared.m_damageModifiers = temp;
            }
        }

        private static void UpdateItemInPlayerInventory(string prefab, Action<ItemDrop.ItemData> callback) {
            if (Player.m_localPlayer == null) { return; }
            foreach (ItemDrop.ItemData user_item in Player.m_localPlayer.m_inventory.GetAllItems()) {
                if (user_item == null) { continue; }
                if (user_item.m_dropPrefab.name != prefab) { continue; }
                callback(user_item);
            }
        }

        // Queues an in-world item update. All updates enqueued within a frame are applied together in a single
        // pass (see DrainWorldUpdates), collapsing N passes - one per changed setting during a config sync - into one.
        private static void EnqueueWorldUpdate(string prefab, Action<ItemDrop.ItemData> callback) {
            // Skip during game shutdown: the ThreadingHelper's MonoBehaviour is destroyed (StartCoroutine
            // would throw) and there are no in-world items left to update. Unity's '==' treats it as null.
            BepInEx.ThreadingHelper host = BepInEx.ThreadingHelper.Instance;
            if (host == null) { return; }
            pendingWorldUpdates.Add(new KeyValuePair<string, Action<ItemDrop.ItemData>>(prefab, callback));
            if (worldUpdateScheduled) { return; }
            worldUpdateScheduled = true;
            host.StartCoroutine(DrainWorldUpdates());
        }

        // Applies all queued in-world item updates to each prefab and its live drops, in a single pass.
        private static IEnumerator DrainWorldUpdates() {
            // Wait a frame so the full burst of SettingChanged handlers (e.g. an entire config sync) enqueues first.
            yield return null;
            try {
                if (pendingWorldUpdates.Count > 0) {
                    // Grouped by prefab, so each live drop costs one lookup however many updates are queued.
                    Dictionary<string, List<Action<ItemDrop.ItemData>>> updatesByPrefab = new Dictionary<string, List<Action<ItemDrop.ItemData>>>();
                    foreach (KeyValuePair<string, Action<ItemDrop.ItemData>> update in pendingWorldUpdates) {
                        if (updatesByPrefab.TryGetValue(update.Key, out List<Action<ItemDrop.ItemData>> callbacks) == false) {
                            callbacks = new List<Action<ItemDrop.ItemData>>();
                            updatesByPrefab.Add(update.Key, callbacks);
                        }
                        callbacks.Add(update.Value);
                    }
                    // Exact name matches only (see LiveItemDrops): StartsWith would also hit prefabs that merely
                    // share the prefix ("ArrowWood" -> "ArrowWoodFire") and silently rewrite that item's stats.
                    LiveItemDrops.ForEach(updatesByPrefab.Keys, (prefab, id) => {
                        foreach (Action<ItemDrop.ItemData> callback in updatesByPrefab[prefab]) {
                            callback(id.m_itemData);
                        }
                    });
                }
            } finally {
                pendingWorldUpdates.Clear();
                worldUpdateScheduled = false;
            }
        }

        static void AddAmmoItemsToArcheryTarget() {
            GameObject archerTarget = PrefabManager.Instance.GetPrefab("piece_ArcheryTarget");
            ArcheryTarget ArcherAmmoManger = archerTarget.GetComponentInChildren<ArcheryTarget>(true);

            foreach (string ammoPrefab in ArcheryAmmoToAdd) {
                Logger.LogDebug($"Adding {ammoPrefab} to Archery Target Ammo Return.");
                ItemDrop ammoID = PrefabManager.Instance.GetPrefab(ammoPrefab).GetComponent<ItemDrop>();
                if (ammoID != null && ArcherAmmoManger.m_returnAmmo.Contains(ammoID) == false) {
                    ArcherAmmoManger.m_returnAmmo.Add(ammoID);
                }
            }
        }
    }
}
