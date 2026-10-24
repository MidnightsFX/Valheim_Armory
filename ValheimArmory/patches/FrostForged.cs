using BepInEx.Configuration;
using HarmonyLib;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ValheimArmory.Common;

namespace ValheimArmory.patches
{
    // Weapons made the way vanilla makes its Deep North gold weapons (ItemDefinition.FrostForged). Each one gets two
    // generated items, both copies of a vanilla original: a mould, found in loot, and a cast. The mould and the
    // weapon's recipe materials make the cast at the weapon's crafting station, the Frost Foundry hardens the cast
    // into the weapon, and the weapon's own recipe is then only used to upgrade it (see
    // JotunBatchLoader.SyncFrostForgedRecipes).
    //
    // A weapon's mould turns up wherever the vanilla mould it was copied from does, so there is no list of loot
    // tables to keep in step with the game or with other mods. Vanilla weapon moulds are only found in chests and in
    // the loot of things that are destroyed (trash piles, weapon stands, spawner holes), so both are covered here. Like
    // chest bolts, the loot is added to the container or object being filled, since location and dungeon copies each
    // carry their own DropTable.
    public static class FrostForged
    {
        private const string Section = "Mould Loot";
        private const string FrostFoundry = "piece_FrostFoundry";
        // Every vanilla cast takes this long in the Frost Foundry.
        private const float CastHardenTime = 50f;

        public static ConfigEntry<bool> Enabled;
        public static ConfigEntry<float> MouldWeight;

        // Weapon definition -> the weapon's own item, read for its name when its mould and cast are made.
        private static readonly Dictionary<ItemDefinition, ItemDrop> Weapons = new Dictionary<ItemDefinition, ItemDrop>();
        // Vanilla mould prefab -> the weapons whose moulds are copied from it.
        private static readonly Dictionary<string, List<ItemDefinition>> WeaponsByVanillaMould = new Dictionary<string, List<ItemDefinition>>();
        private static readonly HashSet<string> MissingMouldsLogged = new HashSet<string>();
        // Set once the vanilla moulds and casts could be copied. A weapon registered after that (the dual Nord sword, made
        // from vanilla's sword in the same event) gets its copies right away.
        private static bool copiesCreated = false;

        internal static void BindConfig()
        {
            Enabled = ValConfig.BindServerConfig(Section, "EnableMouldLoot", true, "Adds the moulds of Valheim Armory's frost forged weapons to loot, wherever the vanilla mould each one is copied from can be found (chests, trash piles, weapon stands and the like). Only loot generated after this is enabled is affected. Moulds of weapons whose crafting is disabled are left out.");
            MouldWeight = ValConfig.BindServerConfig(Section, "MouldWeight", 1f, "How often a Valheim Armory mould turns up compared to the vanilla mould it is found with. 1 makes it as common as that mould, 0 adds none.", true, 0f, 5f);
        }

        // Called for each frost forged weapon as items are added.
        internal static void Register(ItemDefinition itemdef, ItemDrop weapon)
        {
            FrostForgedDefinition frostForged = itemdef.FrostForged;
            frostForged.MouldPrefab = $"{itemdef.Prefab}_mold";
            frostForged.CastPrefab = $"{itemdef.Prefab}_cast";
            Weapons[itemdef] = weapon;
            if (WeaponsByVanillaMould.TryGetValue(frostForged.Mould, out List<ItemDefinition> weapons) == false) {
                weapons = new List<ItemDefinition>();
                WeaponsByVanillaMould.Add(frostForged.Mould, weapons);
            }
            weapons.Add(itemdef);
            ItemManager.Instance.AddItemConversion(new CustomItemConversion(new CookingConversionConfig {
                Station = FrostFoundry,
                FromItem = frostForged.CastPrefab,
                ToItem = itemdef.Prefab,
                CookTime = CastHardenTime
            }));
            if (copiesCreated) {
                AddMouldAndCast(itemdef, weapon);
            }
        }

        // Vanilla moulds and casts can only be copied once the game's prefabs are loaded. Runs once: Jotunn adds the
        // copies to every ObjectDB from then on.
        internal static void CreateMouldsAndCasts()
        {
            PrefabManager.OnVanillaPrefabsAvailable -= CreateMouldsAndCasts;
            copiesCreated = true;
            foreach (KeyValuePair<ItemDefinition, ItemDrop> weapon in Weapons) {
                AddMouldAndCast(weapon.Key, weapon.Value);
            }
        }

        private static void AddMouldAndCast(ItemDefinition itemdef, ItemDrop weapon)
        {
            FrostForgedDefinition frostForged = itemdef.FrostForged;
            string weaponName = weapon.m_itemData.m_shared.m_name;
            // Named like the vanilla ones ("Mould: Nord Dagger"), so they follow the weapon's own translation.
            // A name starting with $item_mold also gives the mould the vanilla mould tutorial.
            AddCopy(frostForged.MouldPrefab, frostForged.Mould, $"$item_mold_va {weaponName}");
            AddCopy(frostForged.CastPrefab, frostForged.Cast, $"$item_cast_va {weaponName}");
        }

        // Keeps the vanilla item's look, icon and description, and only renames it.
        private static void AddCopy(string prefab, string vanillaPrefab, string name)
        {
            CustomItem item = new CustomItem(prefab, vanillaPrefab);
            if (item.ItemDrop == null) {
                Logger.LogWarning($"Vanilla item {vanillaPrefab} was not found, {prefab} will not be added and its weapon stays craftable without it.");
                return;
            }
            item.ItemDrop.m_itemData.m_shared.m_name = name;
            ItemManager.Instance.AddItem(item);
        }

        // The mould that joins this loot, or null when the weapon's crafting is disabled (an admin who disabled a
        // recipe wants it out of the world), its mould is missing, or the loot already holds it.
        private static ItemDrop MouldFor(ItemDefinition itemdef, List<DropTable.DropData> loot)
        {
            if (JotunBatchLoader.IsCraftingDisabled(itemdef.Prefab)) { return null; }
            string prefab = itemdef.FrostForged.MouldPrefab;
            GameObject go = ObjectDB.instance != null ? ObjectDB.instance.GetItemPrefab(prefab) : null;
            ItemDrop mould = go != null ? go.GetComponent<ItemDrop>() : null;
            if (mould == null) {
                if (MissingMouldsLogged.Add(prefab)) { Logger.LogWarning($"Mould {prefab} was not found, it will not be added to loot."); }
                return null;
            }
            if (loot.Any(entry => entry.m_item == mould.gameObject)) { return null; }
            return mould;
        }

        // The table's loot with our moulds added next to each vanilla mould they are copied from, or null when it
        // holds none. Always a new list, so a container or object never edits a drop list shared with the prefab
        // it was copied from.
        private static List<DropTable.DropData> WithMoulds(DropTable table)
        {
            if (WeaponsByVanillaMould.Count == 0 || Enabled.Value == false || MouldWeight.Value <= 0f) { return null; }
            if (table == null || table.m_drops.Count == 0) { return null; }
            List<DropTable.DropData> drops = null;
            foreach (DropTable.DropData drop in table.m_drops) {
                if (drop.m_item == null || drop.m_weight <= 0f || WeaponsByVanillaMould.TryGetValue(drop.m_item.name, out List<ItemDefinition> weapons) == false) { continue; }
                foreach (ItemDefinition itemdef in weapons) {
                    ItemDrop mould = MouldFor(itemdef, table.m_drops);
                    if (mould == null) { continue; }
                    if (drops == null) { drops = new List<DropTable.DropData>(table.m_drops); }
                    // Added on top of the vanilla mould rather than sharing its weight: it is another mould in the pool,
                    // the way each vanilla mould is.
                    drops.Add(new DropTable.DropData {
                        m_item = mould.gameObject,
                        m_stackMin = drop.m_stackMin,
                        m_stackMax = drop.m_stackMax,
                        m_weight = drop.m_weight * MouldWeight.Value,
                        m_dontScale = drop.m_dontScale
                    });
                }
            }
            return drops;
        }

        // Chest loot is rolled once, by whoever generates the zone - the dedicated server in a multiplayer world.
        [HarmonyPatch(typeof(Container), nameof(Container.AddDefaultItems))]
        public static class AddMouldsToChestLoot
        {
            public static void Prefix(Container __instance)
            {
                List<DropTable.DropData> drops = WithMoulds(__instance.m_defaultItems);
                if (drops != null) { __instance.m_defaultItems.m_drops = drops; }
            }
        }

        // Rolled by the object's owner as it is destroyed.
        [HarmonyPatch(typeof(DropOnDestroyed), nameof(DropOnDestroyed.OnDestroyed))]
        public static class AddMouldsToDestroyedLoot
        {
            public static void Prefix(DropOnDestroyed __instance)
            {
                List<DropTable.DropData> drops = WithMoulds(__instance.m_dropWhenDestroyed);
                if (drops != null) { __instance.m_dropWhenDestroyed.m_drops = drops; }
            }
        }
    }
}
