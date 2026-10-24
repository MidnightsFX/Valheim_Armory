using BepInEx.Configuration;
using Jotunn.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ValheimArmory.Common;

namespace ValheimArmory.patches
{
    // A dual wielded copy of every one handed sword, vanilla and this mod's, held and swung with the vanilla dual axes
    // animations. Each copy keeps its sword's look and on-hit effects and only changes how it is held and swung.
    //
    // Nothing is rigged. This mod's dual axes and knives put skinned blades in attach_skin, but every vertex there is
    // weighted to a single hand bone, and each blade sits exactly where a one handed weapon's attach sits at
    // RightHand_Attach / LeftHand_Attach. So the copy keeps the sword's own attach, which the game shows in the right hand
    // as usual, and DualSwordVisuals shows that same attach in the left hand.
    //
    // The swords are found rather than listed: vanilla's are the one handed swords with a recipe in the game's own
    // ObjectDB (the dev only swords have none), and this mod's come from its item definitions. Each copy then becomes an
    // item definition of its own, added through JotunBatchLoader like the asset bundle's items, so it gets its own
    // config: stats and recipe start out as the sword's and can be balanced apart from it. A copy is always registered,
    // whatever the config says, so saves holding one stay valid; the config only decides who can craft it.
    public static class DualSwords
    {
        private const string Section = "Dual Swords";
        // Vanilla's dual axes. Their two attacks give the copies their motion: the four swing dualaxes chain and the
        // dualaxes_secondary spin.
        private const string DualAxes = "AxeBerzerkr";
        private const string PrefabPrefix = "VADual_";
        // The pair's default recipe takes this many times the sword's materials, both to craft and for each upgrade.
        private const float MaterialMultiplier = 1.5f;

        // English names of vanilla's swords. The copies' config sections are named after them, and must not change with
        // the game's language. A sword missing here (eg: one a later game update adds) is named after its prefab.
        private static readonly Dictionary<string, string> VanillaNames = new Dictionary<string, string> {
            { "SwordWood", "Wooden Sword" },
            { "SwordBronze", "Bronze Sword" },
            { "SwordIron", "Iron Sword" },
            { "SwordSilver", "Silver Sword" },
            { "SwordBlackmetal", "Black Metal Sword" },
            { "SwordMistwalker", "Mistwalker" },
            { "SwordNiedhogg", "Nidhogg" },
            { "SwordNiedhoggBlood", "Nidhogg the Bleeding" },
            { "SwordNiedhoggLightning", "Nidhogg the Thundering" },
            { "SwordNiedhoggNature", "Nidhogg the Primal" },
            { "SwordDyrnwyn", "Dyrnwyn" },
            { "SwordGold", "Nord Sword" },
            { "SwordGold_FrostFire", "Frostfire Sword" },
            { "SwordGold_BloodLightning", "Thunderblood Sword" },
        };

        public static ConfigEntry<bool> Enabled;

        // Sword prefab -> its dual copy's prefab.
        private static readonly Dictionary<string, string> DualBySword = new Dictionary<string, string>();
        private static readonly HashSet<string> DualPrefabs = new HashSet<string>();
        // Hashes of the dual copy prefabs, as VisEquipment and the ZDO carry them.
        internal static readonly HashSet<int> DualHashes = new HashSet<int>();

        // A sword to copy: this mod's carry their item definition, vanilla's the recipe from the game's ObjectDB.
        private class Sword
        {
            public ItemDrop Item;
            public ItemDefinition Definition;
            public Recipe Recipe;
        }

        internal static void BindConfig()
        {
            Enabled = ValConfig.BindServerConfig(Section, "EnableDualSwords", true, "Lets every one handed sword, vanilla and Valheim Armory, be crafted as a dual wielded pair that swings like dual axes. Each pair has its own settings, under Swords - Dual <sword>. Disabling only removes the recipes: dual swords already made keep working.");
            ValConfig.OnChangeDebounced(Enabled, OnEnabledChanged);
        }

        private static void OnEnabledChanged(object sender, EventArgs e)
        {
            JotunBatchLoader.ReapplyAllRecipeConfig();
        }

        // False for a dual sword while they are all switched off. Its own craftable config applies on top.
        internal static bool CraftingAllowed(string prefab)
        {
            return Enabled.Value || DualPrefabs.Contains(prefab) == false;
        }

        // Vanilla swords can only be copied once the game's prefabs are loaded. Runs once: Jotunn adds the copies to
        // every ObjectDB from then on.
        internal static void CreateDualSwords()
        {
            PrefabManager.OnVanillaPrefabsAvailable -= CreateDualSwords;
            GameObject dualAxes = PrefabManager.Instance.GetPrefab(DualAxes);
            if (dualAxes == null) {
                Logger.LogWarning($"Vanilla {DualAxes} was not found, no dual swords will be added.");
                return;
            }
            ItemDrop.ItemData.SharedData dualAxesShared = dualAxes.GetComponent<ItemDrop>().m_itemData.m_shared;
            ObjectDB vanilla = FejdStartup.instance != null && FejdStartup.instance.m_objectDBPrefab != null ? FejdStartup.instance.m_objectDBPrefab.GetComponent<ObjectDB>() : null;
            List<Sword> swords = VanillaSwords(vanilla).Concat(ArmorySwords()).ToList();
            // Every pair is named before any recipe is built, so a variant's recipe can ask for its base sword's pair.
            foreach (Sword sword in swords) {
                DualBySword[sword.Item.name] = PrefabPrefix + sword.Item.name;
            }
            List<ItemDefinition> definitions = new List<ItemDefinition>();
            foreach (Sword sword in swords) {
                ItemDefinition dual = CreateDualSword(sword, dualAxesShared, vanilla);
                if (dual == null) { continue; }
                definitions.Add(dual);
                DualPrefabs.Add(dual.Prefab);
                DualHashes.Add(dual.Prefab.GetStableHashCode());
            }
            JotunBatchLoader.AddGeneratedDefinitions(definitions);
            Logger.LogInfo($"Added {definitions.Count} dual swords.");
        }

        // The one handed swords that the game's own ObjectDB has a recipe for. Read from the ObjectDB prefab, as
        // OnVanillaPrefabsAvailable runs just before the menu's ObjectDB is filled from it.
        private static IEnumerable<Sword> VanillaSwords(ObjectDB vanilla)
        {
            if (vanilla == null) {
                Logger.LogWarning("The game's ObjectDB was not found, vanilla swords get no dual version.");
                return Enumerable.Empty<Sword>();
            }
            return vanilla.m_recipes
                .Where(recipe => recipe != null && recipe.m_enabled && IsOneHandedSword(recipe.m_item))
                .GroupBy(recipe => recipe.m_item.name)
                .Select(recipes => new Sword { Item = recipes.First().m_item, Recipe = recipes.First() });
        }

        private static IEnumerable<Sword> ArmorySwords()
        {
            foreach (ItemDefinition itemdef in JotunBatchLoader.resourceDefinitions.Where(def => def.Category == ItemCategory.Swords && def.GeneratedPrefab == null).ToList()) {
                ItemDrop item = PrefabManager.Instance.GetPrefab(itemdef.Prefab)?.GetComponent<ItemDrop>();
                if (IsOneHandedSword(item)) {
                    yield return new Sword { Item = item, Definition = itemdef };
                }
            }
        }

        // The tankards are one handed weapons on the swords skill too, but are held like a torch, so only what is swung
        // like a one handed weapon counts.
        private static bool IsOneHandedSword(ItemDrop item)
        {
            if (item == null) { return false; }
            ItemDrop.ItemData.SharedData shared = item.m_itemData.m_shared;
            return shared.m_itemType == ItemDrop.ItemData.ItemType.OneHandedWeapon && shared.m_skillType == Skills.SkillType.Swords
                && shared.m_animationState == ItemDrop.ItemData.AnimationState.OneHanded;
        }

        // Copies the sword and changes how the copy is held and swung, then describes it as an item definition whose
        // defaults are the sword's: its stats, and its recipe with MaterialMultiplier times the materials.
        private static ItemDefinition CreateDualSword(Sword sword, ItemDrop.ItemData.SharedData dualAxes, ObjectDB vanilla)
        {
            string dualPrefab = DualBySword[sword.Item.name];
            GameObject prefab = PrefabManager.Instance.CreateClonedPrefab(dualPrefab, sword.Item.gameObject);
            if (prefab == null) {
                Logger.LogWarning($"Could not copy {sword.Item.name}, it gets no dual version.");
                return null;
            }
            ItemDrop.ItemData.SharedData shared = prefab.GetComponent<ItemDrop>().m_itemData.m_shared;
            ItemDrop.ItemData.SharedData swordShared = sword.Item.m_itemData.m_shared;
            // Different from the sword's name, which also keeps a crafting recipe from taking a dual sword in place of a
            // sword: inventories match requirements by name.
            shared.m_name = $"$item_dual_va {swordShared.m_name}";
            shared.m_description = $"{swordShared.m_description}\n\n$item_dual_va_description";
            // Two handed empties the left hand for the second sword, and leaves the right hand item to pick the
            // animation state. Sheathed, the pair hangs where a sword does.
            shared.m_itemType = ItemDrop.ItemData.ItemType.TwoHandedWeapon;
            shared.m_animationState = ItemDrop.ItemData.AnimationState.DualAxes;
            shared.m_attachOverride = ItemDrop.ItemData.ItemType.OneHandedWeapon;
            // Both reach as far as the sword's swing, as the blade is longer than an axe. The sword's own secondary is a
            // thrust, with a longer reach than the spin.
            shared.m_attack = DualAttack(dualAxes.m_attack, swordShared.m_attack, swordShared.m_attack.m_attackRange);
            shared.m_secondaryAttack = DualAttack(dualAxes.m_secondaryAttack, swordShared.m_secondaryAttack, swordShared.m_attack.m_attackRange);
            DualSwordVisuals.AddPairModels(prefab);

            ItemDefinition dual = new ItemDefinition {
                Name = $"Dual {EnglishName(sword)}",
                Category = ItemCategory.Swords,
                Prefab = dualPrefab,
                CraftAmount = 1,
                GeneratedPrefab = prefab,
                GeneratedIcon = DualSwordVisuals.PairIcon(swordShared),
            };
            if (sword.Definition != null) {
                FromArmorySword(dual, sword.Definition);
            } else {
                FromVanillaSword(dual, sword, shared, vanilla);
            }
            return dual;
        }

        private static string EnglishName(Sword sword)
        {
            if (sword.Definition != null) { return sword.Definition.Name; }
            return VanillaNames.TryGetValue(sword.Item.name, out string name) ? name : sword.Item.name;
        }

        // The defaults of this mod's sword, as written in its definition rather than as its config stands now.
        private static void FromArmorySword(ItemDefinition dual, ItemDefinition sword)
        {
            dual.CraftedAt = sword.CraftedAt;
            dual.ReqStationlevel = Math.Max(1, sword.ReqStationlevel);
            dual.UpgraderResource = sword.UpgraderResource;
            if (sword.FrostForged != null) {
                dual.FrostForged = new FrostForgedDefinition { Mould = sword.FrostForged.Mould, Cast = sword.FrostForged.Cast };
            }
            dual.ModifableStats = new Dictionary<ItemStat, ItemStatConfig>();
            foreach (KeyValuePair<ItemStat, ItemStatConfig> stat in sword.ModifableStats) {
                ItemStatConfig swordStat = stat.Value;
                float defaultValue = swordStat.Default_value;
                if (swordStat.Configurable && swordStat.IsInt && swordStat.CfgInt != null) { defaultValue = (int)swordStat.CfgInt.DefaultValue; }
                if (swordStat.Configurable && swordStat.IsInt == false && swordStat.Cfg != null) { defaultValue = (float)swordStat.Cfg.DefaultValue; }
                dual.ModifableStats.Add(stat.Key, new ItemStatConfig { Configurable = swordStat.Configurable, IsInt = swordStat.IsInt, Default_value = defaultValue, Min = swordStat.Min, Max = swordStat.Max });
            }
            // Frost forged weapons list their recipe without the mould, which is added on top.
            dual.Recipe = new RecipeDefinition { RecipeItems = PairRecipe(sword.Recipe.RecipeItems, null) };
        }

        // The vanilla sword's values, read from its prefab and its recipe in the game's ObjectDB.
        //
        // Vanilla's Nord sword is frost forged: its own recipe only upgrades it, and lists the mould. Its pair is made the
        // way this mod makes its other Nord weapons (see FrostForged): the pair's own mould, copied from vanilla's, turns
        // up wherever vanilla's does, makes a cast with the pair's materials, and the Frost Foundry hardens the cast.
        private static void FromVanillaSword(ItemDefinition dual, Sword sword, ItemDrop.ItemData.SharedData shared, ObjectDB vanilla)
        {
            Recipe recipe = sword.Recipe;
            dual.CraftedAt = recipe.m_craftingStation != null ? recipe.m_craftingStation.name : "forge";
            dual.ReqStationlevel = Math.Max(1, recipe.m_minStationLevel);
            dual.UpgraderResource = recipe.m_resources.FirstOrDefault(requirement => requirement.m_upgraderResource && requirement.m_resItem != null)?.m_resItem.name;
            dual.ModifableStats = StatsOf(shared);
            List<RecipeIngredient> ingredients = recipe.m_resources
                .Where(requirement => requirement.m_resItem != null && requirement.m_upgraderResource == false)
                .Select(requirement => new RecipeIngredient { Prefab = requirement.m_resItem.name, Amount = requirement.m_amount, UpgradeCost = requirement.m_amountPerLevel })
                .ToList();
            string mould = null;
            if (recipe.m_noCraftOnlyUpgrade) {
                // The mould is the one ingredient taken once and never for upgrades. Vanilla names each cast after its
                // weapon (SwordGoldUncooked).
                mould = ingredients.FirstOrDefault(ingredient => ingredient.Amount == 1 && ingredient.UpgradeCost == 0 && DualBySword.ContainsKey(ingredient.Prefab) == false)?.Prefab;
                string cast = $"{sword.Item.name}Uncooked";
                if (mould != null && vanilla.m_items.Any(item => item != null && item.name == cast)) {
                    dual.FrostForged = new FrostForgedDefinition { Mould = mould, Cast = cast };
                } else {
                    Logger.LogWarning($"Could not find the mould and cast of {sword.Item.name}, its dual version is crafted directly.");
                    mould = null;
                }
            }
            dual.Recipe = new RecipeDefinition { RecipeItems = PairRecipe(ingredients, mould) };
        }

        // The stats of this mod's swords, with the vanilla sword's values as defaults.
        private static Dictionary<ItemStat, ItemStatConfig> StatsOf(ItemDrop.ItemData.SharedData shared)
        {
            Dictionary<ItemStat, ItemStatConfig> stats = new Dictionary<ItemStat, ItemStatConfig>();
            void Add(ItemStat stat, float value, float min, float max)
            {
                stats.Add(stat, new ItemStatConfig { Default_value = value, Min = Mathf.Min(min, value), Max = Mathf.Max(max, value) });
            }
            void AddDamage(ItemStat stat, ItemStat statPerLevel, float value, float perLevel)
            {
                if (value <= 0f && perLevel <= 0f) { return; }
                Add(stat, value, 0f, 300f);
                Add(statPerLevel, perLevel, 0f, 50f);
            }
            HitData.DamageTypes damage = shared.m_damages;
            HitData.DamageTypes damagePerLevel = shared.m_damagesPerLevel;
            AddDamage(ItemStat.slash, ItemStat.slash_per_level, damage.m_slash, damagePerLevel.m_slash);
            AddDamage(ItemStat.pierce, ItemStat.pierce_per_level, damage.m_pierce, damagePerLevel.m_pierce);
            AddDamage(ItemStat.blunt, ItemStat.blunt_per_level, damage.m_blunt, damagePerLevel.m_blunt);
            AddDamage(ItemStat.fire, ItemStat.fire_per_level, damage.m_fire, damagePerLevel.m_fire);
            AddDamage(ItemStat.frost, ItemStat.frost_per_level, damage.m_frost, damagePerLevel.m_frost);
            AddDamage(ItemStat.lightning, ItemStat.lightning_per_level, damage.m_lightning, damagePerLevel.m_lightning);
            AddDamage(ItemStat.poison, ItemStat.poison_per_level, damage.m_poison, damagePerLevel.m_poison);
            AddDamage(ItemStat.spirit, ItemStat.spirit_per_level, damage.m_spirit, damagePerLevel.m_spirit);
            Add(ItemStat.attack_force, shared.m_attackForce, 0f, 200f);
            Add(ItemStat.block_armor, shared.m_blockPower, 0f, 150f);
            Add(ItemStat.block_force, shared.m_deflectionForce, 0f, 150f);
            Add(ItemStat.durability, shared.m_maxDurability, 0f, 400f);
            Add(ItemStat.durability_per_level, shared.m_durabilityPerLevel, 0f, 150f);
            Add(ItemStat.primary_attack_stamina, shared.m_attack.m_attackStamina, 1f, 50f);
            Add(ItemStat.secondary_attack_stamina, shared.m_secondaryAttack.m_attackStamina, 1f, 50f);
            Add(ItemStat.movement_speed, shared.m_movementModifier, -0.2f, 0f);
            Add(ItemStat.primary_attack_adrenaline, shared.m_attack.m_attackAdrenaline, 0f, 25f);
            Add(ItemStat.secondary_attack_adrenaline, shared.m_secondaryAttack.m_attackAdrenaline, 0f, 25f);
            Add(ItemStat.block_adrenaline, shared.m_blockAdrenaline, 0f, 25f);
            Add(ItemStat.parry_adrenaline, shared.m_perfectBlockAdrenaline, 0f, 25f);
            return stats;
        }

        // The sword's recipe as the pair's default. A sword with its own pair (the base sword of a variant) becomes that
        // pair, so the variant pair is made from the plain pair the way vanilla makes the variant from the plain sword.
        // Anything else is multiplied, unless the sword takes only one of it (moulds, orbs, Dyrnwyn's fragments). The
        // mould of a frost forged sword is left out, as its pair's own mould is added on top.
        private static List<RecipeIngredient> PairRecipe(IEnumerable<RecipeIngredient> swordRecipe, string mould)
        {
            List<RecipeIngredient> pair = new List<RecipeIngredient>();
            foreach (RecipeIngredient ingredient in swordRecipe) {
                if (ingredient.Prefab == mould) { continue; }
                if (DualBySword.TryGetValue(ingredient.Prefab, out string dualPrefab)) {
                    pair.Add(new RecipeIngredient { Prefab = dualPrefab, Amount = ingredient.Amount, UpgradeCost = ingredient.UpgradeCost });
                    continue;
                }
                pair.Add(new RecipeIngredient { Prefab = ingredient.Prefab, Amount = Multiplied(ingredient.Amount), UpgradeCost = Multiplied(ingredient.UpgradeCost) });
            }
            return pair;
        }

        private static int Multiplied(int amount)
        {
            return amount <= 1 ? amount : Mathf.CeilToInt(amount * MaterialMultiplier);
        }

        // The dual axes attack, paying what the sword's attack pays and doing what it does on a hit (eg: the Thunderblood
        // sword's red chain lightning). How it moves stays the dual axes'.
        private static Attack DualAttack(Attack dualAxes, Attack sword, float range)
        {
            Attack dual = dualAxes.Clone();
            dual.m_attackStamina = sword.m_attackStamina;
            dual.m_attackEitr = sword.m_attackEitr;
            dual.m_attackEitrAdd = sword.m_attackEitrAdd;
            dual.m_attackHealth = sword.m_attackHealth;
            dual.m_attackHealthPercentage = sword.m_attackHealthPercentage;
            dual.m_attackHealthLowBlockUse = sword.m_attackHealthLowBlockUse;
            dual.m_attackHealthReturnHit = sword.m_attackHealthReturnHit;
            dual.m_attackAdrenaline = sword.m_attackAdrenaline;
            dual.m_attackUseAdrenaline = sword.m_attackUseAdrenaline;
            dual.m_damageMultiplierPerMissingHP = sword.m_damageMultiplierPerMissingHP;
            dual.m_damageMultiplierByTotalHealthMissing = sword.m_damageMultiplierByTotalHealthMissing;
            dual.m_staminaReturnPerMissingHP = sword.m_staminaReturnPerMissingHP;
            dual.m_spawnOnHit = sword.m_spawnOnHit;
            dual.m_spawnOnHitChance = sword.m_spawnOnHitChance;
            dual.m_hitEffect = sword.m_hitEffect;
            dual.m_hitTerrainEffect = sword.m_hitTerrainEffect;
            dual.m_startEffect = sword.m_startEffect;
            dual.m_triggerEffect = sword.m_triggerEffect;
            dual.m_trailStartEffect = sword.m_trailStartEffect;
            dual.m_burstEffect = sword.m_burstEffect;
            dual.m_attackRange = range;
            return dual;
        }
    }
}
