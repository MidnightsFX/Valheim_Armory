using BepInEx.Configuration;
using Jotunn.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ValheimArmory.Common;

namespace ValheimArmory.patches
{
    // A dual wielded copy of every one handed sword and mace, vanilla and this mod's, held and swung with the vanilla dual
    // axes animations. Each copy keeps its weapon's look and on-hit effects and only changes how it is held and swung.
    //
    // Nothing is rigged. This mod's dual axes and knives put skinned blades in attach_skin, but every vertex there is
    // weighted to a single hand bone, and each blade sits exactly where a one handed weapon's attach sits at
    // RightHand_Attach / LeftHand_Attach. So the copy keeps the weapon's own attach, which the game shows in the right hand
    // as usual, and DualWeaponVisuals shows that same attach in the left hand.
    //
    // The weapons are found rather than listed: vanilla's are the one handed weapons with an enabled recipe in the game's
    // own ObjectDB (the dev only ones have none), and this mod's come from its item definitions. Each copy then becomes an
    // item definition of its own, added through JotunBatchLoader like the asset bundle's items, so it gets its own
    // config: stats and recipe start out as the weapon's and can be balanced apart from it. A copy is always registered,
    // whatever the config says, so saves holding one stay valid; the config only decides who can craft it.
    public static class DualWeapons
    {
        // Vanilla's dual axes. Their two attacks give the copies their motion: the four swing dualaxes chain and the
        // dualaxes_secondary spin.
        private const string DualAxes = "AxeBerzerkr";
        private const string PrefabPrefix = "VADual_";
        // The pair's default recipe takes this many times the weapon's materials, both to craft and for each upgrade.
        private const float MaterialMultiplier = 1.5f;

        // A kind of one handed weapon that gets dual copies, told apart by the skill it trains.
        private class WeaponKind
        {
            public Skills.SkillType Skill;
            // The copies' config sections are named after this.
            public ItemCategory Category;
            // English names of vanilla's weapons of this kind. The copies' config sections are named after them, and must
            // not change with the game's language. A weapon missing here (eg: one a later game update adds) is named after
            // its prefab.
            public Dictionary<string, string> VanillaNames;
            // How the pair crosses on the ground and on the back: the angle between the two, and how far along them they
            // meet, as a fraction of their length.
            public float CrossAngle;
            public float CrossAt;
            public ConfigEntry<bool> Enabled;
        }

        private static readonly WeaponKind Swords = new WeaponKind {
            Skill = Skills.SkillType.Swords,
            Category = ItemCategory.Swords,
            CrossAngle = 35f,
            CrossAt = 0.45f,
            VanillaNames = new Dictionary<string, string> {
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
            },
        };

        private static readonly WeaponKind Maces = new WeaponKind {
            Skill = Skills.SkillType.Clubs,
            Category = ItemCategory.Maces,
            // A mace's head is far wider than a blade, so the pair crosses wider and nearer the grips to keep the heads apart.
            CrossAngle = 50f,
            CrossAt = 0.2f,
            VanillaNames = new Dictionary<string, string> {
                { "Club", "Club" },
                { "MaceBronze", "Bronze Mace" },
                { "MaceIron", "Iron Mace" },
                { "MaceSilver", "Frostner" },
                { "MaceNeedle", "Porcupine" },
                { "MaceEldner", "Flametal Mace" },
                { "MaceEldnerBlood", "Bloodgeon" },
                { "MaceEldnerLightning", "Storm Star" },
                { "MaceEldnerNature", "Klossen" },
                { "MaceGold", "Nord Mace" },
                { "MaceGold_FrostFire", "Frostfire Mace" },
                { "MaceGold_BloodLightning", "Thunderblood Mace" },
            },
        };

        private static readonly WeaponKind[] Kinds = { Swords, Maces };

        // Weapon prefab -> its dual copy's prefab.
        private static readonly Dictionary<string, string> DualByWeapon = new Dictionary<string, string>();
        private static readonly Dictionary<string, WeaponKind> KindByDualPrefab = new Dictionary<string, WeaponKind>();
        // Hashes of the dual copy prefabs, as VisEquipment and the ZDO carry them.
        internal static readonly HashSet<int> DualHashes = new HashSet<int>();

        // A weapon to copy: this mod's carry their item definition, vanilla's the recipe from the game's ObjectDB.
        private class Weapon
        {
            public ItemDrop Item;
            public WeaponKind Kind;
            public ItemDefinition Definition;
            public Recipe Recipe;
        }

        internal static void BindConfig()
        {
            Swords.Enabled = ValConfig.BindServerConfig("Dual Swords", "EnableDualSwords", true, "Lets every one handed sword, vanilla and Valheim Armory, be crafted as a dual wielded pair that swings like dual axes. Each pair has its own settings, under Swords - Dual <sword>. Disabling only removes the recipes: dual swords already made keep working.");
            Maces.Enabled = ValConfig.BindServerConfig("Dual Maces", "EnableDualMaces", true, "Lets every one handed mace, vanilla and Valheim Armory, be crafted as a dual wielded pair that swings like dual axes. Each pair has its own settings, under Maces - Dual <mace>. Disabling only removes the recipes: dual maces already made keep working.");
            foreach (WeaponKind kind in Kinds) {
                ValConfig.OnChangeDebounced(kind.Enabled, OnEnabledChanged);
            }
        }

        private static void OnEnabledChanged(object sender, EventArgs e)
        {
            JotunBatchLoader.ReapplyAllRecipeConfig();
        }

        // False for a dual weapon while all of its kind are switched off. Its own craftable config applies on top.
        internal static bool CraftingAllowed(string prefab)
        {
            return KindByDualPrefab.TryGetValue(prefab, out WeaponKind kind) == false || kind.Enabled.Value;
        }

        // Vanilla weapons can only be copied once the game's prefabs are loaded. Runs once: Jotunn adds the copies to
        // every ObjectDB from then on.
        internal static void CreateDualWeapons()
        {
            PrefabManager.OnVanillaPrefabsAvailable -= CreateDualWeapons;
            GameObject dualAxes = PrefabManager.Instance.GetPrefab(DualAxes);
            if (dualAxes == null) {
                Logger.LogWarning($"Vanilla {DualAxes} was not found, no dual weapons will be added.");
                return;
            }
            ItemDrop.ItemData.SharedData dualAxesShared = dualAxes.GetComponent<ItemDrop>().m_itemData.m_shared;
            ObjectDB vanilla = FejdStartup.instance != null && FejdStartup.instance.m_objectDBPrefab != null ? FejdStartup.instance.m_objectDBPrefab.GetComponent<ObjectDB>() : null;
            List<Weapon> weapons = VanillaWeapons(vanilla).Concat(ArmoryWeapons()).ToList();
            // Every pair is named before any recipe is built, so a variant's recipe can ask for its base weapon's pair.
            foreach (Weapon weapon in weapons) {
                DualByWeapon[weapon.Item.name] = PrefabPrefix + weapon.Item.name;
            }
            List<ItemDefinition> definitions = new List<ItemDefinition>();
            foreach (Weapon weapon in weapons) {
                ItemDefinition dual = CreateDualWeapon(weapon, dualAxesShared, vanilla);
                if (dual == null) { continue; }
                definitions.Add(dual);
                KindByDualPrefab.Add(dual.Prefab, weapon.Kind);
                DualHashes.Add(dual.Prefab.GetStableHashCode());
            }
            JotunBatchLoader.AddGeneratedDefinitions(definitions);
            Logger.LogInfo($"Added {definitions.Count} dual weapons.");
        }

        // The one handed weapons that the game's own ObjectDB has an enabled recipe for. Read from the ObjectDB prefab, as
        // OnVanillaPrefabsAvailable runs just before the menu's ObjectDB is filled from it.
        private static IEnumerable<Weapon> VanillaWeapons(ObjectDB vanilla)
        {
            if (vanilla == null) {
                Logger.LogWarning("The game's ObjectDB was not found, vanilla weapons get no dual version.");
                return Enumerable.Empty<Weapon>();
            }
            return vanilla.m_recipes
                .Where(recipe => recipe != null && recipe.m_enabled && KindOf(recipe.m_item) != null)
                .GroupBy(recipe => recipe.m_item.name)
                .Select(recipes => new Weapon { Item = recipes.First().m_item, Kind = KindOf(recipes.First().m_item), Recipe = recipes.First() });
        }

        // Found by how they are swung rather than by their category, as the Blackmarble mace is listed with the hammers.
        private static IEnumerable<Weapon> ArmoryWeapons()
        {
            foreach (ItemDefinition itemdef in JotunBatchLoader.resourceDefinitions.Where(def => def.GeneratedPrefab == null).ToList()) {
                ItemDrop item = PrefabManager.Instance.GetPrefab(itemdef.Prefab)?.GetComponent<ItemDrop>();
                WeaponKind kind = KindOf(item);
                if (kind != null) {
                    yield return new Weapon { Item = item, Kind = kind, Definition = itemdef };
                }
            }
        }

        // The kind of dual copy this item gets, or null when it gets none. The tankards and torches are on these skills too,
        // but are held differently, so only what is swung like a one handed weapon counts.
        private static WeaponKind KindOf(ItemDrop item)
        {
            if (item == null) { return null; }
            ItemDrop.ItemData.SharedData shared = item.m_itemData.m_shared;
            if (shared.m_itemType != ItemDrop.ItemData.ItemType.OneHandedWeapon || shared.m_animationState != ItemDrop.ItemData.AnimationState.OneHanded) { return null; }
            return Kinds.FirstOrDefault(kind => kind.Skill == shared.m_skillType);
        }

        // Copies the weapon and changes how the copy is held and swung, then describes it as an item definition whose
        // defaults are the weapon's: its stats, and its recipe with MaterialMultiplier times the materials.
        private static ItemDefinition CreateDualWeapon(Weapon weapon, ItemDrop.ItemData.SharedData dualAxes, ObjectDB vanilla)
        {
            string dualPrefab = DualByWeapon[weapon.Item.name];
            GameObject prefab = PrefabManager.Instance.CreateClonedPrefab(dualPrefab, weapon.Item.gameObject);
            if (prefab == null) {
                Logger.LogWarning($"Could not copy {weapon.Item.name}, it gets no dual version.");
                return null;
            }
            ItemDrop.ItemData.SharedData shared = prefab.GetComponent<ItemDrop>().m_itemData.m_shared;
            ItemDrop.ItemData.SharedData weaponShared = weapon.Item.m_itemData.m_shared;
            // Different from the weapon's name, which also keeps a crafting recipe from taking a dual weapon in place of a
            // single one: inventories match requirements by name.
            shared.m_name = $"$item_dual_va {weaponShared.m_name}";
            shared.m_description = $"{weaponShared.m_description}\n\n$item_dual_va_description";
            // Two handed empties the left hand for the second weapon, and leaves the right hand item to pick the
            // animation state. Sheathed, the pair hangs where a one handed weapon does.
            shared.m_itemType = ItemDrop.ItemData.ItemType.TwoHandedWeapon;
            shared.m_animationState = ItemDrop.ItemData.AnimationState.DualAxes;
            shared.m_attachOverride = ItemDrop.ItemData.ItemType.OneHandedWeapon;
            // Both reach as far as the weapon's swing, as a sword or mace is longer than an axe. The weapon's own secondary
            // is a thrust or a slam, with a longer reach than the spin.
            shared.m_attack = DualAttack(dualAxes.m_attack, weaponShared.m_attack, weaponShared.m_attack.m_attackRange);
            shared.m_secondaryAttack = DualAttack(dualAxes.m_secondaryAttack, weaponShared.m_secondaryAttack, weaponShared.m_attack.m_attackRange);
            DualWeaponVisuals.AddPairModels(prefab, weapon.Kind.CrossAngle, weapon.Kind.CrossAt);

            ItemDefinition dual = new ItemDefinition {
                Name = $"Dual {EnglishName(weapon)}",
                Category = weapon.Kind.Category,
                Prefab = dualPrefab,
                CraftAmount = 1,
                GeneratedPrefab = prefab,
                GeneratedIcon = DualWeaponVisuals.PairIcon(weaponShared),
            };
            if (weapon.Definition != null) {
                FromArmoryWeapon(dual, weapon.Definition);
            } else {
                FromVanillaWeapon(dual, weapon, shared, vanilla);
            }
            return dual;
        }

        private static string EnglishName(Weapon weapon)
        {
            if (weapon.Definition != null) { return weapon.Definition.Name; }
            return weapon.Kind.VanillaNames.TryGetValue(weapon.Item.name, out string name) ? name : weapon.Item.name;
        }

        // The defaults of this mod's weapon, as written in its definition rather than as its config stands now.
        private static void FromArmoryWeapon(ItemDefinition dual, ItemDefinition weapon)
        {
            dual.CraftedAt = weapon.CraftedAt;
            dual.ReqStationlevel = Math.Max(1, weapon.ReqStationlevel);
            dual.UpgraderResource = weapon.UpgraderResource;
            if (weapon.FrostForged != null) {
                dual.FrostForged = new FrostForgedDefinition { Mould = weapon.FrostForged.Mould, Cast = weapon.FrostForged.Cast };
            }
            dual.ModifableStats = new Dictionary<ItemStat, ItemStatConfig>();
            foreach (KeyValuePair<ItemStat, ItemStatConfig> stat in weapon.ModifableStats) {
                ItemStatConfig weaponStat = stat.Value;
                float defaultValue = weaponStat.Default_value;
                if (weaponStat.Configurable && weaponStat.IsInt && weaponStat.CfgInt != null) { defaultValue = (int)weaponStat.CfgInt.DefaultValue; }
                if (weaponStat.Configurable && weaponStat.IsInt == false && weaponStat.Cfg != null) { defaultValue = (float)weaponStat.Cfg.DefaultValue; }
                dual.ModifableStats.Add(stat.Key, new ItemStatConfig { Configurable = weaponStat.Configurable, IsInt = weaponStat.IsInt, Default_value = defaultValue, Min = weaponStat.Min, Max = weaponStat.Max });
            }
            // Frost forged weapons list their recipe without the mould, which is added on top.
            dual.Recipe = new RecipeDefinition { RecipeItems = PairRecipe(weapon.Recipe.RecipeItems, null) };
        }

        // The vanilla weapon's values, read from its prefab and its recipe in the game's ObjectDB.
        //
        // Vanilla's Nord weapons are frost forged: their own recipes only upgrade them, and list the mould. Their pairs are
        // made the way this mod makes its other Nord weapons (see FrostForged): the pair's own mould, copied from vanilla's,
        // turns up wherever vanilla's does, makes a cast with the pair's materials, and the Frost Foundry hardens the cast.
        private static void FromVanillaWeapon(ItemDefinition dual, Weapon weapon, ItemDrop.ItemData.SharedData shared, ObjectDB vanilla)
        {
            Recipe recipe = weapon.Recipe;
            // Vanilla's club is crafted by hand and only names a station to repair and upgrade it at. Its pair is made there.
            CraftingStation station = recipe.m_craftingStation != null ? recipe.m_craftingStation : recipe.m_repairStation;
            dual.CraftedAt = station != null ? station.name : "forge";
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
                mould = ingredients.FirstOrDefault(ingredient => ingredient.Amount == 1 && ingredient.UpgradeCost == 0 && DualByWeapon.ContainsKey(ingredient.Prefab) == false)?.Prefab;
                string cast = $"{weapon.Item.name}Uncooked";
                if (mould != null && vanilla.m_items.Any(item => item != null && item.name == cast)) {
                    dual.FrostForged = new FrostForgedDefinition { Mould = mould, Cast = cast };
                } else {
                    Logger.LogWarning($"Could not find the mould and cast of {weapon.Item.name}, its dual version is crafted directly.");
                    mould = null;
                }
            }
            dual.Recipe = new RecipeDefinition { RecipeItems = PairRecipe(ingredients, mould) };
        }

        // The stats of this mod's weapons, with the vanilla weapon's values as defaults.
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

        // The weapon's recipe as the pair's default. A weapon with its own pair (the base weapon of a variant) becomes that
        // pair, so the variant pair is made from the plain pair the way vanilla makes the variant from the plain weapon.
        // Anything else is multiplied, unless the weapon takes only one of it (moulds, orbs, Dyrnwyn's fragments). The
        // mould of a frost forged weapon is left out, as its pair's own mould is added on top.
        private static List<RecipeIngredient> PairRecipe(IEnumerable<RecipeIngredient> weaponRecipe, string mould)
        {
            List<RecipeIngredient> pair = new List<RecipeIngredient>();
            foreach (RecipeIngredient ingredient in weaponRecipe) {
                if (ingredient.Prefab == mould) { continue; }
                if (DualByWeapon.TryGetValue(ingredient.Prefab, out string dualPrefab)) {
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

        // The dual axes attack, paying what the weapon's attack pays and doing what it does on a hit (eg: the Thunderblood
        // sword's red chain lightning, a mace's heavier stagger). How it moves stays the dual axes'.
        private static Attack DualAttack(Attack dualAxes, Attack weapon, float range)
        {
            Attack dual = dualAxes.Clone();
            dual.m_attackStamina = weapon.m_attackStamina;
            dual.m_attackEitr = weapon.m_attackEitr;
            dual.m_attackEitrAdd = weapon.m_attackEitrAdd;
            dual.m_attackHealth = weapon.m_attackHealth;
            dual.m_attackHealthPercentage = weapon.m_attackHealthPercentage;
            dual.m_attackHealthLowBlockUse = weapon.m_attackHealthLowBlockUse;
            dual.m_attackHealthReturnHit = weapon.m_attackHealthReturnHit;
            dual.m_attackAdrenaline = weapon.m_attackAdrenaline;
            dual.m_attackUseAdrenaline = weapon.m_attackUseAdrenaline;
            dual.m_damageMultiplierPerMissingHP = weapon.m_damageMultiplierPerMissingHP;
            dual.m_damageMultiplierByTotalHealthMissing = weapon.m_damageMultiplierByTotalHealthMissing;
            dual.m_staminaReturnPerMissingHP = weapon.m_staminaReturnPerMissingHP;
            dual.m_staggerMultiplier = weapon.m_staggerMultiplier;
            dual.m_spawnOnHit = weapon.m_spawnOnHit;
            dual.m_spawnOnHitChance = weapon.m_spawnOnHitChance;
            dual.m_hitEffect = weapon.m_hitEffect;
            dual.m_hitTerrainEffect = weapon.m_hitTerrainEffect;
            dual.m_startEffect = weapon.m_startEffect;
            dual.m_triggerEffect = weapon.m_triggerEffect;
            dual.m_trailStartEffect = weapon.m_trailStartEffect;
            dual.m_burstEffect = weapon.m_burstEffect;
            dual.m_attackRange = range;
            // The dual axes restart their chain on a tree hit, which is for chopping. Set rather than taken from the
            // weapon, as three of vanilla's Nidhogg swords have it too.
            dual.m_resetChainIfHit = DestructibleType.None;
            return dual;
        }
    }
}
