using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static ItemDrop;

namespace ValheimArmory
{
    internal class ItemEffects
    {
    }

    class EtirBuff : MonoBehaviour
    {
        private static bool buffApplied = false;
        private ZNetView zNetView;
        private ItemDrop itemMetaData;
        private float bonus_value = 15; // Default
        private void Awake()
        {
            zNetView = GetComponent<ZNetView>();
            itemMetaData = GetComponent<ItemDrop>();
        }

        public void SetBonus(float value)
        {
            bonus_value = value;
        }

        private void Update()
        {
            Jotunn.Logger.LogInfo($"Staff checking status: {zNetView.IsValid()} {Player.m_localPlayer.IsEquipActionQueued(itemMetaData.m_itemData)}");
            if (zNetView.IsValid() && Player.m_localPlayer.IsEquipActionQueued(itemMetaData.m_itemData))
            {
                if (buffApplied == false)
                {
                    Jotunn.Logger.LogInfo("Eitr buff applied");
                    buffApplied = true;
                    float adjusted_eitr = Player.m_localPlayer.GetMaxEitr() + bonus_value;
                    float player_health = Player.m_localPlayer.GetMaxHealth();
                    float player_stamina = Player.m_localPlayer.GetMaxStamina();
                    Player.m_localPlayer.GetTotalFoodValue(out player_health, out player_stamina, out adjusted_eitr);
                    Player.m_localPlayer.m_maxEitr += 20;
                    Player.m_localPlayer.m_eitr += 20;
                } else
                {
                    Jotunn.Logger.LogInfo("Eitr buff removed");
                    Player.m_localPlayer.m_maxEitr -= 20;
                }
            }

        }
    }
}
