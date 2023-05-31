// ValheimArmory
//  Adding tidbits to Valheim
// File:    ValheimArmory.cs
// Project: ValheimArmory

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
using System.IO;

namespace ValheimArmory
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class ValheimArmory : BaseUnityPlugin
    {
        public const string PluginGUID = "com.midnightsfx.ValheimArmory";
        public const string PluginName = "ValheimArmory";
        public const string PluginVersion = "1.3.4";

        AssetBundle EmbeddedResourceBundle;
        CustomLocalization Localization;


        private void Awake()
        {
            // build the config class, and ensure defaults are available / configs ingested.
            VAConfig cfg = new VAConfig(Config);

            // Load assets
            LoadAssets(cfg);

            // Build the piece & item creation classes, provide configuration for toggles and loaded resources
            new ValheimArmoryPieces(EmbeddedResourceBundle, cfg); // not used right now
            new ValheimArmoryItems(EmbeddedResourceBundle, cfg);

            AddLocalizations();
            UnloadAssets();
        }

        // This loads all localizations within the localization directory.
        // Localizations should be plain JSON objects with each of the two required entries being seperate eg:
        // "item_sword": "sword-name-here",
        // "item_sword_description": "sword-description-here",
        // the localization file itself should be a casematched language as defined by one of the "folder" language names from here:
        // https://valheim-modding.github.io/Jotunn/data/localization/language-list.html
        private void AddLocalizations()
        {
            Localization = new CustomLocalization();
            LocalizationManager.Instance.AddLocalization(Localization);

            // load all localization files within the localizations directory
            foreach (string fileName in Directory.GetFiles("localizations", "*.json"))
            {
                // Read the localization file
                string localization = File.ReadAllText(fileName);
                // Localization name without the .json
                var localization_name = fileName.Remove(fileName.Length - 5);
                Localization.AddTranslation("English", localization);
            }
        }

        private void LoadAssets(VAConfig cfg)
        {
            if (cfg.EnableDebugMode.Value == true)
            {
                Logger.LogInfo($"Embedded resources: {string.Join(",", typeof(ValheimArmory).Assembly.GetManifestResourceNames())}");
            }
            EmbeddedResourceBundle = AssetUtils.LoadAssetBundleFromResources("ValheimArmory.AssetsEmbedded.vabundle", typeof(ValheimArmory).Assembly);

            if (cfg.EnableDebugMode.Value == true)
            {
                Logger.LogInfo($"Asset Names: {string.Join(",", EmbeddedResourceBundle.GetAllAssetNames())}");
            }
        }

        private void UnloadAssets()
        {
            EmbeddedResourceBundle.Unload(false);
        }

    }
}