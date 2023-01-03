
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
            AddGreenMetalArrowItem(EmbeddedResourceBundle, cfg);
            AddBoneArrowItem(EmbeddedResourceBundle, cfg);
            AddSurtlingFireArrowItem(EmbeddedResourceBundle, cfg);
            AddAncientWoodArrowItem(EmbeddedResourceBundle, cfg);
            AddWoodBoltItem(EmbeddedResourceBundle, cfg);
            AddBronzeCrossbowItem(EmbeddedResourceBundle, cfg);
            AddAbyssalSwordItem(EmbeddedResourceBundle, cfg);
            AddSerpentBucklerItem(EmbeddedResourceBundle, cfg);

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

        // GreenMetal Arrow Enablement, recipe and applied configuration
        private void AddGreenMetalArrowItem(AssetBundle EmbeddedResourceBundle, ValheimAdditionsConfig cfg)
        {
            // GreenMetal Arrow
            if (cfg.GreenMetalArrowConfigEnabled.Value == false)
                Logger.LogWarning("GreenMetal Arrow not loaded.");
            else
            {
                GameObject greenMetalArrowPrefab = EmbeddedResourceBundle.LoadAsset<GameObject>("Assets/Custom/ArrowGreenMetal.prefab");
                Sprite greenMetalArrowSprite = EmbeddedResourceBundle.LoadAsset<Sprite>("Assets/Custom/Icons/arrow_greenmetal.png");

                // Modify any configurable values before adding the object
                var item = greenMetalArrowPrefab.GetComponent<ItemDrop>()?.m_itemData;
                item.m_shared.m_damages.m_blunt = cfg.GreenMetalArrowBluntDamage.Value;
                item.m_shared.m_damages.m_pierce = cfg.GreenMetalArrowPierceDamage.Value;

                // Add the recipe with helper
                AddRecipeForAsset(
                    "GreenMetal_Arrow",
                    greenMetalArrowPrefab,
                    new[] { greenMetalArrowSprite },
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
            if (cfg.BoneArrowConfigEnabled.Value == false)
                Logger.LogWarning("Bone Arrow not loaded.");
            else
            {
                GameObject boneArrowPrefab = EmbeddedResourceBundle.LoadAsset<GameObject>("Assets/Custom/ArrowBone.prefab");
                Sprite boneArrowSprite = EmbeddedResourceBundle.LoadAsset<Sprite>("Assets/Custom/Icons/bone_arrow.png");

                // Modify any configurable values before adding the object
                var item = boneArrowPrefab.GetComponent<ItemDrop>()?.m_itemData;
                item.m_shared.m_damages.m_pierce = cfg.BoneArrowPierceDamage.Value;

                // Add recipe
                AddRecipeForAsset(
                    "Bone_Arrow",
                    boneArrowPrefab,
                    new[] { boneArrowSprite },
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

        private void AddSurtlingFireArrowItem(AssetBundle EmbeddedResourceBundle, ValheimAdditionsConfig cfg)
        {
            // Surtling Fire Arrow
            if (cfg.SurtlingFireArrowConfigEnabled.Value == false)
                Logger.LogWarning("Surtling Fire Arrow not loaded.");
            else
            {
                GameObject surtlingArrowPrefab = EmbeddedResourceBundle.LoadAsset<GameObject>("Assets/Custom/ArrowSurtlingFire.prefab");
                Sprite surtlingArrowSprite = EmbeddedResourceBundle.LoadAsset<Sprite>("Assets/Custom/Icons/surtlingCore_Arrow.png");

                // Modify any configurable values before adding the object
                var item = surtlingArrowPrefab.GetComponent<ItemDrop>()?.m_itemData;
                item.m_shared.m_damages.m_pierce = cfg.SurtlingFireArrowPierceDamage.Value;
                item.m_shared.m_damages.m_fire = cfg.SurtlingFireArrowFireDamage.Value;

                // Add recipe
                AddRecipeForAsset(
                    "SurtlingCore_Arrow",
                    surtlingArrowPrefab,
                    new[] { surtlingArrowSprite },
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
            // Bone Arrow
            if (cfg.AncientWoodArrowConfigEnabled.Value == false)
                Logger.LogWarning("Ancient Wood Arrow not loaded.");
            else
            {
                GameObject prefab = EmbeddedResourceBundle.LoadAsset<GameObject>("assets/custom/arrowancient.prefab");
                Sprite sprite = EmbeddedResourceBundle.LoadAsset<Sprite>("Assets/Custom/Icons/ancient_arrow.png");

                // Modify any configurable values before adding the object
                var item = prefab.GetComponent<ItemDrop>()?.m_itemData;
                item.m_shared.m_damages.m_pierce = cfg.AncientWoodArrowPierceDamage.Value;

                // Add recipe
                AddRecipeForAsset(
                    "Ancient_Arrow",
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

        // Wood Bolt Enablement, recipe and applied configuration
        private void AddWoodBoltItem(AssetBundle EmbeddedResourceBundle, ValheimAdditionsConfig cfg)
        {
            // Bone Arrow
            if (cfg.WoodBoltConfigEnabled.Value == false)
                Logger.LogWarning("Wood Bolt not loaded.");
            else
            {
                GameObject prefab = EmbeddedResourceBundle.LoadAsset<GameObject>("Assets/Custom/BoltWood.prefab");
                Sprite sprite = EmbeddedResourceBundle.LoadAsset<Sprite>("Assets/Custom/Icons/bolt_wood.png");

                // Modify any configurable values before adding the object
                var item = prefab.GetComponent<ItemDrop>()?.m_itemData;
                item.m_shared.m_damages.m_pierce = cfg.WoodBoltPierceDamage.Value;

                // Add recipe
                AddRecipeForAsset(
                    "Wood_Bolt",
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
            // Bone Arrow
            if (cfg.BronzeCrossbowConfigEnabled.Value == false)
                Logger.LogWarning("Bronze Crossbow not loaded.");
            else
            {
                GameObject prefab = EmbeddedResourceBundle.LoadAsset<GameObject>("Assets/Custom/CrossbowBronze.prefab");
                Sprite sprite = EmbeddedResourceBundle.LoadAsset<Sprite>("Assets/Custom/Icons/bronze_crossbow.png");

                // Modify any configurable values before adding the object
                var item = prefab.GetComponent<ItemDrop>()?.m_itemData;
                item.m_shared.m_damages.m_pierce = cfg.BronzeCrossbowPierceDamage.Value;

                // Add recipe
                AddRecipeForAsset(
                    "Bronze_Crossbow",
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

        private void AddAbyssalSwordItem(AssetBundle EmbeddedResourceBundle, ValheimAdditionsConfig cfg)
        {
            // Abyssal Sword
            if (cfg.AbyssalSwordConfigEnabled.Value == false)
                Logger.LogWarning("Abyssal Sword not loaded.");
            else
            {
                GameObject chitinSwordPrefab = EmbeddedResourceBundle.LoadAsset<GameObject>("Assets/Custom/SwordChitin.prefab");
                Sprite chitinSwordSprite = EmbeddedResourceBundle.LoadAsset<Sprite>("Assets/Custom/Icons/chitin_sword.png");

                // Modify any configurable values before adding the object
                var item = chitinSwordPrefab.GetComponent<ItemDrop>()?.m_itemData;
                item.m_shared.m_damages.m_blunt = cfg.AbyssalSwordBluntDamage.Value;
                item.m_shared.m_damages.m_slash = cfg.AbyssalSwordSlashDamage.Value;

                // Add recipe & item
                AddRecipeForAsset(
                    "Chitin_sword",
                    chitinSwordPrefab,
                    new[] { chitinSwordSprite },
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

        private void AddSerpentBucklerItem(AssetBundle EmbeddedResourceBundle, ValheimAdditionsConfig cfg)
        {
            // Serpent Scale Buckler
            if (cfg.AbyssalSwordConfigEnabled.Value == false)
                Logger.LogWarning("Serpent Buckler not loaded.");
            else
            {
                GameObject serpentBucklerPrefab = EmbeddedResourceBundle.LoadAsset<GameObject>("Assets/Custom/SerpentShieldBuckler.prefab");
                Sprite serpentBucklerSprite = EmbeddedResourceBundle.LoadAsset<Sprite>("Assets/Custom/Icons/serpentscale_buckler.png");

                // Modify any configurable values before adding the object
                var item = serpentBucklerPrefab.GetComponent<ItemDrop>()?.m_itemData;
                item.m_shared.m_blockPower = cfg.SerpentBucklerBlockPowerBase.Value;

                // Add recipe & Item
                AddRecipeForAsset(
                    "Serpent_buckler",
                    serpentBucklerPrefab,
                    new[] { serpentBucklerSprite },
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
