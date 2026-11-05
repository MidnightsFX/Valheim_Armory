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
        static GameObject vfx_clubhit;
        static GameObject sfx_clubhit;
        static GameObject sfx_swing_wosh;

        internal class WeaponAttackData
        {
            public Attack primary_attack { get; set; }
            public Attack secondary_attack { get; set; }
        }

        // A vanilla sledge as it was before this mod first changed it. The conversions build on this rather than on an
        // attack written out here, so what a sledge has of its own stays with it: the Thunderblood sledge's chain
        // lightning and damage per missing health, the slam visuals of the iron and bloodgold sledges, the slam's stagger
        // and adrenaline.
        internal class VanillaSledgeData
        {
            public Attack attack { get; set; }
            public Attack secondary_attack { get; set; }
            public EffectList start_effect { get; set; }
            public EffectList trigger_effect { get; set; }
            public EffectList hit_effect { get; set; }
            public EffectList hit_terrain_effect { get; set; }
        }

        static Dictionary<String, WeaponAttackData> OriginalWeaponAttackCache = new Dictionary<String, WeaponAttackData>();
        static Dictionary<String, VanillaSledgeData> VanillaSledgeCache = new Dictionary<String, VanillaSledgeData>();

        // The bloodgold sledge and the two enchanted variants crafted from it. One weapon line: same slam,
        // same stamina, so they convert together and share a single primary attack stamina config.
        private static readonly string[] GoldSledges = { "SledgeGold", "SledgeGold_BloodLightning", "SledgeGold_FrostFire" };

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

        // Taken the first time a sledge is converted, before this mod has changed it, and kept for every later conversion:
        // each menu start and each config change convert again. Null when the game has no such prefab.
        private static VanillaSledgeData VanillaDataFor(string weapon_prefab)
        {
            if (VanillaSledgeCache.TryGetValue(weapon_prefab, out VanillaSledgeData data)) { return data; }

            ItemDrop prefab = PrefabManager.Instance.GetPrefab(weapon_prefab)?.GetComponent<ItemDrop>();
            if (prefab == null)
            {
                Logger.LogWarning($"Could not find {weapon_prefab}, it keeps its own attacks.");
                return null;
            }

            ItemDrop.ItemData.SharedData shared = prefab.m_itemData.m_shared;
            data = new VanillaSledgeData()
            {
                attack = shared.m_attack.Clone(),
                secondary_attack = shared.m_secondaryAttack.Clone(),
                start_effect = shared.m_startEffect,
                trigger_effect = shared.m_triggerEffect,
                hit_effect = shared.m_hitEffect,
                hit_terrain_effect = shared.m_hitTerrainEffect,
            };
            VanillaSledgeCache.Add(weapon_prefab, data);
            return data;
        }

        public static void SetupEffects()
        {
            vfx_clubhit = PrefabManager.Instance.GetPrefab("vfx_clubhit");
            sfx_clubhit = PrefabManager.Instance.GetPrefab("sfx_club_hit");
            sfx_swing_wosh = PrefabManager.Instance.GetPrefab("sfx_battleaxe_swing_wosh");

            Logger.LogDebug($"Set Effect Prefabs: vfx_clubhit:{vfx_clubhit} sfx_clubhit:{sfx_clubhit} sfx_swing_wosh: {sfx_swing_wosh}");
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

        // The swing is this mod's, so it takes over what the sledge's own attack does on a hit.
        private static void CopyOnHit(Attack from, Attack to)
        {
            to.m_damageMultiplierPerMissingHP = from.m_damageMultiplierPerMissingHP;
            to.m_damageMultiplierByTotalHealthMissing = from.m_damageMultiplierByTotalHealthMissing;
            to.m_staminaReturnPerMissingHP = from.m_staminaReturnPerMissingHP;
            to.m_attackHealthReturnHit = from.m_attackHealthReturnHit;
            to.m_attackEitrAdd = from.m_attackEitrAdd;
            to.m_spawnOnHit = from.m_spawnOnHit;
            to.m_spawnOnHitChance = from.m_spawnOnHitChance;
        }

        // The sledge's own attack, as its secondary. A sledge plays its effects from its shared data, which every attack
        // of the weapon would play, so the slam carries them itself.
        private static Attack SetSledgeSmash(VanillaSledgeData vanilla)
        {
            Attack sledge_attack = vanilla.attack.Clone();
            sledge_attack.m_startEffect = vanilla.start_effect;
            sledge_attack.m_triggerEffect = vanilla.trigger_effect;
            sledge_attack.m_hitEffect = vanilla.hit_effect;
            sledge_attack.m_hitTerrainEffect = vanilla.hit_terrain_effect;
            return sledge_attack;
        }

        private static void RestoreVanillaSledge(ItemDrop.ItemData.SharedData shared, VanillaSledgeData vanilla)
        {
            shared.m_attack = vanilla.attack.Clone();
            shared.m_secondaryAttack = vanilla.secondary_attack.Clone();
            shared.m_startEffect = vanilla.start_effect;
            shared.m_triggerEffect = vanilla.trigger_effect;
            shared.m_hitEffect = vanilla.hit_effect;
            shared.m_hitTerrainEffect = vanilla.hit_terrain_effect;
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

        public static void ClearSharedVFX(ItemDrop.ItemData id)
        {
            id.m_shared.m_startEffect = new EffectList();
            id.m_shared.m_triggerEffect = new EffectList();
            id.m_shared.m_hitEffect = new EffectList();
            id.m_shared.m_hitTerrainEffect = new EffectList();
        }

        public static void SledgeToWarhammer(string weapon_prefab, float primary_stamina)
        {
            VanillaSledgeData vanilla = VanillaDataFor(weapon_prefab);
            if (vanilla == null) { return; }
            Attack primary = SetWarhammerPrimaryAttack(primary_stamina);
            CopyOnHit(vanilla.attack, primary);
            Attack secondary = SetSledgeSmash(vanilla);
            EffectList warhammer_primary_effects = SetWarhammerAttackVFX();
            EffectList sledge_swing_effects = SledgeComboSwingSFX();
            // This ensures modifications of clones also
            foreach (ItemDrop id in LiveItemDrops.Find(weapon_prefab))
            {
                id.m_itemData.m_shared.m_attack = primary;
                id.m_itemData.m_shared.m_secondaryAttack = secondary;
                id.m_itemData.m_shared.m_attack.m_hitEffect = warhammer_primary_effects;
                id.m_itemData.m_shared.m_attack.m_trailStartEffect = sledge_swing_effects;
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
                    ClearSharedVFX(user_item);
                }
            }
        }

        public static void ToSledge(string weapon_prefab)
        {
            VanillaSledgeData vanilla = VanillaDataFor(weapon_prefab);
            if (vanilla == null) { return; }
            // This ensures modifications of clones also
            foreach (ItemDrop id in LiveItemDrops.Find(weapon_prefab))
            {
                RestoreVanillaSledge(id.m_itemData.m_shared, vanilla);
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
                    RestoreVanillaSledge(user_item.m_shared, vanilla);
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
                SledgeToWarhammer("SledgeStagbreaker", ValConfig.StagbreakerPrimaryAttackStamina.Value);
                SledgeToWarhammer("SledgeIron", ValConfig.IronSledgePrimaryAttackStamina.Value);
                SledgeToWarhammer("SledgeDemolisher", ValConfig.DemolisherPrimaryAttackStamina.Value);
                foreach (string goldSledge in GoldSledges)
                {
                    SledgeToWarhammer(goldSledge, ValConfig.GoldSledgePrimaryAttackStamina.Value);
                }
            }
        }

        public static void ModifyVanillaHammersToSledges()
        {
            foreach (string sledge in VanillaSledges.Concat(GoldSledges))
            {
                ToSledge(sledge);
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

        // A mod sledge's stats are configured for its swing and its slam, and written to the primary and secondary attack.
        // With the swing turned off the slam is the primary and the secondary is empty, so those writes would change the
        // slam with the swing's values and lose the slam's own. The attacks go back in their own slots for the write. The
        // layout is read from the item, as a drop made since the swap holds its own copy of it, and that drop's attacks
        // become the shared ones, as they do when the config is toggled.
        internal static void WriteModSledgeStat(string weapon_prefab, ItemDrop.ItemData item, Action write)
        {
            ItemDrop.ItemData.SharedData shared = item.m_shared;
            if (ModSledges.Contains(weapon_prefab) == false || string.IsNullOrEmpty(shared.m_secondaryAttack.m_attackAnimation) == false)
            {
                write();
                return;
            }

            WeaponAttackData attacks = CheckForWeaponData(weapon_prefab);
            Attack empty_secondary = shared.m_secondaryAttack;
            shared.m_attack = attacks.primary_attack;
            shared.m_secondaryAttack = attacks.secondary_attack;
            write();
            shared.m_attack = attacks.secondary_attack;
            shared.m_secondaryAttack = empty_secondary;
        }

        // There is no Game at the main menu, where a config edit or leaving a server with other settings lands here.
        public static void OnConfigChangeModifyHammers(object sender, EventArgs e)
        {
            if (Game.instance != null && Game.instance.IsShuttingDown()) { return; }
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
            if (Game.instance != null && Game.instance.IsShuttingDown()) { return; }
            ApplyModHammerConfig();
        }

        // Mod sledges have the swing on their prefabs, so a config that turns it off has to be applied at startup too:
        // no change event fires for a value that was already off when the game started, or that a server also has off.
        public static void ApplyModHammerConfig()
        {
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
