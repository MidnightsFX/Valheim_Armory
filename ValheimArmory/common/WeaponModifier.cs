using Jotunn.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static EffectList;
using Logger = Jotunn.Logger;

namespace ValheimArmory.common
{

    internal static class WeaponModifier
    {
        static GameObject vfx_sledge_hit;
        static GameObject fx_camshake;
        static GameObject sfx_sledge_hit;
        static GameObject sfx_sledge_swing;
        static GameObject fx_demolisher_hit;
        static GameObject vfx_clubhit;
        static GameObject sfx_clubhit;

        internal class WeaponAttackData
        {
            public Attack primary_attack { get; set; }
            public Attack secondary_attack { get; set; }
        }

        static Dictionary<String, WeaponAttackData> OriginalWeaponAttackCache = new Dictionary<String, WeaponAttackData>();

        internal static WeaponAttackData CheckForWeaponData(string weapon_name)
        {
            if (OriginalWeaponAttackCache.ContainsKey(weapon_name))
            {
                return OriginalWeaponAttackCache[weapon_name];
            }

            IEnumerable<GameObject> objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name.StartsWith(weapon_name));
            foreach (GameObject obj in objects)
            {
                ItemDrop id = null;
                if (obj.TryGetComponent<ItemDrop>(out id))
                {
                    OriginalWeaponAttackCache.Add(weapon_name, new WeaponAttackData() { primary_attack = id.m_itemData.m_shared.m_attack, secondary_attack = id.m_itemData.m_shared.m_secondaryAttack });
                    // We just need to at this one
                    break;
                }
            }
            return OriginalWeaponAttackCache[weapon_name];
        }

        public static void SetupEffects()
        {
             vfx_sledge_hit = PrefabManager.Instance.GetPrefab("vfx_sledge_hit");
             fx_camshake = PrefabManager.Instance.GetPrefab("fx_swing_camshake");
             sfx_sledge_hit = PrefabManager.Instance.GetPrefab("sfx_sledge_hit");
             sfx_sledge_swing = PrefabManager.Instance.GetPrefab("sfx_sledge_swing");
             fx_demolisher_hit = PrefabManager.Instance.GetPrefab("fx_sledge_demolisher_hit");
             vfx_clubhit = PrefabManager.Instance.GetPrefab("vfx_clubhit");
             sfx_clubhit = PrefabManager.Instance.GetPrefab("sfx_club_hit");
            if (VAConfig.EnableDebugMode.Value) {
                Logger.LogInfo($"Set Effect Prefabs: vfx_sledge_hit:{vfx_sledge_hit} fx_camshake:{fx_camshake} sfx_sledge_hit:{sfx_sledge_hit} sfx_sledge_swing:{sfx_sledge_swing} fx_demolisher_hit:{fx_demolisher_hit} vfx_clubhit:{vfx_clubhit} sfx_clubhit:{sfx_clubhit}"); 
            }
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

        public static Attack SetSledgeSmash(float stamina_cost = 14f)
        {
            Attack sledge_attack = new Attack();
            sledge_attack.m_attackChainLevels = 0;
            sledge_attack.m_attackRandomAnimations = 0;
            sledge_attack.m_hitTerrain = true;
            sledge_attack.m_speedFactor = 0.3f;
            sledge_attack.m_speedFactorRotation = 0.1f;
            sledge_attack.m_attackStartNoise = 10f;
            sledge_attack.m_attackHitNoise = 60f;
            sledge_attack.m_forceMultiplier = 1f;
            sledge_attack.m_staggerMultiplier = 1.5f;
            sledge_attack.m_damageMultiplier = 1f;
            sledge_attack.m_attackAnimation = "swing_sledge";
            sledge_attack.m_attackType = Attack.AttackType.Area;
            sledge_attack.m_attackRange = 2f;
            sledge_attack.m_attackHeight = 0f;
            sledge_attack.m_skillHitType = DestructibleType.Character;
            sledge_attack.m_attackAngle = 90f;
            sledge_attack.m_attackRayWidth = 4f;
            sledge_attack.m_multiHit = true;
            sledge_attack.m_raiseSkillAmount = 1f;
            sledge_attack.m_lastChainDamageMultiplier = 2f;
            sledge_attack.m_hitPointtype = Attack.HitPointType.Closest;
            sledge_attack.m_lowerDamagePerHit = true;
            sledge_attack.m_resetChainIfHit = DestructibleType.None;

            // Things specific to each weapon
            sledge_attack.m_attackStamina = stamina_cost;
            sledge_attack.m_lastChainDamageMultiplier = 2f;

            return sledge_attack;
        }

        public static EffectList SledgeTriggerEffects(bool demolisher = false)
        {
            EffectData[] sledge_trigger_effects = { new EffectData() { m_prefab = fx_camshake, m_enabled = true, m_variant = -1 }, new EffectData() { m_prefab = vfx_sledge_hit, m_enabled = true, m_variant = -1 }, new EffectData() { m_prefab = sfx_sledge_hit, m_enabled = true, m_variant = -1 } };
            EffectData[] demolisher_trigger_effects = { new EffectData() { m_prefab = fx_camshake, m_enabled = true, m_variant = -1 }, new EffectData() { m_prefab = fx_demolisher_hit, m_enabled = true, m_variant = -1 } };
            
            if (demolisher) { sledge_trigger_effects = demolisher_trigger_effects; }
            return new EffectList { m_effectPrefabs = sledge_trigger_effects };
        }

        public static EffectList SledgeStartEffects()
        {
            EffectData[] sledge_start_efffect = { new EffectData() { m_prefab = sfx_sledge_swing, m_enabled = true, m_variant = -1 } };
            return new EffectList { m_effectPrefabs = sledge_start_efffect }; ;
        }

        public static EffectList SetWarhammerAttackVFX()
        {
            EffectData[] club_hit_effects = { new EffectData() { m_prefab = vfx_clubhit, m_enabled = true, m_variant = -1 }, new EffectData() { m_prefab = sfx_clubhit, m_enabled = true, m_variant = -1 } };
            return new EffectList { m_effectPrefabs = club_hit_effects };
        }

        public static void ClearSecondaryAttack(ItemDrop.ItemData id)
        {
            id.m_shared.m_secondaryAttack = new Attack { };
        }

        public static void ClearSharedVFX(ItemDrop.ItemData id)
        {
            id.m_shared.m_startEffect = new EffectList();
            id.m_shared.m_triggerEffect = new EffectList();
            id.m_shared.m_hitEffect = new EffectList();
            id.m_shared.m_hitTerrainEffect = new EffectList();
        }

        public static void SledgeToWarhammer(string weapon_prefab, float primary_stamina, float secondary_stamina)
        {
            bool demolisher = false;
            if (weapon_prefab == "SledgeDemolisher") { demolisher = true; }
            Attack primary = SetWarhammerPrimaryAttack(primary_stamina);
            Attack secondary = SetSledgeSmash(secondary_stamina);
            EffectList warhammer_primary_effects = SetWarhammerAttackVFX();
            EffectList sledge_trigger_effects = SledgeTriggerEffects(demolisher);
            EffectList sledge_start_effects = SledgeStartEffects();
            // This ensures modifications of clones also
            IEnumerable<GameObject> objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name.StartsWith(weapon_prefab));

            foreach (GameObject obj in objects)
            {
                ItemDrop id = null;
                if (obj.TryGetComponent<ItemDrop>(out id))
                {
                    id.m_itemData.m_shared.m_attack = primary;
                    id.m_itemData.m_shared.m_secondaryAttack = secondary;
                    id.m_itemData.m_shared.m_attack.m_hitEffect = warhammer_primary_effects;
                    id.m_itemData.m_shared.m_secondaryAttack.m_triggerEffect = sledge_trigger_effects;
                    id.m_itemData.m_shared.m_secondaryAttack.m_startEffect = sledge_start_effects;
                    ClearSharedVFX(id.m_itemData);
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
                    user_item.m_shared.m_attack = primary;
                    user_item.m_shared.m_secondaryAttack = secondary;
                    user_item.m_shared.m_attack.m_hitEffect = warhammer_primary_effects;
                    user_item.m_shared.m_secondaryAttack.m_triggerEffect = sledge_trigger_effects;
                    user_item.m_shared.m_secondaryAttack.m_startEffect = sledge_start_effects;
                    ClearSharedVFX(user_item);
                }
            }
        }

        public static void ToSledge(string weapon_prefab, float sledge_stamina)
        {
            bool demolisher = false;
            if (weapon_prefab == "SledgeDemolisher") { demolisher = true; }
            Attack sledgesmash = SetSledgeSmash(sledge_stamina);
            EffectList sledge_trigger_effects = SledgeTriggerEffects(demolisher);
            EffectList sledge_start_effects = SledgeStartEffects();
            // This ensures modifications of clones also
            IEnumerable<GameObject> objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name.StartsWith(weapon_prefab));

            foreach (GameObject obj in objects)
            {
                ItemDrop id = null;
                if (obj.TryGetComponent<ItemDrop>(out id))
                {
                    id.m_itemData.m_shared.m_attack = sledgesmash;
                    ClearSharedVFX(id.m_itemData);
                    ClearSecondaryAttack(id.m_itemData);
                    id.m_itemData.m_shared.m_triggerEffect = sledge_trigger_effects;
                    id.m_itemData.m_shared.m_startEffect = sledge_start_effects;
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
                    user_item.m_shared.m_attack = sledgesmash;
                    ClearSharedVFX(user_item);
                    ClearSecondaryAttack(user_item);
                    user_item.m_shared.m_triggerEffect = sledge_trigger_effects;
                    user_item.m_shared.m_startEffect = sledge_start_effects;
                }
            }
        }

        public static void ModifyStamina(string weapon_prefab, float sledge_stamina)
        {
            // This ensures modifications of clones also
            IEnumerable<GameObject> objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name.StartsWith(weapon_prefab));

            foreach (GameObject obj in objects)
            {
                ItemDrop id = null;
                if (obj.TryGetComponent<ItemDrop>(out id))
                {
                    id.m_itemData.m_shared.m_attack.m_attackStamina = sledge_stamina;
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
                    user_item.m_shared.m_attack.m_attackStamina = sledge_stamina;
                }
            }
        }


        public static void SetWeaponPrimaryAndSecondary(string weapon_prefab, Attack primary, Attack secondary)
        {
            // This ensures modifications of clones also
            IEnumerable<GameObject> objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name.StartsWith(weapon_prefab));

            foreach (GameObject obj in objects)
            {
                ItemDrop id = null;
                if (obj.TryGetComponent<ItemDrop>(out id))
                {
                    id.m_itemData.m_shared.m_attack = primary;
                    id.m_itemData.m_shared.m_secondaryAttack = secondary;
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
                    user_item.m_shared.m_attack = primary;
                    user_item.m_shared.m_secondaryAttack = secondary;
                }
            }
        }

        public static void ModifyVanillaHammersToWarhammers()
        {
            if (VAConfig.VanillaHammersHavePrimaryAttack.Value)
            {
                SledgeToWarhammer("SledgeStagbreaker", VAConfig.StagbreakerPrimaryAttackStamina.Value, 12);
                SledgeToWarhammer("SledgeIron", VAConfig.IronSledgePrimaryAttackStamina.Value, 20);
                SledgeToWarhammer("SledgeDemolisher", VAConfig.DemolisherPrimaryAttackStamina.Value, 28);
            }
        }

        public static void ModifyVanillaHammersToSledges()
        {
            ToSledge("SledgeStagbreaker", 12);
            ToSledge("SledgeIron", 20);
            ToSledge("SledgeDemolisher", 28);
        }

        public static void ModifyModHammersToSledges()
        {
            SetWeaponPrimaryAndSecondary("VAflametal_sledge_nature", CheckForWeaponData("VAflametal_sledge_nature").secondary_attack, new Attack());
            SetWeaponPrimaryAndSecondary("VAflametal_sledge_lightning", CheckForWeaponData("VAflametal_sledge_lightning").secondary_attack, new Attack());
            SetWeaponPrimaryAndSecondary("VAflametal_sledge_blood", CheckForWeaponData("VAflametal_sledge_blood").secondary_attack, new Attack());
            SetWeaponPrimaryAndSecondary("VAflametal_sledge", CheckForWeaponData("VAflametal_sledge").secondary_attack, new Attack());
            SetWeaponPrimaryAndSecondary("VAblackmetal_sledge", CheckForWeaponData("VAblackmetal_sledge").secondary_attack, new Attack());
            SetWeaponPrimaryAndSecondary("VAElderHammer", CheckForWeaponData("VAElderHammer").secondary_attack, new Attack());
            SetWeaponPrimaryAndSecondary("VABronzeSledge", CheckForWeaponData("VABronzeSledge").secondary_attack, new Attack());
            SetWeaponPrimaryAndSecondary("VABonemassWarhammer", CheckForWeaponData("VABonemassWarhammer").secondary_attack, new Attack());
            SetWeaponPrimaryAndSecondary("VASilverSledge", CheckForWeaponData("VASilverSledge").secondary_attack, new Attack());
        }

        public static void ModifyModHammersToWarhammers()
        {
            SetWeaponPrimaryAndSecondary("VAflametal_sledge_nature", CheckForWeaponData("VAflametal_sledge_nature").primary_attack, CheckForWeaponData("VAflametal_sledge_nature").secondary_attack);
            SetWeaponPrimaryAndSecondary("VAflametal_sledge_lightning", CheckForWeaponData("VAflametal_sledge_lightning").primary_attack, CheckForWeaponData("VAflametal_sledge_lightning").secondary_attack);
            SetWeaponPrimaryAndSecondary("VAflametal_sledge_blood", CheckForWeaponData("VAflametal_sledge_blood").primary_attack, CheckForWeaponData("VAflametal_sledge_blood").secondary_attack);
            SetWeaponPrimaryAndSecondary("VAflametal_sledge", CheckForWeaponData("VAflametal_sledge").primary_attack, CheckForWeaponData("VAflametal_sledge").secondary_attack);
            SetWeaponPrimaryAndSecondary("VAblackmetal_sledge", CheckForWeaponData("VAblackmetal_sledge").primary_attack, CheckForWeaponData("VAblackmetal_sledge").secondary_attack);
            SetWeaponPrimaryAndSecondary("VAElderHammer", CheckForWeaponData("VAElderHammer").primary_attack, CheckForWeaponData("VAElderHammer").secondary_attack);
            SetWeaponPrimaryAndSecondary("VABronzeSledge", CheckForWeaponData("VABronzeSledge").primary_attack, CheckForWeaponData("VABronzeSledge").secondary_attack);
            SetWeaponPrimaryAndSecondary("VABonemassWarhammer", CheckForWeaponData("VABonemassWarhammer").primary_attack, CheckForWeaponData("VABonemassWarhammer").secondary_attack);
            SetWeaponPrimaryAndSecondary("VASilverSledge", CheckForWeaponData("VASilverSledge").primary_attack, CheckForWeaponData("VASilverSledge").secondary_attack);
        }

        public static void OnConfigChangeModifyHammers(object sender, EventArgs e)
        {
            if (VAConfig.VanillaHammersHavePrimaryAttack.Value)
            {
                ModifyVanillaHammersToWarhammers();
            } else {
                ModifyVanillaHammersToSledges();
            }
        }

        public static void OnConfigChangeModifyModHammers(object sender, EventArgs e)
        {
            if (VAConfig.ModHammersHavePrimaryAttack.Value)
            {
                ModifyModHammersToWarhammers();
            } else {
                ModifyModHammersToSledges();
            }
        }

        public static void OnConfigStagbreakerValueChanged(object sender, EventArgs e)
        {
            if (VAConfig.VanillaHammersHavePrimaryAttack.Value)
            {
                ModifyStamina("SledgeStagbreaker", VAConfig.StagbreakerPrimaryAttackStamina.Value);
            }
        }

        public static void OnConfigIronSledgeValueChanged(object sender, EventArgs e)
        {
            if (VAConfig.VanillaHammersHavePrimaryAttack.Value)
            {
                ModifyStamina("SledgeIron", VAConfig.IronSledgePrimaryAttackStamina.Value);
            }
        }

        public static void OnConfigDemolisherValueChanged(object sender, EventArgs e)
        {
            if (VAConfig.VanillaHammersHavePrimaryAttack.Value)
            {
                ModifyStamina("SledgeDemolisher", VAConfig.DemolisherPrimaryAttackStamina.Value);
            }
        }

        public static void ModifyVanillaKnife()
        {
            if (VAConfig.VanillaAbyssalKnifeBluntDamageConvert.Value)
            {
                KnifeToAbyssal("KnifeChitin");
            }
        }

        public static void OnConfigChangeModifyVanillaKnife(object sender, EventArgs e)
        {
            if (VAConfig.VanillaAbyssalKnifeBluntDamageConvert.Value)
            {
                KnifeToAbyssal("KnifeChitin");
            }
            else
            {
                KnifeToVanilla("KnifeChitin");
            }
        }

        public static void OnConfigAbyssalKnifeValueChanged(object sender, EventArgs e)
        {
            if (VAConfig.VanillaHammersHavePrimaryAttack.Value)
            {
                KnifeToAbyssal("KnifeChitin");
            }
        }

        public static void KnifeToAbyssal(string weapon_prefab)
        {
            // This ensures modifications of clones also
            IEnumerable<GameObject> objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name.StartsWith(weapon_prefab));

            foreach (GameObject obj in objects)
            {
                ItemDrop id = null;
                if (obj.TryGetComponent<ItemDrop>(out id))
                {
                    id.m_itemData.m_shared.m_damages.m_slash = 0;
                    id.m_itemData.m_shared.m_damages.m_blunt = VAConfig.AbyssalKnifeBlunt.Value;
                    id.m_itemData.m_shared.m_damagesPerLevel.m_slash = 0;
                    id.m_itemData.m_shared.m_damagesPerLevel.m_blunt = VAConfig.AbyssalKnifeBluntPerLevel.Value;
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
                    user_item.m_shared.m_damages.m_slash = 0;
                    user_item.m_shared.m_damages.m_blunt = VAConfig.AbyssalKnifeBlunt.Value;
                    user_item.m_shared.m_damagesPerLevel.m_slash = 0;
                    user_item.m_shared.m_damagesPerLevel.m_blunt = VAConfig.AbyssalKnifeBluntPerLevel.Value;
                }
            }
        }

        public static void KnifeToVanilla(string weapon_prefab)
        {
            // This ensures modifications of clones also
            IEnumerable<GameObject> objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name.StartsWith(weapon_prefab));

            foreach (GameObject obj in objects)
            {
                ItemDrop id = null;
                if (obj.TryGetComponent<ItemDrop>(out id))
                {
                    id.m_itemData.m_shared.m_damages.m_blunt = 0;
                    id.m_itemData.m_shared.m_damages.m_slash = 20;
                    id.m_itemData.m_shared.m_damagesPerLevel.m_blunt = 0;
                    id.m_itemData.m_shared.m_damagesPerLevel.m_slash = 1f;
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
                    user_item.m_shared.m_damages.m_blunt = 0;
                    user_item.m_shared.m_damages.m_slash = 20;
                    user_item.m_shared.m_damagesPerLevel.m_blunt = 0;
                    user_item.m_shared.m_damagesPerLevel.m_slash = 1f;
                }
            }
        }

    }
}
