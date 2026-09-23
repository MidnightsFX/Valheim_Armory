using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ValheimArmory.common
{
    internal class StatusModifiers
    {
        // Prefab names only; LiveItemDrops also matches their "(Clone)" world drops.
        private static List<string> bloodBuffPrefabs = new List<string>
        {
            "VABlood_bone_bow",
            "VAHeavy_Blood_Bone_Bow",
            "VABlood_Bones_pickaxe",
        };

        private static List<string> queenBuffPrefabs = new List<string>
        {
            "VAQueen_greatsword",
            "VASwordQueen",
            "VAQueen_bow",
            "VAdagger_queen",
        };

        public static void OnConfigBloodChanged(object sender, EventArgs e)
        {
            SE_Stats bloodbuff = null;
            foreach (SE_Stats buff in Resources.FindObjectsOfTypeAll<SE_Stats>().Where(se => se.name == "VABloodBuff").ToList()) {
                buff.m_healthRegenMultiplier = ValConfig.BloodHungerRegen.Value;
                bloodbuff = buff;
            }
            LiveItemDrops.ForEach(bloodBuffPrefabs, (_, id) => { id.m_itemData.m_shared.m_equipStatusEffect = bloodbuff; });
            if (Player.m_localPlayer == null) { return; }
            foreach (ItemDrop.ItemData user_item in Player.m_localPlayer.m_inventory.GetAllItems())
            {
                if (user_item == null || user_item.m_dropPrefab == null) { continue; }
                if (!bloodBuffPrefabs.Contains(user_item.m_dropPrefab.name)) { continue; }
                user_item.m_shared.m_equipStatusEffect = bloodbuff;
            }
        }

        public static void OnConfigQueenHealthRegenChanged(object sender, EventArgs e)
        {
            SE_Stats queenbuff = null;
            foreach (SE_Stats buff in Resources.FindObjectsOfTypeAll<SE_Stats>().Where(se => se.name == "VAQueen_buff").ToList())
            {
                buff.m_healthRegenMultiplier = ValConfig.QueenHealthRegen.Value;
                buff.m_eitrRegenMultiplier = ValConfig.QueenEitrRegen.Value;
                queenbuff = buff;
            }
            LiveItemDrops.ForEach(queenBuffPrefabs, (_, id) => { id.m_itemData.m_shared.m_equipStatusEffect = queenbuff; });
            if (Player.m_localPlayer == null) { return; }
            foreach (ItemDrop.ItemData user_item in Player.m_localPlayer.m_inventory.GetAllItems())
            {
                if (user_item == null || user_item.m_dropPrefab == null) { continue; }
                if (!queenBuffPrefabs.Contains(user_item.m_dropPrefab.name)) { continue; }
                user_item.m_shared.m_equipStatusEffect = queenbuff;
            }
        }

        public static void SyncStatusEffectsToConfig() {
            OnConfigBloodChanged(null, null);
            OnConfigQueenHealthRegenChanged(null, null);
        }
    }
}
