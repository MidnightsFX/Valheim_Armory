using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ValheimArmory.common
{
    internal class StatusModifiers
    {
        private static List<string> bloodBuffPrefabs = new List<string>
        {
            "VABlood_bone_bow",
            "VABlood_bone_bow(Clone)",
            "VAHeavy_Blood_Bone_Bow",
            "VAHeavy_Blood_Bone_Bow(Clone)",
            "VABlood_Bones_pickaxe",
            "VABlood_Bones_pickaxe(Clone)",
        };

        private static List<string> queenBuffPrefabs = new List<string>
        {
            "VAQueen_greatsword",
            "VAQueen_greatsword(Clone)",
            "VASwordQueen",
            "VASwordQueen(Clone)",
            "VAQueen_bow",
            "VAQueen_bow(Clone)",
            "VAdagger_queen",
            "VAdagger_queen(Clone)",
        };

        public static void OnConfigBloodChanged(object sender, EventArgs e)
        {
            SE_Stats bloodbuff = null;
            foreach (SE_Stats buff in Resources.FindObjectsOfTypeAll<SE_Stats>().Where(se => se.name == "VABloodBuff").ToList()) {
                buff.m_healthRegenMultiplier = VAConfig.BloodHungerRegen.Value;
                bloodbuff = buff;
            }
            IEnumerable<GameObject> prefabs = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => bloodBuffPrefabs.Contains(obj.name));
            foreach (GameObject go in prefabs) {
                ItemDrop id = null;
                if (go.TryGetComponent<ItemDrop>(out id)) {
                    id.m_itemData.m_shared.m_equipStatusEffect = bloodbuff;
                }
            }
            if (Player.m_localPlayer == null) { return; }
            foreach (ItemDrop.ItemData user_item in Player.m_localPlayer.m_inventory.GetAllItems())
            {
                if (user_item == null) { continue; }
                if (bloodBuffPrefabs.Contains(user_item.m_dropPrefab.name)) { continue; }
                user_item.m_shared.m_equipStatusEffect = bloodbuff;
            }
        }

        public static void OnConfigQueenHealthRegenChanged(object sender, EventArgs e)
        {
            SE_Stats queenbuff = null;
            foreach (SE_Stats buff in Resources.FindObjectsOfTypeAll<SE_Stats>().Where(se => se.name == "VAQueen_buff").ToList())
            {
                buff.m_healthRegenMultiplier = VAConfig.QueenHealthRegen.Value;
                buff.m_eitrRegenMultiplier = VAConfig.QueenEitrRegen.Value;
                queenbuff = buff;
            }
            IEnumerable<GameObject> prefabs = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => queenBuffPrefabs.Contains(obj.name));
            foreach (GameObject go in prefabs)
            {
                ItemDrop id = null;
                if (go.TryGetComponent<ItemDrop>(out id))
                {
                    id.m_itemData.m_shared.m_equipStatusEffect = queenbuff;
                }
            }
            if (Player.m_localPlayer == null) { return; }
            foreach (ItemDrop.ItemData user_item in Player.m_localPlayer.m_inventory.GetAllItems())
            {
                if (user_item == null) { continue; }
                if (queenBuffPrefabs.Contains(user_item.m_dropPrefab.name)) { continue; }
                user_item.m_shared.m_equipStatusEffect = queenbuff;
            }
        }

        public static void SyncStatusEffectsToConfig() {
            OnConfigBloodChanged(null, null);
            OnConfigQueenHealthRegenChanged(null, null);
        }
    }
}
