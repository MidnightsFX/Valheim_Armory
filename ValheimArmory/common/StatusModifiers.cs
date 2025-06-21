using System;
using System.Linq;
using UnityEngine;

namespace ValheimArmory.common
{
    internal class StatusModifiers
    {
        public static void OnConfigBloodChanged(object sender, EventArgs e)
        {
            Resources.FindObjectsOfTypeAll<SE_Stats>().Where(se => se.name == "VABloodBuff")
                .ToList()
                .ForEach(se => {
                    se.m_healthRegenMultiplier = VAConfig.BloodHungerRegen.Value;
                });
        }

        public static void OnConfigQueenHealthRegenChanged(object sender, EventArgs e)
        {
            Resources.FindObjectsOfTypeAll<SE_Stats>().Where(se => se.name == "VAQueen_buff")
                .ToList()
                .ForEach(se => {
                    se.m_healthRegenMultiplier = VAConfig.QueenHealthRegen.Value;
                    se.m_eitrRegenMultiplier = VAConfig.QueenEitrRegen.Value;
                });
        }
    }
}
