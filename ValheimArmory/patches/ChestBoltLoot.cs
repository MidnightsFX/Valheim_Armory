using BepInEx.Configuration;
using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ValheimArmory.Common;

namespace ValheimArmory.patches
{
    // Puts crossbow bolts into treasure chests next to the arrows those chests already hold, so bolts turn
    // up in the world the way arrows do. Any container whose loot includes a listed arrow gets that arrow's
    // bolt, so there is no list of chests to keep in step with the game or with other mods.
    //
    // Chest loot is rolled once, in Container.Awake -> AddDefaultItems, by whoever generates the zone -
    // the dedicated server in a multiplayer world. Chests placed by locations and dungeon rooms are copies
    // of the chest inside that location or room prefab, each carrying its own DropTable, so the bolts are
    // added to the container being filled instead of to the TreasureChest prefabs.
    public static class ChestBoltLoot
    {
        private const string Section = "Chest Loot";

        // Every arrow vanilla chests hold, plus a few more, paired with the bolt of the same tier.
        private const string DefaultArrowBolts = "ArrowWood,VABoltWood|ArrowFlint,VABoltWood|ArrowFire,VAFireBolt|ArrowBronze,VAbolt_bronze|ArrowIron,BoltIron|ArrowPoison,VAbolt_poison|ArrowFrost,VAbolt_frost|ArrowObsidian,VAObsidianBolt|ArrowNeedle,VABoltNeedle|ArrowCarapace,BoltCarapace|ArrowCharred,BoltCharred";

        public static ConfigEntry<bool> Enabled;
        public static ConfigEntry<float> BoltShare;
        public static ConfigEntry<string> ArrowBolts;

        private static readonly HashSet<string> MissingPrefabsLogged = new HashSet<string>();
        private static string parsedArrowBolts;
        private static Dictionary<string, string> boltForArrow = new Dictionary<string, string>();

        internal static void BindConfig()
        {
            Enabled = ValConfig.BindServerConfig(Section, "EnableChestBolts", true, "Adds crossbow bolts to treasure chests whose loot includes arrows, next to those arrows. Only chests generated after this is enabled are affected; chests in areas already visited keep their loot.");
            BoltShare = ValConfig.BindServerConfig(Section, "BoltShare", 0.5f, "Share of each arrow's loot weight that goes to its bolt. The arrow keeps the rest, so a chest turns up ammo about as often as before and its other items keep their vanilla odds. 0.5 splits evenly, 1 replaces the arrows with bolts, 0 adds no bolts.", true, 0f, 1f);
            ArrowBolts = ValConfig.BindServerConfig(Section, "ArrowBolts", DefaultArrowBolts, "The bolt that joins each arrow found in a chest's loot. Format Arrow,Bolt|Arrow,Bolt eg: ArrowFlint,VABoltWood|ArrowIron,BoltIron. The bolt uses the arrow's stack range, capped at the bolt's max stack size. Arrows not listed get no bolt, and bolts whose crafting is disabled are left out.", true);
        }

        // Parsed again only when the value changed, e.g. after a config reload on the server.
        private static Dictionary<string, string> BoltForArrow()
        {
            string value = ArrowBolts.Value;
            if (value == parsedArrowBolts) { return boltForArrow; }
            Dictionary<string, string> pairs = new Dictionary<string, string>();
            foreach (string part in (value ?? "").Split('|')) {
                // Tolerates an empty value and a trailing or doubled separator.
                if (string.IsNullOrWhiteSpace(part)) { continue; }
                string[] fields = part.Split(',');
                if (fields.Length == 2 && fields[0].Trim().Length > 0 && fields[1].Trim().Length > 0) {
                    pairs[fields[0].Trim()] = fields[1].Trim();
                } else {
                    Logger.LogWarning($"Invalid ArrowBolts entry '{part}'. Should be in the format Arrow,Bolt eg: ArrowFlint,VABoltWood");
                }
            }
            boltForArrow = pairs;
            parsedArrowBolts = value;
            return pairs;
        }

        private static ItemDrop ResolveItem(string prefab)
        {
            GameObject go = ObjectDB.instance != null ? ObjectDB.instance.GetItemPrefab(prefab) : null;
            ItemDrop item = go != null ? go.GetComponent<ItemDrop>() : null;
            if (item == null && MissingPrefabsLogged.Add(prefab)) {
                Logger.LogWarning($"Chest loot item {prefab} was not found, it will not be added to chests.");
            }
            return item;
        }

        // The bolt that joins this loot entry, or null when the item is not a listed arrow, the bolt is missing
        // or its crafting is disabled, or the chest already holds that bolt (some newer vanilla chests do).
        private static ItemDrop BoltFor(DropTable.DropData drop, Dictionary<string, string> pairs, List<DropTable.DropData> loot)
        {
            if (drop.m_item == null || drop.m_weight <= 0f || !pairs.TryGetValue(drop.m_item.name, out string prefab)) { return null; }
            // An admin who disabled a bolt's recipe wants it out of the world, chests included.
            if (JotunBatchLoader.IsCraftingDisabled(prefab)) { return null; }
            ItemDrop bolt = ResolveItem(prefab);
            if (bolt == null || loot.Any(entry => entry.m_item == bolt.gameObject)) { return null; }
            return bolt;
        }

        [HarmonyPatch(typeof(Container), nameof(Container.AddDefaultItems))]
        public static class AddBoltsToChestLoot
        {
            public static void Prefix(Container __instance)
            {
                if (Enabled.Value == false || BoltShare.Value <= 0f) { return; }
                DropTable table = __instance.m_defaultItems;
                if (table == null || table.m_drops.Count == 0) { return; }
                Dictionary<string, string> pairs = BoltForArrow();
                if (pairs.Count == 0) { return; }

                // The bolt takes its share out of the arrow's weight instead of adding to the table's total, so
                // the chest's other items keep their vanilla odds.
                float share = Mathf.Min(BoltShare.Value, 1f);
                // Always a new list, so this container can never edit a drop list shared with the prefab it was copied from.
                List<DropTable.DropData> drops = new List<DropTable.DropData>(table.m_drops.Count + 2);
                bool added = false;
                foreach (DropTable.DropData drop in table.m_drops) {
                    ItemDrop bolt = BoltFor(drop, pairs, table.m_drops);
                    if (bolt == null) {
                        drops.Add(drop);
                        continue;
                    }
                    // At a share of 1 the arrow is dropped rather than kept at weight 0, which DropTable can still roll.
                    if (share < 1f) {
                        DropTable.DropData arrow = drop;
                        arrow.m_weight *= 1f - share;
                        drops.Add(arrow);
                    }
                    // DropTable only caps the top of the range at the max stack, so a min above it would still roll an oversized stack.
                    int maxStack = Mathf.Max(1, bolt.m_itemData.m_shared.m_maxStackSize);
                    drops.Add(new DropTable.DropData {
                        m_item = bolt.gameObject,
                        m_stackMin = Mathf.Min(drop.m_stackMin, maxStack),
                        m_stackMax = Mathf.Min(drop.m_stackMax, maxStack),
                        m_weight = drop.m_weight * share,
                        m_dontScale = drop.m_dontScale
                    });
                    added = true;
                }
                if (added) { table.m_drops = drops; }
            }
        }
    }
}
