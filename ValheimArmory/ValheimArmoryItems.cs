
using Jotunn.Managers;
using System;
using Logger = Jotunn.Logger;
using UnityEngine;
using Jotunn.Entities;
using Jotunn.Configs;
using BepInEx.Configuration;
using System.Linq;
using System.Collections.Generic;

namespace ValheimArmory
{
    class ValheimArmoryItems
    {
        // constructor, add all items on init
        public ValheimArmoryItems(AssetBundle EmbeddedResourceBundle, VAConfig cfg)
        {
            if (cfg.EnableDebugMode.Value == true)
            {
                Logger.LogInfo("Loading Items.");
            }

            LoadArrows(EmbeddedResourceBundle, cfg);
            LoadBows(EmbeddedResourceBundle, cfg);
            LoadSwords(EmbeddedResourceBundle, cfg);
            LoadAxes(EmbeddedResourceBundle, cfg);
            LoadHammers(EmbeddedResourceBundle, cfg);
            LoadAtgeirs(EmbeddedResourceBundle, cfg);
            LoadDaggers(EmbeddedResourceBundle, cfg);
            LoadShields(EmbeddedResourceBundle, cfg);
            LoadSpears(EmbeddedResourceBundle, cfg);
        }

        private void LoadArrows(AssetBundle EmbeddedResourceBundle, VAConfig cfg)
        {
            // Greenmetal Arrows
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Black Metal Arrow" },
                    { "catagory", "Arrows" },
                    { "prefab", "VAArrowGreenMetal" },
                    { "sprite", "arrow_greenmetal" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { "blunt", new Tuple<float, float, float, bool>(15, 0, 200, true) },
                    { "pierce", new Tuple<float, float, float, bool>(70, 0, 200, true) }
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Feathers", new Tuple<int, int>(1, 0) },
                    { "Wood", new Tuple<int, int>(6, 0) },
                    { "BlackMetal", new Tuple<int, int>(1, 0) },
                }
            );

            // Bone Arrows
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Bone Arrow" },
                    { "catagory", "Arrows" },
                    { "prefab", "VAArrowBone" },
                    { "sprite", "bone_arrow" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { "pierce", new Tuple<float, float, float, bool>(28, 0, 200, true) }
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Feathers", new Tuple<int, int>(1, 0) },
                    { "BoneFragments", new Tuple<int, int>(8, 0) },
                }
            );

            // Surtling Fire Arrow
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Surtling Fire Arrow" },
                    { "catagory", "Arrows" },
                    { "prefab", "VAarrow_surtling_fire" },
                    { "sprite", "surtlingcore_arrow" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { "fire", new Tuple<float, float, float, bool>(65, 0, 200, true) },
                    { "pierce", new Tuple<float, float, float, bool>(35, 0, 200, true) }
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Feathers", new Tuple<int, int>(2, 0) },
                    { "Wood", new Tuple<int, int>(10, 0) },
                    { "Obsidian", new Tuple<int, int>(2, 0) },
                    { "SurtlingCore", new Tuple<int, int>(1, 0) },
                }
            );

            // Ancient Wood Arrow
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Ancient Wood Arrow" },
                    { "catagory", "Arrows" },
                    { "prefab", "VAarrowancient" },
                    { "sprite", "ancient_arrow" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { "pierce", new Tuple<float, float, float, bool>(48, 0, 200, true) }
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Feathers", new Tuple<int, int>(2, 0) },
                    { "ElderBark", new Tuple<int, int>(8, 0) }
                }
            );

            // Chitin Arrow
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Chitin Arrow" },
                    { "catagory", "Arrows" },
                    { "prefab", "VAchitinarrow" },
                    { "sprite", "arrow_chitin" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { "pierce", new Tuple<float, float, float, bool>(32, 0, 200, true) },
                    { "slash", new Tuple<float, float, float, bool>(22, 0, 200, true) }
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Feathers", new Tuple<int, int>(2, 0) },
                    { "Wood", new Tuple<int, int>(8, 0) },
                    { "Chitin", new Tuple<int, int>(3, 0) }
                }
            );

            // Wood Crossbow Bolt
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Wood Bolt" },
                    { "catagory", "Arrows" },
                    { "prefab", "VABoltWood" },
                    { "sprite", "bolt_wood" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { "pierce", new Tuple<float, float, float, bool>(26, 0, 200, true) }
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "RoundLog", new Tuple<int, int>(8, 0) }
                }
            );

            // Bronze Bolt
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Bronze Bolt" },
                    { "catagory", "Arrows" },
                    { "prefab", "VAbolt_bronze" },
                    { "sprite", "bronze_bolt" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { "pierce", new Tuple<float, float, float, bool>(34, 0, 200, true) }
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(8, 0) },
                    { "Bronze", new Tuple<int, int>(2, 0) },
                    { "Feathers", new Tuple<int, int>(2, 0) },
                }
            );

            // Iron Poison Bolt
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Iron Poison Bolt" },
                    { "catagory", "Arrows" },
                    { "prefab", "VAbolt_poison" },
                    { "sprite", "poison_bolt" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { "poison", new Tuple<float, float, float, bool>(72, 0, 200, true) },
                    { "pierce", new Tuple<float, float, float, bool>(36, 0, 200, true) }
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(8, 0) },
                    { "Bronze", new Tuple<int, int>(2, 0) },
                    { "Ooze", new Tuple<int, int>(2, 0) },
                    { "Feathers", new Tuple<int, int>(2, 0) },
                }
            );

            // Silver Ice Bolt
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Silver Frost Bolt" },
                    { "catagory", "Arrows" },
                    { "prefab", "VAbolt_frost" },
                    { "sprite", "ice_bolt" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { "frost", new Tuple<float, float, float, bool>(48, 0, 200, true) },
                    { "spirit", new Tuple<float, float, float, bool>(20, 0, 200, true) },
                    { "pierce", new Tuple<float, float, float, bool>(40, 0, 200, true) }
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(8, 0) },
                    { "Silver", new Tuple<int, int>(2, 0) },
                    { "FreezeGland", new Tuple<int, int>(2, 0) },
                    { "Feathers", new Tuple<int, int>(2, 0) },
                }
            );

            // Blackmetal Surtling bolt
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Blackmetal Surtling Bolt" },
                    { "catagory", "Arrows" },
                    { "prefab", "VASurtlingBolt" },
                    { "sprite", "surtling_bolt" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { "fire", new Tuple<float, float, float, bool>(66, 0, 200, true) },
                    { "pierce", new Tuple<float, float, float, bool>(54, 0, 200, true) }
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(8, 0) },
                    { "BlackMetal", new Tuple<int, int>(2, 0) },
                    { "SurtlingCore", new Tuple<int, int>(2, 0) },
                    { "Feathers", new Tuple<int, int>(2, 0) },
                }
            );
        }

        private void LoadBows(AssetBundle EmbeddedResourceBundle, VAConfig cfg)
        {
            // Bronze Arbalist
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Bronze Arbelist" },
                    { "catagory", "Bows" },
                    { "prefab", "VAArbalistBronze" },
                    { "sprite", "bronze_crossbow_upright" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "pierce", new Tuple<float, float, float, bool>(130, 0, 300, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "block", new Tuple<float, float, float, bool>(14, 0, 60, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                    { "durability", new Tuple<float, float, float, bool>(125, 0, 300, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(16, 8) },
                    { "Bronze", new Tuple<int, int>(6, 3) },
                    { "Guck", new Tuple<int, int>(4, 2) },
                    { "LinenThread", new Tuple<int, int>(8, 4) },
                }
            );

            // Antler Bow
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Eikthyrs Bow" },
                    { "catagory", "Bows" },
                    { "prefab", "VAAntler_Bow" },
                    { "sprite", "antler_bow" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "pierce", new Tuple<float, float, float, bool>(32, 0, 120, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { "lightning", new Tuple<float, float, float, bool>(22, 0, 90, true) },
                    { "lightning_per_level", new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { "block", new Tuple<float, float, float, bool>(9, 0, 25, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(12, 8) },
                    { "Bronze", new Tuple<int, int>(6, 4) },
                    { "HardAntler", new Tuple<int, int>(2, 2) },
                    { "TrophyEikthyr", new Tuple<int, int>(1, 1) },
                }
            );

            // Bronze Crossbow
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Bronze Crossbow" },
                    { "catagory", "Bows" },
                    { "prefab", "VACrossbowBronze" },
                    { "sprite", "bronze_crossbow2" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "pierce", new Tuple<float, float, float, bool>(40, 0, 300, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "block", new Tuple<float, float, float, bool>(14, 0, 60, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                    { "durability", new Tuple<float, float, float, bool>(125, 0, 300, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(8, 8) },
                    { "Bronze", new Tuple<int, int>(6, 3) },
                    { "LeatherScraps", new Tuple<int, int>(4, 2) },
                    { "RoundLog", new Tuple<int, int>(6, 3) },
                }
            );

            // Elder Crossbow
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Elders Reach" },
                    { "catagory", "Bows" },
                    { "prefab", "VACrossbowElder" },
                    { "sprite", "elder_crossbow" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "pierce", new Tuple<float, float, float, bool>(50, 0, 300, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { "spirit", new Tuple<float, float, float, bool>(25, 0, 300, true) },
                    { "spirit_per_level", new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { "block", new Tuple<float, float, float, bool>(14, 0, 60, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                    { "durability", new Tuple<float, float, float, bool>(125, 0, 300, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "RoundLog", new Tuple<int, int>(8, 6) },
                    { "Bronze", new Tuple<int, int>(4, 2) },
                    { "CryptKey", new Tuple<int, int>(1, 1) },
                    { "TrophyTheElder", new Tuple<int, int>(1, 1) },
                }
            );

            // Moder Crossbow
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Bronze Crossbow" },
                    { "catagory", "Bows" },
                    { "prefab", "VACrossbowModer" },
                    { "sprite", "moder_crossbow" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "pierce", new Tuple<float, float, float, bool>(76, 0, 300, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { "frost", new Tuple<float, float, float, bool>(40, 0, 300, true) },
                    { "frost_per_level", new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { "block", new Tuple<float, float, float, bool>(14, 0, 60, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                    { "durability", new Tuple<float, float, float, bool>(125, 0, 300, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(8, 8) },
                    { "Silver", new Tuple<int, int>(6, 3) },
                    { "DragonTear", new Tuple<int, int>(3, 2) },
                    { "TrophyDragonQueen", new Tuple<int, int>(1, 1) },
                }
            );
        }

        private void LoadSwords(AssetBundle EmbeddedResourceBundle, VAConfig cfg)
        {
            // Chitin Sword
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Abyssal Sword" },
                    { "catagory", "Swords" },
                    { "prefab", "VASwordChitin" },
                    { "sprite", "chitin_sword" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "blunt", new Tuple<float, float, float, bool>(25, 0, 90, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "slash", new Tuple<float, float, float, bool>(35, 0, 120, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(10, 1, 30, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "LeatherScraps", new Tuple<int, int>(3, 2) },
                    { "Bronze", new Tuple<int, int>(2, 1) },
                    { "Chitin", new Tuple<int, int>(8, 4) },
                }
            );

            // Antler Sword
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Eikthyrs Sword" },
                    { "catagory", "Swords" },
                    { "prefab", "VAAntler_Sword" },
                    { "sprite", "antler_sword" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "slash", new Tuple<float, float, float, bool>(25, 0, 90, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { "blunt", new Tuple<float, float, float, bool>(15, 0, 90, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(3, 0, 20, true) },
                    { "lightning", new Tuple<float, float, float, bool>(25, 0, 120, true) },
                    { "lightning_per_level", new Tuple<float, float, float, bool>(3, 0, 20, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(8, 1, 30, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(15, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "LeatherScraps", new Tuple<int, int>(2, 2) },
                    { "Bronze", new Tuple<int, int>(6, 6) },
                    { "HardAntler", new Tuple<int, int>(2, 2) },
                    { "TrophyEikthyr", new Tuple<int, int>(1, 1) },
                }
            );

            // Ice Sword
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Moders Grasp" },
                    { "catagory", "Swords" },
                    { "prefab", "VASwordModer" },
                    { "sprite", "moder_sword" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "slash", new Tuple<float, float, float, bool>(70, 0, 90, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { "blunt", new Tuple<float, float, float, bool>(35, 0, 90, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(3, 0, 20, true) },
                    { "frost", new Tuple<float, float, float, bool>(45, 0, 120, true) },
                    { "frost_per_level", new Tuple<float, float, float, bool>(3, 0, 20, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(8, 1, 30, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(15, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "JuteRed", new Tuple<int, int>(4, 2) },
                    { "Obsidian", new Tuple<int, int>(6, 6) },
                    { "DragonTear", new Tuple<int, int>(3, 2) },
                    { "TrophyDragonQueen", new Tuple<int, int>(1, 1) },
                }
            );

            // Bronze Greatsword
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Bronze Greatsword" },
                    { "catagory", "Swords" },
                    { "prefab", "VAbronze_greatsword" },
                    { "sprite", "bronze_greatsword" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "slash", new Tuple<float, float, float, bool>(60, 0, 200, true) },
                    { "block", new Tuple<float, float, float, bool>(12, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(12, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Bronze", new Tuple<int, int>(25, 8) },
                    { "RoundLog", new Tuple<int, int>(8, 2) }
                }
            );

            // Iron Greatsword
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Iron Greatsword" },
                    { "catagory", "Swords" },
                    { "prefab", "VAiron_greatsword" },
                    { "sprite", "iron_greatsword" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "slash", new Tuple<float, float, float, bool>(74, 0, 250, true) },
                    { "block", new Tuple<float, float, float, bool>(24, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(15, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(25, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Iron", new Tuple<int, int>(25, 8) },
                    { "ElderBark", new Tuple<int, int>(6, 2) }
                }
            );

            // Silver Greatsword
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Silver Greatsword" },
                    { "catagory", "Swords" },
                    { "prefab", "VAsilver_greatsword" },
                    { "sprite", "silver_greatsword" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "slash", new Tuple<float, float, float, bool>(96, 0, 300, true) },
                    { "spirit", new Tuple<float, float, float, bool>(30, 0, 120, true) },
                    { "block", new Tuple<float, float, float, bool>(38, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(17, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(30, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Silver", new Tuple<int, int>(25, 8) },
                    { "ElderBark", new Tuple<int, int>(6, 2) },
                    { "Iron", new Tuple<int, int>(6, 1) }
                }

            );
        }

        private void LoadAxes(AssetBundle EmbeddedResourceBundle, VAConfig cfg)
        {
            // Bronze Battleaxe
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Bronze Lumber Axe" },
                    { "catagory", "Axes" },
                    { "prefab", "VAbronze_battleaxe" },
                    { "sprite", "bronze_battleaxe" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "slash", new Tuple<float, float, float, bool>(55, 0, 200, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "chop", new Tuple<float, float, float, bool>(65, 0, 200, true) },
                    { "chop_per_level", new Tuple<float, float, float, bool>(0, 0, 25, true) },
                    { "block", new Tuple<float, float, float, bool>(12, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(12, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(5, 1, 20, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Bronze", new Tuple<int, int>(25, 6) },
                    { "RoundLog", new Tuple<int, int>(8, 2) },
                    { "LeatherScraps", new Tuple<int, int>(4, 2) }
                }
            );

            // Antler Battleaxe
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Eikthyrs Greataxe" },
                    { "catagory", "Axes" },
                    { "prefab", "VAAntler_greataxe" },
                    { "sprite", "antler_greataxe" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "blunt", new Tuple<float, float, float, bool>(15, 0, 200, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "slash", new Tuple<float, float, float, bool>(35, 0, 200, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "lightning", new Tuple<float, float, float, bool>(25, 0, 200, true) },
                    { "lightning_per_level", new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { "chop", new Tuple<float, float, float, bool>(40, 0, 200, true) },
                    { "block", new Tuple<float, float, float, bool>(12, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(12, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(5, 1, 20, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "RoundLog", new Tuple<int, int>(26, 22) },
                    { "Bronze", new Tuple<int, int>(6, 6) },
                    { "HardAntler", new Tuple<int, int>(4, 2) },
                    { "TrophyEikthyr", new Tuple<int, int>(1, 1) },
                }
            );

            // Blackmetal Battleaxe
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Blackmetal Battleaxe" },
                    { "catagory", "Axes" },
                    { "prefab", "VAblackmetal_battleaxe" },
                    { "sprite", "blackmetal_battleaxe" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "slash", new Tuple<float, float, float, bool>(120, 0, 300, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "chop", new Tuple<float, float, float, bool>(120, 0, 300, true) },
                    { "chop_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "fire", new Tuple<float, float, float, bool>(70, 0, 160, true) },
                    { "fire_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "block", new Tuple<float, float, float, bool>(52, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(10, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "BlackMetal", new Tuple<int, int>(25, 6) },
                    { "YggdrasilWood", new Tuple<int, int>(8, 6) },
                    { "SurtlingCore", new Tuple<int, int>(2, 2) }
                }
            );
        }

        private void LoadHammers(AssetBundle EmbeddedResourceBundle, VAConfig cfg)
        {
            // Blackmetal Sledge
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Blackmetal Sledge" },
                    { "catagory", "Hammers" },
                    { "prefab", "VAblackmetal_sledge" },
                    { "sprite", "blackmetal_hammer" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "blunt", new Tuple<float, float, float, bool>(112, 0, 300, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(8, 0, 20, true) },
                    { "lightning", new Tuple<float, float, float, bool>(45, 0, 120, true) },
                    { "lightning_per_level", new Tuple<float, float, float, bool>(3, 0, 20, true) },
                    { "block", new Tuple<float, float, float, bool>(48, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "BlackMetal", new Tuple<int, int>(24, 8) },
                    { "Iron", new Tuple<int, int>(4, 2) },
                    { "Thunderstone", new Tuple<int, int>(4, 2) },
                    { "LoxPelt", new Tuple<int, int>(2, 0) },
                }
            );

            // Elder Sledge
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Elders Rock" },
                    { "catagory", "Hammers" },
                    { "prefab", "VAElderHammer" },
                    { "sprite", "elder_hammer" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "blunt", new Tuple<float, float, float, bool>(112, 0, 300, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(12, 0, 20, true) },
                    { "spirit", new Tuple<float, float, float, bool>(30, 0, 99, true) },
                    { "spirit_per_level", new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { "block", new Tuple<float, float, float, bool>(48, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Stone", new Tuple<int, int>(24, 24) },
                    { "RoundLog", new Tuple<int, int>(8, 4) },
                    { "CryptKey", new Tuple<int, int>(1, 1) },
                    { "TrophyTheElder", new Tuple<int, int>(1, 1) },
                }
            );
        }

        private void LoadAtgeirs(AssetBundle EmbeddedResourceBundle, VAConfig cfg)
        {
            // Antler Atgeir
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Eikthyrs Atgeir" },
                    { "catagory", "Atgeirs" },
                    { "prefab", "VAatgeir_antler" },
                    { "sprite", "antler_atgeir" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "slash", new Tuple<float, float, float, bool>(23, 0, 90, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "lightning", new Tuple<float, float, float, bool>(18, 0, 25, true) },
                    { "lightning_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "block", new Tuple<float, float, float, bool>(12, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(8, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(16, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(24, 20) },
                    { "Resin", new Tuple<int, int>(32, 26) },
                    { "HardAntler", new Tuple<int, int>(4, 2) },
                    { "TrophyEikthyr", new Tuple<int, int>(1, 1) },
                }
            );

            // Royal Abyssal Atgeir
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Royal Abyssal Atgeir" },
                    { "catagory", "Atgeirs" },
                    { "prefab", "VAatgeirchitin" },
                    { "sprite", "chitin_heavy_atgeir_small2" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "pierce", new Tuple<float, float, float, bool>(65, 0, 140, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "slash", new Tuple<float, float, float, bool>(35, 0, 120, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "spirit", new Tuple<float, float, float, bool>(25, 0, 120, true) },
                    { "spirit_per_level", new Tuple<float, float, float, bool>(0, 0, 25, true) },
                    { "block", new Tuple<float, float, float, bool>(28, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(14, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(28, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Chitin", new Tuple<int, int>(14, 8) },
                    { "JuteRed", new Tuple<int, int>(4, 2) },
                    { "FineWood", new Tuple<int, int>(6, 3) },
                    { "Silver", new Tuple<int, int>(4, 2) }
                    
                }
            );
        }

        private void LoadShields(AssetBundle EmbeddedResourceBundle, VAConfig cfg)
        {
            // Serpentscale Buckler
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Serpent Scale Buckler" },
                    { "catagory", "Shields" },
                    { "prefab", "VAserpent_buckler" },
                    { "sprite", "serpentscale_shield2" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(48, 0, 120, true) },
                    { "block_per_level", new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "SerpentScale", new Tuple<int, int>(6, 4) },
                    { "FineWood", new Tuple<int, int>(3, 1) },
                    { "Iron", new Tuple<int, int>(3, 2) }
                }
            );

            // Elder Round Shield
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Elders Bulwark" },
                    { "catagory", "Shields" },
                    { "prefab", "VAElderRoundShield" },
                    { "sprite", "elder_roundshield" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(54, 0, 120, true) },
                    { "block_per_level", new Tuple<float, float, float, bool>(8, 0, 20, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Bronze", new Tuple<int, int>(6, 4) },
                    { "FineWood", new Tuple<int, int>(8, 4) },
                    { "CryptKey", new Tuple<int, int>(1, 1) },
                    { "TrophyTheElder", new Tuple<int, int>(1, 1) },
                }
            );
        }

        private void LoadDaggers(AssetBundle EmbeddedResourceBundle, VAConfig cfg)
        {
            // Antler 1H Daggers
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Eikthyrs Dagger" },
                    { "catagory", "Daggers" },
                    { "prefab", "VAAntler_dagger" },
                    { "sprite", "antler_dagger" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(11, 0, 48, true) },
                    { "slash", new Tuple<float, float, float, bool>(10, 0, 99, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "pierce", new Tuple<float, float, float, bool>(16, 0, 99, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "lightning", new Tuple<float, float, float, bool>(14, 0, 99, true) },
                    { "lightning_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(6, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(18, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "RoundLog", new Tuple<int, int>(2, 1) },
                    { "Resin", new Tuple<int, int>(20, 12) },
                    { "HardAntler", new Tuple<int, int>(1, 1) },
                    { "TrophyEikthyr", new Tuple<int, int>(1, 1) },
                }
            );

            // Bronze 2H Daggers
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Rascals Daggers" },
                    { "catagory", "Daggers" },
                    { "prefab", "VAdagger_bronze_2h" },
                    { "sprite", "bronze_dagger_2h" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(16, 0, 48, true) },
                    { "slash", new Tuple<float, float, float, bool>(19, 0, 99, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "pierce", new Tuple<float, float, float, bool>(19, 0, 99, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(7, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "RoundLog", new Tuple<int, int>(4, 2) },
                    { "LeatherScraps", new Tuple<int, int>(2, 0) },
                    { "Bronze", new Tuple<int, int>(12, 6) }
                }
            );

            // Bronze 1H Daggers
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Bronze Dagger" },
                    { "catagory", "Daggers" },
                    { "prefab", "VAdagger_bronze" },
                    { "sprite", "bronze_dagger" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(11, 0, 48, true) },
                    { "slash", new Tuple<float, float, float, bool>(10, 0, 99, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "pierce", new Tuple<float, float, float, bool>(16, 0, 99, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(6, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(18, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "RoundLog", new Tuple<int, int>(2, 1) },
                    { "LeatherScraps", new Tuple<int, int>(2, 1) },
                    { "Bronze", new Tuple<int, int>(8, 4) }
                }
            );

            // Iron 2H Daggers
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Rogue Daggers" },
                    { "catagory", "Daggers" },
                    { "prefab", "VAdagger_iron_2h" },
                    { "sprite", "iron_dagger_2h" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(21, 0, 48, true) },
                    { "slash", new Tuple<float, float, float, bool>(22, 0, 99, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "pierce", new Tuple<float, float, float, bool>(37, 0, 99, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(8, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(24, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(4, 2) },
                    { "LeatherScraps", new Tuple<int, int>(2, 0) },
                    { "Iron", new Tuple<int, int>(12, 6) }
                }
            );

            // Iron 1H Daggers
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Iron Dagger" },
                    { "catagory", "Daggers" },
                    { "prefab", "VAdagger_iron" },
                    { "sprite", "iron_dagger" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(11, 0, 48, true) },
                    { "slash", new Tuple<float, float, float, bool>(18, 0, 99, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "pierce", new Tuple<float, float, float, bool>(22, 0, 99, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(7, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(22, 1, 50, true) },
                },
                new Dictionary<string, bool>() {
                    { "enabled", true }
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(2, 1) },
                    { "LeatherScraps", new Tuple<int, int>(2, 1) },
                    { "Iron", new Tuple<int, int>(8, 4) }
                }
            );

            // Silver 2H Daggers
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Blackguards Runic Daggers" },
                    { "catagory", "Daggers" },
                    { "prefab", "VAdagger_silver_2h" },
                    { "sprite", "silver_dagger_2h" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(23, 0, 48, true) },
                    { "slash", new Tuple<float, float, float, bool>(25, 0, 99, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "pierce", new Tuple<float, float, float, bool>(41, 0, 99, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "spirit", new Tuple<float, float, float, bool>(32, 0, 99, true) },
                    { "spirit_per_level", new Tuple<float, float, float, bool>(0, 0, 25, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(10, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(32, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(4, 2) },
                    { "JuteRed", new Tuple<int, int>(4, 1) },
                    { "Silver", new Tuple<int, int>(16, 6) }
                }
            );

            // Silver 1H Daggers
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Silver Dagger" },
                    { "catagory", "Daggers" },
                    { "prefab", "VAdagger_silver" },
                    { "sprite", "silver_dagger" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(11, 0, 48, true) },
                    { "slash", new Tuple<float, float, float, bool>(18, 0, 99, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "pierce", new Tuple<float, float, float, bool>(22, 0, 99, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "spirit", new Tuple<float, float, float, bool>(18, 0, 99, true) },
                    { "spirit_per_level", new Tuple<float, float, float, bool>(0, 0, 25, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(10, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(30, 1, 50, true) },
                },
                new Dictionary<string, bool>() {
                    { "enabled", true }
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(2, 1) },
                    { "JuteRed", new Tuple<int, int>(2, 1) },
                    { "Silver", new Tuple<int, int>(10, 4) }
                }
            );
        }

        private void LoadSpears(AssetBundle EmbeddedResourceBundle, VAConfig cfg)
        {
            // Moder Spear
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg,
                new Dictionary<string, string>() {
                    { "name", "Moders Strike" },
                    { "catagory", "Spears" },
                    { "prefab", "VASpearModer" },
                    { "sprite", "moder_spear" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(11, 0, 48, true) },
                    { "pierce", new Tuple<float, float, float, bool>(65, 0, 120, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(8, 0, 20, true) },
                    { "blunt", new Tuple<float, float, float, bool>(25, 0, 99, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(3, 0, 20, true) },
                    { "frost", new Tuple<float, float, float, bool>(45, 0, 99, true) },
                    { "frost_per_level", new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(12, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(14, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(12, 8) },
                    { "Obsidian", new Tuple<int, int>(8, 6) },
                    { "DragonTear", new Tuple<int, int>(3, 2) },
                    { "TrophyDragonQueen", new Tuple<int, int>(1, 1) },
                }
            );
        }
    }

    class ValArmoryItem
    {
        String[] allowed_catagories = {"Arrows", "Atgeirs", "Axes", "Bows", "Hammers", "Shields", "Swords", "Spears", "Daggers" };
        String[] damage_types = {"blunt", "pierce", "slash", "fire", "spirit", "lightning", "chop" };
        String[] crafting_stations = { "forge", "piece_workbench", "blackforge", "piece_artisanstation" };
        /// <summary>
        /// 
        /// </summary>
        /// <param name="EmbeddedResourceBundle"></param>
        /// <param name="cfg"> config file to add things to</param>
        /// <param name="metadata">Key(string)-Value(string) dictionary of item metadata eg: "name" = "Green Metal Arrow"</param>
        /// <param name="itemdata">Key(string)-Value(Tuple) dictionary of item metadata with config metadata eg: "blunt" = < 15(value), 0(min), 200(max), true(cfg_enable_flag) > </param>
        /// <param name="itemtoggles">Key(string)-Value(bool) dictionary of true/false config toggles for this item.</param>
        /// <param name="recipedata">Key(string)-Value(Tuple) dictionary of recipe requirements (limit 4) eg: "SerpentScale" = < 3(creation requirement), 2(levelup requirement)> </param>
        public ValArmoryItem(
            AssetBundle EmbeddedResourceBundle,
            VAConfig cfg,
            Dictionary<String, String> metadata,
            Dictionary<String, Tuple<float, float, float, bool>> itemdata,
            Dictionary<String, bool> itemtoggles,
            Dictionary<String, Tuple<int, int>> recipedata
            )
        {
            // Validate inputs are valid
            if (!allowed_catagories.Contains(metadata["catagory"])) { throw new ArgumentException($"Catagory {metadata["catagory"]} must be an allowed catagory: {allowed_catagories}"); }
            if (!metadata.ContainsKey("name")) { throw new ArgumentException($"Item must have a name"); }
            if (!metadata.ContainsKey("prefab")) { throw new ArgumentException($"Item must have a prefab"); }
            if (!metadata.ContainsKey("sprite")) { throw new ArgumentException($"Item must have a sprite"); }
            if (!metadata.ContainsKey("craftedAt")) { throw new ArgumentException($"Item must have a craftedAt"); }
            if (!itemdata.ContainsKey("amount")) { throw new ArgumentException($"Item must have an amount to be crafted"); }
            if (!crafting_stations.Contains(metadata["craftedAt"])) { throw new ArgumentException($"Catagory {metadata["craftedAt"]} must be a valid crafting station: {crafting_stations}"); }
            if (recipedata.Count > 4) { throw new ArgumentException($"Recipe data can't have more than 4 requirements"); }
            if (!itemtoggles.ContainsKey("enabled")) { itemtoggles.Add("enabled", true); }
            // needed metadata - item name without spaces
            metadata["short_item_name"] = string.Join("", metadata["name"].Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));

            // create config
            if (cfg.EnableDebugMode.Value == true) { Logger.LogDebug($"Creating Configuration Values for {metadata["name"]}"); }
            CreateAndLoadConfigValues(cfg, metadata, itemdata, itemtoggles, recipedata);

            // If the item is not enabled we do not load it
            if (itemtoggles["enabled"] != false)
            {
                // load assets
                if (cfg.EnableDebugMode.Value == true) { Logger.LogDebug($"Loading bundled assets for {metadata["name"]}"); }
                GameObject prefab = EmbeddedResourceBundle.LoadAsset<GameObject>($"Assets/Custom/Weapons/{metadata["catagory"]}/{metadata["prefab"]}.prefab");
                Sprite sprite = EmbeddedResourceBundle.LoadAsset<Sprite>($"Assets/Custom/Icons/{metadata["sprite"]}.png");
                // modify item/recipe
                if (cfg.EnableDebugMode.Value == true) { Logger.LogDebug($"Modifying itemdata for {metadata["name"]}, applying configured values."); }
                ModifyItemData(prefab.GetComponent<ItemDrop>()?.m_itemData, itemdata);

                // Add the recipe with helper
                RequirementConfig[] recipe = new RequirementConfig[recipedata.Count];
                int recipe_index = 0;
                foreach (KeyValuePair<string, Tuple<int, int>> entry in recipedata)
                {
                    recipe[recipe_index] = new RequirementConfig { Item = entry.Key, Amount = entry.Value.Item1, AmountPerLevel = entry.Value.Item2 };
                    recipe_index++;
                }
                ItemConfig itemcfg = new ItemConfig()
                {
                    Amount = (int)itemdata["amount"].Item1,
                    CraftingStation = $"{metadata["craftedAt"]}",
                    Icons = new[] { sprite },
                    Requirements = recipe
                };
                if (cfg.EnableDebugMode.Value == true) { Logger.LogDebug($"Setting Recipe Data: {recipe.ToArray()}"); }
                AddRecipeForAsset($"VA{metadata["short_item_name"]}", prefab, itemcfg);
            }
            else 
            {
                if (cfg.EnableDebugMode.Value == true) { Logger.LogDebug($"{metadata["name"]} is not enabled, and was not loaded."); }
            }
        }

        /// <summary>
        ///  Creates configuration values with automated segmentation on weapon type
        /// </summary>
        /// <param name="Config"></param>
        /// <param name="metadata"></param>
        /// <param name="itemdata"></param>
        /// <param name="itemtoggles"></param>
        private void CreateAndLoadConfigValues(VAConfig Config, Dictionary<String, String> metadata, Dictionary<String, Tuple<float, float, float, bool>> itemdata, Dictionary<String, bool> itemtoggles, Dictionary<String, Tuple<int, int>> recipedata)
        {
            itemtoggles["enabled"] = BindServerConfig(Config.file, $"{metadata["catagory"]} - {metadata["name"]}", $"{metadata["short_item_name"]}-Enable", itemtoggles["enabled"], $"Enable/Disable the {metadata["name"]}.").Value;
            
            // Set and update the crafted at value
            String craftedAt_temp = BindServerConfig(Config.file, $"{metadata["catagory"]} - {metadata["name"]}", $"{metadata["short_item_name"]}-CraftedAt", metadata["craftedAt"], $"Where the recipe is crafted at, valid values: 'forge', 'piece_workbench', 'blackforge', 'piece_artisanstation'.").Value;
            if (!crafting_stations.Contains(craftedAt_temp))
            {
                Logger.LogWarning($"{metadata["catagory"]} - {metadata["name"]} - {metadata["short_item_name"]}-CraftedAt is not valid and the default will be used. Valid values: 'forge', 'piece_workbench', 'blackforge', 'piece_artisanstation'.");
            }
            else
            {
              metadata["craftedAt"] = craftedAt_temp;
            }
                
            // Item bolean flag configs
            foreach (KeyValuePair<string, bool> entry in itemtoggles)
            {
                if (entry.Key == "enabled") { continue; }
                itemtoggles[entry.Key] = BindServerConfig(Config.file, $"{metadata["catagory"]} - {metadata["name"]}", $"{metadata["short_item_name"]}-{entry.Key}", entry.Value, $"{entry.Key} enable(true)/disable(false).", true).Value;
            }
            // Item float valued configs
            Dictionary<String, Tuple<float, float, float, bool>> replacement_itemdata = new Dictionary<String, Tuple<float, float, float, bool>>();
            foreach (KeyValuePair<string, Tuple<float, float, float, bool>> entry in itemdata)
            {
                // Skip this entry if the flag is set for it to be disabled
                if (entry.Value.Item4 == false) { continue; }
                // allow overrides of the min/max damage values passthrough like before
                // allow overrides for advanced section or not, Everything besides enable/disable defaults to advanced currently
                String description;
                int max_value = 200;
                int min_value = 0;
                float current_itemdata_value;
                
                if (damage_types.Contains(entry.Key)) { description = $"{entry.Key} ({min_value}-{max_value}) Damage Value"; } else { description = $"{entry.Key} ({min_value}-{max_value}) Value"; }
                current_itemdata_value = BindServerConfig(Config.file, $"{metadata["catagory"]} - {metadata["name"]}", $"{metadata["short_item_name"]}-{entry.Key}", entry.Value.Item1, $"{description}", true, entry.Value.Item2, entry.Value.Item3).Value;
                Tuple<float, float, float, bool> cfg_update_tuple = new Tuple<float, float, float, bool>(current_itemdata_value, entry.Value.Item2, entry.Value.Item3, true);
                //itemdata.Remove(entry.Key); // remove the old value tuple
                replacement_itemdata.Add(entry.Key, cfg_update_tuple);
            }
            // Replace updated keys in the itemdata
            foreach (KeyValuePair<string, Tuple<float, float, float, bool>> entry in replacement_itemdata)
            {
                itemdata.Remove(entry.Key);
                itemdata.Add(entry.Key, entry.Value);
            }
            // Recipe Configs
            String recipe_cfg = "";
            foreach (KeyValuePair < string, Tuple <int, int>> entry in recipedata)
            {
                if (recipe_cfg.Length > 0) { recipe_cfg += "|"; }
                recipe_cfg += $"{entry.Key},{entry.Value.Item1},{entry.Value.Item2}";
            }
            String RawRecipe;
            RawRecipe = BindServerConfig(Config.file, $"{metadata["catagory"]} - {metadata["name"]}", $"{metadata["short_item_name"]}-recipe", recipe_cfg, $"Recipe to craft and upgrade costs. Find item ids: https://valheim.fandom.com/wiki/Item_IDs, at most 4 costs. Format: resouce_id,craft_cost,upgrade_cost eg: Wood,8,2|Iron,12,4|LeatherScraps,4,0", true).Value;
            if (Config.EnableDebugMode.Value == true) { Logger.LogInfo($"recieved rawrecipe data: '{RawRecipe}'"); }
            String[] RawRecipeEntries = RawRecipe.Split('|');
            Dictionary<String, Tuple<int, int>> updated_recipe = new Dictionary<String, Tuple<int, int>>();
            // we only clear out the default recipe if there is recipe data provided, otherwise we will continue to use the default recipe
            // TODO: Add a sanity check to ensure that recipe formatting is correct
            if (Config.EnableDebugMode.Value == true)
            {
                Logger.LogInfo($"recipe entries: {RawRecipeEntries.Length} : {RawRecipeEntries}");
            }
            if (RawRecipeEntries.Length > 1)
            {
                foreach (String recipe_entry in RawRecipeEntries)
                {
                    String[] recipe_segments = recipe_entry.Split(',');
                    if (Config.EnableDebugMode.Value == true)
                    {
                        String split_segments = "";
                        foreach (String segment in recipe_segments)
                        {
                            split_segments += $" {segment}";
                        }
                        //Logger.LogInfo($"recipe segments: {split_segments} from {recipe_entry}");
                    }
                    // Add a sanity check to ensure the prefab we are trying to use exists
                    updated_recipe.Add(recipe_segments[0], new Tuple<int, int>(Int32.Parse(recipe_segments[1]), Int32.Parse((recipe_segments[2]))));
                }
                recipedata.Clear();
                foreach (KeyValuePair<string, Tuple<int, int>> entry in updated_recipe)
                {
                    if (Config.EnableDebugMode.Value == true) { Logger.LogInfo($"Updated recipe: resouce: {entry.Key} build: {entry.Value.Item1} upgrade: {entry.Value.Item2}"); }
                    recipedata.Add(entry.Key, entry.Value);
                }
            }
            else
            {
                Logger.LogWarning($"Configuration '{metadata["catagory"]} - {metadata["name"]} - {metadata["short_item_name"]}-recipe' was invalid and will be ignored, the default will be used.");
            }
        }

        /// <summary>
        ///  Helper to bind configs for bool types
        /// </summary>
        /// <param name="config_file"></param>
        /// <param name="catagory"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="description"></param>
        /// <param name="advanced"></param>
        /// <returns></returns>
        private ConfigEntry<bool> BindServerConfig(ConfigFile config_file, string catagory, string key, bool value, string description, bool advanced = false)
        {
            return config_file.Bind(catagory, key, value,
                new ConfigDescription(description,
                null,
                new ConfigurationManagerAttributes { IsAdminOnly = true, IsAdvanced = advanced })
                );
        }

        /// <summary>
        /// Helper to bind configs for flaot types
        /// </summary>
        /// <param name="config_file"></param>
        /// <param name="catagory"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="description"></param>
        /// <param name="advanced"></param>
        /// <param name="valmin"></param>
        /// <param name="valmax"></param>
        /// <returns></returns>
        private ConfigEntry<float> BindServerConfig(ConfigFile config_file, string catagory, string key, float value, string description, bool advanced = false, float valmin = 0, float valmax = 150)
        {
            return config_file.Bind(catagory, key, value,
                new ConfigDescription(description,
                new AcceptableValueRange<float>(valmin, valmax),
                new ConfigurationManagerAttributes { IsAdminOnly = true, IsAdvanced = advanced })
                );
        }
        /// <summary>
        /// Helper to bind configs for strings
        /// </summary>
        /// <param name="config_file"></param>
        /// <param name="catagory"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="description"></param>
        /// <param name="advanced"></param>
        /// <returns></returns>
        private ConfigEntry<string> BindServerConfig(ConfigFile config_file, string catagory, string key, string value, string description, bool advanced = false)
        {
            return config_file.Bind(catagory, key, value,
                new ConfigDescription(description, null,
                new ConfigurationManagerAttributes { IsAdminOnly = true, IsAdvanced = advanced })
                );
        }

        /// <summary>
        ///  helper to add a recipe
        /// </summary>
        /// <param name="ingredients"> List of crafting ingrediants for the recipe </param>
        /// <param name="prefab"> Prefabricated object eg: GameObject </param>
        /// <param name="icon"> List of sprites to be used as icons </param>
        /// <param name="ingredients"> List of crafting requirements </param>
        /// <param name="crafted_at"> The crafting station used for the recipe: forge, piece_workbench </param>
        /// <param name="amount"> Int amount recipe will produce </param>
        private void AddRecipeForAsset(String name, GameObject prefab, ItemConfig itemcfg)
        {
            Logger.LogDebug($"Attempting to load {name} Item & Recipe.");
            // Should probably add validation to the input strings here
            try
            {
                var customItem = new CustomItem(prefab, fixReference: true, itemcfg);
                ItemManager.Instance.AddItem(customItem);

                Logger.LogInfo($"{name} Item & Recipe Loaded.");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error while adding Recipe_{name}: {ex.Message}");
            }
        }

        private void ModifyItemData(ItemDrop.ItemData item, Dictionary<String, Tuple<float, float, float, bool>> itemdata)
        {
            foreach (KeyValuePair<string, Tuple<float, float, float, bool>> entry in itemdata)
            {
                switch(entry.Key)
                {
                    // Standard Damage types
                    case "blunt":
                        item.m_shared.m_damages.m_blunt = entry.Value.Item1;
                        break;
                    case "blunt_per_level":
                        item.m_shared.m_damagesPerLevel.m_blunt = (int)entry.Value.Item1;
                        break;
                    case "pierce":
                        item.m_shared.m_damages.m_pierce = entry.Value.Item1;
                        break;
                    case "pierce_per_level":
                        item.m_shared.m_damagesPerLevel.m_pierce = (int)entry.Value.Item1;
                        break;
                    case "slash":
                        item.m_shared.m_damages.m_slash = entry.Value.Item1;
                        break;
                    case "slash_per_level":
                        item.m_shared.m_damagesPerLevel.m_slash = (int)entry.Value.Item1;
                        break;
                    case "attack_force":
                        item.m_shared.m_attackForce = entry.Value.Item1;
                        break;
                    // Harvesting Values
                    case "pickaxe":
                        item.m_shared.m_damages.m_pickaxe = entry.Value.Item1;
                        break;
                    case "pickaxe_per_level":
                        item.m_shared.m_damagesPerLevel.m_pickaxe = (int)entry.Value.Item1;
                        break;
                    case "chop":
                        item.m_shared.m_damages.m_chop = entry.Value.Item1;
                        break;
                    case "chop_per_level":
                        item.m_shared.m_damagesPerLevel.m_chop = (int)entry.Value.Item1;
                        break;
                    // Elemental Damage types
                    case "fire":
                        item.m_shared.m_damages.m_fire = entry.Value.Item1;
                        break;
                    case "fire_per_level":
                        item.m_shared.m_damagesPerLevel.m_fire = (int)entry.Value.Item1;
                        break;
                    case "lightning":
                        item.m_shared.m_damages.m_lightning = entry.Value.Item1;
                        break;
                    case "lightning_per_level":
                        item.m_shared.m_damagesPerLevel.m_lightning = (int)entry.Value.Item1;
                        break;
                    case "spirit":
                        item.m_shared.m_damages.m_spirit = entry.Value.Item1;
                        break;
                    case "spirit_per_level":
                        item.m_shared.m_damagesPerLevel.m_spirit = (int)entry.Value.Item1;
                        break;
                    case "frost":
                        item.m_shared.m_damages.m_frost = entry.Value.Item1;
                        break;
                    case "frost_per_level":
                        item.m_shared.m_damagesPerLevel.m_frost = (int)entry.Value.Item1;
                        break;
                    case "poison":
                        item.m_shared.m_damages.m_poison = entry.Value.Item1;
                        break;
                    case "poison_per_level":
                        item.m_shared.m_damagesPerLevel.m_poison = (int)entry.Value.Item1;
                        break;
                    // Block and Parry
                    case "block":
                        item.m_shared.m_blockPower = entry.Value.Item1;
                        break;
                    case "parry":
                        item.m_shared.m_timedBlockBonus = entry.Value.Item1;
                        break;
                    case "blockforce":
                        item.m_shared.m_deflectionForce = entry.Value.Item1;
                        break;
                    case "timed_block_bonus":
                        item.m_shared.m_timedBlockBonus = entry.Value.Item1;
                        break;
                    case "deflection_force":
                        item.m_shared.m_deflectionForce = entry.Value.Item1;
                        break;
                    // Stamina cost for attack types
                    case "primary_attack_stamina":
                        item.m_shared.m_attack.m_attackStamina = entry.Value.Item1;
                        break;
                    case "secondary_attack_stamina":
                        item.m_shared.m_secondaryAttack.m_attackStamina = entry.Value.Item1;
                        break;
                    // Item Modifiers
                    case "max_item_level":
                        item.m_shared.m_maxQuality = (int)entry.Value.Item1;
                        break;
                    case "durability":
                        item.m_shared.m_maxDurability = (int)entry.Value.Item1;
                        break;
                    case "durability_per_level":
                        item.m_shared.m_maxDurability = (int)entry.Value.Item1;
                        break;
                    case "test":
                        item.m_shared.m_damagesPerLevel.m_blunt = (int)entry.Value.Item1;
                        break;
                    default:
                    break;
                }
            }
        }


    }
}
