// ValheimAdditions
//  Adding tidbits to Valheim
// File:    ValheimAdditions.cs
// Project: ValheimAdditions

using BepInEx;
using Jotunn.Managers;
using Jotunn.Utils;
using System;
using Logger = Jotunn.Logger;
using UnityEngine;
using Jotunn.Entities;
using Jotunn.Configs;
using System.Collections.Generic;
using BepInEx.Configuration;

namespace ValheimAdditions
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class ValheimAdditions : BaseUnityPlugin
    {
        public const string PluginGUID = "com.jotunn.ValheimAdditions";
        public const string PluginName = "ValheimAdditions";
        public const string PluginVersion = "0.2.5";

        private AssetBundle EmbeddedResourceBundle;
        private CustomLocalization Localization;
        private GameObject GreenMetalArrowPrefab;
        private GameObject ChitinSwordPrefab;
        private GameObject BoneArrowPrefab;
        private GameObject BoneArrowProjectilePrefab;
        private GameObject ThunderHammerPrefab;
        

        // setup working server configs
        private ConfigEntry<bool> EnabledGreenMetalArrowConfig;
        private ConfigEntry<bool> EnabledBoneArrowConfig;
        private ConfigEntry<bool> EnabledAbyssalSwordConfig;
        private ConfigEntry<bool> EnabledThunderHammerConfig;

        private void Awake()
        {
            // Jotunn comes with MonoMod Detours enabled for hooking Valheim's code
            // https://github.com/MonoMod/MonoMod
            On.FejdStartup.Awake += FejdStartup_Awake;
            CreateConfigValues();
            LoadAssets();
            //CreateConfigValues();
            //SetConfigValues();
            AddCustomItems();
            AddLocalizations();
            // should unload assets once we have them linked in, originals not needed
        }


        // Create Configuration and load it.
        private void CreateConfigValues()
        {
            Jotunn.Logger.LogInfo("Config Values bound.");
            Config.SaveOnConfigSet = true;

            // Server Settings
            // Enable items (recipes)
            EnabledGreenMetalArrowConfig = Config.Bind("Server config", "EnableGreenMetalArrow", true,
                new ConfigDescription("Enable the GreenMetal Arrow (requires mod-reload to take effect).", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));
            EnabledBoneArrowConfig = Config.Bind("Server config", "EnableBoneArrow", true,
                new ConfigDescription("Enable the Bone Arrow (requires mod-reload to take effect).", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));
            EnabledAbyssalSwordConfig = Config.Bind("Server config", "EnableAbyssalSword", true,
                new ConfigDescription("Enable the Abyssal Sword (chitin sword) (requires mod-reload to take effect).", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));
            EnabledThunderHammerConfig = Config.Bind("Server config", "EnableThunderHammer", false,
                new ConfigDescription("Enable the 2H Thunder Hammer (requires mod-reload to take effect).", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));

        }

        private void AddCustomItems()
        {
            // GreenMetal Arrow
            if (!GreenMetalArrowPrefab || EnabledGreenMetalArrowConfig.Value == false) 
                Jotunn.Logger.LogWarning("GreenMetal Arrow not loaded.");
            else
            {
                AddRecipeForAsset(
                    "GreenMetal_Arrow",
                    GreenMetalArrowPrefab,
                    new RequirementConfig[]
                    {
                        new RequirementConfig { Item = "Feathers", Amount = 1 },
                        new RequirementConfig { Item = "Wood", Amount = 6 },
                        new RequirementConfig { Item = "BlackMetal", Amount = 1 },
                    },
                    "forge",
                    20
                 );
            }
            // Bone Arrow
            if (!BoneArrowPrefab || EnabledBoneArrowConfig.Value == false)
                Jotunn.Logger.LogWarning("Bone Arrow not loaded.");
            else
            {
                AddRecipeForAsset(
                    "Bone_Arrow",
                    BoneArrowPrefab,
                    new RequirementConfig[]
                    {
                        new RequirementConfig { Item = "Feathers", Amount = 1 },
                        new RequirementConfig { Item = "BoneFragments", Amount = 8 },
                    },
                    "piece_workbench",
                    20
                 );
            }

            // Abyssal Sword
            if (!ChitinSwordPrefab || EnabledAbyssalSwordConfig.Value == false) 
                Jotunn.Logger.LogWarning("Abyssal Sword not loaded.");
            else
            {
                AddRecipeForAsset(
                    "Chitin_sword",
                    ChitinSwordPrefab,
                    new RequirementConfig[]
                    {
                        new RequirementConfig { Item = "LeatherScraps", Amount = 3 },
                        new RequirementConfig { Item = "Bronze", Amount = 1 },
                        new RequirementConfig { Item = "Chitin", Amount = 8 },
                    },
                    "forge",
                    1
                 );
            }
            // Thunder Hammer 2H
            if (!ThunderHammerPrefab || EnabledThunderHammerConfig.Value == false) 
                Jotunn.Logger.LogWarning("Thunder Hammer not loaded.");
            else
            {
                AddRecipeForAsset(
                    "Thunder_Hammer",
                    ThunderHammerPrefab,
                    new RequirementConfig[]
                    {
                        new RequirementConfig { Item = "ElderBark", Amount = 4 },
                        new RequirementConfig { Item = "Thunderstone", Amount = 6 },
                        new RequirementConfig { Item = "LeatherScraps", Amount = 3 },
                        new RequirementConfig { Item = "BlackMetal", Amount = 4 },
                    },
                "forge",
                    1
                 );
            }

        }

        private void AddLocalizations()
        {
            Localization = new CustomLocalization();
            LocalizationManager.Instance.AddLocalization(Localization);

            // Add translations for our custom skill
            Localization.AddTranslation("English", new Dictionary<string, string>
            {
                {"item_arrow_greenmetal", "Blackmetal arrow"}, {"item_arrow_greenmetal_description", "A piercing darkness, may your aim be true."},
                {"item_bone_arrow", "Bone Arrow"}, {"item_arrow_bone_description", "Just giving a greydwarf a bone."},
                {"item_sword_chitin", "Abyssal Sword"}, {"item_sword_chitin_description", "It may not be the sharpest but with enough force it still hurts, a lot."},
                {"item_lightning_hammer", "Elding Hammer"}, {"item_hammer_lightning_description", "A bunch of thunderstones tied together with metal, what could go wrong?"},
            });
        }

        private void LoadAssets()
        {
            //Jotunn.Logger.LogInfo($"Embedded resources: {string.Join(",", typeof(ValheimAdditions).Assembly.GetManifestResourceNames())}");
            EmbeddedResourceBundle = AssetUtils.LoadAssetBundleFromResources("vabundle", typeof(ValheimAdditions).Assembly);
            // Load Arrows
            if (EnabledGreenMetalArrowConfig.Value == true) 
            { 
                GreenMetalArrowPrefab = EmbeddedResourceBundle.LoadAsset<GameObject>("Assets/Custom/ArrowGreenMetal.prefab");
                Jotunn.Logger.LogInfo("Loaded Greenmetal Item from bundle.");
            }
            if (EnabledBoneArrowConfig.Value == true)
            {
                BoneArrowPrefab = EmbeddedResourceBundle.LoadAsset<GameObject>("Assets/Custom/ArrowBone.prefab");
                BoneArrowProjectilePrefab = EmbeddedResourceBundle.LoadAsset<GameObject>("Assets/Custom/bow_projectile_bone.prefab");
            }

            // Load Weapons
            if (EnabledAbyssalSwordConfig.Value == true) { ChitinSwordPrefab = EmbeddedResourceBundle.LoadAsset<GameObject>("Assets/Custom/SwordChitin.prefab"); }
            if (EnabledThunderHammerConfig.Value == true) { ThunderHammerPrefab = EmbeddedResourceBundle.LoadAsset<GameObject>("Assets/Custom/HammerLightning.prefab"); }
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="ingredients"> List of crafting ingrediants for the recipe eg: MockRequirement.Create("LeatherScraps", 3) </param>
        /// <param name="prefab"> Prefabricated object eg: GameObject </param>
        /// <param name="ingredients"> List of crafting requirements </param>
        /// <param name="crafted_at"> The crafting station used for the recipe: forge, piece_workbench </param>
        private void AddRecipeForAsset(String name, GameObject prefab, RequirementConfig[] ingredients, String crafted_at, Int16 amount)
        {
            Jotunn.Logger.LogDebug($"Attempting to load {name} Item & Recipe.");
            // Should probably add validation to the input strings here
            try
            {
                CustomItem customItem = new CustomItem(prefab, true);
                ItemManager.Instance.AddItem(customItem);

                // Create a custom recipe with a RecipeConfig
                CustomRecipe customRecipe = new CustomRecipe(new RecipeConfig()
                {
                    Item = prefab.name,
                    Name = $"Recipe_{name}",
                    Requirements = ingredients,
                    Amount = amount,
                    CraftingStation = crafted_at
                });
                ItemManager.Instance.AddRecipe(customRecipe);

                Jotunn.Logger.LogInfo($"{name} Item & Recipe Loaded.");
            } catch (Exception ex)
            {
                Jotunn.Logger.LogError($"Error while adding Recipe_{name}: {ex.Message}");
            }
        }

        private void FejdStartup_Awake(On.FejdStartup.orig_Awake orig, FejdStartup self)
        {
            // This code runs before Valheim's FejdStartup.Awake
            //Jotunn.Logger.LogInfo("FejdStartup is going to awake");

            // Call this method so the original game method is invoked
            orig(self);

            // This code runs after Valheim's FejdStartup.Awake
            //Jotunn.Logger.LogInfo("FejdStartup has awoken");
        }
    }
}