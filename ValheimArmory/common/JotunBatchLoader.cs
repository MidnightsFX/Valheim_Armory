using BepInEx.Configuration;
using Jotunn;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ValheimArmory.common
{
    class JotunBatchLoader : MonoBehaviour
    {
        internal static List<ItemDefinition> resourceDefinitions = new List<ItemDefinition>();
        internal static Queue<Action> queuedModifications = new Queue<Action>();
        internal static bool runningQueuedChanges = false;
        internal static AssetBundle Assets;

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
            if (reverse_order){
                resourceDefinitions.Reverse();
            }
            WireConfigDefs();

            bool on_server = false;
            if (ZNet.instance != null && ZNet.instance.IsServerInstance()) {
                on_server = true;
            }

            if (on_server == false) {       
                // This is not needed on the server
                // The server does not actually do anything with prefabs, and is not responsible for modifying them
                BatchAddItems();
                SetupOnChange();

            }


            VAConfig.SaveOnSet(true);

            return true;
        }

        public bool AddDefinition(ItemDefinition itemdef) {
            resourceDefinitions.Add(itemdef);
            return true;
        }

        private static bool WireConfigDefs() { 
            // Ensure save on set is false, we will save at the end of this process.
            foreach (ItemDefinition itemdef in resourceDefinitions) {
                // Build a compacted display name for reference, this primarily just needs spaces removed.
                itemdef.DisplayName = string.Join("", itemdef.Name.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
                itemdef.enabled = VAConfig.BindServerConfig($"{itemdef.Category} - {itemdef.Name}", $"{itemdef.DisplayName}-enabled", itemdef.enabled, $"Enable/Disable the {itemdef.Name}. Items set to Disabled will not be loaded. Requires a restart if changed while the game is running.").Value;
                // Skip over all loading of items that are disabled.
                if (!itemdef.enabled) { continue; }
                itemdef.craftable_cfg = VAConfig.BindServerConfig($"{itemdef.Category} - {itemdef.Name}", $"{itemdef.DisplayName}-craftable", itemdef.craftable, $"Enable/Disable the crafting recipe for {itemdef.Name}.");
                itemdef.stationlvl_cfg = VAConfig.BindServerConfig($"{itemdef.Category} - {itemdef.Name}", $"{itemdef.DisplayName}-stationRequiredLevel", itemdef.reqStationlevel, $"Sets the required minimum crafting station level to craft {itemdef.Name}", true, 1, 4);
                itemdef.craftAmount_cfg = VAConfig.BindServerConfig($"{itemdef.Category} - {itemdef.Name}", $"{itemdef.DisplayName}-craftAmount", itemdef.craftAmount, $"Sets the amount of {itemdef.Name} crafted per recipe.", true, 1, 50);
                itemdef.craftedAt_cfg = VAConfig.BindServerConfig($"{itemdef.Category} - {itemdef.Name}", $"{itemdef.DisplayName}-craftedAt", itemdef.craftedAt, $"Sets the crafting station for {itemdef.Name}.");
                // Setup the modifiable stats that this item has defined
                foreach (KeyValuePair<ItemStat, ItemStatConfig> stat in itemdef.modifableStats) {
                    if (stat.Value.configurable == false) { continue; }
                    stat.Value.cfg= VAConfig.BindServerConfig($"{itemdef.Category} - {itemdef.Name}", $"{itemdef.DisplayName}-{stat.Key}", stat.Value.default_value, $"Value for {stat.Key} on {itemdef.Name}", true, stat.Value.min, stat.Value.max);
                }
                // Set the damage modifiers for this item
                if (itemdef.damageMods != null) {
                    foreach (KeyValuePair<HitData.DamageType, HitCustomDamageMod> dmgmod in itemdef.damageMods) {
                        dmgmod.Value.dmgModcfg = VAConfig.BindServerConfig($"{itemdef.Category} - {itemdef.Name}", $"{itemdef.DisplayName}-{dmgmod.Key}-DamageModifier", dmgmod.Value.damageModifier.ToString(), $"Damage modifier for {dmgmod.Key} on {itemdef.Name}", true, allowedModifiers);
                    }
                }

                // Build the item recipe
                itemdef.recipe.recipeConfig = VAConfig.BindServerConfig($"{itemdef.Category} - {itemdef.Name}", $"{itemdef.DisplayName}-recipe", "", $"Recipe for {itemdef.Name}. Should be in the format of Prefab,Amount,AmountPerLevel|Prefab,Amount,AmountPerLevel eg: Wood,12,2|Stone,2,0");
                if (ValidateRecipeConfig(itemdef) == false) { 
                    BuildRecipeReqsFromDefault(itemdef); 
                }
                // itemdef.recipe.resolvedRecipe = BuildRecipeFromConfig(itemdef);
            }
            return true;
        }

        // TODO: Change batch onchange actions to pass to a queue and execute queue from a couroutine.
        private bool SetupOnChange(){
            foreach (ItemDefinition itemdef in resourceDefinitions) {
                if (!itemdef.enabled) { continue; }
                // Craftable config toggle
                itemdef.craftable_cfg.SettingChanged += (_, _) => {
                    Action mod = () => { EnableDisableItemInDB(itemdef, itemdef.craftable_cfg.Value); };
                    queuedModifications.Enqueue(mod);
                    StartCoroutine(RunQueuedModification());
                };
                // Logger.LogInfo("Setup Craftable toggle");
                // Station level config
                itemdef.stationlvl_cfg.SettingChanged += (_, _) => {
                    Action mod = () => { ModifyItemRecipeLevel(itemdef, itemdef.stationlvl_cfg.Value); };
                    queuedModifications.Enqueue(mod);
                    StartCoroutine(RunQueuedModification());
                };
                // Logger.LogInfo("Setup Crafting station level");
                // Modify where the item is crafted
                itemdef.craftedAt_cfg.SettingChanged += (_, _) => {
                    Action mod = () => { ModifyItemRecipeCraftedAt(itemdef, itemdef.craftedAt_cfg.Value); };
                    queuedModifications.Enqueue(mod);
                    StartCoroutine(RunQueuedModification());
                };
                // Logger.LogInfo("Setup single value changes");
                
                // All of the configurable stat variables
                foreach (KeyValuePair<ItemStat, ItemStatConfig> stat in itemdef.modifableStats) {
                    if (stat.Value.configurable == false) { continue; }
                    stat.Value.cfg.SettingChanged += (sender, args) => {
                        Action mod = () => {
                            stat.Value.default_value = stat.Value.cfg.Value;
                            // Update player items
                            UpdateItemInPlayerInventory(itemdef.prefab, (ItemDrop.ItemData item) => { ItemDataConfigModifier(stat.Key, stat.Value.default_value, item); });
                            // Update in world items, this is delayed and batched to prevent lag spikes.
                            IEnumerable<GameObject> objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name.StartsWith(itemdef.prefab));
                            // UpdateItemInWorldAsync(objects, true, (ItemDrop.ItemData item) => { ItemDataConfigModifier(stat.Key, stat.Value.default_value, item); });
                            StartCoroutine(UpdateItemInWorldAsync(objects, true, (ItemDrop.ItemData item) => { ItemDataConfigModifier(stat.Key, stat.Value.default_value, item); }));
                        };
                        queuedModifications.Enqueue(mod);
                        StartCoroutine(RunQueuedModification());
                    };
                }
                // Logger.LogInfo("Setup stat changes");

                // Modify the recipe in the object DB
                itemdef.recipe.recipeConfig.SettingChanged += (sender, args) => {
                    if (ValidateRecipeConfig(itemdef)) {
                        Action mod = () => { ModifyItemRecipeInODB(itemdef); };
                        queuedModifications.Enqueue(mod);
                        StartCoroutine(RunQueuedModification());
                    }
                };
                // Logger.LogInfo("Setup recipe changes");

                //Modify the damage modifiers
                if (itemdef.damageMods == null) { continue; }
                foreach (KeyValuePair<HitData.DamageType, HitCustomDamageMod> dmgmod in itemdef.damageMods)
                {
                    dmgmod.Value.dmgModcfg.SettingChanged += (_, _) => {
                        Action mod = () =>
                        {
                            HitData.DamageModifier modifier = (HitData.DamageModifier)Enum.Parse(typeof(HitData.DamageModifier), dmgmod.Value.dmgModcfg.Value);
                            // Update player items
                            UpdateItemInPlayerInventory(itemdef.prefab, (ItemDrop.ItemData item) => { SetItemDamageModifier(modifier, dmgmod.Key, item); });
                            IEnumerable<GameObject> objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name.StartsWith(itemdef.prefab));
                            // Update world items
                            // UpdateItemInWorldAsync(objects, false, (ItemDrop.ItemData item) => { SetItemDamageModifier(modifier, dmgmod.Key, item); });
                            StartCoroutine(UpdateItemInWorldAsync(objects, false, (ItemDrop.ItemData item) => { SetItemDamageModifier(modifier, dmgmod.Key, item); }));
                        };
                        queuedModifications.Enqueue(mod);
                        StartCoroutine(RunQueuedModification());
                    };
                }
            }
            return true;
        }

        private static bool BatchAddItems() {
            foreach (ItemDefinition itemdef in resourceDefinitions) {
                if (!itemdef.enabled) { continue; }
                // Add item to game
                GameObject ItemPrefab = Assets.LoadAsset<GameObject>($"Assets/Custom/Weapons/{itemdef.Category}/{itemdef.prefab}.prefab");
                Sprite ItemSprite = Assets.LoadAsset<Sprite>($"Assets/Custom/Icons/{itemdef.icon}.png");
                ItemDrop ItemD = ItemPrefab.GetComponent<ItemDrop>();
                foreach(KeyValuePair<ItemStat, ItemStatConfig> modstat in itemdef.modifableStats) {
                    if (modstat.Value.configurable == false) { continue; }
                    ItemDataConfigModifier(modstat.Key, modstat.Value.cfg.Value, ItemD.m_itemData);
                }
                ItemConfig itemcfg = new ItemConfig() {
                    Amount = itemdef.craftAmount_cfg.Value,
                    CraftingStation = $"{itemdef.craftedAt_cfg.Value}",
                    MinStationLevel = itemdef.stationlvl_cfg.Value,
                    Enabled = itemdef.craftable_cfg.Value,
                    Icons = new[] { ItemSprite },
                    Requirements = itemdef.recipe.recipeReqs.ToArray()
                };
                ItemManager.Instance.AddItem(new CustomItem(ItemPrefab, fixReference: true, itemcfg));
                // itemdef.recipe.resolvedRecipe = itemcfg.GetRecipe();
            }
            return true;
        }



        private static void ItemDataConfigModifier(ItemStat target_attribute, float updatedValue, ItemDrop.ItemData itemData)
        {
            if (itemData == null) { return; }
            switch (target_attribute)
            {
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
                    break;
            }
        }

        private static bool ValidateRecipeConfig(ItemDefinition itemdef) {
            List<RequirementConfig> requirements = new List<RequirementConfig>();
            try {
                string[] recipeConfig = itemdef.recipe.recipeConfig.Value.Split('|');
                foreach (string ingredient in recipeConfig) {
                    // Logger.LogInfo($"Ingrediant details: {ingredient}");
                    string[] ingredientConfig = ingredient.Split(',');
                    if (ingredientConfig.Length != 3) {
                        Logger.LogWarning($"Invalid recipe config detected: {ingredient}. Needs three entries eg: Wood,1,1");
                        return false;
                    }
                    requirements.Add(new RequirementConfig { Item = ingredientConfig[0], Amount = int.Parse(ingredientConfig[1]), AmountPerLevel = int.Parse(ingredientConfig[2]) });
                }
                // Only happens if the recipe is valid
                itemdef.recipe.recipeReqs = requirements;
                return true;
            } catch {
                Logger.LogWarning($"Recipe is Invalid. Should have the format of Wood,1,1|Stone,2,0 - Prefab,cost,upgrade.");
                return false;
            }
        }

        private static void BuildRecipeReqsFromDefault(ItemDefinition itemdef) {
            List<RequirementConfig> requirements = new List<RequirementConfig>();
            foreach(var recipeIng in itemdef.recipe.recipeItems) {
                requirements.Add(new RequirementConfig { Item = recipeIng.prefab, Amount = recipeIng.amount, AmountPerLevel = recipeIng.upgradeCost });
            }
            itemdef.recipe.recipeReqs = requirements;
        }

        private static bool ModifyItemRecipeCraftedAt(ItemDefinition itemdef, string craftedAt) {
            int index = ObjectDB.instance.m_recipes.IndexOf(GetRecipeByPrefab(itemdef));
            if (index == -1) {
                Logger.LogWarning($"Recipe of {itemdef.prefab} not found in ObjectDB.");
                return false;
            }
            CraftingStation craftable_at = PrefabManager.Instance.GetPrefab(itemdef.craftedAt_cfg.Value)?.GetComponent<CraftingStation>();
            if (craftable_at == null) {
                Logger.LogWarning($"Crafting Station {itemdef.craftedAt_cfg.Value} prefab not found, or does not have a crafting station componet.");
                return  false;
            }
            ObjectDB.instance.m_recipes[index].m_craftingStation = craftable_at;
            // repair station should likely be split out into a seperate config
            ObjectDB.instance.m_recipes[index].m_repairStation = craftable_at;
            return true;
        }


        private static void ModifyItemRecipeInODB(ItemDefinition itemdef) {
            Recipe current_recipe = GetRecipeByPrefab(itemdef);
            Recipe newRecipe = current_recipe;
            List<Piece.Requirement> newRequirements = new List<Piece.Requirement>();
            foreach (var req in itemdef.recipe.recipeReqs)
            {
                GameObject resgo = ObjectDB.instance.GetItemPrefab(req.Item);
                if (resgo == null) {
                    Logger.LogWarning($"Recipe {itemdef.recipe.resolvedRecipe.name} has an invalid requirement {req.Item}.");
                    return;
                }
                newRequirements.Add(new Piece.Requirement { m_resItem = resgo.GetComponent<ItemDrop>(), m_amount = req.Amount, m_amountPerLevel = req.AmountPerLevel });
            }
            newRecipe.m_resources = newRequirements.ToArray();

            int index = ObjectDB.instance.m_recipes.IndexOf(current_recipe);
            if (index > -1) {
                ObjectDB.instance.m_recipes[index] = newRecipe;
                itemdef.recipe.resolvedRecipe = newRecipe;
            } else {
                Logger.LogWarning($"Recipe {current_recipe.name} not found in ObjectDB.");
            }
        }

        private static void EnableDisableItemInDB(ItemDefinition itemdef, bool enable) {
            int index = ObjectDB.instance.m_recipes.IndexOf(GetRecipeByPrefab(itemdef));
            Logger.LogWarning($"Enable/Disable item in ODB. target state: {enable}");
            if (index == -1) {
                Logger.LogWarning($"Recipe of {itemdef.prefab} not found in ObjectDB.");
                return; 
            }
            if (enable) {
                ObjectDB.instance.m_recipes[index].m_enabled = true;
            } else {
                ObjectDB.instance.m_recipes[index].m_enabled = false;
            }
            itemdef.recipe.resolvedRecipe = ObjectDB.instance.m_recipes[index];
        }

        private static void ModifyItemRecipeLevel(ItemDefinition itemdef, int level) {
            int index = ObjectDB.instance.m_recipes.IndexOf(GetRecipeByPrefab(itemdef));
            if (index == -1) {
                Logger.LogWarning($"Recipe of {itemdef.prefab} not found in ObjectDB.");
                return;
            }
            ObjectDB.instance.m_recipes[index].m_minStationLevel = level;
            // Update the stored recipe so if we use it to target things again it will still be accurate
            itemdef.recipe.resolvedRecipe = ObjectDB.instance.m_recipes[index];
        }

        private static Recipe GetRecipeByPrefab(ItemDefinition itemdef, bool lookup = false) {
            if (itemdef.recipe.resolvedRecipe != null && lookup == false) {
                return itemdef.recipe.resolvedRecipe;
            }

            GameObject go = PrefabManager.Instance.GetPrefab(itemdef.prefab);
            ItemDrop itemDrop = go.GetComponent<ItemDrop>();
            Recipe target_recipe = ObjectDB.instance.GetRecipe(itemDrop.m_itemData);
            itemdef.recipe.resolvedRecipe = target_recipe;
            return target_recipe;
        }

        private static void SetItemDamageModifier(HitData.DamageModifier modifier, HitData.DamageType type, ItemDrop.ItemData itemData) {
            List<HitData.DamageModPair> temp = itemData.m_shared.m_damageModifiers.Where(entry => entry.m_type != type).ToList();
            if (temp.Count == 0)
            {
                itemData.m_shared.m_damageModifiers.Clear();
                itemData.m_shared.m_damageModifiers.Add(new HitData.DamageModPair() { m_modifier = modifier, m_type = type });
            }
            else
            {
                temp.Add(new HitData.DamageModPair() { m_modifier = modifier, m_type = type });
                itemData.m_shared.m_damageModifiers = temp;
            }
        }

        private static void UpdateItemInPlayerInventory(string prefab, Action<ItemDrop.ItemData> callback) {
            foreach (ItemDrop.ItemData user_item in Player.m_localPlayer.m_inventory.GetAllItems()) {
                if (user_item == null) { continue; }
                if (user_item.m_dropPrefab.name != prefab) { continue; }
                callback(user_item);
            }
        }

        static IEnumerator UpdateItemInWorldAsync(IEnumerable<GameObject> objects, bool start_sleep, Action<ItemDrop.ItemData> callback) {
            if (objects == null || objects.Count() == 0) { yield break; }
            if (start_sleep) { yield return new WaitForSeconds(0.5f); }
            Logger.LogDebug($"Updating {objects.Count()} objects in the world.");
            int concurrent_updates = VAConfig.InMemoryModificationsPerTick.Value;
            int update_num = 0;
            foreach (GameObject go in objects)
            {
                if (update_num >= concurrent_updates) {
                    yield return new WaitForSeconds(0.5f);
                    update_num = 0;
                }
                ItemDrop id = null;
                if (go.TryGetComponent<ItemDrop>(out id)) {
                    Logger.LogDebug($"Updating {id.m_itemData.m_shared.m_name}");
                    callback(id.m_itemData);
                }
            }
            yield break;
        }

        static IEnumerator RunQueuedModification() {
            if (queuedModifications.Count == 0 || runningQueuedChanges == true) {
                yield break;
            }
            runningQueuedChanges = true;
            // wait for a tiny bit to give ourselves a good chance of catching bulk changes
            yield return new WaitForSeconds(0.5f);
            int concurrent_updates = VAConfig.InMemoryModificationsPerTick.Value;
            int op_num = 0;
            while (queuedModifications.Count > 0) {
                op_num ++;
                if (op_num >= concurrent_updates) {
                    yield return new WaitForSeconds(0.2f);
                    op_num = 0;
                }
                queuedModifications.Dequeue().Invoke();
            }
            runningQueuedChanges = false;
            yield break;
        }
    }
}
