// ValheimArmory
//  Adding tidbits to Valheim
// File:    ValheimArmory.cs
// Project: ValheimArmory

using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEngine;
using ValheimArmory.common;

namespace ValheimArmory
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.ClientMustHaveMod, VersionStrictness.Minor)]
    internal class ValheimArmory : BaseUnityPlugin
    {
        public const string PluginGUID = "MidnightsFX.ValheimArmory";
        public const string PluginName = "ValheimArmory";
        public const string PluginVersion = "1.22.5";

        internal static AssetBundle EmbeddedResourceBundle;
        CustomLocalization Localization;
        public static ManualLogSource Log;


        public void Awake()
        {
            // build the config class, and ensure defaults are available / configs ingested.
            VAConfig cfg = new VAConfig(Config);
            Log = this.Logger;
            // Load assets
            LoadAssets();

            // Build the piece & item creation classes, provide configuration for toggles and loaded resources
            // new ValheimArmoryPieces(EmbeddedResourceBundle); // not used right now
            new JotunnItemFactory(EmbeddedResourceBundle);
            new ValheimArmoryItems();

            AddLocalizations();
            // UnloadAssets();

            // extra Modifying Weapon configurations
            PrefabManager.OnVanillaPrefabsAvailable += WeaponModifier.SetupEffects;
            PrefabManager.OnVanillaPrefabsAvailable += WeaponModifier.ModifyVanillaHammersToWarhammers;
            PrefabManager.OnVanillaPrefabsAvailable += WeaponModifier.ModifyVanillaKnife;
            VAConfig.VanillaHammersHavePrimaryAttack.SettingChanged += WeaponModifier.OnConfigChangeModifyHammers;
            VAConfig.ModHammersHavePrimaryAttack.SettingChanged += WeaponModifier.OnConfigChangeModifyModHammers;
            VAConfig.VanillaAbyssalKnifeBluntDamageConvert.SettingChanged += WeaponModifier.OnConfigChangeModifyVanillaKnife;

            Assembly assembly = Assembly.GetExecutingAssembly();
            Harmony harmony = new(PluginGUID);
            harmony.PatchAll(assembly);

            VAConfig.SaveOnSet(true);
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

            // Ensure localization folder exists
            var translationFolder = Path.Combine(BepInEx.Paths.ConfigPath, "ValheimArmory", "localizations");
            Directory.CreateDirectory(translationFolder);
            //SimpleJson.SimpleJson.CurrentJsonSerializerStrategy
            

            // ValheimArmory.localizations.English.json,ValheimArmory.localizations.German.json,ValheimArmory.localizations.Russian.json
            // load all localization files within the localizations directory
            foreach (string embeddedResouce in typeof(ValheimArmory).Assembly.GetManifestResourceNames())
            {
                if (!embeddedResouce.Contains("localizations")) { continue; }
                // Read the localization file
                
                string localization = ReadEmbeddedResourceFile(embeddedResouce);
                // since I use comments in the localization that are not valid JSON those need to be stripped
                string cleaned_localization = Regex.Replace(localization, @"\/\/.*", "");
                Dictionary<string, string> internal_localization = SimpleJson.SimpleJson.DeserializeObject<Dictionary<string, string>>(cleaned_localization);
                // Just the localization name
                var localization_name = embeddedResouce.Split('.');
                if (File.Exists($"{translationFolder}/{localization_name[2]}.json")) {
                    string cached_translation_file = File.ReadAllText($"{translationFolder}/{localization_name[2]}.json");
                    try {
                        Dictionary<string, string> cached_localization = SimpleJson.SimpleJson.DeserializeObject<Dictionary<string, string>>(cached_translation_file);
                        UpdateLocalizationWithMissingKeys(internal_localization, cached_localization);
                        Logger.LogDebug($"Reading {translationFolder}/{localization_name[2]}.json");
                        File.WriteAllText($"{translationFolder}/{localization_name[2]}.json", SimpleJson.SimpleJson.SerializeObject(cached_localization));
                        string updated_local_translation = File.ReadAllText($"{translationFolder}/{localization_name[2]}.json");
                        Localization.AddJsonFile(localization_name[2], updated_local_translation);
                    } catch {
                        File.WriteAllText($"{translationFolder}/{localization_name[2]}.json", cleaned_localization);
                        Logger.LogDebug($"Reading {embeddedResouce}");
                        Localization.AddJsonFile(localization_name[2], cleaned_localization);
                    }
                } else {
                    File.WriteAllText($"{translationFolder}/{localization_name[2]}.json", cleaned_localization);
                    Logger.LogDebug($"Reading {embeddedResouce}");
                    Localization.AddJsonFile(localization_name[2], cleaned_localization);
                }

                Logger.LogDebug($"Added localization: '{localization_name[2]}'");
                // Logging some characters seem to cause issues sometimes
                // if (VAConfig.EnableDebugMode.Value == true) { Logger.LogInfo($"Localization Text: {cleaned_localization}"); }
                //Localization.AddTranslation(localization_name[2], localization);
                // Localization.AddJsonFile(localization_name[2], cleaned_localization);
            }
        }

        private void UpdateLocalizationWithMissingKeys(Dictionary<string, string> internal_localization, Dictionary<string, string> cached_localization) {
            if (internal_localization.Keys.Count != cached_localization.Keys.Count)
            {
                Logger.LogDebug("Cached localization was missing some entries. They will be added.");
                foreach (KeyValuePair<string, string> entry in internal_localization)
                {
                    if (!cached_localization.ContainsKey(entry.Key))
                    {
                        cached_localization.Add(entry.Key, entry.Value);
                    }
                }
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