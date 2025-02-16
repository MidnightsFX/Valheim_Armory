
using Jotunn.Entities;
using Jotunn.Managers;
using System;
using System.Collections.Generic;
using UnityEngine;
using ValheimArmory.common;
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
            Logger.LogInfo("Loading Arrows");
            // Greenmetal Arrows					forge lvl 3
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Black Metal Arrow" },
                    { ItemMetadata.catagory, "Arrows" },
                    { ItemMetadata.prefab, "VAArrowGreenMetal" },
                    { ItemMetadata.sprite, "arrow_greenmetal" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { ItemStat.blunt, new Tuple<float, float, float, bool>(52, 0, 200, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(26, 0, 200, true) }
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(8, 0) },
                    { "BlackMetal", new Tuple<int, int>(2, 0) },
                    { "Feathers", new Tuple<int, int>(2, 0) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 3 }
                }
            );

            // Bone Arrows							workbench lvl 3(obsidian)
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Bone Arrow" },
                    { ItemMetadata.catagory, "Arrows" },
                    { ItemMetadata.prefab, "VAArrowBone" },
                    { ItemMetadata.sprite, "bone_arrow" },
                    { ItemMetadata.craftedAt, "piece_workbench" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(32, 0, 200, true) }
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "BoneFragments", new Tuple<int, int>(8, 0) },
                    { "Feathers", new Tuple<int, int>(2, 0) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 3 }
                }
            );

            // Surtling Fire Arrow					workbench lvl 3
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Surtling Fire Arrow" },
                    { ItemMetadata.catagory, "Arrows" },
                    { ItemMetadata.prefab, "VAarrow_surtling_fire" },
                    { ItemMetadata.sprite, "surtlingcore_arrow" },
                    { ItemMetadata.craftedAt, "piece_workbench" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { ItemStat.fire, new Tuple<float, float, float, bool>(52, 0, 200, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(26, 0, 200, true) }
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(8, 0) },
                    { "Obsidian", new Tuple<int, int>(4, 0) },
                    { "Feathers", new Tuple<int, int>(2, 0) },
                    { "SurtlingCore", new Tuple<int, int>(1, 0) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 3 }
                }
            );

            // Ancient Wood Arrow					workbench lvl 3
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Ancient Wood Arrow" },
                    { ItemMetadata.catagory, "Arrows" },
                    { ItemMetadata.prefab, "VAarrowancient" },
                    { ItemMetadata.sprite, "ancient_arrow" },
                    { ItemMetadata.craftedAt, "piece_workbench" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(37, 0, 200, true) }
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(8, 0) },
                    { "Feathers", new Tuple<int, int>(2, 0) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 3 }
                }
            );

            // Chitin Arrow							workbench lvl 3
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Chitin Arrow" },
                    { ItemMetadata.catagory, "Arrows" },
                    { ItemMetadata.prefab, "VAchitinarrow" },
                    { ItemMetadata.sprite, "arrow_chitin" },
                    { ItemMetadata.craftedAt, "piece_workbench" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(12, 0, 200, true) },
                    { ItemStat.blunt, new Tuple<float, float, float, bool>(35, 0, 200, true) }
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(8, 0) },
                    { "Chitin", new Tuple<int, int>(2, 0) },
                    { "Feathers", new Tuple<int, int>(2, 0) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 3 }
                }
            );

            // Wood Crossbow Bolt					workbench lvl 1
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Wood Bolt" },
                    { ItemMetadata.catagory, "Arrows" },
                    { ItemMetadata.prefab, "VABoltWood" },
                    { ItemMetadata.sprite, "bolt_wood" },
                    { ItemMetadata.craftedAt, "piece_workbench" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(22, 0, 200, true) }
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(8, 0) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 1 }
                }
            );

            // Corewood Crossbow Bolt					workbench lvl 3
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Corewood Bolt" },
                    { ItemMetadata.catagory, "Arrows" },
                    { ItemMetadata.prefab, "VABoltCoreWood" },
                    { ItemMetadata.sprite, "bolt_corewood" },
                    { ItemMetadata.craftedAt, "piece_workbench" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(37, 0, 200, true) }
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "RoundLog", new Tuple<int, int>(8, 0) },
                    { "Feathers", new Tuple<int, int>(2, 0) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 3 }
                }
            );

            // Bronze Bolt							forge lvl 1
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Bronze Bolt" },
                    { ItemMetadata.catagory, "Arrows" },
                    { ItemMetadata.prefab, "VAbolt_bronze" },
                    { ItemMetadata.sprite, "bronze_bolt" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(32, 0, 200, true) }
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(8, 0) },
                    { "Bronze", new Tuple<int, int>(1, 0) },
                    { "Feathers", new Tuple<int, int>(2, 0) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 1 }
                }
            );

            // Iron Poison Bolt						forge lvl 2
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Poison Bolt" },
                    { ItemMetadata.catagory, "Arrows" },
                    { ItemMetadata.prefab, "VAbolt_poison" },
                    { ItemMetadata.sprite, "poison_bolt" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { ItemStat.poison, new Tuple<float, float, float, bool>(52, 0, 200, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(26, 0, 200, true) }
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(8, 0) },
                    { "Iron", new Tuple<int, int>(1, 0) },
                    { "Feathers", new Tuple<int, int>(2, 0) },
                    { "Ooze", new Tuple<int, int>(1, 0) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );

            // Obsidian Bolt						workbench lvl 3
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Obsidian Bolt" },
                    { ItemMetadata.catagory, "Arrows" },
                    { ItemMetadata.prefab, "VAObsidianBolt" },
                    { ItemMetadata.sprite, "obsidian_bolt" },
                    { ItemMetadata.craftedAt, "piece_workbench" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(52, 0, 200, true) }
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(8, 0) },
                    { "Obsidian", new Tuple<int, int>(4, 0) },
                    { "Feathers", new Tuple<int, int>(2, 0) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 3 }
                }
            );

            // Silver Ice Bolt						forge lvl 3
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Frost Bolt" },
                    { ItemMetadata.catagory, "Arrows" },
                    { ItemMetadata.prefab, "VAbolt_frost" },
                    { ItemMetadata.sprite, "ice_bolt" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { ItemStat.frost, new Tuple<float, float, float, bool>(52, 0, 200, true) },
                    { ItemStat.spirit, new Tuple<float, float, float, bool>(20, 0, 200, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(26, 0, 200, true) }
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(8, 0) },
                    { "Silver", new Tuple<int, int>(1, 0) },
                    { "Feathers", new Tuple<int, int>(2, 0) },
                    { "FreezeGland", new Tuple<int, int>(1, 0) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 3 }
                }
            );

            // Iron Surtling bolt					forge lvl 2
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Surtling Core Bolt" },
                    { ItemMetadata.catagory, "Arrows" },
                    { ItemMetadata.prefab, "VASurtlingBolt" },
                    { ItemMetadata.sprite, "surtling_bolt" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { ItemStat.fire, new Tuple<float, float, float, bool>(52, 0, 200, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(26, 0, 200, true) }
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(8, 0) },
                    { "Iron", new Tuple<int, int>(1, 0) },
                    { "Feathers", new Tuple<int, int>(2, 0) },
                    { "SurtlingCore", new Tuple<int, int>(1, 0) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );

            // Needle bolt					forge lvl 4
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Needle Bolt" },
                    { ItemMetadata.catagory, "Arrows" },
                    { ItemMetadata.prefab, "VABoltNeedle" },
                    { ItemMetadata.sprite, "needle_bolt" },
                    { ItemMetadata.craftedAt, "piece_workbench" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(56, 0, 200, true) }
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Needle", new Tuple<int, int>(8, 0) },
                    { "Feathers", new Tuple<int, int>(2, 0) },
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 4 }
                }
            );

            // Fire bolt					forge lvl 2
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Fire Bolt" },
                    { ItemMetadata.catagory, "Arrows" },
                    { ItemMetadata.prefab, "VAFireBolt" },
                    { ItemMetadata.sprite, "surtling_bolt" },
                    { ItemMetadata.craftedAt, "piece_workbench" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(22, 0, 200, true) },
                    { ItemStat.fire, new Tuple<float, float, float, bool>(34, 0, 200, true) }
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(8, 0) },
                    { "Resin", new Tuple<int, int>(8, 0) },
                    { "Feathers", new Tuple<int, int>(2, 0) },
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 4 }
                }
            );
        }

        private void LoadBows()
        {
            Logger.LogInfo("Loading Bows");
            // Heavy Blood Bone Bow
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Carapace Blood Bow" },
                    { ItemMetadata.catagory, "Bows" },
                    { ItemMetadata.prefab, "VAHeavy_Blood_Bone_Bow" },
                    { ItemMetadata.sprite, "blood_bone_bow_heavy" },
                    { ItemMetadata.craftedAt, "piece_magetable" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(92, 0, 300, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { ItemStat.spirit, new Tuple<float, float, float, bool>(24, 0, 200, true) },
                    { ItemStat.spirit_per_level, new Tuple<float, float, float, bool>(2, 0, 20, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(5, 0, 60, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(20, 0, 300, true) },
                    { ItemStat.draw_stamina_drain, new Tuple<float, float, float, bool>(6, 1, 50, true) },
                    { ItemStat.primary_attack_flat_health_cost, new Tuple<float, float, float, bool>(12, 0, 25, true) },
                    { ItemStat.primary_attack_percent_health_cost, new Tuple<float, float, float, bool>(0, 0, 50, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.bow_draw_speed, new Tuple<float, float, float, bool>(2, 0.01f, 2, true) },
                    { ItemStat.projectile_velocity, new Tuple<float, float, float, bool>(60, 0, 120, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "YggdrasilWood", new Tuple<int, int>(14, 7) },
                    { "Iron", new Tuple<int, int>(10, 6) },
                    { "Carapace", new Tuple<int, int>(24, 10) },
                    { "TrophyTick", new Tuple<int, int>(2, 0) },
                    { "Eitr", new Tuple<int, int>(0, 10) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 1 }
                }
            );

            // Blood Bone Bow
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Blood Bone Bow" },
                    { ItemMetadata.catagory, "Bows" },
                    { ItemMetadata.prefab, "VABlood_bone_bow" },
                    { ItemMetadata.sprite, "bone_bow" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(60, 0, 300, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { ItemStat.spirit, new Tuple<float, float, float, bool>(18, 0, 200, true) },
                    { ItemStat.spirit_per_level, new Tuple<float, float, float, bool>(2, 0, 20, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(3, 0, 60, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(20, 0, 300, true) },
                    { ItemStat.draw_stamina_drain, new Tuple<float, float, float, bool>(4, 1, 50, true) },
                    { ItemStat.primary_attack_flat_health_cost, new Tuple<float, float, float, bool>(8, 0, 25, true) },
                    { ItemStat.primary_attack_percent_health_cost, new Tuple<float, float, float, bool>(0, 0, 50, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.bow_draw_speed, new Tuple<float, float, float, bool>(2, 0.01f, 2, true) },
                    { ItemStat.projectile_velocity, new Tuple<float, float, float, bool>(60, 0, 120, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(10, 5) },
                    { "Silver", new Tuple<int, int>(10, 5) },
                    { "BoneFragments", new Tuple<int, int>(20, 10) },
                    { "TrophyUlv", new Tuple<int, int>(2, 0) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 3 }
                }
            );

            // Bronze Arbalist
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Bronze Arbelist" },
                    { ItemMetadata.catagory, "Bows" },
                    { ItemMetadata.prefab, "VAArbalistBronze" },
                    { ItemMetadata.sprite, "bronze_crossbow_upright" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(105, 0, 300, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(200, 0, 300, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(3, 0, 60, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(100, 0, 300, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.crossbow_reload_speed, new Tuple<float, float, float, bool>(3.5f, 0.01f, 3.5f, true) },
                    { ItemStat.crossbow_reload_stamina_drain, new Tuple<float, float, float, bool>(1, 1, 50, true) },
                    { ItemStat.projectile_velocity, new Tuple<float, float, float, bool>(200, 0, 300, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(10, 5) },
                    { "Bronze", new Tuple<int, int>(20, 10) },
                    { "Tar", new Tuple<int, int>(10, 2) },
                    { "LinenThread", new Tuple<int, int>(2, 2) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 4 }
                }
            );

            // Antler Bow
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Eikthyrs Bow" },
                    { ItemMetadata.catagory, "Bows" },
                    { ItemMetadata.prefab, "VAAntler_Bow" },
                    { ItemMetadata.sprite, "antler_bow" },
                    { ItemMetadata.craftedAt, "piece_workbench" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(26, 0, 120, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(2, 0, 25, true) },
                    { ItemStat.lightning, new Tuple<float, float, float, bool>(4, 0, 90, true) },
                    { ItemStat.lightning_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(5, 0, 50, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { ItemStat.draw_stamina_drain, new Tuple<float, float, float, bool>(6, 1, 50, true) },
                    { ItemStat.bow_draw_speed, new Tuple<float, float, float, bool>(2.5f, 0.01f, 2.5f, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(100, 0, 300, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.projectile_velocity, new Tuple<float, float, float, bool>(45, 0, 120, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(15, 5) },
                    { "Resin", new Tuple<int, int>(20, 10) },
                    { "HardAntler", new Tuple<int, int>(3, 3) },
                    { "TrophyEikthyr", new Tuple<int, int>(1, 1) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );

            // Bronze Crossbow
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Bronze Crossbow" },
                    { ItemMetadata.catagory, "Bows" },
                    { ItemMetadata.prefab, "VACrossbowBronze" },
                    { ItemMetadata.sprite, "bronze_crossbow2" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(80, 0, 300, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(3, 0, 60, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(150, 0, 300, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(100, 0, 300, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.crossbow_reload_speed, new Tuple<float, float, float, bool>(3.5f, 0.01f, 3.5f, true) },
                    { ItemStat.crossbow_reload_stamina_drain, new Tuple<float, float, float, bool>(1, 1, 50, true) },
                    { ItemStat.projectile_velocity, new Tuple<float, float, float, bool>(200, 0, 300, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(10, 5) },
                    { "RoundLog", new Tuple<int, int>(10, 5) },
                    { "Bronze", new Tuple<int, int>(4, 0) },
                    { "DeerHide", new Tuple<int, int>(2, 2) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 1 }
                }
            );

            // Elder Crossbow
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Elders Reach" },
                    { ItemMetadata.catagory, "Bows" },
                    { ItemMetadata.prefab, "VACrossbowElder" },
                    { ItemMetadata.sprite, "elder_crossbow" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(80, 0, 300, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { ItemStat.spirit, new Tuple<float, float, float, bool>(20, 0, 300, true) },
                    { ItemStat.spirit_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(3, 0, 60, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(150, 0, 300, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(100, 0, 300, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.crossbow_reload_speed, new Tuple<float, float, float, bool>(3.5f, 0.01f, 3.5f, true) },
                    { ItemStat.crossbow_reload_stamina_drain, new Tuple<float, float, float, bool>(1, 1, 50, true) },
                    { ItemStat.projectile_velocity, new Tuple<float, float, float, bool>(200, 0, 300, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Bronze", new Tuple<int, int>(4, 2) },
                    { "RoundLog", new Tuple<int, int>(20, 10) },
                    { "CryptKey", new Tuple<int, int>(1, 0) },
                    { "TrophyTheElder", new Tuple<int, int>(1, 0) },
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );

            // Moder Crossbow
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Moder Crossbow" },
                    { ItemMetadata.catagory, "Bows" },
                    { ItemMetadata.prefab, "VACrossbowModer" },
                    { ItemMetadata.sprite, "moder_crossbow" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(150, 0, 300, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { ItemStat.frost, new Tuple<float, float, float, bool>(25, 0, 300, true) },
                    { ItemStat.frost_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(3, 0, 60, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(200, 0, 300, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(100, 0, 300, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.crossbow_reload_speed, new Tuple<float, float, float, bool>(3.5f, 0.01f, 3.5f, true) },
                    { ItemStat.crossbow_reload_stamina_drain, new Tuple<float, float, float, bool>(1, 1, 50, true) },
                    { ItemStat.projectile_velocity, new Tuple<float, float, float, bool>(200, 0, 300, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(10, 5) },
                    { "Obsidian", new Tuple<int, int>(20, 10) },
                    { "DragonTear", new Tuple<int, int>(10, 0) },
                    { "TrophyDragonQueen", new Tuple<int, int>(1, 0) },
                    { "Silver", new Tuple<int, int>(0, 6) },
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 4 }
                }
            );

            // Queen Bow
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Queens Greatbow" },
                    { ItemMetadata.catagory, "Bows" },
                    { ItemMetadata.prefab, "VAQueen_bow" },
                    { ItemMetadata.sprite, "queen_bow" },
                    { ItemMetadata.craftedAt, "blackforge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(72, 0, 200, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { ItemStat.poison, new Tuple<float, float, float, bool>(25, 0, 90, true) },
                    { ItemStat.poison_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.lightning, new Tuple<float, float, float, bool>(30, 0, 99, true) },
                    { ItemStat.lightning_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(25, 0, 50, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(100, 0, 300, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.draw_stamina_drain, new Tuple<float, float, float, bool>(12, 1, 50, true) },
                    { ItemStat.bow_draw_speed, new Tuple<float, float, float, bool>(3f, 0.01f, 3f, true) },
                    { ItemStat.projectile_velocity, new Tuple<float, float, float, bool>(60, 0, 120, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "YggdrasilWood", new Tuple<int, int>(10, 5) },
                    { "Eitr", new Tuple<int, int>(20, 10) },
                    { "JuteBlue", new Tuple<int, int>(4, 0) },
                    { "TrophySeekerQueen", new Tuple<int, int>(1, 0) },
                    { "Carapace", new Tuple<int, int>(0, 4) },
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );
        }

        private void LoadSwords()
        {
            Logger.LogInfo("Loading Swords");
            // Blackmetal Greatsword
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Blackmetal Greatsword" },
                    { ItemMetadata.catagory, "Swords" },
                    { ItemMetadata.prefab, "VABlackmetal_greatsword" },
                    { ItemMetadata.sprite, "blackmetal_greatsword" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(125, 0, 250, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(55, 0, 120, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(52, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(50, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(18, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(36, 1, 50, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "BlackMetal", new Tuple<int, int>(30, 10) },
                    { "LinenThread", new Tuple<int, int>(10, 5) },
                    { "FineWood", new Tuple<int, int>(6, 3) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 4 }
                }
            );
            // Abyssal Sword
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Abyssal Sword" },
                    { ItemMetadata.catagory, "Swords" },
                    { ItemMetadata.prefab, "VASwordChitin" },
                    { ItemMetadata.sprite, "chitin_sword" },
                    { ItemMetadata.craftedAt, "piece_workbench" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.blunt, new Tuple<float, float, float, bool>(20, 0, 90, true) },
                    { ItemStat.blunt_per_level, new Tuple<float, float, float, bool>(4, 0, 25, true) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(25, 0, 120, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(2, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(40, 0, 120, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(18, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(20, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(10, 1, 30, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(20, 1, 50, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(2, 1) },
                    { "Chitin", new Tuple<int, int>(30, 15) },
                    { "DeerHide", new Tuple<int, int>(2, 0) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );

            // Antler Sword
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Eikthyrs Sword" },
                    { ItemMetadata.catagory, "Swords" },
                    { ItemMetadata.prefab, "VAAntler_Sword" },
                    { ItemMetadata.sprite, "antler_sword" },
                    { ItemMetadata.craftedAt, "piece_workbench" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(16, 0, 90, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(2, 0, 20, true) },
                    { ItemStat.blunt, new Tuple<float, float, float, bool>(8, 0, 90, true) },
                    { ItemStat.blunt_per_level, new Tuple<float, float, float, bool>(4, 0, 20, true) },
                    { ItemStat.lightning, new Tuple<float, float, float, bool>(6, 0, 120, true) },
                    { ItemStat.lightning_per_level, new Tuple<float, float, float, bool>(5, 0, 20, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(40, 0, 120, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(8, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(20, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(8, 1, 30, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(16, 1, 50, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(3, 1) },
                    { "Resin", new Tuple<int, int>(16, 8) },
                    { "HardAntler", new Tuple<int, int>(3, 3) },
                    { "TrophyEikthyr", new Tuple<int, int>(1, 1) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 1 }
                }
            );

            // Vine Sword
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Elders Balance" },
                    { ItemMetadata.catagory, "Swords" },
                    { ItemMetadata.prefab, "VAVine_Sword" },
                    { ItemMetadata.sprite, "vine_sword" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(35, 0, 90, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { ItemStat.spirit, new Tuple<float, float, float, bool>(20, 0, 120, true) },
                    { ItemStat.spirit_per_level, new Tuple<float, float, float, bool>(5, 0, 20, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(40, 0, 120, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(12, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(20, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(8, 1, 30, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(16, 1, 50, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Bronze", new Tuple<int, int>(2, 1) },
                    { "Stone", new Tuple<int, int>(16, 8) },
                    { "CryptKey", new Tuple<int, int>(1, 0) },
                    { "TrophyTheElder", new Tuple<int, int>(1, 0) },
                    { "RoundLog", new Tuple<int, int>(0, 4) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );

            // Ice Sword
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Moders Grasp" },
                    { ItemMetadata.catagory, "Swords" },
                    { ItemMetadata.prefab, "VASwordModer" },
                    { ItemMetadata.sprite, "moder_sword" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(35, 0, 90, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(2, 0, 20, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(30, 0, 90, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(4, 0, 20, true) },
                    { ItemStat.frost, new Tuple<float, float, float, bool>(25, 0, 120, true) },
                    { ItemStat.frost_per_level, new Tuple<float, float, float, bool>(1, 0, 20, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(40, 0, 120, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(30, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(20, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(12, 1, 30, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(24, 1, 50, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(4, 2) },
                    { "Obsidian", new Tuple<int, int>(30, 15) },
                    { "DragonTear", new Tuple<int, int>(10, 0) },
                    { "TrophyDragonQueen", new Tuple<int, int>(1, 0) },
                    { "Silver", new Tuple<int, int>(0, 2) },
                    { "JuteRed", new Tuple<int, int>(0, 2) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 4 }
                }
            );

            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Moders Greatsword" },
                    { ItemMetadata.catagory, "Swords" },
                    { ItemMetadata.prefab, "VAModer_greatsword" },
                    { ItemMetadata.sprite, "moder_greatsword" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(55, 0, 90, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(2, 0, 20, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(40, 0, 90, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(4, 0, 20, true) },
                    { ItemStat.frost, new Tuple<float, float, float, bool>(25, 0, 120, true) },
                    { ItemStat.frost_per_level, new Tuple<float, float, float, bool>(1, 0, 20, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(55, 0, 120, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(48, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(50, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(17, 1, 30, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(34, 1, 50, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Crystal", new Tuple<int, int>(25, 10) },
                    { "Obsidian", new Tuple<int, int>(15, 10) },
                    { "DragonTear", new Tuple<int, int>(10, 0) },
                    { "TrophyDragonQueen", new Tuple<int, int>(1, 0) },
                    { "Silver", new Tuple<int, int>(0, 4) },
                    { "JuteRed", new Tuple<int, int>(0, 2) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 4 }
                }
            );

            // Bronze Greatsword
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Bronze Greatsword" },
                    { ItemMetadata.catagory, "Swords" },
                    { ItemMetadata.prefab, "VAbronze_greatsword" },
                    { ItemMetadata.sprite, "bronze_greatsword_reforged" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(50, 0, 200, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(55, 0, 160, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(16, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(50, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(12, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(24, 1, 50, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "RoundLog", new Tuple<int, int>(4, 0) },
                    { "Bronze", new Tuple<int, int>(20, 10) },
                    { "DeerHide", new Tuple<int, int>(3, 0) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 1 }
                }
            );

            // Iron Greatsword
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Iron Greatsword" },
                    { ItemMetadata.catagory, "Swords" },
                    { ItemMetadata.prefab, "VAiron_greatsword" },
                    { ItemMetadata.sprite, "iron_greatsword_reforged" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(75, 0, 250, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(55, 0, 160, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(28, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(50, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(14, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(28, 1, 50, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(15, 5) },
                    { "Iron", new Tuple<int, int>(30, 15) },
                    { "LeatherScraps", new Tuple<int, int>(4, 0) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );

            // Silver Greatsword
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Silver Greatsword" },
                    { ItemMetadata.catagory, "Swords" },
                    { ItemMetadata.prefab, "VAsilver_greatsword" },
                    { ItemMetadata.sprite, "silver_greatsword_reforged" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(100, 0, 300, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { ItemStat.spirit, new Tuple<float, float, float, bool>(30, 0, 120, true) },
                    { ItemStat.spirit_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(55, 0, 160, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(40, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(50, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(16, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(32, 1, 50, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(10, 5) },
                    { "Silver", new Tuple<int, int>(25, 10) },
                    { "Iron", new Tuple<int, int>(4, 2) },
                    { "LeatherScraps", new Tuple<int, int>(3, 1) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 3 }
                }

            );

            // Bonemass Greatsword
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Bonemasses Greatsword" },
                    { ItemMetadata.catagory, "Swords" },
                    { ItemMetadata.prefab, "VABonemassGreatsword" },
                    { ItemMetadata.sprite, "bonemass_greatsword" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(75, 0, 250, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { ItemStat.poison, new Tuple<float, float, float, bool>(20, 0, 250, true) },
                    { ItemStat.poison_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(55, 0, 160, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(36, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(50, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(15, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(30, 1, 50, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "WitheredBone", new Tuple<int, int>(15, 5) },
                    { "Iron", new Tuple<int, int>(30, 15) },
                    { "Wishbone", new Tuple<int, int>(1, 0) },
                    { "TrophyBonemass", new Tuple<int, int>(1, 0) },
                    { "ElderBark", new Tuple<int, int>(0, 2) },
                    { "LeatherScraps", new Tuple<int, int>(0, 2) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 3 }
                }
            );

            // Yagluth Greatsword
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Yagluths Greatsword" },
                    { ItemMetadata.catagory, "Swords" },
                    { ItemMetadata.prefab, "VAYagluth_greatsword" },
                    { ItemMetadata.sprite, "yagluth_greatsword" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(125, 0, 250, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { ItemStat.fire, new Tuple<float, float, float, bool>(25, 0, 250, true) },
                    { ItemStat.fire_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(55, 0, 160, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(49, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(50, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(18, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(36, 1, 50, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "BlackMetal", new Tuple<int, int>(10, 5) },
                    { "Iron", new Tuple<int, int>(4, 2) },
                    { "YagluthDrop", new Tuple<int, int>(2, 0) },
                    { "TrophyGoblinKing", new Tuple<int, int>(1, 0) },
                    { "Tar", new Tuple<int, int>(0, 3) },
                    { "LinenThread", new Tuple<int, int>(0, 2) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 4 }
                }
            );

            // Flint Sword
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Flint Sword" },
                    { ItemMetadata.catagory, "Swords" },
                    { ItemMetadata.prefab, "VAFlint_Sword" },
                    { ItemMetadata.sprite, "flint_sword" },
                    { ItemMetadata.craftedAt, "piece_workbench" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(15, 0, 90, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(40, 0, 120, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(4, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(20, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(6, 1, 30, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(12, 1, 50, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(2, 0) },
                    { "Flint", new Tuple<int, int>(6, 3) },
                    { "LeatherScraps", new Tuple<int, int>(0, 2) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 1 }
                }
            );

            // Flint Greatsword
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Flint Greatsword" },
                    { ItemMetadata.catagory, "Swords" },
                    { ItemMetadata.prefab, "VAFlint_greatsword" },
                    { ItemMetadata.sprite, "flint_greatsword" },
                    { ItemMetadata.craftedAt, "piece_workbench" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(25, 0, 200, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(55, 0, 160, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(14, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(50, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(10, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(20, 1, 50, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(4, 0) },
                    { "Flint", new Tuple<int, int>(9, 5) },
                    { "LeatherScraps", new Tuple<int, int>(0, 2) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 1 }
                }
            );

            // Queen Greatsword
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Queen Greatsword" },
                    { ItemMetadata.catagory, "Swords" },
                    { ItemMetadata.prefab, "VAQueen_greatsword" },
                    { ItemMetadata.sprite, "queen_greatsword" },
                    { ItemMetadata.craftedAt, "blackforge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(125, 0, 250, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { ItemStat.poison, new Tuple<float, float, float, bool>(25, 0, 250, true) },
                    { ItemStat.poison_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.lightning, new Tuple<float, float, float, bool>(30, 0, 99, true) },
                    { ItemStat.lightning_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(55, 0, 160, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(62, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(50, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(20, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(40, 1, 50, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "YggdrasilWood", new Tuple<int, int>(10, 5) },
                    { "Eitr", new Tuple<int, int>(20, 10) },
                    { "JuteBlue", new Tuple<int, int>(4, 2) },
                    { "TrophySeekerQueen", new Tuple<int, int>(1, 0) },
                    { "Carapace", new Tuple<int, int>(0, 8) },
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );

            // Queen sword
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Queen Sword" },
                    { ItemMetadata.catagory, "Swords" },
                    { ItemMetadata.prefab, "VASwordQueen" },
                    { ItemMetadata.sprite, "queen_sword" },
                    { ItemMetadata.craftedAt, "blackforge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(95, 0, 250, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { ItemStat.poison, new Tuple<float, float, float, bool>(25, 0, 250, true) },
                    { ItemStat.poison_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.lightning, new Tuple<float, float, float, bool>(30, 0, 99, true) },
                    { ItemStat.lightning_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(40, 0, 160, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(52, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(20, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(16, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(32, 1, 50, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "YggdrasilWood", new Tuple<int, int>(3, 1) },
                    { "Eitr", new Tuple<int, int>(10, 5) },
                    { "JuteBlue", new Tuple<int, int>(3, 1) },
                    { "TrophySeekerQueen", new Tuple<int, int>(1, 0) },
                    { "Carapace", new Tuple<int, int>(0, 6) },
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );
        }

        private void LoadAxes()
        {
            Logger.LogInfo("Loading Axes");
            // Flint Battleaxe
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Flint greataxe" },
                    { ItemMetadata.catagory, "Axes" },
                    { ItemMetadata.prefab, "VAFlint_greataxe" },
                    { ItemMetadata.sprite, "flint_greataxe" },
                    { ItemMetadata.craftedAt, "piece_workbench" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(25, 0, 200, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.chop, new Tuple<float, float, float, bool>(45, 0, 200, true) },
                    { ItemStat.chop_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(70, 0, 200, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(14, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(70, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(12, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(24, 1, 20, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(8, 0) },
                    { "Flint", new Tuple<int, int>(9, 5) },
                    { "LeatherScraps", new Tuple<int, int>(0, 2) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 1 }
                }
            );

            // Flint Dualaxes
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Flint dualaxes" },
                    { ItemMetadata.catagory, "Axes" },
                    { ItemMetadata.prefab, "VAFlint_dualaxes" },
                    { ItemMetadata.sprite, "flint_dualaxes" },
                    { ItemMetadata.craftedAt, "piece_workbench" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(20, 0, 200, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.chop, new Tuple<float, float, float, bool>(30, 0, 200, true) },
                    { ItemStat.chop_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(50, 0, 200, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(12, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(175, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(6, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(14, 1, 20, true) },
                    { ItemStat.movement_speed, new Tuple<float, float, float, bool>(-0.05f, -0.20f, 0, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(10, 2) },
                    { "Flint", new Tuple<int, int>(12, 6) },
                    { "LeatherScraps", new Tuple<int, int>(0, 2) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 1 }
                }
            );

            // Bronze Battleaxe
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Bronze Lumber Axe" },
                    { ItemMetadata.catagory, "Axes" },
                    { ItemMetadata.prefab, "VAbronze_battleaxe" },
                    { ItemMetadata.sprite, "bronze_axe_rebuild" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(50, 0, 200, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { ItemStat.chop, new Tuple<float, float, float, bool>(30, 0, 200, true) },
                    { ItemStat.chop_per_level, new Tuple<float, float, float, bool>(2.5f, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(70, 0, 200, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(18, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(70, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(14, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(28, 1, 20, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "RoundLog", new Tuple<int, int>(20, 5) },
                    { "Bronze", new Tuple<int, int>(10, 5) },
                    { "DeerHide", new Tuple<int, int>(2, 0) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 1 }
                }
            );

            // Bronze Dualaxes
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Bronze dualaxes" },
                    { ItemMetadata.catagory, "Axes" },
                    { ItemMetadata.prefab, "VABronze_dualaxes" },
                    { ItemMetadata.sprite, "bronze_dualaxes" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(40, 0, 200, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.chop, new Tuple<float, float, float, bool>(40, 0, 200, true) },
                    { ItemStat.chop_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(50, 0, 200, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(16, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(175, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(8, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(16, 1, 20, true) },
                    { ItemStat.movement_speed, new Tuple<float, float, float, bool>(-0.05f, -0.20f, 0, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(8, 0) },
                    { "Bronze", new Tuple<int, int>(16, 8) },
                    { "LeatherScraps", new Tuple<int, int>(4, 1) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 1 }
                }
            );

            // Iron Dualaxes
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Iron dualaxes" },
                    { ItemMetadata.catagory, "Axes" },
                    { ItemMetadata.prefab, "VAIron_dualaxes" },
                    { ItemMetadata.sprite, "iron_dualaxes" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(60, 0, 200, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.chop, new Tuple<float, float, float, bool>(50, 0, 200, true) },
                    { ItemStat.chop_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(50, 0, 200, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(21, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(175, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(10, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(18, 1, 20, true) },
                    { ItemStat.movement_speed, new Tuple<float, float, float, bool>(-0.05f, -0.20f, 0, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(8, 0) },
                    { "Iron", new Tuple<int, int>(40, 20) },
                    { "LeatherScraps", new Tuple<int, int>(4, 2) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );

            // Crystal Axe
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Crystal Axe" },
                    { ItemMetadata.catagory, "Axes" },
                    { ItemMetadata.prefab, "VAcrystal_axe" },
                    { ItemMetadata.sprite, "silver_axe_1h_icon" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(80, 0, 200, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.spirit, new Tuple<float, float, float, bool>(30, 0, 200, true) },
                    { ItemStat.spirit_per_level, new Tuple<float, float, float, bool>(0, 0, 25, true) },
                    { ItemStat.chop, new Tuple<float, float, float, bool>(45, 0, 200, true) },
                    { ItemStat.chop_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(80, 0, 200, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(26, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(175, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(12, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(24, 1, 50, true) },
                    { ItemStat.movement_speed, new Tuple<float, float, float, bool>(-0.05f, -0.20f, 0, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(15, 4) },
                    { "Silver", new Tuple<int, int>(20, 10) },
                    { "Crystal", new Tuple<int, int>(8, 0) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 3 }
                }
            );

            // Crystal dual Axes
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Crystal dualaxes" },
                    { ItemMetadata.catagory, "Axes" },
                    { ItemMetadata.prefab, "VACrystal_dualaxes" },
                    { ItemMetadata.sprite, "crystal_dualaxes" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(80, 0, 200, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.spirit, new Tuple<float, float, float, bool>(30, 0, 200, true) },
                    { ItemStat.spirit_per_level, new Tuple<float, float, float, bool>(0, 0, 25, true) },
                    { ItemStat.chop, new Tuple<float, float, float, bool>(50, 0, 200, true) },
                    { ItemStat.chop_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(50, 0, 200, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(30, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(175, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(12, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(20, 1, 20, true) },
                    { ItemStat.movement_speed, new Tuple<float, float, float, bool>(-0.05f, -0.20f, 0, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(30, 8) },
                    { "Silver", new Tuple<int, int>(50, 20) },
                    { "Crystal", new Tuple<int, int>(16, 0) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 3 }
                }
            );

            // Blackmetal Dual Axes
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Blackmetal dualaxes" },
                    { ItemMetadata.catagory, "Axes" },
                    { ItemMetadata.prefab, "VABlackmetal_dualaxes" },
                    { ItemMetadata.sprite, "blackmetal_dualaxes" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(100, 0, 200, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.chop, new Tuple<float, float, float, bool>(60, 0, 200, true) },
                    { ItemStat.chop_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(50, 0, 200, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(39, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(175, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(14, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(22, 1, 20, true) },
                    { ItemStat.movement_speed, new Tuple<float, float, float, bool>(-0.05f, -0.20f, 0, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "BlackMetal", new Tuple<int, int>(50, 20) },
                    { "FineWood", new Tuple<int, int>(14, 5) },
                    { "LinenThread", new Tuple<int, int>(8, 0) },
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 3 }
                }
            );

            // Blackmetal Greataxe
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Blackmetal Greataxe" },
                    { ItemMetadata.catagory, "Axes" },
                    { ItemMetadata.prefab, "VAblackmetal_2h_axe" },
                    { ItemMetadata.sprite, "blackmetal_2h_axe" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(130, 0, 300, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.chop, new Tuple<float, float, float, bool>(60, 0, 300, true) },
                    { ItemStat.chop_per_level, new Tuple<float, float, float, bool>(2.5f, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(70, 0, 200, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(52, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(70, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(20, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(10, 1, 50, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(10, 5) },
                    { "BlackMetal", new Tuple<int, int>(35, 15) },
                    { "LinenThread", new Tuple<int, int>(5, 1) },
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 4 }
                }
            );

            // Jotun Dual Axes
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Jotun dualaxes" },
                    { ItemMetadata.catagory, "Axes" },
                    { ItemMetadata.prefab, "VAJotunn_dualaxes" },
                    { ItemMetadata.sprite, "jotun_dualaxes" },
                    { ItemMetadata.craftedAt, "blackforge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(120, 0, 200, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.poison, new Tuple<float, float, float, bool>(30, 0, 200, true) },
                    { ItemStat.poison_per_level, new Tuple<float, float, float, bool>(0, 0, 25, true) },
                    { ItemStat.chop, new Tuple<float, float, float, bool>(80, 0, 200, true) },
                    { ItemStat.chop_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(50, 0, 200, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(48, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(175, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(15, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(24, 1, 20, true) },
                    { ItemStat.movement_speed, new Tuple<float, float, float, bool>(-0.05f, -0.20f, 0, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Eitr", new Tuple<int, int>(35, 30) },
                    { "Iron", new Tuple<int, int>(25, 20) },
                    { "YggdrasilWood", new Tuple<int, int>(14, 5) },
                    { "Bilebag", new Tuple<int, int>(6, 2) },
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 1 }
                }
            );

            // Jotun 2H Axe
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Jotun battleaxe" },
                    { ItemMetadata.catagory, "Axes" },
                    { ItemMetadata.prefab, "VAJotunn_2h_axe" },
                    { ItemMetadata.sprite, "jotun_2h_axe" },
                    { ItemMetadata.craftedAt, "blackforge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(140, 0, 200, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.poison, new Tuple<float, float, float, bool>(13, 0, 200, true) },
                    { ItemStat.poison_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.chop, new Tuple<float, float, float, bool>(90, 0, 200, true) },
                    { ItemStat.chop_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(50, 0, 200, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(60, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(175, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(22, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(11, 1, 50, true) },
                    { ItemStat.movement_speed, new Tuple<float, float, float, bool>(-0.05f, -0.20f, 0, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Eitr", new Tuple<int, int>(30, 20) },
                    { "Iron", new Tuple<int, int>(20, 15) },
                    { "YggdrasilWood", new Tuple<int, int>(14, 5) },
                    { "Bilebag", new Tuple<int, int>(6, 2) },
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 1 }
                }
            );

            // Jotunn halfblade
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Jotun halfblade" },
                    { ItemMetadata.catagory, "Axes" },
                    { ItemMetadata.prefab, "VAJotunn_single_axe" },
                    { ItemMetadata.sprite, "jotunn_halfblade" },
                    { ItemMetadata.craftedAt, "blackforge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(80, 0, 200, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.poison, new Tuple<float, float, float, bool>(40, 0, 200, true) },
                    { ItemStat.poison_per_level, new Tuple<float, float, float, bool>(0, 0, 25, true) },
                    { ItemStat.chop, new Tuple<float, float, float, bool>(70, 0, 200, true) },
                    { ItemStat.chop_per_level, new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(50, 0, 200, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(48, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(175, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(16, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(32, 1, 50, true) },
                    { ItemStat.movement_speed, new Tuple<float, float, float, bool>(-0.05f, -0.20f, 0, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Eitr", new Tuple<int, int>(10, 1) },
                    { "Iron", new Tuple<int, int>(15, 10) },
                    { "YggdrasilWood", new Tuple<int, int>(5, 0) },
                    { "Bilebag", new Tuple<int, int>(3, 1) },
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 1 }
                },
                new Dictionary<ItemToggles, bool>() {
                    { ItemToggles.enabled, true },
                    { ItemToggles.craftable, false }
                }
            );

            // Antler Battleaxe
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Eikthyrs Greataxe" },
                    { ItemMetadata.catagory, "Axes" },
                    { ItemMetadata.prefab, "VAAntler_greataxe" },
                    { ItemMetadata.sprite, "antler_greataxe" },
                    { ItemMetadata.craftedAt, "piece_workbench" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.blunt, new Tuple<float, float, float, bool>(10, 0, 200, true) },
                    { ItemStat.blunt_per_level, new Tuple<float, float, float, bool>(2, 0, 25, true) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(25, 0, 200, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(2, 0, 25, true) },
                    { ItemStat.lightning, new Tuple<float, float, float, bool>(10, 0, 200, true) },
                    { ItemStat.lightning_per_level, new Tuple<float, float, float, bool>(2, 0, 25, true) },
                    { ItemStat.chop, new Tuple<float, float, float, bool>(30, 0, 200, true) },
                    { ItemStat.chop_per_level, new Tuple<float, float, float, bool>(2.5f, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(70, 0, 200, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(18, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(70, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(14, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(28, 1, 20, true) },
                    { ItemStat.movement_speed, new Tuple<float, float, float, bool>(-0.20f, -0.20f, 0, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(15, 0) },
                    { "Resin", new Tuple<int, int>(30, 15) },
                    { "HardAntler", new Tuple<int, int>(3, 3) },
                    { "TrophyEikthyr", new Tuple<int, int>(1, 1) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );

            // Blackmetal Battleaxe
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Blackmetal Battleaxe" },
                    { ItemMetadata.catagory, "Axes" },
                    { ItemMetadata.prefab, "VAblackmetal_battleaxe" },
                    { ItemMetadata.sprite, "blackmetal_battleaxe" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(120, 0, 300, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.chop, new Tuple<float, float, float, bool>(60, 0, 300, true) },
                    { ItemStat.chop_per_level, new Tuple<float, float, float, bool>(2.5f, 0, 25, true) },
                    { ItemStat.fire, new Tuple<float, float, float, bool>(20, 0, 160, true) },
                    { ItemStat.fire_per_level, new Tuple<float, float, float, bool>(0, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(70, 0, 200, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(52, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(70, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(22, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(10, 1, 50, true) },
                    { ItemStat.movement_speed, new Tuple<float, float, float, bool>(-0.20f, -0.20f, 0, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(10, 5) },
                    { "BlackMetal", new Tuple<int, int>(35, 15) },
                    { "LinenThread", new Tuple<int, int>(5, 0) },
                    { "SurtlingCore", new Tuple<int, int>(4, 0) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 4 }
                },
                new Dictionary<ItemToggles, bool>() {
                    { ItemToggles.enabled, true },
                    { ItemToggles.craftable, false }
                }
            );

            // Flametal Battleaxe
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Flametal Battleaxe" },
                    { ItemMetadata.catagory, "Axes" },
                    { ItemMetadata.prefab, "VAFlametalAxe_2h" },
                    { ItemMetadata.sprite, "flametal_battleaxe" },
                    { ItemMetadata.craftedAt, "blackforge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(150, 0, 300, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.chop, new Tuple<float, float, float, bool>(90, 0, 300, true) },
                    { ItemStat.chop_per_level, new Tuple<float, float, float, bool>(2.5f, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(70, 0, 200, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(78, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(70, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(28, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(12, 1, 50, true) },
                    { ItemStat.movement_speed, new Tuple<float, float, float, bool>(-0.20f, -0.20f, 0, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Blackwood", new Tuple<int, int>(10, 5) },
                    { "FlametalNew", new Tuple<int, int>(20, 10) },
                    { "CharredBone", new Tuple<int, int>(20, 15) },
                    { "AskHide", new Tuple<int, int>(4, 0) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                },
                new Dictionary<ItemToggles, bool>() {
                    { ItemToggles.enabled, true },
                    { ItemToggles.craftable, true }
                }
            );

            // Flametal Primal Battleaxe
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Flametal Primal Battleaxe" },
                    { ItemMetadata.catagory, "Axes" },
                    { ItemMetadata.prefab, "VAFlametalAxe_primal_2h" },
                    { ItemMetadata.sprite, "flametal_battleaxe_primal" },
                    { ItemMetadata.craftedAt, "blackforge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(150, 0, 300, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.poison, new Tuple<float, float, float, bool>(25, 0, 300, true) },
                    { ItemStat.poison_per_level, new Tuple<float, float, float, bool>(3, 0, 20, true) },
                    { ItemStat.chop, new Tuple<float, float, float, bool>(90, 0, 300, true) },
                    { ItemStat.chop_per_level, new Tuple<float, float, float, bool>(2.5f, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(70, 0, 200, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(78, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(70, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(28, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(12, 1, 50, true) },
                    { ItemStat.movement_speed, new Tuple<float, float, float, bool>(-0.20f, -0.20f, 0, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "VAFlametalAxe_2h", new Tuple<int, int>(1, 0) },
                    { "Blackwood", new Tuple<int, int>(5, 0) },
                    { "FlametalNew", new Tuple<int, int>(10, 5) },
                    { "GemstoneGreen", new Tuple<int, int>(1, 1) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                },
                new Dictionary<ItemToggles, bool>() {
                    { ItemToggles.enabled, true },
                    { ItemToggles.craftable, true }
                }
            );

            // Flametal Lightning Battleaxe
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Flametal Lightning Battleaxe" },
                    { ItemMetadata.catagory, "Axes" },
                    { ItemMetadata.prefab, "VAFlametalAxe_lightning_2h" },
                    { ItemMetadata.sprite, "flametal_battleaxe_lightning" },
                    { ItemMetadata.craftedAt, "blackforge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(150, 0, 300, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.lightning, new Tuple<float, float, float, bool>(20, 0, 300, true) },
                    { ItemStat.lightning_per_level, new Tuple<float, float, float, bool>(2, 0, 20, true) },
                    { ItemStat.chop, new Tuple<float, float, float, bool>(90, 0, 300, true) },
                    { ItemStat.chop_per_level, new Tuple<float, float, float, bool>(2.5f, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(70, 0, 200, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(78, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(70, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(28, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(12, 1, 50, true) },
                    { ItemStat.movement_speed, new Tuple<float, float, float, bool>(-0.20f, -0.20f, 0, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "VAFlametalAxe_2h", new Tuple<int, int>(1, 0) },
                    { "Blackwood", new Tuple<int, int>(5, 0) },
                    { "FlametalNew", new Tuple<int, int>(10, 5) },
                    { "GemstoneBlue", new Tuple<int, int>(1, 1) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                },
                new Dictionary<ItemToggles, bool>() {
                    { ItemToggles.enabled, true },
                    { ItemToggles.craftable, true }
                }
            );

            // Flametal Blood Battleaxe
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Flametal Blood Battleaxe" },
                    { ItemMetadata.catagory, "Axes" },
                    { ItemMetadata.prefab, "VAFlametalAxe_blood_2h" },
                    { ItemMetadata.sprite, "flametal_battleaxe_blood" },
                    { ItemMetadata.craftedAt, "blackforge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(150, 0, 300, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.chop, new Tuple<float, float, float, bool>(90, 0, 300, true) },
                    { ItemStat.chop_per_level, new Tuple<float, float, float, bool>(2.5f, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(70, 0, 200, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(78, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(70, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(28, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(12, 1, 50, true) },
                    { ItemStat.movement_speed, new Tuple<float, float, float, bool>(-0.20f, -0.20f, 0, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "VAFlametalAxe_2h", new Tuple<int, int>(1, 0) },
                    { "Blackwood", new Tuple<int, int>(5, 0) },
                    { "FlametalNew", new Tuple<int, int>(10, 5) },
                    { "GemstoneRed", new Tuple<int, int>(1, 1) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                },
                new Dictionary<ItemToggles, bool>() {
                    { ItemToggles.enabled, true },
                    { ItemToggles.craftable, true }
                }
            );

            // Flametal Axe
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Flametal Axe" },
                    { ItemMetadata.catagory, "Axes" },
                    { ItemMetadata.prefab, "VAFlametal_Axe" },
                    { ItemMetadata.sprite, "flametalAxeBase" },
                    { ItemMetadata.craftedAt, "blackforge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(140, 0, 200, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.chop, new Tuple<float, float, float, bool>(80, 0, 200, true) },
                    { ItemStat.chop_per_level, new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(50, 0, 200, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(48, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(175, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(18, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(36, 1, 50, true) },
                    { ItemStat.movement_speed, new Tuple<float, float, float, bool>(-0.05f, -0.20f, 0, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FlametalNew", new Tuple<int, int>(12, 6) },
                    { "AskHide", new Tuple<int, int>(4, 1) },
                    { "CharredBone", new Tuple<int, int>(10, 0) },
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 1 }
                },
                new Dictionary<ItemToggles, bool>() {
                    { ItemToggles.enabled, true },
                    { ItemToggles.craftable, true }
                }
            );

            // Flametal Primal Axe
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Flametal Primal Axe" },
                    { ItemMetadata.catagory, "Axes" },
                    { ItemMetadata.prefab, "VAFlametal_Axe_Primal" },
                    { ItemMetadata.sprite, "flametal_axe_1h_primal" },
                    { ItemMetadata.craftedAt, "blackforge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(140, 0, 200, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.poison, new Tuple<float, float, float, bool>(25, 0, 300, true) },
                    { ItemStat.poison_per_level, new Tuple<float, float, float, bool>(3, 0, 20, true) },
                    { ItemStat.chop, new Tuple<float, float, float, bool>(80, 0, 200, true) },
                    { ItemStat.chop_per_level, new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(50, 0, 200, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(48, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(175, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(18, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(36, 1, 50, true) },
                    { ItemStat.movement_speed, new Tuple<float, float, float, bool>(-0.05f, -0.20f, 0, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FlametalNew", new Tuple<int, int>(12, 6) },
                    { "GemstoneGreen", new Tuple<int, int>(4, 1) },
                    { "CharredBone", new Tuple<int, int>(10, 0) },
                    { "VAFlametal_Axe", new Tuple<int, int>(1, 0) },
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 1 }
                },
                new Dictionary<ItemToggles, bool>() {
                    { ItemToggles.enabled, true },
                    { ItemToggles.craftable, true }
                }
            );

            // Flametal Lightning Axe
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Flametal Lightning Axe" },
                    { ItemMetadata.catagory, "Axes" },
                    { ItemMetadata.prefab, "VAFlametal_Axe_Lightning" },
                    { ItemMetadata.sprite, "flametal_axe_1h_lightning" },
                    { ItemMetadata.craftedAt, "blackforge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(140, 0, 200, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.lightning, new Tuple<float, float, float, bool>(20, 0, 300, true) },
                    { ItemStat.lightning_per_level, new Tuple<float, float, float, bool>(2, 0, 20, true) },
                    { ItemStat.chop, new Tuple<float, float, float, bool>(80, 0, 200, true) },
                    { ItemStat.chop_per_level, new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(50, 0, 200, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(48, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(175, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(18, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(36, 1, 50, true) },
                    { ItemStat.movement_speed, new Tuple<float, float, float, bool>(-0.05f, -0.20f, 0, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FlametalNew", new Tuple<int, int>(12, 6) },
                    { "GemstoneBlue", new Tuple<int, int>(4, 1) },
                    { "CharredBone", new Tuple<int, int>(10, 0) },
                    { "VAFlametal_Axe", new Tuple<int, int>(1, 0) },
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 1 }
                },
                new Dictionary<ItemToggles, bool>() {
                    { ItemToggles.enabled, true },
                    { ItemToggles.craftable, true }
                }
            );

            // Flametal Blood Axe
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Flametal Blood Axe" },
                    { ItemMetadata.catagory, "Axes" },
                    { ItemMetadata.prefab, "VAFlametal_Axe_Blood" },
                    { ItemMetadata.sprite, "flametal_axe_1h_blood" },
                    { ItemMetadata.craftedAt, "blackforge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(140, 0, 200, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.chop, new Tuple<float, float, float, bool>(80, 0, 200, true) },
                    { ItemStat.chop_per_level, new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(50, 0, 200, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(48, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(175, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(18, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(36, 1, 50, true) },
                    { ItemStat.movement_speed, new Tuple<float, float, float, bool>(-0.05f, -0.20f, 0, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FlametalNew", new Tuple<int, int>(12, 6) },
                    { "GemstoneBlue", new Tuple<int, int>(4, 1) },
                    { "CharredBone", new Tuple<int, int>(10, 0) },
                    { "VAFlametal_Axe", new Tuple<int, int>(1, 0) },
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 1 }
                },
                new Dictionary<ItemToggles, bool>() {
                    { ItemToggles.enabled, true },
                    { ItemToggles.craftable, true }
                }
            );

        }

        private void LoadHammers()
        {
            Logger.LogInfo("Loading Hammers");
            // Flametal Nature Sledge
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Flametal nature sledge" },
                    { ItemMetadata.catagory, "Hammers" },
                    { ItemMetadata.prefab, "VAflametal_sledge_nature" },
                    { ItemMetadata.sprite, "flametal_sledge_nature" },
                    { ItemMetadata.craftedAt, "blackforge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.blunt, new Tuple<float, float, float, bool>(165, 0, 300, true) },
                    { ItemStat.blunt_per_level, new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { ItemStat.poison, new Tuple<float, float, float, bool>(25, 0, 300, true) },
                    { ItemStat.poison_per_level, new Tuple<float, float, float, bool>(3, 0, 20, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(210, 0, 400, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(64, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(50, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(100, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(24, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(30, 1, 50, true) },
                    { ItemStat.movement_speed, new Tuple<float, float, float, bool>(-0.20f, -0.20f, 0, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "VAflametal_sledge", new Tuple<int, int>(1, 0) },
                    { "FlametalNew", new Tuple<int, int>(8, 8) },
                    { "Blackwood", new Tuple<int, int>(5, 0) },
                    { "GemstoneGreen", new Tuple<int, int>(1, 1) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );

            // Flametal Lightning Sledge
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Flametal lightning sledge" },
                    { ItemMetadata.catagory, "Hammers" },
                    { ItemMetadata.prefab, "VAflametal_sledge_lightning" },
                    { ItemMetadata.sprite, "flametal_sledge_lightning" },
                    { ItemMetadata.craftedAt, "blackforge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.blunt, new Tuple<float, float, float, bool>(165, 0, 300, true) },
                    { ItemStat.blunt_per_level, new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { ItemStat.lightning, new Tuple<float, float, float, bool>(20, 0, 300, true) },
                    { ItemStat.lightning_per_level, new Tuple<float, float, float, bool>(2, 0, 20, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(210, 0, 400, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(64, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(50, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(100, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(24, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(30, 1, 50, true) },
                    { ItemStat.movement_speed, new Tuple<float, float, float, bool>(-0.20f, -0.20f, 0, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "VAflametal_sledge", new Tuple<int, int>(1, 0) },
                    { "FlametalNew", new Tuple<int, int>(8, 8) },
                    { "Blackwood", new Tuple<int, int>(5, 0) },
                    { "GemstoneBlue", new Tuple<int, int>(1, 1) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );

            // Flametal Blood Sledge
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Flametal blood sledge" },
                    { ItemMetadata.catagory, "Hammers" },
                    { ItemMetadata.prefab, "VAflametal_sledge_blood" },
                    { ItemMetadata.sprite, "flametal_sledge_blood" },
                    { ItemMetadata.craftedAt, "blackforge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.blunt, new Tuple<float, float, float, bool>(175, 0, 300, true) },
                    { ItemStat.blunt_per_level, new Tuple<float, float, float, bool>(10, 0, 20, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(210, 0, 400, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(64, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(50, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(100, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(24, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(30, 1, 50, true) },
                    { ItemStat.movement_speed, new Tuple<float, float, float, bool>(-0.20f, -0.20f, 0, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "VAflametal_sledge", new Tuple<int, int>(1, 0) },
                    { "FlametalNew", new Tuple<int, int>(8, 8) },
                    { "Blackwood", new Tuple<int, int>(5, 0) },
                    { "GemstoneRed", new Tuple<int, int>(1, 1) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );

            // Flametal Sledge
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Flametal sledge" },
                    { ItemMetadata.catagory, "Hammers" },
                    { ItemMetadata.prefab, "VAflametal_sledge" },
                    { ItemMetadata.sprite, "flametal_sledge" },
                    { ItemMetadata.craftedAt, "blackforge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.blunt, new Tuple<float, float, float, bool>(165, 0, 300, true) },
                    { ItemStat.blunt_per_level, new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(210, 0, 400, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(64, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(50, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(100, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(24, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(30, 1, 50, true) },
                    { ItemStat.movement_speed, new Tuple<float, float, float, bool>(-0.20f, -0.20f, 0, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FlametalNew", new Tuple<int, int>(30, 15) },
                    { "Iron", new Tuple<int, int>(4, 0) },
                    { "Eitr", new Tuple<int, int>(6, 3) },
                    { "Blackwood", new Tuple<int, int>(12, 6) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );

            // Blackmarble mace
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Blackmarble mace" },
                    { ItemMetadata.catagory, "Hammers" },
                    { ItemMetadata.prefab, "VAmistland_mace" },
                    { ItemMetadata.sprite, "mist_mace" },
                    { ItemMetadata.craftedAt, "blackforge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.blunt, new Tuple<float, float, float, bool>(115, 0, 300, true) },
                    { ItemStat.blunt_per_level, new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(100, 0, 400, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(48, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(20, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(100, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(15, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(28, 1, 50, true) },
                    { ItemStat.movement_speed, new Tuple<float, float, float, bool>(-0.05f, -0.05f, 0, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "YggdrasilWood", new Tuple<int, int>(6, 4) },
                    { "Bronze", new Tuple<int, int>(10, 5) },
                    { "Eitr", new Tuple<int, int>(8, 2) },
                    { "BlackMarble", new Tuple<int, int>(20, 10) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 1 }
                }
            );

            // Blackmetal Sledge
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Blackmetal Sledge" },
                    { ItemMetadata.catagory, "Hammers" },
                    { ItemMetadata.prefab, "VAblackmetal_sledge" },
                    { ItemMetadata.sprite, "blackmetal_hammer" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.blunt, new Tuple<float, float, float, bool>(120, 0, 300, true) },
                    { ItemStat.blunt_per_level, new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { ItemStat.lightning, new Tuple<float, float, float, bool>(20, 0, 120, true) },
                    { ItemStat.lightning_per_level, new Tuple<float, float, float, bool>(0, 0, 20, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(100, 0, 400, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(49, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(50, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(20, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(40, 1, 50, true) },
                    { ItemStat.movement_speed, new Tuple<float, float, float, bool>(-0.20f, -0.20f, 0, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(10, 5) },
                    { "BlackMetal", new Tuple<int, int>(30, 10) },
                    { "LinenThread", new Tuple<int, int>(5, 0) },
                    { "Thunderstone", new Tuple<int, int>(4, 0) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 4 }
                }
            );

            // Elder Sledge
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Elders Rock" },
                    { ItemMetadata.catagory, "Hammers" },
                    { ItemMetadata.prefab, "VAElderHammer" },
                    { ItemMetadata.sprite, "elder_hammer" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.blunt, new Tuple<float, float, float, bool>(50, 0, 300, true) },
                    { ItemStat.blunt_per_level, new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { ItemStat.spirit, new Tuple<float, float, float, bool>(20, 0, 99, true) },
                    { ItemStat.spirit_per_level, new Tuple<float, float, float, bool>(5, 0, 20, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(100, 0, 400, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(22, 0, 60, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(50, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(12, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(22, 1, 50, true) },
                    { ItemStat.movement_speed, new Tuple<float, float, float, bool>(-0.20f, -0.20f, 0, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Bronze", new Tuple<int, int>(4, 2) },
                    { "Stone", new Tuple<int, int>(30, 15) },
                    { "CryptKey", new Tuple<int, int>(1, 0) },
                    { "TrophyTheElder", new Tuple<int, int>(1, 0) },
                    { "RoundLog", new Tuple<int, int>(0, 8) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 1 }
                }
            );

            // Bronze sledge
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Bronze Sledge" },
                    { ItemMetadata.catagory, "Hammers" },
                    { ItemMetadata.prefab, "VABronzeSledge" },
                    { ItemMetadata.sprite, "bronze_sledge" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.blunt, new Tuple<float, float, float, bool>(35, 0, 300, true) },
                    { ItemStat.blunt_per_level, new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(100, 0, 400, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(22, 0, 60, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(12, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(22, 1, 50, true) },
                    { ItemStat.movement_speed, new Tuple<float, float, float, bool>(-0.20f, -0.20f, 0, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Bronze", new Tuple<int, int>(8, 4) },
                    { "Stone", new Tuple<int, int>(25, 15) },
                    { "TrollHide", new Tuple<int, int>(6, 3) },
                    { "RoundLog", new Tuple<int, int>(4, 4) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 1 }
                }
            );

            // Bonemass Warhammer
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Bonemasses Rage" },
                    { ItemMetadata.catagory, "Hammers" },
                    { ItemMetadata.prefab, "VABonemassWarhammer" },
                    { ItemMetadata.sprite, "bonemass_warhammer" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.blunt, new Tuple<float, float, float, bool>(70, 0, 300, true) },
                    { ItemStat.blunt_per_level, new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { ItemStat.poison, new Tuple<float, float, float, bool>(20, 0, 99, true) },
                    { ItemStat.poison_per_level, new Tuple<float, float, float, bool>(5, 0, 20, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(100, 0, 400, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(31, 0, 60, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(14, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(24, 1, 50, true) },
                    { ItemStat.movement_speed, new Tuple<float, float, float, bool>(-0.20f, -0.20f, 0, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "WitheredBone", new Tuple<int, int>(10, 5) },
                    { "Iron", new Tuple<int, int>(30, 10) },
                    { "Wishbone", new Tuple<int, int>(1, 0) },
                    { "TrophyBonemass", new Tuple<int, int>(1, 0) },
                    { "ElderBark", new Tuple<int, int>(0, 2) },
                    { "LeatherScraps", new Tuple<int, int>(0, 2) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );

            // Silver sledge
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Silver Sledge" },
                    { ItemMetadata.catagory, "Hammers" },
                    { ItemMetadata.prefab, "VASilverSledge" },
                    { ItemMetadata.sprite, "silver_sledge" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.blunt, new Tuple<float, float, float, bool>(85, 0, 300, true) },
                    { ItemStat.blunt_per_level, new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { ItemStat.spirit, new Tuple<float, float, float, bool>(25, 0, 99, true) },
                    { ItemStat.spirit_per_level, new Tuple<float, float, float, bool>(5, 0, 20, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(100, 0, 400, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(31, 0, 60, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(15, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(24, 1, 50, true) },
                    { ItemStat.movement_speed, new Tuple<float, float, float, bool>(-0.20f, -0.20f, 0, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "RoundLog", new Tuple<int, int>(10, 5) },
                    { "Silver", new Tuple<int, int>(30, 15) },
                    { "YmirRemains", new Tuple<int, int>(4, 2) },
                    { "TrophyFenring", new Tuple<int, int>(1, 1) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 3 }
                }
            );
        }

        private void LoadAtgeirs()
        {
            Logger.LogInfo("Loading Atgeirs");
            // Flint Atgeir
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Flint Atgeir" },
                    { ItemMetadata.catagory, "Atgeirs" },
                    { ItemMetadata.prefab, "VAAtgeir_Flint" },
                    { ItemMetadata.sprite, "flint_atgeir" },
                    { ItemMetadata.craftedAt, "piece_workbench" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(25, 0, 90, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(30, 0, 120, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(11, 0, 60, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(125, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(10, 1, 20, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(20, 1, 50, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(10, 0) },
                    { "Flint", new Tuple<int, int>(6, 3) },
                    { "LeatherScraps", new Tuple<int, int>(0, 2) },
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 1 }
                }
            );

            // Antler Atgeir
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Eikthyrs Atgeir" },
                    { ItemMetadata.catagory, "Atgeirs" },
                    { ItemMetadata.prefab, "VAatgeir_antler" },
                    { ItemMetadata.sprite, "antler_atgeir" },
                    { ItemMetadata.craftedAt, "piece_workbench" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(35, 0, 90, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.lightning, new Tuple<float, float, float, bool>(10, 0, 25, true) },
                    { ItemStat.lightning_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(30, 0, 120, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(14, 0, 60, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(175, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(12, 1, 20, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(24, 1, 50, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(15, 0) },
                    { "Resin", new Tuple<int, int>(30, 15) },
                    { "HardAntler", new Tuple<int, int>(3, 3) },
                    { "TrophyEikthyr", new Tuple<int, int>(1, 1) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 1 }
                }
            );

            // Abyssal Atgeir
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Abyssal Atgeir" },
                    { ItemMetadata.catagory, "Atgeirs" },
                    { ItemMetadata.prefab, "VAAtgeirchitin" },
                    { ItemMetadata.sprite, "chitin_heavy_atgeir_small2" },
                    { ItemMetadata.craftedAt, "piece_workbench" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(35, 0, 140, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(2, 0, 25, true) },
                    { ItemStat.blunt, new Tuple<float, float, float, bool>(20, 0, 120, true) },
                    { ItemStat.blunt_per_level, new Tuple<float, float, float, bool>(4, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(30, 0, 120, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(21, 0, 60, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(175, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(14, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(28, 1, 50, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(10, 0) },
                    { "Chitin", new Tuple<int, int>(30, 15) },
                    { "DeerHide", new Tuple<int, int>(2, 1) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );

            // Silver Atgeir
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Silver Atgeir" },
                    { ItemMetadata.catagory, "Atgeirs" },
                    { ItemMetadata.prefab, "VASilverAtgeir" },
                    { ItemMetadata.sprite, "silver_atgeir" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(85, 0, 250, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { ItemStat.spirit, new Tuple<float, float, float, bool>(30, 0, 120, true) },
                    { ItemStat.spirit_per_level, new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(30, 0, 120, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(40, 0, 60, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(175, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(16, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(32, 1, 50, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(10, 0) },
                    { "Silver", new Tuple<int, int>(25, 10) },
                    { "Iron", new Tuple<int, int>(4, 2) },
                    { "LeatherScraps", new Tuple<int, int>(3, 1) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 3 }
                }
            );

            // Yagluth Atgeir
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Yagluths Reach" },
                    { ItemMetadata.catagory, "Atgeirs" },
                    { ItemMetadata.prefab, "VAYagluthAtgeir" },
                    { ItemMetadata.sprite, "yagluth_atgeir" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(105, 0, 250, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { ItemStat.fire, new Tuple<float, float, float, bool>(25, 0, 120, true) },
                    { ItemStat.fire_per_level, new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(30, 0, 120, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(52, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(175, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(18, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(36, 1, 50, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "BlackMetal", new Tuple<int, int>(10, 0) },
                    { "Iron", new Tuple<int, int>(4, 2) },
                    { "YagluthDrop", new Tuple<int, int>(2, 0) },
                    { "TrophyGoblinKing", new Tuple<int, int>(1, 0) },
                    { "Tar", new Tuple<int, int>(0, 3) },
                    { "LinenThread", new Tuple<int, int>(0, 2) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 4 }
                }
            );

            // Meteor atgeir
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Flametal Atgeir" },
                    { ItemMetadata.catagory, "Atgeirs" },
                    { ItemMetadata.prefab, "VAMeteorAtgeir" },
                    { ItemMetadata.sprite, "meteor_atgeir" },
                    { ItemMetadata.craftedAt, "blackforge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(145, 0, 300, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(30, 0, 120, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(64, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(175, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(22, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(42, 1, 50, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FlametalNew", new Tuple<int, int>(15, 10) },
                    { "Iron", new Tuple<int, int>(4, 2) },
                    { "Blackwood", new Tuple<int, int>(10, 0) },
                    { "MorgenSinew", new Tuple<int, int>(2, 2) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );

            // Meteor primal atgeir
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Flametal primal Atgeir" },
                    { ItemMetadata.catagory, "Atgeirs" },
                    { ItemMetadata.prefab, "VAMeteorAtgeir_nature" },
                    { ItemMetadata.sprite, "meteor_atgeir_nature" },
                    { ItemMetadata.craftedAt, "blackforge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(145, 0, 300, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { ItemStat.poison, new Tuple<float, float, float, bool>(10, 0, 300, true) },
                    { ItemStat.poison_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(30, 0, 120, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(64, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(175, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(22, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(42, 1, 50, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "VAMeteorAtgeir", new Tuple<int, int>(1, 0) },
                    { "FlametalNew", new Tuple<int, int>(8, 8) },
                    { "Blackwood", new Tuple<int, int>(5, 0) },
                    { "GemstoneGreen", new Tuple<int, int>(1, 1) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );

            // Meteor lightning atgeir
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Flametal lightning Atgeir" },
                    { ItemMetadata.catagory, "Atgeirs" },
                    { ItemMetadata.prefab, "VAMeteorAtgeir_lightning" },
                    { ItemMetadata.sprite, "meteor_atgeir_lightning" },
                    { ItemMetadata.craftedAt, "blackforge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(145, 0, 300, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { ItemStat.lightning, new Tuple<float, float, float, bool>(10, 0, 300, true) },
                    { ItemStat.lightning_per_level, new Tuple<float, float, float, bool>(0, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(30, 0, 120, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(64, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(175, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(22, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(42, 1, 50, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "VAMeteorAtgeir", new Tuple<int, int>(1, 0) },
                    { "FlametalNew", new Tuple<int, int>(8, 8) },
                    { "Blackwood", new Tuple<int, int>(5, 0) },
                    { "GemstoneBlue", new Tuple<int, int>(1, 1) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );

            // Meteor blood atgeir
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Flametal blood Atgeir" },
                    { ItemMetadata.catagory, "Atgeirs" },
                    { ItemMetadata.prefab, "VAMeteorAtgeir_blood" },
                    { ItemMetadata.sprite, "meteor_atgeir_blood" },
                    { ItemMetadata.craftedAt, "blackforge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(145, 0, 300, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(30, 0, 120, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(52, 0, 120, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(175, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(22, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(42, 1, 50, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "VAMeteorAtgeir", new Tuple<int, int>(1, 0) },
                    { "FlametalNew", new Tuple<int, int>(8, 8) },
                    { "Blackwood", new Tuple<int, int>(5, 0) },
                    { "GemstoneRed", new Tuple<int, int>(1, 1) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );
        }

        private void LoadShields()
        {
            Logger.LogInfo("Loading Shields");
            // Serpentscale Buckler
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Serpent Scale Buckler" },
                    { ItemMetadata.catagory, "Shields" },
                    { ItemMetadata.prefab, "VAserpent_buckler" },
                    { ItemMetadata.sprite, "serpentscale_shield2" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(48, 0, 120, true) },
                    { ItemStat.block_armor_per_level, new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(40, 0, 120, true) },
                    { ItemStat.parry, new Tuple<float, float, float, bool>(1.5f, 0, 3, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(250, 0, 500, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.movement_speed, new Tuple<float, float, float, bool>(-0.05f, -0.30f, 0, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(8, 8) },
                    { "Iron", new Tuple<int, int>(2, 2) },
                    { "SerpentScale", new Tuple<int, int>(6, 3) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 3 }
                },
                itemModifiers: new Dictionary<HitData.DamageType, HitData.DamageModifier>
                {
                    { HitData.DamageType.Pierce, HitData.DamageModifier.Resistant }
                }
            );

            // Elder Round Shield
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Elders Bulwark" },
                    { ItemMetadata.catagory, "Shields" },
                    { ItemMetadata.prefab, "VAElderRoundShield" },
                    { ItemMetadata.sprite, "elder_roundshield" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(28, 0, 120, true) },
                    { ItemStat.block_armor_per_level, new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(30, 0, 120, true) },
                    { ItemStat.block_force_per_level, new Tuple<float, float, float, bool>(5, 0, 30, true) },
                    { ItemStat.parry, new Tuple<float, float, float, bool>(1.5f, 0, 3, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(250, 0, 500, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.movement_speed, new Tuple<float, float, float, bool>(-0.05f, -0.30f, 0, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(16, 8) },
                    { "Bronze", new Tuple<int, int>(8, 4) },
                    { "CryptKey", new Tuple<int, int>(1, 1) },
                    { "TrophyTheElder", new Tuple<int, int>(1, 1) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                },
                itemModifiers: new Dictionary<HitData.DamageType, HitData.DamageModifier>
                {
                    { HitData.DamageType.Blunt, HitData.DamageModifier.VeryResistant }
                }
            );

            // Moder Round Shield
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Moders Roundshield" },
                    { ItemMetadata.catagory, "Shields" },
                    { ItemMetadata.prefab, "VAModer_RoundShield" },
                    { ItemMetadata.sprite, "moder_roundshield" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(62, 0, 120, true) },
                    { ItemStat.block_armor_per_level, new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(40, 0, 120, true) },
                    { ItemStat.block_force_per_level, new Tuple<float, float, float, bool>(5, 0, 30, true) },
                    { ItemStat.parry, new Tuple<float, float, float, bool>(1.5f, 0, 3, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(250, 0, 500, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.movement_speed, new Tuple<float, float, float, bool>(-0.05f, -0.30f, 0, true) },

                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(24, 12) },
                    { "Silver", new Tuple<int, int>(16, 8) },
                    { "DragonTear", new Tuple<int, int>(10, 0) },
                    { "TrophyDragonQueen", new Tuple<int, int>(1, 0) },
                    { "Obsidian", new Tuple<int, int>(0, 2) },
                    { "JuteRed", new Tuple<int, int>(0, 2) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 4 }
                },
                new Dictionary<ItemToggles, bool>() {
                    { ItemToggles.enabled, true },
                    { ItemToggles.craftable, false }
                },
                itemModifiers: new Dictionary<HitData.DamageType, HitData.DamageModifier>
                {
                    { HitData.DamageType.Frost, HitData.DamageModifier.Resistant }
                }
            );

            // Moder Tower Shield
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Moders Shield" },
                    { ItemMetadata.catagory, "Shields" },
                    { ItemMetadata.prefab, "VAModer_shield" },
                    { ItemMetadata.sprite, "modershiled_v2" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(100, 0, 180, true) },
                    { ItemStat.block_armor_per_level, new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(40, 0, 120, true) },
                    { ItemStat.block_force_per_level, new Tuple<float, float, float, bool>(5, 0, 30, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(250, 0, 500, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                    { ItemStat.movement_speed, new Tuple<float, float, float, bool>(-0.20f, -0.30f, 0, true) },

                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(24, 12) },
                    { "Silver", new Tuple<int, int>(16, 8) },
                    { "DragonTear", new Tuple<int, int>(10, 0) },
                    { "TrophyDragonQueen", new Tuple<int, int>(1, 0) },
                    { "Obsidian", new Tuple<int, int>(0, 2) },
                    { "JuteRed", new Tuple<int, int>(0, 2) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 4 }
                },
                itemModifiers: new Dictionary<HitData.DamageType, HitData.DamageModifier>
                {
                    { HitData.DamageType.Frost, HitData.DamageModifier.Resistant }
                }
            );

            // Silver Wolf tower shield
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Silver Wolf Towershield" },
                    { ItemMetadata.catagory, "Shields" },
                    { ItemMetadata.prefab, "VAsilver_tower" },
                    { ItemMetadata.sprite, "silver_tower_shield" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(78, 0, 120, true) },
                    { ItemStat.block_armor_per_level, new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { ItemStat.block_force, new Tuple<float, float, float, bool>(40, 0, 120, true) },
                    { ItemStat.block_force_per_level, new Tuple<float, float, float, bool>(5, 0, 30, true) },
                    { ItemStat.movement_speed, new Tuple<float, float, float, bool>(-0.20f, -0.30f, 0, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(250, 0, 500, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(15, 10) },
                    { "Silver", new Tuple<int, int>(10, 6) },
                    { "TrophyUlv", new Tuple<int, int>(1, 1) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 3 }
                }
            );
        }

        private void LoadDaggers()
        {
            Logger.LogInfo("Loading Daggers");
            // Blackmetal (mistlands) 1H Daggers
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Hati Knife" },
                    { ItemMetadata.catagory, "Knives" },
                    { ItemMetadata.prefab, "VAdagger_blackmetal_mistlands" },
                    { ItemMetadata.sprite, "hatti_knife" },
                    { ItemMetadata.craftedAt, "blackforge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(4, 0, 48, true) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(39, 0, 99, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(39, 0, 99, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(10, 0, 40, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(14, 1, 20, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(38, 1, 50, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(4, 4) },
                    { "BlackMetal", new Tuple<int, int>(8, 4) },
                    { "Iron", new Tuple<int, int>(2, 2) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );

            // Blackmetal 2H Daggers
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Blackmetal knives" },
                    { ItemMetadata.catagory, "Knives" },
                    { ItemMetadata.prefab, "VAknife_blackmetal" },
                    { ItemMetadata.sprite, "2h_blackmetal_knives" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(20, 0, 48, true) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(39, 0, 99, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(39, 0, 99, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(10, 0, 40, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(12, 1, 20, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(12, 1, 50, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(8, 4) },
                    { "BlackMetal", new Tuple<int, int>(20, 10) },
                    { "LinenThread", new Tuple<int, int>(10, 5) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 4 }
                }
            );

            // Flint 2H Daggers
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Flint knives" },
                    { ItemMetadata.catagory, "Knives" },
                    { ItemMetadata.prefab, "VADagger_Flint_2h" },
                    { ItemMetadata.sprite, "2h_flint_knives" },
                    { ItemMetadata.craftedAt, "piece_workbench" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(4, 0, 48, true) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(12, 0, 99, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(12, 0, 99, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(10, 0, 40, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(4, 1, 20, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(12, 1, 50, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(4, 0) },
                    { "Flint", new Tuple<int, int>(6, 3) },
                    { "LeatherScraps", new Tuple<int, int>(2, 1) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 1 }
                }
            );

            // Antler 1H Daggers
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Eikthyrs knife" },
                    { ItemMetadata.catagory, "Knives" },
                    { ItemMetadata.prefab, "VAAntler_dagger" },
                    { ItemMetadata.sprite, "antler_dagger" },
                    { ItemMetadata.craftedAt, "piece_workbench" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(2, 0, 48, true) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(8, 0, 99, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(8, 0, 99, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.lightning, new Tuple<float, float, float, bool>(4, 0, 99, true) },
                    { ItemStat.lightning_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(10, 0, 30, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(6, 1, 20, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(18, 1, 50, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(3, 0) },
                    { "Resin", new Tuple<int, int>(16, 8) },
                    { "HardAntler", new Tuple<int, int>(3, 3) },
                    { "TrophyEikthyr", new Tuple<int, int>(1, 1) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );

            // Copper 2H Daggers
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Rascals knives" },
                    { ItemMetadata.catagory, "Knives" },
                    { ItemMetadata.prefab, "VAdagger_copper_2h" },
                    { ItemMetadata.sprite, "copper_knives_2h" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(8, 0, 48, true) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(20, 0, 99, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(20, 0, 99, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(10, 0, 40, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(6, 1, 20, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(18, 1, 50, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "RoundLog", new Tuple<int, int>(4, 0) },
                    { "Copper", new Tuple<int, int>(16, 4) },
                    { "LeatherScraps", new Tuple<int, int>(4, 2) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 1 }
                }
            );

            // Iron 2H Daggers
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Rogue knives" },
                    { ItemMetadata.catagory, "Knives" },
                    { ItemMetadata.prefab, "VAdagger_iron_2h" },
                    { ItemMetadata.sprite, "iron_dagger_2h" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(12, 0, 48, true) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(25, 0, 99, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(25, 0, 99, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(10, 0, 40, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(8, 1, 20, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(24, 1, 50, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(4, 2) },
                    { "Iron", new Tuple<int, int>(16, 8) },
                    { "LeatherScraps", new Tuple<int, int>(6, 3) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );

            // Iron 1H Daggers
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Iron knives" },
                    { ItemMetadata.catagory, "Knives" },
                    { ItemMetadata.prefab, "VAdagger_iron" },
                    { ItemMetadata.sprite, "iron_dagger" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(2, 0, 48, true) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(22, 0, 99, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(22, 0, 99, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(10, 0, 30, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(8, 1, 20, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(24, 1, 50, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(2, 1) },
                    { "Iron", new Tuple<int, int>(12, 6) },
                    { "LeatherScraps", new Tuple<int, int>(4, 2) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );

            // Silver 2H Daggers
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Silver knives" },
                    { ItemMetadata.catagory, "Knives" },
                    { ItemMetadata.prefab, "VAdagger_silver_2h" },
                    { ItemMetadata.sprite, "silver_dagger_2h" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(16, 0, 48, true) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(34, 0, 99, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(34, 0, 99, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.spirit, new Tuple<float, float, float, bool>(12, 0, 99, true) },
                    { ItemStat.spirit_per_level, new Tuple<float, float, float, bool>(0, 0, 25, true) },
                    { ItemStat.frost, new Tuple<float, float, float, bool>(0, 0, 99, true) },
                    { ItemStat.frost_per_level, new Tuple<float, float, float, bool>(0, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(10, 0, 40, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(10, 1, 20, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(30, 1, 50, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(4, 2) },
                    { "Silver", new Tuple<int, int>(12, 6) },
                    { "Iron", new Tuple<int, int>(4, 2) },
                    { "LeatherScraps", new Tuple<int, int>(6, 3) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 3 }
                }
            );

            // Moders Daggers 1H
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Moders knife" },
                    { ItemMetadata.catagory, "Knives" },
                    { ItemMetadata.prefab, "VAdagger_moder" },
                    { ItemMetadata.sprite, "moder_dagger" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(2, 0, 48, true) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(28, 0, 99, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(28, 0, 99, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.spirit, new Tuple<float, float, float, bool>(0, 0, 99, true) },
                    { ItemStat.spirit_per_level, new Tuple<float, float, float, bool>(0, 0, 25, true) },
                    { ItemStat.frost, new Tuple<float, float, float, bool>(8, 0, 99, true) },
                    { ItemStat.frost_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(10, 0, 30, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(10, 1, 20, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(30, 1, 50, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(4, 2) },
                    { "Obsidian", new Tuple<int, int>(15, 5) },
                    { "DragonTear", new Tuple<int, int>(10, 0) },
                    { "TrophyDragonQueen", new Tuple<int, int>(1, 0) },
                    { "Silver", new Tuple<int, int>(0, 2) },
                    { "JuteRed", new Tuple<int, int>(0, 2) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 4 }
                }
            );

            // Bonemass Dagger
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Bonemasses knife" },
                    { ItemMetadata.catagory, "Knives" },
                    { ItemMetadata.prefab, "VABonemassDagger" },
                    { ItemMetadata.sprite, "bonemass_dagger" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(2, 0, 48, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(22, 0, 99, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(22, 0, 99, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.poison, new Tuple<float, float, float, bool>(7, 0, 99, true) },
                    { ItemStat.poison_per_level, new Tuple<float, float, float, bool>(2, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(10, 0, 30, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(9, 1, 20, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(28, 1, 50, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "WitheredBone", new Tuple<int, int>(2, 1) },
                    { "Iron", new Tuple<int, int>(12, 6) },
                    { "Wishbone", new Tuple<int, int>(1, 0) },
                    { "TrophyBonemass", new Tuple<int, int>(1, 0) },
                    { "ElderBark", new Tuple<int, int>(0, 2) },
                    { "LeatherScraps", new Tuple<int, int>(0, 2) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 3 }
                }
            );

            // Queens Dagger
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Queens knife" },
                    { ItemMetadata.catagory, "Knives" },
                    { ItemMetadata.prefab, "VAdagger_queen" },
                    { ItemMetadata.sprite, "dagger_queen" },
                    { ItemMetadata.craftedAt, "blackforge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(2, 0, 48, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(34, 0, 99, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(34, 0, 99, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.poison, new Tuple<float, float, float, bool>(18, 0, 99, true) },
                    { ItemStat.poison_per_level, new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { ItemStat.lightning, new Tuple<float, float, float, bool>(18, 0, 99, true) },
                    { ItemStat.lightning_per_level, new Tuple<float, float, float, bool>(3, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(10, 0, 30, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(14, 1, 20, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(42, 1, 80, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "YggdrasilWood", new Tuple<int, int>(2, 2) },
                    { "Eitr", new Tuple<int, int>(10, 5) },
                    { "JuteBlue", new Tuple<int, int>(2, 1) },
                    { "TrophySeekerQueen", new Tuple<int, int>(1, 0) },
                    { "Carapace", new Tuple<int, int>(0, 4) },
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );

            // Meteor dagger
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Flametal knife" },
                    { ItemMetadata.catagory, "Knives" },
                    { ItemMetadata.prefab, "VAdagger_meteor" },
                    { ItemMetadata.sprite, "meteor_dagger" },
                    { ItemMetadata.craftedAt, "blackforge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(2, 0, 48, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(45, 0, 99, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(45, 0, 99, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(10, 0, 30, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(14, 1, 20, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(42, 1, 80, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FlametalNew", new Tuple<int, int>(10, 4) },
                    { "Iron", new Tuple<int, int>(2, 1) },
                    { "Blackwood", new Tuple<int, int>(4, 0) },
                    { "MorgenSinew", new Tuple<int, int>(4, 2) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );

            // Meteor primal dagger
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Flametal primal knife" },
                    { ItemMetadata.catagory, "Knives" },
                    { ItemMetadata.prefab, "VAdagger_meteor_nature" },
                    { ItemMetadata.sprite, "meteor_dagger_primal" },
                    { ItemMetadata.craftedAt, "blackforge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(2, 0, 48, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(45, 0, 99, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(45, 0, 99, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.poison, new Tuple<float, float, float, bool>(10, 0, 99, true) },
                    { ItemStat.poison_per_level, new Tuple<float, float, float, bool>(2, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(10, 0, 30, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(14, 1, 20, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(42, 1, 80, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "VAdagger_meteor", new Tuple<int, int>(1, 0) },
                    { "FlametalNew", new Tuple<int, int>(4, 4) },
                    { "GemstoneGreen", new Tuple<int, int>(1, 1) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );

            // Meteor lightning dagger
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Flametal lightning knife" },
                    { ItemMetadata.catagory, "Knives" },
                    { ItemMetadata.prefab, "VAdagger_meteor_lightning" },
                    { ItemMetadata.sprite, "meteor_dagger_lightning" },
                    { ItemMetadata.craftedAt, "blackforge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(2, 0, 48, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(45, 0, 99, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(45, 0, 99, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.lightning, new Tuple<float, float, float, bool>(10, 0, 99, true) },
                    { ItemStat.lightning_per_level, new Tuple<float, float, float, bool>(2, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(10, 0, 30, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(14, 1, 20, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(42, 1, 80, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "VAdagger_meteor", new Tuple<int, int>(1, 0) },
                    { "FlametalNew", new Tuple<int, int>(4, 4) },
                    { "GemstoneBlue", new Tuple<int, int>(1, 1) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );

            // Meteor blood dagger
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Flametal blood knife" },
                    { ItemMetadata.catagory, "Knives" },
                    { ItemMetadata.prefab, "VAdagger_meteor_blood" },
                    { ItemMetadata.sprite, "meteor_dagger_blood" },
                    { ItemMetadata.craftedAt, "blackforge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(2, 0, 48, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(45, 0, 99, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(45, 0, 99, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(10, 0, 30, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(14, 1, 20, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(42, 1, 80, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "VAdagger_meteor", new Tuple<int, int>(1, 0) },
                    { "FlametalNew", new Tuple<int, int>(4, 4) },
                    { "GemstoneRed", new Tuple<int, int>(1, 1) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );

            // Meteor dagger 2h
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Assassins knives" },
                    { ItemMetadata.catagory, "Knives" },
                    { ItemMetadata.prefab, "VAdagger_meteor_2h" },
                    { ItemMetadata.sprite, "2h_meteor_daggers" },
                    { ItemMetadata.craftedAt, "blackforge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(28, 0, 48, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(52, 0, 99, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(52, 0, 99, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(10, 0, 30, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(15, 1, 20, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(45, 1, 80, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FlametalNew", new Tuple<int, int>(14, 6) },
                    { "Iron", new Tuple<int, int>(2, 1) },
                    { "Blackwood", new Tuple<int, int>(6, 0) },
                    { "MorgenSinew", new Tuple<int, int>(4, 2) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );

            // Meteor dagger 2h nature
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Assassins primal knives" },
                    { ItemMetadata.catagory, "Knives" },
                    { ItemMetadata.prefab, "VAdagger_meteor_2h_nature" },
                    { ItemMetadata.sprite, "meteor_dagger_primal_2h" },
                    { ItemMetadata.craftedAt, "blackforge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(28, 0, 48, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(52, 0, 99, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(52, 0, 99, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.poison, new Tuple<float, float, float, bool>(14, 0, 99, true) },
                    { ItemStat.poison_per_level, new Tuple<float, float, float, bool>(2, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(10, 0, 30, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(15, 1, 20, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(45, 1, 80, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "VAdagger_meteor_2h", new Tuple<int, int>(1, 0) },
                    { "FlametalNew", new Tuple<int, int>(8, 8) },
                    { "GemstoneGreen", new Tuple<int, int>(1, 1) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );

            // Meteor dagger 2h lightning
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Assassins lightning knives" },
                    { ItemMetadata.catagory, "Knives" },
                    { ItemMetadata.prefab, "VAdagger_meteor_2h_lightning" },
                    { ItemMetadata.sprite, "meteor_dagger_lightning_2h" },
                    { ItemMetadata.craftedAt, "blackforge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(28, 0, 48, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(52, 0, 99, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(52, 0, 99, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.lightning, new Tuple<float, float, float, bool>(14, 0, 99, true) },
                    { ItemStat.lightning_per_level, new Tuple<float, float, float, bool>(2, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(10, 0, 30, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(15, 1, 20, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(45, 1, 80, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "VAdagger_meteor_2h", new Tuple<int, int>(1, 0) },
                    { "FlametalNew", new Tuple<int, int>(8, 8) },
                    { "GemstoneBlue", new Tuple<int, int>(1, 1) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );

            // Meteor dagger 2h Blood
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Assassins blood knives" },
                    { ItemMetadata.catagory, "Knives" },
                    { ItemMetadata.prefab, "VAdagger_meteor_2h_blood" },
                    { ItemMetadata.sprite, "meteor_dagger_blood_2h" },
                    { ItemMetadata.craftedAt, "blackforge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(28, 0, 48, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(52, 0, 99, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(52, 0, 99, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(1, 0, 25, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(10, 0, 30, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(15, 1, 20, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(45, 1, 80, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 500, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "VAdagger_meteor_2h", new Tuple<int, int>(1, 0) },
                    { "FlametalNew", new Tuple<int, int>(8, 8) },
                    { "GemstoneRed", new Tuple<int, int>(1, 1) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );
        }

        private void LoadSpears()
        {
            Logger.LogInfo("Loading Spears");
            // Moder Spear
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Moders Strike" },
                    { ItemMetadata.catagory, "Spears" },
                    { ItemMetadata.prefab, "VASpearModer" },
                    { ItemMetadata.sprite, "moder_spear" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(30, 0, 48, true) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(45, 0, 120, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(2, 0, 20, true) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(30, 0, 99, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(4, 0, 20, true) },
                    { ItemStat.frost, new Tuple<float, float, float, bool>(25, 0, 99, true) },
                    { ItemStat.frost_per_level, new Tuple<float, float, float, bool>(5, 0, 20, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(12, 1, 20, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(14, 1, 50, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(100, 0, 300, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(15, 10) },
                    { "Obsidian", new Tuple<int, int>(8, 4) },
                    { "DragonTear", new Tuple<int, int>(10, 0) },
                    { "TrophyDragonQueen", new Tuple<int, int>(1, 0) },
                    { "Silver", new Tuple<int, int>(0, 2) },
                    { "JuteRed", new Tuple<int, int>(0, 2) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 4 }
                }
            );
        }

        private void LoadFists()
        {
            Logger.LogInfo("Loading Fists");
            // Flint Fists
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Flint knuckles" },
                    { ItemMetadata.catagory, "Fists" },
                    { ItemMetadata.prefab, "VAFist_Flint" },
                    { ItemMetadata.sprite, "flint_fists" },
                    { ItemMetadata.craftedAt, "piece_workbench" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(5, 0, 48, true) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(6, 0, 120, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(4, 0, 20, true) },
                    { ItemStat.blunt, new Tuple<float, float, float, bool>(0, 0, 120, true) },
                    { ItemStat.blunt_per_level, new Tuple<float, float, float, bool>(0, 0, 20, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(4, 1, 20, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(300, 0, 600, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(4, 0) },
                    { "Flint", new Tuple<int, int>(4, 2) },
                    { "LeatherScraps", new Tuple<int, int>(2, 2) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 1 }
                }
            );

            // Bronze Fists
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Bronze knuckles" },
                    { ItemMetadata.catagory, "Fists" },
                    { ItemMetadata.prefab, "VAFist_Bronze" },
                    { ItemMetadata.sprite, "bronze_fists" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(5, 0, 48, true) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(20, 0, 120, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(4, 0, 20, true) },
                    { ItemStat.blunt, new Tuple<float, float, float, bool>(0, 0, 120, true) },
                    { ItemStat.blunt_per_level, new Tuple<float, float, float, bool>(0, 0, 20, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(6, 1, 20, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(300, 0, 600, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "RoundLog", new Tuple<int, int>(4, 0) },
                    { "Bronze", new Tuple<int, int>(6, 3) },
                    { "LeatherScraps", new Tuple<int, int>(4, 4) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 1 }
                }
            );

            // Iron Fists
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Iron knuckles" },
                    { ItemMetadata.catagory, "Fists" },
                    { ItemMetadata.prefab, "VAFist_Iron" },
                    { ItemMetadata.sprite, "iron_fists" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(5, 0, 48, true) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(35, 0, 120, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(4, 0, 20, true) },
                    { ItemStat.blunt, new Tuple<float, float, float, bool>(0, 0, 120, true) },
                    { ItemStat.blunt_per_level, new Tuple<float, float, float, bool>(0, 0, 20, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(8, 1, 20, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(300, 0, 600, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(4, 2) },
                    { "Iron", new Tuple<int, int>(12, 6) },
                    { "LeatherScraps", new Tuple<int, int>(6, 6) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );

            // Yagluth Fists
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Goblin king knuckles" },
                    { ItemMetadata.catagory, "Fists" },
                    { ItemMetadata.prefab, "VAFist_Yagluth" },
                    { ItemMetadata.sprite, "yagluth_fists" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(5, 0, 48, true) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(80, 0, 120, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(4, 0, 20, true) },
                    { ItemStat.blunt, new Tuple<float, float, float, bool>(0, 0, 120, true) },
                    { ItemStat.blunt_per_level, new Tuple<float, float, float, bool>(0, 0, 20, true) },
                    { ItemStat.fire, new Tuple<float, float, float, bool>(25, 0, 120, true) },
                    { ItemStat.fire_per_level, new Tuple<float, float, float, bool>(5, 0, 20, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(12, 1, 20, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(36, 1, 50, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(300, 0, 600, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "BlackMetal", new Tuple<int, int>(4, 2) },
                    { "Iron", new Tuple<int, int>(6, 3) },
                    { "YagluthDrop", new Tuple<int, int>(2, 0) },
                    { "TrophyGoblinKing", new Tuple<int, int>(1, 0) },
                    { "Tar", new Tuple<int, int>(0, 3) },
                    { "LinenThread", new Tuple<int, int>(0, 2) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 4 }
                }
            );
        }

        private void LoadMaces()
        {
            Logger.LogInfo("Loading Maces");
            // Elders Mace
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Elders Fist" },
                    { ItemMetadata.catagory, "Maces" },
                    { ItemMetadata.prefab, "VAElder_mace" },
                    { ItemMetadata.sprite, "elder_mace" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.blunt, new Tuple<float, float, float, bool>(35, 0, 90, true) },
                    { ItemStat.blunt_per_level, new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { ItemStat.spirit, new Tuple<float, float, float, bool>(20, 0, 120, true) },
                    { ItemStat.spirit_per_level, new Tuple<float, float, float, bool>(5, 0, 20, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(80, 0, 120, true) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(12, 0, 60, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(8, 1, 30, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(16, 1, 50, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Bronze", new Tuple<int, int>(2, 1) },
                    { "Stone", new Tuple<int, int>(16, 8) },
                    { "CryptKey", new Tuple<int, int>(1, 0) },
                    { "TrophyTheElder", new Tuple<int, int>(1, 0) },
                    { "RoundLog", new Tuple<int, int>(0, 6) },
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );
        }

        private void LoadMagic()
        {
            Logger.LogInfo("Loading Magic Weapons");
            // Staff of poison
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Staff of poison" },
                    { ItemMetadata.catagory, "Magics" },
                    { ItemMetadata.prefab, "VAStaff_Poison" },
                    { ItemMetadata.sprite, "poison_staff" },
                    { ItemMetadata.craftedAt, "piece_magetable" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(48, 0, 90, true) },
                    { ItemStat.poison, new Tuple<float, float, float, bool>(120, 0, 200, true) },
                    { ItemStat.poison_per_level, new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { ItemStat.blunt, new Tuple<float, float, float, bool>(120, 0, 200, true) },
                    { ItemStat.blunt_per_level, new Tuple<float, float, float, bool>(0, 0, 20, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { ItemStat.primary_attack_eitr, new Tuple<float, float, float, bool>(35, 0, 50, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(0, 0, 50, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "YggdrasilWood", new Tuple<int, int>(20, 10) },
                    { "Guck", new Tuple<int, int>(4, 2) },
                    { "Eitr", new Tuple<int, int>(16, 8) },
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 1 }
                }
            );

            // Staff of spirit
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Staff of Spirit" },
                    { ItemMetadata.catagory, "Magics" },
                    { ItemMetadata.prefab, "VAStaff_Spirit" },
                    { ItemMetadata.sprite, "spirit_staff" },
                    { ItemMetadata.craftedAt, "piece_magetable" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(48, 0, 90, true) },
                    { ItemStat.spirit, new Tuple<float, float, float, bool>(120, 0, 200, true) },
                    { ItemStat.spirit_per_level, new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { ItemStat.blunt, new Tuple<float, float, float, bool>(120, 0, 200, true) },
                    { ItemStat.blunt_per_level, new Tuple<float, float, float, bool>(0, 0, 20, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { ItemStat.primary_attack_eitr, new Tuple<float, float, float, bool>(35, 0, 50, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(0, 0, 50, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "YggdrasilWood", new Tuple<int, int>(20, 10) },
                    { "GreydwarfEye", new Tuple<int, int>(8, 8) },
                    { "Eitr", new Tuple<int, int>(16, 8) },
                    { "TrophyDvergr", new Tuple<int, int>(2, 0) },
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 4 }
                }
            );

            // Druidic Staff of poison
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Druidic Staff of Poison" },
                    { ItemMetadata.catagory, "Magics" },
                    { ItemMetadata.prefab, "VAStaff_Druid_Poison" },
                    { ItemMetadata.sprite, "poison_staff_druidic" },
                    { ItemMetadata.craftedAt, "piece_workbench" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(24, 0, 48, true) },
                    { ItemStat.poison, new Tuple<float, float, float, bool>(50, 0, 120, true) },
                    { ItemStat.poison_per_level, new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { ItemStat.blunt, new Tuple<float, float, float, bool>(50, 0, 200, true) },
                    { ItemStat.blunt_per_level, new Tuple<float, float, float, bool>(0, 0, 20, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(50, 0, 500, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(10, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(35, 0, 50, true) },
                    { ItemStat.primary_attack_eitr, new Tuple<float, float, float, bool>(0, 0, 50, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(20, 10) },
                    { "Guck", new Tuple<int, int>(4, 2) },
                    { "TrophyBlob", new Tuple<int, int>(2, 1) },
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );

            // Druidic Staff of spirit
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Druidic Staff of Spirit" },
                    { ItemMetadata.catagory, "Magics" },
                    { ItemMetadata.prefab, "VAStaff_Druid_Spirit" },
                    { ItemMetadata.sprite, "spirit_staff_druid" },
                    { ItemMetadata.craftedAt, "piece_workbench" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(24, 0, 48, true) },
                    { ItemStat.spirit, new Tuple<float, float, float, bool>(50, 0, 120, true) },
                    { ItemStat.spirit_per_level, new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { ItemStat.blunt, new Tuple<float, float, float, bool>(50, 0, 200, true) },
                    { ItemStat.blunt_per_level, new Tuple<float, float, float, bool>(0, 0, 20, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(50, 0, 500, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(10, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(35, 0, 50, true) },
                    { ItemStat.primary_attack_eitr, new Tuple<float, float, float, bool>(0, 0, 50, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(20, 10) },
                    { "GreydwarfEye", new Tuple<int, int>(4, 2) },
                    { "TrophyGreydwarfShaman", new Tuple<int, int>(2, 1) },
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );

            // Druidic Staff of Ice
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Druidic Staff of Ice" },
                    { ItemMetadata.catagory, "Magics" },
                    { ItemMetadata.prefab, "VAStaff_Druid_Ice" },
                    { ItemMetadata.sprite, "ice_staff_druidic" },
                    { ItemMetadata.craftedAt, "piece_workbench" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(24, 0, 48, true) },
                    { ItemStat.frost, new Tuple<float, float, float, bool>(12, 0, 120, true) },
                    { ItemStat.frost_per_level, new Tuple<float, float, float, bool>(2, 0, 20, true) },
                    { ItemStat.blunt, new Tuple<float, float, float, bool>(12, 0, 200, true) },
                    { ItemStat.blunt_per_level, new Tuple<float, float, float, bool>(0, 0, 20, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(50, 0, 500, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(10, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(5, 0, 50, true) },
                    { ItemStat.primary_attack_eitr, new Tuple<float, float, float, bool>(0, 0, 50, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(20, 10) },
                    { "FreezeGland", new Tuple<int, int>(4, 2) },
                    { "TrophyHatchling", new Tuple<int, int>(2, 1) },
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );

            // Druidic Staff of Fire
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Druidic Staff of Fire" },
                    { ItemMetadata.catagory, "Magics" },
                    { ItemMetadata.prefab, "VAStaff_Druid_Fire" },
                    { ItemMetadata.sprite, "fire_staff_druidic" },
                    { ItemMetadata.craftedAt, "piece_workbench" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(24, 0, 48, true) },
                    { ItemStat.fire, new Tuple<float, float, float, bool>(50, 0, 120, true) },
                    { ItemStat.fire_per_level, new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { ItemStat.blunt, new Tuple<float, float, float, bool>(50, 0, 200, true) },
                    { ItemStat.blunt_per_level, new Tuple<float, float, float, bool>(0, 0, 20, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(20, 0, 60, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(50, 0, 500, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(10, 0, 75, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(35, 0, 50, true) },
                    { ItemStat.primary_attack_eitr, new Tuple<float, float, float, bool>(0, 0, 50, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "ElderBark", new Tuple<int, int>(20, 10) },
                    { "SurtlingCore", new Tuple<int, int>(4, 2) },
                    { "TrophySurtling", new Tuple<int, int>(2, 1) },
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 2 }
                }
            );
        }

        private void LoadPickaxes()
        {
            // This is just another magic weapon so we are not gunna log its loading seperately
            // If more pickaxes are are added this will be restructured

            // Bone Blood Pickaxe
            new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Bone Blood Pickaxe" },
                    { ItemMetadata.catagory, "Pickaxes" },
                    { ItemMetadata.prefab, "VABlood_Bones_pickaxe" },
                    { ItemMetadata.sprite, "blood_bone_pickaxe" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.pierce, new Tuple<float, float, float, bool>(26, 0, 200, true) },
                    { ItemStat.pierce_per_level, new Tuple<float, float, float, bool>(4, 0, 20, true) },
                    { ItemStat.spirit, new Tuple<float, float, float, bool>(6, 0, 200, true) },
                    { ItemStat.spirit_per_level, new Tuple<float, float, float, bool>(2, 0, 20, true) },
                    { ItemStat.pickaxe, new Tuple<float, float, float, bool>(32, 0, 200, true) },
                    { ItemStat.pickaxe_per_level, new Tuple<float, float, float, bool>(6, 0, 20, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(50, 0, 100, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(6, 0, 50, true) },
                    { ItemStat.primary_attack_flat_health_cost, new Tuple<float, float, float, bool>(4, 0, 25, true) },
                    { ItemStat.primary_attack_percent_health_cost, new Tuple<float, float, float, bool>(0, 0, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(4, 0, 50, true) },
                    { ItemStat.secondary_attack_flat_health_cost, new Tuple<float, float, float, bool>(6, 0, 25, true) },
                    { ItemStat.secondary_attack_percent_health_cost, new Tuple<float, float, float, bool>(0, 0, 50, true) },
                    { ItemStat.tool_level, new Tuple<float, float, float, bool>(1, 0, 5, false) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(200, 0, 400, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 75, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "RoundLog", new Tuple<int, int>(12, 8) },
                    { "BoneFragments", new Tuple<int, int>(20, 14) },
                    { "Bronze", new Tuple<int, int>(4, 2) },
                    { "TrophySkeleton", new Tuple<int, int>(2, 0) },
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 1 }
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