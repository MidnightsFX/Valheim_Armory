using Jotunn.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static EffectList;
using Logger = Jotunn.Logger;

namespace ValheimArmory.common
{
    internal static class WeaponModifier
    {

        public static Dictionary<string, Attack> AttackTypes = new Dictionary<string, Attack>();
        public static List<string> ModifiedWeapons = new List<string>(); 
        public static bool CheckForModification(string weapon)
        {
            if (ModifiedWeapons.Contains(weapon)) {  return true; }
            return false;
        }

        public static Attack SetWarhammerPrimaryAttack(float stamina_cost = 22f)
        {
            Attack primary_attack = new Attack();
            primary_attack.m_attackChainLevels = 3;
            primary_attack.m_attackRandomAnimations = 0;
            primary_attack.m_hitTerrain = true;
            primary_attack.m_speedFactor = 0.3f;
            primary_attack.m_speedFactorRotation = 0.3f;
            primary_attack.m_attackStartNoise = 20f;
            primary_attack.m_attackHitNoise = 30f;
            primary_attack.m_forceMultiplier = 1f;
            primary_attack.m_staggerMultiplier = 1.5f;
            primary_attack.m_damageMultiplier = 1f;
            primary_attack.m_attackAnimation = "battleaxe_attack";
            primary_attack.m_attackType = Attack.AttackType.Horizontal;
            primary_attack.m_attackRange = 2.5f;
            primary_attack.m_attackHeight = 1f;
            primary_attack.m_skillHitType = DestructibleType.Character;

            primary_attack.m_attackAngle = 90f;
            primary_attack.m_attackRayWidth = 0.5f;
            primary_attack.m_multiHit = true;
            primary_attack.m_raiseSkillAmount = 1f;
            primary_attack.m_lastChainDamageMultiplier = 2f;
            primary_attack.m_hitPointtype = Attack.HitPointType.Closest;
            primary_attack.m_lowerDamagePerHit = true;
            primary_attack.m_resetChainIfHit = DestructibleType.Tree;

            // Things specific to each weapon
            primary_attack.m_attackStamina = stamina_cost;
            primary_attack.m_lastChainDamageMultiplier = 2f;

            return primary_attack;
        }

        public static void ModifyItemEffectsToHammer(ItemDrop.ItemData id)
        {
            if (id.m_shared.m_startEffect.HasEffects())
            {
                id.m_shared.m_secondaryAttack.m_startEffect = id.m_shared.m_startEffect;
                id.m_shared.m_startEffect = new EffectList(); // clean out start effects
            }
            if (id.m_shared.m_triggerEffect.HasEffects())
            {
                id.m_shared.m_secondaryAttack.m_triggerEffect = id.m_shared.m_triggerEffect;
                id.m_shared.m_triggerEffect = new EffectList(); // clear out the trigger effects
            }

            GameObject vfx_clubhit = PrefabManager.Instance.GetPrefab("vfx_clubhit");
            GameObject sfx_clubhit = PrefabManager.Instance.GetPrefab("sfx_clubhit");
            if (VAConfig.EnableDebugMode.Value) { Logger.LogInfo($"Found effect prefabs for hammer modification: {vfx_clubhit} {sfx_clubhit}"); }
            EffectData[] club_hit_effects = { new EffectData() { m_prefab = vfx_clubhit, m_enabled = true, m_variant = -1 }, new EffectData() { m_prefab = sfx_clubhit, m_enabled = true, m_variant = -1 } };
            id.m_shared.m_attack.m_hitEffect = new EffectList { m_effectPrefabs = club_hit_effects };
        }

        public static Attack SetWarhammerSecondaryAttack(float stamina_cost = 12f)
        {
            GameObject vfx_clubhit = PrefabManager.Instance.GetPrefab("vfx_clubhit");
            GameObject sfx_clubhit = PrefabManager.Instance.GetPrefab("sfx_clubhit");
            EffectData[] club_hit_effects = { new EffectData() { m_prefab = vfx_clubhit, m_enabled = true, m_variant = -1 }, new EffectData() { m_prefab = sfx_clubhit, m_enabled = true, m_variant = -1 } };
            Attack secondary_attack = new Attack();
            secondary_attack.m_speedFactor = 0.2f;
            secondary_attack.m_speedFactorRotation = 0.2f;
            secondary_attack.m_attackStartNoise = 10f;
            secondary_attack.m_attackHitNoise = 60f;
            secondary_attack.m_forceMultiplier = 2f;
            secondary_attack.m_staggerMultiplier = 2f;
            secondary_attack.m_damageMultiplier = 1.5f;
            secondary_attack.m_attackAnimation = "swing_sledge";
            secondary_attack.m_attackType = Attack.AttackType.Area;
            secondary_attack.m_attackRange = 2.5f;
            secondary_attack.m_attackHeight = 0.6f;

            secondary_attack.m_attackAngle = 90f;
            secondary_attack.m_attackRayWidth = 0.5f;
            secondary_attack.m_multiHit = true;
            secondary_attack.m_hitPointtype = Attack.HitPointType.Closest;
            secondary_attack.m_raiseSkillAmount = 1f;

            // Things specific to each weapon
            secondary_attack.m_attackStamina = stamina_cost;
            secondary_attack.m_lastChainDamageMultiplier = 2f;
            secondary_attack.m_hitEffect = new EffectList { m_effectPrefabs = club_hit_effects };

            return secondary_attack;
        }

        public static void ModifyWeaponAttack(string weapon_prefab, Attack attack, Attack secondary, string animation_set = null, bool copy_primary_to_secondary = false, bool copy_secondary_to_primary = false, bool check_for_secondary = false)
        {
            // This ensures modifications of clones also
            IEnumerable<GameObject> objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name.StartsWith(weapon_prefab));

            foreach (GameObject obj in objects)
            {
                ItemDrop id = null;
                if (obj.TryGetComponent<ItemDrop>(out id))
                {
                    UpdateWeaponAttackItemdata(id.m_itemData, weapon_prefab, attack, secondary, animation_set, copy_primary_to_secondary, copy_secondary_to_primary, check_for_secondary);
                }
            }

            if (Player.m_localPlayer != null)
            {
                if (VAConfig.EnableDebugMode.Value == true) { Logger.LogInfo($"Modifying items within the players inventory."); }
                // Update all instances that are in the backpack
                foreach (ItemDrop.ItemData user_item in Player.m_localPlayer.m_inventory.GetAllItems())
                {
                    if (user_item == null) { continue; }
                    if (user_item.m_dropPrefab.name != weapon_prefab) { continue; }

                    if (VAConfig.EnableDebugMode.Value == true) { Logger.LogInfo($"{user_item.m_shared.m_name} found in the players backpack, updating."); }
                    UpdateWeaponAttackItemdata(user_item, weapon_prefab, attack, secondary, animation_set, copy_primary_to_secondary, copy_secondary_to_primary, check_for_secondary);
                }
            }
        }

        public static void UpdateWeaponAttackItemdata(ItemDrop.ItemData id, string weapon_prefab, Attack attack, Attack secondary, string animation_set = null, bool copy_primary_to_secondary = false, bool copy_secondary_to_primary = false, bool check_for_secondary = false)
        {
            // Skip modifying this item if it doesn't have a secondary
            if (check_for_secondary && id.m_shared.m_secondaryAttack.m_attackAnimation.Length == 0)
            {
                if (VAConfig.EnableDebugMode.Value) { Logger.LogInfo($"Skipping weapon modification due to existing configuration {weapon_prefab}"); }
                return;
            }
            // Copy primary attack to secondary attack
            if (copy_primary_to_secondary == true)
            {
                if (VAConfig.EnableDebugMode.Value) { Logger.LogInfo($"Replaced secondary attack with primary attack {weapon_prefab}"); }
                id.m_shared.m_secondaryAttack = id.m_shared.m_attack;
            }
            // Copy secondary attack to primary attack
            if (copy_secondary_to_primary == true)
            {
                if (VAConfig.EnableDebugMode.Value) { Logger.LogInfo($"Replaced primary attack with secondary attack {weapon_prefab}"); }
                id.m_shared.m_attack = id.m_shared.m_secondaryAttack;
            }
            // Modify if the attack is set
            if (attack != null)
            {
                if (VAConfig.EnableDebugMode.Value) { Logger.LogInfo($"Set primary attack {weapon_prefab}"); }
                id.m_shared.m_attack = attack;
            }
            // Modify secondary if it is set
            if (secondary != null)
            {
                if (VAConfig.EnableDebugMode.Value) { Logger.LogInfo($"Set secondary attack {weapon_prefab}"); }
                id.m_shared.m_secondaryAttack = secondary;
            }
            // Modify attack animations to move shared effects to specific attacks
            // This shouldn't need to be re-ran
            if (animation_set == "sledge")
            {
                if (VAConfig.EnableDebugMode.Value) { Logger.LogInfo($"Updating animations for {weapon_prefab}"); }
                ModifyItemEffectsToHammer(id);
            }
        }

        public static void ModifySledgeToWarhammer(string prefab, float stamina_cost_primary, float stamina_cost_secondary)
        {
            if (VAConfig.EnableDebugMode.Value) { Logger.LogInfo($"Modifying {prefab} to a warhammer"); }
            Attack primary_attack = SetWarhammerPrimaryAttack();
            //Attack secondary_attack = SetWarhammerSecondaryAttack();
            ModifyWeaponAttack(prefab, primary_attack, null, "sledge", copy_primary_to_secondary: true);
            // ModifyWeaponAttack(prefab, secondary_attack, stamina_cost_secondary, false);
        }

        public static void ModifySledgeToSledge(string prefab)
        {
            if (VAConfig.EnableDebugMode.Value) { Logger.LogInfo($"Modifying {prefab} to a sledge"); }
            ModifyWeaponAttack(prefab, null, new Attack(), copy_secondary_to_primary: true, check_for_secondary: true);
        }

        public static void ModifyVanillaHammersToWarhammers()
        {
            if (VAConfig.VanillaHammersHavePrimaryAttack.Value)
            {
                ModifySledgeToWarhammer("SledgeStagbreaker", 6, 12);
                ModifySledgeToWarhammer("SledgeIron", 10, 20);
                ModifySledgeToWarhammer("SledgeDemolisher", 14, 28);
            }
        }

        public static void RevertVanillaHammers()
        {
            ModifySledgeToSledge("SledgeStagbreaker");
            ModifySledgeToSledge("SledgeIron");
            ModifySledgeToSledge("SledgeDemolisher");
        }

        public static void OnConfigChangeModifyHammers(object sender, EventArgs e)
        {
            if (VAConfig.VanillaHammersHavePrimaryAttack.Value)
            {
                ModifyVanillaHammersToWarhammers();
            } else
            {
                RevertVanillaHammers();
            }
        }
    }
}
