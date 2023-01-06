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
        public const string PluginVersion = "0.3.9";

        AssetBundle EmbeddedResourceBundle;
        CustomLocalization Localization;


        private void Awake()
        {
            // build the config class, and ensure defaults are available / configs ingested.
            ValheimAdditionsConfig cfg = new ValheimAdditionsConfig(Config);

            // Load assets
            LoadAssets(cfg);

            // Build the item creation class, provide configuration for toggles and loaded resources
            new ValheimAdditionsItems(EmbeddedResourceBundle, cfg);

            AddLocalizations();
            UnloadAssets();
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
                {"item_ancient_arrow", "Ancient Wood Arrow"}, {"item_ancient_arrow_description", "Looks like it will splinter at any given time."},
                {"item_arrow_chitin", "Chitin Arrow"}, {"item_arrow_chitin_description", "Not as sharp as other arrows but it causes a nasty cut regardless."},
                {"item_bolt_wood", "Wood Bolt"}, {"item_bolt_wood_description", "A little more than a pointy stick. Shot hard enough, it sure hurts!"},
                {"item_crossbow_bronze", "Bronze Crossbow"}, {"item_crossbow_bronze_description", "Not perfect, but a weapon like this should be able to hurl bolts an an incredible speed. Not very durable."},
                {"item_sword_chitin", "Abyssal Sword"}, {"item_sword_chitin_description", "It may not be the sharpest but with enough force it still hurts, a lot."},
                {"item_lightning_hammer", "Elding Hammer"}, {"item_hammer_lightning_description", "A bunch of thunderstones tied together with metal, what could go wrong?"},
                {"item_serpent_buckler", "Serpent Scaled Buckler"}, {"item_serpent_buckler_description", "A flexible wooden-iron woven shield fronted by an array of shiny scales."},
                {"item_atgeir_chitin_heavy", "Royal Abyssal Atgeir"}, {"item_atgeir_chitin_heavy_description", "A sharpened Chitin Atgeir with a silvercore, fit for the bravest of vikings."},
            });
        }

        private void LoadAssets(ValheimAdditionsConfig cfg)
        {
            if (cfg.EnableDebugMode.Value == true)
            {
                Logger.LogInfo($"Embedded resources: {string.Join(",", typeof(ValheimAdditions).Assembly.GetManifestResourceNames())}");
            }
            EmbeddedResourceBundle = AssetUtils.LoadAssetBundleFromResources("vabundle", typeof(ValheimAdditions).Assembly);
        }

        private void UnloadAssets()
        {
            EmbeddedResourceBundle.Unload(false);
        }

    }
}