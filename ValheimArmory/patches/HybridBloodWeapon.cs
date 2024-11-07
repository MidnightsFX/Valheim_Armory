using HarmonyLib;
using System.Collections.Generic;
using static Skills;
using Logger = Jotunn.Logger;

namespace ValheimArmory.patches
{
    public static class HybridBloodWeapon
    {

        [HarmonyPatch(typeof(Skills), nameof(Skills.RaiseSkill))]
        public class BloodHybridWeaponsRaiseSkills
        {
            // This doesn't need to manipulate the result, we just want to hook into the skill type and item that cause the skill increase etc
            public static void Postfix(SkillType skillType, float factor)
            {
                List<int> HybridWeapons = new List<int>() { "VABlood_bone_bow".GetHashCode(), "VABlood_Bones_pickaxe".GetHashCode(), "VAHeavy_Blood_Bone_Bow".GetHashCode() };
                // if (VAConfig.EnableDebugMode.Value == true) { Logger.LogInfo($"Checking skilltype raise that includes blood hybrid weapon {skillType}"); }
                // Current weapon skill types that have blood magic usage
                if (skillType == Skills.SkillType.Bows || skillType == Skills.SkillType.Pickaxes)
                {
                    //List<ItemDrop.ItemData> equipedItems = Player.m_localPlayer.m_inventory.GetEquippedItems();
                    // if (VAConfig.EnableDebugMode.Value == true) { Logger.LogInfo($"Checking for a blood-hybrid weapontype {Player.m_localPlayer.GetCurrentWeapon().m_dropPrefab.name}"); }
                    if (HybridWeapons.Contains(Player.m_localPlayer.GetCurrentWeapon().m_dropPrefab.name.GetHashCode()))
                    {
                        Player.m_localPlayer.RaiseSkill(Skills.SkillType.BloodMagic, VAConfig.HybridWeaponBloodMagicSkillIncrease.Value);
                    }
                }
            }
        }


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
