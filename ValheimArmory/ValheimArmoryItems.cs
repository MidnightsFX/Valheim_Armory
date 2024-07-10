
using Jotunn.Entities;
using Jotunn.Managers;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
using static ValheimArmory.common.JotunnItemFactory;
using Logger = Jotunn.Logger;

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
            // Greenmetal Arrows					forge lvl 3
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Black Metal Arrow" },
                    { "catagory", "Arrows" },
                    { "prefab", "VAArrowGreenMetal" },
                    { "sprite", "arrow_greenmetal" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { "blunt", new Tuple<float, float, float, bool>(52, 0, 200, true) },
                    { "pierce", new Tuple<float, float, float, bool>(26, 0, 200, true) }
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(8, 0) },
                    { "BlackMetal", new Tuple<int, int>(2, 0) },
                    { "Feathers", new Tuple<int, int>(2, 0) }
                },
                new Dictionary<string, int>
                {
                    { "stationRequiredLevel", 3 }
                }
            );

            // Bone Arrows							workbench lvl 3(obsidian)
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Bone Arrow" },
                    { "catagory", "Arrows" },
                    { "prefab", "VAArrowBone" },
                    { "sprite", "bone_arrow" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { "pierce", new Tuple<float, float, float, bool>(32, 0, 200, true) }
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "BoneFragments", new Tuple<int, int>(8, 0) },
                    { "Feathers", new Tuple<int, int>(2, 0) }
                },
                new Dictionary<string, int>
                {
                    { "stationRequiredLevel", 3 }
                }
            );

            // Surtling Fire Arrow					workbench lvl 3
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Surtling Fire Arrow" },
                    { "catagory", "Arrows" },
                    { "prefab", "VAarrow_surtling_fire" },
                    { "sprite", "surtlingcore_arrow" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { "fire", new Tuple<float, float, float, bool>(52, 0, 200, true) },
                    { "pierce", new Tuple<float, float, float, bool>(26, 0, 200, true) }
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(8, 0) },
                    { "Obsidian", new Tuple<int, int>(4, 0) },
                    { "Feathers", new Tuple<int, int>(2, 0) },
                    { "SurtlingCore", new Tuple<int, int>(1, 0) }
                },
                new Dictionary<string, int>
                {
                    { "stationRequiredLevel", 3 }
                }
            );

            // Ancient Wood Arrow					workbench lvl 3
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Ancient Wood Arrow" },
                    { "catagory", "Arrows" },
                    { "prefab", "VAarrowancient" },
                    { "sprite", "ancient_arrow" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { "pierce", new Tuple<float, float, float, bool>(37, 0, 200, true) }
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(8, 0) },
                    { "Feathers", new Tuple<int, int>(2, 0) }
                },
                new Dictionary<string, int>
                {
                    { "stationRequiredLevel", 3 }
                }
            );

            // Chitin Arrow							workbench lvl 3
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Chitin Arrow" },
                    { "catagory", "Arrows" },
                    { "prefab", "VAchitinarrow" },
                    { "sprite", "arrow_chitin" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { "pierce", new Tuple<float, float, float, bool>(12, 0, 200, true) },
                    { "blunt", new Tuple<float, float, float, bool>(35, 0, 200, true) }
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(8, 0) },
                    { "Chitin", new Tuple<int, int>(2, 0) },
                    { "Feathers", new Tuple<int, int>(2, 0) }
                },
                new Dictionary<string, int>
                {
                    { "stationRequiredLevel", 3 }
                }
            );

            // Wood Crossbow Bolt					workbench lvl 1
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Wood Bolt" },
                    { "catagory", "Arrows" },
                    { "prefab", "VABoltWood" },
                    { "sprite", "bolt_wood" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { "pierce", new Tuple<float, float, float, bool>(22, 0, 200, true) }
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(8, 0) }
                },
                new Dictionary<string, int>
                {
                    { "stationRequiredLevel", 1 }
                }
            );

            // Corewood Crossbow Bolt					workbench lvl 3
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Corewood Bolt" },
                    { "catagory", "Arrows" },
                    { "prefab", "VABoltCoreWood" },
                    { "sprite", "bolt_corewood" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { "pierce", new Tuple<float, float, float, bool>(37, 0, 200, true) }
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "RoundLog", new Tuple<int, int>(8, 0) },
                    { "Feathers", new Tuple<int, int>(2, 0) }
                },
                new Dictionary<string, int>
                {
                    { "stationRequiredLevel", 3 }
                }
            );

            // Bronze Bolt							forge lvl 1
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Bronze Bolt" },
                    { "catagory", "Arrows" },
                    { "prefab", "VAbolt_bronze" },
                    { "sprite", "bronze_bolt" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { "pierce", new Tuple<float, float, float, bool>(32, 0, 200, true) }
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(8, 0) },
                    { "Bronze", new Tuple<int, int>(1, 0) },
                    { "Feathers", new Tuple<int, int>(2, 0) }
                },
                new Dictionary<string, int>
                {
                    { "stationRequiredLevel", 1 }
                }
            );

            // Iron Poison Bolt						forge lvl 2
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Poison Bolt" },
                    { "catagory", "Arrows" },
                    { "prefab", "VAbolt_poison" },
                    { "sprite", "poison_bolt" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { "poison", new Tuple<float, float, float, bool>(52, 0, 200, true) },
                    { "pierce", new Tuple<float, float, float, bool>(26, 0, 200, true) }
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(8, 0) },
                    { "Iron", new Tuple<int, int>(1, 0) },
                    { "Feathers", new Tuple<int, int>(2, 0) },
                    { "Ooze", new Tuple<int, int>(1, 0) }
                },
                new Dictionary<string, int>
                {
                    { "stationRequiredLevel", 2 }
                }
            );

            // Obsidian Bolt						workbench lvl 3
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Obsidian Bolt" },
                    { "catagory", "Arrows" },
                    { "prefab", "VAObsidianBolt" },
                    { "sprite", "obsidian_bolt" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { "pierce", new Tuple<float, float, float, bool>(52, 0, 200, true) }
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(8, 0) },
                    { "Obsidian", new Tuple<int, int>(4, 0) },
                    { "Feathers", new Tuple<int, int>(2, 0) }
                },
                new Dictionary<string, int>
                {
                    { "stationRequiredLevel", 3 }
                }
            );

            // Silver Ice Bolt						forge lvl 3
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Frost Bolt" },
                    { "catagory", "Arrows" },
                    { "prefab", "VAbolt_frost" },
                    { "sprite", "ice_bolt" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { "frost", new Tuple<float, float, float, bool>(52, 0, 200, true) },
                    { "spirit", new Tuple<float, float, float, bool>(20, 0, 200, true) },
                    { "pierce", new Tuple<float, float, float, bool>(26, 0, 200, true) }
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(8, 0) },
                    { "Silver", new Tuple<int, int>(1, 0) },
                    { "Feathers", new Tuple<int, int>(2, 0) },
                    { "FreezeGland", new Tuple<int, int>(1, 0) }
                },
                new Dictionary<string, int>
                {
                    { "stationRequiredLevel", 3 }
                }
            );

            // Iron Surtling bolt					forge lvl 2
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Surtling Core Bolt" },
                    { "catagory", "Arrows" },
                    { "prefab", "VASurtlingBolt" },
                    { "sprite", "surtling_bolt" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { "fire", new Tuple<float, float, float, bool>(52, 0, 200, true) },
                    { "pierce", new Tuple<float, float, float, bool>(26, 0, 200, true) }
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(8, 0) },
                    { "Iron", new Tuple<int, int>(1, 0) },
                    { "Feathers", new Tuple<int, int>(2, 0) },
                    { "SurtlingCore", new Tuple<int, int>(1, 0) }
                },
                new Dictionary<string, int>
                {
                    { "stationRequiredLevel", 2 }
                }
            );

            // Needle bolt					forge lvl 4
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Needle Bolt" },
                    { "catagory", "Arrows" },
                    { "prefab", "VABoltNeedle" },
                    { "sprite", "needle_bolt" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { "pierce", new Tuple<float, float, float, bool>(56, 0, 200, true) }
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Needle", new Tuple<int, int>(8, 0) },
                    { "Feathers", new Tuple<int, int>(2, 0) },
                },
                new Dictionary<string, int>
                {
                    { "stationRequiredLevel", 4 }
                }
            );

            // Fire bolt					forge lvl 2
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Fire Bolt" },
                    { "catagory", "Arrows" },
                    { "prefab", "VAFireBolt" },
                    { "sprite", "surtling_bolt" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { "pierce", new Tuple<float, float, float, bool>(22, 0, 200, true) },
                    { "fire", new Tuple<float, float, float, bool>(34, 0, 200, true) }
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(8, 0) },
                    { "Resin", new Tuple<int, int>(8, 0) },
                    { "Feathers", new Tuple<int, int>(2, 0) },
                },
                new Dictionary<string, int>
                {
                    { "stationRequiredLevel", 4 }
                }
            );
        }

        private void LoadBows()
        {
            // Heavy Blood Bone Bow
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Carapace Blood Bow" },
                    { "catagory", "Bows" },
                    { "prefab", "VAHeavy_Blood_Bone_Bow" },
                    { "sprite", "blood_bone_bow_heavy" },
                    { "craftedAt", "piece_magetable" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "pierce", new Tuple<float, float, float, bool>(92, 0, 300, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "spirit", new Tuple<float, float, float, bool>(24, 0, 200, true) },
                    { "spirit_per_level", new Tuple<float, float, float, bool>(2, 0, 20, true) },
                    { "block", new Tuple<float, float, float, bool>(5, 0, 60, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(20, 0, 300, true) },
                    { "draw_stamina_drain", new Tuple<float, float, float, bool>(6, 1, 50, true) },
                    { "primary_attack_flat_health_cost", new Tuple<float, float, float, bool>(12, 0, 25, true) },
                    { "primary_attack_percent_health_cost", new Tuple<float, float, float, bool>(0, 0, 50, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { "bow_draw_speed", new Tuple<float, float, float, bool>(2, 0.01f, 2, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "YggdrasilWood", new Tuple<int, int>(14, 7) },
                    { "Iron", new Tuple<int, int>(10, 6) },
                    { "Carapace", new Tuple<int, int>(24, 10) },
                    { "TrophyTick", new Tuple<int, int>(2, 0) },
                    { "Eitr", new Tuple<int, int>(0, 10) }
                }
            );

            // Blood Bone Bow
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Blood Bone Bow" },
                    { "catagory", "Bows" },
                    { "prefab", "VABlood_bone_bow" },
                    { "sprite", "bone_bow" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "pierce", new Tuple<float, float, float, bool>(60, 0, 300, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "spirit", new Tuple<float, float, float, bool>(18, 0, 200, true) },
                    { "spirit_per_level", new Tuple<float, float, float, bool>(2, 0, 20, true) },
                    { "block", new Tuple<float, float, float, bool>(3, 0, 60, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(20, 0, 300, true) },
                    { "draw_stamina_drain", new Tuple<float, float, float, bool>(4, 1, 50, true) },
                    { "primary_attack_flat_health_cost", new Tuple<float, float, float, bool>(8, 0, 25, true) },
                    { "primary_attack_percent_health_cost", new Tuple<float, float, float, bool>(0, 0, 50, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { "bow_draw_speed", new Tuple<float, float, float, bool>(2, 0.01f, 2, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(10, 5) },
                    { "Silver", new Tuple<int, int>(10, 5) },
                    { "BoneFragments", new Tuple<int, int>(20, 10) },
                    { "TrophyUlv", new Tuple<int, int>(2, 0) }
                }
            );

            // Bronze Arbalist
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Bronze Arbelist" },
                    { "catagory", "Bows" },
                    { "prefab", "VAArbalistBronze" },
                    { "sprite", "bronze_crossbow_upright" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "pierce", new Tuple<float, float, float, bool>(105, 0, 300, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(200, 0, 300, true) },
                    { "block", new Tuple<float, float, float, bool>(3, 0, 60, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                    { "durability", new Tuple<float, float, float, bool>(100, 0, 300, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { "crossbow_reload_speed", new Tuple<float, float, float, bool>(3.5f, 0.01f, 3.5f, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(10, 5) },
                    { "Bronze", new Tuple<int, int>(20, 10) },
                    { "Tar", new Tuple<int, int>(10, 2) },
                    { "LinenThread", new Tuple<int, int>(2, 2) }
                }
            );

            // Antler Bow
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Eikthyrs Bow" },
                    { "catagory", "Bows" },
                    { "prefab", "VAAntler_Bow" },
                    { "sprite", "antler_bow" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "pierce", new Tuple<float, float, float, bool>(32, 0, 120, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "lightning", new Tuple<float, float, float, bool>(10, 0, 90, true) },
                    { "lightning_per_level", new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(5, 0, 50, true) },
                    { "block", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                    { "bow_draw_speed", new Tuple<float, float, float, bool>(2.5f, 0.01f, 2.5f, true) },
                    { "durability", new Tuple<float, float, float, bool>(100, 0, 300, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(15, 5) },
                    { "Resin", new Tuple<int, int>(20, 10) },
                    { "HardAntler", new Tuple<int, int>(3, 3) },
                    { "TrophyEikthyr", new Tuple<int, int>(1, 1) }
                }
            );

            // Bronze Crossbow
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Bronze Crossbow" },
                    { "catagory", "Bows" },
                    { "prefab", "VACrossbowBronze" },
                    { "sprite", "bronze_crossbow2" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "pierce", new Tuple<float, float, float, bool>(80, 0, 300, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "block", new Tuple<float, float, float, bool>(3, 0, 60, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(150, 0, 300, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                    { "durability", new Tuple<float, float, float, bool>(100, 0, 300, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { "crossbow_reload_speed", new Tuple<float, float, float, bool>(3.5f, 0.01f, 3.5f, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(10, 5) },
                    { "RoundLog", new Tuple<int, int>(10, 5) },
                    { "Bronze", new Tuple<int, int>(4, 0) },
                    { "DeerHide", new Tuple<int, int>(2, 2) }
                }
            );

            // Elder Crossbow
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Elders Reach" },
                    { "catagory", "Bows" },
                    { "prefab", "VACrossbowElder" },
                    { "sprite", "elder_crossbow" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "pierce", new Tuple<float, float, float, bool>(80, 0, 300, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "spirit", new Tuple<float, float, float, bool>(20, 0, 300, true) },
                    { "spirit_per_level", new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { "block", new Tuple<float, float, float, bool>(3, 0, 60, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(150, 0, 300, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                    { "durability", new Tuple<float, float, float, bool>(100, 0, 300, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { "crossbow_reload_speed", new Tuple<float, float, float, bool>(3.5f, 0.01f, 3.5f, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Bronze", new Tuple<int, int>(4, 2) },
                    { "RoundLog", new Tuple<int, int>(20, 10) },
                    { "CryptKey", new Tuple<int, int>(1, 0) },
                    { "TrophyTheElder", new Tuple<int, int>(1, 0) },
                }
            );

            // Moder Crossbow
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Moder Crossbow" },
                    { "catagory", "Bows" },
                    { "prefab", "VACrossbowModer" },
                    { "sprite", "moder_crossbow" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "pierce", new Tuple<float, float, float, bool>(150, 0, 300, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "frost", new Tuple<float, float, float, bool>(25, 0, 300, true) },
                    { "frost_per_level", new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { "block", new Tuple<float, float, float, bool>(3, 0, 60, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(200, 0, 300, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                    { "durability", new Tuple<float, float, float, bool>(100, 0, 300, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { "crossbow_reload_speed", new Tuple<float, float, float, bool>(3.5f, 0.01f, 3.5f, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(10, 5) },
                    { "Obsidian", new Tuple<int, int>(20, 10) },
                    { "DragonTear", new Tuple<int, int>(10, 0) },
                    { "TrophyDragonQueen", new Tuple<int, int>(1, 0) },
                    { "Silver", new Tuple<int, int>(0, 6) },
                }
            );

            // Queen Bow
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Queens Greatbow" },
                    { "catagory", "Bows" },
                    { "prefab", "VAQueen_bow" },
                    { "sprite", "queen_bow" },
                    { "craftedAt", "blackforge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "pierce", new Tuple<float, float, float, bool>(72, 0, 200, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "poison", new Tuple<float, float, float, bool>(25, 0, 90, true) },
                    { "poison_per_level", new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { "lightning", new Tuple<float, float, float, bool>(30, 0, 99, true) },
                    { "lightning_per_level", new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(25, 0, 50, true) },
                    { "block", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "durability", new Tuple<float, float, float, bool>(100, 0, 300, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                    { "bow_draw_speed", new Tuple<float, float, float, bool>(3f, 0.01f, 3f, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "YggdrasilWood", new Tuple<int, int>(10, 5) },
                    { "Eitr", new Tuple<int, int>(20, 10) },
                    { "JuteBlue", new Tuple<int, int>(4, 0) },
                    { "TrophySeekerQueen", new Tuple<int, int>(1, 0) },
                    { "Carapace", new Tuple<int, int>(0, 4) },
                }
            );
        }

        private void LoadSwords()
        {
            // Blackmetal Greatsword
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Blackmetal Greatsword" },
                    { "catagory", "Swords" },
                    { "prefab", "VABlackmetal_greatsword" },
                    { "sprite", "blackmetal_greatsword" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "slash", new Tuple<float, float, float, bool>(125, 0, 250, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(65, 0, 120, true) },
                    { "block", new Tuple<float, float, float, bool>(22, 0, 60, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(17, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(34, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "BlackMetal", new Tuple<int, int>(30, 10) },
                    { "LinenThread", new Tuple<int, int>(10, 5) },
                    { "FineWood", new Tuple<int, int>(6, 3) }
                }
            );
            // Abyssal Sword
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Abyssal Sword" },
                    { "catagory", "Swords" },
                    { "prefab", "VASwordChitin" },
                    { "sprite", "chitin_sword" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "blunt", new Tuple<float, float, float, bool>(20, 0, 90, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(4, 0, 25, true) },
                    { "slash", new Tuple<float, float, float, bool>(25, 0, 120, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(2, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(40, 0, 120, true) },
                    { "block", new Tuple<float, float, float, bool>(18, 0, 60, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(10, 1, 30, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(2, 1) },
                    { "Chitin", new Tuple<int, int>(30, 15) },
                    { "DeerHide", new Tuple<int, int>(2, 0) }
                }
            );

            // Antler Sword
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Eikthyrs Sword" },
                    { "catagory", "Swords" },
                    { "prefab", "VAAntler_Sword" },
                    { "sprite", "antler_sword" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "slash", new Tuple<float, float, float, bool>(20, 0, 90, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(2, 0, 20, true) },
                    { "blunt", new Tuple<float, float, float, bool>(10, 0, 90, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(4, 0, 20, true) },
                    { "lightning", new Tuple<float, float, float, bool>(10, 0, 120, true) },
                    { "lightning_per_level", new Tuple<float, float, float, bool>(5, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(40, 0, 120, true) },
                    { "block", new Tuple<float, float, float, bool>(8, 0, 60, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(8, 1, 30, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(16, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(3, 1) },
                    { "Resin", new Tuple<int, int>(16, 8) },
                    { "HardAntler", new Tuple<int, int>(3, 3) },
                    { "TrophyEikthyr", new Tuple<int, int>(1, 1) }
                }
            );

            // Vine Sword
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Elders Balance" },
                    { "catagory", "Swords" },
                    { "prefab", "VAVine_Sword" },
                    { "sprite", "vine_sword" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "slash", new Tuple<float, float, float, bool>(35, 0, 90, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { "spirit", new Tuple<float, float, float, bool>(20, 0, 120, true) },
                    { "spirit_per_level", new Tuple<float, float, float, bool>(5, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(40, 0, 120, true) },
                    { "block", new Tuple<float, float, float, bool>(12, 0, 60, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(8, 1, 30, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(16, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Bronze", new Tuple<int, int>(2, 1) },
                    { "Stone", new Tuple<int, int>(16, 8) },
                    { "CryptKey", new Tuple<int, int>(1, 0) },
                    { "TrophyTheElder", new Tuple<int, int>(1, 0) },
                    { "RoundLog", new Tuple<int, int>(0, 4) }
                }
            );

            // Ice Sword
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Moders Grasp" },
                    { "catagory", "Swords" },
                    { "prefab", "VASwordModer" },
                    { "sprite", "moder_sword" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "slash", new Tuple<float, float, float, bool>(35, 0, 90, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(2, 0, 20, true) },
                    { "pierce", new Tuple<float, float, float, bool>(30, 0, 90, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(4, 0, 20, true) },
                    { "frost", new Tuple<float, float, float, bool>(25, 0, 120, true) },
                    { "frost_per_level", new Tuple<float, float, float, bool>(5, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(40, 0, 120, true) },
                    { "block", new Tuple<float, float, float, bool>(30, 0, 60, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(12, 1, 30, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(24, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(4, 2) },
                    { "Obsidian", new Tuple<int, int>(30, 15) },
                    { "DragonTear", new Tuple<int, int>(10, 0) },
                    { "TrophyDragonQueen", new Tuple<int, int>(1, 0) },
                    { "Silver", new Tuple<int, int>(0, 2) },
                    { "JuteRed", new Tuple<int, int>(0, 2) }
                }
            );

            // Bronze Greatsword
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Bronze Greatsword" },
                    { "catagory", "Swords" },
                    { "prefab", "VAbronze_greatsword" },
                    { "sprite", "bronze_greatsword_reforged" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "slash", new Tuple<float, float, float, bool>(50, 0, 200, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(55, 0, 160, true) },
                    { "block", new Tuple<float, float, float, bool>(22, 0, 60, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(12, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(24, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(4, 0) },
                    { "Bronze", new Tuple<int, int>(20, 10) },
                    { "DeerHide", new Tuple<int, int>(3, 0) }
                }
            );

            // Iron Greatsword
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Iron Greatsword" },
                    { "catagory", "Swords" },
                    { "prefab", "VAiron_greatsword" },
                    { "sprite", "iron_greatsword_reforged" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "slash", new Tuple<float, float, float, bool>(75, 0, 250, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(55, 0, 160, true) },
                    { "block", new Tuple<float, float, float, bool>(28, 0, 60, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(14, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(28, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(15, 5) },
                    { "Iron", new Tuple<int, int>(30, 15) },
                    { "LeatherScraps", new Tuple<int, int>(4, 0) }
                }
            );

            // Silver Greatsword
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Silver Greatsword" },
                    { "catagory", "Swords" },
                    { "prefab", "VAsilver_greatsword" },
                    { "sprite", "silver_greatsword_reforged" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "slash", new Tuple<float, float, float, bool>(100, 0, 300, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { "spirit", new Tuple<float, float, float, bool>(30, 0, 120, true) },
                    { "spirit_per_level", new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(55, 0, 160, true) },
                    { "block", new Tuple<float, float, float, bool>(40, 0, 60, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(16, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(32, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(10, 5) },
                    { "Silver", new Tuple<int, int>(25, 10) },
                    { "Iron", new Tuple<int, int>(4, 2) },
                    { "LeatherScraps", new Tuple<int, int>(3, 1) }
                }

            );

            // Bonemass Greatsword
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Bonemasses Greatsword" },
                    { "catagory", "Swords" },
                    { "prefab", "VABonemassGreatsword" },
                    { "sprite", "bonemass_greatsword" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "slash", new Tuple<float, float, float, bool>(75, 0, 250, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { "poison", new Tuple<float, float, float, bool>(20, 0, 250, true) },
                    { "poison_per_level", new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(55, 0, 160, true) },
                    { "block", new Tuple<float, float, float, bool>(28, 0, 60, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(14, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(28, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "WitheredBone", new Tuple<int, int>(15, 5) },
                    { "Iron", new Tuple<int, int>(30, 15) },
                    { "Wishbone", new Tuple<int, int>(1, 0) },
                    { "TrophyBonemass", new Tuple<int, int>(1, 0) },
                    { "ElderBark", new Tuple<int, int>(0, 2) },
                    { "LeatherScraps", new Tuple<int, int>(0, 2) }
                }
            );

            // Yagluth Greatsword
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Yagluths Greatsword" },
                    { "catagory", "Swords" },
                    { "prefab", "VAYagluth_greatsword" },
                    { "sprite", "yagluth_greatsword" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "slash", new Tuple<float, float, float, bool>(125, 0, 250, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { "fire", new Tuple<float, float, float, bool>(25, 0, 250, true) },
                    { "fire_per_level", new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(55, 0, 160, true) },
                    { "block", new Tuple<float, float, float, bool>(49, 0, 60, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(18, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(36, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "BlackMetal", new Tuple<int, int>(10, 5) },
                    { "Iron", new Tuple<int, int>(4, 2) },
                    { "YagluthDrop", new Tuple<int, int>(2, 0) },
                    { "TrophyGoblinKing", new Tuple<int, int>(1, 0) },
                    { "Tar", new Tuple<int, int>(0, 3) },
                    { "LinenThread", new Tuple<int, int>(0, 2) }
                }
            );

            // Flint Sword
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Flint Sword" },
                    { "catagory", "Swords" },
                    { "prefab", "VAFlint_Sword" },
                    { "sprite", "flint_sword" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "slash", new Tuple<float, float, float, bool>(15, 0, 90, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(40, 0, 120, true) },
                    { "block", new Tuple<float, float, float, bool>(4, 0, 60, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(6, 1, 30, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(12, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(2, 0) },
                    { "Flint", new Tuple<int, int>(6, 3) },
                    { "LeatherScraps", new Tuple<int, int>(0, 2) }
                }
            );

            // Flint Greatsword
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Flint Greatsword" },
                    { "catagory", "Swords" },
                    { "prefab", "VAFlint_greatsword" },
                    { "sprite", "flint_greatsword" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "slash", new Tuple<float, float, float, bool>(25, 0, 200, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(55, 0, 160, true) },
                    { "block", new Tuple<float, float, float, bool>(14, 0, 60, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(10, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(4, 0) },
                    { "Flint", new Tuple<int, int>(9, 5) },
                    { "LeatherScraps", new Tuple<int, int>(0, 2) }
                }
            );

            // Queen Greatsword
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Queen Greatsword" },
                    { "catagory", "Swords" },
                    { "prefab", "VAQueen_greatsword" },
                    { "sprite", "queen_greatsword" },
                    { "craftedAt", "blackforge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "slash", new Tuple<float, float, float, bool>(125, 0, 250, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { "poison", new Tuple<float, float, float, bool>(25, 0, 250, true) },
                    { "poison_per_level", new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { "lightning", new Tuple<float, float, float, bool>(30, 0, 99, true) },
                    { "lightning_per_level", new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(55, 0, 160, true) },
                    { "block", new Tuple<float, float, float, bool>(62, 0, 60, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(40, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "YggdrasilWood", new Tuple<int, int>(10, 5) },
                    { "Eitr", new Tuple<int, int>(20, 10) },
                    { "JuteBlue", new Tuple<int, int>(4, 2) },
                    { "TrophySeekerQueen", new Tuple<int, int>(1, 0) },
                    { "Carapace", new Tuple<int, int>(0, 8) },
                }
            );

            // Queen sword
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Queen Sword" },
                    { "catagory", "Swords" },
                    { "prefab", "VASwordQueen" },
                    { "sprite", "queen_sword" },
                    { "craftedAt", "blackforge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "slash", new Tuple<float, float, float, bool>(95, 0, 250, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { "poison", new Tuple<float, float, float, bool>(25, 0, 250, true) },
                    { "poison_per_level", new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { "lightning", new Tuple<float, float, float, bool>(30, 0, 99, true) },
                    { "lightning_per_level", new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(40, 0, 160, true) },
                    { "block", new Tuple<float, float, float, bool>(52, 0, 60, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(16, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(32, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "YggdrasilWood", new Tuple<int, int>(3, 1) },
                    { "Eitr", new Tuple<int, int>(10, 5) },
                    { "JuteBlue", new Tuple<int, int>(3, 1) },
                    { "TrophySeekerQueen", new Tuple<int, int>(1, 0) },
                    { "Carapace", new Tuple<int, int>(0, 6) },
                }
            );
        }

        private void LoadAxes()
        {
            // Flint Battleaxe
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Flint greataxe" },
                    { "catagory", "Axes" },
                    { "prefab", "VAFlint_greataxe" },
                    { "sprite", "flint_greataxe" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "slash", new Tuple<float, float, float, bool>(25, 0, 200, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { "chop", new Tuple<float, float, float, bool>(45, 0, 200, true) },
                    { "chop_per_level", new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(70, 0, 200, true) },
                    { "block", new Tuple<float, float, float, bool>(14, 0, 60, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(12, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(24, 1, 20, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(8, 0) },
                    { "Flint", new Tuple<int, int>(9, 5) },
                    { "LeatherScraps", new Tuple<int, int>(0, 2) }
                }
            );

            // Bronze Battleaxe
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Bronze Lumber Axe" },
                    { "catagory", "Axes" },
                    { "prefab", "VAbronze_battleaxe" },
                    { "sprite", "bronze_axe_rebuild" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "slash", new Tuple<float, float, float, bool>(50, 0, 200, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { "chop", new Tuple<float, float, float, bool>(60, 0, 200, true) },
                    { "chop_per_level", new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(70, 0, 200, true) },
                    { "block", new Tuple<float, float, float, bool>(18, 0, 60, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(14, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(28, 1, 20, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "RoundLog", new Tuple<int, int>(20, 5) },
                    { "Bronze", new Tuple<int, int>(10, 5) },
                    { "DeerHide", new Tuple<int, int>(2, 0) }
                }
            );

            // Antler Battleaxe
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Eikthyrs Greataxe" },
                    { "catagory", "Axes" },
                    { "prefab", "VAAntler_greataxe" },
                    { "sprite", "antler_greataxe" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "blunt", new Tuple<float, float, float, bool>(10, 0, 200, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "slash", new Tuple<float, float, float, bool>(20, 0, 200, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(2, 0, 25, true) },
                    { "lightning", new Tuple<float, float, float, bool>(10, 0, 200, true) },
                    { "lightning_per_level", new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { "chop", new Tuple<float, float, float, bool>(60, 0, 200, true) },
                    { "chop_per_level", new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(70, 0, 200, true) },
                    { "block", new Tuple<float, float, float, bool>(18, 0, 60, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(14, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(28, 1, 20, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(15, 0) },
                    { "Resin", new Tuple<int, int>(30, 15) },
                    { "HardAntler", new Tuple<int, int>(3, 3) },
                    { "TrophyEikthyr", new Tuple<int, int>(1, 1) }
                }
            );

            // Blackmetal Battleaxe
            new JotunnItem(
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
                    { "slash_per_level", new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { "chop", new Tuple<float, float, float, bool>(90, 0, 300, true) },
                    { "chop_per_level", new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { "fire", new Tuple<float, float, float, bool>(20, 0, 160, true) },
                    { "fire_per_level", new Tuple<float, float, float, bool>(0, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(70, 0, 200, true) },
                    { "block", new Tuple<float, float, float, bool>(49, 0, 60, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(40, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(10, 5) },
                    { "BlackMetal", new Tuple<int, int>(35, 15) },
                    { "LinenThread", new Tuple<int, int>(5, 0) },
                    { "SurtlingCore", new Tuple<int, int>(4, 0) }
                }
            );
        }

        private void LoadHammers()
        {
            // Blackmetal Sledge
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Blackmetal Sledge" },
                    { "catagory", "Hammers" },
                    { "prefab", "VAblackmetal_sledge" },
                    { "sprite", "blackmetal_hammer" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "blunt", new Tuple<float, float, float, bool>(120, 0, 300, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { "lightning", new Tuple<float, float, float, bool>(20, 0, 120, true) },
                    { "lightning_per_level", new Tuple<float, float, float, bool>(0, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(100, 0, 400, true) },
                    { "block", new Tuple<float, float, float, bool>(49, 0, 60, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(40, 1, 50, true) },
                    { "movement_speed", new Tuple<float, float, float, bool>(-0.20f, -0.20f, 0, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(10, 5) },
                    { "BlackMetal", new Tuple<int, int>(30, 10) },
                    { "LinenThread", new Tuple<int, int>(5, 0) },
                    { "Thunderstone", new Tuple<int, int>(4, 0) }
                }
            );

            // Elder Sledge
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Elders Rock" },
                    { "catagory", "Hammers" },
                    { "prefab", "VAElderHammer" },
                    { "sprite", "elder_hammer" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "blunt", new Tuple<float, float, float, bool>(50, 0, 300, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { "spirit", new Tuple<float, float, float, bool>(20, 0, 99, true) },
                    { "spirit_per_level", new Tuple<float, float, float, bool>(5, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(100, 0, 400, true) },
                    { "block", new Tuple<float, float, float, bool>(22, 0, 60, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(12, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(22, 1, 50, true) },
                    { "movement_speed", new Tuple<float, float, float, bool>(-0.20f, -0.20f, 0, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Bronze", new Tuple<int, int>(4, 2) },
                    { "Stone", new Tuple<int, int>(30, 15) },
                    { "CryptKey", new Tuple<int, int>(1, 0) },
                    { "TrophyTheElder", new Tuple<int, int>(1, 0) },
                    { "RoundLog", new Tuple<int, int>(0, 8) }
                }
            );

            // Bonemass Warhammer
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Bonemasses Rage" },
                    { "catagory", "Hammers" },
                    { "prefab", "VABonemassWarhammer" },
                    { "sprite", "bonemass_warhammer" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "blunt", new Tuple<float, float, float, bool>(70, 0, 300, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { "poison", new Tuple<float, float, float, bool>(20, 0, 99, true) },
                    { "poison_per_level", new Tuple<float, float, float, bool>(5, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(100, 0, 400, true) },
                    { "block", new Tuple<float, float, float, bool>(31, 0, 60, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(14, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(24, 1, 50, true) },
                    { "movement_speed", new Tuple<float, float, float, bool>(-0.20f, -0.20f, 0, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "WitheredBone", new Tuple<int, int>(10, 5) },
                    { "Iron", new Tuple<int, int>(30, 10) },
                    { "Wishbone", new Tuple<int, int>(1, 0) },
                    { "TrophyBonemass", new Tuple<int, int>(1, 0) },
                    { "ElderBark", new Tuple<int, int>(0, 2) },
                    { "LeatherScraps", new Tuple<int, int>(0, 2) }

                }
            );

            // Silver sledge
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Silver Sledge" },
                    { "catagory", "Hammers" },
                    { "prefab", "VASilverSledge" },
                    { "sprite", "silver_sledge" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "blunt", new Tuple<float, float, float, bool>(85, 0, 300, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { "spirit", new Tuple<float, float, float, bool>(25, 0, 99, true) },
                    { "spirit_per_level", new Tuple<float, float, float, bool>(5, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(100, 0, 400, true) },
                    { "block", new Tuple<float, float, float, bool>(31, 0, 60, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(15, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(24, 1, 50, true) },
                    { "movement_speed", new Tuple<float, float, float, bool>(-0.20f, -0.20f, 0, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "RoundLog", new Tuple<int, int>(10, 5) },
                    { "Silver", new Tuple<int, int>(30, 15) },
                    { "YmirRemains", new Tuple<int, int>(4, 2) },
                    { "TrophyFenring", new Tuple<int, int>(1, 1) }
                }
            );
        }

        private void LoadAtgeirs()
        {
            // Flint Atgeir
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Flint Atgeir" },
                    { "catagory", "Atgeirs" },
                    { "prefab", "VAAtgeir_Flint" },
                    { "sprite", "flint_atgeir" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "pierce", new Tuple<float, float, float, bool>(25, 0, 90, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(30, 0, 120, true) },
                    { "block", new Tuple<float, float, float, bool>(11, 0, 60, true) },
                    { "durability", new Tuple<float, float, float, bool>(175, 0, 400, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(10, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(20, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(10, 0) },
                    { "Flint", new Tuple<int, int>(6, 3) },
                    { "LeatherScraps", new Tuple<int, int>(0, 2) },
                }
            );

            // Antler Atgeir
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Eikthyrs Atgeir" },
                    { "catagory", "Atgeirs" },
                    { "prefab", "VAatgeir_antler" },
                    { "sprite", "antler_atgeir" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "pierce", new Tuple<float, float, float, bool>(35, 0, 90, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { "lightning", new Tuple<float, float, float, bool>(10, 0, 25, true) },
                    { "lightning_per_level", new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(30, 0, 120, true) },
                    { "block", new Tuple<float, float, float, bool>(14, 0, 60, true) },
                    { "durability", new Tuple<float, float, float, bool>(175, 0, 400, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(12, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(24, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(15, 0) },
                    { "Resin", new Tuple<int, int>(30, 15) },
                    { "HardAntler", new Tuple<int, int>(3, 3) },
                    { "TrophyEikthyr", new Tuple<int, int>(1, 1) }
                }
            );

            // Abyssal Atgeir
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Abyssal Atgeir" },
                    { "catagory", "Atgeirs" },
                    { "prefab", "VAAtgeirchitin" },
                    { "sprite", "chitin_heavy_atgeir_small2" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "pierce", new Tuple<float, float, float, bool>(35, 0, 140, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(2, 0, 25, true) },
                    { "blunt", new Tuple<float, float, float, bool>(20, 0, 120, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(4, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(30, 0, 120, true) },
                    { "block", new Tuple<float, float, float, bool>(21, 0, 60, true) },
                    { "durability", new Tuple<float, float, float, bool>(175, 0, 400, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(14, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(28, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(10, 0) },
                    { "Chitin", new Tuple<int, int>(30, 15) },
                    { "DeerHide", new Tuple<int, int>(2, 1) }
                }
            );

            // Silver Atgeir
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Silver Atgeir" },
                    { "catagory", "Atgeirs" },
                    { "prefab", "VASilverAtgeir" },
                    { "sprite", "silver_atgeir" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "pierce", new Tuple<float, float, float, bool>(75, 0, 250, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { "spirit", new Tuple<float, float, float, bool>(30, 0, 120, true) },
                    { "spirit_per_level", new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(30, 0, 120, true) },
                    { "block", new Tuple<float, float, float, bool>(39, 0, 60, true) },
                    { "durability", new Tuple<float, float, float, bool>(175, 0, 400, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(16, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(32, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(10, 0) },
                    { "Silver", new Tuple<int, int>(25, 10) },
                    { "Iron", new Tuple<int, int>(4, 2) },
                    { "LeatherScraps", new Tuple<int, int>(3, 1) }
                }
            );

            // Yagluth Atgeir
            new JotunnItem(
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
                    { "pierce_per_level", new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { "fire", new Tuple<float, float, float, bool>(25, 0, 120, true) },
                    { "fire_per_level", new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(30, 0, 120, true) },
                    { "block", new Tuple<float, float, float, bool>(52, 0, 120, true) },
                    { "durability", new Tuple<float, float, float, bool>(175, 0, 400, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(18, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(36, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "BlackMetal", new Tuple<int, int>(10, 0) },
                    { "Iron", new Tuple<int, int>(4, 2) },
                    { "YagluthDrop", new Tuple<int, int>(2, 0) },
                    { "TrophyGoblinKing", new Tuple<int, int>(1, 0) },
                    { "Tar", new Tuple<int, int>(0, 3) },
                    { "LinenThread", new Tuple<int, int>(0, 2) }
                }
            );

            // Meteor atgeir
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Eird Atgeir" },
                    { "catagory", "Atgeirs" },
                    { "prefab", "VAMeteorAtgeir" },
                    { "sprite", "meteor_atgeir" },
                    { "craftedAt", "blackforge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "pierce", new Tuple<float, float, float, bool>(150, 0, 300, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(30, 0, 120, true) },
                    { "block", new Tuple<float, float, float, bool>(52, 0, 120, true) },
                    { "durability", new Tuple<float, float, float, bool>(175, 0, 400, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(22, 1, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(42, 1, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FlametalNew", new Tuple<int, int>(15, 10) },
                    { "Iron", new Tuple<int, int>(4, 2) },
                    { "Blackwood", new Tuple<int, int>(10, 0) },
                    { "MorgenSinew", new Tuple<int, int>(2, 2) }
                }
            );
        }

        private void LoadShields()
        {
            // Serpentscale Buckler
            new JotunnItem(
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
                    { "block_force", new Tuple<float, float, float, bool>(40, 0, 120, true) },
                    { "parry", new Tuple<float, float, float, bool>(1.5f, 0, 3, true) },
                    { "durability", new Tuple<float, float, float, bool>(250, 0, 500, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, bool>() {
                    { "resistPierce", true },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(8, 8) },
                    { "Iron", new Tuple<int, int>(2, 2) },
                    { "SerpentScale", new Tuple<int, int>(6, 3) }
                }
            );

            // Elder Round Shield
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Elders Bulwark" },
                    { "catagory", "Shields" },
                    { "prefab", "VAElderRoundShield" },
                    { "sprite", "elder_roundshield" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(28, 0, 120, true) },
                    { "block_per_level", new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { "block_force", new Tuple<float, float, float, bool>(30, 0, 120, true) },
                    { "parry", new Tuple<float, float, float, bool>(1.5f, 0, 3, true) },
                    { "durability", new Tuple<float, float, float, bool>(250, 0, 500, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, bool>() {
                    { "veryResistBlunt", true },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(16, 8) },
                    { "Bronze", new Tuple<int, int>(8, 4) },
                    { "CryptKey", new Tuple<int, int>(1, 1) },
                    { "TrophyTheElder", new Tuple<int, int>(1, 1) }
                }
            );

            // Moder Round Shield
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Moders Roundshield" },
                    { "catagory", "Shields" },
                    { "prefab", "VAModer_RoundShield" },
                    { "sprite", "moder_roundshield" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(62, 0, 120, true) },
                    { "block_per_level", new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { "block_force", new Tuple<float, float, float, bool>(40, 0, 120, true) },
                    { "parry", new Tuple<float, float, float, bool>(1.5f, 0, 3, true) },
                    { "durability", new Tuple<float, float, float, bool>(250, 0, 500, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },

                },
                new Dictionary<string, bool>() {
                    { "veryResistFrost", true },
                    { "enabled", true },
                    { "craftable", false }
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(24, 12) },
                    { "Silver", new Tuple<int, int>(16, 8) },
                    { "DragonTear", new Tuple<int, int>(10, 0) },
                    { "TrophyDragonQueen", new Tuple<int, int>(1, 0) },
                    { "Obsidian", new Tuple<int, int>(0, 2) },
                    { "JuteRed", new Tuple<int, int>(0, 2) }
                }
            );

            // Moder Tower Shield
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Moders Shield" },
                    { "catagory", "Shields" },
                    { "prefab", "VAModer_shield" },
                    { "sprite", "modershiled_v2" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(100, 0, 180, true) },
                    { "block_per_level", new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { "block_force", new Tuple<float, float, float, bool>(40, 0, 120, true) },
                    { "parry", new Tuple<float, float, float, bool>(1, 0, 3, true) },
                    { "durability", new Tuple<float, float, float, bool>(250, 0, 500, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },

                },
                new Dictionary<string, bool>() {
                    { "veryResistFrost", true },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(24, 12) },
                    { "Silver", new Tuple<int, int>(16, 8) },
                    { "DragonTear", new Tuple<int, int>(10, 0) },
                    { "TrophyDragonQueen", new Tuple<int, int>(1, 0) },
                    { "Obsidian", new Tuple<int, int>(0, 2) },
                    { "JuteRed", new Tuple<int, int>(0, 2) }
                }
            );

            // Silver Wolf tower shield
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Silver Wolf Towershield" },
                    { "catagory", "Shields" },
                    { "prefab", "VAsilver_tower" },
                    { "sprite", "silver_tower_shield" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(78, 0, 120, true) },
                    { "block_per_level", new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { "block_force", new Tuple<float, float, float, bool>(40, 0, 120, true) },
                    { "movement_speed", new Tuple<float, float, float, bool>(-0.20f, -0.30f, 0, true) },
                    { "durability", new Tuple<float, float, float, bool>(250, 0, 500, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, bool>() {},
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(15, 10) },
                    { "Silver", new Tuple<int, int>(10, 6) },
                    { "TrophyUlv", new Tuple<int, int>(1, 1) }
                }
            );
        }

        private void LoadDaggers()
        {
            // Flint 2H Daggers
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Flint Daggers" },
                    { "catagory", "Daggers" },
                    { "prefab", "VADagger_Flint_2h" },
                    { "sprite", "flint_2h_dagger" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(4, 0, 48, true) },
                    { "slash", new Tuple<float, float, float, bool>(12, 0, 99, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "pierce", new Tuple<float, float, float, bool>(12, 0, 99, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(10, 0, 40, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(4, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(12, 1, 50, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(4, 0) },
                    { "Flint", new Tuple<int, int>(6, 3) },
                    { "LeatherScraps", new Tuple<int, int>(2, 1) }
                }
            );

            // Antler 1H Daggers
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Eikthyrs Dagger" },
                    { "catagory", "Daggers" },
                    { "prefab", "VAAntler_dagger" },
                    { "sprite", "antler_dagger" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(2, 0, 48, true) },
                    { "slash", new Tuple<float, float, float, bool>(10, 0, 99, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "pierce", new Tuple<float, float, float, bool>(10, 0, 99, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "lightning", new Tuple<float, float, float, bool>(7, 0, 99, true) },
                    { "lightning_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(10, 0, 30, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(6, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(18, 1, 50, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(3, 0) },
                    { "Resin", new Tuple<int, int>(16, 8) },
                    { "HardAntler", new Tuple<int, int>(3, 3) },
                    { "TrophyEikthyr", new Tuple<int, int>(1, 1) }
                }
            );

            // Bronze 2H Daggers
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Rascals Daggers" },
                    { "catagory", "Daggers" },
                    { "prefab", "VAdagger_bronze_2h" },
                    { "sprite", "bronze_dagger_2h" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(8, 0, 48, true) },
                    { "slash", new Tuple<float, float, float, bool>(20, 0, 99, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "pierce", new Tuple<float, float, float, bool>(20, 0, 99, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(10, 0, 40, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(6, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(18, 1, 50, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "RoundLog", new Tuple<int, int>(4, 0) },
                    { "Bronze", new Tuple<int, int>(8, 4) },
                    { "LeatherScraps", new Tuple<int, int>(4, 2) }
                }
            );

            // Bronze 1H Daggers
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Bronze Dagger" },
                    { "catagory", "Daggers" },
                    { "prefab", "VAdagger_bronze" },
                    { "sprite", "bronze_dagger" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(2, 0, 48, true) },
                    { "slash", new Tuple<float, float, float, bool>(16, 0, 99, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "pierce", new Tuple<float, float, float, bool>(16, 0, 99, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(10, 0, 30, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(6, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(18, 1, 50, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "RoundLog", new Tuple<int, int>(2, 0) },
                    { "Bronze", new Tuple<int, int>(6, 3) },
                    { "LeatherScraps", new Tuple<int, int>(3, 1) }
                }
            );

            // Iron 2H Daggers
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Rogue Daggers" },
                    { "catagory", "Daggers" },
                    { "prefab", "VAdagger_iron_2h" },
                    { "sprite", "iron_dagger_2h" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(12, 0, 48, true) },
                    { "slash", new Tuple<float, float, float, bool>(25, 0, 99, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "pierce", new Tuple<float, float, float, bool>(25, 0, 99, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(10, 0, 40, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(8, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(24, 1, 50, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(4, 2) },
                    { "Iron", new Tuple<int, int>(16, 8) },
                    { "LeatherScraps", new Tuple<int, int>(6, 3) }
                }
            );

            // Iron 1H Daggers
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Iron Dagger" },
                    { "catagory", "Daggers" },
                    { "prefab", "VAdagger_iron" },
                    { "sprite", "iron_dagger" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(2, 0, 48, true) },
                    { "slash", new Tuple<float, float, float, bool>(22, 0, 99, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "pierce", new Tuple<float, float, float, bool>(22, 0, 99, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(10, 0, 30, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(8, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(24, 1, 50, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, bool>() {
                    { "enabled", true }
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(2, 1) },
                    { "Iron", new Tuple<int, int>(12, 6) },
                    { "LeatherScraps", new Tuple<int, int>(4, 2) }
                }
            );

            // Silver 2H Daggers
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Blackguards Runic Daggers" },
                    { "catagory", "Daggers" },
                    { "prefab", "VAdagger_silver_2h" },
                    { "sprite", "silver_dagger_2h" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(16, 0, 48, true) },
                    { "slash", new Tuple<float, float, float, bool>(34, 0, 99, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "pierce", new Tuple<float, float, float, bool>(34, 0, 99, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "spirit", new Tuple<float, float, float, bool>(12, 0, 99, true) },
                    { "spirit_per_level", new Tuple<float, float, float, bool>(0, 0, 25, true) },
                    { "frost", new Tuple<float, float, float, bool>(0, 0, 99, true) },
                    { "frost_per_level", new Tuple<float, float, float, bool>(0, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(10, 0, 40, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(10, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(30, 1, 50, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(4, 2) },
                    { "Silver", new Tuple<int, int>(12, 6) },
                    { "Iron", new Tuple<int, int>(4, 2) },
                    { "LeatherScraps", new Tuple<int, int>(6, 3) }
                }
            );

            // Silver 1H Daggers | not default craftable
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Silver Dagger" },
                    { "catagory", "Daggers" },
                    { "prefab", "VAdagger_silver" },
                    { "sprite", "silver_dagger" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(2, 0, 48, true) },
                    { "slash", new Tuple<float, float, float, bool>(34, 0, 99, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "pierce", new Tuple<float, float, float, bool>(34, 0, 99, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "spirit", new Tuple<float, float, float, bool>(0, 0, 99, true) },
                    { "spirit_per_level", new Tuple<float, float, float, bool>(0, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(10, 0, 30, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(10, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(30, 1, 50, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, bool>() {
                    { "enabled", true },
                    { "craftable", false }
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(4, 2) },
                    { "Obsidian", new Tuple<int, int>(12, 5) },
                    { "Silver", new Tuple<int, int>(14, 6) },
                }
            );

            // Moders Daggers 1H
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Moders Dagger" },
                    { "catagory", "Daggers" },
                    { "prefab", "VAdagger_moder" },
                    { "sprite", "moder_dagger" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(2, 0, 48, true) },
                    { "slash", new Tuple<float, float, float, bool>(34, 0, 99, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "pierce", new Tuple<float, float, float, bool>(34, 0, 99, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "spirit", new Tuple<float, float, float, bool>(0, 0, 99, true) },
                    { "spirit_per_level", new Tuple<float, float, float, bool>(0, 0, 25, true) },
                    { "frost", new Tuple<float, float, float, bool>(18, 0, 99, true) },
                    { "frost_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(10, 0, 30, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(10, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(30, 1, 50, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, bool>() {
                    { "enabled", true }
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(4, 2) },
                    { "Obsidian", new Tuple<int, int>(15, 5) },
                    { "DragonTear", new Tuple<int, int>(10, 0) },
                    { "TrophyDragonQueen", new Tuple<int, int>(1, 0) },
                    { "Silver", new Tuple<int, int>(0, 2) },
                    { "JuteRed", new Tuple<int, int>(0, 2) }
                }
            );

            // Bonemass Dagger
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Bonemasses Dagger" },
                    { "catagory", "Daggers" },
                    { "prefab", "VABonemassDagger" },
                    { "sprite", "bonemass_dagger" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(2, 0, 48, true) },
                    { "pierce", new Tuple<float, float, float, bool>(22, 0, 99, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "slash", new Tuple<float, float, float, bool>(22, 0, 99, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "poison", new Tuple<float, float, float, bool>(10, 0, 99, true) },
                    { "poison_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(10, 0, 30, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(8, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(24, 1, 50, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, bool>() {
                    { "enabled", true }
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "WitheredBone", new Tuple<int, int>(2, 1) },
                    { "Iron", new Tuple<int, int>(12, 6) },
                    { "Wishbone", new Tuple<int, int>(1, 0) },
                    { "TrophyBonemass", new Tuple<int, int>(1, 0) },
                    { "ElderBark", new Tuple<int, int>(0, 2) },
                    { "LeatherScraps", new Tuple<int, int>(0, 2) }
                }
            );

            // Queens Dagger
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Queens Dagger" },
                    { "catagory", "Daggers" },
                    { "prefab", "VAdagger_queen" },
                    { "sprite", "dagger_queen" },
                    { "craftedAt", "blackforge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(2, 0, 48, true) },
                    { "pierce", new Tuple<float, float, float, bool>(34, 0, 99, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "slash", new Tuple<float, float, float, bool>(34, 0, 99, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "poison", new Tuple<float, float, float, bool>(18, 0, 99, true) },
                    { "poison_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "lightning", new Tuple<float, float, float, bool>(18, 0, 99, true) },
                    { "lightning_per_level", new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(10, 0, 30, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(14, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(42, 1, 80, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, bool>() {
                    { "enabled", true }
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "YggdrasilWood", new Tuple<int, int>(2, 2) },
                    { "Eitr", new Tuple<int, int>(10, 5) },
                    { "JuteBlue", new Tuple<int, int>(2, 1) },
                    { "TrophySeekerQueen", new Tuple<int, int>(1, 0) },
                    { "Carapace", new Tuple<int, int>(0, 4) },
                }
            );

            // Meteor dagger
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Eird dagger" },
                    { "catagory", "Daggers" },
                    { "prefab", "VAdagger_meteor" },
                    { "sprite", "meteor_dagger" },
                    { "craftedAt", "blackforge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(2, 0, 48, true) },
                    { "pierce", new Tuple<float, float, float, bool>(45, 0, 99, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "slash", new Tuple<float, float, float, bool>(45, 0, 99, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(10, 0, 30, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(14, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(42, 1, 80, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, bool>() {
                    { "enabled", true }
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FlametalNew", new Tuple<int, int>(10, 4) },
                    { "Iron", new Tuple<int, int>(2, 1) },
                    { "Blackwood", new Tuple<int, int>(4, 0) },
                    { "MorgenSinew", new Tuple<int, int>(4, 2) }
                }
            );

            // Meteor dagger 2h
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Assassins dagger" },
                    { "catagory", "Daggers" },
                    { "prefab", "VAdagger_meteor_2h" },
                    { "sprite", "2h_meteor_daggers" },
                    { "craftedAt", "blackforge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(2, 0, 48, true) },
                    { "pierce", new Tuple<float, float, float, bool>(52, 0, 99, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "slash", new Tuple<float, float, float, bool>(52, 0, 99, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(10, 0, 30, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(15, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(45, 1, 80, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, bool>() {
                    { "enabled", true }
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FlametalNew", new Tuple<int, int>(14, 6) },
                    { "Iron", new Tuple<int, int>(2, 1) },
                    { "Blackwood", new Tuple<int, int>(6, 0) },
                    { "MorgenSinew", new Tuple<int, int>(4, 2) }
                }
            );
        }

        private void LoadSpears()
        {
            // Moder Spear
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Moders Strike" },
                    { "catagory", "Spears" },
                    { "prefab", "VASpearModer" },
                    { "sprite", "moder_spear" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(30, 0, 48, true) },
                    { "pierce", new Tuple<float, float, float, bool>(45, 0, 120, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(2, 0, 20, true) },
                    { "slash", new Tuple<float, float, float, bool>(30, 0, 99, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(4, 0, 20, true) },
                    { "frost", new Tuple<float, float, float, bool>(25, 0, 99, true) },
                    { "frost_per_level", new Tuple<float, float, float, bool>(5, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(12, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(14, 1, 50, true) },
                    { "durability", new Tuple<float, float, float, bool>(100, 0, 300, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(15, 10) },
                    { "Obsidian", new Tuple<int, int>(8, 4) },
                    { "DragonTear", new Tuple<int, int>(10, 0) },
                    { "TrophyDragonQueen", new Tuple<int, int>(1, 0) },
                    { "Silver", new Tuple<int, int>(0, 2) },
                    { "JuteRed", new Tuple<int, int>(0, 2) }
                }
            );
        }

        private void LoadFists()
        {
            // Flint Fists
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Flint knuckles" },
                    { "catagory", "Fists" },
                    { "prefab", "VAFist_Flint" },
                    { "sprite", "flint_fists" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(5, 0, 48, true) },
                    { "slash", new Tuple<float, float, float, bool>(6, 0, 120, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(4, 0, 20, true) },
                    { "blunt", new Tuple<float, float, float, bool>(0, 0, 120, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(0, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(4, 1, 20, true) },
                    { "durability", new Tuple<float, float, float, bool>(300, 0, 600, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(4, 0) },
                    { "Flint", new Tuple<int, int>(4, 2) },
                    { "LeatherScraps", new Tuple<int, int>(2, 2) }
                }
            );

            // Bronze Fists
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Bronze knuckles" },
                    { "catagory", "Fists" },
                    { "prefab", "VAFist_Bronze" },
                    { "sprite", "bronze_fists" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(5, 0, 48, true) },
                    { "slash", new Tuple<float, float, float, bool>(20, 0, 120, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(4, 0, 20, true) },
                    { "blunt", new Tuple<float, float, float, bool>(0, 0, 120, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(0, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(6, 1, 20, true) },
                    { "durability", new Tuple<float, float, float, bool>(300, 0, 600, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "RoundLog", new Tuple<int, int>(4, 0) },
                    { "Bronze", new Tuple<int, int>(6, 3) },
                    { "LeatherScraps", new Tuple<int, int>(4, 4) }
                }
            );

            // Iron Fists
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Iron knuckles" },
                    { "catagory", "Fists" },
                    { "prefab", "VAFist_Iron" },
                    { "sprite", "iron_fists" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(5, 0, 48, true) },
                    { "slash", new Tuple<float, float, float, bool>(35, 0, 120, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(4, 0, 20, true) },
                    { "blunt", new Tuple<float, float, float, bool>(0, 0, 120, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(0, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(8, 1, 20, true) },
                    { "durability", new Tuple<float, float, float, bool>(300, 0, 600, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(4, 2) },
                    { "Iron", new Tuple<int, int>(12, 6) },
                    { "LeatherScraps", new Tuple<int, int>(6, 6) }
                }
            );

            // Yagluth Fists
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Goblin king knuckles" },
                    { "catagory", "Fists" },
                    { "prefab", "VAFist_Yagluth" },
                    { "sprite", "yagluth_fists" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(5, 0, 48, true) },
                    { "slash", new Tuple<float, float, float, bool>(80, 0, 120, true) },
                    { "slash_per_level", new Tuple<float, float, float, bool>(4, 0, 20, true) },
                    { "blunt", new Tuple<float, float, float, bool>(0, 0, 120, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(0, 0, 20, true) },
                    { "fire", new Tuple<float, float, float, bool>(25, 0, 120, true) },
                    { "fire_per_level", new Tuple<float, float, float, bool>(5, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(12, 1, 20, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(36, 1, 50, true) },
                    { "durability", new Tuple<float, float, float, bool>(300, 0, 600, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "BlackMetal", new Tuple<int, int>(4, 2) },
                    { "Iron", new Tuple<int, int>(6, 3) },
                    { "YagluthDrop", new Tuple<int, int>(2, 0) },
                    { "TrophyGoblinKing", new Tuple<int, int>(1, 0) },
                    { "Tar", new Tuple<int, int>(0, 3) },
                    { "LinenThread", new Tuple<int, int>(0, 2) }
                }
            );
        }

        private void LoadMaces()
        {
            // Elders Mace
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Elders Fist" },
                    { "catagory", "Maces" },
                    { "prefab", "VAElder_mace" },
                    { "sprite", "elder_mace" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "blunt", new Tuple<float, float, float, bool>(35, 0, 90, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { "spirit", new Tuple<float, float, float, bool>(20, 0, 120, true) },
                    { "spirit_per_level", new Tuple<float, float, float, bool>(5, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(80, 0, 120, true) },
                    { "block", new Tuple<float, float, float, bool>(12, 0, 60, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(8, 1, 30, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(16, 1, 50, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Bronze", new Tuple<int, int>(2, 1) },
                    { "Stone", new Tuple<int, int>(16, 8) },
                    { "CryptKey", new Tuple<int, int>(1, 0) },
                    { "TrophyTheElder", new Tuple<int, int>(1, 0) },
                    { "RoundLog", new Tuple<int, int>(0, 6) },
                }
            );
        }

        private void LoadMagic()
        {
            // Staff of poison
            new JotunnItem(
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
                    { "poison", new Tuple<float, float, float, bool>(120, 0, 200, true) },
                    { "poison_per_level", new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { "blunt", new Tuple<float, float, float, bool>(120, 0, 200, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(0, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { "primary_attack_eitr", new Tuple<float, float, float, bool>(35, 0, 50, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(0, 0, 50, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "YggdrasilWood", new Tuple<int, int>(20, 10) },
                    { "Guck", new Tuple<int, int>(4, 2) },
                    { "Eitr", new Tuple<int, int>(16, 8) },
                }
            );

            // Staff of spirit
            new JotunnItem(
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
                    { "spirit", new Tuple<float, float, float, bool>(120, 0, 200, true) },
                    { "spirit_per_level", new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { "blunt", new Tuple<float, float, float, bool>(120, 0, 200, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(0, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { "primary_attack_eitr", new Tuple<float, float, float, bool>(35, 0, 50, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(0, 0, 50, true) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "YggdrasilWood", new Tuple<int, int>(20, 10) },
                    { "GreydwarfEye", new Tuple<int, int>(8, 8) },
                    { "Eitr", new Tuple<int, int>(16, 8) },
                    { "TrophyDvergr", new Tuple<int, int>(2, 0) },
                }
            );

            // Druidic Staff of poison
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Druidic Staff of Poison" },
                    { "catagory", "Magics" },
                    { "prefab", "VAStaff_Druid_Poison" },
                    { "sprite", "poison_staff_druidic" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(24, 0, 48, true) },
                    { "poison", new Tuple<float, float, float, bool>(50, 0, 120, true) },
                    { "poison_per_level", new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { "blunt", new Tuple<float, float, float, bool>(50, 0, 200, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(0, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { "durability", new Tuple<float, float, float, bool>(50, 0, 500, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(10, 0, 75, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(35, 0, 50, true) },
                    { "primary_attack_eitr", new Tuple<float, float, float, bool>(0, 0, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(20, 10) },
                    { "Guck", new Tuple<int, int>(4, 2) },
                    { "TrophyBlob", new Tuple<int, int>(2, 1) },
                },
                new Dictionary<string, int>
                {
                    { "stationRequiredLevel", 2 }
                }
            );

            // Druidic Staff of spirit
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Druidic Staff of Spirit" },
                    { "catagory", "Magics" },
                    { "prefab", "VAStaff_Druid_Spirit" },
                    { "sprite", "spirit_staff_druid" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(24, 0, 48, true) },
                    { "spirit", new Tuple<float, float, float, bool>(50, 0, 120, true) },
                    { "spirit_per_level", new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { "blunt", new Tuple<float, float, float, bool>(50, 0, 200, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(0, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { "durability", new Tuple<float, float, float, bool>(50, 0, 500, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(10, 0, 75, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(35, 0, 50, true) },
                    { "primary_attack_eitr", new Tuple<float, float, float, bool>(0, 0, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(20, 10) },
                    { "GreydwarfEye", new Tuple<int, int>(4, 2) },
                    { "TrophyGreydwarfShaman", new Tuple<int, int>(2, 1) },
                },
                new Dictionary<string, int>
                {
                    { "stationRequiredLevel", 2 }
                }
            );

            // Druidic Staff of Ice
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Druidic Staff of Ice" },
                    { "catagory", "Magics" },
                    { "prefab", "VAStaff_Druid_Ice" },
                    { "sprite", "ice_staff_druidic" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(24, 0, 48, true) },
                    { "frost", new Tuple<float, float, float, bool>(12, 0, 120, true) },
                    { "frost_per_level", new Tuple<float, float, float, bool>(2, 0, 20, true) },
                    { "blunt", new Tuple<float, float, float, bool>(12, 0, 200, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(0, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { "durability", new Tuple<float, float, float, bool>(50, 0, 500, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(10, 0, 75, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(5, 0, 50, true) },
                    { "primary_attack_eitr", new Tuple<float, float, float, bool>(0, 0, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(20, 10) },
                    { "FreezeGland", new Tuple<int, int>(4, 2) },
                    { "TrophyHatchling", new Tuple<int, int>(2, 1) },
                },
                new Dictionary<string, int>
                {
                    { "stationRequiredLevel", 2 }
                }
            );

            // Druidic Staff of Fire
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Druidic Staff of Fire" },
                    { "catagory", "Magics" },
                    { "prefab", "VAStaff_Druid_Fire" },
                    { "sprite", "fire_staff_druidic" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(24, 0, 48, true) },
                    { "fire", new Tuple<float, float, float, bool>(50, 0, 120, true) },
                    { "fire_per_level", new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { "blunt", new Tuple<float, float, float, bool>(50, 0, 200, true) },
                    { "blunt_per_level", new Tuple<float, float, float, bool>(0, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { "durability", new Tuple<float, float, float, bool>(50, 0, 500, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(10, 0, 75, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(35, 0, 50, true) },
                    { "primary_attack_eitr", new Tuple<float, float, float, bool>(0, 0, 50, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(20, 10) },
                    { "SurtlingCore", new Tuple<int, int>(4, 2) },
                    { "TrophySurtling", new Tuple<int, int>(2, 1) },
                },
                new Dictionary<string, int>
                {
                    { "stationRequiredLevel", 2 }
                }
            );
        }

        private void LoadPickaxes()
        {
            // Bone Blood Pickaxe
            new JotunnItem(
                new Dictionary<string, string>() {
                    { "name", "Bone Blood Pickaxe" },
                    { "catagory", "Pickaxes" },
                    { "prefab", "VABlood_Bones_pickaxe" },
                    { "sprite", "blood_bone_pickaxe" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "pierce", new Tuple<float, float, float, bool>(26, 0, 200, true) },
                    { "pierce_per_level", new Tuple<float, float, float, bool>(4, 0, 20, true) },
                    { "spirit", new Tuple<float, float, float, bool>(6, 0, 200, true) },
                    { "spirit_per_level", new Tuple<float, float, float, bool>(2, 0, 20, true) },
                    { "pickaxe", new Tuple<float, float, float, bool>(32, 0, 200, true) },
                    { "pickaxe_per_level", new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { "attack_force", new Tuple<float, float, float, bool>(50, 0, 100, true) },
                    { "primary_attack_stamina", new Tuple<float, float, float, bool>(6, 0, 50, true) },
                    { "primary_attack_flat_health_cost", new Tuple<float, float, float, bool>(4, 0, 25, true) },
                    { "primary_attack_percent_health_cost", new Tuple<float, float, float, bool>(0, 0, 50, true) },
                    { "secondary_attack_stamina", new Tuple<float, float, float, bool>(4, 0, 50, true) },
                    { "secondary_attack_flat_health_cost", new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { "secondary_attack_percent_health_cost", new Tuple<float, float, float, bool>(0, 0, 50, true) },
                    { "tool_level", new Tuple<float, float, float, bool>(1, 0, 5, false) },
                    { "durability", new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { "durability_per_level", new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "RoundLog", new Tuple<int, int>(12, 8) },
                    { "BoneFragments", new Tuple<int, int>(20, 14) },
                    { "Bronze", new Tuple<int, int>(4, 2) },
                    { "TrophySkeleton", new Tuple<int, int>(2, 0) },
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
            //new NonCraftablePrefab(EmbeddedResourceBundle, "Assets/Custom/Weapons/Magics/projectiles/staff_ice_projectile.prefab");
            new NonCraftablePrefab(EmbeddedResourceBundle, "Assets/Custom/Weapons/Magics/projectiles/staff_poison_projectile.prefab");
            new NonCraftablePrefab(EmbeddedResourceBundle, "Assets/Custom/Weapons/Magics/projectiles/staff_spirit_projectile.prefab");
            // new NonCraftablePrefab(EmbeddedResourceBundle, "Assets/Custom/Weapons/Magics/projectiles/vfx_poison_explosion.prefab");
            new NonCraftablePrefab(EmbeddedResourceBundle, "Assets/Custom/Weapons/Magics/projectiles/vfx_spirit_explosion.prefab");
        }
    }

    class NonCraftablePrefab
    {
        // full_path like: Assets/Custom/Pieces/VFortress/VF_creature_notify.prefab
        public NonCraftablePrefab(AssetBundle EmbeddedResourceBundle, String full_path)
        {
            GameObject game_obj = EmbeddedResourceBundle.LoadAsset<GameObject>($"{full_path}");
            CustomPrefab prefab_obj = new CustomPrefab(game_obj, true);
            PrefabManager.Instance.AddPrefab(prefab_obj);
        }
    }
}