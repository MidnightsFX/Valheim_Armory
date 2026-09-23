using Jotunn.Managers;
using System;
using System.Collections.Generic;

namespace ValheimArmory.common
{
    // Finds the ItemDrops that hold a prefab's item data, without Resources.FindObjectsOfTypeAll. That call
    // walks every GameObject the game has loaded - every prefab and each of their children - and running it
    // for each applied config change was a large part of the main thread stall behind in-game disconnects.
    //
    // The data lives in two places. The registered prefab: inventories and containers build their items from
    // it with ItemData.Clone, which keeps the same m_shared, so updating the prefab reaches all of those. And
    // each live world drop: Instantiate copies SharedData, and ItemDrop.Awake only points it back at the
    // prefab's copy in the editor, so every drop in the world carries its own. ItemDrop.s_instances is the
    // game's own list of those drops.
    //
    // Names match exactly (plus Unity's clone suffix), so "VAflametal_sledge" does not also pick up
    // "VAflametal_sledge_nature".
    internal static class LiveItemDrops
    {
        private const string CloneSuffix = "(Clone)";

        // The prefab's ItemDrop, followed by every live world drop of it.
        internal static List<ItemDrop> Find(string prefab)
        {
            List<ItemDrop> found = new List<ItemDrop>();
            ForEach(new[] { prefab }, (_, drop) => found.Add(drop));
            return found;
        }

        // Bulk form of Find: visits each named prefab, then makes a single pass over the live drops, so the
        // cost does not grow with how many prefabs are asked for. Pass a set when there are many of them.
        internal static void ForEach(ICollection<string> prefabs, Action<string, ItemDrop> visit)
        {
            foreach (string prefab in prefabs)
            {
                ItemDrop prefabDrop = PrefabManager.Instance.GetPrefab(prefab)?.GetComponent<ItemDrop>();
                if (prefabDrop != null) { visit(prefab, prefabDrop); }
            }

            foreach (ItemDrop drop in ItemDrop.s_instances)
            {
                if (drop == null) { continue; }
                string prefab = PrefabName(drop.name);
                if (prefabs.Contains(prefab)) { visit(prefab, drop); }
            }
        }

        private static string PrefabName(string name)
        {
            return name.EndsWith(CloneSuffix, StringComparison.Ordinal) ? name.Substring(0, name.Length - CloneSuffix.Length) : name;
        }
    }
}
