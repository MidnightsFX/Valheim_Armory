using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Skills;

namespace ValheimArmory.patches
{
    public static class HybridBloodWeapon
    {
        // Weapon prefab -> extra skills trained whenever that weapon trains its own skill.
        // Keyed by the ObjectDB prefab that every ItemData.m_dropPrefab points at, so the lookup is an instance id hash instead of a native name string allocation.
        private static readonly Dictionary<GameObject, SkillType[]> HybridWeapons = new Dictionary<GameObject, SkillType[]>();

        // Registered from ItemDefinition.HybridSkills as items are added
        internal static void RegisterHybridWeapon(ItemDrop weapon, List<SkillType> hybridSkills)
        {
            SkillType weaponSkill = weapon.m_itemData.m_shared.m_skillType;
            if (hybridSkills.Contains(weaponSkill)) {
                Logger.LogWarning($"{weapon.name} lists its own skill {weaponSkill} as a hybrid skill, ignoring it.");
            }
            SkillType[] skills = hybridSkills.Where(skill => skill != weaponSkill && skill != SkillType.None).Distinct().ToArray();
            if (skills.Length == 0) { return; }
            HybridWeapons[weapon.gameObject] = skills;
            Logger.LogDebug($"{weapon.name} ({weaponSkill}) also trains {string.Join(", ", skills)}");
        }

        // Player rather than Skills: summons and tames raise their owner's skill directly through Skills,
        // and those raises should not grant hybrid XP for whatever weapon the owner happens to be holding.
        [HarmonyPatch(typeof(Player), nameof(Player.RaiseSkill))]
        public static class BloodHybridWeaponsRaiseSkills
        {
            // Set while granting hybrid skills so those raises can never re-enter this patch
            private static bool raisingHybridSkills = false;

            public static void Postfix(Player __instance, SkillType skill)
            {
                if (raisingHybridSkills) { return; }
                ItemDrop.ItemData weapon = __instance.GetCurrentWeapon();
                // Only the weapon training its own skill counts as a use, not running, blocking etc while holding it
                if (weapon == null || weapon.m_shared.m_skillType != skill || weapon.m_dropPrefab == null) { return; }
                if (!HybridWeapons.TryGetValue(weapon.m_dropPrefab, out SkillType[] hybridSkills)) { return; }

                raisingHybridSkills = true;
                try {
                    foreach (SkillType hybridSkill in hybridSkills) {
                        __instance.RaiseSkill(hybridSkill, ValConfig.HybridWeaponBloodMagicSkillIncrease.Value);
                    }
                } finally {
                    raisingHybridSkills = false;
                }
            }
        }

        // TODO:
        // Modify damage for hybrid weapons by their blood factor
        //[HarmonyPatch(typeof(Character), nameof(Character.Damage))]
        //public static class IncreaseBloodHybridWeaponDamage
        //{
        //    private static void Prefix(HitData hit)
        //    {
        //        if (hit.GetAttacker() is Player attacker)
        //        {
        //            float skillFactor = Player.m_localPlayer.m_skills.GetSkillFactor(Skills.SkillType.BloodMagic);
        //            float num = Mathf.Lerp(0.4f, 1f, skillFactor);
        //        }
        //    }
        //}
    }
}
