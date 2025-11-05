
using Jotunn.Entities;
using Jotunn.Managers;
using System;
using System.Collections.Generic;
using UnityEngine;
using ValheimArmory.common;
using Logger = ValheimArmory.common.Logger;

namespace ValheimArmory
{
    class ValheimArmoryItems
    {
        AssetBundle EmbeddedResourceBundle = ValheimArmory.EmbeddedResourceBundle;
        // constructor, add all items on init
        JotunBatchLoader Loader;
        public ValheimArmoryItems()
        {
            Loader = new JotunBatchLoader();
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

            // Load all of the defined items
            Loader.BatchSetup(EmbeddedResourceBundle);
        }

        private void LoadArrows()
        {
            Logger.LogInfo("Loading Arrows");
            // Greenmetal Arrows					forge lvl 3
            ItemDefinition Black_Metal_Arrow = new ItemDefinition();
            Black_Metal_Arrow.Name = "Black Metal Arrow";
            Black_Metal_Arrow.Category = ItemCategory.Arrows;
            Black_Metal_Arrow.prefab = "VAArrowGreenMetal";
            Black_Metal_Arrow.icon = "arrow_greenmetal";
            Black_Metal_Arrow.craftedAt = "forge";
            Black_Metal_Arrow.craftAmount = 20;
            Black_Metal_Arrow.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.blunt, new ItemStatConfig{ default_value = 52, min =  0, max =  200 } },
                { ItemStat.pierce, new ItemStatConfig{ default_value = 26, min =  0, max =  200 } },
            };
            Black_Metal_Arrow.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Wood", amount = 8, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "BlackMetal", amount = 2, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Feathers", amount = 2, upgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Black_Metal_Arrow);

            // Bone Arrows							workbench lvl 3(obsidian)
            ItemDefinition Bone_Arrow = new ItemDefinition();
            Bone_Arrow.Name = "Bone Arrow";
            Bone_Arrow.Category = ItemCategory.Arrows;
            Bone_Arrow.prefab = "VAArrowBone";
            Bone_Arrow.icon = "bone_arrow";
            Bone_Arrow.craftedAt = "piece_workbench";
            Bone_Arrow.craftAmount = 20;
            Bone_Arrow.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ default_value = 32, min =  0, max =  200 } },
            };
            Bone_Arrow.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "BoneFragments", amount = 8, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Feathers", amount = 2, upgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Bone_Arrow);

            // Surtling Fire Arrow					workbench lvl 3
            ItemDefinition Surtling_Fire_Arrow = new ItemDefinition();
            Surtling_Fire_Arrow.Name = "Surtling Fire Arrow";
            Surtling_Fire_Arrow.Category = ItemCategory.Arrows;
            Surtling_Fire_Arrow.prefab = "VAarrow_surtling_fire";
            Surtling_Fire_Arrow.icon = "surtlingcore_arrow";
            Surtling_Fire_Arrow.craftedAt = "piece_workbench";
            Surtling_Fire_Arrow.craftAmount = 20;
            Surtling_Fire_Arrow.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.fire, new ItemStatConfig{ default_value = 52, min =  0, max =  200 } },
                { ItemStat.pierce, new ItemStatConfig{ default_value = 26, min =  0, max =  200 } },
            };
            Surtling_Fire_Arrow.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Wood", amount = 8, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Obsidian", amount = 4, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Feathers", amount = 2, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "SurtlingCore", amount = 1, upgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Surtling_Fire_Arrow);

            // Ancient Wood Arrow					workbench lvl 3
            ItemDefinition Ancient_Wood_Arrow = new ItemDefinition();
            Ancient_Wood_Arrow.Name = "Ancient Wood Arrow";
            Ancient_Wood_Arrow.Category = ItemCategory.Arrows;
            Ancient_Wood_Arrow.prefab = "VAArrowAncient";
            Ancient_Wood_Arrow.icon = "ancient_arrow";
            Ancient_Wood_Arrow.craftedAt = "piece_workbench";
            Ancient_Wood_Arrow.craftAmount = 20;
            Ancient_Wood_Arrow.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ default_value = 37, min =  0, max =  200 } },
            };
            Ancient_Wood_Arrow.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "ElderBark", amount = 8, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Feathers", amount = 2, upgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Ancient_Wood_Arrow);

            // Chitin Arrow							workbench lvl 3
            ItemDefinition Chitin_Arrow = new ItemDefinition();
            Chitin_Arrow.Name = "Chitin Arrow";
            Chitin_Arrow.Category = ItemCategory.Arrows;
            Chitin_Arrow.prefab = "VAChitinArrow";
            Chitin_Arrow.icon = "arrow_chitin";
            Chitin_Arrow.craftedAt = "piece_workbench";
            Chitin_Arrow.craftAmount = 20;
            Chitin_Arrow.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ default_value = 12, min =  0, max =  200 } },
                { ItemStat.blunt, new ItemStatConfig{ default_value = 35, min =  0, max =  200 } },
            };
            Chitin_Arrow.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Wood", amount = 8, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Chitin", amount = 2, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Feathers", amount = 2, upgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Chitin_Arrow);

            // Wood Crossbow Bolt					workbench lvl 1
            ItemDefinition Wood_Bolt = new ItemDefinition();
            Wood_Bolt.Name = "Wood Bolt";
            Wood_Bolt.Category = ItemCategory.Arrows;
            Wood_Bolt.prefab = "VABoltWood";
            Wood_Bolt.icon = "bolt_wood";
            Wood_Bolt.craftedAt = "piece_workbench";
            Wood_Bolt.craftAmount = 20;
            Wood_Bolt.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ default_value = 22, min =  0, max =  200 } },
            };
            Wood_Bolt.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Wood", amount = 8, upgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Wood_Bolt);

            // Corewood Crossbow Bolt					workbench lvl 3
            ItemDefinition Corewood_Bolt = new ItemDefinition();
            Corewood_Bolt.Name = "Corewood Bolt";
            Corewood_Bolt.Category = ItemCategory.Arrows;
            Corewood_Bolt.prefab = "VABoltCoreWood";
            Corewood_Bolt.icon = "bolt_corewood";
            Corewood_Bolt.craftedAt = "piece_workbench";
            Corewood_Bolt.craftAmount = 20;
            Corewood_Bolt.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ default_value = 37, min =  0, max =  200 } },
            };
            Corewood_Bolt.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "RoundLog", amount = 8, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Feathers", amount = 2, upgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Corewood_Bolt);

            // Bronze Bolt							forge lvl 1
            ItemDefinition Bronze_Bolt = new ItemDefinition();
            Bronze_Bolt.Name = "Bronze Bolt";
            Bronze_Bolt.Category = ItemCategory.Arrows;
            Bronze_Bolt.prefab = "VAbolt_bronze";
            Bronze_Bolt.icon = "bronze_bolt";
            Bronze_Bolt.craftedAt = "forge";
            Bronze_Bolt.craftAmount = 20;
            Bronze_Bolt.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ default_value = 32, min =  0, max =  200 } },
            };
            Bronze_Bolt.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Wood", amount = 8, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Bronze", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Feathers", amount = 2, upgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Bronze_Bolt);

            // Iron Poison Bolt						forge lvl 2
            ItemDefinition Poison_Bolt = new ItemDefinition();
            Poison_Bolt.Name = "Poison Bolt";
            Poison_Bolt.Category = ItemCategory.Arrows;
            Poison_Bolt.prefab = "VAbolt_poison";
            Poison_Bolt.icon = "poison_bolt";
            Poison_Bolt.craftedAt = "forge";
            Poison_Bolt.craftAmount = 20;
            Poison_Bolt.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.poison, new ItemStatConfig{ default_value = 52, min =  0, max =  200 } },
                { ItemStat.pierce, new ItemStatConfig{ default_value = 26, min =  0, max =  200 } },
            };
            Poison_Bolt.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Wood", amount = 8, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Iron", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Feathers", amount = 2, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Ooze", amount = 1, upgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Poison_Bolt);

            // Obsidian Bolt						workbench lvl 3
            ItemDefinition Obsidian_Bolt = new ItemDefinition();
            Obsidian_Bolt.Name = "Obsidian Bolt";
            Obsidian_Bolt.Category = ItemCategory.Arrows;
            Obsidian_Bolt.prefab = "VAObsidianBolt";
            Obsidian_Bolt.icon = "obsidian_bolt";
            Obsidian_Bolt.craftedAt = "piece_workbench";
            Obsidian_Bolt.craftAmount = 20;
            Obsidian_Bolt.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ default_value = 52, min =  0, max =  200 } },
            };
            Obsidian_Bolt.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Wood", amount = 8, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Obsidian", amount = 4, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Feathers", amount = 2, upgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Obsidian_Bolt);

            // Silver Ice Bolt						forge lvl 3
            ItemDefinition Frost_Bolt = new ItemDefinition();
            Frost_Bolt.Name = "Frost Bolt";
            Frost_Bolt.Category = ItemCategory.Arrows;
            Frost_Bolt.prefab = "VAbolt_frost";
            Frost_Bolt.icon = "ice_bolt";
            Frost_Bolt.craftedAt = "forge";
            Frost_Bolt.craftAmount = 20;
            Frost_Bolt.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.frost, new ItemStatConfig{ default_value = 52, min =  0, max =  200 } },
                { ItemStat.spirit, new ItemStatConfig{ default_value = 20, min =  0, max =  200 } },
                { ItemStat.pierce, new ItemStatConfig{ default_value = 26, min =  0, max =  200 } },
            };
            Frost_Bolt.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Wood", amount = 8, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Silver", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Feathers", amount = 2, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "FreezeGland", amount = 1, upgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Frost_Bolt);

            // Iron Surtling bolt					forge lvl 2
            ItemDefinition Surtling_Core_Bolt = new ItemDefinition();
            Surtling_Core_Bolt.Name = "Surtling Core Bolt";
            Surtling_Core_Bolt.Category = ItemCategory.Arrows;
            Surtling_Core_Bolt.prefab = "VASurtlingBolt";
            Surtling_Core_Bolt.icon = "surtling_bolt";
            Surtling_Core_Bolt.craftedAt = "forge";
            Surtling_Core_Bolt.craftAmount = 20;
            Surtling_Core_Bolt.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.fire, new ItemStatConfig{ default_value = 52, min =  0, max =  200 } },
                { ItemStat.pierce, new ItemStatConfig{ default_value = 26, min =  0, max =  200 } },
            };
            Surtling_Core_Bolt.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Wood", amount = 8, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Iron", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Feathers", amount = 2, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "SurtlingCore", amount = 1, upgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Surtling_Core_Bolt);

            // Needle bolt					forge lvl 4
            ItemDefinition Needle_Bolt = new ItemDefinition();
            Needle_Bolt.Name = "Needle Bolt";
            Needle_Bolt.Category = ItemCategory.Arrows;
            Needle_Bolt.prefab = "VABoltNeedle";
            Needle_Bolt.icon = "needle_bolt";
            Needle_Bolt.craftedAt = "piece_workbench";
            Needle_Bolt.craftAmount = 20;
            Needle_Bolt.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ default_value = 56, min =  0, max =  200 } },
            };
            Needle_Bolt.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Needle", amount = 8, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Feathers", amount = 2, upgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Needle_Bolt);

            // Fire bolt					forge lvl 2
            ItemDefinition Fire_Bolt = new ItemDefinition();
            Fire_Bolt.Name = "Fire Bolt";
            Fire_Bolt.Category = ItemCategory.Arrows;
            Fire_Bolt.prefab = "VAFireBolt";
            Fire_Bolt.icon = "surtling_bolt";
            Fire_Bolt.craftedAt = "piece_workbench";
            Fire_Bolt.craftAmount = 20;
            Fire_Bolt.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ default_value = 22, min =  0, max =  200 } },
                { ItemStat.fire, new ItemStatConfig{ default_value = 34, min =  0, max =  200 } },
            };
            Fire_Bolt.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Wood", amount = 8, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Resin", amount = 8, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Feathers", amount = 2, upgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Fire_Bolt);
        }

        private void LoadBows()
        {
            Logger.LogInfo("Loading Bows");

            // Blackmetal Bow
            ItemDefinition Blackmetal_Bow = new ItemDefinition();
            Blackmetal_Bow.Name = "Blackmetal Bow";
            Blackmetal_Bow.Category = ItemCategory.Bows;
            Blackmetal_Bow.prefab = "VABlackmetal_bow";
            Blackmetal_Bow.icon = "blackmetal_bow";
            Blackmetal_Bow.craftedAt = "forge";
            Blackmetal_Bow.craftAmount = 1;
            Blackmetal_Bow.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ default_value = 62, min =  0, max =  300 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 3, min =  0, max =  50 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 3, min =  0, max =  150 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 20, min =  0, max =  300 } },
                { ItemStat.draw_stamina_drain, new ItemStatConfig{ default_value = 12, min =  1, max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.bow_draw_speed, new ItemStatConfig{ default_value = 2, min =  0.01f, max =  2 } },
                { ItemStat.projectile_velocity, new ItemStatConfig{ default_value = 60, min =  0, max =  120 } },
            };
            Blackmetal_Bow.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "FineWood", amount = 15, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "BlackMetal", amount = 20, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "LinenThread", amount = 5, upgradeCost = 5 },
                }
            };
            Loader.AddDefinition(Blackmetal_Bow);

            // Heavy Blood Bone Bow
            ItemDefinition Carapace_Blood_Bow = new ItemDefinition();
            Carapace_Blood_Bow.Name = "Carapace Blood Bow";
            Carapace_Blood_Bow.Category = ItemCategory.Bows;
            Carapace_Blood_Bow.prefab = "VAHeavy_Blood_Bone_Bow";
            Carapace_Blood_Bow.icon = "blood_bone_bow_heavy";
            Carapace_Blood_Bow.craftedAt = "piece_magetable";
            Carapace_Blood_Bow.craftAmount = 1;
            Carapace_Blood_Bow.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ default_value = 92, min =  0, max =  300 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 3, min =  0, max =  50 } },
                { ItemStat.spirit, new ItemStatConfig{ default_value = 24, min =  0, max =  200 } },
                { ItemStat.spirit_per_level, new ItemStatConfig{ default_value = 2, min =  0, max =  50 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 5, min =  0, max =  150 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 20, min =  0, max =  300 } },
                { ItemStat.draw_stamina_drain, new ItemStatConfig{ default_value = 6, min =  1, max =  50 } },
                { ItemStat.primary_attack_flat_health_cost, new ItemStatConfig{ default_value = 12, min =  0, max =  50 } },
                { ItemStat.primary_attack_percent_health_cost, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.bow_draw_speed, new ItemStatConfig{ default_value = 2, min =  0.01f, max =  2 } },
                { ItemStat.projectile_velocity, new ItemStatConfig{ default_value = 60, min =  0, max =  120 } },
            };
            Carapace_Blood_Bow.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "YggdrasilWood", amount = 14, upgradeCost = 7 },
                    new RecipeIngredient { prefab = "Iron", amount = 10, upgradeCost = 6 },
                    new RecipeIngredient { prefab = "Carapace", amount = 24, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "TrophyTick", amount = 2, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Eitr", amount = 0, upgradeCost = 10 },
                }
            };
            Loader.AddDefinition(Carapace_Blood_Bow);

            // Blood Bone Bow
            ItemDefinition Blood_Bone_Bow = new ItemDefinition();
            Blood_Bone_Bow.Name = "Blood Bone Bow";
            Blood_Bone_Bow.Category = ItemCategory.Bows;
            Blood_Bone_Bow.prefab = "VABlood_bone_bow";
            Blood_Bone_Bow.icon = "bone_bow";
            Blood_Bone_Bow.craftedAt = "forge";
            Blood_Bone_Bow.craftAmount = 1;
            Blood_Bone_Bow.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ default_value = 60, min =  0, max =  300 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 3, min =  0, max =  50 } },
                { ItemStat.spirit, new ItemStatConfig{ default_value = 18, min =  0, max =  200 } },
                { ItemStat.spirit_per_level, new ItemStatConfig{ default_value = 2, min =  0, max =  50 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 3, min =  0, max =  150 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 20, min =  0, max =  300 } },
                { ItemStat.draw_stamina_drain, new ItemStatConfig{ default_value = 4, min =  1, max =  50 } },
                { ItemStat.primary_attack_flat_health_cost, new ItemStatConfig{ default_value = 8, min =  0, max =  50 } },
                { ItemStat.primary_attack_percent_health_cost, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.bow_draw_speed, new ItemStatConfig{ default_value = 2, min =  0.01f, max =  2 } },
                { ItemStat.projectile_velocity, new ItemStatConfig{ default_value = 60, min =  0, max =  120 } },
            };
            Blood_Bone_Bow.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "ElderBark", amount = 10, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "Silver", amount = 10, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "BoneFragments", amount = 20, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "TrophyUlv", amount = 2, upgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Blood_Bone_Bow);

            // Bronze Arbalist
            ItemDefinition Bronze_Arbelist = new ItemDefinition();
            Bronze_Arbelist.Name = "Bronze Arbelist";
            Bronze_Arbelist.Category = ItemCategory.Bows;
            Bronze_Arbelist.prefab = "VAArbalistBronze";
            Bronze_Arbelist.icon = "bronze_crossbow_upright";
            Bronze_Arbelist.craftedAt = "forge";
            Bronze_Arbelist.craftAmount = 1;
            Bronze_Arbelist.craftable = false;
            Bronze_Arbelist.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ default_value = 140, min =  0, max =  300 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 200, min =  0, max =  300 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 3, min =  0, max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 100, min =  0, max =  300 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.crossbow_reload_speed, new ItemStatConfig{ default_value = 3.5f, min =  0.01f, max =  3.5f } },
                { ItemStat.crossbow_reload_stamina_drain, new ItemStatConfig{ default_value = 1, min =  1, max =  50 } },
                { ItemStat.projectile_velocity, new ItemStatConfig{ default_value = 200, min =  0, max =  300 } },
            };
            Bronze_Arbelist.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "ElderBark", amount = 10, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "Bronze", amount = 20, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "JuteRed", amount = 5, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "Silver", amount = 2, upgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Bronze_Arbelist);

            // Iron Crossbow
            ItemDefinition IronCrossbow = new ItemDefinition();
            IronCrossbow.Name = "Iron Crossbow";
            IronCrossbow.Category = ItemCategory.Bows;
            IronCrossbow.prefab = "VACrossbowIron";
            IronCrossbow.icon = "iron_crossbow";
            IronCrossbow.craftedAt = "forge";
            IronCrossbow.craftAmount = 1;
            IronCrossbow.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ default_value = 120, min =  0, max =  300 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 200, min =  0, max =  300 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 3, min =  0, max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 100, min =  0, max =  300 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.crossbow_reload_speed, new ItemStatConfig{ default_value = 3.5f, min =  0.01f, max =  3.5f } },
                { ItemStat.crossbow_reload_stamina_drain, new ItemStatConfig{ default_value = 1, min =  1, max =  50 } },
                { ItemStat.projectile_velocity, new ItemStatConfig{ default_value = 200, min =  0, max =  300 } },
            };
            IronCrossbow.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "ElderBark", amount = 5, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "FineWood", amount = 20, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "Iron", amount = 10, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "IronNails", amount = 2, upgradeCost = 2 },
                }
            };
            Loader.AddDefinition(IronCrossbow);

            // Silver Crossbow
            ItemDefinition SilverCrossbow = new ItemDefinition();
            SilverCrossbow.Name = "Silver Crossbow";
            SilverCrossbow.Category = ItemCategory.Bows;
            SilverCrossbow.prefab = "VACrossbowSilver";
            SilverCrossbow.icon = "silver_crossbow";
            SilverCrossbow.craftedAt = "forge";
            SilverCrossbow.craftAmount = 1;
            SilverCrossbow.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ default_value = 140, min =  0, max =  300 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ default_value = 30, min =  0, max =  300 } },
                { ItemStat.spirit, new ItemStatConfig{ default_value = 40, min =  0, max =  300 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 200, min =  0, max =  300 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 3, min =  0, max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 100, min =  0, max =  300 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.crossbow_reload_speed, new ItemStatConfig{ default_value = 3.5f, min =  0.01f, max =  3.5f } },
                { ItemStat.crossbow_reload_stamina_drain, new ItemStatConfig{ default_value = 1, min =  1, max =  50 } },
                { ItemStat.projectile_velocity, new ItemStatConfig{ default_value = 200, min =  0, max =  300 } },
            };
            SilverCrossbow.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Guck", amount = 5, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "ElderBark", amount = 20, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "Silver", amount = 12, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "IronNails", amount = 2, upgradeCost = 2 },
                }
            };
            Loader.AddDefinition(SilverCrossbow);

            // Blackmetal crossbow
            ItemDefinition BlackmetalCrossbow = new ItemDefinition();
            BlackmetalCrossbow.Name = "Blackmetal Crossbow";
            BlackmetalCrossbow.Category = ItemCategory.Bows;
            BlackmetalCrossbow.prefab = "VACrossbowBlackmetal";
            BlackmetalCrossbow.icon = "blackmetal_crossbow";
            BlackmetalCrossbow.craftedAt = "forge";
            BlackmetalCrossbow.craftAmount = 1;
            BlackmetalCrossbow.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ default_value = 180, min =  0, max =  300 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 3, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 200, min =  0, max =  300 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 3, min =  0, max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 50, min =  0, max =  300 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.crossbow_reload_speed, new ItemStatConfig{ default_value = 3.5f, min =  0.01f, max =  3.5f } },
                { ItemStat.crossbow_reload_stamina_drain, new ItemStatConfig{ default_value = 1, min =  1, max =  50 } },
                { ItemStat.projectile_velocity, new ItemStatConfig{ default_value = 200, min =  0, max =  300 } },
            };
            BlackmetalCrossbow.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "FineWood", amount = 16, upgradeCost = 8 },
                    new RecipeIngredient { prefab = "BlackMetal", amount = 20, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "LinenThread", amount = 6, upgradeCost = 4 },
                    new RecipeIngredient { prefab = "Iron", amount = 4, upgradeCost = 2 },
                }
            };
            Loader.AddDefinition(BlackmetalCrossbow);

            // Antler Bow
            ItemDefinition Eikthyrs_Bow = new ItemDefinition();
            Eikthyrs_Bow.Name = "Eikthyrs Bow";
            Eikthyrs_Bow.Category = ItemCategory.Bows;
            Eikthyrs_Bow.prefab = "VAAntler_Bow";
            Eikthyrs_Bow.icon = "antler_bow";
            Eikthyrs_Bow.craftedAt = "piece_workbench";
            Eikthyrs_Bow.craftAmount = 1;
            Eikthyrs_Bow.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ default_value = 26, min =  0, max =  120 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 2, min =  0, max =  50 } },
                { ItemStat.lightning, new ItemStatConfig{ default_value = 4, min =  0, max =  90 } },
                { ItemStat.lightning_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 3, min =  0, max =  50 } },
                { ItemStat.draw_stamina_drain, new ItemStatConfig{ default_value = 6, min =  1, max =  50 } },
                { ItemStat.bow_draw_speed, new ItemStatConfig{ default_value = 2.5f, min =  0.01f, max =  2.5f } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 100, min =  0, max =  300 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.projectile_velocity, new ItemStatConfig{ default_value = 45, min =  0, max =  120 } },
            };
            Eikthyrs_Bow.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "FineWood", amount = 15, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "Resin", amount = 20, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "HardAntler", amount = 3, upgradeCost = 3 },
                    new RecipeIngredient { prefab = "TrophyEikthyr", amount = 1, upgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Eikthyrs_Bow);

            // Bronze Crossbow
            ItemDefinition Bronze_Crossbow = new ItemDefinition();
            Bronze_Crossbow.Name = "Bronze Crossbow";
            Bronze_Crossbow.Category = ItemCategory.Bows;
            Bronze_Crossbow.prefab = "VACrossbowBronze";
            Bronze_Crossbow.icon = "bronze_crossbow2";
            Bronze_Crossbow.craftedAt = "forge";
            Bronze_Crossbow.craftAmount = 1;
            Bronze_Crossbow.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ default_value = 80, min =  0, max =  300 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 3, min =  0, max =  50 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 3, min =  0, max =  150 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 150, min =  0, max =  300 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 100, min =  0, max =  300 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.crossbow_reload_speed, new ItemStatConfig{ default_value = 3.5f, min =  0.01f, max =  3.5f } },
                { ItemStat.crossbow_reload_stamina_drain, new ItemStatConfig{ default_value = 1, min =  1, max =  50 } },
                { ItemStat.projectile_velocity, new ItemStatConfig{ default_value = 200, min =  0, max =  300 } },
            };
            Bronze_Crossbow.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "FineWood", amount = 10, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "RoundLog", amount = 10, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "Bronze", amount = 4, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "DeerHide", amount = 2, upgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Bronze_Crossbow);

            // Wood Crossbow
            ItemDefinition WoodCrossbow = new ItemDefinition();
            WoodCrossbow.Name = "Wood Crossbow";
            WoodCrossbow.Category = ItemCategory.Bows;
            WoodCrossbow.prefab = "VACrossbowWood";
            WoodCrossbow.icon = "woodCrossbow";
            WoodCrossbow.craftedAt = "piece_workbench";
            WoodCrossbow.craftAmount = 1;
            WoodCrossbow.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ default_value = 40, min =  0, max =  300 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 3, min =  0, max =  50 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 3, min =  0, max =  150 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 150, min =  0, max =  300 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 50, min =  0, max =  300 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.crossbow_reload_speed, new ItemStatConfig{ default_value = 7f, min =  0.01f, max =  10f } },
                { ItemStat.crossbow_reload_stamina_drain, new ItemStatConfig{ default_value = 1, min =  1, max =  50 } },
                { ItemStat.projectile_velocity, new ItemStatConfig{ default_value = 200, min =  0, max =  300 } },
            };
            WoodCrossbow.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Wood", amount = 30, upgradeCost = 15 },
                    new RecipeIngredient { prefab = "Resin", amount = 10, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "DeerHide", amount = 2, upgradeCost = 2 },
                }
            };
            Loader.AddDefinition(WoodCrossbow);

            // Elder Crossbow
            ItemDefinition Elders_Reach = new ItemDefinition();
            Elders_Reach.Name = "Elders Reach";
            Elders_Reach.Category = ItemCategory.Bows;
            Elders_Reach.prefab = "VACrossbowElder";
            Elders_Reach.icon = "elder_crossbow";
            Elders_Reach.craftedAt = "forge";
            Elders_Reach.craftAmount = 1;
            Elders_Reach.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ default_value = 80, min =  0, max =  300 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 3, min =  0, max =  50 } },
                { ItemStat.spirit, new ItemStatConfig{ default_value = 7, min =  0, max =  300 } },
                { ItemStat.spirit_per_level, new ItemStatConfig{ default_value = 2, min =  0, max =  50 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 3, min =  0, max =  150 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 150, min =  0, max =  300 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 100, min =  0, max =  300 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.crossbow_reload_speed, new ItemStatConfig{ default_value = 3.5f, min =  0.01f, max =  3.5f } },
                { ItemStat.crossbow_reload_stamina_drain, new ItemStatConfig{ default_value = 1, min =  1, max =  50 } },
                { ItemStat.projectile_velocity, new ItemStatConfig{ default_value = 200, min =  0, max =  300 } },
            };
            Elders_Reach.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Bronze", amount = 4, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "RoundLog", amount = 20, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "CryptKey", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "TrophyTheElder", amount = 1, upgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Elders_Reach);

            // Moder Crossbow
            ItemDefinition Moder_Crossbow = new ItemDefinition();
            Moder_Crossbow.Name = "Moder Crossbow";
            Moder_Crossbow.Category = ItemCategory.Bows;
            Moder_Crossbow.prefab = "VACrossbowModer";
            Moder_Crossbow.icon = "moder_crossbow";
            Moder_Crossbow.craftedAt = "forge";
            Moder_Crossbow.craftAmount = 1;
            Moder_Crossbow.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ default_value = 150, min =  0, max =  300 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 3, min =  0, max =  50 } },
                { ItemStat.frost, new ItemStatConfig{ default_value = 25, min =  0, max =  300 } },
                { ItemStat.frost_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 3, min =  0, max =  150 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 200, min =  0, max =  300 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 100, min =  0, max =  300 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.crossbow_reload_speed, new ItemStatConfig{ default_value = 3.5f, min =  0.01f, max =  3.5f } },
                { ItemStat.crossbow_reload_stamina_drain, new ItemStatConfig{ default_value = 1, min =  1, max =  50 } },
                { ItemStat.projectile_velocity, new ItemStatConfig{ default_value = 200, min =  0, max =  300 } },
            };
            Moder_Crossbow.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "ElderBark", amount = 10, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "Obsidian", amount = 20, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "DragonTear", amount = 10, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "TrophyDragonQueen", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Silver", amount = 0, upgradeCost = 6 },
                }
            };
            Loader.AddDefinition(Moder_Crossbow);

            // Queen Bow
            ItemDefinition Queens_Greatbow = new ItemDefinition();
            Queens_Greatbow.Name = "Queens Greatbow";
            Queens_Greatbow.Category = ItemCategory.Bows;
            Queens_Greatbow.prefab = "VAQueen_bow";
            Queens_Greatbow.icon = "queen_bow";
            Queens_Greatbow.craftedAt = "blackforge";
            Queens_Greatbow.craftAmount = 1;
            Queens_Greatbow.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ default_value = 72, min =  0, max =  200 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 3, min =  0, max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ default_value = 25, min =  0, max =  90 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.lightning, new ItemStatConfig{ default_value = 30, min =  0, max =  99 } },
                { ItemStat.lightning_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 25, min =  0, max =  50 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 3, min =  0, max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 100, min =  0, max =  300 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.draw_stamina_drain, new ItemStatConfig{ default_value = 12, min =  1, max =  50 } },
                { ItemStat.bow_draw_speed, new ItemStatConfig{ default_value = 3f, min =  0.01f, max =  3f } },
                { ItemStat.projectile_velocity, new ItemStatConfig{ default_value = 60, min =  0, max =  120 } },
            };
            Queens_Greatbow.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "YggdrasilWood", amount = 10, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "Eitr", amount = 20, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "JuteBlue", amount = 4, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "TrophySeekerQueen", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Carapace", amount = 0, upgradeCost = 4 },
                }
            };
            Loader.AddDefinition(Queens_Greatbow);
        }

        private void LoadSwords()
        {
            Logger.LogInfo("Loading Swords");
            // Fader Sword
            ItemDefinition FaderSword = new ItemDefinition();
            FaderSword.Name = "Faders Sword";
            FaderSword.Category = ItemCategory.Swords;
            FaderSword.prefab = "VASwordFader";
            FaderSword.icon = "fader_sword";
            FaderSword.craftedAt = "blackforge";
            FaderSword.craftAmount = 1;
            FaderSword.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 145, min =  0, max =  250 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 3, min =  0, max =  50 } },
                { ItemStat.fire, new ItemStatConfig{ default_value = 25, min =  0, max =  250 } },
                { ItemStat.fire_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ default_value = 25, min =  0, max =  250 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 55, min =  0, max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 60, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 50, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 18, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 30, min =  1, max =  50 } },
            };
            FaderSword.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "FlametalNew", amount = 30, upgradeCost = 30 },
                    new RecipeIngredient { prefab = "CharredBone", amount = 30, upgradeCost = 30 },
                    new RecipeIngredient { prefab = "TrophyFader", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "FaderDrop", amount = 1, upgradeCost = 0 },
                }
            };
            Loader.AddDefinition(FaderSword);

            // Faders Greatsword
            ItemDefinition FaderGreatsword = new ItemDefinition();
            FaderGreatsword.Name = "Faders Greatsword";
            FaderGreatsword.Category = ItemCategory.Swords;
            FaderGreatsword.prefab = "VAGreatswordFader";
            FaderGreatsword.icon = "fader_greatsword";
            FaderGreatsword.craftedAt = "blackforge";
            FaderGreatsword.craftAmount = 1;
            FaderGreatsword.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 180, min =  0, max =  250 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 3, min =  0, max =  50 } },
                { ItemStat.fire, new ItemStatConfig{ default_value = 30, min =  0, max =  250 } },
                { ItemStat.fire_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ default_value = 30, min =  0, max =  250 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 55, min =  0, max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 60, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 50, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 18, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 30, min =  1, max =  50 } },
            };
            FaderGreatsword.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "FlametalNew", amount = 40, upgradeCost = 20 },
                    new RecipeIngredient { prefab = "CharredBone", amount = 20, upgradeCost = 20 },
                    new RecipeIngredient { prefab = "TrophyFader", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "FaderDrop", amount = 1, upgradeCost = 0 },
                }
            };
            Loader.AddDefinition(FaderGreatsword);

            // Blackmetal Greatsword
            ItemDefinition Blackmetal_Greatsword = new ItemDefinition();
            Blackmetal_Greatsword.Name = "Blackmetal Greatsword";
            Blackmetal_Greatsword.Category = ItemCategory.Swords;
            Blackmetal_Greatsword.prefab = "VABlackmetal_greatsword";
            Blackmetal_Greatsword.icon = "blackmetal_greatsword";
            Blackmetal_Greatsword.craftedAt = "forge";
            Blackmetal_Greatsword.craftAmount = 1;
            Blackmetal_Greatsword.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 125, min =  0, max =  250 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 55, min =  0, max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 52, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 50, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 18, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 36, min =  1, max =  50 } },
            };
            Blackmetal_Greatsword.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "BlackMetal", amount = 30, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "LinenThread", amount = 10, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "FineWood", amount = 6, upgradeCost = 3 },
                }
            };
            Loader.AddDefinition(Blackmetal_Greatsword);
            // Abyssal Sword
            ItemDefinition Abyssal_Sword = new ItemDefinition();
            Abyssal_Sword.Name = "Abyssal Sword";
            Abyssal_Sword.Category = ItemCategory.Swords;
            Abyssal_Sword.prefab = "VASwordChitin";
            Abyssal_Sword.icon = "chitin_sword";
            Abyssal_Sword.craftedAt = "piece_workbench";
            Abyssal_Sword.craftAmount = 1;
            Abyssal_Sword.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.blunt, new ItemStatConfig{ default_value = 20, min =  0, max =  90 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ default_value = 4, min =  0, max =  50 } },
                { ItemStat.slash, new ItemStatConfig{ default_value = 25, min =  0, max =  120 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 2, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 40, min =  0, max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 18, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 20, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 10, min =  1, max =  30 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 20, min =  1, max =  50 } },
            };
            Abyssal_Sword.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "FineWood", amount = 2, upgradeCost = 1 },
                    new RecipeIngredient { prefab = "Chitin", amount = 30, upgradeCost = 15 },
                    new RecipeIngredient { prefab = "DeerHide", amount = 2, upgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Abyssal_Sword);

            // Antler Sword
            ItemDefinition Eikthyrs_Sword = new ItemDefinition();
            Eikthyrs_Sword.Name = "Eikthyrs Sword";
            Eikthyrs_Sword.Category = ItemCategory.Swords;
            Eikthyrs_Sword.prefab = "VAAntler_Sword";
            Eikthyrs_Sword.icon = "antler_sword";
            Eikthyrs_Sword.craftedAt = "piece_workbench";
            Eikthyrs_Sword.craftAmount = 1;
            Eikthyrs_Sword.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 16, min =  0, max =  90 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 2, min =  0, max =  50 } },
                { ItemStat.blunt, new ItemStatConfig{ default_value = 8, min =  0, max =  90 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ default_value = 4, min =  0, max =  50 } },
                { ItemStat.lightning, new ItemStatConfig{ default_value = 6, min =  0, max =  120 } },
                { ItemStat.lightning_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 40, min =  0, max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 8, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 20, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 8, min =  1, max =  30 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 16, min =  1, max =  50 } },
            };
            Eikthyrs_Sword.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "FineWood", amount = 3, upgradeCost = 1 },
                    new RecipeIngredient { prefab = "Resin", amount = 16, upgradeCost = 8 },
                    new RecipeIngredient { prefab = "HardAntler", amount = 3, upgradeCost = 3 },
                    new RecipeIngredient { prefab = "TrophyEikthyr", amount = 1, upgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Eikthyrs_Sword);

            // Vine Sword
            ItemDefinition Elders_Balance = new ItemDefinition();
            Elders_Balance.Name = "Elders Balance";
            Elders_Balance.Category = ItemCategory.Swords;
            Elders_Balance.prefab = "VAVine_Sword";
            Elders_Balance.icon = "vine_sword";
            Elders_Balance.craftedAt = "forge";
            Elders_Balance.craftAmount = 1;
            Elders_Balance.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 40, min =  0, max =  90 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.spirit, new ItemStatConfig{ default_value = 10, min =  0, max =  120 } },
                { ItemStat.spirit_per_level, new ItemStatConfig{ default_value = 2, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 40, min =  0, max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 12, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 20, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 8, min =  1, max =  30 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 16, min =  1, max =  50 } },
            };
            Elders_Balance.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Bronze", amount = 2, upgradeCost = 1 },
                    new RecipeIngredient { prefab = "Stone", amount = 16, upgradeCost = 8 },
                    new RecipeIngredient { prefab = "CryptKey", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "TrophyTheElder", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "RoundLog", amount = 0, upgradeCost = 4 },
                }
            };
            Loader.AddDefinition(Elders_Balance);

            // Moders Sword
            ItemDefinition Moders_Grasp = new ItemDefinition();
            Moders_Grasp.Name = "Moders Grasp";
            Moders_Grasp.Category = ItemCategory.Swords;
            Moders_Grasp.prefab = "VASwordModer";
            Moders_Grasp.icon = "moder_sword";
            Moders_Grasp.craftedAt = "forge";
            Moders_Grasp.craftAmount = 1;
            Moders_Grasp.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 35, min =  0, max =  90 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 2, min =  0, max =  50 } },
                { ItemStat.pierce, new ItemStatConfig{ default_value = 30, min =  0, max =  90 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 4, min =  0, max =  50 } },
                { ItemStat.frost, new ItemStatConfig{ default_value = 25, min =  0, max =  120 } },
                { ItemStat.frost_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 40, min =  0, max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 30, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 20, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 12, min =  1, max =  30 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 24, min =  1, max =  50 } },
            };
            Moders_Grasp.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "ElderBark", amount = 4, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "Obsidian", amount = 30, upgradeCost = 15 },
                    new RecipeIngredient { prefab = "DragonTear", amount = 10, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "TrophyDragonQueen", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Silver", amount = 0, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "JuteRed", amount = 0, upgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Moders_Grasp);

            // Moders Greatsword
            ItemDefinition Moders_Greatsword = new ItemDefinition();
            Moders_Greatsword.Name = "Moders Greatsword";
            Moders_Greatsword.Category = ItemCategory.Swords;
            Moders_Greatsword.prefab = "VAModer_greatsword";
            Moders_Greatsword.icon = "moder_greatsword";
            Moders_Greatsword.craftedAt = "forge";
            Moders_Greatsword.craftAmount = 1;
            Moders_Greatsword.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 55, min =  0, max =  90 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 2, min =  0, max =  50 } },
                { ItemStat.pierce, new ItemStatConfig{ default_value = 40, min =  0, max =  90 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 4, min =  0, max =  50 } },
                { ItemStat.frost, new ItemStatConfig{ default_value = 25, min =  0, max =  120 } },
                { ItemStat.frost_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 55, min =  0, max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 48, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 50, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 17, min =  1, max =  30 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 34, min =  1, max =  50 } },
            };
            Moders_Greatsword.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Crystal", amount = 25, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "Obsidian", amount = 15, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "DragonTear", amount = 10, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "TrophyDragonQueen", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Silver", amount = 0, upgradeCost = 4 },
                    new RecipeIngredient { prefab = "JuteRed", amount = 0, upgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Moders_Greatsword);

            // Bronze Greatsword
            ItemDefinition Bronze_Greatsword = new ItemDefinition();
            Bronze_Greatsword.Name = "Bronze Greatsword";
            Bronze_Greatsword.Category = ItemCategory.Swords;
            Bronze_Greatsword.prefab = "VAbronze_greatsword";
            Bronze_Greatsword.icon = "bronze_greatsword_reforged";
            Bronze_Greatsword.craftedAt = "forge";
            Bronze_Greatsword.craftAmount = 1;
            Bronze_Greatsword.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 50, min =  0, max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 55, min =  0, max =  160 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 16, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 50, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 12, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 24, min =  1, max =  50 } },
            };
            Bronze_Greatsword.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "RoundLog", amount = 4, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Bronze", amount = 20, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "DeerHide", amount = 3, upgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Bronze_Greatsword);

            // Iron Greatsword
            ItemDefinition Iron_Greatsword = new ItemDefinition();
            Iron_Greatsword.Name = "Iron Greatsword";
            Iron_Greatsword.Category = ItemCategory.Swords;
            Iron_Greatsword.prefab = "VAiron_greatsword";
            Iron_Greatsword.icon = "iron_greatsword_reforged";
            Iron_Greatsword.craftedAt = "forge";
            Iron_Greatsword.craftAmount = 1;
            Iron_Greatsword.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 75, min =  0, max =  250 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 55, min =  0, max =  160 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 28, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 50, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 14, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 28, min =  1, max =  50 } },
            };
            Iron_Greatsword.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "ElderBark", amount = 15, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "Iron", amount = 30, upgradeCost = 15 },
                    new RecipeIngredient { prefab = "LeatherScraps", amount = 4, upgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Iron_Greatsword);

            // Silver Greatsword
            ItemDefinition Silver_Greatsword = new ItemDefinition();
            Silver_Greatsword.Name = "Silver Greatsword";
            Silver_Greatsword.Category = ItemCategory.Swords;
            Silver_Greatsword.prefab = "VAsilver_greatsword";
            Silver_Greatsword.icon = "silver_greatsword_reforged";
            Silver_Greatsword.craftedAt = "forge";
            Silver_Greatsword.craftAmount = 1;
            Silver_Greatsword.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 100, min =  0, max =  300 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.spirit, new ItemStatConfig{ default_value = 30, min =  0, max =  120 } },
                { ItemStat.spirit_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 55, min =  0, max =  160 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 40, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 50, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 16, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 32, min =  1, max =  50 } },
            };
            Silver_Greatsword.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Wood", amount = 10, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "Silver", amount = 45, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "Iron", amount = 5, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "LeatherScraps", amount = 3, upgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Silver_Greatsword);

            // Bonemass Greatsword
            ItemDefinition Bm_sword = new ItemDefinition();
            Bm_sword.Name = "Bonemasses Sword";
            Bm_sword.Category = ItemCategory.Swords;
            Bm_sword.prefab = "VABonemassSword";
            Bm_sword.icon = "bonemass_sword";
            Bm_sword.craftedAt = "forge";
            Bm_sword.craftAmount = 1;
            Bm_sword.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 65, min =  0, max =  250 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ default_value = 20, min =  0, max =  250 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 55, min =  0, max =  160 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 30, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 45, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 15, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 30, min =  1, max =  50 } },
            };
            Bm_sword.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "WitheredBone", amount = 10, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "Iron", amount = 22, upgradeCost = 15 },
                    new RecipeIngredient { prefab = "Wishbone", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "TrophyBonemass", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "ElderBark", amount = 0, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "LeatherScraps", amount = 0, upgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Bm_sword);

            // Bonemass Greatsword
            ItemDefinition Bonemasses_Greatsword = new ItemDefinition();
            Bonemasses_Greatsword.Name = "Bonemasses Greatsword";
            Bonemasses_Greatsword.Category = ItemCategory.Swords;
            Bonemasses_Greatsword.prefab = "VABonemassGreatsword";
            Bonemasses_Greatsword.icon = "bonemass_greatsword";
            Bonemasses_Greatsword.craftedAt = "forge";
            Bonemasses_Greatsword.craftAmount = 1;
            Bonemasses_Greatsword.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 75, min =  0, max =  250 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ default_value = 20, min =  0, max =  250 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 55, min =  0, max =  160 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 36, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 50, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 15, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 30, min =  1, max =  50 } },
            };
            Bonemasses_Greatsword.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "WitheredBone", amount = 15, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "Iron", amount = 30, upgradeCost = 15 },
                    new RecipeIngredient { prefab = "Wishbone", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "TrophyBonemass", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "ElderBark", amount = 0, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "LeatherScraps", amount = 0, upgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Bonemasses_Greatsword);

            // Yagluth Greatsword
            ItemDefinition Yagluths_Greatsword = new ItemDefinition();
            Yagluths_Greatsword.Name = "Yagluths Greatsword";
            Yagluths_Greatsword.Category = ItemCategory.Swords;
            Yagluths_Greatsword.prefab = "VAYagluth_greatsword";
            Yagluths_Greatsword.icon = "yagluth_greatsword";
            Yagluths_Greatsword.craftedAt = "forge";
            Yagluths_Greatsword.craftAmount = 1;
            Yagluths_Greatsword.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 125, min =  0, max =  250 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.fire, new ItemStatConfig{ default_value = 25, min =  0, max =  250 } },
                { ItemStat.fire_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 55, min =  0, max =  160 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 49, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 50, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 18, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 36, min =  1, max =  50 } },
            };
            Yagluths_Greatsword.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "BlackMetal", amount = 10, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "Iron", amount = 4, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "YagluthDrop", amount = 2, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "TrophyGoblinKing", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Tar", amount = 0, upgradeCost = 3 },
                    new RecipeIngredient { prefab = "LinenThread", amount = 0, upgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Yagluths_Greatsword);

            // Flint Sword
            ItemDefinition Flint_Sword = new ItemDefinition();
            Flint_Sword.Name = "Flint Sword";
            Flint_Sword.Category = ItemCategory.Swords;
            Flint_Sword.prefab = "VAFlint_Sword";
            Flint_Sword.icon = "flint_sword";
            Flint_Sword.craftedAt = "piece_workbench";
            Flint_Sword.craftAmount = 1;
            Flint_Sword.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 15, min =  0, max =  90 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 40, min =  0, max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 4, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 20, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 6, min =  1, max =  30 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 12, min =  1, max =  50 } },
            };
            Flint_Sword.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Wood", amount = 2, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Flint", amount = 6, upgradeCost = 3 },
                    new RecipeIngredient { prefab = "LeatherScraps", amount = 0, upgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Flint_Sword);

            // Flint Greatsword
            ItemDefinition Flint_Greatsword = new ItemDefinition();
            Flint_Greatsword.Name = "Flint Greatsword";
            Flint_Greatsword.Category = ItemCategory.Swords;
            Flint_Greatsword.prefab = "VAFlint_greatsword";
            Flint_Greatsword.icon = "flint_greatsword";
            Flint_Greatsword.craftedAt = "piece_workbench";
            Flint_Greatsword.craftAmount = 1;
            Flint_Greatsword.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 25, min =  0, max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 55, min =  0, max =  160 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 14, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 50, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 10, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 20, min =  1, max =  50 } },
            };
            Flint_Greatsword.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Wood", amount = 4, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Flint", amount = 9, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "LeatherScraps", amount = 0, upgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Flint_Greatsword);

            // Queen Greatsword
            ItemDefinition Queen_Greatsword = new ItemDefinition();
            Queen_Greatsword.Name = "Queen Greatsword";
            Queen_Greatsword.Category = ItemCategory.Swords;
            Queen_Greatsword.prefab = "VAQueen_greatsword";
            Queen_Greatsword.icon = "queen_greatsword";
            Queen_Greatsword.craftedAt = "blackforge";
            Queen_Greatsword.craftAmount = 1;
            Queen_Greatsword.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 125, min =  0, max =  250 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ default_value = 25, min =  0, max =  250 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.lightning, new ItemStatConfig{ default_value = 30, min =  0, max =  99 } },
                { ItemStat.lightning_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 55, min =  0, max =  160 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 62, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 50, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 20, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 40, min =  1, max =  50 } },
            };
            Queen_Greatsword.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "YggdrasilWood", amount = 10, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "Eitr", amount = 20, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "JuteBlue", amount = 4, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "TrophySeekerQueen", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Carapace", amount = 0, upgradeCost = 8 },
                }
            };
            Loader.AddDefinition(Queen_Greatsword);

            // Queen sword
            ItemDefinition Queen_Sword = new ItemDefinition();
            Queen_Sword.Name = "Queen Sword";
            Queen_Sword.Category = ItemCategory.Swords;
            Queen_Sword.prefab = "VASwordQueen";
            Queen_Sword.icon = "queen_sword";
            Queen_Sword.craftedAt = "blackforge";
            Queen_Sword.craftAmount = 1;
            Queen_Sword.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 95, min =  0, max =  250 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ default_value = 25, min =  0, max =  250 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.lightning, new ItemStatConfig{ default_value = 30, min =  0, max =  99 } },
                { ItemStat.lightning_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 40, min =  0, max =  160 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 52, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 20, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 16, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 32, min =  1, max =  50 } },
            };
            Queen_Sword.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "YggdrasilWood", amount = 3, upgradeCost = 1 },
                    new RecipeIngredient { prefab = "Eitr", amount = 10, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "JuteBlue", amount = 3, upgradeCost = 1 },
                    new RecipeIngredient { prefab = "TrophySeekerQueen", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Carapace", amount = 0, upgradeCost = 6 },
                }
            };
            Loader.AddDefinition(Queen_Sword);
        }

        private void LoadAxes()
        {
            Logger.LogInfo("Loading Axes");

            
            // Flint Axe
            ItemDefinition FlintAxe = new ItemDefinition();
            FlintAxe.Name = "Flint greataxe";
            FlintAxe.Category = ItemCategory.Axes;
            FlintAxe.prefab = "VAFlint_Axe";
            FlintAxe.icon = "flint_axe";
            FlintAxe.craftedAt = "piece_workbench";
            FlintAxe.craftAmount = 1;
            FlintAxe.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 20, min =  0, max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ default_value = 30, min =  0, max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 50, min =  0, max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 4, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 50, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 100, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 6, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 12, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.05f, min =  -0.15f, max =  0 } },
            };
            FlintAxe.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Wood", amount = 4, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Flint", amount = 6, upgradeCost = 3 },
                    new RecipeIngredient { prefab = "LeatherScraps", amount = 0, upgradeCost = 2 },
                }
            };
            Loader.AddDefinition(FlintAxe);

            // Flint Battleaxe
            ItemDefinition Flint_greataxe = new ItemDefinition();
            Flint_greataxe.Name = "Flint greataxe";
            Flint_greataxe.Category = ItemCategory.Axes;
            Flint_greataxe.prefab = "VAFlint_greataxe";
            Flint_greataxe.icon = "flint_greataxe";
            Flint_greataxe.craftedAt = "piece_workbench";
            Flint_greataxe.craftAmount = 1;
            Flint_greataxe.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 25, min =  0, max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ default_value = 45, min =  0, max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 70, min =  0, max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 14, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 70, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 12, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 6, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.15f, min =  -0.15f, max =  0 } },
            };
            Flint_greataxe.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Wood", amount = 8, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Flint", amount = 9, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "LeatherScraps", amount = 0, upgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Flint_greataxe);

            // Flint Dualaxes
            ItemDefinition Flint_dualaxes = new ItemDefinition();
            Flint_dualaxes.Name = "Flint dualaxes";
            Flint_dualaxes.Category = ItemCategory.Axes;
            Flint_dualaxes.prefab = "VAFlint_dualaxes";
            Flint_dualaxes.icon = "flint_dualaxes";
            Flint_dualaxes.craftedAt = "piece_workbench";
            Flint_dualaxes.craftAmount = 1;
            Flint_dualaxes.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 20, min =  0, max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ default_value = 30, min =  0, max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 50, min =  0, max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 12, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 20, min =  0, max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 175, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 6, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 14, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.05f, min =  -0.20f, max =  0 } },
            };
            Flint_dualaxes.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Wood", amount = 10, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "Flint", amount = 12, upgradeCost = 6 },
                    new RecipeIngredient { prefab = "LeatherScraps", amount = 0, upgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Flint_dualaxes);

            // Bronze Battleaxe
            ItemDefinition Bronze_Lumber_Axe = new ItemDefinition();
            Bronze_Lumber_Axe.Name = "Bronze Lumber Axe";
            Bronze_Lumber_Axe.Category = ItemCategory.Axes;
            Bronze_Lumber_Axe.prefab = "VAbronze_battleaxe";
            Bronze_Lumber_Axe.icon = "bronze_axe_rebuild";
            Bronze_Lumber_Axe.craftedAt = "forge";
            Bronze_Lumber_Axe.craftAmount = 1;
            Bronze_Lumber_Axe.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 50, min =  0, max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ default_value = 30, min =  0, max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ default_value = 2.5f, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 70, min =  0, max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 18, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 70, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 14, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 7, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.15f, min =  -0.15f, max =  0 } },
            };
            Bronze_Lumber_Axe.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "RoundLog", amount = 20, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "Bronze", amount = 10, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "DeerHide", amount = 2, upgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Bronze_Lumber_Axe);

            // Bronze Dualaxes
            ItemDefinition Bronze_dualaxes = new ItemDefinition();
            Bronze_dualaxes.Name = "Bronze dualaxes";
            Bronze_dualaxes.Category = ItemCategory.Axes;
            Bronze_dualaxes.prefab = "VABronze_dualaxes";
            Bronze_dualaxes.icon = "bronze_dualaxes";
            Bronze_dualaxes.craftedAt = "forge";
            Bronze_dualaxes.craftAmount = 1;
            Bronze_dualaxes.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 40, min =  0, max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ default_value = 30, min =  0, max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 50, min =  0, max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 16, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 20, min =  0, max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 175, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 10, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 16, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.05f, min =  -0.20f, max =  0 } },
            };
            Bronze_dualaxes.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Wood", amount = 8, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Bronze", amount = 16, upgradeCost = 8 },
                    new RecipeIngredient { prefab = "LeatherScraps", amount = 4, upgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Bronze_dualaxes);

            // Iron Dualaxes
            ItemDefinition Iron_dualaxes = new ItemDefinition();
            Iron_dualaxes.Name = "Iron dualaxes";
            Iron_dualaxes.Category = ItemCategory.Axes;
            Iron_dualaxes.prefab = "VAIron_dualaxes";
            Iron_dualaxes.icon = "iron_dualaxes";
            Iron_dualaxes.craftedAt = "forge";
            Iron_dualaxes.craftAmount = 1;
            Iron_dualaxes.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 60, min =  0, max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ default_value = 50, min =  0, max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 50, min =  0, max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 21, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 20, min =  0, max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 175, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 12, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 18, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.05f, min =  -0.20f, max =  0 } },
            };
            Iron_dualaxes.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "ElderBark", amount = 8, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Iron", amount = 40, upgradeCost = 20 },
                    new RecipeIngredient { prefab = "LeatherScraps", amount = 4, upgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Iron_dualaxes);

            // Bonemass Axe
            ItemDefinition Bonemass_Axe = new ItemDefinition();
            Bonemass_Axe.Name = "Bonemasses Axe";
            Bonemass_Axe.Category = ItemCategory.Axes;
            Bonemass_Axe.prefab = "VABone_axe";
            Bonemass_Axe.icon = "bonemass_axe";
            Bonemass_Axe.craftedAt = "forge";
            Bonemass_Axe.craftAmount = 1;
            Bonemass_Axe.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 70, min =  0, max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ default_value = 30, min =  0, max =  200 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ default_value = 45, min =  0, max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 80, min =  0, max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 26, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 20, min =  0, max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 175, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 12, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 24, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.05f, min =  -0.20f, max =  0 } },
            };
            Bonemass_Axe.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "WitheredBone", amount = 6, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "Iron", amount = 20, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "Wishbone", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "TrophyBonemass", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "LeatherScraps", amount = 0, upgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Bonemass_Axe);


            // Bonemass Dualaxes
            ItemDefinition BonemassDualaxes = new ItemDefinition();
            BonemassDualaxes.Name = "Bonemasses Dualaxes";
            BonemassDualaxes.Category = ItemCategory.Axes;
            BonemassDualaxes.prefab = "VABone_dualaxes";
            BonemassDualaxes.icon = "bonerot_dualaxes";
            BonemassDualaxes.craftedAt = "forge";
            BonemassDualaxes.craftAmount = 1;
            BonemassDualaxes.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 70, min =  0, max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ default_value = 30, min =  0, max =  200 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ default_value = 45, min =  0, max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 80, min =  0, max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 26, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 20, min =  0, max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 175, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 12, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 19, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.05f, min =  -0.20f, max =  0 } },
            };
            BonemassDualaxes.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "WitheredBone", amount = 12, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "Iron", amount = 40, upgradeCost = 20 },
                    new RecipeIngredient { prefab = "Wishbone", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "TrophyBonemass", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "LeatherScraps", amount = 0, upgradeCost = 4 },
                }
            };
            Loader.AddDefinition(BonemassDualaxes);
            

            // Crystal Axe
            ItemDefinition Crystal_Axe = new ItemDefinition();
            Crystal_Axe.Name = "Crystal Axe";
            Crystal_Axe.Category = ItemCategory.Axes;
            Crystal_Axe.prefab = "VAcrystal_axe";
            Crystal_Axe.icon = "silver_axe_1h_icon";
            Crystal_Axe.craftedAt = "forge";
            Crystal_Axe.craftAmount = 1;
            Crystal_Axe.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 80, min =  0, max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.spirit, new ItemStatConfig{ default_value = 30, min =  0, max =  200 } },
                { ItemStat.spirit_per_level, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ default_value = 45, min =  0, max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 80, min =  0, max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 26, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 20, min =  0, max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 175, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 12, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 24, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.05f, min =  -0.20f, max =  0 } },
            };
            Crystal_Axe.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "ElderBark", amount = 15, upgradeCost = 4 },
                    new RecipeIngredient { prefab = "Silver", amount = 20, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "Crystal", amount = 8, upgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Crystal_Axe);

            // Crystal dual Axes
            ItemDefinition Crystal_dualaxes = new ItemDefinition();
            Crystal_dualaxes.Name = "Crystal dualaxes";
            Crystal_dualaxes.Category = ItemCategory.Axes;
            Crystal_dualaxes.prefab = "VACrystal_dualaxes";
            Crystal_dualaxes.icon = "crystal_dualaxes";
            Crystal_dualaxes.craftedAt = "forge";
            Crystal_dualaxes.craftAmount = 1;
            Crystal_dualaxes.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 80, min =  0, max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.spirit, new ItemStatConfig{ default_value = 30, min =  0, max =  200 } },
                { ItemStat.spirit_per_level, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ default_value = 50, min =  0, max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 50, min =  0, max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 30, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 20, min =  0, max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 175, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 12, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 20, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.05f, min =  -0.20f, max =  0 } },
            };
            Crystal_dualaxes.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "ElderBark", amount = 30, upgradeCost = 8 },
                    new RecipeIngredient { prefab = "Silver", amount = 50, upgradeCost = 20 },
                    new RecipeIngredient { prefab = "Crystal", amount = 16, upgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Crystal_dualaxes);

            // Moder Axe
            ItemDefinition Moder_Axe = new ItemDefinition();
            Moder_Axe.Name = "Dragonfrost Axe";
            Moder_Axe.Category = ItemCategory.Axes;
            Moder_Axe.prefab = "VAModer_Axe";
            Moder_Axe.icon = "moder_axe_1h";
            Moder_Axe.craftedAt = "forge";
            Moder_Axe.craftAmount = 1;
            Moder_Axe.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 80, min =  0, max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.frost, new ItemStatConfig{ default_value = 30, min =  0, max =  200 } },
                { ItemStat.frost_per_level, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ default_value = 45, min =  0, max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 80, min =  0, max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 26, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 20, min =  0, max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 175, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 12, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 24, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.05f, min =  -0.20f, max =  0 } },
            };
            Moder_Axe.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "DragonTear", amount = 10, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "TrophyDragonQueen", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Silver", amount = 15, upgradeCost = 15 },
                    new RecipeIngredient { prefab = "FineWood", amount = 8, upgradeCost = 4 },
                }
            };
            Loader.AddDefinition(Moder_Axe);

            // Moder Dualaxes
            ItemDefinition Moder_Dualaxes = new ItemDefinition();
            Moder_Dualaxes.Name = "Moder dualaxes";
            Moder_Dualaxes.Category = ItemCategory.Axes;
            Moder_Dualaxes.prefab = "VAModer_dualaxes";
            Moder_Dualaxes.icon = "moder_dualaxes";
            Moder_Dualaxes.craftedAt = "forge";
            Moder_Dualaxes.craftAmount = 1;
            Moder_Dualaxes.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 80, min =  0, max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.frost, new ItemStatConfig{ default_value = 30, min =  0, max =  200 } },
                { ItemStat.frost_per_level, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ default_value = 50, min =  0, max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 50, min =  0, max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 30, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 20, min =  0, max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 175, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 12, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 20, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.05f, min =  -0.20f, max =  0 } },
            };
            Moder_Dualaxes.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "DragonTear", amount = 10, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "TrophyDragonQueen", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Silver", amount = 30, upgradeCost = 30 },
                    new RecipeIngredient { prefab = "FineWood", amount = 16, upgradeCost = 8 },
                }
            };
            Loader.AddDefinition(Moder_Dualaxes);

            // Blackmetal Dual Axes
            ItemDefinition Blackmetal_dualaxes = new ItemDefinition();
            Blackmetal_dualaxes.Name = "Blackmetal dualaxes";
            Blackmetal_dualaxes.Category = ItemCategory.Axes;
            Blackmetal_dualaxes.prefab = "VABlackmetal_dualaxes";
            Blackmetal_dualaxes.icon = "blackmetal_dualaxes";
            Blackmetal_dualaxes.craftedAt = "forge";
            Blackmetal_dualaxes.craftAmount = 1;
            Blackmetal_dualaxes.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 100, min =  0, max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ default_value = 60, min =  0, max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 50, min =  0, max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 39, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 20, min =  0, max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 175, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 14, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 22, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.05f, min =  -0.20f, max =  0 } },
            };
            Blackmetal_dualaxes.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "BlackMetal", amount = 50, upgradeCost = 20 },
                    new RecipeIngredient { prefab = "FineWood", amount = 14, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "LinenThread", amount = 8, upgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Blackmetal_dualaxes);

            // Blackmetal Greataxe
            ItemDefinition Blackmetal_Greataxe = new ItemDefinition();
            Blackmetal_Greataxe.Name = "Blackmetal Greataxe (Legacy)";
            Blackmetal_Greataxe.Category = ItemCategory.Axes;
            Blackmetal_Greataxe.prefab = "VAblackmetal_2h_axe";
            Blackmetal_Greataxe.icon = "blackmetal_2h_axe";
            Blackmetal_Greataxe.craftedAt = "forge";
            Blackmetal_Greataxe.craftAmount = 1;
            Blackmetal_Greataxe.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 130, min =  0, max =  300 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ default_value = 60, min =  0, max =  300 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ default_value = 2.5f, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 70, min =  0, max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 52, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 70, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 20, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 10, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.15f, min =  -0.15f, max =  0 } },
            };
            Blackmetal_Greataxe.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "FineWood", amount = 10, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "BlackMetal", amount = 35, upgradeCost = 15 },
                    new RecipeIngredient { prefab = "LinenThread", amount = 5, upgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Blackmetal_Greataxe);

            // Jotun Dual Axes
            ItemDefinition Jotun_dualaxes = new ItemDefinition();
            Jotun_dualaxes.Name = "Jotun dualaxes";
            Jotun_dualaxes.Category = ItemCategory.Axes;
            Jotun_dualaxes.prefab = "VAJotunn_dualaxes";
            Jotun_dualaxes.icon = "jotun_dualaxes";
            Jotun_dualaxes.craftedAt = "blackforge";
            Jotun_dualaxes.craftAmount = 1;
            Jotun_dualaxes.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 120, min =  0, max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ default_value = 30, min =  0, max =  200 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ default_value = 80, min =  0, max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 50, min =  0, max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 48, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 20, min =  0, max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 175, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 15, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 24, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.05f, min =  -0.20f, max =  0 } },
            };
            Jotun_dualaxes.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Eitr", amount = 35, upgradeCost = 30 },
                    new RecipeIngredient { prefab = "Iron", amount = 25, upgradeCost = 20 },
                    new RecipeIngredient { prefab = "YggdrasilWood", amount = 14, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "Bilebag", amount = 6, upgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Jotun_dualaxes);

            // Jotun 2H Axe
            ItemDefinition Jotun_battleaxe = new ItemDefinition();
            Jotun_battleaxe.Name = "Jotun battleaxe";
            Jotun_battleaxe.Category = ItemCategory.Axes;
            Jotun_battleaxe.prefab = "VAJotunn_2h_axe";
            Jotun_battleaxe.icon = "jotun_2h_axe";
            Jotun_battleaxe.craftedAt = "blackforge";
            Jotun_battleaxe.craftAmount = 1;
            Jotun_battleaxe.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 140, min =  0, max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ default_value = 13, min =  0, max =  200 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ default_value = 90, min =  0, max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 50, min =  0, max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 72, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 20, min =  0, max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 175, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 22, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 11, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.05f, min =  -0.20f, max =  0 } },
            };
            Jotun_battleaxe.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Eitr", amount = 30, upgradeCost = 20 },
                    new RecipeIngredient { prefab = "Iron", amount = 20, upgradeCost = 15 },
                    new RecipeIngredient { prefab = "YggdrasilWood", amount = 14, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "Bilebag", amount = 6, upgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Jotun_battleaxe);

            // Jotunn halfblade
            ItemDefinition Jotun_halfblade = new ItemDefinition();
            Jotun_halfblade.Name = "Jotun halfblade";
            Jotun_halfblade.Category = ItemCategory.Axes;
            Jotun_halfblade.prefab = "VAJotunn_single_axe";
            Jotun_halfblade.icon = "jotunn_halfblade";
            Jotun_halfblade.craftedAt = "blackforge";
            Jotun_halfblade.craftAmount = 1;
            Jotun_halfblade.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 80, min =  0, max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ default_value = 40, min =  0, max =  200 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ default_value = 70, min =  0, max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ default_value = 3, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 50, min =  0, max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 48, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 20, min =  0, max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 175, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 16, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 32, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.05f, min =  -0.20f, max =  0 } },
            };
            Jotun_halfblade.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Eitr", amount = 10, upgradeCost = 1 },
                    new RecipeIngredient { prefab = "Iron", amount = 15, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "YggdrasilWood", amount = 5, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Bilebag", amount = 3, upgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Jotun_halfblade);

            // Antler Battleaxe
            ItemDefinition Eikthyrs_Greataxe = new ItemDefinition();
            Eikthyrs_Greataxe.Name = "Eikthyrs Greataxe";
            Eikthyrs_Greataxe.Category = ItemCategory.Axes;
            Eikthyrs_Greataxe.prefab = "VAAntler_greataxe";
            Eikthyrs_Greataxe.icon = "antler_greataxe";
            Eikthyrs_Greataxe.craftedAt = "piece_workbench";
            Eikthyrs_Greataxe.craftAmount = 1;
            Eikthyrs_Greataxe.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.blunt, new ItemStatConfig{ default_value = 10, min =  0, max =  200 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ default_value = 2, min =  0, max =  50 } },
                { ItemStat.slash, new ItemStatConfig{ default_value = 25, min =  0, max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 2, min =  0, max =  50 } },
                { ItemStat.lightning, new ItemStatConfig{ default_value = 10, min =  0, max =  200 } },
                { ItemStat.lightning_per_level, new ItemStatConfig{ default_value = 2, min =  0, max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ default_value = 30, min =  0, max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ default_value = 2.5f, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 70, min =  0, max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 18, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 70, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 14, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 7, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.15f, min =  -0.15f, max =  0 } },
            };
            Eikthyrs_Greataxe.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "FineWood", amount = 15, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Resin", amount = 30, upgradeCost = 15 },
                    new RecipeIngredient { prefab = "HardAntler", amount = 3, upgradeCost = 3 },
                    new RecipeIngredient { prefab = "TrophyEikthyr", amount = 1, upgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Eikthyrs_Greataxe);

            // Blackmetal Battleaxe
            ItemDefinition Blackmetal_Battleaxe = new ItemDefinition();
            Blackmetal_Battleaxe.Name = "Blackmetal Battleaxe";
            Blackmetal_Battleaxe.Category = ItemCategory.Axes;
            Blackmetal_Battleaxe.prefab = "VAblackmetal_battleaxe";
            Blackmetal_Battleaxe.icon = "blackmetal_battleaxe";
            Blackmetal_Battleaxe.craftedAt = "forge";
            Blackmetal_Battleaxe.craftAmount = 1;
            Blackmetal_Battleaxe.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 120, min =  0, max =  300 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ default_value = 60, min =  0, max =  300 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ default_value = 2.5f, min =  0, max =  50 } },
                { ItemStat.fire, new ItemStatConfig{ default_value = 20, min =  0, max =  160 } },
                { ItemStat.fire_per_level, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 70, min =  0, max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 52, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 70, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 22, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 10, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.15f, min =  -0.15f, max =  0 } },
            };
            Blackmetal_Battleaxe.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "FineWood", amount = 10, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "BlackMetal", amount = 35, upgradeCost = 15 },
                    new RecipeIngredient { prefab = "LinenThread", amount = 5, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "SurtlingCore", amount = 4, upgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Blackmetal_Battleaxe);

            // Flametal Battleaxe
            ItemDefinition Flametal_Battleaxe = new ItemDefinition();
            Flametal_Battleaxe.Name = "Flametal Battleaxe";
            Flametal_Battleaxe.Category = ItemCategory.Axes;
            Flametal_Battleaxe.prefab = "VAFlametalAxe_2h";
            Flametal_Battleaxe.icon = "flametal_battleaxe";
            Flametal_Battleaxe.craftedAt = "blackforge";
            Flametal_Battleaxe.craftAmount = 1;
            Flametal_Battleaxe.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 150, min =  0, max =  300 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ default_value = 90, min =  0, max =  300 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ default_value = 2.5f, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 70, min =  0, max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 78, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 70, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 28, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 14, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.15f, min =  -0.15f, max =  0 } },
            };
            Flametal_Battleaxe.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Blackwood", amount = 10, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "FlametalNew", amount = 20, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "CharredBone", amount = 20, upgradeCost = 15 },
                    new RecipeIngredient { prefab = "AskHide", amount = 4, upgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Flametal_Battleaxe);

            // Flametal Primal Battleaxe
            ItemDefinition Flametal_Primal_Battleaxe = new ItemDefinition();
            Flametal_Primal_Battleaxe.Name = "Flametal Primal Battleaxe";
            Flametal_Primal_Battleaxe.Category = ItemCategory.Axes;
            Flametal_Primal_Battleaxe.prefab = "VAFlametalAxe_primal_2h";
            Flametal_Primal_Battleaxe.icon = "flametal_battleaxe_primal";
            Flametal_Primal_Battleaxe.craftedAt = "blackforge";
            Flametal_Primal_Battleaxe.craftAmount = 1;
            Flametal_Primal_Battleaxe.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 150, min =  0, max =  300 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ default_value = 25, min =  0, max =  300 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ default_value = 3, min =  0, max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ default_value = 90, min =  0, max =  300 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ default_value = 2.5f, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 70, min =  0, max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 78, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 70, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 28, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 14, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.15f, min =  -0.15f, max =  0 } },
            };
            Flametal_Primal_Battleaxe.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "VAFlametalAxe_2h", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Blackwood", amount = 5, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "FlametalNew", amount = 10, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "GemstoneGreen", amount = 1, upgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Flametal_Primal_Battleaxe);

            // Flametal Lightning Battleaxe
            ItemDefinition Flametal_Lightning_Battleaxe = new ItemDefinition();
            Flametal_Lightning_Battleaxe.Name = "Flametal Lightning Battleaxe";
            Flametal_Lightning_Battleaxe.Category = ItemCategory.Axes;
            Flametal_Lightning_Battleaxe.prefab = "VAFlametalAxe_lightning_2h";
            Flametal_Lightning_Battleaxe.icon = "flametal_battleaxe_lightning";
            Flametal_Lightning_Battleaxe.craftedAt = "blackforge";
            Flametal_Lightning_Battleaxe.craftAmount = 1;
            Flametal_Lightning_Battleaxe.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 150, min =  0, max =  300 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.lightning, new ItemStatConfig{ default_value = 20, min =  0, max =  300 } },
                { ItemStat.lightning_per_level, new ItemStatConfig{ default_value = 2, min =  0, max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ default_value = 90, min =  0, max =  300 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ default_value = 2.5f, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 70, min =  0, max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 78, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 70, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 28, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 14, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.15f, min =  -0.15f, max =  0 } },
            };
            Flametal_Lightning_Battleaxe.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "VAFlametalAxe_2h", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Blackwood", amount = 5, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "FlametalNew", amount = 10, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "GemstoneBlue", amount = 1, upgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Flametal_Lightning_Battleaxe);

            // Flametal Blood Battleaxe
            ItemDefinition Flametal_Blood_Battleaxe = new ItemDefinition();
            Flametal_Blood_Battleaxe.Name = "Flametal Blood Battleaxe";
            Flametal_Blood_Battleaxe.Category = ItemCategory.Axes;
            Flametal_Blood_Battleaxe.prefab = "VAFlametalAxe_blood_2h";
            Flametal_Blood_Battleaxe.icon = "flametal_battleaxe_blood";
            Flametal_Blood_Battleaxe.craftedAt = "blackforge";
            Flametal_Blood_Battleaxe.craftAmount = 1;
            Flametal_Blood_Battleaxe.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 150, min =  0, max =  300 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ default_value = 90, min =  0, max =  300 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ default_value = 2.5f, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 70, min =  0, max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 78, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 70, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 28, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 14, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.15f, min =  -0.15f, max =  0 } },
            };
            Flametal_Blood_Battleaxe.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "VAFlametalAxe_2h", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Blackwood", amount = 5, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "FlametalNew", amount = 10, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "GemstoneRed", amount = 1, upgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Flametal_Blood_Battleaxe);

            // Flametal Axe
            ItemDefinition Flametal_Axe = new ItemDefinition();
            Flametal_Axe.Name = "Flametal Axe";
            Flametal_Axe.Category = ItemCategory.Axes;
            Flametal_Axe.prefab = "VAFlametal_Axe";
            Flametal_Axe.icon = "flametalAxeBase";
            Flametal_Axe.craftedAt = "blackforge";
            Flametal_Axe.craftAmount = 1;
            Flametal_Axe.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 140, min =  0, max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ default_value = 80, min =  0, max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ default_value = 3, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 50, min =  0, max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 84, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 20, min =  0, max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 175, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 18, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 36, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.05f, min =  -0.20f, max =  0 } },
            };
            Flametal_Axe.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "FlametalNew", amount = 12, upgradeCost = 6 },
                    new RecipeIngredient { prefab = "AskHide", amount = 4, upgradeCost = 1 },
                    new RecipeIngredient { prefab = "CharredBone", amount = 10, upgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Flametal_Axe);

            // Flametal Primal Axe
            ItemDefinition Flametal_Primal_Axe = new ItemDefinition();
            Flametal_Primal_Axe.Name = "Flametal Primal Axe";
            Flametal_Primal_Axe.Category = ItemCategory.Axes;
            Flametal_Primal_Axe.prefab = "VAFlametal_Axe_Primal";
            Flametal_Primal_Axe.icon = "flametal_axe_1h_primal";
            Flametal_Primal_Axe.craftedAt = "blackforge";
            Flametal_Primal_Axe.craftAmount = 1;
            Flametal_Primal_Axe.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 140, min =  0, max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ default_value = 25, min =  0, max =  300 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ default_value = 3, min =  0, max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ default_value = 80, min =  0, max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ default_value = 3, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 50, min =  0, max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 84, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 20, min =  0, max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 175, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 18, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 36, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.05f, min =  -0.20f, max =  0 } },
            };
            Flametal_Primal_Axe.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "FlametalNew", amount = 12, upgradeCost = 6 },
                    new RecipeIngredient { prefab = "GemstoneGreen", amount = 4, upgradeCost = 1 },
                    new RecipeIngredient { prefab = "CharredBone", amount = 10, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "VAFlametal_Axe", amount = 1, upgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Flametal_Primal_Axe);

            // Flametal Lightning Axe
            ItemDefinition Flametal_Lightning_Axe = new ItemDefinition();
            Flametal_Lightning_Axe.Name = "Flametal Lightning Axe";
            Flametal_Lightning_Axe.Category = ItemCategory.Axes;
            Flametal_Lightning_Axe.prefab = "VAFlametal_Axe_Lightning";
            Flametal_Lightning_Axe.icon = "flametal_axe_1h_lightning";
            Flametal_Lightning_Axe.craftedAt = "blackforge";
            Flametal_Lightning_Axe.craftAmount = 1;
            Flametal_Lightning_Axe.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 140, min =  0, max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.lightning, new ItemStatConfig{ default_value = 20, min =  0, max =  300 } },
                { ItemStat.lightning_per_level, new ItemStatConfig{ default_value = 2, min =  0, max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ default_value = 80, min =  0, max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ default_value = 3, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 50, min =  0, max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 84, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 20, min =  0, max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 175, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 18, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 36, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.05f, min =  -0.20f, max =  0 } },
            };
            Flametal_Lightning_Axe.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "FlametalNew", amount = 12, upgradeCost = 6 },
                    new RecipeIngredient { prefab = "GemstoneBlue", amount = 4, upgradeCost = 1 },
                    new RecipeIngredient { prefab = "CharredBone", amount = 10, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "VAFlametal_Axe", amount = 1, upgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Flametal_Lightning_Axe);

            // Flametal Blood Axe
            ItemDefinition Flametal_Blood_Axe = new ItemDefinition();
            Flametal_Blood_Axe.Name = "Flametal Blood Axe";
            Flametal_Blood_Axe.Category = ItemCategory.Axes;
            Flametal_Blood_Axe.prefab = "VAFlametal_Axe_Blood";
            Flametal_Blood_Axe.icon = "flametal_axe_1h_blood";
            Flametal_Blood_Axe.craftedAt = "blackforge";
            Flametal_Blood_Axe.craftAmount = 1;
            Flametal_Blood_Axe.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ default_value = 140, min =  0, max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ default_value = 80, min =  0, max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ default_value = 3, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 50, min =  0, max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 84, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 20, min =  0, max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 175, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 18, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 36, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.05f, min =  -0.20f, max =  0 } },
            };
            Flametal_Blood_Axe.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "FlametalNew", amount = 12, upgradeCost = 6 },
                    new RecipeIngredient { prefab = "GemstoneRed", amount = 4, upgradeCost = 1 },
                    new RecipeIngredient { prefab = "CharredBone", amount = 10, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "VAFlametal_Axe", amount = 1, upgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Flametal_Blood_Axe);
        }

        private void LoadHammers()
        {
            Logger.LogInfo("Loading Hammers");
            // Flametal Nature Sledge
            ItemDefinition Flametal_nature_sledge = new ItemDefinition();
            Flametal_nature_sledge.Name = "Flametal nature sledge";
            Flametal_nature_sledge.Category = ItemCategory.Hammers;
            Flametal_nature_sledge.prefab = "VAflametal_sledge_nature";
            Flametal_nature_sledge.icon = "flametal_sledge_nature";
            Flametal_nature_sledge.craftedAt = "blackforge";
            Flametal_nature_sledge.craftAmount = 1;
            Flametal_nature_sledge.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.blunt, new ItemStatConfig{ default_value = 165, min =  0, max =  300 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ default_value = 25, min =  0, max =  300 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ default_value = 3, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 210, min =  0, max =  400 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 64, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 50, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 100, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 24, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 30, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.15f, min =  -0.15f, max =  0 } },
            };
            Flametal_nature_sledge.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "VAflametal_sledge", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "FlametalNew", amount = 8, upgradeCost = 8 },
                    new RecipeIngredient { prefab = "Blackwood", amount = 5, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "GemstoneGreen", amount = 1, upgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Flametal_nature_sledge);

            // Flametal Lightning Sledge
            ItemDefinition Flametal_lightning_sledge = new ItemDefinition();
            Flametal_lightning_sledge.Name = "Flametal lightning sledge";
            Flametal_lightning_sledge.Category = ItemCategory.Hammers;
            Flametal_lightning_sledge.prefab = "VAflametal_sledge_lightning";
            Flametal_lightning_sledge.icon = "flametal_sledge_lightning";
            Flametal_lightning_sledge.craftedAt = "blackforge";
            Flametal_lightning_sledge.craftAmount = 1;
            Flametal_lightning_sledge.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.blunt, new ItemStatConfig{ default_value = 165, min =  0, max =  300 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.lightning, new ItemStatConfig{ default_value = 20, min =  0, max =  300 } },
                { ItemStat.lightning_per_level, new ItemStatConfig{ default_value = 2, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 210, min =  0, max =  400 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 64, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 50, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 100, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 24, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 30, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.15f, min =  -0.15f, max =  0 } },
            };
            Flametal_lightning_sledge.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "VAflametal_sledge", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "FlametalNew", amount = 8, upgradeCost = 8 },
                    new RecipeIngredient { prefab = "Blackwood", amount = 5, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "GemstoneBlue", amount = 1, upgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Flametal_lightning_sledge);

            // Flametal Blood Sledge
            ItemDefinition Flametal_blood_sledge = new ItemDefinition();
            Flametal_blood_sledge.Name = "Flametal blood sledge";
            Flametal_blood_sledge.Category = ItemCategory.Hammers;
            Flametal_blood_sledge.prefab = "VAflametal_sledge_blood";
            Flametal_blood_sledge.icon = "flametal_sledge_blood";
            Flametal_blood_sledge.craftedAt = "blackforge";
            Flametal_blood_sledge.craftAmount = 1;
            Flametal_blood_sledge.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.blunt, new ItemStatConfig{ default_value = 175, min =  0, max =  300 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ default_value = 10, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 210, min =  0, max =  400 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 64, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 50, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 100, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 24, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 30, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.15f, min =  -0.15f, max =  0 } },
            };
            Flametal_blood_sledge.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "VAflametal_sledge", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "FlametalNew", amount = 8, upgradeCost = 8 },
                    new RecipeIngredient { prefab = "Blackwood", amount = 5, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "GemstoneRed", amount = 1, upgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Flametal_blood_sledge);

            // Flametal Sledge
            ItemDefinition Flametal_sledge = new ItemDefinition();
            Flametal_sledge.Name = "Flametal sledge";
            Flametal_sledge.Category = ItemCategory.Hammers;
            Flametal_sledge.prefab = "VAflametal_sledge";
            Flametal_sledge.icon = "flametal_sledge";
            Flametal_sledge.craftedAt = "blackforge";
            Flametal_sledge.craftAmount = 1;
            Flametal_sledge.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.blunt, new ItemStatConfig{ default_value = 165, min =  0, max =  300 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 210, min =  0, max =  400 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 64, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 50, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 100, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 24, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 30, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.15f, min =  -0.15f, max =  0 } },
            };
            Flametal_sledge.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "FlametalNew", amount = 30, upgradeCost = 15 },
                    new RecipeIngredient { prefab = "Iron", amount = 4, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Eitr", amount = 6, upgradeCost = 3 },
                    new RecipeIngredient { prefab = "Blackwood", amount = 12, upgradeCost = 6 },
                }
            };
            Loader.AddDefinition(Flametal_sledge);

            // Blackmarble mace
            ItemDefinition Blackmarble_mace = new ItemDefinition();
            Blackmarble_mace.Name = "Blackmarble mace";
            Blackmarble_mace.Category = ItemCategory.Hammers;
            Blackmarble_mace.prefab = "VAmistland_mace";
            Blackmarble_mace.icon = "mist_mace";
            Blackmarble_mace.craftedAt = "blackforge";
            Blackmarble_mace.craftAmount = 1;
            Blackmarble_mace.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.blunt, new ItemStatConfig{ default_value = 115, min =  0, max =  300 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 100, min =  0, max =  400 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 48, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 20, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 100, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 15, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 28, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.05f, min =  -0.05f, max =  0 } },
            };
            Blackmarble_mace.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "YggdrasilWood", amount = 6, upgradeCost = 4 },
                    new RecipeIngredient { prefab = "Bronze", amount = 10, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "Eitr", amount = 8, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "BlackMarble", amount = 20, upgradeCost = 10 },
                }
            };
            Loader.AddDefinition(Blackmarble_mace);

            // Blackmetal Sledge
            ItemDefinition Blackmetal_Sledge = new ItemDefinition();
            Blackmetal_Sledge.Name = "Blackmetal Sledge";
            Blackmetal_Sledge.Category = ItemCategory.Hammers;
            Blackmetal_Sledge.prefab = "VAblackmetal_sledge";
            Blackmetal_Sledge.icon = "blackmetal_hammer";
            Blackmetal_Sledge.craftedAt = "forge";
            Blackmetal_Sledge.craftAmount = 1;
            Blackmetal_Sledge.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.blunt, new ItemStatConfig{ default_value = 120, min =  0, max =  300 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.lightning, new ItemStatConfig{ default_value = 20, min =  0, max =  120 } },
                { ItemStat.lightning_per_level, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 100, min =  0, max =  400 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 49, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 50, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 20, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 40, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.15f, min =  -0.15f, max =  0 } },
            };
            Blackmetal_Sledge.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "FineWood", amount = 10, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "BlackMetal", amount = 30, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "LinenThread", amount = 5, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Thunderstone", amount = 4, upgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Blackmetal_Sledge);

            // Elder Sledge
            ItemDefinition Elders_Rock = new ItemDefinition();
            Elders_Rock.Name = "Elders Rock";
            Elders_Rock.Category = ItemCategory.Hammers;
            Elders_Rock.prefab = "VAElderHammer";
            Elders_Rock.icon = "elder_hammer";
            Elders_Rock.craftedAt = "forge";
            Elders_Rock.craftAmount = 1;
            Elders_Rock.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.blunt, new ItemStatConfig{ default_value = 35, min =  0, max =  300 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.spirit, new ItemStatConfig{ default_value = 10, min =  0, max =  99 } },
                { ItemStat.spirit_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 100, min =  0, max =  400 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 22, min =  0, max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 50, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 12, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 22, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.15f, min =  -0.15f, max =  0 } },
            };
            Elders_Rock.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Bronze", amount = 4, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "Stone", amount = 30, upgradeCost = 15 },
                    new RecipeIngredient { prefab = "CryptKey", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "TrophyTheElder", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "RoundLog", amount = 0, upgradeCost = 8 },
                }
            };
            Loader.AddDefinition(Elders_Rock);

            // Bronze sledge
            ItemDefinition Bronze_Sledge = new ItemDefinition();
            Bronze_Sledge.Name = "Bronze Sledge";
            Bronze_Sledge.Category = ItemCategory.Hammers;
            Bronze_Sledge.prefab = "VABronzeSledge";
            Bronze_Sledge.icon = "bronze_sledge";
            Bronze_Sledge.craftedAt = "forge";
            Bronze_Sledge.craftAmount = 1;
            Bronze_Sledge.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.blunt, new ItemStatConfig{ default_value = 35, min =  0, max =  300 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 100, min =  0, max =  400 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 22, min =  0, max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 12, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 22, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.15f, min =  -0.15f, max =  0 } },
            };
            Bronze_Sledge.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Bronze", amount = 8, upgradeCost = 4 },
                    new RecipeIngredient { prefab = "Stone", amount = 25, upgradeCost = 15 },
                    new RecipeIngredient { prefab = "TrollHide", amount = 6, upgradeCost = 3 },
                    new RecipeIngredient { prefab = "RoundLog", amount = 4, upgradeCost = 4 },
                }
            };
            Loader.AddDefinition(Bronze_Sledge);

            // Bonemass Warhammer
            ItemDefinition Bonemasses_Rage = new ItemDefinition();
            Bonemasses_Rage.Name = "Bonemasses Rage";
            Bonemasses_Rage.Category = ItemCategory.Hammers;
            Bonemasses_Rage.prefab = "VABonemassWarhammer";
            Bonemasses_Rage.icon = "bonemass_warhammer";
            Bonemasses_Rage.craftedAt = "forge";
            Bonemasses_Rage.craftAmount = 1;
            Bonemasses_Rage.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.blunt, new ItemStatConfig{ default_value = 70, min =  0, max =  300 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ default_value = 20, min =  0, max =  99 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 100, min =  0, max =  400 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 31, min =  0, max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 14, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 24, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.15f, min =  -0.15f, max =  0 } },
            };
            Bonemasses_Rage.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "WitheredBone", amount = 10, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "Iron", amount = 30, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "Wishbone", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "TrophyBonemass", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "ElderBark", amount = 0, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "LeatherScraps", amount = 0, upgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Bonemasses_Rage);

            // Silver sledge
            ItemDefinition Silver_Sledge = new ItemDefinition();
            Silver_Sledge.Name = "Silver Sledge";
            Silver_Sledge.Category = ItemCategory.Hammers;
            Silver_Sledge.prefab = "VASilverSledge";
            Silver_Sledge.icon = "silver_sledge";
            Silver_Sledge.craftedAt = "forge";
            Silver_Sledge.craftAmount = 1;
            Silver_Sledge.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.blunt, new ItemStatConfig{ default_value = 85, min =  0, max =  300 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.spirit, new ItemStatConfig{ default_value = 25, min =  0, max =  99 } },
                { ItemStat.spirit_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 100, min =  0, max =  400 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 31, min =  0, max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 15, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 24, min =  1, max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.15f, min =  -0.15f, max =  0 } },
            };
            Silver_Sledge.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "RoundLog", amount = 10, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "Silver", amount = 30, upgradeCost = 15 },
                    new RecipeIngredient { prefab = "YmirRemains", amount = 4, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "TrophyFenring", amount = 1, upgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Silver_Sledge);
        }

        private void LoadAtgeirs()
        {
            Logger.LogInfo("Loading Atgeirs");
            // Flint Atgeir
            ItemDefinition Flint_Atgeir = new ItemDefinition();
            Flint_Atgeir.Name = "Flint Atgeir";
            Flint_Atgeir.Category = ItemCategory.Atgeirs;
            Flint_Atgeir.prefab = "VAAtgeir_Flint";
            Flint_Atgeir.icon = "flint_atgeir";
            Flint_Atgeir.craftedAt = "piece_workbench";
            Flint_Atgeir.craftAmount = 1;
            Flint_Atgeir.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ default_value = 25, min =  0, max =  90 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 30, min =  0, max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 11, min =  0, max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 125, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 10, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 20, min =  1, max =  50 } },
            };
            Flint_Atgeir.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Wood", amount = 10, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Flint", amount = 6, upgradeCost = 3 },
                    new RecipeIngredient { prefab = "LeatherScraps", amount = 0, upgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Flint_Atgeir);

            // Antler Atgeir
            ItemDefinition Eikthyrs_Atgeir = new ItemDefinition();
            Eikthyrs_Atgeir.Name = "Eikthyrs Atgeir";
            Eikthyrs_Atgeir.Category = ItemCategory.Atgeirs;
            Eikthyrs_Atgeir.prefab = "VAatgeir_antler";
            Eikthyrs_Atgeir.icon = "antler_atgeir";
            Eikthyrs_Atgeir.craftedAt = "piece_workbench";
            Eikthyrs_Atgeir.craftAmount = 1;
            Eikthyrs_Atgeir.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ default_value = 35, min =  0, max =  90 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.lightning, new ItemStatConfig{ default_value = 10, min =  0, max =  50 } },
                { ItemStat.lightning_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 30, min =  0, max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 14, min =  0, max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 175, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 12, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 24, min =  1, max =  50 } },
            };
            Eikthyrs_Atgeir.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "FineWood", amount = 15, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Resin", amount = 30, upgradeCost = 15 },
                    new RecipeIngredient { prefab = "HardAntler", amount = 3, upgradeCost = 3 },
                    new RecipeIngredient { prefab = "TrophyEikthyr", amount = 1, upgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Eikthyrs_Atgeir);

            // Abyssal Atgeir
            ItemDefinition Abyssal_Atgeir = new ItemDefinition();
            Abyssal_Atgeir.Name = "Abyssal Atgeir";
            Abyssal_Atgeir.Category = ItemCategory.Atgeirs;
            Abyssal_Atgeir.prefab = "VAAtgeirChitin";
            Abyssal_Atgeir.icon = "chitin_heavy_atgeir_small2";
            Abyssal_Atgeir.craftedAt = "piece_workbench";
            Abyssal_Atgeir.craftAmount = 1;
            Abyssal_Atgeir.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ default_value = 35, min =  0, max =  140 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 2, min =  0, max =  50 } },
                { ItemStat.blunt, new ItemStatConfig{ default_value = 20, min =  0, max =  120 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ default_value = 4, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 30, min =  0, max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 21, min =  0, max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 175, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 14, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 28, min =  1, max =  50 } },
            };
            Abyssal_Atgeir.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "FineWood", amount = 10, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Chitin", amount = 30, upgradeCost = 15 },
                    new RecipeIngredient { prefab = "DeerHide", amount = 2, upgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Abyssal_Atgeir);

            // Silver Atgeir
            ItemDefinition Silver_Atgeir = new ItemDefinition();
            Silver_Atgeir.Name = "Silver Atgeir";
            Silver_Atgeir.Category = ItemCategory.Atgeirs;
            Silver_Atgeir.prefab = "VASilverAtgeir";
            Silver_Atgeir.icon = "silver_atgeir";
            Silver_Atgeir.craftedAt = "forge";
            Silver_Atgeir.craftAmount = 1;
            Silver_Atgeir.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ default_value = 85, min =  0, max =  250 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.spirit, new ItemStatConfig{ default_value = 30, min =  0, max =  120 } },
                { ItemStat.spirit_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 30, min =  0, max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 40, min =  0, max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 175, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 16, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 32, min =  1, max =  50 } },
            };
            Silver_Atgeir.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Wood", amount = 10, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Silver", amount = 25, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "Iron", amount = 4, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "LeatherScraps", amount = 3, upgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Silver_Atgeir);

            // Yagluth Atgeir
            ItemDefinition Yagluths_Reach = new ItemDefinition();
            Yagluths_Reach.Name = "Yagluths Reach";
            Yagluths_Reach.Category = ItemCategory.Atgeirs;
            Yagluths_Reach.prefab = "VAYagluthAtgeir";
            Yagluths_Reach.icon = "yagluth_atgeir";
            Yagluths_Reach.craftedAt = "forge";
            Yagluths_Reach.craftAmount = 1;
            Yagluths_Reach.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ default_value = 105, min =  0, max =  250 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 3, min =  0, max =  50 } },
                { ItemStat.fire, new ItemStatConfig{ default_value = 25, min =  0, max =  120 } },
                { ItemStat.fire_per_level, new ItemStatConfig{ default_value = 3, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 30, min =  0, max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 52, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 175, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 18, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 36, min =  1, max =  50 } },
            };
            Yagluths_Reach.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "BlackMetal", amount = 10, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Iron", amount = 4, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "YagluthDrop", amount = 2, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "TrophyGoblinKing", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Tar", amount = 0, upgradeCost = 3 },
                    new RecipeIngredient { prefab = "LinenThread", amount = 0, upgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Yagluths_Reach);

            // Meteor atgeir
            ItemDefinition Flametal_Atgeir = new ItemDefinition();
            Flametal_Atgeir.Name = "Flametal Atgeir";
            Flametal_Atgeir.Category = ItemCategory.Atgeirs;
            Flametal_Atgeir.prefab = "VAMeteorAtgeir";
            Flametal_Atgeir.icon = "meteor_atgeir";
            Flametal_Atgeir.craftedAt = "blackforge";
            Flametal_Atgeir.craftAmount = 1;
            Flametal_Atgeir.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ default_value = 145, min =  0, max =  300 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 30, min =  0, max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 64, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 175, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 22, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 42, min =  1, max =  50 } },
            };
            Flametal_Atgeir.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "FlametalNew", amount = 15, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "Iron", amount = 4, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "Blackwood", amount = 10, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "MorgenSinew", amount = 2, upgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Flametal_Atgeir);

            // Meteor primal atgeir
            ItemDefinition Flametal_primal_Atgeir = new ItemDefinition();
            Flametal_primal_Atgeir.Name = "Flametal primal Atgeir";
            Flametal_primal_Atgeir.Category = ItemCategory.Atgeirs;
            Flametal_primal_Atgeir.prefab = "VAMeteorAtgeir_nature";
            Flametal_primal_Atgeir.icon = "meteor_atgeir_nature";
            Flametal_primal_Atgeir.craftedAt = "blackforge";
            Flametal_primal_Atgeir.craftAmount = 1;
            Flametal_primal_Atgeir.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ default_value = 145, min =  0, max =  300 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ default_value = 10, min =  0, max =  300 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 30, min =  0, max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 64, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 175, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 22, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 42, min =  1, max =  50 } },
            };
            Flametal_primal_Atgeir.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "VAMeteorAtgeir", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "FlametalNew", amount = 8, upgradeCost = 8 },
                    new RecipeIngredient { prefab = "Blackwood", amount = 5, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "GemstoneGreen", amount = 1, upgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Flametal_primal_Atgeir);

            // Meteor lightning atgeir
            ItemDefinition Flametal_lightning_Atgeir = new ItemDefinition();
            Flametal_lightning_Atgeir.Name = "Flametal lightning Atgeir";
            Flametal_lightning_Atgeir.Category = ItemCategory.Atgeirs;
            Flametal_lightning_Atgeir.prefab = "VAMeteorAtgeir_lightning";
            Flametal_lightning_Atgeir.icon = "meteor_atgeir_lightning";
            Flametal_lightning_Atgeir.craftedAt = "blackforge";
            Flametal_lightning_Atgeir.craftAmount = 1;
            Flametal_lightning_Atgeir.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ default_value = 145, min =  0, max =  300 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.lightning, new ItemStatConfig{ default_value = 10, min =  0, max =  300 } },
                { ItemStat.lightning_per_level, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 30, min =  0, max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 64, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 175, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 22, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 42, min =  1, max =  50 } },
            };
            Flametal_lightning_Atgeir.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "VAMeteorAtgeir", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "FlametalNew", amount = 8, upgradeCost = 8 },
                    new RecipeIngredient { prefab = "Blackwood", amount = 5, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "GemstoneBlue", amount = 1, upgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Flametal_lightning_Atgeir);

            // Meteor blood atgeir
            ItemDefinition Flametal_blood_Atgeir = new ItemDefinition();
            Flametal_blood_Atgeir.Name = "Flametal blood Atgeir";
            Flametal_blood_Atgeir.Category = ItemCategory.Atgeirs;
            Flametal_blood_Atgeir.prefab = "VAMeteorAtgeir_blood";
            Flametal_blood_Atgeir.icon = "meteor_atgeir_blood";
            Flametal_blood_Atgeir.craftedAt = "blackforge";
            Flametal_blood_Atgeir.craftAmount = 1;
            Flametal_blood_Atgeir.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ default_value = 145, min =  0, max =  300 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 30, min =  0, max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 52, min =  0, max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 175, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 22, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 42, min =  1, max =  50 } },
            };
            Flametal_blood_Atgeir.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "VAMeteorAtgeir", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "FlametalNew", amount = 8, upgradeCost = 8 },
                    new RecipeIngredient { prefab = "Blackwood", amount = 5, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "GemstoneRed", amount = 1, upgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Flametal_blood_Atgeir);
        }

        private void LoadShields()
        {
            Logger.LogInfo("Loading Shields");
            // Serpentscale Buckler
            ItemDefinition Serpent_Scale_Buckler = new ItemDefinition();
            Serpent_Scale_Buckler.Name = "Serpent Scale Buckler";
            Serpent_Scale_Buckler.Category = ItemCategory.Shields;
            Serpent_Scale_Buckler.prefab = "VAserpent_buckler";
            Serpent_Scale_Buckler.icon = "serpentscale_shield2";
            Serpent_Scale_Buckler.craftedAt = "forge";
            Serpent_Scale_Buckler.craftAmount = 1;
            Serpent_Scale_Buckler.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 48, min =  0, max =  120 } },
                { ItemStat.block_armor_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 40, min =  0, max =  120 } },
                { ItemStat.parry, new ItemStatConfig{ default_value = 2.5f, min =  0, max =  3 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 250, min =  0, max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.05f, min =  -0.30f, max =  0 } },
            };
            Serpent_Scale_Buckler.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "FineWood", amount = 8, upgradeCost = 8 },
                    new RecipeIngredient { prefab = "Iron", amount = 2, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "SerpentScale", amount = 6, upgradeCost = 3 },
                }
            };
            Serpent_Scale_Buckler.damageMods = new Dictionary<HitData.DamageType, HitCustomDamageMod>
            {
                { HitData.DamageType.Pierce, new HitCustomDamageMod { damageModifier = HitData.DamageModifier.Resistant } }
            };
            Loader.AddDefinition(Serpent_Scale_Buckler);

            // Elder Round Shield
            ItemDefinition Elders_Bulwark = new ItemDefinition();
            Elders_Bulwark.Name = "Elders Bulwark";
            Elders_Bulwark.Category = ItemCategory.Shields;
            Elders_Bulwark.prefab = "VAElderRoundShield";
            Elders_Bulwark.icon = "elder_roundshield";
            Elders_Bulwark.craftedAt = "forge";
            Elders_Bulwark.craftAmount = 1;
            Elders_Bulwark.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 28, min =  0, max =  120 } },
                { ItemStat.block_armor_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 30, min =  0, max =  120 } },
                { ItemStat.block_force_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  30 } },
                { ItemStat.parry, new ItemStatConfig{ default_value = 1.5f, min =  0, max =  3 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 250, min =  0, max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.05f, min =  -0.30f, max =  0 } },
            };
            Elders_Bulwark.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Wood", amount = 16, upgradeCost = 8 },
                    new RecipeIngredient { prefab = "Bronze", amount = 8, upgradeCost = 4 },
                    new RecipeIngredient { prefab = "CryptKey", amount = 1, upgradeCost = 1 },
                    new RecipeIngredient { prefab = "TrophyTheElder", amount = 1, upgradeCost = 1 },
                }
            };
            Elders_Bulwark.damageMods = new Dictionary<HitData.DamageType, HitCustomDamageMod>
            {
                { HitData.DamageType.Blunt, new HitCustomDamageMod { damageModifier = HitData.DamageModifier.Resistant } }
            };
            Loader.AddDefinition(Elders_Bulwark);

            // Moder Round Shield
            ItemDefinition Moders_Roundshield = new ItemDefinition();
            Moders_Roundshield.Name = "Moders Roundshield";
            Moders_Roundshield.Category = ItemCategory.Shields;
            Moders_Roundshield.prefab = "VAModer_RoundShield";
            Moders_Roundshield.icon = "moder_roundshield";
            Moders_Roundshield.craftedAt = "forge";
            Moders_Roundshield.craftAmount = 1;
            Moders_Roundshield.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 62, min =  0, max =  120 } },
                { ItemStat.block_armor_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 40, min =  0, max =  120 } },
                { ItemStat.block_force_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  30 } },
                { ItemStat.parry, new ItemStatConfig{ default_value = 1.5f, min =  0, max =  3 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 250, min =  0, max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.05f, min =  -0.30f, max =  0 } },
            };
            Moders_Roundshield.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "FineWood", amount = 24, upgradeCost = 12 },
                    new RecipeIngredient { prefab = "Silver", amount = 16, upgradeCost = 8 },
                    new RecipeIngredient { prefab = "DragonTear", amount = 10, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "TrophyDragonQueen", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Obsidian", amount = 0, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "JuteRed", amount = 0, upgradeCost = 2 },
                }
            };
            Moders_Roundshield.damageMods = new Dictionary<HitData.DamageType, HitCustomDamageMod>
            {
                { HitData.DamageType.Frost, new HitCustomDamageMod { damageModifier = HitData.DamageModifier.Resistant } }
            };
            Loader.AddDefinition(Moders_Roundshield);

            // Moder Tower Shield
            ItemDefinition Moders_Shield = new ItemDefinition();
            Moders_Shield.Name = "Moders Shield";
            Moders_Shield.Category = ItemCategory.Shields;
            Moders_Shield.prefab = "VAModer_shield";
            Moders_Shield.icon = "modershiled_v2";
            Moders_Shield.craftedAt = "forge";
            Moders_Shield.craftAmount = 1;
            Moders_Shield.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 100, min =  0, max =  180 } },
                { ItemStat.block_armor_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 120, min =  0, max =  200 } },
                { ItemStat.block_force_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  30 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 250, min =  0, max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.15f, min =  -0.15f, max =  0 } },
            };
            Moders_Shield.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "FineWood", amount = 24, upgradeCost = 12 },
                    new RecipeIngredient { prefab = "Silver", amount = 16, upgradeCost = 8 },
                    new RecipeIngredient { prefab = "DragonTear", amount = 10, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "TrophyDragonQueen", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Obsidian", amount = 0, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "JuteRed", amount = 0, upgradeCost = 2 },
                }
            };
            Moders_Shield.damageMods = new Dictionary<HitData.DamageType, HitCustomDamageMod>
            {
                { HitData.DamageType.Frost, new HitCustomDamageMod { damageModifier = HitData.DamageModifier.Resistant } }
            };
            Loader.AddDefinition(Moders_Shield);

            // Silver Wolf tower shield
            ItemDefinition Silver_Wolf_Towershield = new ItemDefinition();
            Silver_Wolf_Towershield.Name = "Silver Wolf Towershield";
            Silver_Wolf_Towershield.Category = ItemCategory.Shields;
            Silver_Wolf_Towershield.prefab = "VAsilver_tower";
            Silver_Wolf_Towershield.icon = "silver_tower_shield";
            Silver_Wolf_Towershield.craftedAt = "forge";
            Silver_Wolf_Towershield.craftAmount = 1;
            Silver_Wolf_Towershield.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 78, min =  0, max =  120 } },
                { ItemStat.block_armor_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 120, min =  0, max =  200 } },
                { ItemStat.block_force_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  30 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.15f, min =  -0.15f, max =  0 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 250, min =  0, max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
            };
            Silver_Wolf_Towershield.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "FineWood", amount = 15, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "Silver", amount = 10, upgradeCost = 6 },
                    new RecipeIngredient { prefab = "TrophyUlv", amount = 1, upgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Silver_Wolf_Towershield);

            // Dverger tower shield
            ItemDefinition dverger_tower_shield = new ItemDefinition();
            dverger_tower_shield.Name = "Dverger Towershield";
            dverger_tower_shield.Category = ItemCategory.Shields;
            dverger_tower_shield.prefab = "VAdverger_tower";
            dverger_tower_shield.icon = "dverger_towershield";
            dverger_tower_shield.craftedAt = "blackforge";
            dverger_tower_shield.craftAmount = 1;
            dverger_tower_shield.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 122, min =  0, max =  200 } },
                { ItemStat.block_armor_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.block_force, new ItemStatConfig{ default_value = 150, min =  0, max =  200 } },
                { ItemStat.block_force_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  30 } },
                { ItemStat.movement_speed, new ItemStatConfig{ default_value = -0.15f, min =  -0.15f, max =  0 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
            };
            dverger_tower_shield.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "BlackMarble", amount = 20, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "YggdrasilWood", amount = 12, upgradeCost = 6 },
                    new RecipeIngredient { prefab = "BlackCore", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Copper", amount = 14, upgradeCost = 10 },
                }
            };
            Loader.AddDefinition(dverger_tower_shield);
        }

        private void LoadDaggers()
        {
            Logger.LogInfo("Loading Daggers");
            // Blackmetal (mistlands) 1H Daggers
            ItemDefinition Hati_Knife = new ItemDefinition();
            Hati_Knife.Name = "Hati Knife";
            Hati_Knife.Category = ItemCategory.Knives;
            Hati_Knife.prefab = "VAdagger_blackmetal_mistlands";
            Hati_Knife.icon = "hatti_knife";
            Hati_Knife.craftedAt = "blackforge";
            Hati_Knife.craftAmount = 1;
            Hati_Knife.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 4, min =  0, max =  48 } },
                { ItemStat.slash, new ItemStatConfig{ default_value = 39, min =  0, max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.pierce, new ItemStatConfig{ default_value = 39, min =  0, max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 10, min =  0, max =  40 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 14, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 38, min =  1, max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
            };
            Hati_Knife.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "FineWood", amount = 4, upgradeCost = 4 },
                    new RecipeIngredient { prefab = "BlackMetal", amount = 8, upgradeCost = 4 },
                    new RecipeIngredient { prefab = "Iron", amount = 2, upgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Hati_Knife);

            // Blackmetal 2H Daggers
            ItemDefinition Blackmetal_knives = new ItemDefinition();
            Blackmetal_knives.Name = "Blackmetal knives";
            Blackmetal_knives.Category = ItemCategory.Knives;
            Blackmetal_knives.prefab = "VAknife_blackmetal";
            Blackmetal_knives.icon = "2h_blackmetal_knives";
            Blackmetal_knives.craftedAt = "forge";
            Blackmetal_knives.craftAmount = 1;
            Blackmetal_knives.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 20, min =  0, max =  48 } },
                { ItemStat.slash, new ItemStatConfig{ default_value = 39, min =  0, max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.pierce, new ItemStatConfig{ default_value = 39, min =  0, max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 10, min =  0, max =  40 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 12, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 12, min =  1, max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
            };
            Blackmetal_knives.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "FineWood", amount = 8, upgradeCost = 4 },
                    new RecipeIngredient { prefab = "BlackMetal", amount = 20, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "LinenThread", amount = 10, upgradeCost = 5 },
                }
            };
            Loader.AddDefinition(Blackmetal_knives);

            // Flint 2H Daggers
            ItemDefinition Flint_knives = new ItemDefinition();
            Flint_knives.Name = "Flint knives";
            Flint_knives.Category = ItemCategory.Knives;
            Flint_knives.prefab = "VADagger_Flint_2h";
            Flint_knives.icon = "2h_flint_knives";
            Flint_knives.craftedAt = "piece_workbench";
            Flint_knives.craftAmount = 1;
            Flint_knives.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 4, min =  0, max =  48 } },
                { ItemStat.slash, new ItemStatConfig{ default_value = 12, min =  0, max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.pierce, new ItemStatConfig{ default_value = 12, min =  0, max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 10, min =  0, max =  40 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 4, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 12, min =  1, max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
            };
            Flint_knives.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Wood", amount = 4, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Flint", amount = 6, upgradeCost = 3 },
                    new RecipeIngredient { prefab = "LeatherScraps", amount = 2, upgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Flint_knives);

            // Antler 1H Daggers
            ItemDefinition Eikthyrs_knife = new ItemDefinition();
            Eikthyrs_knife.Name = "Eikthyrs knife";
            Eikthyrs_knife.Category = ItemCategory.Knives;
            Eikthyrs_knife.prefab = "VAAntler_dagger";
            Eikthyrs_knife.icon = "antler_dagger";
            Eikthyrs_knife.craftedAt = "piece_workbench";
            Eikthyrs_knife.craftAmount = 1;
            Eikthyrs_knife.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 2, min =  0, max =  48 } },
                { ItemStat.slash, new ItemStatConfig{ default_value = 8, min =  0, max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.pierce, new ItemStatConfig{ default_value = 8, min =  0, max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.lightning, new ItemStatConfig{ default_value = 4, min =  0, max =  99 } },
                { ItemStat.lightning_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 10, min =  0, max =  30 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 6, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 18, min =  1, max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
            };
            Eikthyrs_knife.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "FineWood", amount = 3, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Resin", amount = 16, upgradeCost = 8 },
                    new RecipeIngredient { prefab = "HardAntler", amount = 3, upgradeCost = 3 },
                    new RecipeIngredient { prefab = "TrophyEikthyr", amount = 1, upgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Eikthyrs_knife);

            // Copper 2H Daggers
            ItemDefinition Rascals_knives = new ItemDefinition();
            Rascals_knives.Name = "Rascals knives";
            Rascals_knives.Category = ItemCategory.Knives;
            Rascals_knives.prefab = "VAdagger_copper_2h";
            Rascals_knives.icon = "copper_knives_2h";
            Rascals_knives.craftedAt = "forge";
            Rascals_knives.craftAmount = 1;
            Rascals_knives.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 8, min =  0, max =  48 } },
                { ItemStat.slash, new ItemStatConfig{ default_value = 20, min =  0, max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.pierce, new ItemStatConfig{ default_value = 20, min =  0, max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 10, min =  0, max =  40 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 6, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 18, min =  1, max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
            };
            Rascals_knives.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "RoundLog", amount = 4, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Copper", amount = 16, upgradeCost = 4 },
                    new RecipeIngredient { prefab = "LeatherScraps", amount = 4, upgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Rascals_knives);

            // Abyssal 2H Daggers
            ItemDefinition Abyssal_knives = new ItemDefinition();
            Abyssal_knives.Name = "Abyssal knives";
            Abyssal_knives.Category = ItemCategory.Knives;
            Abyssal_knives.prefab = "VAdagger_chitin_2h";
            Abyssal_knives.icon = "chitin_knives";
            Abyssal_knives.craftedAt = "piece_workbench";
            Abyssal_knives.craftAmount = 1;
            Abyssal_knives.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 12, min =  0, max =  48 } },
                { ItemStat.slash, new ItemStatConfig{ default_value = 24, min =  0, max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.pierce, new ItemStatConfig{ default_value = 0, min =  0, max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
                { ItemStat.blunt, new ItemStatConfig{ default_value = 24, min =  0, max =  99 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 10, min =  0, max =  40 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 8, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 24, min =  1, max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
            };
            Abyssal_knives.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "FineWood", amount = 6, upgradeCost = 4 },
                    new RecipeIngredient { prefab = "Chitin", amount = 32, upgradeCost = 12 },
                    new RecipeIngredient { prefab = "LeatherScraps", amount = 8, upgradeCost = 4 },
                }
            };
            Loader.AddDefinition(Abyssal_knives);

            // Iron 2H Daggers
            ItemDefinition Rogue_knives = new ItemDefinition();
            Rogue_knives.Name = "Rogue knives";
            Rogue_knives.Category = ItemCategory.Knives;
            Rogue_knives.prefab = "VAdagger_iron_2h";
            Rogue_knives.icon = "iron_dagger_2h";
            Rogue_knives.craftedAt = "forge";
            Rogue_knives.craftAmount = 1;
            Rogue_knives.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 12, min =  0, max =  48 } },
                { ItemStat.slash, new ItemStatConfig{ default_value = 25, min =  0, max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.pierce, new ItemStatConfig{ default_value = 25, min =  0, max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 10, min =  0, max =  40 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 8, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 24, min =  1, max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
            };
            Rogue_knives.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Wood", amount = 4, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "Iron", amount = 16, upgradeCost = 8 },
                    new RecipeIngredient { prefab = "LeatherScraps", amount = 6, upgradeCost = 3 },
                }
            };
            Loader.AddDefinition(Rogue_knives);

            // Iron 1H Daggers
            ItemDefinition Iron_knives = new ItemDefinition();
            Iron_knives.Name = "Iron knives";
            Iron_knives.Category = ItemCategory.Knives;
            Iron_knives.prefab = "VAdagger_iron";
            Iron_knives.icon = "iron_dagger";
            Iron_knives.craftedAt = "forge";
            Iron_knives.craftAmount = 1;
            Iron_knives.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 2, min =  0, max =  48 } },
                { ItemStat.slash, new ItemStatConfig{ default_value = 22, min =  0, max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.pierce, new ItemStatConfig{ default_value = 22, min =  0, max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 10, min =  0, max =  30 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 8, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 24, min =  1, max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
            };
            Iron_knives.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Wood", amount = 2, upgradeCost = 1 },
                    new RecipeIngredient { prefab = "Iron", amount = 12, upgradeCost = 6 },
                    new RecipeIngredient { prefab = "LeatherScraps", amount = 4, upgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Iron_knives);

            // Silver 2H Daggers
            ItemDefinition Silver_knives = new ItemDefinition();
            Silver_knives.Name = "Silver knives";
            Silver_knives.Category = ItemCategory.Knives;
            Silver_knives.prefab = "VAdagger_silver_2h";
            Silver_knives.icon = "silver_dagger_2h";
            Silver_knives.craftedAt = "forge";
            Silver_knives.craftAmount = 1;
            Silver_knives.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 16, min =  0, max =  48 } },
                { ItemStat.slash, new ItemStatConfig{ default_value = 34, min =  0, max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.pierce, new ItemStatConfig{ default_value = 34, min =  0, max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.spirit, new ItemStatConfig{ default_value = 12, min =  0, max =  99 } },
                { ItemStat.spirit_per_level, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
                { ItemStat.frost, new ItemStatConfig{ default_value = 0, min =  0, max =  99 } },
                { ItemStat.frost_per_level, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 10, min =  0, max =  40 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 10, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 30, min =  1, max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
            };
            Silver_knives.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Wood", amount = 4, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "Silver", amount = 12, upgradeCost = 6 },
                    new RecipeIngredient { prefab = "Iron", amount = 4, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "LeatherScraps", amount = 6, upgradeCost = 3 },
                }
            };
            Loader.AddDefinition(Silver_knives);

            // Moders Daggers 1H
            ItemDefinition Moders_knife = new ItemDefinition();
            Moders_knife.Name = "Moders knife";
            Moders_knife.Category = ItemCategory.Knives;
            Moders_knife.prefab = "VAdagger_moder";
            Moders_knife.icon = "moder_dagger";
            Moders_knife.craftedAt = "forge";
            Moders_knife.craftAmount = 1;
            Moders_knife.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 2, min =  0, max =  48 } },
                { ItemStat.slash, new ItemStatConfig{ default_value = 28, min =  0, max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.pierce, new ItemStatConfig{ default_value = 28, min =  0, max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.spirit, new ItemStatConfig{ default_value = 0, min =  0, max =  99 } },
                { ItemStat.spirit_per_level, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
                { ItemStat.frost, new ItemStatConfig{ default_value = 8, min =  0, max =  99 } },
                { ItemStat.frost_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 10, min =  0, max =  30 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 10, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 30, min =  1, max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
            };
            Moders_knife.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "ElderBark", amount = 4, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "Obsidian", amount = 15, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "DragonTear", amount = 10, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "TrophyDragonQueen", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Silver", amount = 0, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "JuteRed", amount = 0, upgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Moders_knife);

            // Moders Daggers 2H
            ItemDefinition Moders_knife_2h = new ItemDefinition();
            Moders_knife_2h.Name = "Moders dualknives";
            Moders_knife_2h.Category = ItemCategory.Knives;
            Moders_knife_2h.prefab = "VAdagger_moder_2h";
            Moders_knife_2h.icon = "moder_dagger_2h";
            Moders_knife_2h.craftedAt = "forge";
            Moders_knife_2h.craftAmount = 1;
            Moders_knife_2h.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 18, min =  0, max =  48 } },
                { ItemStat.slash, new ItemStatConfig{ default_value = 32, min =  0, max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.pierce, new ItemStatConfig{ default_value = 32, min =  0, max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.spirit, new ItemStatConfig{ default_value = 0, min =  0, max =  99 } },
                { ItemStat.spirit_per_level, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
                { ItemStat.frost, new ItemStatConfig{ default_value = 8, min =  0, max =  99 } },
                { ItemStat.frost_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 10, min =  0, max =  30 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 10, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 30, min =  1, max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
            };
            Moders_knife_2h.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "DragonTear", amount = 10, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "TrophyDragonQueen", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Silver", amount = 15, upgradeCost = 4 },
                    new RecipeIngredient { prefab = "ElderBark", amount = 6, upgradeCost = 3 },
                    new RecipeIngredient { prefab = "JuteRed", amount = 0, upgradeCost = 4 },
                }
            };
            Loader.AddDefinition(Moders_knife_2h);

            // Bonemass Dagger
            ItemDefinition Bonemasses_knife = new ItemDefinition();
            Bonemasses_knife.Name = "Bonemasses knife";
            Bonemasses_knife.Category = ItemCategory.Knives;
            Bonemasses_knife.prefab = "VABonemassDagger";
            Bonemasses_knife.icon = "bonemass_dagger";
            Bonemasses_knife.craftedAt = "forge";
            Bonemasses_knife.craftAmount = 1;
            Bonemasses_knife.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 2, min =  0, max =  48 } },
                { ItemStat.pierce, new ItemStatConfig{ default_value = 22, min =  0, max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.slash, new ItemStatConfig{ default_value = 22, min =  0, max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ default_value = 7, min =  0, max =  99 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ default_value = 2, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 10, min =  0, max =  30 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 9, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 28, min =  1, max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
            };
            Bonemasses_knife.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "WitheredBone", amount = 2, upgradeCost = 1 },
                    new RecipeIngredient { prefab = "Iron", amount = 12, upgradeCost = 6 },
                    new RecipeIngredient { prefab = "Wishbone", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "TrophyBonemass", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "ElderBark", amount = 0, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "LeatherScraps", amount = 0, upgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Bonemasses_knife);

            // Queens Dagger
            ItemDefinition Queens_knife = new ItemDefinition();
            Queens_knife.Name = "Queens knife";
            Queens_knife.Category = ItemCategory.Knives;
            Queens_knife.prefab = "VAdagger_queen";
            Queens_knife.icon = "dagger_queen";
            Queens_knife.craftedAt = "blackforge";
            Queens_knife.craftAmount = 1;
            Queens_knife.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 2, min =  0, max =  48 } },
                { ItemStat.pierce, new ItemStatConfig{ default_value = 34, min =  0, max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.slash, new ItemStatConfig{ default_value = 34, min =  0, max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ default_value = 18, min =  0, max =  99 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ default_value = 3, min =  0, max =  50 } },
                { ItemStat.lightning, new ItemStatConfig{ default_value = 18, min =  0, max =  99 } },
                { ItemStat.lightning_per_level, new ItemStatConfig{ default_value = 3, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 10, min =  0, max =  30 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 14, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 42, min =  1, max =  80 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
            };
            Queens_knife.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "YggdrasilWood", amount = 2, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "Eitr", amount = 10, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "JuteBlue", amount = 2, upgradeCost = 1 },
                    new RecipeIngredient { prefab = "TrophySeekerQueen", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Carapace", amount = 0, upgradeCost = 4 },
                }
            };
            Loader.AddDefinition(Queens_knife);

            // Meteor dagger
            ItemDefinition Flametal_knife = new ItemDefinition();
            Flametal_knife.Name = "Flametal knife";
            Flametal_knife.Category = ItemCategory.Knives;
            Flametal_knife.prefab = "VAdagger_meteor";
            Flametal_knife.icon = "meteor_dagger";
            Flametal_knife.craftedAt = "blackforge";
            Flametal_knife.craftAmount = 1;
            Flametal_knife.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 2, min =  0, max =  48 } },
                { ItemStat.pierce, new ItemStatConfig{ default_value = 45, min =  0, max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.slash, new ItemStatConfig{ default_value = 45, min =  0, max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 10, min =  0, max =  30 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 14, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 42, min =  1, max =  80 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
            };
            Flametal_knife.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "FlametalNew", amount = 10, upgradeCost = 4 },
                    new RecipeIngredient { prefab = "Iron", amount = 2, upgradeCost = 1 },
                    new RecipeIngredient { prefab = "Blackwood", amount = 4, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "MorgenSinew", amount = 4, upgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Flametal_knife);

            // Meteor primal dagger
            ItemDefinition Flametal_primal_knife = new ItemDefinition();
            Flametal_primal_knife.Name = "Flametal primal knife";
            Flametal_primal_knife.Category = ItemCategory.Knives;
            Flametal_primal_knife.prefab = "VAdagger_meteor_nature";
            Flametal_primal_knife.icon = "meteor_dagger_primal";
            Flametal_primal_knife.craftedAt = "blackforge";
            Flametal_primal_knife.craftAmount = 1;
            Flametal_primal_knife.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 2, min =  0, max =  48 } },
                { ItemStat.pierce, new ItemStatConfig{ default_value = 45, min =  0, max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.slash, new ItemStatConfig{ default_value = 45, min =  0, max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ default_value = 10, min =  0, max =  99 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ default_value = 2, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 10, min =  0, max =  30 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 14, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 42, min =  1, max =  80 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
            };
            Flametal_primal_knife.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "VAdagger_meteor", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "FlametalNew", amount = 4, upgradeCost = 4 },
                    new RecipeIngredient { prefab = "GemstoneGreen", amount = 1, upgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Flametal_primal_knife);

            // Meteor lightning dagger
            ItemDefinition Flametal_lightning_knife = new ItemDefinition();
            Flametal_lightning_knife.Name = "Flametal lightning knife";
            Flametal_lightning_knife.Category = ItemCategory.Knives;
            Flametal_lightning_knife.prefab = "VAdagger_meteor_lightning";
            Flametal_lightning_knife.icon = "meteor_dagger_lightning";
            Flametal_lightning_knife.craftedAt = "blackforge";
            Flametal_lightning_knife.craftAmount = 1;
            Flametal_lightning_knife.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 2, min =  0, max =  48 } },
                { ItemStat.pierce, new ItemStatConfig{ default_value = 45, min =  0, max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.slash, new ItemStatConfig{ default_value = 45, min =  0, max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.lightning, new ItemStatConfig{ default_value = 10, min =  0, max =  99 } },
                { ItemStat.lightning_per_level, new ItemStatConfig{ default_value = 2, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 10, min =  0, max =  30 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 14, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 42, min =  1, max =  80 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
            };
            Flametal_lightning_knife.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "VAdagger_meteor", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "FlametalNew", amount = 4, upgradeCost = 4 },
                    new RecipeIngredient { prefab = "GemstoneBlue", amount = 1, upgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Flametal_lightning_knife);

            // Meteor blood dagger
            ItemDefinition Flametal_blood_knife = new ItemDefinition();
            Flametal_blood_knife.Name = "Flametal blood knife";
            Flametal_blood_knife.Category = ItemCategory.Knives;
            Flametal_blood_knife.prefab = "VAdagger_meteor_blood";
            Flametal_blood_knife.icon = "meteor_dagger_blood";
            Flametal_blood_knife.craftedAt = "blackforge";
            Flametal_blood_knife.craftAmount = 1;
            Flametal_blood_knife.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 2, min =  0, max =  48 } },
                { ItemStat.pierce, new ItemStatConfig{ default_value = 45, min =  0, max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.slash, new ItemStatConfig{ default_value = 45, min =  0, max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 10, min =  0, max =  30 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 14, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 42, min =  1, max =  80 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
            };
            Flametal_blood_knife.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "VAdagger_meteor", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "FlametalNew", amount = 4, upgradeCost = 4 },
                    new RecipeIngredient { prefab = "GemstoneRed", amount = 1, upgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Flametal_blood_knife);

            // Meteor dagger 2h
            ItemDefinition Assassins_knives = new ItemDefinition();
            Assassins_knives.Name = "Assassins knives";
            Assassins_knives.Category = ItemCategory.Knives;
            Assassins_knives.prefab = "VAdagger_meteor_2h";
            Assassins_knives.icon = "2h_meteor_daggers";
            Assassins_knives.craftedAt = "blackforge";
            Assassins_knives.craftAmount = 1;
            Assassins_knives.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 28, min =  0, max =  48 } },
                { ItemStat.pierce, new ItemStatConfig{ default_value = 52, min =  0, max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.slash, new ItemStatConfig{ default_value = 52, min =  0, max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 10, min =  0, max =  30 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 15, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 45, min =  1, max =  80 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
            };
            Assassins_knives.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "FlametalNew", amount = 14, upgradeCost = 6 },
                    new RecipeIngredient { prefab = "Iron", amount = 2, upgradeCost = 1 },
                    new RecipeIngredient { prefab = "Blackwood", amount = 6, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "MorgenSinew", amount = 4, upgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Assassins_knives);

            // Meteor dagger 2h nature
            ItemDefinition Assassins_primal_knives = new ItemDefinition();
            Assassins_primal_knives.Name = "Assassins primal knives";
            Assassins_primal_knives.Category = ItemCategory.Knives;
            Assassins_primal_knives.prefab = "VAdagger_meteor_2h_nature";
            Assassins_primal_knives.icon = "meteor_dagger_primal_2h";
            Assassins_primal_knives.craftedAt = "blackforge";
            Assassins_primal_knives.craftAmount = 1;
            Assassins_primal_knives.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 28, min =  0, max =  48 } },
                { ItemStat.pierce, new ItemStatConfig{ default_value = 52, min =  0, max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.slash, new ItemStatConfig{ default_value = 52, min =  0, max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ default_value = 14, min =  0, max =  99 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ default_value = 2, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 10, min =  0, max =  30 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 15, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 45, min =  1, max =  80 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
            };
            Assassins_primal_knives.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "VAdagger_meteor_2h", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "FlametalNew", amount = 8, upgradeCost = 8 },
                    new RecipeIngredient { prefab = "GemstoneGreen", amount = 1, upgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Assassins_primal_knives);

            // Meteor dagger 2h lightning
            ItemDefinition Assassins_lightning_knives = new ItemDefinition();
            Assassins_lightning_knives.Name = "Assassins lightning knives";
            Assassins_lightning_knives.Category = ItemCategory.Knives;
            Assassins_lightning_knives.prefab = "VAdagger_meteor_2h_lightning";
            Assassins_lightning_knives.icon = "meteor_dagger_lightning_2h";
            Assassins_lightning_knives.craftedAt = "blackforge";
            Assassins_lightning_knives.craftAmount = 1;
            Assassins_lightning_knives.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 28, min =  0, max =  48 } },
                { ItemStat.pierce, new ItemStatConfig{ default_value = 52, min =  0, max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.slash, new ItemStatConfig{ default_value = 52, min =  0, max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.lightning, new ItemStatConfig{ default_value = 14, min =  0, max =  99 } },
                { ItemStat.lightning_per_level, new ItemStatConfig{ default_value = 2, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 10, min =  0, max =  30 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 15, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 45, min =  1, max =  80 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
            };
            Assassins_lightning_knives.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "VAdagger_meteor_2h", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "FlametalNew", amount = 8, upgradeCost = 8 },
                    new RecipeIngredient { prefab = "GemstoneBlue", amount = 1, upgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Assassins_lightning_knives);

            // Meteor dagger 2h Blood
            ItemDefinition Assassins_blood_knives = new ItemDefinition();
            Assassins_blood_knives.Name = "Assassins blood knives";
            Assassins_blood_knives.Category = ItemCategory.Knives;
            Assassins_blood_knives.prefab = "VAdagger_meteor_2h_blood";
            Assassins_blood_knives.icon = "meteor_dagger_blood_2h";
            Assassins_blood_knives.craftedAt = "blackforge";
            Assassins_blood_knives.craftAmount = 1;
            Assassins_blood_knives.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 28, min =  0, max =  48 } },
                { ItemStat.pierce, new ItemStatConfig{ default_value = 52, min =  0, max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.slash, new ItemStatConfig{ default_value = 52, min =  0, max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 10, min =  0, max =  30 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 15, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 45, min =  1, max =  80 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
            };
            Assassins_blood_knives.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "VAdagger_meteor_2h", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "FlametalNew", amount = 8, upgradeCost = 8 },
                    new RecipeIngredient { prefab = "GemstoneRed", amount = 1, upgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Assassins_blood_knives);
        }

        private void LoadSpears()
        {
            Logger.LogInfo("Loading Spears");
            // Flint Spear
            ItemDefinition FlintSpear = new ItemDefinition();
            FlintSpear.Name = "Flint Spear";
            FlintSpear.Category = ItemCategory.Spears;
            FlintSpear.prefab = "VASpearFlint";
            FlintSpear.icon = "flint_spear";
            FlintSpear.craftedAt = "piece_workbench";
            FlintSpear.craftAmount = 1;
            FlintSpear.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 4, min =  0, max =  48 } },
                { ItemStat.pierce, new ItemStatConfig{ default_value = 20, min =  0, max =  120 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 30, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 6, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 8, min =  1, max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 100, min =  0, max =  300 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
            };
            FlintSpear.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Wood", amount = 5, upgradeCost = 3 },
                    new RecipeIngredient { prefab = "Flint", amount = 10, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "LeatherScraps", amount = 2, upgradeCost = 1 },
                }
            };
            Loader.AddDefinition(FlintSpear);

            // Moder Spear
            ItemDefinition Moders_Strike = new ItemDefinition();
            Moders_Strike.Name = "Moders Strike";
            Moders_Strike.Category = ItemCategory.Spears;
            Moders_Strike.prefab = "VASpearModer";
            Moders_Strike.icon = "moder_spear";
            Moders_Strike.craftedAt = "forge";
            Moders_Strike.craftAmount = 1;
            Moders_Strike.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 30, min =  0, max =  48 } },
                { ItemStat.pierce, new ItemStatConfig{ default_value = 45, min =  0, max =  120 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 2, min =  0, max =  50 } },
                { ItemStat.slash, new ItemStatConfig{ default_value = 30, min =  0, max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 4, min =  0, max =  50 } },
                { ItemStat.frost, new ItemStatConfig{ default_value = 25, min =  0, max =  99 } },
                { ItemStat.frost_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 20, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 12, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 14, min =  1, max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 100, min =  0, max =  300 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
            };
            Moders_Strike.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "ElderBark", amount = 15, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "Obsidian", amount = 8, upgradeCost = 4 },
                    new RecipeIngredient { prefab = "DragonTear", amount = 10, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "TrophyDragonQueen", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Silver", amount = 0, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "JuteRed", amount = 0, upgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Moders_Strike);

            // Blackmetal Spear
            ItemDefinition BlackmetalSpear = new ItemDefinition();
            BlackmetalSpear.Name = "Blackmetal Spear";
            BlackmetalSpear.Category = ItemCategory.Spears;
            BlackmetalSpear.prefab = "VASpearBlackmetal";
            BlackmetalSpear.icon = "blackmetal_spear";
            BlackmetalSpear.craftedAt = "forge";
            BlackmetalSpear.craftAmount = 1;
            BlackmetalSpear.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 30, min =  0, max =  48 } },
                { ItemStat.pierce, new ItemStatConfig{ default_value = 95, min =  0, max =  120 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 2, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 20, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 14, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 18, min =  1, max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 100, min =  0, max =  300 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
            };
            BlackmetalSpear.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "BlackMetal", amount = 6, upgradeCost = 6 },
                    new RecipeIngredient { prefab = "FineWood", amount = 10, upgradeCost = 5 },
                    new RecipeIngredient { prefab = "Chain", amount = 2, upgradeCost = 1 },
                    new RecipeIngredient { prefab = "JuteRed", amount = 2, upgradeCost = 1 },
                }
            };
            Loader.AddDefinition(BlackmetalSpear);

            // Fader Spear
            ItemDefinition FaderSpear = new ItemDefinition();
            FaderSpear.Name = "Fader Spear";
            FaderSpear.Category = ItemCategory.Spears;
            FaderSpear.prefab = "VASpearFader";
            FaderSpear.icon = "fader_spear";
            FaderSpear.craftedAt = "blackforge";
            FaderSpear.craftAmount = 1;
            FaderSpear.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 30, min =  0, max =  48 } },
                { ItemStat.pierce, new ItemStatConfig{ default_value = 150, min =  0, max =  300 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 3, min =  0, max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ default_value = 25, min =  0, max =  300 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.fire, new ItemStatConfig{ default_value = 25, min =  0, max =  300 } },
                { ItemStat.fire_per_level, new ItemStatConfig{ default_value = 1, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 20, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 18, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 20, min =  1, max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 100, min =  0, max =  300 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
            };
            FaderSpear.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "FlametalNew", amount = 24, upgradeCost = 24 },
                    new RecipeIngredient { prefab = "Blackwood", amount = 10, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "TrophyFader", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "FaderDrop", amount = 1, upgradeCost = 0 },
                }
            };
            Loader.AddDefinition(FaderSpear);
        }

        private void LoadFists()
        {
            Logger.LogInfo("Loading Fists");
            // Flint Fists
            ItemDefinition Flint_knuckles = new ItemDefinition();
            Flint_knuckles.Name = "Flint knuckles";
            Flint_knuckles.Category = ItemCategory.Fists;
            Flint_knuckles.prefab = "VAFist_Flint";
            Flint_knuckles.icon = "flint_fists";
            Flint_knuckles.craftedAt = "piece_workbench";
            Flint_knuckles.craftAmount = 1;
            Flint_knuckles.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 5, min =  0, max =  48 } },
                { ItemStat.slash, new ItemStatConfig{ default_value = 6, min =  0, max =  120 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 4, min =  0, max =  50 } },
                { ItemStat.blunt, new ItemStatConfig{ default_value = 0, min =  0, max =  120 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 20, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 4, min =  1, max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 300, min =  0, max =  600 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
            };
            Flint_knuckles.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Wood", amount = 4, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Flint", amount = 4, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "LeatherScraps", amount = 2, upgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Flint_knuckles);

            // Bronze Fists
            ItemDefinition Bronze_knuckles = new ItemDefinition();
            Bronze_knuckles.Name = "Bronze knuckles";
            Bronze_knuckles.Category = ItemCategory.Fists;
            Bronze_knuckles.prefab = "VAFist_Bronze";
            Bronze_knuckles.icon = "bronze_fists";
            Bronze_knuckles.craftedAt = "forge";
            Bronze_knuckles.craftAmount = 1;
            Bronze_knuckles.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 5, min =  0, max =  48 } },
                { ItemStat.slash, new ItemStatConfig{ default_value = 20, min =  0, max =  120 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 4, min =  0, max =  50 } },
                { ItemStat.blunt, new ItemStatConfig{ default_value = 0, min =  0, max =  120 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 20, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 6, min =  1, max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 300, min =  0, max =  600 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
            };
            Bronze_knuckles.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "RoundLog", amount = 4, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Bronze", amount = 6, upgradeCost = 3 },
                    new RecipeIngredient { prefab = "LeatherScraps", amount = 4, upgradeCost = 4 },
                }
            };
            Loader.AddDefinition(Bronze_knuckles);

            // Iron Fists
            ItemDefinition Iron_knuckles = new ItemDefinition();
            Iron_knuckles.Name = "Iron knuckles";
            Iron_knuckles.Category = ItemCategory.Fists;
            Iron_knuckles.prefab = "VAFist_Iron";
            Iron_knuckles.icon = "iron_fists";
            Iron_knuckles.craftedAt = "forge";
            Iron_knuckles.craftAmount = 1;
            Iron_knuckles.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 5, min =  0, max =  48 } },
                { ItemStat.slash, new ItemStatConfig{ default_value = 35, min =  0, max =  120 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 4, min =  0, max =  50 } },
                { ItemStat.blunt, new ItemStatConfig{ default_value = 0, min =  0, max =  120 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 20, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 8, min =  1, max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 300, min =  0, max =  600 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
            };
            Iron_knuckles.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Wood", amount = 4, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "Iron", amount = 12, upgradeCost = 6 },
                    new RecipeIngredient { prefab = "LeatherScraps", amount = 6, upgradeCost = 6 },
                }
            };
            Loader.AddDefinition(Iron_knuckles);

            // Yagluth Fists
            ItemDefinition Goblin_king_knuckles = new ItemDefinition();
            Goblin_king_knuckles.Name = "Goblin king knuckles";
            Goblin_king_knuckles.Category = ItemCategory.Fists;
            Goblin_king_knuckles.prefab = "VAFist_Yagluth";
            Goblin_king_knuckles.icon = "yagluth_fists";
            Goblin_king_knuckles.craftedAt = "forge";
            Goblin_king_knuckles.craftAmount = 1;
            Goblin_king_knuckles.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 5, min =  0, max =  48 } },
                { ItemStat.slash, new ItemStatConfig{ default_value = 80, min =  0, max =  120 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 4, min =  0, max =  50 } },
                { ItemStat.blunt, new ItemStatConfig{ default_value = 0, min =  0, max =  120 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
                { ItemStat.fire, new ItemStatConfig{ default_value = 25, min =  0, max =  120 } },
                { ItemStat.fire_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 20, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 12, min =  1, max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 36, min =  1, max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 300, min =  0, max =  600 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
            };
            Goblin_king_knuckles.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "BlackMetal", amount = 4, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "Iron", amount = 6, upgradeCost = 3 },
                    new RecipeIngredient { prefab = "YagluthDrop", amount = 2, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "TrophyGoblinKing", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Tar", amount = 0, upgradeCost = 3 },
                    new RecipeIngredient { prefab = "LinenThread", amount = 0, upgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Goblin_king_knuckles);
        }

        private void LoadMaces()
        {
            Logger.LogInfo("Loading Maces");
            // Elders Mace
            ItemDefinition Elders_Fist = new ItemDefinition();
            Elders_Fist.Name = "Elders Fist";
            Elders_Fist.Category = ItemCategory.Maces;
            Elders_Fist.prefab = "VAElder_mace";
            Elders_Fist.icon = "elder_mace";
            Elders_Fist.craftedAt = "forge";
            Elders_Fist.craftAmount = 1;
            Elders_Fist.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.blunt, new ItemStatConfig{ default_value = 35, min =  0, max =  90 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.spirit, new ItemStatConfig{ default_value = 20, min =  0, max =  120 } },
                { ItemStat.spirit_per_level, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 80, min =  0, max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 12, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 8, min =  1, max =  30 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 16, min =  1, max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
            };
            Elders_Fist.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Bronze", amount = 2, upgradeCost = 1 },
                    new RecipeIngredient { prefab = "Stone", amount = 16, upgradeCost = 8 },
                    new RecipeIngredient { prefab = "CryptKey", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "TrophyTheElder", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "RoundLog", amount = 0, upgradeCost = 6 },
                }
            };
            Loader.AddDefinition(Elders_Fist);


            // Flint Mace
            ItemDefinition FlintMace = new ItemDefinition();
            FlintMace.Name = "Flint Mace";
            FlintMace.Category = ItemCategory.Maces;
            FlintMace.prefab = "VAFlintMace";
            FlintMace.icon = "flintMace";
            FlintMace.craftedAt = "piece_workbench";
            FlintMace.craftAmount = 1;
            FlintMace.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.blunt, new ItemStatConfig{ default_value = 16, min =  0, max =  90 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 30, min =  0, max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 4, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 7, min =  1, max =  30 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 14, min =  1, max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
            };
            FlintMace.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "Wood", amount = 4, upgradeCost = 8 },
                    new RecipeIngredient { prefab = "Flint", amount = 8, upgradeCost = 8 },
                    new RecipeIngredient { prefab = "LeatherScraps", amount = 2, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "BoneFragments", amount = 0, upgradeCost = 5 },
                }
            };
            Loader.AddDefinition(FlintMace);
            
        }

        private void LoadMagic()
        {
            Logger.LogInfo("Loading Magic Weapons");
            // Staff of poison
            ItemDefinition Staff_of_poison = new ItemDefinition();
            Staff_of_poison.Name = "Staff of poison";
            Staff_of_poison.Category = ItemCategory.Magics;
            Staff_of_poison.prefab = "VAStaff_Poison";
            Staff_of_poison.icon = "poison_staff";
            Staff_of_poison.craftedAt = "piece_magetable";
            Staff_of_poison.craftAmount = 1;
            Staff_of_poison.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 48, min =  0, max =  90 } },
                { ItemStat.poison, new ItemStatConfig{ default_value = 120, min =  0, max =  200 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.blunt, new ItemStatConfig{ default_value = 120, min =  0, max =  200 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 20, min =  0, max =  150 } },
                { ItemStat.primary_attack_eitr, new ItemStatConfig{ default_value = 35, min =  0, max =  50 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
            };
            Staff_of_poison.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "YggdrasilWood", amount = 20, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "Guck", amount = 4, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "Eitr", amount = 16, upgradeCost = 8 },
                }
            };
            Loader.AddDefinition(Staff_of_poison);

            // Staff of spirit
            ItemDefinition Staff_of_Spirit = new ItemDefinition();
            Staff_of_Spirit.Name = "Staff of Spirit";
            Staff_of_Spirit.Category = ItemCategory.Magics;
            Staff_of_Spirit.prefab = "VAStaff_Spirit";
            Staff_of_Spirit.icon = "spirit_staff";
            Staff_of_Spirit.craftedAt = "piece_magetable";
            Staff_of_Spirit.craftAmount = 1;
            Staff_of_Spirit.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 48, min =  0, max =  90 } },
                { ItemStat.spirit, new ItemStatConfig{ default_value = 90, min =  0, max =  200 } },
                { ItemStat.spirit_per_level, new ItemStatConfig{ default_value = 3, min =  0, max =  50 } },
                { ItemStat.blunt, new ItemStatConfig{ default_value = 0, min =  0, max =  200 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
                { ItemStat.slash, new ItemStatConfig{ default_value = 120, min =  0, max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 3, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 20, min =  0, max =  150 } },
                { ItemStat.primary_attack_eitr, new ItemStatConfig{ default_value = 35, min =  0, max =  50 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min =  0, max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
            };
            Staff_of_Spirit.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "YggdrasilWood", amount = 20, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "GreydwarfEye", amount = 8, upgradeCost = 8 },
                    new RecipeIngredient { prefab = "Eitr", amount = 16, upgradeCost = 8 },
                    new RecipeIngredient { prefab = "TrophyDvergr", amount = 2, upgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Staff_of_Spirit);

            // Druidic Staff of poison
            ItemDefinition Druidic_Staff_of_Poison = new ItemDefinition();
            Druidic_Staff_of_Poison.Name = "Druidic Staff of Poison";
            Druidic_Staff_of_Poison.Category = ItemCategory.Magics;
            Druidic_Staff_of_Poison.prefab = "VAStaff_Druid_Poison";
            Druidic_Staff_of_Poison.icon = "poison_staff_druidic";
            Druidic_Staff_of_Poison.craftedAt = "piece_workbench";
            Druidic_Staff_of_Poison.craftAmount = 1;
            Druidic_Staff_of_Poison.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 24, min =  0, max =  48 } },
                { ItemStat.poison, new ItemStatConfig{ default_value = 50, min =  0, max =  120 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.blunt, new ItemStatConfig{ default_value = 50, min =  0, max =  200 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 20, min =  0, max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 50, min =  0, max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 10, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 35, min =  0, max =  50 } },
                { ItemStat.primary_attack_eitr, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
            };
            Druidic_Staff_of_Poison.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "ElderBark", amount = 20, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "Guck", amount = 4, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "TrophyBlob", amount = 2, upgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Druidic_Staff_of_Poison);

            // Druidic Staff of spirit
            ItemDefinition Druidic_Staff_of_Spirit = new ItemDefinition();
            Druidic_Staff_of_Spirit.Name = "Druidic Staff of Spirit";
            Druidic_Staff_of_Spirit.Category = ItemCategory.Magics;
            Druidic_Staff_of_Spirit.prefab = "VAStaff_Druid_Spirit";
            Druidic_Staff_of_Spirit.icon = "spirit_staff_druid";
            Druidic_Staff_of_Spirit.craftedAt = "piece_workbench";
            Druidic_Staff_of_Spirit.craftAmount = 1;
            Druidic_Staff_of_Spirit.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 24, min =  0, max =  48 } },
                { ItemStat.spirit, new ItemStatConfig{ default_value = 20, min =  0, max =  120 } },
                { ItemStat.spirit_per_level, new ItemStatConfig{ default_value = 3, min =  0, max =  50 } },
                { ItemStat.blunt, new ItemStatConfig{ default_value = 0, min =  0, max =  200 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
                { ItemStat.slash, new ItemStatConfig{ default_value = 40, min =  0, max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ default_value = 3, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 20, min =  0, max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 50, min =  0, max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 10, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 35, min =  0, max =  50 } },
                { ItemStat.primary_attack_eitr, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
            };
            Druidic_Staff_of_Spirit.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "ElderBark", amount = 20, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "GreydwarfEye", amount = 4, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "TrophyGreydwarfShaman", amount = 2, upgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Druidic_Staff_of_Spirit);

            // Druidic Staff of Ice
            ItemDefinition Druidic_Staff_of_Ice = new ItemDefinition();
            Druidic_Staff_of_Ice.Name = "Druidic Staff of Ice";
            Druidic_Staff_of_Ice.Category = ItemCategory.Magics;
            Druidic_Staff_of_Ice.prefab = "VAStaff_Druid_Ice";
            Druidic_Staff_of_Ice.icon = "ice_staff_druidic";
            Druidic_Staff_of_Ice.craftedAt = "piece_workbench";
            Druidic_Staff_of_Ice.craftAmount = 1;
            Druidic_Staff_of_Ice.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 24, min =  0, max =  48 } },
                { ItemStat.frost, new ItemStatConfig{ default_value = 12, min =  0, max =  120 } },
                { ItemStat.frost_per_level, new ItemStatConfig{ default_value = 2, min =  0, max =  50 } },
                { ItemStat.blunt, new ItemStatConfig{ default_value = 12, min =  0, max =  200 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 20, min =  0, max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 50, min =  0, max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 10, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 5, min =  0, max =  50 } },
                { ItemStat.primary_attack_eitr, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
            };
            Druidic_Staff_of_Ice.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "ElderBark", amount = 20, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "FreezeGland", amount = 4, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "TrophyHatchling", amount = 2, upgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Druidic_Staff_of_Ice);

            // Druidic Staff of Fire
            ItemDefinition Druidic_Staff_of_Fire = new ItemDefinition();
            Druidic_Staff_of_Fire.Name = "Druidic Staff of Fire";
            Druidic_Staff_of_Fire.Category = ItemCategory.Magics;
            Druidic_Staff_of_Fire.prefab = "VAStaff_Druid_Fire";
            Druidic_Staff_of_Fire.icon = "fire_staff_druidic";
            Druidic_Staff_of_Fire.craftedAt = "piece_workbench";
            Druidic_Staff_of_Fire.craftAmount = 1;
            Druidic_Staff_of_Fire.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 24, min =  0, max =  48 } },
                { ItemStat.fire, new ItemStatConfig{ default_value = 50, min =  0, max =  120 } },
                { ItemStat.fire_per_level, new ItemStatConfig{ default_value = 6, min =  0, max =  50 } },
                { ItemStat.blunt, new ItemStatConfig{ default_value = 50, min =  0, max =  200 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 20, min =  0, max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 50, min =  0, max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 10, min =  0, max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 35, min =  0, max =  50 } },
                { ItemStat.primary_attack_eitr, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
            };
            Druidic_Staff_of_Fire.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "ElderBark", amount = 20, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "SurtlingCore", amount = 4, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "TrophySurtling", amount = 2, upgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Druidic_Staff_of_Fire);

            // Soulstealer
            ItemDefinition Soulstealer = new ItemDefinition();
            Soulstealer.Name = "Soulstealer";
            Soulstealer.Category = ItemCategory.Magics;
            Soulstealer.prefab = "VASoulStealer";
            Soulstealer.icon = "soulstealer";
            Soulstealer.craftedAt = "piece_magetable";
            Soulstealer.craftAmount = 1;
            Soulstealer.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ default_value = 200, min =  0, max =  300 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 3, min =  0, max =  50 } },
                { ItemStat.spirit, new ItemStatConfig{ default_value = 100, min =  0, max =  300 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 200, min =  0, max =  300 } },
                { ItemStat.block_armor, new ItemStatConfig{ default_value = 3, min =  0, max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 100, min =  0, max =  300 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min =  0, max =  150 } },
                { ItemStat.crossbow_reload_speed, new ItemStatConfig{ default_value = 2f, min =  0.01f, max =  3.5f } },
                { ItemStat.crossbow_reload_stamina_drain, new ItemStatConfig{ default_value = 0, min =  0, max =  50 } },
                { ItemStat.primary_attack_percent_health_cost, new ItemStatConfig{ default_value = 12, min =  0, max =  50 } },
                { ItemStat.primary_attack_flat_health_cost, new ItemStatConfig{ default_value = 10, min =  0, max =  120 } },
                { ItemStat.primary_attack_health_returned, new ItemStatConfig{ default_value = 10, min =  0, max =  50 } },
                { ItemStat.primary_attack_projectile_count, new ItemStatConfig { default_value = 2, min =  1, max =  10 } },
                { ItemStat.projectile_velocity, new ItemStatConfig{ default_value = 200, min =  0, max =  300 } },
            };
            Soulstealer.recipe = new RecipeDefinition
            {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "FlametalNew", amount = 18, upgradeCost = 10 },
                    new RecipeIngredient { prefab = "Blackwood", amount = 24, upgradeCost = 12 },
                    new RecipeIngredient { prefab = "GemstoneRed", amount = 2, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "DvergrNeedle", amount = 1, upgradeCost = 0 },
                    new RecipeIngredient { prefab = "Bronze", amount = 0, upgradeCost = 6 },
                }
            };
            Loader.AddDefinition(Soulstealer);
        }

        private void LoadPickaxes()
        {
            // This is just another magic weapon so we are not gunna log its loading seperately
            // If more pickaxes are are added this will be restructured
            
            // Bone Blood Pickaxe
            ItemDefinition bonepick = new ItemDefinition();
            bonepick.Name = "Bone Blood Pickaxe";
            bonepick.Category = ItemCategory.Pickaxes;
            bonepick.prefab = "VABlood_Bones_pickaxe";
            bonepick.icon = "blood_bone_pickaxe";
            bonepick.craftedAt = "forge";
            bonepick.craftAmount = 1;
            bonepick.reqStationlevel = 1;
            bonepick.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ default_value = 26, min = 0, max = 200 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ default_value = 4, min = 0, max = 50 } },
                { ItemStat.spirit, new ItemStatConfig{ default_value = 6, min = 0, max = 200 } },
                { ItemStat.spirit_per_level, new ItemStatConfig{ default_value = 2, min = 0, max = 50 } },
                { ItemStat.pickaxe, new ItemStatConfig{ default_value = 32, min = 0, max = 200 } },
                { ItemStat.pickaxe_per_level, new ItemStatConfig{ default_value = 6, min = 0, max = 50 } },
                { ItemStat.attack_force, new ItemStatConfig{ default_value = 50, min = 0, max = 100 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ default_value = 6, min = 0, max = 50 } },
                { ItemStat.primary_attack_flat_health_cost, new ItemStatConfig{ default_value = 4, min = 0, max = 50 } },
                { ItemStat.primary_attack_percent_health_cost, new ItemStatConfig{ default_value = 0, min = 0, max = 50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ default_value = 4, min = 0, max = 50 } },
                { ItemStat.secondary_attack_flat_health_cost, new ItemStatConfig{ default_value = 6, min = 0, max = 50 } },
                { ItemStat.secondary_attack_percent_health_cost, new ItemStatConfig{ default_value = 0, min = 0, max = 100 } },
                { ItemStat.tool_level, new ItemStatConfig{ default_value = 1, min = 0, max = 5 } },
                { ItemStat.durability, new ItemStatConfig{ default_value = 200, min = 0, max = 800 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ default_value = 50, min = 0, max = 200 } },
            };
            bonepick.recipe = new RecipeDefinition {
                recipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { prefab = "RoundLog", amount = 12, upgradeCost = 8 },
                    new RecipeIngredient { prefab = "BoneFragments", amount = 20, upgradeCost = 14 },
                    new RecipeIngredient { prefab = "Bronze", amount = 4, upgradeCost = 2 },
                    new RecipeIngredient { prefab = "TrophySkeleton", amount = 2, upgradeCost = 0 },
                }
            };
            Loader.AddDefinition(bonepick);
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
            // Spear projectiles
            new NonCraftablePrefab(EmbeddedResourceBundle, "Assets/Custom/Weapons/Spears/VAspearblackmetal_projectile.prefab");
            new NonCraftablePrefab(EmbeddedResourceBundle, "Assets/Custom/Weapons/Spears/VAspearmoder_projectile.prefab");

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