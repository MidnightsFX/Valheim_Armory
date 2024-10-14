// ValheimArmory
//  Adding tidbits to Valheim
// File:    ValheimArmory.cs
// Project: ValheimArmory

using BepInEx;
using HarmonyLib;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEngine;
using ValheimArmory.common;
using Logger = Jotunn.Logger;

namespace ValheimArmory
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.ClientMustHaveMod, VersionStrictness.Minor)]
    internal class ValheimArmory : BaseUnityPlugin
    {
        public const string PluginGUID = "MidnightsFX.ValheimArmory";
        public const string PluginName = "ValheimArmory";
        public const string PluginVersion = "1.16.2";

        internal static AssetBundle EmbeddedResourceBundle;
        CustomLocalization Localization;


        private void Awake()
        {
            // build the config class, and ensure defaults are available / configs ingested.
            VAConfig cfg = new VAConfig(Config);

            // Load assets
            LoadAssets();

            // Build the piece & item creation classes, provide configuration for toggles and loaded resources
            // new ValheimArmoryPieces(EmbeddedResourceBundle); // not used right now
            new JotunnItemFactory(EmbeddedResourceBundle);
            new ValheimArmoryItems();

            AddLocalizations();
            // UnloadAssets();

            // Modify vanilla weapons
            PrefabManager.OnVanillaPrefabsAvailable += WeaponModifier.SetupEffects;
            if (VAConfig.VanillaHammersHavePrimaryAttack.Value) {
                PrefabManager.OnVanillaPrefabsAvailable += WeaponModifier.ModifyVanillaHammersToWarhammers;
            }
            VAConfig.VanillaHammersHavePrimaryAttack.SettingChanged += WeaponModifier.OnConfigChangeModifyHammers;

            Assembly assembly = Assembly.GetExecutingAssembly();
            Harmony harmony = new(PluginGUID);
            harmony.PatchAll(assembly);
        }

        // Check for other mods here and add compatability functionality
        private void Start()
        {

        }

        // This loads all localizations within the localization directory.
        // Localizations should be plain JSON objects with each of the two required entries being seperate eg:
        // "item_sword": "sword-name-here",
        // "item_sword_description": "sword-description-here",
        // the localization file itself should be a casematched language as defined by one of the "folder" language names from here:
        // https://valheim-modding.github.io/Jotunn/data/localization/language-list.html
        private void AddLocalizations()
        {
            Localization = LocalizationManager.Instance.GetLocalization();
            //LocalizationManager.Instance.AddLocalization(Localization);
            

            // ValheimArmory.localizations.English.json,ValheimArmory.localizations.German.json,ValheimArmory.localizations.Russian.json
            // load all localization files within the localizations directory
            foreach (string embeddedResouce in typeof(ValheimArmory).Assembly.GetManifestResourceNames())
            {
                if (!embeddedResouce.Contains("localizations")) { continue; }
                // Read the localization file
                if (VAConfig.EnableDebugMode.Value == true) { Logger.LogInfo($"Reading {embeddedResouce}"); }
                string localization = ReadEmbeddedResourceFile(embeddedResouce);
                // since I use comments in the localization that are not valid JSON those need to be stripped
                string cleaned_localization = Regex.Replace(localization, @"\/\/.*", "");
                // Just the localization name
                var localization_name = embeddedResouce.Split('.');
                if (VAConfig.EnableDebugMode.Value == true) { Logger.LogInfo($"Adding localization: '{localization_name[2]}'"); }
                // Logging some characters seem to cause issues sometimes
                // if (VAConfig.EnableDebugMode.Value == true) { Logger.LogInfo($"Localization Text: {cleaned_localization}"); }
                //Localization.AddTranslation(localization_name[2], localization);
                Localization.AddJsonFile(localization_name[2], cleaned_localization);
            }
        }

        private void LoadAssets()
        {
            if (VAConfig.EnableDebugMode.Value == true)
            {
                Logger.LogInfo($"Embedded resources: {string.Join(",", typeof(ValheimArmory).Assembly.GetManifestResourceNames())}");
            }
            EmbeddedResourceBundle = AssetUtils.LoadAssetBundleFromResources("ValheimArmory.AssetsEmbedded.vabundle", typeof(ValheimArmory).Assembly);

            if (VAConfig.EnableDebugMode.Value == true)
            {
                Logger.LogInfo($"Asset Names: {string.Join(",", EmbeddedResourceBundle.GetAllAssetNames())}");
            }
        }

        private void UnloadAssets()
        {
            EmbeddedResourceBundle.Unload(false);
        }

        // This reads an embedded file resouce name, these are all resouces packed into the DLL
        // they all have a format following this:
        // ValheimArmory.localizations.English.json
        private string ReadEmbeddedResourceFile(string filename)
        {
            using (var stream = typeof(ValheimArmory).Assembly.GetManifestResourceStream(filename))
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

    }
}