// ValheimAdditions
// a Valheim mod skeleton using Jötunn
// 
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

namespace ValheimAdditions
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    //[NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class ValheimAdditions : BaseUnityPlugin
    {
        public const string PluginGUID = "com.jotunn.ValheimAdditions";
        public const string PluginName = "ValheimAdditions";
        public const string PluginVersion = "0.0.1";

        private AssetBundle EmbeddedResourceBundle;
        private GameObject GreenMetalArrowPrefab;

        private void Awake()
        {
            // Jotunn comes with MonoMod Detours enabled for hooking Valheim's code
            // https://github.com/MonoMod/MonoMod
            On.FejdStartup.Awake += FejdStartup_Awake;

            LoadAssets();
            AddMockedItems();
            AddLocalizations();
            // should unload assets once we have them linked in, originals not needed

            // To learn more about Jotunn's features, go to
            // https://valheim-modding.github.io/Jotunn/tutorials/overview.html
        }

        private void AddMockedItems()
        {
            if (!GreenMetalArrowPrefab) Jotunn.Logger.LogWarning($"Failed to load asset from bundle: {EmbeddedResourceBundle}");
            else
            {
                // Create and add a custom item
                CustomItem CI = new CustomItem(GreenMetalArrowPrefab, true);
                ItemManager.Instance.AddItem(CI);

                Recipe recipe = ScriptableObject.CreateInstance<Recipe>();
                recipe.name = "Recipe_GreenMetal_Arrow";
                recipe.m_item = GreenMetalArrowPrefab.GetComponent<ItemDrop>();
                recipe.m_craftingStation = Mock<CraftingStation>.Create("forge");
                recipe.m_amount = 20;
                var ingredients = new List<Piece.Requirement>
                {
                    MockRequirement.Create("Feathers", 6),
                    MockRequirement.Create("Wood", 4),
                    MockRequirement.Create("BlackMetal", 2),
                };
                recipe.m_resources = ingredients.ToArray();
                CustomRecipe CR = new CustomRecipe(recipe, true, true);
                ItemManager.Instance.AddRecipe(CR);

                Jotunn.Logger.LogInfo("VA - GreenMetalArrow Item & Recipe Loaded.");
            }

        }

        private void AddLocalizations()
        {
            LocalizationManager.Instance.AddLocalization(new LocalizationConfig("English")
            {
                Translations = {
                    {"item_arrow_greenmetal", "Blackmetal arrow"}, {"item_arrow_greenmetal_description", "A piercing darkness, may your aim be true."},
                }
            });
        }

        private void LoadAssets()
        {
            Jotunn.Logger.LogInfo($"Embedded resources: {string.Join(",", typeof(ValheimAdditions).Assembly.GetManifestResourceNames())}");
            EmbeddedResourceBundle = AssetUtils.LoadAssetBundleFromResources("vabundle", typeof(ValheimAdditions).Assembly);
            GreenMetalArrowPrefab = EmbeddedResourceBundle.LoadAsset<GameObject>("Assets/Custom/GreenMetalArrow.prefab");
            Jotunn.Logger.LogInfo($"VA - Loaded: {EmbeddedResourceBundle.GetAllAssetNames()}");
        }

        private void FejdStartup_Awake(On.FejdStartup.orig_Awake orig, FejdStartup self)
        {
            // This code runs before Valheim's FejdStartup.Awake
            Jotunn.Logger.LogInfo("FejdStartup is going to awake");

            // Call this method so the original game method is invoked
            orig(self);

            // This code runs after Valheim's FejdStartup.Awake
            Jotunn.Logger.LogInfo("FejdStartup has awoken");
        }
    }
}