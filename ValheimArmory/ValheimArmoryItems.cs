
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
        AssetBundle EmbeddedResourceBundle = ValheimArmory.EmbeddedResourceBundle;
        // constructor, add all items on init
        public ValheimArmoryItems()
        {
            if (VAConfig.EnableDebugMode.Value == true)
            {
                Logger.LogInfo("Loading Items.");
            }

            LoadArrows();
            LoadBows();
            LoadSwords();
            LoadAxes();
            LoadHammers();
            LoadAtgeirs();
            LoadDaggers();
            LoadShields();
            LoadSpears();
            LoadMaces();
            LoadFists();
            LoadMagic();
            LoadPickaxes();
            LoadNonCraftables();
        }

        private void LoadArrows()
        {
            // Greenmetal Arrows
            new ValArmoryItem(
                EmbeddedResourceBundle,
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
                },
                new Dictionary<string, bool>() { }
            );

            // Bone Arrows
            new ValArmoryItem(
                EmbeddedResourceBundle,
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
                },
                new Dictionary<string, bool>() { }
            );

            // Surtling Fire Arrow
            new ValArmoryItem(
                EmbeddedResourceBundle,
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
                },
                new Dictionary<string, bool>() { }
            );

            // Ancient Wood Arrow
            new ValArmoryItem(
                EmbeddedResourceBundle,
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
                },
                new Dictionary<string, bool>() { }
            );

            // Chitin Arrow
            new ValArmoryItem(
                EmbeddedResourceBundle,
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
                },
                new Dictionary<string, bool>() { }
            );

            // Wood Crossbow Bolt
            new ValArmoryItem(
                EmbeddedResourceBundle,
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
                },
                new Dictionary<string, bool>() { }
            );

            // Bronze Bolt
            new ValArmoryItem(
                EmbeddedResourceBundle,
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
                },
                new Dictionary<string, bool>() { }
            );

            // Iron Poison Bolt
            new ValArmoryItem(
                EmbeddedResourceBundle,
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
                    { "Iron", new Tuple<int, int>(2, 0) },
                    { "Ooze", new Tuple<int, int>(2, 0) },
                    { "Feathers", new Tuple<int, int>(2, 0) },
                },
                new Dictionary<string, bool>() { }
            );

            // Obsidian Bolt
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Obsidian Bolt" },
                    { "catagory", "Arrows" },
                    { "prefab", "VAObsidianBolt" },
                    { "sprite", "obsidian_bolt" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { "pierce", new Tuple<float, float, float, bool>(58, 0, 200, true) }
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(8, 0) },
                    { "Obsidian", new Tuple<int, int>(4, 0) },
                    { "Feathers", new Tuple<int, int>(2, 0) },
                },
                new Dictionary<string, bool>() { }
            );

            // Silver Ice Bolt
            new ValArmoryItem(
                EmbeddedResourceBundle,
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
                },
                new Dictionary<string, bool>() { }
            );

            // Blackmetal Surtling bolt
            new ValArmoryItem(
                EmbeddedResourceBundle,
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
                },
                new Dictionary<string, bool>() { }
            );
        }

        private void LoadBows()
        {
            // Blood Bone Bow
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Blood Bone Bow" },
                    { "catagory", "Bows" },
                    { "prefab", "VABlood_bone_bow" },
                    { "sprite", "bone_bow" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "pierce", new Tuple<float, float, float, bool>(82, 0, 300, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(8, 0, 25, true) },
                    { "block", new Tuple<float, float, float, bool>(22, 0, 60, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(10, 0, 300, true) },
                    { "draw_stamina_drain", new Tuple<float, float, float, bool>(4, 1, 50, true) },
                    { "primary_attack_flat_health_cost", new Tuple<float, float, float, bool>(8, 0, 25, true) },
                    { "primary_attack_percent_health_cost", new Tuple<float, float, float, bool>(0, 0, 50, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { "bow_draw_speed", new Tuple<float, float, float, bool>(100, 1, 300, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "RoundLog", new Tuple<int, int>(12, 8) },
                    { "BoneFragments", new Tuple<int, int>(20, 14) },
                    { "Silver", new Tuple<int, int>(6, 2) },
                    { "TrophyUlv", new Tuple<int, int>(4, 0) },
                },
                new Dictionary<string, bool>() { }
            );

            // Bronze Arbalist
            new ValArmoryItem(
                EmbeddedResourceBundle,
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
                    { "attack_force", new Tuple<float, float, float, bool>(140, 0, 300, true) },
                    { "block", new Tuple<float, float, float, bool>(14, 0, 60, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                    { "durability", new Tuple<float, float, float, bool>(125, 0, 300, true) },
                    { "crossbow_reload_speed", new Tuple<float, float, float, bool>(100, 1, 300, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(16, 8) },
                    { "Bronze", new Tuple<int, int>(6, 3) },
                    { "Guck", new Tuple<int, int>(4, 2) },
                    { "LinenThread", new Tuple<int, int>(8, 4) },
                },
                new Dictionary<string, bool>() { }
            );

            // Antler Bow
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Eikthyrs Bow" },
                    { "catagory", "Bows" },
                    { "prefab", "VAAntler_Bow" },
                    { "sprite", "antler_bow" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "pierce", new Tuple<float, float, float, bool>(22, 0, 120, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "lightning", new Tuple<float, float, float, bool>(18, 0, 90, true) },
                    { "lightning_per_level", new Tuple<float, float, float, bool>(2, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(5, 0, 50, true) },
                    { "block", new Tuple<float, float, float, bool>(9, 0, 25, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                    { "bow_draw_speed", new Tuple<float, float, float, bool>(100, 1, 300, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(24, 8) },
                    { "Bronze", new Tuple<int, int>(12, 4) },
                    { "HardAntler", new Tuple<int, int>(2, 2) },
                    { "TrophyEikthyr", new Tuple<int, int>(1, 1) },
                },
                new Dictionary<string, bool>() { }
            );

            // Bronze Crossbow
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Bronze Crossbow" },
                    { "catagory", "Bows" },
                    { "prefab", "VACrossbowBronze" },
                    { "sprite", "bronze_crossbow2" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "pierce", new Tuple<float, float, float, bool>(45, 0, 300, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "block", new Tuple<float, float, float, bool>(14, 0, 60, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(140, 0, 300, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                    { "durability", new Tuple<float, float, float, bool>(125, 0, 300, true) },
                    { "crossbow_reload_speed", new Tuple<float, float, float, bool>(100, 1, 300, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(8, 8) },
                    { "Bronze", new Tuple<int, int>(6, 3) },
                    { "LeatherScraps", new Tuple<int, int>(4, 2) },
                    { "RoundLog", new Tuple<int, int>(6, 3) },
                },
                new Dictionary<string, bool>() { }
            );

            // Elder Crossbow
            new ValArmoryItem(
                EmbeddedResourceBundle,
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
                    { "pierce_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "spirit", new Tuple<float, float, float, bool>(15, 0, 300, true) },
                    { "spirit_per_level", new Tuple<float, float, float, bool>(2, 0, 25, true) },
                    { "block", new Tuple<float, float, float, bool>(14, 0, 60, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(140, 0, 300, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                    { "durability", new Tuple<float, float, float, bool>(125, 0, 300, true) },
                    { "crossbow_reload_speed", new Tuple<float, float, float, bool>(100, 1, 300, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "RoundLog", new Tuple<int, int>(16, 8) },
                    { "Bronze", new Tuple<int, int>(8, 4) },
                    { "CryptKey", new Tuple<int, int>(1, 1) },
                    { "TrophyTheElder", new Tuple<int, int>(1, 1) },
                },
                new Dictionary<string, bool>() { }
            );

            // Moder Crossbow
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Moder Crossbow" },
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
                    { "attack_force", new Tuple<float, float, float, bool>(140, 0, 300, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                    { "durability", new Tuple<float, float, float, bool>(125, 0, 300, true) },
                    { "crossbow_reload_speed", new Tuple<float, float, float, bool>(100, 1, 300, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(8, 8) },
                    { "Silver", new Tuple<int, int>(6, 3) },
                    { "DragonTear", new Tuple<int, int>(3, 2) },
                    { "TrophyDragonQueen", new Tuple<int, int>(1, 1) },
                },
                new Dictionary<string, bool>() { }
            );

            // Queen Bow
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Queens Greatbow" },
                    { "catagory", "Bows" },
                    { "prefab", "VAQueen_bow" },
                    { "sprite", "queen_bow" },
                    { "craftedAt", "blackforge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "pierce", new Tuple<float, float, float, bool>(86, 0, 200, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { "poison", new Tuple<float, float, float, bool>(32, 0, 90, true) },
                    { "poison_per_level", new Tuple<float, float, float, bool>(4, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(30, 0, 50, true) },
                    { "block", new Tuple<float, float, float, bool>(24, 0, 25, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                    { "bow_draw_speed", new Tuple<float, float, float, bool>(100, 1, 300, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "TrophySeekerQueen", new Tuple<int, int>(1, 1) },
                    { "Iron", new Tuple<int, int>(20, 10) },
                    { "JuteRed", new Tuple<int, int>(6, 2) },
                    { "Eitr", new Tuple<int, int>(26, 13) },
                },
                new Dictionary<string, bool>() { }
            );
        }

        private void LoadSwords()
        {
            // Chitin Sword
            new ValArmoryItem(
                EmbeddedResourceBundle,
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
                    { "attack_force", new Tuple<float, float, float, bool>(40, 0, 120, true) },
                    { "block", new Tuple<float, float, float, bool>(12, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(10, 1, 30, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "LeatherScraps", new Tuple<int, int>(3, 2) },
                    { "Bronze", new Tuple<int, int>(2, 1) },
                    { "Chitin", new Tuple<int, int>(8, 4) },
                },
                new Dictionary<string, bool>() { }
            );

            // Antler Sword
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Eikthyrs Sword" },
                    { "catagory", "Swords" },
                    { "prefab", "VAAntler_Sword" },
                    { "sprite", "antler_sword" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "slash", new Tuple<float, float, float, bool>(18, 0, 90, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(2, 0, 20, true) },
                    { "blunt", new Tuple<float, float, float, bool>(10, 0, 90, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(1, 0, 20, true) },
                    { "lightning", new Tuple<float, float, float, bool>(12, 0, 120, true) },
                    { "lightning_per_level", new Tuple<float, float, float, bool>(3, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(40, 0, 120, true) },
                    { "block", new Tuple<float, float, float, bool>(12, 0, 60, true) },
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
                },
                new Dictionary<string, bool>() { }
            );

            // Vine Sword
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Elders Balance" },
                    { "catagory", "Swords" },
                    { "prefab", "VAVine_Sword" },
                    { "sprite", "vine_sword" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "slash", new Tuple<float, float, float, bool>(45, 0, 90, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(3, 0, 20, true) },
                    { "spirit", new Tuple<float, float, float, bool>(16, 0, 120, true) },
                    { "spirit_per_level", new Tuple<float, float, float, bool>(2, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(20, 0, 120, true) },
                    { "block", new Tuple<float, float, float, bool>(12, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(9, 1, 30, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(18, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Stone", new Tuple<int, int>(40, 25) },
                    { "Bronze", new Tuple<int, int>(6, 6) },
                    { "CryptKey", new Tuple<int, int>(1, 1) },
                    { "TrophyTheElder", new Tuple<int, int>(1, 1) },
                },
                new Dictionary<string, bool>() { }
            );

            // Ice Sword
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Moders Grasp" },
                    { "catagory", "Swords" },
                    { "prefab", "VASwordModer" },
                    { "sprite", "moder_sword" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "slash", new Tuple<float, float, float, bool>(55, 0, 90, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { "blunt", new Tuple<float, float, float, bool>(35, 0, 90, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(3, 0, 20, true) },
                    { "frost", new Tuple<float, float, float, bool>(25, 0, 120, true) },
                    { "frost_per_level", new Tuple<float, float, float, bool>(3, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(40, 0, 120, true) },
                    { "block", new Tuple<float, float, float, bool>(12, 0, 60, true) },
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
                },
                new Dictionary<string, bool>() { }
            );

            // Bronze Greatsword
            new ValArmoryItem(
                EmbeddedResourceBundle,
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
                    { "slash_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(55, 0, 160, true) },
                    { "block", new Tuple<float, float, float, bool>(12, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(12, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Bronze", new Tuple<int, int>(25, 8) },
                    { "RoundLog", new Tuple<int, int>(8, 2) }
                },
                new Dictionary<string, bool>() { }
            );

            // Iron Greatsword
            new ValArmoryItem(
                EmbeddedResourceBundle,
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
                    { "slash_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(55, 0, 160, true) },
                    { "block", new Tuple<float, float, float, bool>(24, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(15, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(25, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Iron", new Tuple<int, int>(25, 8) },
                    { "ElderBark", new Tuple<int, int>(6, 2) }
                },
                new Dictionary<string, bool>() { }
            );

            // Silver Greatsword
            new ValArmoryItem(
                EmbeddedResourceBundle,
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
                    { "slash_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "spirit", new Tuple<float, float, float, bool>(30, 0, 120, true) },
                    { "spirit_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(55, 0, 160, true) },
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
                },
                new Dictionary<string, bool>() { }

            );

            // Bonemass Greatsword
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Bonemasses Greatsword" },
                    { "catagory", "Swords" },
                    { "prefab", "VABonemassGreatsword" },
                    { "sprite", "bonemass_greatsword" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "slash", new Tuple<float, float, float, bool>(62, 0, 250, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "poison", new Tuple<float, float, float, bool>(35, 0, 250, true) },
                    { "poison_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(55, 0, 160, true) },
                    { "block", new Tuple<float, float, float, bool>(24, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(15, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(25, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Iron", new Tuple<int, int>(12, 8) },
                    { "WitheredBone", new Tuple<int, int>(18, 12) },
                    { "Wishbone", new Tuple<int, int>(1, 1) },
                    { "TrophyBonemass", new Tuple<int, int>(1, 1) },
                },
                new Dictionary<string, bool>() { }
            );

            // Yagluth Greatsword
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Yagluths Greatsword" },
                    { "catagory", "Swords" },
                    { "prefab", "VAYagluth_greatsword" },
                    { "sprite", "yagluth_greatsword" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "slash", new Tuple<float, float, float, bool>(130, 0, 250, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { "fire", new Tuple<float, float, float, bool>(25, 0, 250, true) },
                    { "fire_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(55, 0, 160, true) },
                    { "block", new Tuple<float, float, float, bool>(30, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(17, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(31, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "BlackMetal", new Tuple<int, int>(16, 12) },
                    { "Iron", new Tuple<int, int>(6, 6) },
                    { "TrophyGoblinKing", new Tuple<int, int>(1, 1) },
                    { "YagluthDrop", new Tuple<int, int>(3, 2) },
                },
                new Dictionary<string, bool>() { }
            );

            // Flint Sword
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Flint Sword" },
                    { "catagory", "Swords" },
                    { "prefab", "VAFlint_Sword" },
                    { "sprite", "flint_sword" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "slash", new Tuple<float, float, float, bool>(16, 0, 90, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(3, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(40, 0, 120, true) },
                    { "block", new Tuple<float, float, float, bool>(4, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(6, 1, 30, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(12, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "LeatherScraps", new Tuple<int, int>(2, 1) },
                    { "Wood", new Tuple<int, int>(4, 2) },
                    { "Flint", new Tuple<int, int>(12, 4) },
                },
                new Dictionary<string, bool>() { }
            );

            // Flint Greatsword
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Flint Greatsword" },
                    { "catagory", "Swords" },
                    { "prefab", "VAFlint_greatsword" },
                    { "sprite", "flint_greatsword" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "slash", new Tuple<float, float, float, bool>(30, 0, 200, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(42, 0, 160, true) },
                    { "block", new Tuple<float, float, float, bool>(6, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(10, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(15, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "LeatherScraps", new Tuple<int, int>(3, 1) },
                    { "Wood", new Tuple<int, int>(15, 5) },
                    { "Flint", new Tuple<int, int>(20, 8) },
                },
                new Dictionary<string, bool>() { }
            );

            // Queen Greatsword
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Queen Greatsword" },
                    { "catagory", "Swords" },
                    { "prefab", "VAQueen_greatsword" },
                    { "sprite", "queen_greatsword" },
                    { "craftedAt", "blackforge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "slash", new Tuple<float, float, float, bool>(145, 0, 250, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { "poison", new Tuple<float, float, float, bool>(32, 0, 250, true) },
                    { "poison_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(55, 0, 160, true) },
                    { "block", new Tuple<float, float, float, bool>(35, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(19, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(33, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "JuteRed", new Tuple<int, int>(12, 4) },
                    { "Iron", new Tuple<int, int>(24, 12) },
                    { "TrophySeekerQueen", new Tuple<int, int>(1, 1) },
                    { "Eitr", new Tuple<int, int>(20, 16) },
                },
                new Dictionary<string, bool>() { }
            );

            // Queen sword
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Queen Sword" },
                    { "catagory", "Swords" },
                    { "prefab", "VASwordQueen" },
                    { "sprite", "queen_sword" },
                    { "craftedAt", "blackforge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "slash", new Tuple<float, float, float, bool>(110, 0, 250, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { "poison", new Tuple<float, float, float, bool>(32, 0, 250, true) },
                    { "poison_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(55, 0, 160, true) },
                    { "block", new Tuple<float, float, float, bool>(35, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(17, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(34, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "JuteRed", new Tuple<int, int>(12, 4) },
                    { "Iron", new Tuple<int, int>(24, 12) },
                    { "TrophySeekerQueen", new Tuple<int, int>(1, 1) },
                    { "Eitr", new Tuple<int, int>(20, 16) },
                },
                new Dictionary<string, bool>() { }
            );
        }

        private void LoadAxes()
        {
            // Flint Battleaxe
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Flint greataxe" },
                    { "catagory", "Axes" },
                    { "prefab", "VAFlint_greataxe" },
                    { "sprite", "flint_greataxe" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "slash", new Tuple<float, float, float, bool>(28, 0, 200, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "chop", new Tuple<float, float, float, bool>(30, 0, 200, true) },
                    { "chop_per_level", new Tuple<float, float, float, bool>(0, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(45, 0, 200, true) },
                    { "block", new Tuple<float, float, float, bool>(6, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(10, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(3, 1, 20, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(18, 12) },
                    { "Flint", new Tuple<int, int>(22, 12) },
                    { "LeatherScraps", new Tuple<int, int>(4, 2) }
                },
                new Dictionary<string, bool>() { }
            );

            // Bronze Battleaxe
            new ValArmoryItem(
                EmbeddedResourceBundle,
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
                    { "attack_force", new Tuple<float, float, float, bool>(65, 0, 200, true) },
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
                },
                new Dictionary<string, bool>() { }
            );

            // Antler Battleaxe
            new ValArmoryItem(
                EmbeddedResourceBundle,
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
                    { "lightning", new Tuple<float, float, float, bool>(20, 0, 200, true) },
                    { "lightning_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "chop", new Tuple<float, float, float, bool>(40, 0, 200, true) },
                    { "chop_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(65, 0, 200, true) },
                    { "block", new Tuple<float, float, float, bool>(12, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(12, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(5, 1, 20, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "RoundLog", new Tuple<int, int>(26, 22) },
                    { "Bronze", new Tuple<int, int>(12, 6) },
                    { "HardAntler", new Tuple<int, int>(4, 2) },
                    { "TrophyEikthyr", new Tuple<int, int>(1, 1) },
                },
                new Dictionary<string, bool>() { }
            );

            // Blackmetal Battleaxe
            new ValArmoryItem(
                EmbeddedResourceBundle,
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
                    { "slash_per_level", new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { "chop", new Tuple<float, float, float, bool>(120, 0, 300, true) },
                    { "chop_per_level", new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { "fire", new Tuple<float, float, float, bool>(70, 0, 160, true) },
                    { "fire_per_level", new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(65, 0, 200, true) },
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
                },
                new Dictionary<string, bool>() { }
            );
        }

        private void LoadHammers()
        {
            // Blackmetal Sledge
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Blackmetal Sledge" },
                    { "catagory", "Hammers" },
                    { "prefab", "VAblackmetal_sledge" },
                    { "sprite", "blackmetal_hammer" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "blunt", new Tuple<float, float, float, bool>(92, 0, 300, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { "lightning", new Tuple<float, float, float, bool>(38, 0, 120, true) },
                    { "lightning_per_level", new Tuple<float, float, float, bool>(3, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(120, 0, 400, true) },
                    { "block", new Tuple<float, float, float, bool>(48, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(19, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(24, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "BlackMetal", new Tuple<int, int>(24, 12) },
                    { "Iron", new Tuple<int, int>(8, 4) },
                    { "Thunderstone", new Tuple<int, int>(8, 4) },
                    { "LoxPelt", new Tuple<int, int>(2, 2) },
                },
                new Dictionary<string, bool>() { }
            );

            // Elder Sledge
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Elders Rock" },
                    { "catagory", "Hammers" },
                    { "prefab", "VAElderHammer" },
                    { "sprite", "elder_hammer" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "blunt", new Tuple<float, float, float, bool>(42, 0, 300, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(4, 0, 20, true) },
                    { "spirit", new Tuple<float, float, float, bool>(12, 0, 99, true) },
                    { "spirit_per_level", new Tuple<float, float, float, bool>(3, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(120, 0, 400, true) },
                    { "block", new Tuple<float, float, float, bool>(48, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(11, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(15, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Stone", new Tuple<int, int>(48, 24) },
                    { "RoundLog", new Tuple<int, int>(24, 12) },
                    { "CryptKey", new Tuple<int, int>(1, 1) },
                    { "TrophyTheElder", new Tuple<int, int>(1, 1) },
                },
                new Dictionary<string, bool>() { }
            );

            // Bonemass Warhammer
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Bonemasses Rage" },
                    { "catagory", "Hammers" },
                    { "prefab", "VABonemassWarhammer" },
                    { "sprite", "bonemass_warhammer" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "blunt", new Tuple<float, float, float, bool>(85, 0, 300, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(3, 0, 20, true) },
                    { "poison", new Tuple<float, float, float, bool>(32, 0, 99, true) },
                    { "poison_per_level", new Tuple<float, float, float, bool>(2, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(120, 0, 400, true) },
                    { "block", new Tuple<float, float, float, bool>(48, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(15, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Iron", new Tuple<int, int>(12, 8) },
                    { "WitheredBone", new Tuple<int, int>(16, 12) },
                    { "Wishbone", new Tuple<int, int>(1, 1) },
                    { "TrophyBonemass", new Tuple<int, int>(1, 1) },
                },
                new Dictionary<string, bool>() { }
            );
        }

        private void LoadAtgeirs()
        {
            // Flint Atgeir
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Flint Atgeir" },
                    { "catagory", "Atgeirs" },
                    { "prefab", "VAAtgeir_Flint" },
                    { "sprite", "flint_atgeir" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "pierce", new Tuple<float, float, float, bool>(23, 0, 90, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(25, 0, 120, true) },
                    { "block", new Tuple<float, float, float, bool>(10, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(8, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(14, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(20, 12) },
                    { "Flint", new Tuple<int, int>(18, 9) },
                    { "LeatherScraps", new Tuple<int, int>(3, 2) },
                },
                new Dictionary<string, bool>() { }
            );

            // Antler Atgeir
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Eikthyrs Atgeir" },
                    { "catagory", "Atgeirs" },
                    { "prefab", "VAatgeir_antler" },
                    { "sprite", "antler_atgeir" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "pierce", new Tuple<float, float, float, bool>(23, 0, 90, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "lightning", new Tuple<float, float, float, bool>(18, 0, 25, true) },
                    { "lightning_per_level", new Tuple<float, float, float, bool>(2, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(30, 0, 120, true) },
                    { "block", new Tuple<float, float, float, bool>(12, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(10, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(16, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(24, 20) },
                    { "Resin", new Tuple<int, int>(32, 26) },
                    { "HardAntler", new Tuple<int, int>(4, 2) },
                    { "TrophyEikthyr", new Tuple<int, int>(1, 1) },
                },
                new Dictionary<string, bool>() { }
            );

            // Royal Abyssal Atgeir
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Royal Abyssal Atgeir" },
                    { "catagory", "Atgeirs" },
                    { "prefab", "VAAtgeirchitin" },
                    { "sprite", "chitin_heavy_atgeir_small2" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "pierce", new Tuple<float, float, float, bool>(45, 0, 140, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "slash", new Tuple<float, float, float, bool>(30, 0, 120, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(2, 0, 25, true) },
                    { "spirit", new Tuple<float, float, float, bool>(25, 0, 120, true) },
                    { "spirit_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(30, 0, 120, true) },
                    { "block", new Tuple<float, float, float, bool>(28, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(14, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(28, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Chitin", new Tuple<int, int>(14, 10) },
                    { "JuteRed", new Tuple<int, int>(4, 2) },
                    { "FineWood", new Tuple<int, int>(14, 7) },
                    { "Silver", new Tuple<int, int>(8, 6) }
                    
                },
                new Dictionary<string, bool>() { }
            );

            // Silver Atgeir
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Silver Atgeir" },
                    { "catagory", "Atgeirs" },
                    { "prefab", "VASilverAtgeir" },
                    { "sprite", "silver_atgeir" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "pierce", new Tuple<float, float, float, bool>(82, 0, 250, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { "spirit", new Tuple<float, float, float, bool>(22, 0, 120, true) },
                    { "spirit_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(30, 0, 120, true) },
                    { "block", new Tuple<float, float, float, bool>(28, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(14, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(28, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Silver", new Tuple<int, int>(30, 15) },
                    { "ElderBark", new Tuple<int, int>(12, 8) },
                    { "JuteRed", new Tuple<int, int>(4, 2) },
                },
                new Dictionary<string, bool>() { }
            );

            // Yagluth Atgeir
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Yagluths Reach" },
                    { "catagory", "Atgeirs" },
                    { "prefab", "VAYagluthAtgeir" },
                    { "sprite", "yagluth_atgeir" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "pierce", new Tuple<float, float, float, bool>(105, 0, 250, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(8, 0, 25, true) },
                    { "fire", new Tuple<float, float, float, bool>(25, 0, 120, true) },
                    { "fire_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(30, 0, 120, true) },
                    { "block", new Tuple<float, float, float, bool>(58, 0, 120, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(18, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(36, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "BlackMetal", new Tuple<int, int>(8, 8) },
                    { "Iron", new Tuple<int, int>(20, 20) },
                    { "TrophyGoblinKing", new Tuple<int, int>(1, 1) },
                    { "YagluthDrop", new Tuple<int, int>(3, 2) },
                },
                new Dictionary<string, bool>() { }
            );
        }

        private void LoadShields()
        {
            // Serpentscale Buckler
            new ValArmoryItem(
                EmbeddedResourceBundle,
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
                    { "deflection_force", new Tuple<float, float, float, bool>(25, 0, 120, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "SerpentScale", new Tuple<int, int>(6, 4) },
                    { "FineWood", new Tuple<int, int>(3, 1) },
                    { "Iron", new Tuple<int, int>(3, 2) }
                },
                new Dictionary<string, bool>() { }
            );

            // Elder Round Shield
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Elders Bulwark" },
                    { "catagory", "Shields" },
                    { "prefab", "VAElderRoundShield" },
                    { "sprite", "elder_roundshield" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(38, 0, 120, true) },
                    { "block_per_level", new Tuple<float, float, float, bool>(2, 0, 20, true) },
                    { "deflection_force", new Tuple<float, float, float, bool>(25, 0, 120, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                },
                new Dictionary<string, bool>() {},
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Bronze", new Tuple<int, int>(8, 4) },
                    { "FineWood", new Tuple<int, int>(16, 8) },
                    { "CryptKey", new Tuple<int, int>(1, 1) },
                    { "TrophyTheElder", new Tuple<int, int>(1, 1) },
                },
                new Dictionary<string, bool>() { }
            );

            // Elder Round Shield
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Moders Roundshield" },
                    { "catagory", "Shields" },
                    { "prefab", "VAModer_RoundShield" },
                    { "sprite", "moder_roundshield" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(100, 0, 120, true) },
                    { "block_per_level", new Tuple<float, float, float, bool>(2, 0, 20, true) },
                    { "deflection_force", new Tuple<float, float, float, bool>(25, 0, 120, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                },
                new Dictionary<string, bool>() {
                    { "resistFire", true },
                    { "resistIce", true },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(24, 14) },
                    { "Silver", new Tuple<int, int>(16, 8) },
                    { "DragonTear", new Tuple<int, int>(2, 2) },
                    { "TrophyDragonQueen", new Tuple<int, int>(1, 1) },
                },
                new Dictionary<string, bool>() { }
            );
        }

        private void LoadDaggers()
        {
            // Flint 2H Daggers
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Flint Daggers" },
                    { "catagory", "Daggers" },
                    { "prefab", "VADagger_Flint_2h" },
                    { "sprite", "flint_2h_dagger" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(12, 0, 48, true) },
                    { "slash", new Tuple<float, float, float, bool>(11, 0, 99, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "pierce", new Tuple<float, float, float, bool>(11, 0, 99, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(12, 0, 40, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(5, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(15, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(12, 2) },
                    { "Flint", new Tuple<int, int>(20, 8) },
                    { "LeatherScraps", new Tuple<int, int>(2, 2) }
                },
                new Dictionary<string, bool>() { }
            );

            // Antler 1H Daggers
            new ValArmoryItem(
                EmbeddedResourceBundle,
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
                    { "pierce", new Tuple<float, float, float, bool>(13, 0, 99, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(0, 0, 25, true) },
                    { "lightning", new Tuple<float, float, float, bool>(8, 0, 99, true) },
                    { "lightning_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(10, 0, 30, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(6, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(18, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "RoundLog", new Tuple<int, int>(8, 4) },
                    { "Resin", new Tuple<int, int>(40, 20) },
                    { "HardAntler", new Tuple<int, int>(2, 2) },
                    { "TrophyEikthyr", new Tuple<int, int>(1, 1) },
                },
                new Dictionary<string, bool>() { }
            );

            // Bronze 2H Daggers
            new ValArmoryItem(
                EmbeddedResourceBundle,
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
                    { "attack_force", new Tuple<float, float, float, bool>(12, 0, 40, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(7, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "RoundLog", new Tuple<int, int>(4, 2) },
                    { "LeatherScraps", new Tuple<int, int>(2, 0) },
                    { "Bronze", new Tuple<int, int>(12, 6) }
                },
                new Dictionary<string, bool>() { }
            );

            // Bronze 1H Daggers
            new ValArmoryItem(
                EmbeddedResourceBundle,
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
                    { "attack_force", new Tuple<float, float, float, bool>(10, 0, 30, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(6, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(18, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "RoundLog", new Tuple<int, int>(2, 1) },
                    { "LeatherScraps", new Tuple<int, int>(2, 1) },
                    { "Bronze", new Tuple<int, int>(8, 4) }
                },
                new Dictionary<string, bool>() { }
            );

            // Iron 2H Daggers
            new ValArmoryItem(
                EmbeddedResourceBundle,
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
                    { "attack_force", new Tuple<float, float, float, bool>(12, 0, 40, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(8, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(24, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(4, 2) },
                    { "LeatherScraps", new Tuple<int, int>(2, 0) },
                    { "Iron", new Tuple<int, int>(12, 6) }
                },
                new Dictionary<string, bool>() { }
            );

            // Iron 1H Daggers
            new ValArmoryItem(
                EmbeddedResourceBundle,
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
                    { "attack_force", new Tuple<float, float, float, bool>(10, 0, 30, true) },
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
                },
                new Dictionary<string, bool>() { }
            );

            // Silver 2H Daggers
            new ValArmoryItem(
                EmbeddedResourceBundle,
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
                    { "attack_force", new Tuple<float, float, float, bool>(12, 0, 40, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(10, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(32, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(4, 2) },
                    { "JuteRed", new Tuple<int, int>(4, 1) },
                    { "Silver", new Tuple<int, int>(16, 6) }
                },
                new Dictionary<string, bool>() { }
            );

            // Silver 1H Daggers
            new ValArmoryItem(
                EmbeddedResourceBundle,
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
                    { "attack_force", new Tuple<float, float, float, bool>(10, 0, 30, true) },
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
                },
                new Dictionary<string, bool>() { }
            );

            // Bonemass Dagger
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Bonemasses Dagger" },
                    { "catagory", "Daggers" },
                    { "prefab", "VABonemassDagger" },
                    { "sprite", "bonemass_dagger" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(11, 0, 48, true) },
                    { "pierce", new Tuple<float, float, float, bool>(32, 0, 99, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "poison", new Tuple<float, float, float, bool>(12, 0, 99, true) },
                    { "poison_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(10, 0, 30, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(7, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(22, 1, 50, true) },
                },
                new Dictionary<string, bool>() {
                    { "enabled", true }
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Iron", new Tuple<int, int>(12, 8) },
                    { "WitheredBone", new Tuple<int, int>(8, 4) },
                    { "Wishbone", new Tuple<int, int>(1, 1) },
                    { "TrophyBonemass", new Tuple<int, int>(1, 1) },
                },
                new Dictionary<string, bool>() { }
            );

            // Queens Dagger
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Queens Dagger" },
                    { "catagory", "Daggers" },
                    { "prefab", "VAdagger_queen" },
                    { "sprite", "dagger_queen" },
                    { "craftedAt", "blackforge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(11, 0, 48, true) },
                    { "pierce", new Tuple<float, float, float, bool>(45, 0, 99, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(2, 0, 25, true) },
                    { "slash", new Tuple<float, float, float, bool>(45, 0, 99, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(2, 0, 25, true) },
                    { "poison", new Tuple<float, float, float, bool>(18, 0, 99, true) },
                    { "poison_per_level", new Tuple<float, float, float, bool>(2, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(10, 0, 30, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(13, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(42, 1, 80, true) },
                },
                new Dictionary<string, bool>() {
                    { "enabled", true }
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Iron", new Tuple<int, int>(18, 8) },
                    { "JuteRed", new Tuple<int, int>(6, 3) },
                    { "Eitr", new Tuple<int, int>(12, 10) },
                    { "TrophySeekerQueen", new Tuple<int, int>(1, 1) },
                },
                new Dictionary<string, bool>() { }
            );
        }

        private void LoadSpears()
        {
            // Moder Spear
            new ValArmoryItem(
                EmbeddedResourceBundle,
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
                    { "pierce", new Tuple<float, float, float, bool>(50, 0, 120, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(2, 0, 20, true) },
                    { "blunt", new Tuple<float, float, float, bool>(20, 0, 99, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(1, 0, 20, true) },
                    { "frost", new Tuple<float, float, float, bool>(32, 0, 99, true) },
                    { "frost_per_level", new Tuple<float, float, float, bool>(2, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(12, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(14, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(20, 14) },
                    { "Obsidian", new Tuple<int, int>(16, 8) },
                    { "DragonTear", new Tuple<int, int>(3, 2) },
                    { "TrophyDragonQueen", new Tuple<int, int>(1, 1) },
                },
                new Dictionary<string, bool>() { }
            );
        }

        private void LoadFists()
        {
            // Flint Fists
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Flint knuckles" },
                    { "catagory", "Fists" },
                    { "prefab", "VAFist_Flint" },
                    { "sprite", "flint_fists" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(6, 0, 48, true) },
                    { "slash", new Tuple<float, float, float, bool>(15, 0, 120, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(1, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(5, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(4, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(8, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(14, 6) },
                    { "Flint", new Tuple<int, int>(8, 4) },
                    { "LeatherScraps", new Tuple<int, int>(2, 2) },
                },
                new Dictionary<string, bool>() { }
            );

            // Bronze Fists
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Bronze knuckles" },
                    { "catagory", "Fists" },
                    { "prefab", "VAFist_Bronze" },
                    { "sprite", "bronze_fists" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(6, 0, 48, true) },
                    { "slash", new Tuple<float, float, float, bool>(26, 0, 120, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(2, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(5, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(6, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(12, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(10, 6) },
                    { "RoundLog", new Tuple<int, int>(6, 4) },
                    { "LeatherScraps", new Tuple<int, int>(4, 2) },
                    { "Bronze", new Tuple<int, int>(8, 6) },
                },
                new Dictionary<string, bool>() { }
            );

            // Iron Fists
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Iron knuckles" },
                    { "catagory", "Fists" },
                    { "prefab", "VAFist_Iron" },
                    { "sprite", "iron_fists" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(6, 0, 48, true) },
                    { "slash", new Tuple<float, float, float, bool>(48, 0, 120, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(3, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(5, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(8, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(16, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Iron", new Tuple<int, int>(18, 12) },
                    { "ElderBark", new Tuple<int, int>(8, 4) },
                    { "TrollHide", new Tuple<int, int>(6, 3) },
                    { "Bronze", new Tuple<int, int>(4, 0) },
                },
                new Dictionary<string, bool>() { }
            );

            // Yagluth Fists
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Goblin king knuckles" },
                    { "catagory", "Fists" },
                    { "prefab", "VAFist_Yagluth" },
                    { "sprite", "yagluth_fists" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(6, 0, 48, true) },
                    { "slash", new Tuple<float, float, float, bool>(92, 0, 120, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(5, 0, 20, true) },
                    { "fire", new Tuple<float, float, float, bool>(30, 0, 120, true) },
                    { "fire_per_level", new Tuple<float, float, float, bool>(2, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(5, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(12, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(24, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "BlackMetal", new Tuple<int, int>(20, 12) },
                    { "Iron", new Tuple<int, int>(8, 4) },
                    { "TrophyGoblinKing", new Tuple<int, int>(1, 1) },
                    { "YagluthDrop", new Tuple<int, int>(3, 2) },
                },
                new Dictionary<string, bool>() { }
            );
        }

        private void LoadMaces()
        {
            // Elders Mace
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Elders Fist" },
                    { "catagory", "Maces" },
                    { "prefab", "VAElder_mace" },
                    { "sprite", "elder_mace" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "blunt", new Tuple<float, float, float, bool>(45, 0, 90, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(3, 0, 20, true) },
                    { "spirit", new Tuple<float, float, float, bool>(16, 0, 120, true) },
                    { "spirit_per_level", new Tuple<float, float, float, bool>(2, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(20, 0, 120, true) },
                    { "block", new Tuple<float, float, float, bool>(12, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(9, 1, 30, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(18, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Stone", new Tuple<int, int>(40, 25) },
                    { "Bronze", new Tuple<int, int>(6, 6) },
                    { "CryptKey", new Tuple<int, int>(1, 1) },
                    { "TrophyTheElder", new Tuple<int, int>(1, 1) },
                },
                new Dictionary<string, bool>() { }
            );
        }

        private void LoadMagic()
        {
            // Staff of poison
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Staff of poison" },
                    { "catagory", "Magics" },
                    { "prefab", "VAStaff_Poison" },
                    { "sprite", "poison_staff" },
                    { "craftedAt", "piece_magetable" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(48, 0, 90, true) },
                    { "poison", new Tuple<float, float, float, bool>(90, 0, 200, true) },
                    { "poison_per_level", new Tuple<float, float, float, bool>(5, 0, 20, true) },
                    { "blunt", new Tuple<float, float, float, bool>(90, 0, 200, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(5, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(65, 0, 60, true) },
                    { "primary_attack_eitr", new Tuple<float, float, float, bool>(24, 0, 50, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(0, 0, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "YggdrasilWood", new Tuple<int, int>(24, 12) },
                    { "Guck", new Tuple<int, int>(22, 8) },
                    { "JuteBlue", new Tuple<int, int>(14, 7) },
                    { "Eitr", new Tuple<int, int>(12, 6) },
                },
                new Dictionary<string, bool>()
                {
                }
            );

            // Staff of spirit
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Staff of Spirit" },
                    { "catagory", "Magics" },
                    { "prefab", "VAStaff_Spirit" },
                    { "sprite", "spirit_staff" },
                    { "craftedAt", "piece_magetable" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(48, 0, 90, true) },
                    { "spirit", new Tuple<float, float, float, bool>(90, 0, 200, true) },
                    { "spirit_per_level", new Tuple<float, float, float, bool>(5, 0, 20, true) },
                    { "blunt", new Tuple<float, float, float, bool>(90, 0, 200, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(5, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(65, 0, 60, true) },
                    { "primary_attack_eitr", new Tuple<float, float, float, bool>(24, 0, 50, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(0, 0, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "YggdrasilWood", new Tuple<int, int>(24, 12) },
                    { "Silver", new Tuple<int, int>(16, 8) },
                    { "JuteBlue", new Tuple<int, int>(14, 7) },
                    { "Eitr", new Tuple<int, int>(12, 6) },
                },
                new Dictionary<string, bool>()
                {
                }
            );

            // Druidic Staff of poison
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Druidic Staff of Poison" },
                    { "catagory", "Magics" },
                    { "prefab", "VAStaff_Druid_Poison" },
                    { "sprite", "poison_staff_druidic" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(18, 0, 48, true) },
                    { "poison", new Tuple<float, float, float, bool>(45, 0, 120, true) },
                    { "poison_per_level", new Tuple<float, float, float, bool>(4, 0, 20, true) },
                    { "blunt", new Tuple<float, float, float, bool>(20, 0, 200, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(2, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(45, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(22, 0, 50, true) },
                    { "primary_attack_eitr", new Tuple<float, float, float, bool>(0, 0, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(24, 12) },
                    { "Guck", new Tuple<int, int>(12, 8) },
                    { "LeatherScraps", new Tuple<int, int>(8, 4) },
                    { "TrophyBlob", new Tuple<int, int>(2, 1) },
                },
                new Dictionary<string, bool>()
                {
                }
            );

            // Druidic Staff of spirit
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Druidic Staff of Spirit" },
                    { "catagory", "Magics" },
                    { "prefab", "VAStaff_Druid_Spirit" },
                    { "sprite", "spirit_staff_druid" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(18, 0, 48, true) },
                    { "spirit", new Tuple<float, float, float, bool>(30, 0, 120, true) },
                    { "spirit_per_level", new Tuple<float, float, float, bool>(4, 0, 20, true) },
                    { "blunt", new Tuple<float, float, float, bool>(15, 0, 200, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(1, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(45, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(18, 0, 50, true) },
                    { "primary_attack_eitr", new Tuple<float, float, float, bool>(0, 0, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "RoundLog", new Tuple<int, int>(24, 12) },
                    { "GreydwarfEye", new Tuple<int, int>(24, 18) },
                    { "LeatherScraps", new Tuple<int, int>(8, 4) },
                    { "TrophyGreydwarfShaman", new Tuple<int, int>(2, 1) },
                },
                new Dictionary<string, bool>()
                {
                }
            );

            // Druidic Staff of Ice
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Druidic Staff of Ice" },
                    { "catagory", "Magics" },
                    { "prefab", "VAStaff_Druid_Ice" },
                    { "sprite", "ice_staff_druidic" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(18, 0, 48, true) },
                    { "frost", new Tuple<float, float, float, bool>(15, 0, 120, true) },
                    { "frost_per_level", new Tuple<float, float, float, bool>(1, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(45, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(10, 0, 50, true) },
                    { "primary_attack_eitr", new Tuple<float, float, float, bool>(0, 0, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(24, 12) },
                    { "Crystal", new Tuple<int, int>(18, 12) },
                    { "JuteRed", new Tuple<int, int>(8, 4) },
                    { "TrophyHatchling", new Tuple<int, int>(2, 1) },
                },
                new Dictionary<string, bool>()
                {
                }
            );

            // Druidic Staff of Fire
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Druidic Staff of Fire" },
                    { "catagory", "Magics" },
                    { "prefab", "VAStaff_Druid_Fire" },
                    { "sprite", "fire_staff_druidic" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(18, 0, 48, true) },
                    { "fire", new Tuple<float, float, float, bool>(55, 0, 120, true) },
                    { "fire_per_level", new Tuple<float, float, float, bool>(5, 0, 20, true) },
                    { "blunt", new Tuple<float, float, float, bool>(25, 0, 200, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(2, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(45, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(35, 0, 50, true) },
                    { "primary_attack_eitr", new Tuple<float, float, float, bool>(0, 0, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(24, 12) },
                    { "Iron", new Tuple<int, int>(12, 8) },
                    { "JuteRed", new Tuple<int, int>(8, 4) },
                    { "TrophyGoblinShaman", new Tuple<int, int>(1, 1) },
                },
                new Dictionary<string, bool>()
                {
                }
            );
        }

        private void LoadPickaxes()
        {
            // Bone Blood Pickaxe
            new ValArmoryItem(
                EmbeddedResourceBundle,
                new Dictionary<string, string>() {
                    { "name", "Bone Blood Pickaxe" },
                    { "catagory", "Pickaxes" },
                    { "prefab", "VABlood_Bones_pickaxe" },
                    { "sprite", "blood_bone_pickaxe" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "pierce", new Tuple<float, float, float, bool>(32, 0, 200, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { "pickaxe", new Tuple<float, float, float, bool>(32, 0, 200, true) },
                    { "pickaxe_per_level", new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(50, 0, 100, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(6, 0, 50, true) },
                    { "primary_attack_flat_health_cost", new Tuple<float, float, float, bool>(4, 0, 25, true) },
                    { "primary_attack_percent_health_cost", new Tuple<float, float, float, bool>(0, 0, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(4, 0, 50, true) },
                    { "secondary_attack_flat_health_cost", new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { "secondary_attack_percent_health_cost", new Tuple<float, float, float, bool>(0, 0, 50, true) },
                    
                    { "secondary_attack_speed", new Tuple<float, float, float, bool>(100, 1, 300, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "RoundLog", new Tuple<int, int>(12, 8) },
                    { "BoneFragments", new Tuple<int, int>(20, 14) },
                    { "Bronze", new Tuple<int, int>(4, 2) },
                    { "TrophySkeleton", new Tuple<int, int>(2, 0) },
                },
                new Dictionary<string, bool>()
                {
                }
            );
        }

        private void LoadNonCraftables()
        {
            // Arrow resources
            new NonCraftablePrefab(EmbeddedResourceBundle, "Assets/Custom/Weapons/Arrows/VAbow_projectile_ancient.prefab");
            new NonCraftablePrefab(EmbeddedResourceBundle, "Assets/Custom/Weapons/Arrows/VAbow_projectile_bone.prefab");
            new NonCraftablePrefab(EmbeddedResourceBundle, "Assets/Custom/Weapons/Bows/projectiles/blood_projectile.prefab");
            new NonCraftablePrefab(EmbeddedResourceBundle, "Assets/Custom/Weapons/Arrows/VAbow_projectile_boltBronze.prefab");
            new NonCraftablePrefab(EmbeddedResourceBundle, "Assets/Custom/Weapons/Arrows/VAbow_projectile_boltFrost.prefab");
            new NonCraftablePrefab(EmbeddedResourceBundle, "Assets/Custom/Weapons/Arrows/VAbow_projectile_boltObsidian.prefab");
            new NonCraftablePrefab(EmbeddedResourceBundle, "Assets/Custom/Weapons/Arrows/VAbow_projectile_boltPoison.prefab");
            new NonCraftablePrefab(EmbeddedResourceBundle, "Assets/Custom/Weapons/Arrows/VAbow_projectile_boltSurtling.prefab");
            new NonCraftablePrefab(EmbeddedResourceBundle, "Assets/Custom/Weapons/Arrows/VAbow_projectile_greenmetal.prefab");
            new NonCraftablePrefab(EmbeddedResourceBundle, "Assets/Custom/Weapons/Arrows/VAbow_projectile_surtlingfire.prefab");
            // Magic projectiles
            new NonCraftablePrefab(EmbeddedResourceBundle, "Assets/Custom/Weapons/Magics/projectiles/staff_ice_projectile.prefab");
            new NonCraftablePrefab(EmbeddedResourceBundle, "Assets/Custom/Weapons/Magics/projectiles/staff_poison_projectile.prefab");
            new NonCraftablePrefab(EmbeddedResourceBundle, "Assets/Custom/Weapons/Magics/projectiles/staff_spirit_projectile.prefab");
            new NonCraftablePrefab(EmbeddedResourceBundle, "Assets/Custom/Weapons/Magics/projectiles/vfx_poison_explosion.prefab");
            new NonCraftablePrefab(EmbeddedResourceBundle, "Assets/Custom/Weapons/Magics/projectiles/vfx_spirit_explosion.prefab");
        }
    }

    class NonCraftablePrefab
    {
        // full_path like: Assets/Custom/Pieces/VFortress/VF_creature_notify.prefab
        public NonCraftablePrefab(AssetBundle EmbeddedResourceBundle, String full_path)
        {
            GameObject game_obj = EmbeddedResourceBundle.LoadAsset<GameObject>($"{full_path}");
            CustomPrefab prefab_obj = new CustomPrefab(game_obj, false);
            PrefabManager.Instance.AddPrefab(prefab_obj);
        }
    }

    class ValArmoryItem
    {
        String[] allowed_catagories = {"Arrows", "Atgeirs", "Axes", "Bows", "Hammers", "Shields", "Swords", "Spears", "Daggers", "Maces", "Fists", "Pickaxes", "Magics" };
        String[] damage_types = {"blunt", "pierce", "slash", "fire", "spirit", "lightning", "frost", "poison", "chop" };
        String[] crafting_stations = { "forge", "piece_workbench", "blackforge", "piece_artisanstation" };
        /// <summary>
        /// 
        /// </summary>
        /// <param name="EmbeddedResourceBundle"> The embedded assets</param>
        /// <param name="metadata">Key(string)-Value(string) dictionary of item metadata eg: "name" = "Green Metal Arrow"</param>
        /// <param name="itemdata">Key(string)-Value(Tuple) dictionary of item metadata with config metadata eg: "blunt" = < 15(value), 0(min), 200(max), true(cfg_enable_flag) > </param>
        /// <param name="itemtoggles">Key(string)-Value(bool) dictionary of true/false config toggles for this item.</param>
        /// <param name="recipedata">Key(string)-Value(Tuple) dictionary of recipe requirements (limit 4) eg: "SerpentScale" = < 3(creation requirement), 2(levelup requirement)> </param>
        public ValArmoryItem(
            AssetBundle EmbeddedResourceBundle,
            Dictionary<String, String> metadata,
            Dictionary<String, Tuple<float, float, float, bool>> itemdata,
            Dictionary<String, bool> itemtoggles,
            Dictionary<String, Tuple<int, int>> recipedata,
            Dictionary<String, bool> scriptdata
            )
        {
            // Validate inputs are valid
            if (!allowed_catagories.Contains(metadata["catagory"])) { throw new ArgumentException($"Catagory {metadata["catagory"]} must be an allowed catagory: {allowed_catagories}"); }
            if (!metadata.ContainsKey("name")) { throw new ArgumentException($"Item must have a name"); }
            if (!metadata.ContainsKey("prefab")) { throw new ArgumentException($"Item must have a prefab"); }
            if (!metadata.ContainsKey("sprite")) { throw new ArgumentException($"Item must have a sprite"); }
            if (!metadata.ContainsKey("craftedAt")) { throw new ArgumentException($"Item must have a craftedAt"); }
            if (!itemdata.ContainsKey("amount")) { throw new ArgumentException($"Item must have an amount to be crafted"); }
            //if (!crafting_stations.Contains(metadata["craftedAt"])) { throw new ArgumentException($"Catagory {metadata["craftedAt"]} must be a valid crafting station: {crafting_stations}"); }
            if (recipedata.Count > 4) { throw new ArgumentException($"Recipe data can't have more than 4 requirements"); }
            if (!itemtoggles.ContainsKey("enabled")) { itemtoggles.Add("enabled", true); }
            if (!itemtoggles.ContainsKey("craftable")) { itemtoggles.Add("craftable", true); }
            // needed metadata - item name without spaces
            metadata["short_item_name"] = string.Join("", metadata["name"].Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));

            // create config
            if (VAConfig.EnableDebugMode.Value == true) { Logger.LogDebug($"Creating Configuration Values for {metadata["name"]}"); }
            CreateAndLoadConfigValues(metadata, itemdata, itemtoggles, recipedata);

            // If the item is not enabled we do not load it
            if (itemtoggles["enabled"] != false)
            {
                // load assets
                if (VAConfig.EnableDebugMode.Value == true) { Logger.LogDebug($"Loading bundled assets for {metadata["name"]}"); }
                GameObject prefab = EmbeddedResourceBundle.LoadAsset<GameObject>($"Assets/Custom/Weapons/{metadata["catagory"]}/{metadata["prefab"]}.prefab");
                Sprite sprite = EmbeddedResourceBundle.LoadAsset<Sprite>($"Assets/Custom/Icons/{metadata["sprite"]}.png");

                // Add scripts
                //foreach(KeyValuePair<String, bool> entry in scriptdata)
                //{
                //    Logger.LogInfo($"Checking script actions for {entry.Key} with {entry.Value}");
                //    if (entry.Value == true && entry.Key == "EtirBuff")
                //    {
                //        Logger.LogInfo($"Adding {entry.Key} to {metadata["prefab"]}");
                //        prefab.AddComponent<EtirBuff>(); 
                //    }
                //}
                

                // modify item/recipe
                if (VAConfig.EnableDebugMode.Value == true) { Logger.LogDebug($"Modifying itemdata for {metadata["name"]}, applying configured values."); }
                ModifyItemData(prefab.GetComponent<ItemDrop>()?.m_itemData, itemdata);
                ModifyItemFlags(prefab.GetComponent<ItemDrop>().m_itemData, itemtoggles);

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
                    Enabled = itemtoggles["craftable"],
                    Icons = new[] { sprite },
                    Requirements = recipe
                };
                if (VAConfig.EnableDebugMode.Value == true) { Logger.LogDebug($"Setting Recipe Data: {recipe.ToArray()}"); }
                AddRecipeForAsset($"VA{metadata["short_item_name"]}", prefab, itemcfg);
            }
            else 
            {
                if (VAConfig.EnableDebugMode.Value == true) { Logger.LogDebug($"{metadata["name"]} is not enabled, and was not loaded."); }
            }
        }

        /// <summary>
        ///  Creates configuration values with automated segmentation on weapon type
        /// </summary>
        /// <param name="Config"></param>
        /// <param name="metadata"></param>
        /// <param name="itemdata"></param>
        /// <param name="itemtoggles"></param>
        private void CreateAndLoadConfigValues(Dictionary<String, String> metadata, Dictionary<String, Tuple<float, float, float, bool>> itemdata, Dictionary<String, bool> itemtoggles, Dictionary<String, Tuple<int, int>> recipedata)
        {
            // Populate defaults if they don't exist
            itemtoggles["enabled"] = VAConfig.BindServerConfig($"{metadata["catagory"]} - {metadata["name"]}", $"{metadata["short_item_name"]}-enabled", itemtoggles["enabled"], $"Enable/Disable the {metadata["name"]}.").Value;
            itemtoggles["craftable"] = VAConfig.BindServerConfig($"{metadata["catagory"]} - {metadata["name"]}", $"{metadata["short_item_name"]}-craftable", itemtoggles["craftable"], $"Enable/Disable the crafting recipe for {metadata["name"]}.").Value;

            // Set and update the crafted at value
            metadata["craftedAt"] = VAConfig.BindServerConfig($"{metadata["catagory"]} - {metadata["name"]}", $"{metadata["short_item_name"]}-CraftedAt", metadata["craftedAt"], $"Where the recipe is crafted at, eg: 'forge', 'piece_workbench', 'blackforge', 'piece_artisanstation'.").Value;

            // Item bolean flag configs
            Dictionary<string, bool> item_toggles_updates = new Dictionary<string, bool> { };

            foreach (KeyValuePair<string, bool> entry in itemtoggles)
            {
                if (VAConfig.EnableDebugMode.Value) { Logger.LogInfo($"Modifying boolflag {entry.Key}"); }
                String cfg_description = $"{entry.Key} enable(true)/disable(false).";
                bool advanced = true;
                if (entry.Key == "enabled") {
                    cfg_description = $"Enable/Disable the {metadata["name"]}.";
                    advanced = false; 
                }
                if (entry.Key == "craftable")
                {
                    cfg_description = $"Enable/Disable the crafting recipe for {metadata["name"]}.";
                    advanced = false;
                }
                item_toggles_updates.Add(entry.Key, VAConfig.BindServerConfig($"{metadata["catagory"]} - {metadata["name"]}", $"{metadata["short_item_name"]}-{entry.Key}", entry.Value, cfg_description, advanced).Value);
            }
            itemtoggles = item_toggles_updates;

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
                current_itemdata_value = VAConfig.BindServerConfig($"{metadata["catagory"]} - {metadata["name"]}", $"{metadata["short_item_name"]}-{entry.Key}", entry.Value.Item1, $"{description}", true, entry.Value.Item2, entry.Value.Item3).Value;
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
            RawRecipe = VAConfig.BindServerConfig($"{metadata["catagory"]} - {metadata["name"]}", $"{metadata["short_item_name"]}-recipe", recipe_cfg, $"Recipe to craft and upgrade costs. Find item ids: https://valheim.fandom.com/wiki/Item_IDs, at most 4 costs. Format: resouce_id,craft_cost,upgrade_cost eg: Wood,8,2|Iron,12,4|LeatherScraps,4,0", true).Value;
            if (VAConfig.EnableDebugMode.Value == true) { Logger.LogInfo($"recieved rawrecipe data: '{RawRecipe}'"); }
            String[] RawRecipeEntries = RawRecipe.Split('|');
            Dictionary<String, Tuple<int, int>> updated_recipe = new Dictionary<String, Tuple<int, int>>();
            // we only clear out the default recipe if there is recipe data provided, otherwise we will continue to use the default recipe
            // TODO: Add a sanity check to ensure that recipe formatting is correct
            if (VAConfig.EnableDebugMode.Value == true)
            {
                Logger.LogInfo($"recipe entries: {RawRecipeEntries.Length} : {RawRecipeEntries}");
            }
            if (RawRecipeEntries.Length >= 1)
            {
                foreach (String recipe_entry in RawRecipeEntries)
                {
                    String[] recipe_segments = recipe_entry.Split(',');
                    if (VAConfig.EnableDebugMode.Value == true)
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
                    if (VAConfig.EnableDebugMode.Value == true) { Logger.LogInfo($"Updated recipe: resouce: {entry.Key} build: {entry.Value.Item1} upgrade: {entry.Value.Item2}"); }
                    recipedata.Add(entry.Key, entry.Value);
                }
            }
            else
            {
                Logger.LogWarning($"Configuration '{metadata["catagory"]} - {metadata["name"]} - {metadata["short_item_name"]}-recipe' was invalid and will be ignored, the default will be used.");
            }
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

                if (VAConfig.EnableDebugMode.Value == true) { Logger.LogInfo($"{name} Item & Recipe Loaded."); }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error while adding Recipe_{name}: {ex.Message}");
            }
        }

        // Right now these need to not exist to be added
        // All weapons/armor with these damage modifiers should not have any to begin with
        private void ModifyItemFlags(ItemDrop.ItemData item, Dictionary<String, bool> itemtoggles)
        {
            foreach(KeyValuePair<String, Boolean> entry in itemtoggles)
            {
                // Skip toggles which are applied as part of adding the item
                if(entry.Key == "craftable" || entry.Key == "enabled")
                {
                    continue;
                }
                if(entry.Value == false) { continue; }

                switch (entry.Key)
                {
                    case "resistPoison":
                        item.m_shared.m_damageModifiers.Add(new HitData.DamageModPair { m_modifier = HitData.DamageModifier.Resistant, m_type = HitData.DamageType.Poison });
                        break;
                    case "resistSpirit":
                        item.m_shared.m_damageModifiers.Add(new HitData.DamageModPair { m_modifier = HitData.DamageModifier.Resistant, m_type = HitData.DamageType.Spirit });
                        break;
                    case "resistFire":
                        item.m_shared.m_damageModifiers.Add(new HitData.DamageModPair { m_modifier = HitData.DamageModifier.Resistant, m_type = HitData.DamageType.Fire });
                        break;
                    case "resistElemental":
                        item.m_shared.m_damageModifiers.Add(new HitData.DamageModPair { m_modifier = HitData.DamageModifier.Resistant, m_type = HitData.DamageType.Elemental });
                        break;
                    case "resistFrost":
                        item.m_shared.m_damageModifiers.Add(new HitData.DamageModPair { m_modifier = HitData.DamageModifier.Resistant, m_type = HitData.DamageType.Frost });
                        break;
                    case "resistLightning":
                        item.m_shared.m_damageModifiers.Add(new HitData.DamageModPair { m_modifier = HitData.DamageModifier.Resistant, m_type = HitData.DamageType.Lightning });
                        break;
                }

            }
        }

        private void ModifyItemData(ItemDrop.ItemData item, Dictionary<String, Tuple<float, float, float, bool>> itemdata)
        {
            foreach (KeyValuePair<string, Tuple<float, float, float, bool>> entry in itemdata)
            {
                if (VAConfig.EnableDebugMode.Value == true)
                {
                    Logger.LogInfo($"Modifying type: {entry.Key} to {entry.Value.Item1}");
                }
                switch (entry.Key)
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
                    case "block_force":
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
                    case "primary_attack_eitr":
                        item.m_shared.m_attack.m_attackEitr = entry.Value.Item1;
                        break;
                    case "secondary_attack_stamina":
                        item.m_shared.m_secondaryAttack.m_attackStamina = entry.Value.Item1;
                        break;
                    case "secondary_attack_eitr":
                        item.m_shared.m_secondaryAttack.m_attackEitr = entry.Value.Item1;
                        break;
                    case "draw_stamina_drain":
                        item.m_shared.m_attack.m_drawStaminaDrain = entry.Value.Item1;
                        break;
                    // Blood costs for attacks / usage
                    case "primary_attack_flat_health_cost":
                        item.m_shared.m_attack.m_attackHealth = entry.Value.Item1;
                        break;
                    case "primary_attack_percent_health_cost":
                        item.m_shared.m_attack.m_attackHealthPercentage = entry.Value.Item1;
                        break;
                    case "secondary_attack_flat_health_cost":
                        item.m_shared.m_secondaryAttack.m_attackHealth = entry.Value.Item1;
                        break;
                    case "secondary_attack_percent_health_cost":
                        item.m_shared.m_secondaryAttack.m_attackHealthPercentage = entry.Value.Item1;
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
                    // Reload speed
                    case "bow_draw_speed":
                        item.m_shared.m_attack.m_drawDurationMin *= (entry.Value.Item1 / 100);
                        break;
                    case "crossbow_reload_speed":
                        item.m_shared.m_attack.m_reloadTime *= (entry.Value.Item1 / 100);
                        break;
                    default:
                    break;
                }
            }
        }


    }
}
