
using Jotunn.Managers;
using System;
using Logger = Jotunn.Logger;
using UnityEngine;
using Jotunn.Entities;
using Jotunn.Configs;

namespace ValheimAdditions
{
    class ValheimAdditionsItems
    {
        // constructor, add all items on init
        public ValheimAdditionsItems(AssetBundle EmbeddedResourceBundle, ValheimAdditionsConfig cfg)
        {
            if (cfg.EnableDebugMode.Value == true)
            {
                Logger.LogInfo("Loading Items.");
            }

            AddGreenMetalArrowItem(EmbeddedResourceBundle, cfg);
            AddBoneArrowItem(EmbeddedResourceBundle, cfg);
            AddSurtlingFireArrowItem(EmbeddedResourceBundle, cfg);
            AddAncientWoodArrowItem(EmbeddedResourceBundle, cfg);
            AddChitinArrowItem(EmbeddedResourceBundle, cfg);
            AddWoodBoltItem(EmbeddedResourceBundle, cfg);
            AddBronzeCrossbowItem(EmbeddedResourceBundle, cfg);
            AddAbyssalSwordItem(EmbeddedResourceBundle, cfg);
            AddSerpentBucklerItem(EmbeddedResourceBundle, cfg);
            AddHeavyChitinAtgeirItem(EmbeddedResourceBundle, cfg);
            AddAntlerAtgeirItem(EmbeddedResourceBundle, cfg);
            AddBlackmetalSledgeItem(EmbeddedResourceBundle, cfg);

            // Not added
            // AddThunderHammerItem(EmbeddedResourceBundle, cfg);
        }

        /// <summary>
        ///  helper to add a recipe
        /// </summary>
        /// <param name="ingredients"> List of crafting ingrediants for the recipe eg: MockRequirement.Create("LeatherScraps", 3) </param>
        /// <param name="prefab"> Prefabricated object eg: GameObject </param>
        /// <param name="icon"> List of sprites to be used as icons </param>
        /// <param name="ingredients"> List of crafting requirements </param>
        /// <param name="crafted_at"> The crafting station used for the recipe: forge, piece_workbench </param>
        /// <param name="amount"> Int amount recipe will produce </param>
        private void AddRecipeForAsset(String name, GameObject prefab, Sprite[] icon, RequirementConfig[] ingredients, String crafted_at, Int16 amount)
        {
            Logger.LogDebug($"Attempting to load {name} Item & Recipe.");
            // Should probably add validation to the input strings here
            try
            {
                var customItem = new CustomItem(prefab, fixReference: true,
                    new ItemConfig
                    {
                        Amount = amount,
                        Requirements = ingredients,
                        CraftingStation = crafted_at,
                        Icons = icon
                    });
                ItemManager.Instance.AddItem(customItem);

                Logger.LogInfo($"{name} Item & Recipe Loaded.");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error while adding Recipe_{name}: {ex.Message}");
            }
        }

        // Helper to load prefabs, safety checks
        private GameObject LoadPrefab(AssetBundle bundle, string to_load)
        {
            GameObject prefab = null;
            try
            {
                prefab = bundle.LoadAsset<GameObject>(to_load);
            } catch (Exception ex)
            {
                Logger.LogError($"Error while loading Prefab: {to_load}: {ex.Message}");
            }
            return prefab;

        }

        // Helper to load sprites, safety checks
        private Sprite LoadSprite(AssetBundle bundle, string to_load)
        {
            to_load = to_load.ToLower();
            Sprite sprite = null;
            try
            {
                sprite = bundle.LoadAsset<Sprite>(to_load);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error while loading Sprite: {to_load}: {ex.Message}");
            }
            return sprite;

        }

        // GreenMetal Arrow Enablement, recipe and applied configuration
        private void AddGreenMetalArrowItem(AssetBundle EmbeddedResourceBundle, ValheimAdditionsConfig cfg)
        {
            // GreenMetal Arrow
            if (cfg.GreenMetalArrowConfigEnabled.Value == false) {
                if (cfg.EnableDebugMode.Value == true) { Logger.LogWarning("GreenMetal Arrow not loaded."); }
            } else {
                Logger.LogInfo("GreenMetal Arrow Loading assets.");
                GameObject prefab = LoadPrefab(EmbeddedResourceBundle, "Assets/Custom/ArrowGreenMetal.prefab");
                Sprite sprite = LoadSprite(EmbeddedResourceBundle, "Assets/Custom/Icons/arrow_greenmetal.png");

                // Modify any configurable values before adding the object
                var item = prefab.GetComponent<ItemDrop>()?.m_itemData;
                item.m_shared.m_damages.m_blunt = cfg.GreenMetalArrowBluntDamage.Value;
                item.m_shared.m_damages.m_pierce = cfg.GreenMetalArrowPierceDamage.Value;

                // Add the recipe with helper
                AddRecipeForAsset(
                    "VAGreenMetal_Arrow",
                    prefab,
                    new[] { sprite },
                    new[]
                    {
                        new RequirementConfig { Item = "Feathers", Amount = 1 },
                        new RequirementConfig { Item = "Wood", Amount = 6 },
                        new RequirementConfig { Item = "BlackMetal", Amount = 1 },
                    },
                    "forge",
                    20
                 );
            }
        }

        // Bone Arrow Enablement, recipe and applied configuration
        private void AddBoneArrowItem(AssetBundle EmbeddedResourceBundle, ValheimAdditionsConfig cfg)
        {
            // Bone Arrow
            if (cfg.BoneArrowConfigEnabled.Value == false) { 
                if (cfg.EnableDebugMode.Value == true) { Logger.LogWarning("Bone Arrow not loaded."); }
            } else {
                GameObject prefab = LoadPrefab(EmbeddedResourceBundle, "Assets/Custom/ArrowBone.prefab");
                Sprite sprite = LoadSprite(EmbeddedResourceBundle, "Assets/Custom/Icons/bone_arrow.png");

                // Modify any configurable values before adding the object
                var item = prefab.GetComponent<ItemDrop>()?.m_itemData;
                item.m_shared.m_damages.m_pierce = cfg.BoneArrowPierceDamage.Value;

                // Add recipe
                AddRecipeForAsset(
                    "VABone_Arrow",
                    prefab,
                    new[] { sprite },
                    new[]
                    {
                        new RequirementConfig { Item = "Feathers", Amount = 1 },
                        new RequirementConfig { Item = "BoneFragments", Amount = 8 },
                    },
                    "piece_workbench",
                    20
                 );
            }
        }

        // Surtling Fire Arrow
        private void AddSurtlingFireArrowItem(AssetBundle EmbeddedResourceBundle, ValheimAdditionsConfig cfg)
        {
            if (cfg.SurtlingFireArrowConfigEnabled.Value == false) {
                if (cfg.EnableDebugMode.Value == true) { Logger.LogWarning("Surtling Fire Arrow not loaded."); }
            } else {
                GameObject prefab = LoadPrefab(EmbeddedResourceBundle, "assets/custom/arrow_surtling_fire.prefab");
                Sprite sprite = LoadSprite(EmbeddedResourceBundle, "assets/custom/icons/surtlingcore_arrow.png");

                // Modify any configurable values before adding the object
                var item = prefab.GetComponent<ItemDrop>()?.m_itemData;
                item.m_shared.m_damages.m_pierce = cfg.SurtlingFireArrowPierceDamage.Value;
                item.m_shared.m_damages.m_fire = cfg.SurtlingFireArrowFireDamage.Value;

                // Add recipe
                AddRecipeForAsset(
                    "VASurtlingCore_Arrow",
                    prefab,
                    new[] { sprite },
                    new[]
                    {
                        new RequirementConfig { Item = "Feathers", Amount = 2 },
                        new RequirementConfig { Item = "Wood", Amount = 10 },
                        new RequirementConfig { Item = "Obsidian", Amount = 4 },
                        new RequirementConfig { Item = "SurtlingCore", Amount = 1 },
                    },
                    "forge",
                    50
                 );
            }
        }

        // Ancient Wood Arrow Enablement, recipe and applied configuration
        private void AddAncientWoodArrowItem(AssetBundle EmbeddedResourceBundle, ValheimAdditionsConfig cfg)
        {
            if (cfg.AncientWoodArrowConfigEnabled.Value == false) {
                if (cfg.EnableDebugMode.Value == true) { Logger.LogWarning("Ancient Wood Arrow not loaded."); }
            } else {
                GameObject prefab = LoadPrefab(EmbeddedResourceBundle, "assets/custom/arrowancient.prefab");
                Sprite sprite = LoadSprite(EmbeddedResourceBundle, "Assets/Custom/Icons/ancient_arrow.png");

                // Modify any configurable values before adding the object
                var item = prefab.GetComponent<ItemDrop>()?.m_itemData;
                item.m_shared.m_damages.m_pierce = cfg.AncientWoodArrowPierceDamage.Value;

                // Add recipe
                AddRecipeForAsset(
                    "VAAncient_Arrow",
                    prefab,
                    new[] { sprite },
                    new[]
                    {
                        new RequirementConfig { Item = "Feathers", Amount = 1 },
                        new RequirementConfig { Item = "ElderBark", Amount = 8 },
                    },
                    "piece_workbench",
                    20
                 );
            }
        }

        // Chitin Arrow Enablement, recipe and applied configuration
        private void AddChitinArrowItem(AssetBundle EmbeddedResourceBundle, ValheimAdditionsConfig cfg)
        {
            if (cfg.ChitinArrowConfigEnabled.Value == false) {
                if (cfg.EnableDebugMode.Value == true) { Logger.LogWarning("Chitin Arrow not loaded."); }
            } else {
                GameObject prefab = LoadPrefab(EmbeddedResourceBundle, "assets/custom/chitinarrow.prefab");
                Sprite sprite = LoadSprite(EmbeddedResourceBundle, "Assets/Custom/Icons/arrow_chitin.png");

                // Modify any configurable values before adding the object
                var item = prefab.GetComponent<ItemDrop>()?.m_itemData;
                item.m_shared.m_damages.m_pierce = cfg.ChitinArrowPierceDamage.Value;
                item.m_shared.m_damages.m_slash = cfg.ChitinArrowSlashDamage.Value;

                // Add recipe
                AddRecipeForAsset(
                    "VAChitin_Arrow",
                    prefab,
                    new[] { sprite },
                    new[]
                    {
                        new RequirementConfig { Item = "Feathers", Amount = 1 },
                        new RequirementConfig { Item = "Wood", Amount = 8 },
                        new RequirementConfig { Item = "Chitin", Amount = 3 },
                    },
                    "piece_workbench",
                    20
                 );
            }
        }

        // Wood Bolt Enablement, recipe and applied configuration
        private void AddWoodBoltItem(AssetBundle EmbeddedResourceBundle, ValheimAdditionsConfig cfg)
        {
            if (cfg.WoodBoltConfigEnabled.Value == false) {
                if (cfg.EnableDebugMode.Value == true) { Logger.LogWarning("Wood Bolt not loaded."); }
            } else {
                GameObject prefab = LoadPrefab(EmbeddedResourceBundle, "Assets/Custom/BoltWood.prefab");
                Sprite sprite = LoadSprite(EmbeddedResourceBundle, "Assets/Custom/Icons/bolt_wood.png");

                // Modify any configurable values before adding the object
                var item = prefab.GetComponent<ItemDrop>()?.m_itemData;
                item.m_shared.m_damages.m_pierce = cfg.WoodBoltPierceDamage.Value;

                // Add recipe
                AddRecipeForAsset(
                    "VAWood_Bolt",
                    prefab,
                    new[] { sprite },
                    new[]
                    {
                        new RequirementConfig { Item = "Wood", Amount = 8 },
                    },
                    "piece_artisanstation",
                    20
                 );
            }
        }

        // Bronze Crossbow Enablement, recipe and applied configuration
        private void AddBronzeCrossbowItem(AssetBundle EmbeddedResourceBundle, ValheimAdditionsConfig cfg)
        {
            if (cfg.BronzeCrossbowConfigEnabled.Value == false) {
                if (cfg.EnableDebugMode.Value == true) { Logger.LogWarning("Bronze Crossbow not loaded."); }
            } else {
                GameObject prefab = LoadPrefab(EmbeddedResourceBundle, "Assets/Custom/CrossbowBronze.prefab");
                Sprite sprite = LoadSprite(EmbeddedResourceBundle, "Assets/Custom/Icons/bronze_crossbow.png");

                // Modify any configurable values before adding the object
                var item = prefab.GetComponent<ItemDrop>()?.m_itemData;
                item.m_shared.m_damages.m_pierce = cfg.BronzeCrossbowPierceDamage.Value;

                // Add recipe
                AddRecipeForAsset(
                    "VABronze_Crossbow",
                    prefab,
                    new[] { sprite },
                    new[]
                    {
                        new RequirementConfig { Item = "FineWood", Amount = 6, AmountPerLevel = 8 },
                        new RequirementConfig { Item = "Bronze", Amount = 4, AmountPerLevel = 2 },
                        new RequirementConfig { Item = "Guck", Amount = 2 },
                        new RequirementConfig { Item = "Chain", Amount = 1 },
                    },
                    "piece_artisanstation",
                    1
                 );
            }
        }

        // Abyssal Sword
        private void AddAbyssalSwordItem(AssetBundle EmbeddedResourceBundle, ValheimAdditionsConfig cfg)
        {
            
            if (cfg.AbyssalSwordConfigEnabled.Value == false) {
                if (cfg.EnableDebugMode.Value == true) { Logger.LogWarning("Abyssal Sword not loaded."); }
            } else {
                GameObject prefab = LoadPrefab(EmbeddedResourceBundle, "Assets/Custom/SwordChitin.prefab");
                Sprite sprite = LoadSprite(EmbeddedResourceBundle, "Assets/Custom/Icons/chitin_sword.png");

                // Modify any configurable values before adding the object
                var item = prefab.GetComponent<ItemDrop>()?.m_itemData;
                item.m_shared.m_damages.m_blunt = cfg.AbyssalSwordBluntDamage.Value;
                item.m_shared.m_damages.m_slash = cfg.AbyssalSwordSlashDamage.Value;

                // Add recipe & item
                AddRecipeForAsset(
                    "VAChitin_sword",
                    prefab,
                    new[] { sprite },
                    new[]
                    {
                        new RequirementConfig { Item = "LeatherScraps", Amount = 3, AmountPerLevel = 2 },
                        new RequirementConfig { Item = "Bronze", Amount = 1, AmountPerLevel = 1 },
                        new RequirementConfig { Item = "Chitin", Amount = 8, AmountPerLevel = 4 },
                    },
                    "forge",
                    1
                 );
            }
        }

        // Royal Abyssal Atgeir
        private void AddHeavyChitinAtgeirItem(AssetBundle EmbeddedResourceBundle, ValheimAdditionsConfig cfg)
        {
            
            if (cfg.RoyalAbyssalAtgeirConfigEnabled.Value == false) { 
                if (cfg.EnableDebugMode.Value == true) { Logger.LogWarning("Royal Abyssal Atgeir not loaded."); }
            } else {
                GameObject prefab = EmbeddedResourceBundle.LoadAsset<GameObject>("Assets/Custom/atgeirchitin.prefab");
                Sprite icon = EmbeddedResourceBundle.LoadAsset<Sprite>("Assets/Custom/Icons/chitin_heavy_atgeir_small.png");

                // Modify any configurable values before adding the object
                var item = prefab.GetComponent<ItemDrop>()?.m_itemData;
                item.m_shared.m_damages.m_pierce = cfg.RoyalAbyssalAtgeirPierceDamage.Value;
                item.m_shared.m_damages.m_slash = cfg.RoyalAbyssalAtgeirSlashDamage.Value;
                item.m_shared.m_damages.m_spirit = cfg.RoyalAbyssalAtgeirSpiritDamage.Value;

                // Add recipe & item
                AddRecipeForAsset(
                    "VARoyal_Atgeir",
                    prefab,
                    new[] { icon },
                    new[]
                    {
                        new RequirementConfig { Item = "FineWood", Amount = 4, AmountPerLevel = 2 },
                        new RequirementConfig { Item = "Silver", Amount = 4, AmountPerLevel = 2 },
                        new RequirementConfig { Item = "Chitin", Amount = 8, AmountPerLevel = 4 },
                        new RequirementConfig { Item = "JuteRed", Amount = 6, AmountPerLevel = 4 },
                    },
                    "forge",
                    1
                 );
            }
        }

        private void AddAntlerAtgeirItem(AssetBundle EmbeddedResourceBundle, ValheimAdditionsConfig cfg)
        {
            if (cfg.AntlerAtgeirConfigEnabled.Value == false) {
                if (cfg.EnableDebugMode.Value == true) { Logger.LogWarning("Antler Atgeir not loaded."); }
            } else {
                GameObject prefab = LoadPrefab(EmbeddedResourceBundle, $"Assets/Custom/atgeir_antler{cfg.AntlerAtgeirModel.Value}.prefab");
                Sprite sprite = LoadSprite(EmbeddedResourceBundle, $"Assets/Custom/Icons/antler_atgeir{cfg.AntlerAtgeirModel.Value}_large.png");

                // Modify any configurable values before adding the object
                var item = prefab.GetComponent<ItemDrop>()?.m_itemData;
                item.m_shared.m_damages.m_pierce = cfg.AntlerAtgeirPierceDamage.Value;

                // Add recipe & item
                AddRecipeForAsset(
                    "VAAntler_atgeir",
                    prefab,
                    new[] { sprite },
                    new[]
                    {
                        new RequirementConfig { Item = "Wood", Amount = 8, AmountPerLevel = 6 },
                        new RequirementConfig { Item = "HardAntler", Amount = 3, AmountPerLevel = 2 },
                        new RequirementConfig { Item = "Resin", Amount = 4, AmountPerLevel = 2 },
                    },
                    "piece_workbench",
                    1
                 );
            }
        }

        private void AddBlackmetalSledgeItem(AssetBundle EmbeddedResourceBundle, ValheimAdditionsConfig cfg)
        {
            if (cfg.AntlerAtgeirConfigEnabled.Value == false)
            {
                if (cfg.EnableDebugMode.Value == true) { Logger.LogWarning("Blackmetal Sledge not loaded."); }
            }
            else
            {
                GameObject prefab = LoadPrefab(EmbeddedResourceBundle, $"Assets/Custom/blackmetal_sledge.prefab");
                Sprite sprite = LoadSprite(EmbeddedResourceBundle, $"Assets/Custom/Icons/blackmetal_hammer.png");

                // Modify any configurable values before adding the object
                var item = prefab.GetComponent<ItemDrop>()?.m_itemData;
                item.m_shared.m_damages.m_blunt = cfg.BlackmetalSledgeBluntDamage.Value;
                item.m_shared.m_damages.m_lightning = cfg.BlackmetalSledgeLightningDamage.Value;

                // Add recipe & item
                AddRecipeForAsset(
                    "VABlackmetal_Sledge",
                    prefab,
                    new[] { sprite },
                    new[]
                    {
                        new RequirementConfig { Item = "BlackMetal", Amount = 18, AmountPerLevel = 6 },
                        new RequirementConfig { Item = "Iron", Amount = 4, AmountPerLevel = 2 },
                        new RequirementConfig { Item = "Thunderstone", Amount = 4, AmountPerLevel = 2 },
                        new RequirementConfig { Item = "LoxPelt", Amount = 2 },
                    },
                    "forge",
                    1
                 );
            }
        }

        private void AddSerpentBucklerItem(AssetBundle EmbeddedResourceBundle, ValheimAdditionsConfig cfg)
        {
            // Serpent Scale Buckler
            if (cfg.AbyssalSwordConfigEnabled.Value == false) {
                if (cfg.EnableDebugMode.Value == true) { Logger.LogWarning("Serpent Buckler not loaded."); }
            } else {
                GameObject prefab = LoadPrefab(EmbeddedResourceBundle, "Assets/Custom/SerpentShieldBuckler.prefab");
                Sprite sprite = LoadSprite(EmbeddedResourceBundle, "Assets/Custom/Icons/serpentscale_buckler.png");

                // Modify any configurable values before adding the object
                var item = prefab.GetComponent<ItemDrop>()?.m_itemData;
                item.m_shared.m_blockPower = cfg.SerpentBucklerBlockPowerBase.Value;

                // Add recipe & Item
                AddRecipeForAsset(
                    "VASerpent_buckler",
                    prefab,
                    new[] { sprite },
                    new[]
                    {
                        new RequirementConfig { Item = "SerpentScale", Amount = 6, AmountPerLevel = 4 },
                        new RequirementConfig { Item = "FineWood", Amount = 3, AmountPerLevel = 1 },
                        new RequirementConfig { Item = "Iron", Amount = 3, AmountPerLevel = 2 },
                    },
                    "forge",
                    1
                 );
            }
        }


    }
}
