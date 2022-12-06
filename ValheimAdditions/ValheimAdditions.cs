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
        

        // setup working server configs
        private ConfigEntry<bool> EnabledGreenMetalArrowConfig;
        private ConfigEntry<bool> EnabledBoneArrowConfig;
        private ConfigEntry<bool> EnabledAbyssalSwordConfig;
        private ConfigEntry<bool> EnabledThunderHammerConfig;
        private ConfigEntry<bool> EnabledSerpentBucklerConfig;
        private ConfigEntry<bool> EnabledSurtlingFireArrowConfig;

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
            UnloadAssets();
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
            EnabledSurtlingFireArrowConfig = Config.Bind("Server config", "EnableSurtlingFireArrow", true,
                new ConfigDescription("Enable the Surtling Fire Arrow (requires mod-reload to take effect).", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));
            EnabledAbyssalSwordConfig = Config.Bind("Server config", "EnableAbyssalSword", true,
                new ConfigDescription("Enable the Abyssal Sword (chitin sword) (requires mod-reload to take effect).", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));
            EnabledSerpentBucklerConfig = Config.Bind("Server config", "EnableSerpentBuckler", true,
                new ConfigDescription("Enable the Serpent Scale Buckler Shield (requires mod-reload to take effect).", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));
            EnabledThunderHammerConfig = Config.Bind("Server config", "EnableThunderHammer", false,
                new ConfigDescription("EXPERIMENTAL - Enable the 2H Thunder Hammer (requires mod-reload to take effect).", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));

        }

        private void AddCustomItems()
        {
            // GreenMetal Arrow
            if (EnabledGreenMetalArrowConfig.Value == false) 
                Jotunn.Logger.LogWarning("GreenMetal Arrow not loaded.");
            else
            {
                GameObject greenMetalArrowPrefab = EmbeddedResourceBundle.LoadAsset<GameObject>("Assets/Custom/ArrowGreenMetal.prefab");
                Sprite greenMetalArrowSprite = EmbeddedResourceBundle.LoadAsset<Sprite>("Assets/Texture2D/arrow_greenmetal.png");
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
            // Bone Arrow
            if (EnabledBoneArrowConfig.Value == false)
                Jotunn.Logger.LogWarning("Bone Arrow not loaded.");
            else
            {
                GameObject boneArrowPrefab = EmbeddedResourceBundle.LoadAsset<GameObject>("Assets/Custom/ArrowBone.prefab");
                Sprite boneArrowSprite = EmbeddedResourceBundle.LoadAsset<Sprite>("Assets/Texture2D/bone_arrow.png");
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
            // Surtling Fire Arrow
            if (EnabledSurtlingFireArrowConfig.Value == false)
                Jotunn.Logger.LogWarning("Surtling Fire Arrow not loaded.");
            else
            {
                GameObject surtlingArrowPrefab = EmbeddedResourceBundle.LoadAsset<GameObject>("Assets/Custom/ArrowSurtlingFire.prefab");
                Sprite surtlingArrowSprite = EmbeddedResourceBundle.LoadAsset<Sprite>("Assets/Texture2D/surtlingCore_Arrow.png");
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

            // Abyssal Sword
            if (EnabledAbyssalSwordConfig.Value == false) 
                Jotunn.Logger.LogWarning("Abyssal Sword not loaded.");
            else
            {
                GameObject chitinSwordPrefab = EmbeddedResourceBundle.LoadAsset<GameObject>("Assets/Custom/SwordChitin.prefab");
                Sprite chitinSwordSprite = EmbeddedResourceBundle.LoadAsset<Sprite>("Assets/Texture2D/chitin_sword_ico.png");
                AddRecipeForAsset(
                    "Chitin_sword",
                    chitinSwordPrefab,
                    new[] { chitinSwordSprite },
                    new[]
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
            if (EnabledThunderHammerConfig.Value == false) 
                Jotunn.Logger.LogWarning("Thunder Hammer not loaded.");
            else
            {
                GameObject thunderHammerPrefab = EmbeddedResourceBundle.LoadAsset<GameObject>("Assets/Custom/HammerLightning.prefab");
                Sprite thunderHammerSprite = EmbeddedResourceBundle.LoadAsset<Sprite>("Assets/Texture2D/lightning_hammer_ico.png");
                AddRecipeForAsset(
                    "Thunder_Hammer",
                    thunderHammerPrefab,
                    new[] { thunderHammerSprite },
                    new[]
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

            // Serpent Scale Buckler
            if (EnabledSerpentBucklerConfig.Value == false)
                Jotunn.Logger.LogWarning("Serpent Buckler not loaded.");
            else
            {
                GameObject serpentBucklerPrefab = EmbeddedResourceBundle.LoadAsset<GameObject>("Assets/Custom/SerpentShieldBuckler.prefab");
                Sprite serpentBucklerSprite = EmbeddedResourceBundle.LoadAsset<Sprite>("Assets/Texture2D/serpent_scale_shield_buckler.png");
                AddRecipeForAsset(
                    "Serpent_buckler",
                    serpentBucklerPrefab,
                    new[] { serpentBucklerSprite },
                    new[]
                    {
                        new RequirementConfig { Item = "SerpentScale", Amount = 6 },
                        new RequirementConfig { Item = "FineWood", Amount = 3 },
                        new RequirementConfig { Item = "Iron", Amount = 3 },
                        new RequirementConfig { Item = "Ruby", Amount = 1 },
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

            // Add translations for our custom items
            Localization.AddTranslation("English", new Dictionary<string, string>
            {
                {"item_arrow_greenmetal", "Blackmetal Arrow"}, {"item_arrow_greenmetal_description", "A piercing darkness, may your aim be true."},
                {"item_bone_arrow", "Bone Arrow"}, {"item_arrow_bone_description", "Just giving a greydwarf a bone."},
                {"item_arrow_surtlingfire", "Surtling Fire Arrow"}, {"item_arrow_surtlingfire_description", "This does not seem safe, hopefully more so for what you are aiming at."},
                {"item_sword_chitin", "Abyssal Sword"}, {"item_sword_chitin_description", "It may not be the sharpest but with enough force it still hurts, a lot."},
                {"item_lightning_hammer", "Elding Hammer"}, {"item_hammer_lightning_description", "A bunch of thunderstones tied together with metal, what could go wrong?"},
                {"item_serpent_buckler", "Serpent Scaled Buckler"}, {"item_serpent_buckler_description", "A flexible wooden-iron woven shield fronted by an array of shiny scales and a ruby. Hopefully the drauger don't like shiny things."},
            });
        }

        private void LoadAssets()
        {
            //Jotunn.Logger.LogInfo($"Embedded resources: {string.Join(",", typeof(ValheimAdditions).Assembly.GetManifestResourceNames())}");
            EmbeddedResourceBundle = AssetUtils.LoadAssetBundleFromResources("vabundle", typeof(ValheimAdditions).Assembly);
        }
        
        private void UnloadAssets()
        {
            EmbeddedResourceBundle.Unload(false);
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="ingredients"> List of crafting ingrediants for the recipe eg: MockRequirement.Create("LeatherScraps", 3) </param>
        /// <param name="prefab"> Prefabricated object eg: GameObject </param>
        /// <param name="icon"> List of sprites to be used as icons </param>
        /// <param name="ingredients"> List of crafting requirements </param>
        /// <param name="crafted_at"> The crafting station used for the recipe: forge, piece_workbench </param>
        /// <param name="amount"> Int amount recipe will produce </param>
        private void AddRecipeForAsset(String name, GameObject prefab, Sprite[] icon, RequirementConfig[] ingredients, String crafted_at, Int16 amount)
        {
            Jotunn.Logger.LogDebug($"Attempting to load {name} Item & Recipe.");
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