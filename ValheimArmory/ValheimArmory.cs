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

namespace ValheimArmory
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class ValheimArmory : BaseUnityPlugin
    {
        public const string PluginGUID = "com.jotunn.ValheimArmory";
        public const string PluginName = "ValheimArmory";
        public const string PluginVersion = "1.0.0";

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


        private void AddLocalizations()
        {
            Localization = new CustomLocalization();
            LocalizationManager.Instance.AddLocalization(Localization);

            // Add translations for our custom items
            Localization.AddTranslation("English", new Dictionary<string, string>
            {   
                // Items
                {"item_arrow_greenmetal", "Blackmetal Arrow"}, {"item_arrow_greenmetal_description", "A piercing darkness, may your aim be true."},
                {"item_bone_arrow", "Bone Arrow"}, {"item_arrow_bone_description", "Just giving a greydwarf a bone."},
                {"item_arrow_surtlingfire", "Surtling Fire Arrow"}, {"item_arrow_surtlingfire_description", "This does not seem safe, hopefully more so for what you are aiming at."},
                {"item_ancient_arrow", "Ancient Wood Arrow"}, {"item_ancient_arrow_description", "Looks like it will splinter at any given time."},
                {"item_arrow_chitin", "Chitin Arrow"}, {"item_arrow_chitin_description", "Not as sharp as other arrows but it causes a nasty cut regardless."},
                {"item_bolt_wood", "Wood Bolt"}, {"item_bolt_wood_description", "A little more than a pointy stick. Shot hard enough, it sure hurts!"},
                {"item_crossbow_bronze", "Bronze Crossbow"}, {"item_crossbow_bronze_description", "Not perfect, but a weapon like this should be able to hurl bolts at incredible speeds. Not very durable."},
                {"item_sword_chitin", "Abyssal Sword"}, {"item_sword_chitin_description", "It may not be the sharpest but with enough force it still hurts, a lot."},
                {"item_lightning_hammer", "Elding Hammer"}, {"item_hammer_lightning_description", "A bunch of thunderstones tied together with metal, what could go wrong?"},
                {"item_serpent_buckler", "Serpent Scaled Buckler"}, {"item_serpent_buckler_description", "A flexible wooden-iron woven shield fronted by an array of shiny scales."},
                {"item_atgeir_chitin_heavy", "Royal Abyssal Atgeir"}, {"item_atgeir_chitin_heavy_description", "A sharpened Chitin Atgeir with a silvercore, fit for the bravest of vikings."},
                {"item_atgeir_antler", "Antlergeir"}, {"item_atgeir_antler_description", "Sharp Deer Antlers attached to a wooden pole. Not as sharp as a blade, but also not very heavy."},
                {"item_sledge_blackmetal", "Sky Shatter"}, {"item_sledge_blackmetal_description", "Heavy chunks of blackmetal fused with thunderstones. Causes lightning strikes."},
                {"item_battleaxe_bronze", "Timber Axe"}, {"item_battleaxe_bronze_description", "An especially large bronze axe, great for removing heads and trees."},
                {"item_battleaxe_blackmetal", "Herkir's Wrath"}, {"item_battleaxe_blackmetal_description", "Giant Killer, fire bringer, pain maker."},
                {"item_bronze_greatsword", "Bronze Greatsword"}, {"item_bronze_greatsword_description", "A massive bronze blade handled with corewood, not very durable but quite sharp."},
                {"item_iron_greatsword", "Iron Greatsword"}, {"item_iron_greatsword_description", "A huge rough iron blade with a hewn stone hilt. With a big enough blade, anything dies."},
                {"item_silver_greatsword", "Silver Runic Greatsword"}, {"item_silver_greatsword_description", "Silver forged with wrought iron, emblazoned with runes to ward off the undead."},
                // Pieces
                // {"artisan_upgrade1", "Experimental Equipment"}, {"artisan_upgrade1_description", "A Bucket filled with the same magical tears that seem to make mechanical componets move, with a bunch of mechanical bits tossed in. What could we make with these?"},
            });
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