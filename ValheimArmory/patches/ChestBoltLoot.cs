using BepInEx.Configuration;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
using ValheimArmory.Common;

namespace ValheimArmory.patches
{
    // Puts crossbow bolts into vanilla treasure chests next to the arrows those chests already hold,
    // so bolts turn up in the world the way arrows do.
    //
    // Chest loot is rolled once, in Container.Awake -> AddDefaultItems, by whoever generates the zone -
    // the dedicated server in a multiplayer world. Chests placed by locations and dungeon rooms are copies
    // of the chest inside that location or room prefab, each carrying its own DropTable, so the bolts are
    // added to the container being filled instead of to the TreasureChest prefabs.
    public static class ChestBoltLoot
    {
        private const string Section = "Chest Loot";

        // Each chest's vanilla arrow entry mirrored with its crossbow counterpart: same stack range and weight.
        private static readonly (string chest, string bolts)[] DefaultLoot = {
            ("TreasureChest_meadows", "VABoltWood,10,20,1"),
            ("TreasureChest_meadows_01", "VABoltWood,10,20,1"),
            ("TreasureChest_meadows_02", "VABoltWood,10,20,1"),
            ("TreasureChest_meadows_combat", "VABoltWood,10,20,1"),
            ("TreasureChest_meadows_buried", "VAFireBolt,10,15,1"),
            ("TreasureChest_blackforest", "VABoltWood,5,10,1"),
            ("TreasureChest_forestcrypt", "VABoltWood,5,10,1"),
            ("TreasureChest_fCrypt", "VABoltWood,5,10,1"),
            ("TreasureChest_swamp", "BoltIron,10,15,1|VAbolt_poison,10,15,1"),
            ("TreasureChest_sunkencrypt", "BoltIron,10,15,1|VAbolt_poison,10,15,1"),
            ("TreasureChest_mountains", "VAbolt_frost,5,10,1"),
            ("TreasureChest_plains_stone", "VAObsidianBolt,5,10,1"),
            ("TreasureChest_ashland_stone", "BoltCarapace,3,12,0.5"),
            ("TreasureChest_morkhalla", "BoltCharred,5,11,1"),
        };

        public static ConfigEntry<bool> Enabled;

        // Keyed by the stable hash of the chest prefab name, which is what the chest's ZDO stores.
        private static readonly Dictionary<int, ChestLoot> Chests = new Dictionary<int, ChestLoot>();
        private static readonly HashSet<string> MissingPrefabsLogged = new HashSet<string>();

        private sealed class BoltDrop
        {
            public string Prefab;
            public int Min;
            public int Max;
            public float Weight;
        }

        private sealed class ChestLoot
        {
            public string Chest;
            public ConfigEntry<string> Config;
            private string parsedValue;
            private List<BoltDrop> parsed = new List<BoltDrop>();

            // Re-parsed only when the value changed, e.g. after a config reload on the server.
            public List<BoltDrop> Drops {
                get {
                    if (parsedValue != Config.Value) {
                        parsed = Parse(Chest, Config.Value);
                        parsedValue = Config.Value;
                    }
                    return parsed;
                }
            }
        }

        internal static void BindConfig()
        {
            Enabled = ValConfig.BindServerConfig(Section, "EnableChestBolts", true, "Adds crossbow bolts to treasure chests found in the world, next to the arrows each chest can hold. Only chests generated after this is enabled are affected; chests in areas already visited keep their loot.");
            foreach ((string chest, string bolts) in DefaultLoot) {
                ConfigEntry<string> entry = ValConfig.BindServerConfig(Section, chest, bolts, $"Bolts that can be found in {chest}. Format Prefab,StackMin,StackMax,Weight|Prefab,StackMin,StackMax,Weight eg: VABoltWood,10,20,1. Weight is relative to the chest's other items (most vanilla items use 1). Leave empty to add nothing.", true);
                Chests[chest.GetStableHashCode()] = new ChestLoot { Chest = chest, Config = entry };
            }
        }

        // A dedicated server rolls the chest loot, so it needs this mod's bolt prefabs registered even though
        // it skips item registration by default (see LoadPrefabsOnServer).
        internal static bool NeedsModPrefabs()
        {
            if (Enabled == null || Enabled.Value == false) { return false; }
            HashSet<string> modPrefabs = new HashSet<string>(JotunBatchLoader.AddedItems.Values);
            return Chests.Values.Any(chest => chest.Drops.Any(drop => modPrefabs.Contains(drop.Prefab)));
        }

        private static List<BoltDrop> Parse(string chest, string value)
        {
            List<BoltDrop> drops = new List<BoltDrop>();
            if (string.IsNullOrWhiteSpace(value)) { return drops; }
            foreach (string part in value.Split('|')) {
                string[] fields = part.Split(',');
                if (fields.Length == 4
                    && int.TryParse(fields[1].Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int min)
                    && int.TryParse(fields[2].Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int max)
                    && float.TryParse(fields[3].Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out float weight)
                    && min > 0 && max >= min && weight > 0f) {
                    drops.Add(new BoltDrop { Prefab = fields[0].Trim(), Min = min, Max = max, Weight = weight });
                } else {
                    Logger.LogWarning($"Invalid chest loot entry '{part}' for {chest}. Should be in the format Prefab,StackMin,StackMax,Weight eg: VABoltWood,10,20,1");
                }
            }
            return drops;
        }

        private static GameObject ResolvePrefab(string prefab)
        {
            GameObject item = ObjectDB.instance != null ? ObjectDB.instance.GetItemPrefab(prefab) : null;
            if (item == null && MissingPrefabsLogged.Add(prefab)) {
                Logger.LogWarning($"Chest loot item {prefab} was not found, it will not be added to chests.");
            }
            return item;
        }

        [HarmonyPatch(typeof(Container), nameof(Container.AddDefaultItems))]
        public static class AddBoltsToChestLoot
        {
            public static void Prefix(Container __instance)
            {
                if (Enabled.Value == false || __instance.m_nview == null) { return; }
                ZDO zdo = __instance.m_nview.GetZDO();
                if (zdo == null || !Chests.TryGetValue(zdo.GetPrefab(), out ChestLoot loot)) { return; }
                List<BoltDrop> bolts = loot.Drops;
                if (bolts.Count == 0) { return; }

                DropTable table = __instance.m_defaultItems;
                // Always a new list, so this container can never edit a drop list shared with the prefab it was copied from.
                List<DropTable.DropData> drops = new List<DropTable.DropData>(table.m_drops);
                foreach (BoltDrop bolt in bolts) {
                    GameObject item = ResolvePrefab(bolt.Prefab);
                    if (item == null || drops.Any(drop => drop.m_item == item)) { continue; }
                    drops.Add(new DropTable.DropData { m_item = item, m_stackMin = bolt.Min, m_stackMax = bolt.Max, m_weight = bolt.Weight, m_dontScale = false });
                }
                table.m_drops = drops;
            }
        }
    }
}
