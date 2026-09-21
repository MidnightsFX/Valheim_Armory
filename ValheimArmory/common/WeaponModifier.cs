using Jotunn.Managers;
using SoftReferenceableAssets;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using static EffectList;

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
        static GameObject sfx_swing_wosh;

        internal class WeaponAttackData
        {
            public Attack primary_attack { get; set; }
            public Attack secondary_attack { get; set; }
        }

        static Dictionary<String, WeaponAttackData> OriginalWeaponAttackCache = new Dictionary<String, WeaponAttackData>();

        // The bloodgold sledge and the two enchanted variants crafted from it. One weapon line: same slam,
        // same stamina, so they convert together and share a single primary attack stamina config.
        private static readonly string[] GoldSledges = { "SledgeGold", "SledgeGold_BloodLightning", "SledgeGold_FrostFire" };
        private const float GoldSledgeSlamStamina = 28f;

        // This mod's sledges, the ones ModHammersHavePrimaryAttack switches between warhammer and sledge.
        private static readonly string[] ModSledges = {
            "VAflametal_sledge_nature", "VAflametal_sledge_lightning", "VAflametal_sledge_blood", "VAflametal_sledge",
            "VAblackmetal_sledge", "VAElderHammer", "VABronzeSledge", "VABonemassWarhammer", "VASilverSledge"
        };

        // The vanilla sledges this mod converts, apart from the bloodgold line in GoldSledges.
        private static readonly string[] VanillaSledges = { "SledgeStagbreaker", "SledgeIron", "SledgeDemolisher" };

        // Every sledge the SledgeStance config drives. A set: LiveItemDrops tests each live drop against it.
        private static readonly HashSet<string> StanceSledges =
            new HashSet<string>(ModSledges.Concat(VanillaSledges).Concat(GoldSledges));

        internal static WeaponAttackData CheckForWeaponData(string weapon_name)
        {
            if (OriginalWeaponAttackCache.ContainsKey(weapon_name))
            {
                return OriginalWeaponAttackCache[weapon_name];
            }

            foreach (ItemDrop id in LiveItemDrops.Find(weapon_name))
            {
                if (id.m_itemData.m_shared.m_attack.m_attackAnimation != null && id.m_itemData.m_shared.m_secondaryAttack.m_attackAnimation != null)
                {
                    // We just need to at this one
                    OriginalWeaponAttackCache.Add(weapon_name, new WeaponAttackData() { primary_attack = id.m_itemData.m_shared.m_attack, secondary_attack = id.m_itemData.m_shared.m_secondaryAttack });
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
            sfx_swing_wosh = PrefabManager.Instance.GetPrefab("sfx_battleaxe_swing_wosh");

            Logger.LogDebug($"Set Effect Prefabs: vfx_sledge_hit:{vfx_sledge_hit} fx_camshake:{fx_camshake} sfx_sledge_hit:{sfx_sledge_hit} sfx_sledge_swing:{sfx_sledge_swing} fx_demolisher_hit:{fx_demolisher_hit} vfx_clubhit:{vfx_clubhit} sfx_clubhit:{sfx_clubhit} sfx_swing_wosh: {sfx_swing_wosh}");
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

        // stagger_multiplier defaults to the vanilla slam value shared by every sledge except the
        // stagbreaker, which staggers for 1.
        public static Attack SetSledgeSmash(float stamina_cost = 14f, float stagger_multiplier = 2f)
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
            sledge_attack.m_staggerMultiplier = stagger_multiplier;
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

        public static EffectList SledgeComboSwingSFX()
        {
            EffectData[] sledge_swing_effects = { new EffectData() { m_prefab = sfx_swing_wosh, m_enabled = true, m_variant = -1 } };
            return new EffectList { m_effectPrefabs = sledge_swing_effects }; ;
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

        public static void SledgeToWarhammer(string weapon_prefab, float primary_stamina, float secondary_stamina, float stagger_multiplier = 2f)
        {
            bool demolisher = false;
            if (weapon_prefab == "SledgeDemolisher") { demolisher = true; }
            Attack primary = SetWarhammerPrimaryAttack(primary_stamina);
            Attack secondary = SetSledgeSmash(secondary_stamina, stagger_multiplier);
            EffectList warhammer_primary_effects = SetWarhammerAttackVFX();
            EffectList sledge_trigger_effects = SledgeTriggerEffects(demolisher);
            EffectList sledge_start_effects = SledgeStartEffects();
            EffectList sledge_swing_effects = SledgeComboSwingSFX();
            // This ensures modifications of clones also
            foreach (ItemDrop id in LiveItemDrops.Find(weapon_prefab))
            {
                id.m_itemData.m_shared.m_attack = primary;
                id.m_itemData.m_shared.m_secondaryAttack = secondary;
                id.m_itemData.m_shared.m_attack.m_hitEffect = warhammer_primary_effects;
                id.m_itemData.m_shared.m_attack.m_trailStartEffect = sledge_swing_effects;
                id.m_itemData.m_shared.m_secondaryAttack.m_triggerEffect = sledge_trigger_effects;
                id.m_itemData.m_shared.m_secondaryAttack.m_startEffect = sledge_start_effects;
                ClearSharedVFX(id.m_itemData);
            }

            if (Player.m_localPlayer != null)
            {
                Logger.LogDebug($"Modifying items within the players inventory.");
                // Update all instances that are in the backpack
                foreach (ItemDrop.ItemData user_item in Player.m_localPlayer.m_inventory.GetAllItems())
                {
                    if (user_item == null) { continue; }
                    if (user_item.m_dropPrefab.name != weapon_prefab) { continue; }

                    Logger.LogDebug($"{user_item.m_shared.m_name} found in the players backpack, updating.");
                    user_item.m_shared.m_attack = primary;
                    user_item.m_shared.m_secondaryAttack = secondary;
                    user_item.m_shared.m_attack.m_hitEffect = warhammer_primary_effects;
                    user_item.m_shared.m_attack.m_trailStartEffect = sledge_swing_effects;
                    user_item.m_shared.m_secondaryAttack.m_triggerEffect = sledge_trigger_effects;
                    user_item.m_shared.m_secondaryAttack.m_startEffect = sledge_start_effects;
                    ClearSharedVFX(user_item);
                }
            }
        }

        public static void ToSledge(string weapon_prefab, float sledge_stamina, float stagger_multiplier = 2f)
        {
            bool demolisher = false;
            if (weapon_prefab == "SledgeDemolisher") { demolisher = true; }
            Attack sledgesmash = SetSledgeSmash(sledge_stamina, stagger_multiplier);
            EffectList sledge_trigger_effects = SledgeTriggerEffects(demolisher);
            EffectList sledge_start_effects = SledgeStartEffects();
            // This ensures modifications of clones also
            foreach (ItemDrop id in LiveItemDrops.Find(weapon_prefab))
            {
                id.m_itemData.m_shared.m_attack = sledgesmash;
                ClearSharedVFX(id.m_itemData);
                ClearSecondaryAttack(id.m_itemData);
                id.m_itemData.m_shared.m_triggerEffect = sledge_trigger_effects;
                id.m_itemData.m_shared.m_startEffect = sledge_start_effects;
                id.m_itemData.m_shared.m_attack.m_trailStartEffect = null;
            }

            if (Player.m_localPlayer != null)
            {
                Logger.LogDebug($"Modifying items within the players inventory.");
                // Update all instances that are in the backpack
                foreach (ItemDrop.ItemData user_item in Player.m_localPlayer.m_inventory.GetAllItems())
                {
                    if (user_item == null) { continue; }
                    if (user_item.m_dropPrefab.name != weapon_prefab) { continue; }

                    Logger.LogDebug($"{user_item.m_shared.m_name} found in the players backpack, updating.");
                    user_item.m_shared.m_attack = sledgesmash;
                    ClearSharedVFX(user_item);
                    ClearSecondaryAttack(user_item);
                    user_item.m_shared.m_triggerEffect = sledge_trigger_effects;
                    user_item.m_shared.m_startEffect = sledge_start_effects;
                    user_item.m_shared.m_attack.m_trailStartEffect = null;
                }
            }
        }

        public static void ModifyStamina(string weapon_prefab, float sledge_stamina)
        {
            // This ensures modifications of clones also
            foreach (ItemDrop id in LiveItemDrops.Find(weapon_prefab))
            {
                id.m_itemData.m_shared.m_attack.m_attackStamina = sledge_stamina;
            }

            if (Player.m_localPlayer != null)
            {
                Logger.LogDebug($"Modifying items within the players inventory.");
                // Update all instances that are in the backpack
                foreach (ItemDrop.ItemData user_item in Player.m_localPlayer.m_inventory.GetAllItems())
                {
                    if (user_item == null) { continue; }
                    if (user_item.m_dropPrefab.name != weapon_prefab) { continue; }
                    Logger.LogDebug($"{user_item.m_shared.m_name} found in the players backpack, updating.");
                    user_item.m_shared.m_attack.m_attackStamina = sledge_stamina;
                }
            }
        }


        public static void SetWeaponPrimaryAndSecondary(string weapon_prefab, Attack primary, Attack secondary)
        {
            // This ensures modifications of clones also
            foreach (ItemDrop id in LiveItemDrops.Find(weapon_prefab))
            {
                id.m_itemData.m_shared.m_attack = primary;
                id.m_itemData.m_shared.m_secondaryAttack = secondary;
            }

            if (Player.m_localPlayer != null)
            {
                Logger.LogDebug($"Modifying items within the players inventory.");
                // Update all instances that are in the backpack
                foreach (ItemDrop.ItemData user_item in Player.m_localPlayer.m_inventory.GetAllItems())
                {
                    if (user_item == null) { continue; }
                    if (user_item.m_dropPrefab.name != weapon_prefab) { continue; }

                    Logger.LogDebug($"{user_item.m_shared.m_name} found in the players backpack, updating.");
                    user_item.m_shared.m_attack = primary;
                    user_item.m_shared.m_secondaryAttack = secondary;
                }
            }
        }

        public static void ModifyVanillaHammersToWarhammers()
        {
            if (ValConfig.VanillaHammersHavePrimaryAttack.Value)
            {
                SledgeToWarhammer("SledgeStagbreaker", ValConfig.StagbreakerPrimaryAttackStamina.Value, 12, stagger_multiplier: 1f);
                SledgeToWarhammer("SledgeIron", ValConfig.IronSledgePrimaryAttackStamina.Value, 20);
                SledgeToWarhammer("SledgeDemolisher", ValConfig.DemolisherPrimaryAttackStamina.Value, 28);
                foreach (string goldSledge in GoldSledges)
                {
                    SledgeToWarhammer(goldSledge, ValConfig.GoldSledgePrimaryAttackStamina.Value, GoldSledgeSlamStamina);
                }
            }
        }

        public static void ModifyVanillaHammersToSledges()
        {
            ToSledge("SledgeStagbreaker", 12, stagger_multiplier: 1f);
            ToSledge("SledgeIron", 20);
            ToSledge("SledgeDemolisher", 28);
            foreach (string goldSledge in GoldSledges)
            {
                ToSledge(goldSledge, GoldSledgeSlamStamina);
            }
        }

        public static void ModifyModHammersToSledges()
        {
            foreach (string sledge in ModSledges)
            {
                SetWeaponPrimaryAndSecondary(sledge, CheckForWeaponData(sledge).secondary_attack, new Attack());
            }
        }

        public static void ModifyModHammersToWarhammers()
        {
            foreach (string sledge in ModSledges)
            {
                SetWeaponPrimaryAndSecondary(sledge, CheckForWeaponData(sledge).primary_attack, CheckForWeaponData(sledge).secondary_attack);
            }
        }

        public static void OnConfigChangeModifyHammers(object sender, EventArgs e)
        {
            if (Game.instance.IsShuttingDown()) { return; }
            if (ValConfig.VanillaHammersHavePrimaryAttack.Value)
            {
                ModifyVanillaHammersToWarhammers();
            }
            else
            {
                ModifyVanillaHammersToSledges();
            }
        }

        public static void OnConfigChangeModifyModHammers(object sender, EventArgs e)
        {
            if (Game.instance.IsShuttingDown()) { return; }
            if (ValConfig.ModHammersHavePrimaryAttack.Value)
            {
                ModifyModHammersToWarhammers();
            }
            else
            {
                ModifyModHammersToSledges();
            }
        }

        public static void OnConfigStagbreakerValueChanged(object sender, EventArgs e)
        {
            if (ValConfig.VanillaHammersHavePrimaryAttack.Value)
            {
                ModifyStamina("SledgeStagbreaker", ValConfig.StagbreakerPrimaryAttackStamina.Value);
            }
        }

        public static void OnConfigIronSledgeValueChanged(object sender, EventArgs e)
        {
            if (ValConfig.VanillaHammersHavePrimaryAttack.Value)
            {
                ModifyStamina("SledgeIron", ValConfig.IronSledgePrimaryAttackStamina.Value);
            }
        }

        public static void OnConfigDemolisherValueChanged(object sender, EventArgs e)
        {
            if (ValConfig.VanillaHammersHavePrimaryAttack.Value)
            {
                ModifyStamina("SledgeDemolisher", ValConfig.DemolisherPrimaryAttackStamina.Value);
            }
        }

        // Applies the configured idle stance to every sledge, vanilla and modded. Inventory items are clones
        // that kept the prefab's m_shared, so the prefab covers those; each live world drop carries its own
        // copy, which is what LiveItemDrops walks.
        public static void ApplySledgeStance()
        {
            ItemDrop.ItemData.AnimationState stance = ValConfig.SledgeStance.Value == "Sledge"
                ? ItemDrop.ItemData.AnimationState.TwoHandedClub
                : ItemDrop.ItemData.AnimationState.TwoHandedAxe;
            Logger.LogDebug($"Setting the idle stance of {StanceSledges.Count} sledges to {stance}.");

            LiveItemDrops.ForEach(StanceSledges, (_, drop) => drop.m_itemData.m_shared.m_animationState = stance);

            if (Player.m_localPlayer == null) { return; }
            foreach (ItemDrop.ItemData user_item in Player.m_localPlayer.m_inventory.GetAllItems())
            {
                if (user_item == null || user_item.m_dropPrefab == null) { continue; }
                if (StanceSledges.Contains(user_item.m_dropPrefab.name) == false) { continue; }
                user_item.m_shared.m_animationState = stance;
            }
            RefreshLocalPlayerStance();
        }

        // The stance is only pushed to the animator when equipment is set up, so a sledge that is already in
        // hand keeps the old one until then. Re-running that is idempotent: it reapplies the visible
        // equipment, equipment status effects, build piece mode and the animation state.
        private static void RefreshLocalPlayerStance()
        {
            Player player = Player.m_localPlayer;
            if (player == null || player.m_nview == null || player.m_nview.GetZDO() == null) { return; }
            player.SetupEquipment();
        }

        public static void OnConfigSledgeStanceChanged(object sender, EventArgs e)
        {
            if (Game.instance != null && Game.instance.IsShuttingDown()) { return; }
            ApplySledgeStance();
        }

        public static void OnConfigGoldSledgeValueChanged(object sender, EventArgs e)
        {
            if (ValConfig.VanillaHammersHavePrimaryAttack.Value)
            {
                foreach (string goldSledge in GoldSledges)
                {
                    ModifyStamina(goldSledge, ValConfig.GoldSledgePrimaryAttackStamina.Value);
                }
            }
        }

        public static void ModifyVanillaKnife()
        {
            if (ValConfig.VanillaAbyssalKnifeBluntDamageConvert.Value)
            {
                KnifeToAbyssal("KnifeChitin");
            }
        }

        public static void OnConfigChangeModifyVanillaKnife(object sender, EventArgs e)
        {
            if (ValConfig.VanillaAbyssalKnifeBluntDamageConvert.Value)
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
            if (ValConfig.VanillaAbyssalKnifeBluntDamageConvert.Value)
            {
                KnifeToAbyssal("KnifeChitin");
            }
        }

        public static void KnifeToAbyssal(string weapon_prefab)
        {
            // This ensures modifications of clones also
            foreach (ItemDrop id in LiveItemDrops.Find(weapon_prefab))
            {
                id.m_itemData.m_shared.m_damages.m_slash = 0;
                id.m_itemData.m_shared.m_damages.m_blunt = ValConfig.AbyssalKnifeBlunt.Value;
                id.m_itemData.m_shared.m_damagesPerLevel.m_slash = 0;
                id.m_itemData.m_shared.m_damagesPerLevel.m_blunt = ValConfig.AbyssalKnifeBluntPerLevel.Value;
            }

            if (Player.m_localPlayer != null)
            {
                Logger.LogDebug($"Modifying items within the players inventory.");
                // Update all instances that are in the backpack
                foreach (ItemDrop.ItemData user_item in Player.m_localPlayer.m_inventory.GetAllItems())
                {
                    if (user_item == null) { continue; }
                    if (user_item.m_dropPrefab.name != weapon_prefab) { continue; }

                    Logger.LogDebug($"{user_item.m_shared.m_name} found in the players backpack, updating.");
                    user_item.m_shared.m_damages.m_slash = 0;
                    user_item.m_shared.m_damages.m_blunt = ValConfig.AbyssalKnifeBlunt.Value;
                    user_item.m_shared.m_damagesPerLevel.m_slash = 0;
                    user_item.m_shared.m_damagesPerLevel.m_blunt = ValConfig.AbyssalKnifeBluntPerLevel.Value;
                }
            }
        }

        public static void KnifeToVanilla(string weapon_prefab)
        {
            // This ensures modifications of clones also
            foreach (ItemDrop id in LiveItemDrops.Find(weapon_prefab))
            {
                id.m_itemData.m_shared.m_damages.m_blunt = 0;
                id.m_itemData.m_shared.m_damages.m_slash = 20;
                id.m_itemData.m_shared.m_damagesPerLevel.m_blunt = 0;
                id.m_itemData.m_shared.m_damagesPerLevel.m_slash = 1f;
            }

            if (Player.m_localPlayer != null)
            {
                Logger.LogDebug($"Modifying items within the players inventory.");
                // Update all instances that are in the backpack
                foreach (ItemDrop.ItemData user_item in Player.m_localPlayer.m_inventory.GetAllItems())
                {
                    if (user_item == null) { continue; }
                    if (user_item.m_dropPrefab.name != weapon_prefab) { continue; }

                    Logger.LogDebug($"{user_item.m_shared.m_name} found in the players backpack, updating.");
                    user_item.m_shared.m_damages.m_blunt = 0;
                    user_item.m_shared.m_damages.m_slash = 20;
                    user_item.m_shared.m_damagesPerLevel.m_blunt = 0;
                    user_item.m_shared.m_damagesPerLevel.m_slash = 1f;
                }
            }
        }

        public static void OnConfigChangeModifyVanillaFlintAxe(object sender, EventArgs e)
        {
            ToggleVanillaFlintAxe();
        }

        public static void ToggleVanillaFlintAxe()
        {
            if (ObjectDB.m_instance == null) { return; }
            int recipeindex = RecipeIndexForPrefab("AxeFlint");
            if (recipeindex == -1) { return; }
            ObjectDB.instance.m_recipes[recipeindex].m_enabled = ValConfig.EnableVanillaFlintAxe.Value;
        }

        public static void OnConfigChangeModifyVanillaFlintSpear(object sender, EventArgs e)
        {
            ToggleVanillaFlintSpear();
        }

        public static void ToggleVanillaFlintSpear()
        {
            if (ObjectDB.m_instance == null) { return; }
            int recipeindex = RecipeIndexForPrefab("SpearFlint");
            if (recipeindex == -1) { return; }
            ObjectDB.instance.m_recipes[recipeindex].m_enabled = ValConfig.EnableVanillaSpear.Value;
        }

        public static int RecipeIndexForPrefab(string prefab)
        {
            return ObjectDB.instance.m_recipes.FindIndex(m => m.m_item != null && m.m_item.name == prefab);
        }
    }
}
