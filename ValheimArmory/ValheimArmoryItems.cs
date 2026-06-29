
using Jotunn.Entities;
using Jotunn.Managers;
using System;
using System.Collections.Generic;
using UnityEngine;
using ValheimArmory.Common;

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
            Black_Metal_Arrow.Prefab = "VAArrowGreenMetal";
            Black_Metal_Arrow.Icon = "arrow_greenmetal";
            Black_Metal_Arrow.CraftedAt = "forge";
            Black_Metal_Arrow.CraftAmount = 20;
            Black_Metal_Arrow.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.blunt, new ItemStatConfig{ Default_value = 52, Min =  0, Max =  200 } },
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 26, Min =  0, Max =  200 } },
            };
            Black_Metal_Arrow.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Wood", Amount = 8, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "BlackMetal", Amount = 2, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Feathers", Amount = 2, UpgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Black_Metal_Arrow);

            // Bone Arrows							workbench lvl 3(obsidian)
            ItemDefinition Bone_Arrow = new ItemDefinition();
            Bone_Arrow.Name = "Bone Arrow";
            Bone_Arrow.Category = ItemCategory.Arrows;
            Bone_Arrow.Prefab = "VAArrowBone";
            Bone_Arrow.Icon = "bone_arrow";
            Bone_Arrow.CraftedAt = "piece_workbench";
            Bone_Arrow.CraftAmount = 20;
            Bone_Arrow.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 32, Min =  0, Max =  200 } },
            };
            Bone_Arrow.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "BoneFragments", Amount = 8, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Feathers", Amount = 2, UpgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Bone_Arrow);

            // Surtling Fire Arrow					workbench lvl 3
            ItemDefinition Surtling_Fire_Arrow = new ItemDefinition();
            Surtling_Fire_Arrow.Name = "Surtling Fire Arrow";
            Surtling_Fire_Arrow.Category = ItemCategory.Arrows;
            Surtling_Fire_Arrow.Prefab = "VAarrow_surtling_fire";
            Surtling_Fire_Arrow.Icon = "surtlingcore_arrow";
            Surtling_Fire_Arrow.CraftedAt = "piece_workbench";
            Surtling_Fire_Arrow.CraftAmount = 20;
            Surtling_Fire_Arrow.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.fire, new ItemStatConfig{ Default_value = 52, Min =  0, Max =  200 } },
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 26, Min =  0, Max =  200 } },
            };
            Surtling_Fire_Arrow.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Wood", Amount = 8, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Obsidian", Amount = 4, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Feathers", Amount = 2, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "SurtlingCore", Amount = 1, UpgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Surtling_Fire_Arrow);

            // Ancient Wood Arrow					workbench lvl 3
            ItemDefinition Ancient_Wood_Arrow = new ItemDefinition();
            Ancient_Wood_Arrow.Name = "Ancient Wood Arrow";
            Ancient_Wood_Arrow.Category = ItemCategory.Arrows;
            Ancient_Wood_Arrow.Prefab = "VAArrowAncient";
            Ancient_Wood_Arrow.Icon = "ancient_arrow";
            Ancient_Wood_Arrow.CraftedAt = "piece_workbench";
            Ancient_Wood_Arrow.CraftAmount = 20;
            Ancient_Wood_Arrow.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 37, Min =  0, Max =  200 } },
            };
            Ancient_Wood_Arrow.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "ElderBark", Amount = 8, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Feathers", Amount = 2, UpgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Ancient_Wood_Arrow);

            // Chitin Arrow							workbench lvl 3
            ItemDefinition Chitin_Arrow = new ItemDefinition();
            Chitin_Arrow.Name = "Chitin Arrow";
            Chitin_Arrow.Category = ItemCategory.Arrows;
            Chitin_Arrow.Prefab = "VAChitinArrow";
            Chitin_Arrow.Icon = "arrow_chitin";
            Chitin_Arrow.CraftedAt = "piece_workbench";
            Chitin_Arrow.CraftAmount = 20;
            Chitin_Arrow.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 12, Min =  0, Max =  200 } },
                { ItemStat.blunt, new ItemStatConfig{ Default_value = 35, Min =  0, Max =  200 } },
            };
            Chitin_Arrow.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Wood", Amount = 8, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Chitin", Amount = 2, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Feathers", Amount = 2, UpgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Chitin_Arrow);

            // Wood Crossbow Bolt					workbench lvl 1
            ItemDefinition Wood_Bolt = new ItemDefinition();
            Wood_Bolt.Name = "Wood Bolt";
            Wood_Bolt.Category = ItemCategory.Arrows;
            Wood_Bolt.Prefab = "VABoltWood";
            Wood_Bolt.Icon = "bolt_wood";
            Wood_Bolt.CraftedAt = "piece_workbench";
            Wood_Bolt.CraftAmount = 20;
            Wood_Bolt.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 22, Min =  0, Max =  200 } },
            };
            Wood_Bolt.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Wood", Amount = 8, UpgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Wood_Bolt);

            // Corewood Crossbow Bolt					workbench lvl 3
            ItemDefinition Corewood_Bolt = new ItemDefinition();
            Corewood_Bolt.Name = "Corewood Bolt";
            Corewood_Bolt.Category = ItemCategory.Arrows;
            Corewood_Bolt.Prefab = "VABoltCoreWood";
            Corewood_Bolt.Icon = "bolt_corewood";
            Corewood_Bolt.CraftedAt = "piece_workbench";
            Corewood_Bolt.CraftAmount = 20;
            Corewood_Bolt.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 37, Min =  0, Max =  200 } },
            };
            Corewood_Bolt.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "RoundLog", Amount = 8, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Feathers", Amount = 2, UpgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Corewood_Bolt);

            // Bronze Bolt							forge lvl 1
            ItemDefinition Bronze_Bolt = new ItemDefinition();
            Bronze_Bolt.Name = "Bronze Bolt";
            Bronze_Bolt.Category = ItemCategory.Arrows;
            Bronze_Bolt.Prefab = "VAbolt_bronze";
            Bronze_Bolt.Icon = "bronze_bolt";
            Bronze_Bolt.CraftedAt = "forge";
            Bronze_Bolt.CraftAmount = 20;
            Bronze_Bolt.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 32, Min =  0, Max =  200 } },
            };
            Bronze_Bolt.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Wood", Amount = 8, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Bronze", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Feathers", Amount = 2, UpgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Bronze_Bolt);

            // Iron Poison Bolt						forge lvl 2
            ItemDefinition Poison_Bolt = new ItemDefinition();
            Poison_Bolt.Name = "Poison Bolt";
            Poison_Bolt.Category = ItemCategory.Arrows;
            Poison_Bolt.Prefab = "VAbolt_poison";
            Poison_Bolt.Icon = "poison_bolt";
            Poison_Bolt.CraftedAt = "forge";
            Poison_Bolt.CraftAmount = 20;
            Poison_Bolt.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.poison, new ItemStatConfig{ Default_value = 52, Min =  0, Max =  200 } },
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 26, Min =  0, Max =  200 } },
            };
            Poison_Bolt.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Wood", Amount = 8, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Iron", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Feathers", Amount = 2, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Ooze", Amount = 1, UpgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Poison_Bolt);

            // Obsidian Bolt						workbench lvl 3
            ItemDefinition Obsidian_Bolt = new ItemDefinition();
            Obsidian_Bolt.Name = "Obsidian Bolt";
            Obsidian_Bolt.Category = ItemCategory.Arrows;
            Obsidian_Bolt.Prefab = "VAObsidianBolt";
            Obsidian_Bolt.Icon = "obsidian_bolt";
            Obsidian_Bolt.CraftedAt = "piece_workbench";
            Obsidian_Bolt.CraftAmount = 20;
            Obsidian_Bolt.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 52, Min =  0, Max =  200 } },
            };
            Obsidian_Bolt.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Wood", Amount = 8, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Obsidian", Amount = 4, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Feathers", Amount = 2, UpgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Obsidian_Bolt);

            // Silver Ice Bolt						forge lvl 3
            ItemDefinition Frost_Bolt = new ItemDefinition();
            Frost_Bolt.Name = "Frost Bolt";
            Frost_Bolt.Category = ItemCategory.Arrows;
            Frost_Bolt.Prefab = "VAbolt_frost";
            Frost_Bolt.Icon = "ice_bolt";
            Frost_Bolt.CraftedAt = "forge";
            Frost_Bolt.CraftAmount = 20;
            Frost_Bolt.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.frost, new ItemStatConfig{ Default_value = 52, Min =  0, Max =  200 } },
                { ItemStat.spirit, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  200 } },
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 26, Min =  0, Max =  200 } },
            };
            Frost_Bolt.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Wood", Amount = 8, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Silver", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Feathers", Amount = 2, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "FreezeGland", Amount = 1, UpgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Frost_Bolt);

            // Iron Surtling bolt					forge lvl 2
            ItemDefinition Surtling_Core_Bolt = new ItemDefinition();
            Surtling_Core_Bolt.Name = "Surtling Core Bolt";
            Surtling_Core_Bolt.Category = ItemCategory.Arrows;
            Surtling_Core_Bolt.Prefab = "VASurtlingBolt";
            Surtling_Core_Bolt.Icon = "surtling_bolt";
            Surtling_Core_Bolt.CraftedAt = "forge";
            Surtling_Core_Bolt.CraftAmount = 20;
            Surtling_Core_Bolt.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.fire, new ItemStatConfig{ Default_value = 52, Min =  0, Max =  200 } },
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 26, Min =  0, Max =  200 } },
            };
            Surtling_Core_Bolt.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Wood", Amount = 8, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Iron", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Feathers", Amount = 2, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "SurtlingCore", Amount = 1, UpgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Surtling_Core_Bolt);

            // Needle bolt					forge lvl 4
            ItemDefinition Needle_Bolt = new ItemDefinition();
            Needle_Bolt.Name = "Needle Bolt";
            Needle_Bolt.Category = ItemCategory.Arrows;
            Needle_Bolt.Prefab = "VABoltNeedle";
            Needle_Bolt.Icon = "needle_bolt";
            Needle_Bolt.CraftedAt = "piece_workbench";
            Needle_Bolt.CraftAmount = 20;
            Needle_Bolt.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 56, Min =  0, Max =  200 } },
            };
            Needle_Bolt.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Needle", Amount = 8, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Feathers", Amount = 2, UpgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Needle_Bolt);

            // Fire bolt					forge lvl 2
            ItemDefinition Fire_Bolt = new ItemDefinition();
            Fire_Bolt.Name = "Fire Bolt";
            Fire_Bolt.Category = ItemCategory.Arrows;
            Fire_Bolt.Prefab = "VAFireBolt";
            Fire_Bolt.Icon = "surtling_bolt";
            Fire_Bolt.CraftedAt = "piece_workbench";
            Fire_Bolt.CraftAmount = 20;
            Fire_Bolt.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 22, Min =  0, Max =  200 } },
                { ItemStat.fire, new ItemStatConfig{ Default_value = 34, Min =  0, Max =  200 } },
            };
            Fire_Bolt.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Wood", Amount = 8, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Resin", Amount = 8, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Feathers", Amount = 2, UpgradeCost = 0 },
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
            Blackmetal_Bow.Prefab = "VABlackmetal_bow";
            Blackmetal_Bow.Icon = "blackmetal_bow";
            Blackmetal_Bow.CraftedAt = "forge";
            Blackmetal_Bow.CraftAmount = 1;
            Blackmetal_Bow.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 62, Min =  0, Max =  300 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  50 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  150 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  300 } },
                { ItemStat.draw_stamina_drain, new ItemStatConfig{ Default_value = 12, Min =  1, Max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.bow_draw_speed, new ItemStatConfig{ Default_value = 2, Min =  0.01f, Max =  2 } },
                { ItemStat.projectile_velocity, new ItemStatConfig{ Default_value = 60, Min =  0, Max =  120 } },
                { ItemStat.projectile_accuracy_max, new ItemStatConfig{ Default_value = 100, Min =  0, Max =  100 } },
            };
            Blackmetal_Bow.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "FineWood", Amount = 15, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "BlackMetal", Amount = 20, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "LinenThread", Amount = 5, UpgradeCost = 5 },
                }
            };
            Loader.AddDefinition(Blackmetal_Bow);

            // Heavy Blood Bone Bow
            ItemDefinition Carapace_Blood_Bow = new ItemDefinition();
            Carapace_Blood_Bow.Name = "Carapace Blood Bow";
            Carapace_Blood_Bow.Category = ItemCategory.Bows;
            Carapace_Blood_Bow.Prefab = "VAHeavy_Blood_Bone_Bow";
            Carapace_Blood_Bow.Icon = "blood_bone_bow_heavy";
            Carapace_Blood_Bow.CraftedAt = "piece_magetable";
            Carapace_Blood_Bow.CraftAmount = 1;
            Carapace_Blood_Bow.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 92, Min =  0, Max =  300 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  50 } },
                { ItemStat.spirit, new ItemStatConfig{ Default_value = 24, Min =  0, Max =  200 } },
                { ItemStat.spirit_per_level, new ItemStatConfig{ Default_value = 2, Min =  0, Max =  50 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  150 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  300 } },
                { ItemStat.draw_stamina_drain, new ItemStatConfig{ Default_value = 6, Min =  1, Max =  50 } },
                { ItemStat.primary_attack_flat_health_cost, new ItemStatConfig{ Default_value = 12, Min =  0, Max =  50 } },
                { ItemStat.primary_attack_percent_health_cost, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.bow_draw_speed, new ItemStatConfig{ Default_value = 2, Min =  0.01f, Max =  2 } },
                { ItemStat.projectile_velocity, new ItemStatConfig{ Default_value = 60, Min =  0, Max =  120 } },
                { ItemStat.projectile_accuracy_max, new ItemStatConfig{ Default_value = 100, Min =  0, Max =  100 } },
            };
            Carapace_Blood_Bow.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "YggdrasilWood", Amount = 14, UpgradeCost = 7 },
                    new RecipeIngredient { Prefab = "Iron", Amount = 10, UpgradeCost = 6 },
                    new RecipeIngredient { Prefab = "Carapace", Amount = 24, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "TrophyTick", Amount = 2, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Eitr", Amount = 0, UpgradeCost = 10 },
                }
            };
            Loader.AddDefinition(Carapace_Blood_Bow);

            // Blood Bone Bow
            ItemDefinition Blood_Bone_Bow = new ItemDefinition();
            Blood_Bone_Bow.Name = "Blood Bone Bow";
            Blood_Bone_Bow.Category = ItemCategory.Bows;
            Blood_Bone_Bow.Prefab = "VABlood_bone_bow";
            Blood_Bone_Bow.Icon = "bone_bow";
            Blood_Bone_Bow.CraftedAt = "forge";
            Blood_Bone_Bow.CraftAmount = 1;
            Blood_Bone_Bow.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 60, Min =  0, Max =  300 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  50 } },
                { ItemStat.spirit, new ItemStatConfig{ Default_value = 18, Min =  0, Max =  200 } },
                { ItemStat.spirit_per_level, new ItemStatConfig{ Default_value = 2, Min =  0, Max =  50 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  150 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  300 } },
                { ItemStat.draw_stamina_drain, new ItemStatConfig{ Default_value = 4, Min =  1, Max =  50 } },
                { ItemStat.primary_attack_flat_health_cost, new ItemStatConfig{ Default_value = 8, Min =  0, Max =  50 } },
                { ItemStat.primary_attack_percent_health_cost, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.bow_draw_speed, new ItemStatConfig{ Default_value = 2, Min =  0.01f, Max =  2 } },
                { ItemStat.projectile_velocity, new ItemStatConfig{ Default_value = 60, Min =  0, Max =  120 } },
                { ItemStat.projectile_accuracy_max, new ItemStatConfig{ Default_value = 100, Min =  0, Max =  100 } },
            };
            Blood_Bone_Bow.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "ElderBark", Amount = 10, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "Silver", Amount = 10, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "BoneFragments", Amount = 20, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "TrophyUlv", Amount = 2, UpgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Blood_Bone_Bow);

            // Bronze Arbalist
            ItemDefinition Bronze_Arbelist = new ItemDefinition();
            Bronze_Arbelist.Name = "Bronze Arbelist";
            Bronze_Arbelist.Category = ItemCategory.Bows;
            Bronze_Arbelist.Prefab = "VAArbalistBronze";
            Bronze_Arbelist.Icon = "bronze_crossbow_upright";
            Bronze_Arbelist.CraftedAt = "forge";
            Bronze_Arbelist.CraftAmount = 1;
            Bronze_Arbelist.Craftable = false;
            Bronze_Arbelist.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 140, Min =  0, Max =  300 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  300 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 100, Min =  0, Max =  300 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.crossbow_reload_speed, new ItemStatConfig{ Default_value = 3.5f, Min =  0.01f, Max =  3.5f } },
                { ItemStat.crossbow_reload_stamina_drain, new ItemStatConfig{ Default_value = 1, Min =  1, Max =  50 } },
                { ItemStat.projectile_velocity, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  300 } },
            };
            Bronze_Arbelist.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "ElderBark", Amount = 10, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "Bronze", Amount = 20, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "JuteRed", Amount = 5, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "Silver", Amount = 2, UpgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Bronze_Arbelist);

            // Iron Crossbow
            ItemDefinition IronCrossbow = new ItemDefinition();
            IronCrossbow.Name = "Iron Crossbow";
            IronCrossbow.Category = ItemCategory.Bows;
            IronCrossbow.Prefab = "VACrossbowIron";
            IronCrossbow.Icon = "iron_crossbow";
            IronCrossbow.CraftedAt = "forge";
            IronCrossbow.CraftAmount = 1;
            IronCrossbow.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 120, Min =  0, Max =  300 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  300 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 100, Min =  0, Max =  300 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.crossbow_reload_speed, new ItemStatConfig{ Default_value = 3.5f, Min =  0.01f, Max =  3.5f } },
                { ItemStat.crossbow_reload_stamina_drain, new ItemStatConfig{ Default_value = 1, Min =  1, Max =  50 } },
                { ItemStat.projectile_velocity, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  300 } },
            };
            IronCrossbow.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "ElderBark", Amount = 5, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "FineWood", Amount = 20, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "Iron", Amount = 10, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "IronNails", Amount = 2, UpgradeCost = 2 },
                }
            };
            Loader.AddDefinition(IronCrossbow);

            // Silver Crossbow
            ItemDefinition SilverCrossbow = new ItemDefinition();
            SilverCrossbow.Name = "Silver Crossbow";
            SilverCrossbow.Category = ItemCategory.Bows;
            SilverCrossbow.Prefab = "VACrossbowSilver";
            SilverCrossbow.Icon = "silver_crossbow";
            SilverCrossbow.CraftedAt = "forge";
            SilverCrossbow.CraftAmount = 1;
            SilverCrossbow.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 140, Min =  0, Max =  300 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  300 } },
                { ItemStat.spirit, new ItemStatConfig{ Default_value = 40, Min =  0, Max =  300 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  300 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 100, Min =  0, Max =  300 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.crossbow_reload_speed, new ItemStatConfig{ Default_value = 3.5f, Min =  0.01f, Max =  3.5f } },
                { ItemStat.crossbow_reload_stamina_drain, new ItemStatConfig{ Default_value = 1, Min =  1, Max =  50 } },
                { ItemStat.projectile_velocity, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  300 } },
            };
            SilverCrossbow.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Guck", Amount = 5, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "ElderBark", Amount = 20, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "Silver", Amount = 12, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "IronNails", Amount = 2, UpgradeCost = 2 },
                }
            };
            Loader.AddDefinition(SilverCrossbow);

            // Blackmetal crossbow
            ItemDefinition BlackmetalCrossbow = new ItemDefinition();
            BlackmetalCrossbow.Name = "Blackmetal Crossbow";
            BlackmetalCrossbow.Category = ItemCategory.Bows;
            BlackmetalCrossbow.Prefab = "VACrossbowBlackmetal";
            BlackmetalCrossbow.Icon = "blackmetal_crossbow";
            BlackmetalCrossbow.CraftedAt = "forge";
            BlackmetalCrossbow.CraftAmount = 1;
            BlackmetalCrossbow.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 180, Min =  0, Max =  300 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  300 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  300 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.crossbow_reload_speed, new ItemStatConfig{ Default_value = 3.5f, Min =  0.01f, Max =  3.5f } },
                { ItemStat.crossbow_reload_stamina_drain, new ItemStatConfig{ Default_value = 1, Min =  1, Max =  50 } },
                { ItemStat.projectile_velocity, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  300 } },
            };
            BlackmetalCrossbow.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "FineWood", Amount = 16, UpgradeCost = 8 },
                    new RecipeIngredient { Prefab = "BlackMetal", Amount = 20, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "LinenThread", Amount = 6, UpgradeCost = 4 },
                    new RecipeIngredient { Prefab = "Iron", Amount = 4, UpgradeCost = 2 },
                }
            };
            Loader.AddDefinition(BlackmetalCrossbow);

            // Antler Bow
            ItemDefinition Eikthyrs_Bow = new ItemDefinition();
            Eikthyrs_Bow.Name = "Eikthyrs Bow";
            Eikthyrs_Bow.Category = ItemCategory.Bows;
            Eikthyrs_Bow.Prefab = "VAAntler_Bow";
            Eikthyrs_Bow.Icon = "antler_bow";
            Eikthyrs_Bow.CraftedAt = "piece_workbench";
            Eikthyrs_Bow.CraftAmount = 1;
            Eikthyrs_Bow.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 26, Min =  0, Max =  120 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 2, Min =  0, Max =  50 } },
                { ItemStat.lightning, new ItemStatConfig{ Default_value = 4, Min =  0, Max =  90 } },
                { ItemStat.lightning_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  50 } },
                { ItemStat.draw_stamina_drain, new ItemStatConfig{ Default_value = 6, Min =  1, Max =  50 } },
                { ItemStat.bow_draw_speed, new ItemStatConfig{ Default_value = 2.5f, Min =  0.01f, Max =  2.5f } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 100, Min =  0, Max =  300 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.projectile_velocity, new ItemStatConfig{ Default_value = 45, Min =  0, Max =  120 } },
                { ItemStat.projectile_accuracy_max, new ItemStatConfig{ Default_value = 100, Min =  0, Max =  100 } },
            };
            Eikthyrs_Bow.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "FineWood", Amount = 15, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "Resin", Amount = 20, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "HardAntler", Amount = 3, UpgradeCost = 3 },
                    new RecipeIngredient { Prefab = "TrophyEikthyr", Amount = 1, UpgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Eikthyrs_Bow);

            // Bronze Crossbow
            ItemDefinition Bronze_Crossbow = new ItemDefinition();
            Bronze_Crossbow.Name = "Bronze Crossbow";
            Bronze_Crossbow.Category = ItemCategory.Bows;
            Bronze_Crossbow.Prefab = "VACrossbowBronze";
            Bronze_Crossbow.Icon = "bronze_crossbow2";
            Bronze_Crossbow.CraftedAt = "forge";
            Bronze_Crossbow.CraftAmount = 1;
            Bronze_Crossbow.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 80, Min =  0, Max =  300 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  50 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  150 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 150, Min =  0, Max =  300 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 100, Min =  0, Max =  300 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.crossbow_reload_speed, new ItemStatConfig{ Default_value = 3.5f, Min =  0.01f, Max =  3.5f } },
                { ItemStat.crossbow_reload_stamina_drain, new ItemStatConfig{ Default_value = 1, Min =  1, Max =  50 } },
                { ItemStat.projectile_velocity, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  300 } },
            };
            Bronze_Crossbow.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "FineWood", Amount = 10, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "RoundLog", Amount = 10, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "Bronze", Amount = 4, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "DeerHide", Amount = 2, UpgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Bronze_Crossbow);

            // Wood Crossbow
            ItemDefinition WoodCrossbow = new ItemDefinition();
            WoodCrossbow.Name = "Wood Crossbow";
            WoodCrossbow.Category = ItemCategory.Bows;
            WoodCrossbow.Prefab = "VACrossbowWood";
            WoodCrossbow.Icon = "woodCrossbow";
            WoodCrossbow.CraftedAt = "piece_workbench";
            WoodCrossbow.CraftAmount = 1;
            WoodCrossbow.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 40, Min =  0, Max =  300 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  50 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  150 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 150, Min =  0, Max =  300 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  300 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.crossbow_reload_speed, new ItemStatConfig{ Default_value = 7f, Min =  0.01f, Max =  10f } },
                { ItemStat.crossbow_reload_stamina_drain, new ItemStatConfig{ Default_value = 1, Min =  1, Max =  50 } },
                { ItemStat.projectile_velocity, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  300 } },
            };
            WoodCrossbow.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Wood", Amount = 30, UpgradeCost = 15 },
                    new RecipeIngredient { Prefab = "Resin", Amount = 10, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "DeerHide", Amount = 2, UpgradeCost = 2 },
                }
            };
            Loader.AddDefinition(WoodCrossbow);

            // Elder Crossbow
            ItemDefinition Elders_Reach = new ItemDefinition();
            Elders_Reach.Name = "Elders Reach";
            Elders_Reach.Category = ItemCategory.Bows;
            Elders_Reach.Prefab = "VACrossbowElder";
            Elders_Reach.Icon = "elder_crossbow";
            Elders_Reach.CraftedAt = "forge";
            Elders_Reach.CraftAmount = 1;
            Elders_Reach.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 80, Min =  0, Max =  300 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  50 } },
                { ItemStat.spirit, new ItemStatConfig{ Default_value = 7, Min =  0, Max =  300 } },
                { ItemStat.spirit_per_level, new ItemStatConfig{ Default_value = 2, Min =  0, Max =  50 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  150 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 150, Min =  0, Max =  300 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 100, Min =  0, Max =  300 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.crossbow_reload_speed, new ItemStatConfig{ Default_value = 3.5f, Min =  0.01f, Max =  3.5f } },
                { ItemStat.crossbow_reload_stamina_drain, new ItemStatConfig{ Default_value = 1, Min =  1, Max =  50 } },
                { ItemStat.projectile_velocity, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  300 } },
            };
            Elders_Reach.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Bronze", Amount = 4, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "RoundLog", Amount = 20, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "CryptKey", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "TrophyTheElder", Amount = 1, UpgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Elders_Reach);

            // Moder Crossbow
            ItemDefinition Moder_Crossbow = new ItemDefinition();
            Moder_Crossbow.Name = "Moder Crossbow";
            Moder_Crossbow.Category = ItemCategory.Bows;
            Moder_Crossbow.Prefab = "VACrossbowModer";
            Moder_Crossbow.Icon = "moder_crossbow";
            Moder_Crossbow.CraftedAt = "forge";
            Moder_Crossbow.CraftAmount = 1;
            Moder_Crossbow.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 150, Min =  0, Max =  300 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  50 } },
                { ItemStat.frost, new ItemStatConfig{ Default_value = 25, Min =  0, Max =  300 } },
                { ItemStat.frost_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  150 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  300 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 100, Min =  0, Max =  300 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.crossbow_reload_speed, new ItemStatConfig{ Default_value = 3.5f, Min =  0.01f, Max =  3.5f } },
                { ItemStat.crossbow_reload_stamina_drain, new ItemStatConfig{ Default_value = 1, Min =  1, Max =  50 } },
                { ItemStat.projectile_velocity, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  300 } },
            };
            Moder_Crossbow.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "ElderBark", Amount = 10, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "Obsidian", Amount = 20, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "DragonTear", Amount = 10, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "TrophyDragonQueen", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Silver", Amount = 0, UpgradeCost = 6 },
                }
            };
            Loader.AddDefinition(Moder_Crossbow);

            // Queen Bow
            ItemDefinition Queens_Greatbow = new ItemDefinition();
            Queens_Greatbow.Name = "Queens Greatbow";
            Queens_Greatbow.Category = ItemCategory.Bows;
            Queens_Greatbow.Prefab = "VAQueen_bow";
            Queens_Greatbow.Icon = "queen_bow";
            Queens_Greatbow.CraftedAt = "blackforge";
            Queens_Greatbow.CraftAmount = 1;
            Queens_Greatbow.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 72, Min =  0, Max =  200 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ Default_value = 25, Min =  0, Max =  90 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.lightning, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  99 } },
                { ItemStat.lightning_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 25, Min =  0, Max =  50 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 100, Min =  0, Max =  300 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.draw_stamina_drain, new ItemStatConfig{ Default_value = 12, Min =  1, Max =  50 } },
                { ItemStat.bow_draw_speed, new ItemStatConfig{ Default_value = 3f, Min =  0.01f, Max =  3f } },
                { ItemStat.projectile_velocity, new ItemStatConfig{ Default_value = 60, Min =  0, Max =  120 } },
                { ItemStat.projectile_accuracy_max, new ItemStatConfig{ Default_value = 100, Min =  0, Max =  100 } },
            };
            Queens_Greatbow.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "YggdrasilWood", Amount = 10, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "Eitr", Amount = 20, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "JuteBlue", Amount = 4, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "TrophySeekerQueen", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Carapace", Amount = 0, UpgradeCost = 4 },
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
            FaderSword.Prefab = "VASwordFader";
            FaderSword.Icon = "fader_sword";
            FaderSword.CraftedAt = "blackforge";
            FaderSword.CraftAmount = 1;
            FaderSword.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ Default_value = 145, Min =  0, Max =  250 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  50 } },
                { ItemStat.fire, new ItemStatConfig{ Default_value = 25, Min =  0, Max =  250 } },
                { ItemStat.fire_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ Default_value = 25, Min =  0, Max =  250 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 55, Min =  0, Max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 60, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 18, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 30, Min =  1, Max =  50 } },
            };
            FaderSword.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "FlametalNew", Amount = 30, UpgradeCost = 30 },
                    new RecipeIngredient { Prefab = "CharredBone", Amount = 30, UpgradeCost = 30 },
                    new RecipeIngredient { Prefab = "TrophyFader", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "FaderDrop", Amount = 1, UpgradeCost = 0 },
                }
            };
            Loader.AddDefinition(FaderSword);

            // Faders Greatsword
            ItemDefinition FaderGreatsword = new ItemDefinition();
            FaderGreatsword.Name = "Faders Greatsword";
            FaderGreatsword.Category = ItemCategory.Swords;
            FaderGreatsword.Prefab = "VAGreatswordFader";
            FaderGreatsword.Icon = "fader_greatsword";
            FaderGreatsword.CraftedAt = "blackforge";
            FaderGreatsword.CraftAmount = 1;
            FaderGreatsword.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ Default_value = 180, Min =  0, Max =  250 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  50 } },
                { ItemStat.fire, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  250 } },
                { ItemStat.fire_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  250 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 55, Min =  0, Max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 60, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 18, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 30, Min =  1, Max =  50 } },
            };
            FaderGreatsword.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "FlametalNew", Amount = 40, UpgradeCost = 20 },
                    new RecipeIngredient { Prefab = "CharredBone", Amount = 20, UpgradeCost = 20 },
                    new RecipeIngredient { Prefab = "TrophyFader", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "FaderDrop", Amount = 1, UpgradeCost = 0 },
                }
            };
            Loader.AddDefinition(FaderGreatsword);

            // Blackmetal Greatsword
            ItemDefinition Blackmetal_Greatsword = new ItemDefinition();
            Blackmetal_Greatsword.Name = "Blackmetal Greatsword";
            Blackmetal_Greatsword.Category = ItemCategory.Swords;
            Blackmetal_Greatsword.Prefab = "VABlackmetal_greatsword";
            Blackmetal_Greatsword.Icon = "blackmetal_greatsword";
            Blackmetal_Greatsword.CraftedAt = "forge";
            Blackmetal_Greatsword.CraftAmount = 1;
            Blackmetal_Greatsword.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ Default_value = 125, Min =  0, Max =  250 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 55, Min =  0, Max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 52, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 18, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 36, Min =  1, Max =  50 } },
            };
            Blackmetal_Greatsword.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "BlackMetal", Amount = 30, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "LinenThread", Amount = 10, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "FineWood", Amount = 6, UpgradeCost = 3 },
                }
            };
            Loader.AddDefinition(Blackmetal_Greatsword);
            // Abyssal Sword
            ItemDefinition Abyssal_Sword = new ItemDefinition();
            Abyssal_Sword.Name = "Abyssal Sword";
            Abyssal_Sword.Category = ItemCategory.Swords;
            Abyssal_Sword.Prefab = "VASwordChitin";
            Abyssal_Sword.Icon = "chitin_sword";
            Abyssal_Sword.CraftedAt = "piece_workbench";
            Abyssal_Sword.CraftAmount = 1;
            Abyssal_Sword.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.blunt, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  90 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ Default_value = 4, Min =  0, Max =  50 } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 25, Min =  0, Max =  120 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 2, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 40, Min =  0, Max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 18, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 10, Min =  1, Max =  30 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 20, Min =  1, Max =  50 } },
            };
            Abyssal_Sword.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "FineWood", Amount = 2, UpgradeCost = 1 },
                    new RecipeIngredient { Prefab = "Chitin", Amount = 30, UpgradeCost = 15 },
                    new RecipeIngredient { Prefab = "DeerHide", Amount = 2, UpgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Abyssal_Sword);

            // Antler Sword
            ItemDefinition Eikthyrs_Sword = new ItemDefinition();
            Eikthyrs_Sword.Name = "Eikthyrs Sword";
            Eikthyrs_Sword.Category = ItemCategory.Swords;
            Eikthyrs_Sword.Prefab = "VAAntler_Sword";
            Eikthyrs_Sword.Icon = "antler_sword";
            Eikthyrs_Sword.CraftedAt = "piece_workbench";
            Eikthyrs_Sword.CraftAmount = 1;
            Eikthyrs_Sword.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ Default_value = 16, Min =  0, Max =  90 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 2, Min =  0, Max =  50 } },
                { ItemStat.blunt, new ItemStatConfig{ Default_value = 8, Min =  0, Max =  90 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ Default_value = 4, Min =  0, Max =  50 } },
                { ItemStat.lightning, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  120 } },
                { ItemStat.lightning_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 40, Min =  0, Max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 8, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 8, Min =  1, Max =  30 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 16, Min =  1, Max =  50 } },
            };
            Eikthyrs_Sword.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "FineWood", Amount = 3, UpgradeCost = 1 },
                    new RecipeIngredient { Prefab = "Resin", Amount = 16, UpgradeCost = 8 },
                    new RecipeIngredient { Prefab = "HardAntler", Amount = 3, UpgradeCost = 3 },
                    new RecipeIngredient { Prefab = "TrophyEikthyr", Amount = 1, UpgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Eikthyrs_Sword);

            // Vine Sword
            ItemDefinition Elders_Balance = new ItemDefinition();
            Elders_Balance.Name = "Elders Balance";
            Elders_Balance.Category = ItemCategory.Swords;
            Elders_Balance.Prefab = "VAVine_Sword";
            Elders_Balance.Icon = "vine_sword";
            Elders_Balance.CraftedAt = "forge";
            Elders_Balance.CraftAmount = 1;
            Elders_Balance.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ Default_value = 40, Min =  0, Max =  90 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.spirit, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  120 } },
                { ItemStat.spirit_per_level, new ItemStatConfig{ Default_value = 2, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 40, Min =  0, Max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 12, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 8, Min =  1, Max =  30 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 16, Min =  1, Max =  50 } },
            };
            Elders_Balance.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Bronze", Amount = 2, UpgradeCost = 1 },
                    new RecipeIngredient { Prefab = "Stone", Amount = 16, UpgradeCost = 8 },
                    new RecipeIngredient { Prefab = "CryptKey", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "TrophyTheElder", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "RoundLog", Amount = 0, UpgradeCost = 4 },
                }
            };
            Loader.AddDefinition(Elders_Balance);

            // Moders Sword
            ItemDefinition Moders_Grasp = new ItemDefinition();
            Moders_Grasp.Name = "Moders Grasp";
            Moders_Grasp.Category = ItemCategory.Swords;
            Moders_Grasp.Prefab = "VASwordModer";
            Moders_Grasp.Icon = "moder_sword";
            Moders_Grasp.CraftedAt = "forge";
            Moders_Grasp.CraftAmount = 1;
            Moders_Grasp.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ Default_value = 35, Min =  0, Max =  90 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 2, Min =  0, Max =  50 } },
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  90 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 4, Min =  0, Max =  50 } },
                { ItemStat.frost, new ItemStatConfig{ Default_value = 25, Min =  0, Max =  120 } },
                { ItemStat.frost_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 40, Min =  0, Max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 12, Min =  1, Max =  30 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 24, Min =  1, Max =  50 } },
            };
            Moders_Grasp.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "ElderBark", Amount = 4, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "Obsidian", Amount = 30, UpgradeCost = 15 },
                    new RecipeIngredient { Prefab = "DragonTear", Amount = 10, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "TrophyDragonQueen", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Silver", Amount = 0, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "JuteRed", Amount = 0, UpgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Moders_Grasp);

            // Moders Greatsword
            ItemDefinition Moders_Greatsword = new ItemDefinition();
            Moders_Greatsword.Name = "Moders Greatsword";
            Moders_Greatsword.Category = ItemCategory.Swords;
            Moders_Greatsword.Prefab = "VAModer_greatsword";
            Moders_Greatsword.Icon = "moder_greatsword";
            Moders_Greatsword.CraftedAt = "forge";
            Moders_Greatsword.CraftAmount = 1;
            Moders_Greatsword.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ Default_value = 55, Min =  0, Max =  90 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 2, Min =  0, Max =  50 } },
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 40, Min =  0, Max =  90 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 4, Min =  0, Max =  50 } },
                { ItemStat.frost, new ItemStatConfig{ Default_value = 25, Min =  0, Max =  120 } },
                { ItemStat.frost_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 55, Min =  0, Max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 48, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 17, Min =  1, Max =  30 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 34, Min =  1, Max =  50 } },
            };
            Moders_Greatsword.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Crystal", Amount = 25, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "Obsidian", Amount = 15, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "DragonTear", Amount = 10, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "TrophyDragonQueen", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Silver", Amount = 0, UpgradeCost = 4 },
                    new RecipeIngredient { Prefab = "JuteRed", Amount = 0, UpgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Moders_Greatsword);

            // Bronze Greatsword
            ItemDefinition Bronze_Greatsword = new ItemDefinition();
            Bronze_Greatsword.Name = "Bronze Greatsword";
            Bronze_Greatsword.Category = ItemCategory.Swords;
            Bronze_Greatsword.Prefab = "VAbronze_greatsword";
            Bronze_Greatsword.Icon = "bronze_greatsword_reforged";
            Bronze_Greatsword.CraftedAt = "forge";
            Bronze_Greatsword.CraftAmount = 1;
            Bronze_Greatsword.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 55, Min =  0, Max =  160 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 16, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 12, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 24, Min =  1, Max =  50 } },
            };
            Bronze_Greatsword.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "RoundLog", Amount = 4, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Bronze", Amount = 20, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "DeerHide", Amount = 3, UpgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Bronze_Greatsword);

            // Iron Greatsword
            ItemDefinition Iron_Greatsword = new ItemDefinition();
            Iron_Greatsword.Name = "Iron Greatsword";
            Iron_Greatsword.Category = ItemCategory.Swords;
            Iron_Greatsword.Prefab = "VAiron_greatsword";
            Iron_Greatsword.Icon = "iron_greatsword_reforged";
            Iron_Greatsword.CraftedAt = "forge";
            Iron_Greatsword.CraftAmount = 1;
            Iron_Greatsword.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ Default_value = 75, Min =  0, Max =  250 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 55, Min =  0, Max =  160 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 28, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 14, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 28, Min =  1, Max =  50 } },
            };
            Iron_Greatsword.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "ElderBark", Amount = 15, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "Iron", Amount = 30, UpgradeCost = 15 },
                    new RecipeIngredient { Prefab = "LeatherScraps", Amount = 4, UpgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Iron_Greatsword);

            // Silver Greatsword
            ItemDefinition Silver_Greatsword = new ItemDefinition();
            Silver_Greatsword.Name = "Silver Greatsword";
            Silver_Greatsword.Category = ItemCategory.Swords;
            Silver_Greatsword.Prefab = "VAsilver_greatsword";
            Silver_Greatsword.Icon = "silver_greatsword_reforged";
            Silver_Greatsword.CraftedAt = "forge";
            Silver_Greatsword.CraftAmount = 1;
            Silver_Greatsword.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ Default_value = 100, Min =  0, Max =  300 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.spirit, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  120 } },
                { ItemStat.spirit_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 55, Min =  0, Max =  160 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 40, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 16, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 32, Min =  1, Max =  50 } },
            };
            Silver_Greatsword.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Wood", Amount = 10, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "Silver", Amount = 45, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "Iron", Amount = 5, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "LeatherScraps", Amount = 3, UpgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Silver_Greatsword);

            // Bonemass Greatsword
            ItemDefinition Bm_sword = new ItemDefinition();
            Bm_sword.Name = "Bonemasses Sword";
            Bm_sword.Category = ItemCategory.Swords;
            Bm_sword.Prefab = "VABonemassSword";
            Bm_sword.Icon = "bonemass_sword";
            Bm_sword.CraftedAt = "forge";
            Bm_sword.CraftAmount = 1;
            Bm_sword.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ Default_value = 65, Min =  0, Max =  250 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  250 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 55, Min =  0, Max =  160 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 45, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 15, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 30, Min =  1, Max =  50 } },
            };
            Bm_sword.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "WitheredBone", Amount = 10, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "Iron", Amount = 22, UpgradeCost = 15 },
                    new RecipeIngredient { Prefab = "Wishbone", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "TrophyBonemass", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "ElderBark", Amount = 0, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "LeatherScraps", Amount = 0, UpgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Bm_sword);

            // Bonemass Greatsword
            ItemDefinition Bonemasses_Greatsword = new ItemDefinition();
            Bonemasses_Greatsword.Name = "Bonemasses Greatsword";
            Bonemasses_Greatsword.Category = ItemCategory.Swords;
            Bonemasses_Greatsword.Prefab = "VABonemassGreatsword";
            Bonemasses_Greatsword.Icon = "bonemass_greatsword";
            Bonemasses_Greatsword.CraftedAt = "forge";
            Bonemasses_Greatsword.CraftAmount = 1;
            Bonemasses_Greatsword.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ Default_value = 75, Min =  0, Max =  250 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  250 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 55, Min =  0, Max =  160 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 36, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 15, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 30, Min =  1, Max =  50 } },
            };
            Bonemasses_Greatsword.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "WitheredBone", Amount = 15, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "Iron", Amount = 30, UpgradeCost = 15 },
                    new RecipeIngredient { Prefab = "Wishbone", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "TrophyBonemass", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "ElderBark", Amount = 0, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "LeatherScraps", Amount = 0, UpgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Bonemasses_Greatsword);

            // Yagluth Greatsword
            ItemDefinition Yagluths_Greatsword = new ItemDefinition();
            Yagluths_Greatsword.Name = "Yagluths Greatsword";
            Yagluths_Greatsword.Category = ItemCategory.Swords;
            Yagluths_Greatsword.Prefab = "VAYagluth_greatsword";
            Yagluths_Greatsword.Icon = "yagluth_greatsword";
            Yagluths_Greatsword.CraftedAt = "forge";
            Yagluths_Greatsword.CraftAmount = 1;
            Yagluths_Greatsword.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ Default_value = 125, Min =  0, Max =  250 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.fire, new ItemStatConfig{ Default_value = 25, Min =  0, Max =  250 } },
                { ItemStat.fire_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 55, Min =  0, Max =  160 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 49, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 18, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 36, Min =  1, Max =  50 } },
            };
            Yagluths_Greatsword.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "BlackMetal", Amount = 10, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "Iron", Amount = 4, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "YagluthDrop", Amount = 2, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "TrophyGoblinKing", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Tar", Amount = 0, UpgradeCost = 3 },
                    new RecipeIngredient { Prefab = "LinenThread", Amount = 0, UpgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Yagluths_Greatsword);

            // Flint Sword
            ItemDefinition Flint_Sword = new ItemDefinition();
            Flint_Sword.Name = "Flint Sword";
            Flint_Sword.Category = ItemCategory.Swords;
            Flint_Sword.Prefab = "VAFlint_Sword";
            Flint_Sword.Icon = "flint_sword";
            Flint_Sword.CraftedAt = "piece_workbench";
            Flint_Sword.CraftAmount = 1;
            Flint_Sword.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ Default_value = 15, Min =  0, Max =  90 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 40, Min =  0, Max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 4, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 6, Min =  1, Max =  30 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 12, Min =  1, Max =  50 } },
            };
            Flint_Sword.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Wood", Amount = 2, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Flint", Amount = 6, UpgradeCost = 3 },
                    new RecipeIngredient { Prefab = "LeatherScraps", Amount = 0, UpgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Flint_Sword);

            // Flint Greatsword
            ItemDefinition Flint_Greatsword = new ItemDefinition();
            Flint_Greatsword.Name = "Flint Greatsword";
            Flint_Greatsword.Category = ItemCategory.Swords;
            Flint_Greatsword.Prefab = "VAFlint_greatsword";
            Flint_Greatsword.Icon = "flint_greatsword";
            Flint_Greatsword.CraftedAt = "piece_workbench";
            Flint_Greatsword.CraftAmount = 1;
            Flint_Greatsword.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ Default_value = 25, Min =  0, Max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 55, Min =  0, Max =  160 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 14, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 10, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 20, Min =  1, Max =  50 } },
            };
            Flint_Greatsword.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Wood", Amount = 4, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Flint", Amount = 9, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "LeatherScraps", Amount = 0, UpgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Flint_Greatsword);

            // Queen Greatsword
            ItemDefinition Queen_Greatsword = new ItemDefinition();
            Queen_Greatsword.Name = "Queen Greatsword";
            Queen_Greatsword.Category = ItemCategory.Swords;
            Queen_Greatsword.Prefab = "VAQueen_greatsword";
            Queen_Greatsword.Icon = "queen_greatsword";
            Queen_Greatsword.CraftedAt = "blackforge";
            Queen_Greatsword.CraftAmount = 1;
            Queen_Greatsword.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ Default_value = 125, Min =  0, Max =  250 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ Default_value = 25, Min =  0, Max =  250 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.lightning, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  99 } },
                { ItemStat.lightning_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 55, Min =  0, Max =  160 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 62, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 20, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 40, Min =  1, Max =  50 } },
            };
            Queen_Greatsword.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "YggdrasilWood", Amount = 10, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "Eitr", Amount = 20, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "JuteBlue", Amount = 4, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "TrophySeekerQueen", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Carapace", Amount = 0, UpgradeCost = 8 },
                }
            };
            Loader.AddDefinition(Queen_Greatsword);

            // Queen sword
            ItemDefinition Queen_Sword = new ItemDefinition();
            Queen_Sword.Name = "Queen Sword";
            Queen_Sword.Category = ItemCategory.Swords;
            Queen_Sword.Prefab = "VASwordQueen";
            Queen_Sword.Icon = "queen_sword";
            Queen_Sword.CraftedAt = "blackforge";
            Queen_Sword.CraftAmount = 1;
            Queen_Sword.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.slash, new ItemStatConfig{ Default_value = 95, Min =  0, Max =  250 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ Default_value = 25, Min =  0, Max =  250 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.lightning, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  99 } },
                { ItemStat.lightning_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 40, Min =  0, Max =  160 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 52, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 16, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 32, Min =  1, Max =  50 } },
            };
            Queen_Sword.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "YggdrasilWood", Amount = 3, UpgradeCost = 1 },
                    new RecipeIngredient { Prefab = "Eitr", Amount = 10, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "JuteBlue", Amount = 3, UpgradeCost = 1 },
                    new RecipeIngredient { Prefab = "TrophySeekerQueen", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Carapace", Amount = 0, UpgradeCost = 6 },
                }
            };
            Loader.AddDefinition(Queen_Sword);
        }

        private void LoadAxes()
        {
            Logger.LogInfo("Loading Axes");

            
            // Flint Axe
            ItemDefinition FlintAxe = new ItemDefinition();
            FlintAxe.Name = "Flint axe";
            FlintAxe.Category = ItemCategory.Axes;
            FlintAxe.Prefab = "VAFlint_Axe";
            FlintAxe.Icon = "flint_axe";
            FlintAxe.CraftedAt = "piece_workbench";
            FlintAxe.CraftAmount = 1;
            FlintAxe.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.tool_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  6, IsInt = true } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 4, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 100, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 6, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 12, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.05f, Min =  -0.15f, Max =  0 } },
            };
            FlintAxe.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Wood", Amount = 4, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Flint", Amount = 6, UpgradeCost = 3 },
                    new RecipeIngredient { Prefab = "LeatherScraps", Amount = 0, UpgradeCost = 2 },
                }
            };
            Loader.AddDefinition(FlintAxe);

            // Flint Battleaxe
            ItemDefinition Flint_greataxe = new ItemDefinition();
            Flint_greataxe.Name = "Flint greataxe";
            Flint_greataxe.Category = ItemCategory.Axes;
            Flint_greataxe.Prefab = "VAFlint_greataxe";
            Flint_greataxe.Icon = "flint_greataxe";
            Flint_greataxe.CraftedAt = "piece_workbench";
            Flint_greataxe.CraftAmount = 1;
            Flint_greataxe.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.tool_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  6, IsInt = true } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 25, Min =  0, Max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ Default_value = 45, Min =  0, Max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 70, Min =  0, Max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 14, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 70, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 12, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 6, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.15f, Min =  -0.15f, Max =  0 } },
            };
            Flint_greataxe.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Wood", Amount = 8, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Flint", Amount = 9, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "LeatherScraps", Amount = 0, UpgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Flint_greataxe);

            // Flint Dualaxes
            ItemDefinition Flint_dualaxes = new ItemDefinition();
            Flint_dualaxes.Name = "Flint dualaxes";
            Flint_dualaxes.Category = ItemCategory.Axes;
            Flint_dualaxes.Prefab = "VAFlint_dualaxes";
            Flint_dualaxes.Icon = "flint_dualaxes";
            Flint_dualaxes.CraftedAt = "piece_workbench";
            Flint_dualaxes.CraftAmount = 1;
            Flint_dualaxes.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.tool_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  6, IsInt = true } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 12, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 175, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 6, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 14, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.05f, Min =  -0.20f, Max =  0 } },
            };
            Flint_dualaxes.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Wood", Amount = 10, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "Flint", Amount = 12, UpgradeCost = 6 },
                    new RecipeIngredient { Prefab = "LeatherScraps", Amount = 0, UpgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Flint_dualaxes);

            // Bronze Battleaxe
            ItemDefinition Bronze_Lumber_Axe = new ItemDefinition();
            Bronze_Lumber_Axe.Name = "Bronze Lumber Axe";
            Bronze_Lumber_Axe.Category = ItemCategory.Axes;
            Bronze_Lumber_Axe.Prefab = "VAbronze_battleaxe";
            Bronze_Lumber_Axe.Icon = "bronze_axe_rebuild";
            Bronze_Lumber_Axe.CraftedAt = "forge";
            Bronze_Lumber_Axe.CraftAmount = 1;
            Bronze_Lumber_Axe.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.tool_level, new ItemStatConfig{ Default_value = 2, Min =  0, Max =  6, IsInt = true } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ Default_value = 2.5f, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 70, Min =  0, Max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 18, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 70, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 14, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 7, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.15f, Min =  -0.15f, Max =  0 } },
            };
            Bronze_Lumber_Axe.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "RoundLog", Amount = 20, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "Bronze", Amount = 10, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "DeerHide", Amount = 2, UpgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Bronze_Lumber_Axe);

            // Bronze Dualaxes
            ItemDefinition Bronze_dualaxes = new ItemDefinition();
            Bronze_dualaxes.Name = "Bronze dualaxes";
            Bronze_dualaxes.Category = ItemCategory.Axes;
            Bronze_dualaxes.Prefab = "VABronze_dualaxes";
            Bronze_dualaxes.Icon = "bronze_dualaxes";
            Bronze_dualaxes.CraftedAt = "forge";
            Bronze_dualaxes.CraftAmount = 1;
            Bronze_dualaxes.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.tool_level, new ItemStatConfig{ Default_value = 2, Min =  0, Max =  6, IsInt = true } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 40, Min =  0, Max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 16, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 175, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 10, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 16, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.05f, Min =  -0.20f, Max =  0 } },
            };
            Bronze_dualaxes.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Wood", Amount = 8, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Bronze", Amount = 16, UpgradeCost = 8 },
                    new RecipeIngredient { Prefab = "LeatherScraps", Amount = 4, UpgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Bronze_dualaxes);

            // Iron Dualaxes
            ItemDefinition Iron_dualaxes = new ItemDefinition();
            Iron_dualaxes.Name = "Iron dualaxes";
            Iron_dualaxes.Category = ItemCategory.Axes;
            Iron_dualaxes.Prefab = "VAIron_dualaxes";
            Iron_dualaxes.Icon = "iron_dualaxes";
            Iron_dualaxes.CraftedAt = "forge";
            Iron_dualaxes.CraftAmount = 1;
            Iron_dualaxes.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.tool_level, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  6, IsInt = true } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 60, Min =  0, Max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 21, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 175, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 12, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 18, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.05f, Min =  -0.20f, Max =  0 } },
            };
            Iron_dualaxes.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "ElderBark", Amount = 8, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Iron", Amount = 40, UpgradeCost = 20 },
                    new RecipeIngredient { Prefab = "LeatherScraps", Amount = 4, UpgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Iron_dualaxes);

            // Bonemass Axe
            ItemDefinition Bonemass_Axe = new ItemDefinition();
            Bonemass_Axe.Name = "Bonemasses Axe";
            Bonemass_Axe.Category = ItemCategory.Axes;
            Bonemass_Axe.Prefab = "VABone_axe";
            Bonemass_Axe.Icon = "bonemass_axe";
            Bonemass_Axe.CraftedAt = "forge";
            Bonemass_Axe.CraftAmount = 1;
            Bonemass_Axe.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.tool_level, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  6, IsInt = true } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 70, Min =  0, Max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  200 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ Default_value = 45, Min =  0, Max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 80, Min =  0, Max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 26, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 175, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 12, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 24, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.05f, Min =  -0.20f, Max =  0 } },
            };
            Bonemass_Axe.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "WitheredBone", Amount = 6, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "Iron", Amount = 20, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "Wishbone", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "TrophyBonemass", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "LeatherScraps", Amount = 0, UpgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Bonemass_Axe);


            // Bonemass Dualaxes
            ItemDefinition BonemassDualaxes = new ItemDefinition();
            BonemassDualaxes.Name = "Bonemasses Dualaxes";
            BonemassDualaxes.Category = ItemCategory.Axes;
            BonemassDualaxes.Prefab = "VABone_dualaxes";
            BonemassDualaxes.Icon = "bonerot_dualaxes";
            BonemassDualaxes.CraftedAt = "forge";
            BonemassDualaxes.CraftAmount = 1;
            BonemassDualaxes.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.tool_level, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  6, IsInt = true } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 70, Min =  0, Max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  200 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ Default_value = 45, Min =  0, Max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 26, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 175, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 12, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 19, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.05f, Min =  -0.20f, Max =  0 } },
            };
            BonemassDualaxes.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "WitheredBone", Amount = 12, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "Iron", Amount = 40, UpgradeCost = 20 },
                    new RecipeIngredient { Prefab = "Wishbone", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "TrophyBonemass", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "LeatherScraps", Amount = 0, UpgradeCost = 4 },
                }
            };
            Loader.AddDefinition(BonemassDualaxes);
            

            // Crystal Axe
            ItemDefinition Crystal_Axe = new ItemDefinition();
            Crystal_Axe.Name = "Crystal Axe";
            Crystal_Axe.Category = ItemCategory.Axes;
            Crystal_Axe.Prefab = "VAcrystal_axe";
            Crystal_Axe.Icon = "silver_axe_1h_icon";
            Crystal_Axe.CraftedAt = "forge";
            Crystal_Axe.CraftAmount = 1;
            Crystal_Axe.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.tool_level, new ItemStatConfig{ Default_value = 4, Min =  0, Max =  6, IsInt = true } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 80, Min =  0, Max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.spirit, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  200 } },
                { ItemStat.spirit_per_level, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ Default_value = 45, Min =  0, Max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 80, Min =  0, Max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 26, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 175, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 12, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 24, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.05f, Min =  -0.20f, Max =  0 } },
            };
            Crystal_Axe.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "ElderBark", Amount = 15, UpgradeCost = 4 },
                    new RecipeIngredient { Prefab = "Silver", Amount = 20, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "Crystal", Amount = 8, UpgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Crystal_Axe);

            // Crystal dual Axes
            ItemDefinition Crystal_dualaxes = new ItemDefinition();
            Crystal_dualaxes.Name = "Crystal dualaxes";
            Crystal_dualaxes.Category = ItemCategory.Axes;
            Crystal_dualaxes.Prefab = "VACrystal_dualaxes";
            Crystal_dualaxes.Icon = "crystal_dualaxes";
            Crystal_dualaxes.CraftedAt = "forge";
            Crystal_dualaxes.CraftAmount = 1;
            Crystal_dualaxes.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.tool_level, new ItemStatConfig{ Default_value = 4, Min =  0, Max =  6, IsInt = true } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 80, Min =  0, Max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.spirit, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  200 } },
                { ItemStat.spirit_per_level, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 175, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 12, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 20, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.05f, Min =  -0.20f, Max =  0 } },
            };
            Crystal_dualaxes.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "ElderBark", Amount = 30, UpgradeCost = 8 },
                    new RecipeIngredient { Prefab = "Silver", Amount = 50, UpgradeCost = 20 },
                    new RecipeIngredient { Prefab = "Crystal", Amount = 16, UpgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Crystal_dualaxes);

            // Moder Axe
            ItemDefinition Moder_Axe = new ItemDefinition();
            Moder_Axe.Name = "Dragonfrost Axe";
            Moder_Axe.Category = ItemCategory.Axes;
            Moder_Axe.Prefab = "VAModer_Axe";
            Moder_Axe.Icon = "moder_axe_1h";
            Moder_Axe.CraftedAt = "forge";
            Moder_Axe.CraftAmount = 1;
            Moder_Axe.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.tool_level, new ItemStatConfig{ Default_value = 4, Min =  0, Max =  6, IsInt = true } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 80, Min =  0, Max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.frost, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  200 } },
                { ItemStat.frost_per_level, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ Default_value = 45, Min =  0, Max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 80, Min =  0, Max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 26, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 175, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 12, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 24, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.05f, Min =  -0.20f, Max =  0 } },
            };
            Moder_Axe.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "DragonTear", Amount = 10, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "TrophyDragonQueen", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Silver", Amount = 15, UpgradeCost = 15 },
                    new RecipeIngredient { Prefab = "FineWood", Amount = 8, UpgradeCost = 4 },
                }
            };
            Loader.AddDefinition(Moder_Axe);

            // Moder Dualaxes
            ItemDefinition Moder_Dualaxes = new ItemDefinition();
            Moder_Dualaxes.Name = "Moder dualaxes";
            Moder_Dualaxes.Category = ItemCategory.Axes;
            Moder_Dualaxes.Prefab = "VAModer_dualaxes";
            Moder_Dualaxes.Icon = "moder_dualaxes";
            Moder_Dualaxes.CraftedAt = "forge";
            Moder_Dualaxes.CraftAmount = 1;
            Moder_Dualaxes.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.tool_level, new ItemStatConfig{ Default_value = 4, Min =  0, Max =  6, IsInt = true } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 80, Min =  0, Max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.frost, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  200 } },
                { ItemStat.frost_per_level, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 175, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 12, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 20, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.05f, Min =  -0.20f, Max =  0 } },
            };
            Moder_Dualaxes.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "DragonTear", Amount = 10, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "TrophyDragonQueen", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Silver", Amount = 30, UpgradeCost = 30 },
                    new RecipeIngredient { Prefab = "FineWood", Amount = 16, UpgradeCost = 8 },
                }
            };
            Loader.AddDefinition(Moder_Dualaxes);

            // Blackmetal Dual Axes
            ItemDefinition Blackmetal_dualaxes = new ItemDefinition();
            Blackmetal_dualaxes.Name = "Blackmetal dualaxes";
            Blackmetal_dualaxes.Category = ItemCategory.Axes;
            Blackmetal_dualaxes.Prefab = "VABlackmetal_dualaxes";
            Blackmetal_dualaxes.Icon = "blackmetal_dualaxes";
            Blackmetal_dualaxes.CraftedAt = "forge";
            Blackmetal_dualaxes.CraftAmount = 1;
            Blackmetal_dualaxes.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.tool_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  6, IsInt = true } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 100, Min =  0, Max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ Default_value = 60, Min =  0, Max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 39, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 175, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 14, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 22, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.05f, Min =  -0.20f, Max =  0 } },
            };
            Blackmetal_dualaxes.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "BlackMetal", Amount = 50, UpgradeCost = 20 },
                    new RecipeIngredient { Prefab = "FineWood", Amount = 14, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "LinenThread", Amount = 8, UpgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Blackmetal_dualaxes);

            // Blackmetal Greataxe
            ItemDefinition Blackmetal_Greataxe = new ItemDefinition();
            Blackmetal_Greataxe.Name = "Blackmetal Greataxe (Legacy)";
            Blackmetal_Greataxe.Category = ItemCategory.Axes;
            Blackmetal_Greataxe.Prefab = "VAblackmetal_2h_axe";
            Blackmetal_Greataxe.Icon = "blackmetal_2h_axe";
            Blackmetal_Greataxe.CraftedAt = "forge";
            Blackmetal_Greataxe.CraftAmount = 1;
            Blackmetal_Greataxe.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.tool_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  6, IsInt = true } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 130, Min =  0, Max =  300 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ Default_value = 60, Min =  0, Max =  300 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ Default_value = 2.5f, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 70, Min =  0, Max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 52, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 70, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 20, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 10, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.15f, Min =  -0.15f, Max =  0 } },
            };
            Blackmetal_Greataxe.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "FineWood", Amount = 10, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "BlackMetal", Amount = 35, UpgradeCost = 15 },
                    new RecipeIngredient { Prefab = "LinenThread", Amount = 5, UpgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Blackmetal_Greataxe);

            // Jotun Dual Axes
            ItemDefinition Jotun_dualaxes = new ItemDefinition();
            Jotun_dualaxes.Name = "Jotun dualaxes";
            Jotun_dualaxes.Category = ItemCategory.Axes;
            Jotun_dualaxes.Prefab = "VAJotunn_dualaxes";
            Jotun_dualaxes.Icon = "jotun_dualaxes";
            Jotun_dualaxes.CraftedAt = "blackforge";
            Jotun_dualaxes.CraftAmount = 1;
            Jotun_dualaxes.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.tool_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  6, IsInt = true } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 120, Min =  0, Max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  200 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ Default_value = 80, Min =  0, Max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 48, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 175, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 15, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 24, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.05f, Min =  -0.20f, Max =  0 } },
            };
            Jotun_dualaxes.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Eitr", Amount = 35, UpgradeCost = 30 },
                    new RecipeIngredient { Prefab = "Iron", Amount = 25, UpgradeCost = 20 },
                    new RecipeIngredient { Prefab = "YggdrasilWood", Amount = 14, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "Bilebag", Amount = 6, UpgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Jotun_dualaxes);

            // Jotun 2H Axe
            ItemDefinition Jotun_battleaxe = new ItemDefinition();
            Jotun_battleaxe.Name = "Jotun battleaxe";
            Jotun_battleaxe.Category = ItemCategory.Axes;
            Jotun_battleaxe.Prefab = "VAJotunn_2h_axe";
            Jotun_battleaxe.Icon = "jotun_2h_axe";
            Jotun_battleaxe.CraftedAt = "blackforge";
            Jotun_battleaxe.CraftAmount = 1;
            Jotun_battleaxe.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.tool_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  6, IsInt = true } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 140, Min =  0, Max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ Default_value = 13, Min =  0, Max =  200 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ Default_value = 90, Min =  0, Max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 72, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 175, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 22, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 11, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.05f, Min =  -0.20f, Max =  0 } },
            };
            Jotun_battleaxe.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Eitr", Amount = 30, UpgradeCost = 20 },
                    new RecipeIngredient { Prefab = "Iron", Amount = 20, UpgradeCost = 15 },
                    new RecipeIngredient { Prefab = "YggdrasilWood", Amount = 14, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "Bilebag", Amount = 6, UpgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Jotun_battleaxe);

            // Jotunn halfblade
            ItemDefinition Jotun_halfblade = new ItemDefinition();
            Jotun_halfblade.Name = "Jotun halfblade";
            Jotun_halfblade.Category = ItemCategory.Axes;
            Jotun_halfblade.Prefab = "VAJotunn_single_axe";
            Jotun_halfblade.Icon = "jotunn_halfblade";
            Jotun_halfblade.CraftedAt = "blackforge";
            Jotun_halfblade.CraftAmount = 1;
            Jotun_halfblade.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.tool_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  6, IsInt = true } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 80, Min =  0, Max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ Default_value = 40, Min =  0, Max =  200 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ Default_value = 70, Min =  0, Max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 48, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 175, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 16, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 32, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.05f, Min =  -0.20f, Max =  0 } },
            };
            Jotun_halfblade.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Eitr", Amount = 10, UpgradeCost = 1 },
                    new RecipeIngredient { Prefab = "Iron", Amount = 15, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "YggdrasilWood", Amount = 5, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Bilebag", Amount = 3, UpgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Jotun_halfblade);

            // Antler Battleaxe
            ItemDefinition Eikthyrs_Greataxe = new ItemDefinition();
            Eikthyrs_Greataxe.Name = "Eikthyrs Greataxe";
            Eikthyrs_Greataxe.Category = ItemCategory.Axes;
            Eikthyrs_Greataxe.Prefab = "VAAntler_greataxe";
            Eikthyrs_Greataxe.Icon = "antler_greataxe";
            Eikthyrs_Greataxe.CraftedAt = "piece_workbench";
            Eikthyrs_Greataxe.CraftAmount = 1;
            Eikthyrs_Greataxe.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.tool_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  6, IsInt = true } },
                { ItemStat.blunt, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  200 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ Default_value = 2, Min =  0, Max =  50 } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 25, Min =  0, Max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 2, Min =  0, Max =  50 } },
                { ItemStat.lightning, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  200 } },
                { ItemStat.lightning_per_level, new ItemStatConfig{ Default_value = 2, Min =  0, Max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ Default_value = 2.5f, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 70, Min =  0, Max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 18, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 70, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 14, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 7, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.15f, Min =  -0.15f, Max =  0 } },
            };
            Eikthyrs_Greataxe.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "FineWood", Amount = 15, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Resin", Amount = 30, UpgradeCost = 15 },
                    new RecipeIngredient { Prefab = "HardAntler", Amount = 3, UpgradeCost = 3 },
                    new RecipeIngredient { Prefab = "TrophyEikthyr", Amount = 1, UpgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Eikthyrs_Greataxe);

            // Blackmetal Battleaxe
            ItemDefinition Blackmetal_Battleaxe = new ItemDefinition();
            Blackmetal_Battleaxe.Name = "Blackmetal Battleaxe";
            Blackmetal_Battleaxe.Category = ItemCategory.Axes;
            Blackmetal_Battleaxe.Prefab = "VAblackmetal_battleaxe";
            Blackmetal_Battleaxe.Icon = "blackmetal_battleaxe";
            Blackmetal_Battleaxe.CraftedAt = "forge";
            Blackmetal_Battleaxe.CraftAmount = 1;
            Blackmetal_Battleaxe.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.tool_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  6, IsInt = true } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 120, Min =  0, Max =  300 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ Default_value = 60, Min =  0, Max =  300 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ Default_value = 2.5f, Min =  0, Max =  50 } },
                { ItemStat.fire, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  160 } },
                { ItemStat.fire_per_level, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 70, Min =  0, Max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 52, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 70, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 22, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 10, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.15f, Min =  -0.15f, Max =  0 } },
            };
            Blackmetal_Battleaxe.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "FineWood", Amount = 10, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "BlackMetal", Amount = 35, UpgradeCost = 15 },
                    new RecipeIngredient { Prefab = "LinenThread", Amount = 5, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "SurtlingCore", Amount = 4, UpgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Blackmetal_Battleaxe);

            // Flametal Battleaxe
            ItemDefinition Flametal_Battleaxe = new ItemDefinition();
            Flametal_Battleaxe.Name = "Flametal Battleaxe";
            Flametal_Battleaxe.Category = ItemCategory.Axes;
            Flametal_Battleaxe.Prefab = "VAFlametalAxe_2h";
            Flametal_Battleaxe.Icon = "flametal_battleaxe";
            Flametal_Battleaxe.CraftedAt = "blackforge";
            Flametal_Battleaxe.CraftAmount = 1;
            Flametal_Battleaxe.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.tool_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  6, IsInt = true } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 150, Min =  0, Max =  300 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ Default_value = 90, Min =  0, Max =  300 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ Default_value = 2.5f, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 70, Min =  0, Max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 78, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 70, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 28, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 14, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.15f, Min =  -0.15f, Max =  0 } },
            };
            Flametal_Battleaxe.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Blackwood", Amount = 10, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "FlametalNew", Amount = 20, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "CharredBone", Amount = 20, UpgradeCost = 15 },
                    new RecipeIngredient { Prefab = "AskHide", Amount = 4, UpgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Flametal_Battleaxe);

            // Flametal Primal Battleaxe
            ItemDefinition Flametal_Primal_Battleaxe = new ItemDefinition();
            Flametal_Primal_Battleaxe.Name = "Flametal Primal Battleaxe";
            Flametal_Primal_Battleaxe.Category = ItemCategory.Axes;
            Flametal_Primal_Battleaxe.Prefab = "VAFlametalAxe_primal_2h";
            Flametal_Primal_Battleaxe.Icon = "flametal_battleaxe_primal";
            Flametal_Primal_Battleaxe.CraftedAt = "blackforge";
            Flametal_Primal_Battleaxe.CraftAmount = 1;
            Flametal_Primal_Battleaxe.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.tool_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  6, IsInt = true } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 150, Min =  0, Max =  300 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ Default_value = 25, Min =  0, Max =  300 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ Default_value = 90, Min =  0, Max =  300 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ Default_value = 2.5f, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 70, Min =  0, Max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 78, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 70, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 28, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 14, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.15f, Min =  -0.15f, Max =  0 } },
            };
            Flametal_Primal_Battleaxe.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "VAFlametalAxe_2h", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Blackwood", Amount = 5, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "FlametalNew", Amount = 10, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "GemstoneGreen", Amount = 1, UpgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Flametal_Primal_Battleaxe);

            // Flametal Lightning Battleaxe
            ItemDefinition Flametal_Lightning_Battleaxe = new ItemDefinition();
            Flametal_Lightning_Battleaxe.Name = "Flametal Lightning Battleaxe";
            Flametal_Lightning_Battleaxe.Category = ItemCategory.Axes;
            Flametal_Lightning_Battleaxe.Prefab = "VAFlametalAxe_lightning_2h";
            Flametal_Lightning_Battleaxe.Icon = "flametal_battleaxe_lightning";
            Flametal_Lightning_Battleaxe.CraftedAt = "blackforge";
            Flametal_Lightning_Battleaxe.CraftAmount = 1;
            Flametal_Lightning_Battleaxe.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.tool_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  6, IsInt = true } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 150, Min =  0, Max =  300 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.lightning, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  300 } },
                { ItemStat.lightning_per_level, new ItemStatConfig{ Default_value = 2, Min =  0, Max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ Default_value = 90, Min =  0, Max =  300 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ Default_value = 2.5f, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 70, Min =  0, Max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 78, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 70, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 28, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 14, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.15f, Min =  -0.15f, Max =  0 } },
            };
            Flametal_Lightning_Battleaxe.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "VAFlametalAxe_2h", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Blackwood", Amount = 5, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "FlametalNew", Amount = 10, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "GemstoneBlue", Amount = 1, UpgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Flametal_Lightning_Battleaxe);

            // Flametal Blood Battleaxe
            ItemDefinition Flametal_Blood_Battleaxe = new ItemDefinition();
            Flametal_Blood_Battleaxe.Name = "Flametal Blood Battleaxe";
            Flametal_Blood_Battleaxe.Category = ItemCategory.Axes;
            Flametal_Blood_Battleaxe.Prefab = "VAFlametalAxe_blood_2h";
            Flametal_Blood_Battleaxe.Icon = "flametal_battleaxe_blood";
            Flametal_Blood_Battleaxe.CraftedAt = "blackforge";
            Flametal_Blood_Battleaxe.CraftAmount = 1;
            Flametal_Blood_Battleaxe.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.tool_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  6, IsInt = true } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 150, Min =  0, Max =  300 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ Default_value = 90, Min =  0, Max =  300 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ Default_value = 2.5f, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 70, Min =  0, Max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 78, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 70, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 28, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 14, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.15f, Min =  -0.15f, Max =  0 } },
            };
            Flametal_Blood_Battleaxe.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "VAFlametalAxe_2h", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Blackwood", Amount = 5, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "FlametalNew", Amount = 10, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "GemstoneRed", Amount = 1, UpgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Flametal_Blood_Battleaxe);

            // Flametal Axe
            ItemDefinition Flametal_Axe = new ItemDefinition();
            Flametal_Axe.Name = "Flametal Axe";
            Flametal_Axe.Category = ItemCategory.Axes;
            Flametal_Axe.Prefab = "VAFlametal_Axe";
            Flametal_Axe.Icon = "flametalAxeBase";
            Flametal_Axe.CraftedAt = "blackforge";
            Flametal_Axe.CraftAmount = 1;
            Flametal_Axe.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.tool_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  6, IsInt = true } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 140, Min =  0, Max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ Default_value = 80, Min =  0, Max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 84, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 175, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 18, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 36, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.05f, Min =  -0.20f, Max =  0 } },
            };
            Flametal_Axe.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "FlametalNew", Amount = 12, UpgradeCost = 6 },
                    new RecipeIngredient { Prefab = "AskHide", Amount = 4, UpgradeCost = 1 },
                    new RecipeIngredient { Prefab = "CharredBone", Amount = 10, UpgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Flametal_Axe);

            // Flametal Primal Axe
            ItemDefinition Flametal_Primal_Axe = new ItemDefinition();
            Flametal_Primal_Axe.Name = "Flametal Primal Axe";
            Flametal_Primal_Axe.Category = ItemCategory.Axes;
            Flametal_Primal_Axe.Prefab = "VAFlametal_Axe_Primal";
            Flametal_Primal_Axe.Icon = "flametal_axe_1h_primal";
            Flametal_Primal_Axe.CraftedAt = "blackforge";
            Flametal_Primal_Axe.CraftAmount = 1;
            Flametal_Primal_Axe.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.tool_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  6, IsInt = true } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 140, Min =  0, Max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ Default_value = 25, Min =  0, Max =  300 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ Default_value = 80, Min =  0, Max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 84, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 175, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 18, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 36, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.05f, Min =  -0.20f, Max =  0 } },
            };
            Flametal_Primal_Axe.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "FlametalNew", Amount = 12, UpgradeCost = 6 },
                    new RecipeIngredient { Prefab = "GemstoneGreen", Amount = 1, UpgradeCost = 1 },
                    new RecipeIngredient { Prefab = "CharredBone", Amount = 10, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "VAFlametal_Axe", Amount = 1, UpgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Flametal_Primal_Axe);

            // Flametal Lightning Axe
            ItemDefinition Flametal_Lightning_Axe = new ItemDefinition();
            Flametal_Lightning_Axe.Name = "Flametal Lightning Axe";
            Flametal_Lightning_Axe.Category = ItemCategory.Axes;
            Flametal_Lightning_Axe.Prefab = "VAFlametal_Axe_Lightning";
            Flametal_Lightning_Axe.Icon = "flametal_axe_1h_lightning";
            Flametal_Lightning_Axe.CraftedAt = "blackforge";
            Flametal_Lightning_Axe.CraftAmount = 1;
            Flametal_Lightning_Axe.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.tool_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  6, IsInt = true } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 140, Min =  0, Max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.lightning, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  300 } },
                { ItemStat.lightning_per_level, new ItemStatConfig{ Default_value = 2, Min =  0, Max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ Default_value = 80, Min =  0, Max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 84, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 175, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 18, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 36, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.05f, Min =  -0.20f, Max =  0 } },
            };
            Flametal_Lightning_Axe.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "FlametalNew", Amount = 12, UpgradeCost = 6 },
                    new RecipeIngredient { Prefab = "GemstoneBlue", Amount = 1, UpgradeCost = 1 },
                    new RecipeIngredient { Prefab = "CharredBone", Amount = 10, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "VAFlametal_Axe", Amount = 1, UpgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Flametal_Lightning_Axe);

            // Flametal Blood Axe
            ItemDefinition Flametal_Blood_Axe = new ItemDefinition();
            Flametal_Blood_Axe.Name = "Flametal Blood Axe";
            Flametal_Blood_Axe.Category = ItemCategory.Axes;
            Flametal_Blood_Axe.Prefab = "VAFlametal_Axe_Blood";
            Flametal_Blood_Axe.Icon = "flametal_axe_1h_blood";
            Flametal_Blood_Axe.CraftedAt = "blackforge";
            Flametal_Blood_Axe.CraftAmount = 1;
            Flametal_Blood_Axe.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.tool_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  6, IsInt = true } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 140, Min =  0, Max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.chop, new ItemStatConfig{ Default_value = 80, Min =  0, Max =  200 } },
                { ItemStat.chop_per_level, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  200 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 84, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 175, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 18, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 36, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.05f, Min =  -0.20f, Max =  0 } },
            };
            Flametal_Blood_Axe.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "FlametalNew", Amount = 12, UpgradeCost = 6 },
                    new RecipeIngredient { Prefab = "GemstoneRed", Amount = 1, UpgradeCost = 1 },
                    new RecipeIngredient { Prefab = "CharredBone", Amount = 10, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "VAFlametal_Axe", Amount = 1, UpgradeCost = 0 },
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
            Flametal_nature_sledge.Prefab = "VAflametal_sledge_nature";
            Flametal_nature_sledge.Icon = "flametal_sledge_nature";
            Flametal_nature_sledge.CraftedAt = "blackforge";
            Flametal_nature_sledge.CraftAmount = 1;
            Flametal_nature_sledge.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.blunt, new ItemStatConfig{ Default_value = 165, Min =  0, Max =  300 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ Default_value = 25, Min =  0, Max =  300 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 100, Min =  0, Max =  400 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 64, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 100, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 24, Min =  1, Max =  50 } },
                { ItemStat.primary_attack_force_multiply, new ItemStatConfig{ Default_value = 1, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 30, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_force_multiply, new ItemStatConfig{ Default_value = 2.5f, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.15f, Min =  -0.15f, Max =  0 } },
            };
            Flametal_nature_sledge.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "VAflametal_sledge", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "FlametalNew", Amount = 8, UpgradeCost = 8 },
                    new RecipeIngredient { Prefab = "Blackwood", Amount = 5, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "GemstoneGreen", Amount = 1, UpgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Flametal_nature_sledge);

            // Flametal Lightning Sledge
            ItemDefinition Flametal_lightning_sledge = new ItemDefinition();
            Flametal_lightning_sledge.Name = "Flametal lightning sledge";
            Flametal_lightning_sledge.Category = ItemCategory.Hammers;
            Flametal_lightning_sledge.Prefab = "VAflametal_sledge_lightning";
            Flametal_lightning_sledge.Icon = "flametal_sledge_lightning";
            Flametal_lightning_sledge.CraftedAt = "blackforge";
            Flametal_lightning_sledge.CraftAmount = 1;
            Flametal_lightning_sledge.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.blunt, new ItemStatConfig{ Default_value = 165, Min =  0, Max =  300 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.lightning, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  300 } },
                { ItemStat.lightning_per_level, new ItemStatConfig{ Default_value = 2, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 100, Min =  0, Max =  400 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 64, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 100, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 24, Min =  1, Max =  50 } },
                { ItemStat.primary_attack_force_multiply, new ItemStatConfig{ Default_value = 1, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 30, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_force_multiply, new ItemStatConfig{ Default_value = 2.5f, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.15f, Min =  -0.15f, Max =  0 } },
            };
            Flametal_lightning_sledge.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "VAflametal_sledge", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "FlametalNew", Amount = 8, UpgradeCost = 8 },
                    new RecipeIngredient { Prefab = "Blackwood", Amount = 5, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "GemstoneBlue", Amount = 1, UpgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Flametal_lightning_sledge);

            // Flametal Blood Sledge
            ItemDefinition Flametal_blood_sledge = new ItemDefinition();
            Flametal_blood_sledge.Name = "Flametal blood sledge";
            Flametal_blood_sledge.Category = ItemCategory.Hammers;
            Flametal_blood_sledge.Prefab = "VAflametal_sledge_blood";
            Flametal_blood_sledge.Icon = "flametal_sledge_blood";
            Flametal_blood_sledge.CraftedAt = "blackforge";
            Flametal_blood_sledge.CraftAmount = 1;
            Flametal_blood_sledge.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.blunt, new ItemStatConfig{ Default_value = 175, Min =  0, Max =  300 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 100, Min =  0, Max =  400 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 64, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 100, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 24, Min =  1, Max =  50 } },
                { ItemStat.primary_attack_force_multiply, new ItemStatConfig{ Default_value = 1, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 30, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_force_multiply, new ItemStatConfig{ Default_value = 2.5f, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.15f, Min =  -0.15f, Max =  0 } },
            };
            Flametal_blood_sledge.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "VAflametal_sledge", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "FlametalNew", Amount = 8, UpgradeCost = 8 },
                    new RecipeIngredient { Prefab = "Blackwood", Amount = 5, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "GemstoneRed", Amount = 1, UpgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Flametal_blood_sledge);

            // Flametal Sledge
            ItemDefinition Flametal_sledge = new ItemDefinition();
            Flametal_sledge.Name = "Flametal sledge";
            Flametal_sledge.Category = ItemCategory.Hammers;
            Flametal_sledge.Prefab = "VAflametal_sledge";
            Flametal_sledge.Icon = "flametal_sledge";
            Flametal_sledge.CraftedAt = "blackforge";
            Flametal_sledge.CraftAmount = 1;
            Flametal_sledge.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.blunt, new ItemStatConfig{ Default_value = 165, Min =  0, Max =  300 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 100, Min =  0, Max =  400 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 64, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 100, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 24, Min =  1, Max =  50 } },
                { ItemStat.primary_attack_force_multiply, new ItemStatConfig{ Default_value = 1, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 30, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_force_multiply, new ItemStatConfig{ Default_value = 2.5f, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.15f, Min =  -0.15f, Max =  0 } },
            };
            Flametal_sledge.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "FlametalNew", Amount = 30, UpgradeCost = 15 },
                    new RecipeIngredient { Prefab = "Iron", Amount = 4, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Eitr", Amount = 6, UpgradeCost = 3 },
                    new RecipeIngredient { Prefab = "Blackwood", Amount = 12, UpgradeCost = 6 },
                }
            };
            Loader.AddDefinition(Flametal_sledge);

            // Blackmarble mace
            ItemDefinition Blackmarble_mace = new ItemDefinition();
            Blackmarble_mace.Name = "Blackmarble mace";
            Blackmarble_mace.Category = ItemCategory.Hammers;
            Blackmarble_mace.Prefab = "VAmistland_mace";
            Blackmarble_mace.Icon = "mist_mace";
            Blackmarble_mace.CraftedAt = "blackforge";
            Blackmarble_mace.CraftAmount = 1;
            Blackmarble_mace.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.blunt, new ItemStatConfig{ Default_value = 115, Min =  0, Max =  300 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 40, Min =  0, Max =  400 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 48, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 100, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 15, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 28, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.05f, Min =  -0.05f, Max =  0 } },
            };
            Blackmarble_mace.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "YggdrasilWood", Amount = 6, UpgradeCost = 4 },
                    new RecipeIngredient { Prefab = "Bronze", Amount = 10, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "Eitr", Amount = 8, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "BlackMarble", Amount = 20, UpgradeCost = 10 },
                }
            };
            Loader.AddDefinition(Blackmarble_mace);

            // Blackmetal Sledge
            ItemDefinition Blackmetal_Sledge = new ItemDefinition();
            Blackmetal_Sledge.Name = "Blackmetal Sledge";
            Blackmetal_Sledge.Category = ItemCategory.Hammers;
            Blackmetal_Sledge.Prefab = "VAblackmetal_sledge";
            Blackmetal_Sledge.Icon = "blackmetal_hammer";
            Blackmetal_Sledge.CraftedAt = "forge";
            Blackmetal_Sledge.CraftAmount = 1;
            Blackmetal_Sledge.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.blunt, new ItemStatConfig{ Default_value = 120, Min =  0, Max =  300 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.lightning, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  120 } },
                { ItemStat.lightning_per_level, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 100, Min =  0, Max =  400 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 49, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 20, Min =  1, Max =  50 } },
                { ItemStat.primary_attack_force_multiply, new ItemStatConfig{ Default_value = 1, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 40, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_force_multiply, new ItemStatConfig{ Default_value = 2.5f, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.15f, Min =  -0.15f, Max =  0 } },
            };
            Blackmetal_Sledge.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "FineWood", Amount = 10, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "BlackMetal", Amount = 30, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "LinenThread", Amount = 5, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Thunderstone", Amount = 4, UpgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Blackmetal_Sledge);

            // Elder Sledge
            ItemDefinition Elders_Rock = new ItemDefinition();
            Elders_Rock.Name = "Elders Rock";
            Elders_Rock.Category = ItemCategory.Hammers;
            Elders_Rock.Prefab = "VAElderHammer";
            Elders_Rock.Icon = "elder_hammer";
            Elders_Rock.CraftedAt = "forge";
            Elders_Rock.CraftAmount = 1;
            Elders_Rock.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.blunt, new ItemStatConfig{ Default_value = 35, Min =  0, Max =  300 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.spirit, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  99 } },
                { ItemStat.spirit_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 80, Min =  0, Max =  400 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 22, Min =  0, Max =  150 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 12, Min =  1, Max =  50 } },
                { ItemStat.primary_attack_force_multiply, new ItemStatConfig{ Default_value = 1, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 22, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_force_multiply, new ItemStatConfig{ Default_value = 2.5f, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.15f, Min =  -0.15f, Max =  0 } },
            };
            Elders_Rock.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Bronze", Amount = 4, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "Stone", Amount = 30, UpgradeCost = 15 },
                    new RecipeIngredient { Prefab = "CryptKey", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "TrophyTheElder", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "RoundLog", Amount = 0, UpgradeCost = 8 },
                }
            };
            Loader.AddDefinition(Elders_Rock);

            // Bronze sledge
            ItemDefinition Bronze_Sledge = new ItemDefinition();
            Bronze_Sledge.Name = "Bronze Sledge";
            Bronze_Sledge.Category = ItemCategory.Hammers;
            Bronze_Sledge.Prefab = "VABronzeSledge";
            Bronze_Sledge.Icon = "bronze_sledge";
            Bronze_Sledge.CraftedAt = "forge";
            Bronze_Sledge.CraftAmount = 1;
            Bronze_Sledge.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.blunt, new ItemStatConfig{ Default_value = 35, Min =  0, Max =  300 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 80, Min =  0, Max =  400 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 22, Min =  0, Max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 12, Min =  1, Max =  50 } },
                { ItemStat.primary_attack_force_multiply, new ItemStatConfig{ Default_value = 1, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 22, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_force_multiply, new ItemStatConfig{ Default_value = 2.5f, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.15f, Min =  -0.15f, Max =  0 } },
            };
            Bronze_Sledge.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Bronze", Amount = 8, UpgradeCost = 4 },
                    new RecipeIngredient { Prefab = "Stone", Amount = 25, UpgradeCost = 15 },
                    new RecipeIngredient { Prefab = "TrollHide", Amount = 6, UpgradeCost = 3 },
                    new RecipeIngredient { Prefab = "RoundLog", Amount = 4, UpgradeCost = 4 },
                }
            };
            Loader.AddDefinition(Bronze_Sledge);

            // Bonemass Warhammer
            ItemDefinition Bonemasses_Rage = new ItemDefinition();
            Bonemasses_Rage.Name = "Bonemasses Rage";
            Bonemasses_Rage.Category = ItemCategory.Hammers;
            Bonemasses_Rage.Prefab = "VABonemassWarhammer";
            Bonemasses_Rage.Icon = "bonemass_warhammer";
            Bonemasses_Rage.CraftedAt = "forge";
            Bonemasses_Rage.CraftAmount = 1;
            Bonemasses_Rage.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.blunt, new ItemStatConfig{ Default_value = 70, Min =  0, Max =  300 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  99 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 90, Min =  0, Max =  400 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 31, Min =  0, Max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 14, Min =  1, Max =  50 } },
                { ItemStat.primary_attack_force_multiply, new ItemStatConfig{ Default_value = 1, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 24, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_force_multiply, new ItemStatConfig{ Default_value = 2.5f, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.15f, Min =  -0.15f, Max =  0 } },
            };
            Bonemasses_Rage.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "WitheredBone", Amount = 10, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "Iron", Amount = 30, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "Wishbone", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "TrophyBonemass", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "ElderBark", Amount = 0, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "LeatherScraps", Amount = 0, UpgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Bonemasses_Rage);

            // Silver sledge
            ItemDefinition Silver_Sledge = new ItemDefinition();
            Silver_Sledge.Name = "Silver Sledge";
            Silver_Sledge.Category = ItemCategory.Hammers;
            Silver_Sledge.Prefab = "VASilverSledge";
            Silver_Sledge.Icon = "silver_sledge";
            Silver_Sledge.CraftedAt = "forge";
            Silver_Sledge.CraftAmount = 1;
            Silver_Sledge.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.blunt, new ItemStatConfig{ Default_value = 85, Min =  0, Max =  300 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.spirit, new ItemStatConfig{ Default_value = 25, Min =  0, Max =  99 } },
                { ItemStat.spirit_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 100, Min =  0, Max =  400 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 31, Min =  0, Max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 15, Min =  1, Max =  50 } },
                { ItemStat.primary_attack_force_multiply, new ItemStatConfig{ Default_value = 1, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 24, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_force_multiply, new ItemStatConfig{ Default_value = 2.5f, Min =  1, Max =  50 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.15f, Min =  -0.15f, Max =  0 } },
            };
            Silver_Sledge.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "RoundLog", Amount = 10, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "Silver", Amount = 30, UpgradeCost = 15 },
                    new RecipeIngredient { Prefab = "YmirRemains", Amount = 4, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "TrophyFenring", Amount = 1, UpgradeCost = 1 },
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
            Flint_Atgeir.Prefab = "VAAtgeir_Flint";
            Flint_Atgeir.Icon = "flint_atgeir";
            Flint_Atgeir.CraftedAt = "piece_workbench";
            Flint_Atgeir.CraftAmount = 1;
            Flint_Atgeir.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 25, Min =  0, Max =  90 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 11, Min =  0, Max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 125, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 10, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 20, Min =  1, Max =  50 } },
            };
            Flint_Atgeir.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Wood", Amount = 10, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Flint", Amount = 6, UpgradeCost = 3 },
                    new RecipeIngredient { Prefab = "LeatherScraps", Amount = 0, UpgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Flint_Atgeir);

            // Antler Atgeir
            ItemDefinition Eikthyrs_Atgeir = new ItemDefinition();
            Eikthyrs_Atgeir.Name = "Eikthyrs Atgeir";
            Eikthyrs_Atgeir.Category = ItemCategory.Atgeirs;
            Eikthyrs_Atgeir.Prefab = "VAatgeir_antler";
            Eikthyrs_Atgeir.Icon = "antler_atgeir";
            Eikthyrs_Atgeir.CraftedAt = "piece_workbench";
            Eikthyrs_Atgeir.CraftAmount = 1;
            Eikthyrs_Atgeir.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 35, Min =  0, Max =  90 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.lightning, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  50 } },
                { ItemStat.lightning_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 14, Min =  0, Max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 175, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 12, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 24, Min =  1, Max =  50 } },
            };
            Eikthyrs_Atgeir.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "FineWood", Amount = 15, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Resin", Amount = 30, UpgradeCost = 15 },
                    new RecipeIngredient { Prefab = "HardAntler", Amount = 3, UpgradeCost = 3 },
                    new RecipeIngredient { Prefab = "TrophyEikthyr", Amount = 1, UpgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Eikthyrs_Atgeir);

            // Abyssal Atgeir
            ItemDefinition Abyssal_Atgeir = new ItemDefinition();
            Abyssal_Atgeir.Name = "Abyssal Atgeir";
            Abyssal_Atgeir.Category = ItemCategory.Atgeirs;
            Abyssal_Atgeir.Prefab = "VAAtgeirChitin";
            Abyssal_Atgeir.Icon = "chitin_heavy_atgeir_small2";
            Abyssal_Atgeir.CraftedAt = "piece_workbench";
            Abyssal_Atgeir.CraftAmount = 1;
            Abyssal_Atgeir.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 35, Min =  0, Max =  140 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 2, Min =  0, Max =  50 } },
                { ItemStat.blunt, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  120 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ Default_value = 4, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 21, Min =  0, Max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 175, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 14, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 28, Min =  1, Max =  50 } },
            };
            Abyssal_Atgeir.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "FineWood", Amount = 10, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Chitin", Amount = 30, UpgradeCost = 15 },
                    new RecipeIngredient { Prefab = "DeerHide", Amount = 2, UpgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Abyssal_Atgeir);

            // Silver Atgeir
            ItemDefinition Silver_Atgeir = new ItemDefinition();
            Silver_Atgeir.Name = "Silver Atgeir";
            Silver_Atgeir.Category = ItemCategory.Atgeirs;
            Silver_Atgeir.Prefab = "VASilverAtgeir";
            Silver_Atgeir.Icon = "silver_atgeir";
            Silver_Atgeir.CraftedAt = "forge";
            Silver_Atgeir.CraftAmount = 1;
            Silver_Atgeir.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 85, Min =  0, Max =  250 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.spirit, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  120 } },
                { ItemStat.spirit_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 40, Min =  0, Max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 175, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 16, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 32, Min =  1, Max =  50 } },
            };
            Silver_Atgeir.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Wood", Amount = 10, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Silver", Amount = 25, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "Iron", Amount = 4, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "LeatherScraps", Amount = 3, UpgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Silver_Atgeir);

            // Yagluth Atgeir
            ItemDefinition Yagluths_Reach = new ItemDefinition();
            Yagluths_Reach.Name = "Yagluths Reach";
            Yagluths_Reach.Category = ItemCategory.Atgeirs;
            Yagluths_Reach.Prefab = "VAYagluthAtgeir";
            Yagluths_Reach.Icon = "yagluth_atgeir";
            Yagluths_Reach.CraftedAt = "forge";
            Yagluths_Reach.CraftAmount = 1;
            Yagluths_Reach.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 105, Min =  0, Max =  250 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  50 } },
                { ItemStat.fire, new ItemStatConfig{ Default_value = 25, Min =  0, Max =  120 } },
                { ItemStat.fire_per_level, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 52, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 175, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 18, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 36, Min =  1, Max =  50 } },
            };
            Yagluths_Reach.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "BlackMetal", Amount = 10, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Iron", Amount = 4, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "YagluthDrop", Amount = 2, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "TrophyGoblinKing", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Tar", Amount = 0, UpgradeCost = 3 },
                    new RecipeIngredient { Prefab = "LinenThread", Amount = 0, UpgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Yagluths_Reach);

            // Meteor atgeir
            ItemDefinition Flametal_Atgeir = new ItemDefinition();
            Flametal_Atgeir.Name = "Flametal Atgeir";
            Flametal_Atgeir.Category = ItemCategory.Atgeirs;
            Flametal_Atgeir.Prefab = "VAMeteorAtgeir";
            Flametal_Atgeir.Icon = "meteor_atgeir";
            Flametal_Atgeir.CraftedAt = "blackforge";
            Flametal_Atgeir.CraftAmount = 1;
            Flametal_Atgeir.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 145, Min =  0, Max =  300 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 64, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 175, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 22, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 42, Min =  1, Max =  50 } },
            };
            Flametal_Atgeir.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "FlametalNew", Amount = 15, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "Iron", Amount = 4, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "Blackwood", Amount = 10, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "MorgenSinew", Amount = 2, UpgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Flametal_Atgeir);

            // Meteor primal atgeir
            ItemDefinition Flametal_primal_Atgeir = new ItemDefinition();
            Flametal_primal_Atgeir.Name = "Flametal primal Atgeir";
            Flametal_primal_Atgeir.Category = ItemCategory.Atgeirs;
            Flametal_primal_Atgeir.Prefab = "VAMeteorAtgeir_nature";
            Flametal_primal_Atgeir.Icon = "meteor_atgeir_nature";
            Flametal_primal_Atgeir.CraftedAt = "blackforge";
            Flametal_primal_Atgeir.CraftAmount = 1;
            Flametal_primal_Atgeir.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 145, Min =  0, Max =  300 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  300 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 64, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 175, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 22, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 42, Min =  1, Max =  50 } },
            };
            Flametal_primal_Atgeir.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "VAMeteorAtgeir", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "FlametalNew", Amount = 8, UpgradeCost = 8 },
                    new RecipeIngredient { Prefab = "Blackwood", Amount = 5, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "GemstoneGreen", Amount = 1, UpgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Flametal_primal_Atgeir);

            // Meteor lightning atgeir
            ItemDefinition Flametal_lightning_Atgeir = new ItemDefinition();
            Flametal_lightning_Atgeir.Name = "Flametal lightning Atgeir";
            Flametal_lightning_Atgeir.Category = ItemCategory.Atgeirs;
            Flametal_lightning_Atgeir.Prefab = "VAMeteorAtgeir_lightning";
            Flametal_lightning_Atgeir.Icon = "meteor_atgeir_lightning";
            Flametal_lightning_Atgeir.CraftedAt = "blackforge";
            Flametal_lightning_Atgeir.CraftAmount = 1;
            Flametal_lightning_Atgeir.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 145, Min =  0, Max =  300 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.lightning, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  300 } },
                { ItemStat.lightning_per_level, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 64, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 175, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 22, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 42, Min =  1, Max =  50 } },
            };
            Flametal_lightning_Atgeir.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "VAMeteorAtgeir", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "FlametalNew", Amount = 8, UpgradeCost = 8 },
                    new RecipeIngredient { Prefab = "Blackwood", Amount = 5, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "GemstoneBlue", Amount = 1, UpgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Flametal_lightning_Atgeir);

            // Meteor blood atgeir
            ItemDefinition Flametal_blood_Atgeir = new ItemDefinition();
            Flametal_blood_Atgeir.Name = "Flametal blood Atgeir";
            Flametal_blood_Atgeir.Category = ItemCategory.Atgeirs;
            Flametal_blood_Atgeir.Prefab = "VAMeteorAtgeir_blood";
            Flametal_blood_Atgeir.Icon = "meteor_atgeir_blood";
            Flametal_blood_Atgeir.CraftedAt = "blackforge";
            Flametal_blood_Atgeir.CraftAmount = 1;
            Flametal_blood_Atgeir.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 145, Min =  0, Max =  300 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 52, Min =  0, Max =  120 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 175, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 22, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 42, Min =  1, Max =  50 } },
            };
            Flametal_blood_Atgeir.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "VAMeteorAtgeir", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "FlametalNew", Amount = 8, UpgradeCost = 8 },
                    new RecipeIngredient { Prefab = "Blackwood", Amount = 5, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "GemstoneRed", Amount = 1, UpgradeCost = 1 },
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
            Serpent_Scale_Buckler.Prefab = "VAserpent_buckler";
            Serpent_Scale_Buckler.Icon = "serpentscale_shield2";
            Serpent_Scale_Buckler.CraftedAt = "forge";
            Serpent_Scale_Buckler.CraftAmount = 1;
            Serpent_Scale_Buckler.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 48, Min =  0, Max =  120 } },
                { ItemStat.block_armor_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 40, Min =  0, Max =  120 } },
                { ItemStat.parry, new ItemStatConfig{ Default_value = 2.5f, Min =  0, Max =  3 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 250, Min =  0, Max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.05f, Min =  -0.30f, Max =  0 } },
            };
            Serpent_Scale_Buckler.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "FineWood", Amount = 8, UpgradeCost = 8 },
                    new RecipeIngredient { Prefab = "Iron", Amount = 2, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "SerpentScale", Amount = 6, UpgradeCost = 3 },
                }
            };
            Serpent_Scale_Buckler.DamageMods = new Dictionary<HitData.DamageType, HitCustomDamageMod>
            {
                { HitData.DamageType.Pierce, new HitCustomDamageMod { DamageModifier = HitData.DamageModifier.Resistant } }
            };
            Loader.AddDefinition(Serpent_Scale_Buckler);

            // Elder Round Shield
            ItemDefinition Elders_Bulwark = new ItemDefinition();
            Elders_Bulwark.Name = "Elders Bulwark";
            Elders_Bulwark.Category = ItemCategory.Shields;
            Elders_Bulwark.Prefab = "VAElderRoundShield";
            Elders_Bulwark.Icon = "elder_roundshield";
            Elders_Bulwark.CraftedAt = "forge";
            Elders_Bulwark.CraftAmount = 1;
            Elders_Bulwark.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 28, Min =  0, Max =  120 } },
                { ItemStat.block_armor_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  120 } },
                { ItemStat.block_force_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  30 } },
                { ItemStat.parry, new ItemStatConfig{ Default_value = 1.5f, Min =  0, Max =  3 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 250, Min =  0, Max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.05f, Min =  -0.30f, Max =  0 } },
            };
            Elders_Bulwark.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Wood", Amount = 16, UpgradeCost = 8 },
                    new RecipeIngredient { Prefab = "Bronze", Amount = 8, UpgradeCost = 4 },
                    new RecipeIngredient { Prefab = "CryptKey", Amount = 1, UpgradeCost = 1 },
                    new RecipeIngredient { Prefab = "TrophyTheElder", Amount = 1, UpgradeCost = 1 },
                }
            };
            Elders_Bulwark.DamageMods = new Dictionary<HitData.DamageType, HitCustomDamageMod>
            {
                { HitData.DamageType.Blunt, new HitCustomDamageMod { DamageModifier = HitData.DamageModifier.Resistant } }
            };
            Loader.AddDefinition(Elders_Bulwark);

            // Moder Round Shield
            ItemDefinition Moders_Roundshield = new ItemDefinition();
            Moders_Roundshield.Name = "Moders Roundshield";
            Moders_Roundshield.Category = ItemCategory.Shields;
            Moders_Roundshield.Prefab = "VAModer_RoundShield";
            Moders_Roundshield.Icon = "moder_roundshield";
            Moders_Roundshield.CraftedAt = "forge";
            Moders_Roundshield.CraftAmount = 1;
            Moders_Roundshield.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 62, Min =  0, Max =  120 } },
                { ItemStat.block_armor_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 40, Min =  0, Max =  120 } },
                { ItemStat.block_force_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  30 } },
                { ItemStat.parry, new ItemStatConfig{ Default_value = 1.5f, Min =  0, Max =  3 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 250, Min =  0, Max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.05f, Min =  -0.30f, Max =  0 } },
            };
            Moders_Roundshield.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "FineWood", Amount = 24, UpgradeCost = 12 },
                    new RecipeIngredient { Prefab = "Silver", Amount = 16, UpgradeCost = 8 },
                    new RecipeIngredient { Prefab = "DragonTear", Amount = 10, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "TrophyDragonQueen", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Obsidian", Amount = 0, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "JuteRed", Amount = 0, UpgradeCost = 2 },
                }
            };
            Moders_Roundshield.DamageMods = new Dictionary<HitData.DamageType, HitCustomDamageMod>
            {
                { HitData.DamageType.Frost, new HitCustomDamageMod { DamageModifier = HitData.DamageModifier.Resistant } }
            };
            Loader.AddDefinition(Moders_Roundshield);

            // Moder Tower Shield
            ItemDefinition Moders_Shield = new ItemDefinition();
            Moders_Shield.Name = "Moders Shield";
            Moders_Shield.Category = ItemCategory.Shields;
            Moders_Shield.Prefab = "VAModer_shield";
            Moders_Shield.Icon = "modershiled_v2";
            Moders_Shield.CraftedAt = "forge";
            Moders_Shield.CraftAmount = 1;
            Moders_Shield.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 100, Min =  0, Max =  180 } },
                { ItemStat.block_armor_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 120, Min =  0, Max =  200 } },
                { ItemStat.block_force_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  30 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 250, Min =  0, Max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.15f, Min =  -0.15f, Max =  0 } },
            };
            Moders_Shield.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "FineWood", Amount = 24, UpgradeCost = 12 },
                    new RecipeIngredient { Prefab = "Silver", Amount = 16, UpgradeCost = 8 },
                    new RecipeIngredient { Prefab = "DragonTear", Amount = 10, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "TrophyDragonQueen", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Obsidian", Amount = 0, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "JuteRed", Amount = 0, UpgradeCost = 2 },
                }
            };
            Moders_Shield.DamageMods = new Dictionary<HitData.DamageType, HitCustomDamageMod>
            {
                { HitData.DamageType.Frost, new HitCustomDamageMod { DamageModifier = HitData.DamageModifier.Resistant } }
            };
            Loader.AddDefinition(Moders_Shield);

            // Silver Wolf tower shield
            ItemDefinition Silver_Wolf_Towershield = new ItemDefinition();
            Silver_Wolf_Towershield.Name = "Silver Wolf Towershield";
            Silver_Wolf_Towershield.Category = ItemCategory.Shields;
            Silver_Wolf_Towershield.Prefab = "VAsilver_tower";
            Silver_Wolf_Towershield.Icon = "silver_tower_shield";
            Silver_Wolf_Towershield.CraftedAt = "forge";
            Silver_Wolf_Towershield.CraftAmount = 1;
            Silver_Wolf_Towershield.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 78, Min =  0, Max =  120 } },
                { ItemStat.block_armor_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 120, Min =  0, Max =  200 } },
                { ItemStat.block_force_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  30 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.15f, Min =  -0.15f, Max =  0 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 250, Min =  0, Max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
            };
            Silver_Wolf_Towershield.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "FineWood", Amount = 15, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "Silver", Amount = 10, UpgradeCost = 6 },
                    new RecipeIngredient { Prefab = "TrophyUlv", Amount = 1, UpgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Silver_Wolf_Towershield);

            // Dverger tower shield
            ItemDefinition dverger_tower_shield = new ItemDefinition();
            dverger_tower_shield.Name = "Dverger Towershield";
            dverger_tower_shield.Category = ItemCategory.Shields;
            dverger_tower_shield.Prefab = "VAdverger_tower";
            dverger_tower_shield.Icon = "dverger_towershield";
            dverger_tower_shield.CraftedAt = "blackforge";
            dverger_tower_shield.CraftAmount = 1;
            dverger_tower_shield.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 122, Min =  0, Max =  200 } },
                { ItemStat.block_armor_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.block_force, new ItemStatConfig{ Default_value = 150, Min =  0, Max =  200 } },
                { ItemStat.block_force_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  30 } },
                { ItemStat.movement_speed, new ItemStatConfig{ Default_value = -0.15f, Min =  -0.15f, Max =  0 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
            };
            dverger_tower_shield.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "BlackMarble", Amount = 20, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "YggdrasilWood", Amount = 12, UpgradeCost = 6 },
                    new RecipeIngredient { Prefab = "BlackCore", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Copper", Amount = 14, UpgradeCost = 10 },
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
            Hati_Knife.Prefab = "VAdagger_blackmetal_mistlands";
            Hati_Knife.Icon = "hatti_knife";
            Hati_Knife.CraftedAt = "blackforge";
            Hati_Knife.CraftAmount = 1;
            Hati_Knife.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 4, Min =  0, Max =  48 } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 39, Min =  0, Max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 39, Min =  0, Max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  40 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 14, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 38, Min =  1, Max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
            };
            Hati_Knife.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "FineWood", Amount = 4, UpgradeCost = 4 },
                    new RecipeIngredient { Prefab = "BlackMetal", Amount = 8, UpgradeCost = 4 },
                    new RecipeIngredient { Prefab = "Iron", Amount = 2, UpgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Hati_Knife);

            // Blackmetal 2H Daggers
            ItemDefinition Blackmetal_knives = new ItemDefinition();
            Blackmetal_knives.Name = "Blackmetal knives";
            Blackmetal_knives.Category = ItemCategory.Knives;
            Blackmetal_knives.Prefab = "VAknife_blackmetal";
            Blackmetal_knives.Icon = "2h_blackmetal_knives";
            Blackmetal_knives.CraftedAt = "forge";
            Blackmetal_knives.CraftAmount = 1;
            Blackmetal_knives.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  48 } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 39, Min =  0, Max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 39, Min =  0, Max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  40 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 12, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 12, Min =  1, Max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
            };
            Blackmetal_knives.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "FineWood", Amount = 8, UpgradeCost = 4 },
                    new RecipeIngredient { Prefab = "BlackMetal", Amount = 20, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "LinenThread", Amount = 10, UpgradeCost = 5 },
                }
            };
            Loader.AddDefinition(Blackmetal_knives);

            // Flint 2H Daggers
            ItemDefinition Flint_knives = new ItemDefinition();
            Flint_knives.Name = "Flint knives";
            Flint_knives.Category = ItemCategory.Knives;
            Flint_knives.Prefab = "VADagger_Flint_2h";
            Flint_knives.Icon = "2h_flint_knives";
            Flint_knives.CraftedAt = "piece_workbench";
            Flint_knives.CraftAmount = 1;
            Flint_knives.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 4, Min =  0, Max =  48 } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 12, Min =  0, Max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 12, Min =  0, Max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  40 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 4, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 12, Min =  1, Max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
            };
            Flint_knives.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Wood", Amount = 4, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Flint", Amount = 6, UpgradeCost = 3 },
                    new RecipeIngredient { Prefab = "LeatherScraps", Amount = 2, UpgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Flint_knives);

            // Antler 1H Daggers
            ItemDefinition Eikthyrs_knife = new ItemDefinition();
            Eikthyrs_knife.Name = "Eikthyrs knife";
            Eikthyrs_knife.Category = ItemCategory.Knives;
            Eikthyrs_knife.Prefab = "VAAntler_dagger";
            Eikthyrs_knife.Icon = "antler_dagger";
            Eikthyrs_knife.CraftedAt = "piece_workbench";
            Eikthyrs_knife.CraftAmount = 1;
            Eikthyrs_knife.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 2, Min =  0, Max =  48 } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 8, Min =  0, Max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 8, Min =  0, Max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.lightning, new ItemStatConfig{ Default_value = 4, Min =  0, Max =  99 } },
                { ItemStat.lightning_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  30 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 6, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 18, Min =  1, Max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
            };
            Eikthyrs_knife.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "FineWood", Amount = 3, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Resin", Amount = 16, UpgradeCost = 8 },
                    new RecipeIngredient { Prefab = "HardAntler", Amount = 3, UpgradeCost = 3 },
                    new RecipeIngredient { Prefab = "TrophyEikthyr", Amount = 1, UpgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Eikthyrs_knife);

            // Copper 2H Daggers
            ItemDefinition Rascals_knives = new ItemDefinition();
            Rascals_knives.Name = "Rascals knives";
            Rascals_knives.Category = ItemCategory.Knives;
            Rascals_knives.Prefab = "VAdagger_copper_2h";
            Rascals_knives.Icon = "copper_knives_2h";
            Rascals_knives.CraftedAt = "forge";
            Rascals_knives.CraftAmount = 1;
            Rascals_knives.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 8, Min =  0, Max =  48 } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  40 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 6, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 18, Min =  1, Max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
            };
            Rascals_knives.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "RoundLog", Amount = 4, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Copper", Amount = 16, UpgradeCost = 4 },
                    new RecipeIngredient { Prefab = "LeatherScraps", Amount = 4, UpgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Rascals_knives);

            // Abyssal 2H Daggers
            ItemDefinition Abyssal_knives = new ItemDefinition();
            Abyssal_knives.Name = "Abyssal knives";
            Abyssal_knives.Category = ItemCategory.Knives;
            Abyssal_knives.Prefab = "VAdagger_chitin_2h";
            Abyssal_knives.Icon = "chitin_knives";
            Abyssal_knives.CraftedAt = "piece_workbench";
            Abyssal_knives.CraftAmount = 1;
            Abyssal_knives.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 12, Min =  0, Max =  48 } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 24, Min =  0, Max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
                { ItemStat.blunt, new ItemStatConfig{ Default_value = 24, Min =  0, Max =  99 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  40 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 8, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 24, Min =  1, Max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
            };
            Abyssal_knives.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "FineWood", Amount = 6, UpgradeCost = 4 },
                    new RecipeIngredient { Prefab = "Chitin", Amount = 32, UpgradeCost = 12 },
                    new RecipeIngredient { Prefab = "LeatherScraps", Amount = 8, UpgradeCost = 4 },
                }
            };
            Loader.AddDefinition(Abyssal_knives);

            // Iron 2H Daggers
            ItemDefinition Rogue_knives = new ItemDefinition();
            Rogue_knives.Name = "Rogue knives";
            Rogue_knives.Category = ItemCategory.Knives;
            Rogue_knives.Prefab = "VAdagger_iron_2h";
            Rogue_knives.Icon = "iron_dagger_2h";
            Rogue_knives.CraftedAt = "forge";
            Rogue_knives.CraftAmount = 1;
            Rogue_knives.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 12, Min =  0, Max =  48 } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 25, Min =  0, Max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 25, Min =  0, Max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  40 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 8, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 24, Min =  1, Max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
            };
            Rogue_knives.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Wood", Amount = 4, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "Iron", Amount = 16, UpgradeCost = 8 },
                    new RecipeIngredient { Prefab = "LeatherScraps", Amount = 6, UpgradeCost = 3 },
                }
            };
            Loader.AddDefinition(Rogue_knives);

            // Iron 1H Daggers
            ItemDefinition Iron_knives = new ItemDefinition();
            Iron_knives.Name = "Iron knives";
            Iron_knives.Category = ItemCategory.Knives;
            Iron_knives.Prefab = "VAdagger_iron";
            Iron_knives.Icon = "iron_dagger";
            Iron_knives.CraftedAt = "forge";
            Iron_knives.CraftAmount = 1;
            Iron_knives.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 2, Min =  0, Max =  48 } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 22, Min =  0, Max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 22, Min =  0, Max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  30 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 8, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 24, Min =  1, Max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
            };
            Iron_knives.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Wood", Amount = 2, UpgradeCost = 1 },
                    new RecipeIngredient { Prefab = "Iron", Amount = 12, UpgradeCost = 6 },
                    new RecipeIngredient { Prefab = "LeatherScraps", Amount = 4, UpgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Iron_knives);

            // Silver 2H Daggers
            ItemDefinition Silver_knives = new ItemDefinition();
            Silver_knives.Name = "Silver knives";
            Silver_knives.Category = ItemCategory.Knives;
            Silver_knives.Prefab = "VAdagger_silver_2h";
            Silver_knives.Icon = "silver_dagger_2h";
            Silver_knives.CraftedAt = "forge";
            Silver_knives.CraftAmount = 1;
            Silver_knives.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 16, Min =  0, Max =  48 } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 34, Min =  0, Max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 34, Min =  0, Max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.spirit, new ItemStatConfig{ Default_value = 12, Min =  0, Max =  99 } },
                { ItemStat.spirit_per_level, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
                { ItemStat.frost, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  99 } },
                { ItemStat.frost_per_level, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  40 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 10, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 30, Min =  1, Max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
            };
            Silver_knives.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Wood", Amount = 4, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "Silver", Amount = 12, UpgradeCost = 6 },
                    new RecipeIngredient { Prefab = "Iron", Amount = 4, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "LeatherScraps", Amount = 6, UpgradeCost = 3 },
                }
            };
            Loader.AddDefinition(Silver_knives);

            // Moders Daggers 1H
            ItemDefinition Moders_knife = new ItemDefinition();
            Moders_knife.Name = "Moders knife";
            Moders_knife.Category = ItemCategory.Knives;
            Moders_knife.Prefab = "VAdagger_moder";
            Moders_knife.Icon = "moder_dagger";
            Moders_knife.CraftedAt = "forge";
            Moders_knife.CraftAmount = 1;
            Moders_knife.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 2, Min =  0, Max =  48 } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 28, Min =  0, Max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 28, Min =  0, Max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.spirit, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  99 } },
                { ItemStat.spirit_per_level, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
                { ItemStat.frost, new ItemStatConfig{ Default_value = 8, Min =  0, Max =  99 } },
                { ItemStat.frost_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  30 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 10, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 30, Min =  1, Max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
            };
            Moders_knife.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "ElderBark", Amount = 4, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "Obsidian", Amount = 15, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "DragonTear", Amount = 10, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "TrophyDragonQueen", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Silver", Amount = 0, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "JuteRed", Amount = 0, UpgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Moders_knife);

            // Moders Daggers 2H
            ItemDefinition Moders_knife_2h = new ItemDefinition();
            Moders_knife_2h.Name = "Moders dualknives";
            Moders_knife_2h.Category = ItemCategory.Knives;
            Moders_knife_2h.Prefab = "VAdagger_moder_2h";
            Moders_knife_2h.Icon = "moder_dagger_2h";
            Moders_knife_2h.CraftedAt = "forge";
            Moders_knife_2h.CraftAmount = 1;
            Moders_knife_2h.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 18, Min =  0, Max =  48 } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 32, Min =  0, Max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 32, Min =  0, Max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.spirit, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  99 } },
                { ItemStat.spirit_per_level, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
                { ItemStat.frost, new ItemStatConfig{ Default_value = 8, Min =  0, Max =  99 } },
                { ItemStat.frost_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  30 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 10, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 30, Min =  1, Max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
            };
            Moders_knife_2h.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "DragonTear", Amount = 10, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "TrophyDragonQueen", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Silver", Amount = 15, UpgradeCost = 4 },
                    new RecipeIngredient { Prefab = "ElderBark", Amount = 6, UpgradeCost = 3 },
                    new RecipeIngredient { Prefab = "JuteRed", Amount = 0, UpgradeCost = 4 },
                }
            };
            Loader.AddDefinition(Moders_knife_2h);

            // Bonemass Dagger
            ItemDefinition Bonemasses_knife = new ItemDefinition();
            Bonemasses_knife.Name = "Bonemasses knife";
            Bonemasses_knife.Category = ItemCategory.Knives;
            Bonemasses_knife.Prefab = "VABonemassDagger";
            Bonemasses_knife.Icon = "bonemass_dagger";
            Bonemasses_knife.CraftedAt = "forge";
            Bonemasses_knife.CraftAmount = 1;
            Bonemasses_knife.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 2, Min =  0, Max =  48 } },
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 22, Min =  0, Max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 22, Min =  0, Max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ Default_value = 7, Min =  0, Max =  99 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ Default_value = 2, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  30 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 9, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 28, Min =  1, Max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
            };
            Bonemasses_knife.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "WitheredBone", Amount = 2, UpgradeCost = 1 },
                    new RecipeIngredient { Prefab = "Iron", Amount = 12, UpgradeCost = 6 },
                    new RecipeIngredient { Prefab = "Wishbone", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "TrophyBonemass", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "ElderBark", Amount = 0, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "LeatherScraps", Amount = 0, UpgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Bonemasses_knife);

            // Queens Dagger
            ItemDefinition Queens_knife = new ItemDefinition();
            Queens_knife.Name = "Queens knife";
            Queens_knife.Category = ItemCategory.Knives;
            Queens_knife.Prefab = "VAdagger_queen";
            Queens_knife.Icon = "dagger_queen";
            Queens_knife.CraftedAt = "blackforge";
            Queens_knife.CraftAmount = 1;
            Queens_knife.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 2, Min =  0, Max =  48 } },
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 34, Min =  0, Max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 34, Min =  0, Max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ Default_value = 18, Min =  0, Max =  99 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  50 } },
                { ItemStat.lightning, new ItemStatConfig{ Default_value = 18, Min =  0, Max =  99 } },
                { ItemStat.lightning_per_level, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  30 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 14, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 42, Min =  1, Max =  80 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
            };
            Queens_knife.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "YggdrasilWood", Amount = 2, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "Eitr", Amount = 10, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "JuteBlue", Amount = 2, UpgradeCost = 1 },
                    new RecipeIngredient { Prefab = "TrophySeekerQueen", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Carapace", Amount = 0, UpgradeCost = 4 },
                }
            };
            Loader.AddDefinition(Queens_knife);

            // Meteor dagger
            ItemDefinition Flametal_knife = new ItemDefinition();
            Flametal_knife.Name = "Flametal knife";
            Flametal_knife.Category = ItemCategory.Knives;
            Flametal_knife.Prefab = "VAdagger_meteor";
            Flametal_knife.Icon = "meteor_dagger";
            Flametal_knife.CraftedAt = "blackforge";
            Flametal_knife.CraftAmount = 1;
            Flametal_knife.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 2, Min =  0, Max =  48 } },
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 45, Min =  0, Max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 45, Min =  0, Max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  30 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 14, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 42, Min =  1, Max =  80 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
            };
            Flametal_knife.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "FlametalNew", Amount = 10, UpgradeCost = 4 },
                    new RecipeIngredient { Prefab = "Iron", Amount = 2, UpgradeCost = 1 },
                    new RecipeIngredient { Prefab = "Blackwood", Amount = 4, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "MorgenSinew", Amount = 4, UpgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Flametal_knife);

            // Meteor primal dagger
            ItemDefinition Flametal_primal_knife = new ItemDefinition();
            Flametal_primal_knife.Name = "Flametal primal knife";
            Flametal_primal_knife.Category = ItemCategory.Knives;
            Flametal_primal_knife.Prefab = "VAdagger_meteor_nature";
            Flametal_primal_knife.Icon = "meteor_dagger_primal";
            Flametal_primal_knife.CraftedAt = "blackforge";
            Flametal_primal_knife.CraftAmount = 1;
            Flametal_primal_knife.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 2, Min =  0, Max =  48 } },
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 45, Min =  0, Max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 45, Min =  0, Max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  99 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ Default_value = 2, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  30 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 14, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 42, Min =  1, Max =  80 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
            };
            Flametal_primal_knife.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "VAdagger_meteor", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "FlametalNew", Amount = 4, UpgradeCost = 4 },
                    new RecipeIngredient { Prefab = "GemstoneGreen", Amount = 1, UpgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Flametal_primal_knife);

            // Meteor lightning dagger
            ItemDefinition Flametal_lightning_knife = new ItemDefinition();
            Flametal_lightning_knife.Name = "Flametal lightning knife";
            Flametal_lightning_knife.Category = ItemCategory.Knives;
            Flametal_lightning_knife.Prefab = "VAdagger_meteor_lightning";
            Flametal_lightning_knife.Icon = "meteor_dagger_lightning";
            Flametal_lightning_knife.CraftedAt = "blackforge";
            Flametal_lightning_knife.CraftAmount = 1;
            Flametal_lightning_knife.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 2, Min =  0, Max =  48 } },
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 45, Min =  0, Max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 45, Min =  0, Max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.lightning, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  99 } },
                { ItemStat.lightning_per_level, new ItemStatConfig{ Default_value = 2, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  30 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 14, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 42, Min =  1, Max =  80 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
            };
            Flametal_lightning_knife.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "VAdagger_meteor", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "FlametalNew", Amount = 4, UpgradeCost = 4 },
                    new RecipeIngredient { Prefab = "GemstoneBlue", Amount = 1, UpgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Flametal_lightning_knife);

            // Meteor blood dagger
            ItemDefinition Flametal_blood_knife = new ItemDefinition();
            Flametal_blood_knife.Name = "Flametal blood knife";
            Flametal_blood_knife.Category = ItemCategory.Knives;
            Flametal_blood_knife.Prefab = "VAdagger_meteor_blood";
            Flametal_blood_knife.Icon = "meteor_dagger_blood";
            Flametal_blood_knife.CraftedAt = "blackforge";
            Flametal_blood_knife.CraftAmount = 1;
            Flametal_blood_knife.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 2, Min =  0, Max =  48 } },
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 45, Min =  0, Max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 45, Min =  0, Max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  30 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 14, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 42, Min =  1, Max =  80 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
            };
            Flametal_blood_knife.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "VAdagger_meteor", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "FlametalNew", Amount = 4, UpgradeCost = 4 },
                    new RecipeIngredient { Prefab = "GemstoneRed", Amount = 1, UpgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Flametal_blood_knife);

            // Meteor dagger 2h
            ItemDefinition Assassins_knives = new ItemDefinition();
            Assassins_knives.Name = "Assassins knives";
            Assassins_knives.Category = ItemCategory.Knives;
            Assassins_knives.Prefab = "VAdagger_meteor_2h";
            Assassins_knives.Icon = "2h_meteor_daggers";
            Assassins_knives.CraftedAt = "blackforge";
            Assassins_knives.CraftAmount = 1;
            Assassins_knives.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 28, Min =  0, Max =  48 } },
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 52, Min =  0, Max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 52, Min =  0, Max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  30 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 15, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 45, Min =  1, Max =  80 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
            };
            Assassins_knives.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "FlametalNew", Amount = 14, UpgradeCost = 6 },
                    new RecipeIngredient { Prefab = "Iron", Amount = 2, UpgradeCost = 1 },
                    new RecipeIngredient { Prefab = "Blackwood", Amount = 6, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "MorgenSinew", Amount = 4, UpgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Assassins_knives);

            // Meteor dagger 2h nature
            ItemDefinition Assassins_primal_knives = new ItemDefinition();
            Assassins_primal_knives.Name = "Assassins primal knives";
            Assassins_primal_knives.Category = ItemCategory.Knives;
            Assassins_primal_knives.Prefab = "VAdagger_meteor_2h_nature";
            Assassins_primal_knives.Icon = "meteor_dagger_primal_2h";
            Assassins_primal_knives.CraftedAt = "blackforge";
            Assassins_primal_knives.CraftAmount = 1;
            Assassins_primal_knives.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 28, Min =  0, Max =  48 } },
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 52, Min =  0, Max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 52, Min =  0, Max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ Default_value = 14, Min =  0, Max =  99 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ Default_value = 2, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  30 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 15, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 45, Min =  1, Max =  80 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
            };
            Assassins_primal_knives.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "VAdagger_meteor_2h", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "FlametalNew", Amount = 8, UpgradeCost = 8 },
                    new RecipeIngredient { Prefab = "GemstoneGreen", Amount = 1, UpgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Assassins_primal_knives);

            // Meteor dagger 2h lightning
            ItemDefinition Assassins_lightning_knives = new ItemDefinition();
            Assassins_lightning_knives.Name = "Assassins lightning knives";
            Assassins_lightning_knives.Category = ItemCategory.Knives;
            Assassins_lightning_knives.Prefab = "VAdagger_meteor_2h_lightning";
            Assassins_lightning_knives.Icon = "meteor_dagger_lightning_2h";
            Assassins_lightning_knives.CraftedAt = "blackforge";
            Assassins_lightning_knives.CraftAmount = 1;
            Assassins_lightning_knives.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 28, Min =  0, Max =  48 } },
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 52, Min =  0, Max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 52, Min =  0, Max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.lightning, new ItemStatConfig{ Default_value = 14, Min =  0, Max =  99 } },
                { ItemStat.lightning_per_level, new ItemStatConfig{ Default_value = 2, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  30 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 15, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 45, Min =  1, Max =  80 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
            };
            Assassins_lightning_knives.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "VAdagger_meteor_2h", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "FlametalNew", Amount = 8, UpgradeCost = 8 },
                    new RecipeIngredient { Prefab = "GemstoneBlue", Amount = 1, UpgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Assassins_lightning_knives);

            // Meteor dagger 2h Blood
            ItemDefinition Assassins_blood_knives = new ItemDefinition();
            Assassins_blood_knives.Name = "Assassins blood knives";
            Assassins_blood_knives.Category = ItemCategory.Knives;
            Assassins_blood_knives.Prefab = "VAdagger_meteor_2h_blood";
            Assassins_blood_knives.Icon = "meteor_dagger_blood_2h";
            Assassins_blood_knives.CraftedAt = "blackforge";
            Assassins_blood_knives.CraftAmount = 1;
            Assassins_blood_knives.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 28, Min =  0, Max =  48 } },
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 52, Min =  0, Max =  99 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 52, Min =  0, Max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  30 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 15, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 45, Min =  1, Max =  80 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
            };
            Assassins_blood_knives.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "VAdagger_meteor_2h", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "FlametalNew", Amount = 8, UpgradeCost = 8 },
                    new RecipeIngredient { Prefab = "GemstoneRed", Amount = 1, UpgradeCost = 1 },
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
            FlintSpear.Prefab = "VASpearFlint";
            FlintSpear.Icon = "flint_spear";
            FlintSpear.CraftedAt = "piece_workbench";
            FlintSpear.CraftAmount = 1;
            FlintSpear.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 4, Min =  0, Max =  48 } },
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  120 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 6, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 8, Min =  1, Max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 100, Min =  0, Max =  300 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
            };
            FlintSpear.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Wood", Amount = 5, UpgradeCost = 3 },
                    new RecipeIngredient { Prefab = "Flint", Amount = 10, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "LeatherScraps", Amount = 2, UpgradeCost = 1 },
                }
            };
            Loader.AddDefinition(FlintSpear);

            // Moder Spear
            ItemDefinition Moders_Strike = new ItemDefinition();
            Moders_Strike.Name = "Moders Strike";
            Moders_Strike.Category = ItemCategory.Spears;
            Moders_Strike.Prefab = "VASpearModer";
            Moders_Strike.Icon = "moder_spear";
            Moders_Strike.CraftedAt = "forge";
            Moders_Strike.CraftAmount = 1;
            Moders_Strike.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  48 } },
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 45, Min =  0, Max =  120 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 2, Min =  0, Max =  50 } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  99 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 4, Min =  0, Max =  50 } },
                { ItemStat.frost, new ItemStatConfig{ Default_value = 25, Min =  0, Max =  99 } },
                { ItemStat.frost_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 12, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 14, Min =  1, Max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 100, Min =  0, Max =  300 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
            };
            Moders_Strike.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "ElderBark", Amount = 15, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "Obsidian", Amount = 8, UpgradeCost = 4 },
                    new RecipeIngredient { Prefab = "DragonTear", Amount = 10, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "TrophyDragonQueen", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Silver", Amount = 0, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "JuteRed", Amount = 0, UpgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Moders_Strike);

            // Blackmetal Spear
            ItemDefinition BlackmetalSpear = new ItemDefinition();
            BlackmetalSpear.Name = "Blackmetal Spear";
            BlackmetalSpear.Category = ItemCategory.Spears;
            BlackmetalSpear.Prefab = "VASpearBlackmetal";
            BlackmetalSpear.Icon = "blackmetal_spear";
            BlackmetalSpear.CraftedAt = "forge";
            BlackmetalSpear.CraftAmount = 1;
            BlackmetalSpear.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  48 } },
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 95, Min =  0, Max =  120 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 2, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 14, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 18, Min =  1, Max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 100, Min =  0, Max =  300 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
            };
            BlackmetalSpear.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "BlackMetal", Amount = 6, UpgradeCost = 6 },
                    new RecipeIngredient { Prefab = "FineWood", Amount = 10, UpgradeCost = 5 },
                    new RecipeIngredient { Prefab = "Chain", Amount = 2, UpgradeCost = 1 },
                    new RecipeIngredient { Prefab = "JuteRed", Amount = 2, UpgradeCost = 1 },
                }
            };
            Loader.AddDefinition(BlackmetalSpear);

            // Fader Spear
            ItemDefinition FaderSpear = new ItemDefinition();
            FaderSpear.Name = "Fader Spear";
            FaderSpear.Category = ItemCategory.Spears;
            FaderSpear.Prefab = "VASpearFader";
            FaderSpear.Icon = "fader_spear";
            FaderSpear.CraftedAt = "blackforge";
            FaderSpear.CraftAmount = 1;
            FaderSpear.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  48 } },
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 150, Min =  0, Max =  300 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  50 } },
                { ItemStat.poison, new ItemStatConfig{ Default_value = 25, Min =  0, Max =  300 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.fire, new ItemStatConfig{ Default_value = 25, Min =  0, Max =  300 } },
                { ItemStat.fire_per_level, new ItemStatConfig{ Default_value = 1, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 18, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 20, Min =  1, Max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 100, Min =  0, Max =  300 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
            };
            FaderSpear.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "FlametalNew", Amount = 24, UpgradeCost = 24 },
                    new RecipeIngredient { Prefab = "Blackwood", Amount = 10, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "TrophyFader", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "FaderDrop", Amount = 1, UpgradeCost = 0 },
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
            Flint_knuckles.Prefab = "VAFist_Flint";
            Flint_knuckles.Icon = "flint_fists";
            Flint_knuckles.CraftedAt = "piece_workbench";
            Flint_knuckles.CraftAmount = 1;
            Flint_knuckles.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  48 } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  120 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 4, Min =  0, Max =  50 } },
                { ItemStat.blunt, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  120 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 4, Min =  1, Max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 300, Min =  0, Max =  600 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
            };
            Flint_knuckles.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Wood", Amount = 4, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Flint", Amount = 4, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "LeatherScraps", Amount = 2, UpgradeCost = 2 },
                }
            };
            Loader.AddDefinition(Flint_knuckles);

            // Bronze Fists
            ItemDefinition Bronze_knuckles = new ItemDefinition();
            Bronze_knuckles.Name = "Bronze knuckles";
            Bronze_knuckles.Category = ItemCategory.Fists;
            Bronze_knuckles.Prefab = "VAFist_Bronze";
            Bronze_knuckles.Icon = "bronze_fists";
            Bronze_knuckles.CraftedAt = "forge";
            Bronze_knuckles.CraftAmount = 1;
            Bronze_knuckles.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  48 } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  120 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 4, Min =  0, Max =  50 } },
                { ItemStat.blunt, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  120 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 6, Min =  1, Max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 300, Min =  0, Max =  600 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
            };
            Bronze_knuckles.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "RoundLog", Amount = 4, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Bronze", Amount = 6, UpgradeCost = 3 },
                    new RecipeIngredient { Prefab = "LeatherScraps", Amount = 4, UpgradeCost = 4 },
                }
            };
            Loader.AddDefinition(Bronze_knuckles);

            // Iron Fists
            ItemDefinition Iron_knuckles = new ItemDefinition();
            Iron_knuckles.Name = "Iron knuckles";
            Iron_knuckles.Category = ItemCategory.Fists;
            Iron_knuckles.Prefab = "VAFist_Iron";
            Iron_knuckles.Icon = "iron_fists";
            Iron_knuckles.CraftedAt = "forge";
            Iron_knuckles.CraftAmount = 1;
            Iron_knuckles.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  48 } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 35, Min =  0, Max =  120 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 4, Min =  0, Max =  50 } },
                { ItemStat.blunt, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  120 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 8, Min =  1, Max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 300, Min =  0, Max =  600 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
            };
            Iron_knuckles.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Wood", Amount = 4, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "Iron", Amount = 12, UpgradeCost = 6 },
                    new RecipeIngredient { Prefab = "LeatherScraps", Amount = 6, UpgradeCost = 6 },
                }
            };
            Loader.AddDefinition(Iron_knuckles);

            // Yagluth Fists
            ItemDefinition Goblin_king_knuckles = new ItemDefinition();
            Goblin_king_knuckles.Name = "Goblin king knuckles";
            Goblin_king_knuckles.Category = ItemCategory.Fists;
            Goblin_king_knuckles.Prefab = "VAFist_Yagluth";
            Goblin_king_knuckles.Icon = "yagluth_fists";
            Goblin_king_knuckles.CraftedAt = "forge";
            Goblin_king_knuckles.CraftAmount = 1;
            Goblin_king_knuckles.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  48 } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 80, Min =  0, Max =  120 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 4, Min =  0, Max =  50 } },
                { ItemStat.blunt, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  120 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
                { ItemStat.fire, new ItemStatConfig{ Default_value = 25, Min =  0, Max =  120 } },
                { ItemStat.fire_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 12, Min =  1, Max =  50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 36, Min =  1, Max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 300, Min =  0, Max =  600 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
            };
            Goblin_king_knuckles.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "BlackMetal", Amount = 4, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "Iron", Amount = 6, UpgradeCost = 3 },
                    new RecipeIngredient { Prefab = "YagluthDrop", Amount = 2, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "TrophyGoblinKing", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Tar", Amount = 0, UpgradeCost = 3 },
                    new RecipeIngredient { Prefab = "LinenThread", Amount = 0, UpgradeCost = 2 },
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
            Elders_Fist.Prefab = "VAElder_mace";
            Elders_Fist.Icon = "elder_mace";
            Elders_Fist.CraftedAt = "forge";
            Elders_Fist.CraftAmount = 1;
            Elders_Fist.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.blunt, new ItemStatConfig{ Default_value = 35, Min =  0, Max =  90 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.spirit, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  120 } },
                { ItemStat.spirit_per_level, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 80, Min =  0, Max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 12, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 8, Min =  1, Max =  30 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 16, Min =  1, Max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
            };
            Elders_Fist.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Bronze", Amount = 2, UpgradeCost = 1 },
                    new RecipeIngredient { Prefab = "Stone", Amount = 16, UpgradeCost = 8 },
                    new RecipeIngredient { Prefab = "CryptKey", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "TrophyTheElder", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "RoundLog", Amount = 0, UpgradeCost = 6 },
                }
            };
            Loader.AddDefinition(Elders_Fist);


            // Flint Mace
            ItemDefinition FlintMace = new ItemDefinition();
            FlintMace.Name = "Flint Mace";
            FlintMace.Category = ItemCategory.Maces;
            FlintMace.Prefab = "VAFlintMace";
            FlintMace.Icon = "flintMace";
            FlintMace.CraftedAt = "piece_workbench";
            FlintMace.CraftAmount = 1;
            FlintMace.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.blunt, new ItemStatConfig{ Default_value = 16, Min =  0, Max =  90 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 30, Min =  0, Max =  120 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 4, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 7, Min =  1, Max =  30 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 14, Min =  1, Max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
            };
            FlintMace.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "Wood", Amount = 4, UpgradeCost = 8 },
                    new RecipeIngredient { Prefab = "Flint", Amount = 8, UpgradeCost = 8 },
                    new RecipeIngredient { Prefab = "LeatherScraps", Amount = 2, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "BoneFragments", Amount = 0, UpgradeCost = 5 },
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
            Staff_of_poison.Prefab = "VAStaff_Poison";
            Staff_of_poison.Icon = "poison_staff";
            Staff_of_poison.CraftedAt = "piece_magetable";
            Staff_of_poison.CraftAmount = 1;
            Staff_of_poison.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 48, Min =  0, Max =  90 } },
                { ItemStat.poison, new ItemStatConfig{ Default_value = 120, Min =  0, Max =  200 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.blunt, new ItemStatConfig{ Default_value = 120, Min =  0, Max =  200 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_eitr, new ItemStatConfig{ Default_value = 35, Min =  0, Max =  50 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
            };
            Staff_of_poison.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "YggdrasilWood", Amount = 20, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "Guck", Amount = 4, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "Eitr", Amount = 16, UpgradeCost = 8 },
                }
            };
            Loader.AddDefinition(Staff_of_poison);

            // Staff of spirit
            ItemDefinition Staff_of_Spirit = new ItemDefinition();
            Staff_of_Spirit.Name = "Staff of Spirit";
            Staff_of_Spirit.Category = ItemCategory.Magics;
            Staff_of_Spirit.Prefab = "VAStaff_Spirit";
            Staff_of_Spirit.Icon = "spirit_staff";
            Staff_of_Spirit.CraftedAt = "piece_magetable";
            Staff_of_Spirit.CraftAmount = 1;
            Staff_of_Spirit.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 48, Min =  0, Max =  90 } },
                { ItemStat.spirit, new ItemStatConfig{ Default_value = 90, Min =  0, Max =  200 } },
                { ItemStat.spirit_per_level, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  50 } },
                { ItemStat.blunt, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  200 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 120, Min =  0, Max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_eitr, new ItemStatConfig{ Default_value = 35, Min =  0, Max =  50 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  400 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
            };
            Staff_of_Spirit.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "YggdrasilWood", Amount = 20, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "GreydwarfEye", Amount = 8, UpgradeCost = 8 },
                    new RecipeIngredient { Prefab = "Eitr", Amount = 16, UpgradeCost = 8 },
                    new RecipeIngredient { Prefab = "TrophyDvergr", Amount = 2, UpgradeCost = 0 },
                }
            };
            Loader.AddDefinition(Staff_of_Spirit);

            // Druidic Staff of poison
            ItemDefinition Druidic_Staff_of_Poison = new ItemDefinition();
            Druidic_Staff_of_Poison.Name = "Druidic Staff of Poison";
            Druidic_Staff_of_Poison.Category = ItemCategory.Magics;
            Druidic_Staff_of_Poison.Prefab = "VAStaff_Druid_Poison";
            Druidic_Staff_of_Poison.Icon = "poison_staff_druidic";
            Druidic_Staff_of_Poison.CraftedAt = "piece_workbench";
            Druidic_Staff_of_Poison.CraftAmount = 1;
            Druidic_Staff_of_Poison.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 24, Min =  0, Max =  48 } },
                { ItemStat.poison, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  120 } },
                { ItemStat.poison_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.blunt, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  200 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 35, Min =  0, Max =  50 } },
                { ItemStat.primary_attack_eitr, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
            };
            Druidic_Staff_of_Poison.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "ElderBark", Amount = 20, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "Guck", Amount = 4, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "TrophyBlob", Amount = 2, UpgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Druidic_Staff_of_Poison);

            // Druidic Staff of spirit
            ItemDefinition Druidic_Staff_of_Spirit = new ItemDefinition();
            Druidic_Staff_of_Spirit.Name = "Druidic Staff of Spirit";
            Druidic_Staff_of_Spirit.Category = ItemCategory.Magics;
            Druidic_Staff_of_Spirit.Prefab = "VAStaff_Druid_Spirit";
            Druidic_Staff_of_Spirit.Icon = "spirit_staff_druid";
            Druidic_Staff_of_Spirit.CraftedAt = "piece_workbench";
            Druidic_Staff_of_Spirit.CraftAmount = 1;
            Druidic_Staff_of_Spirit.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 24, Min =  0, Max =  48 } },
                { ItemStat.spirit, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  120 } },
                { ItemStat.spirit_per_level, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  50 } },
                { ItemStat.blunt, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  200 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
                { ItemStat.slash, new ItemStatConfig{ Default_value = 40, Min =  0, Max =  200 } },
                { ItemStat.slash_per_level, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 35, Min =  0, Max =  50 } },
                { ItemStat.primary_attack_eitr, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
            };
            Druidic_Staff_of_Spirit.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "ElderBark", Amount = 20, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "GreydwarfEye", Amount = 4, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "TrophyGreydwarfShaman", Amount = 2, UpgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Druidic_Staff_of_Spirit);

            // Druidic Staff of Ice
            ItemDefinition Druidic_Staff_of_Ice = new ItemDefinition();
            Druidic_Staff_of_Ice.Name = "Druidic Staff of Ice";
            Druidic_Staff_of_Ice.Category = ItemCategory.Magics;
            Druidic_Staff_of_Ice.Prefab = "VAStaff_Druid_Ice";
            Druidic_Staff_of_Ice.Icon = "ice_staff_druidic";
            Druidic_Staff_of_Ice.CraftedAt = "piece_workbench";
            Druidic_Staff_of_Ice.CraftAmount = 1;
            Druidic_Staff_of_Ice.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 24, Min =  0, Max =  48 } },
                { ItemStat.frost, new ItemStatConfig{ Default_value = 12, Min =  0, Max =  120 } },
                { ItemStat.frost_per_level, new ItemStatConfig{ Default_value = 2, Min =  0, Max =  50 } },
                { ItemStat.blunt, new ItemStatConfig{ Default_value = 12, Min =  0, Max =  200 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 5, Min =  0, Max =  50 } },
                { ItemStat.primary_attack_eitr, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
            };
            Druidic_Staff_of_Ice.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "ElderBark", Amount = 20, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "FreezeGland", Amount = 4, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "TrophyHatchling", Amount = 2, UpgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Druidic_Staff_of_Ice);

            // Druidic Staff of Fire
            ItemDefinition Druidic_Staff_of_Fire = new ItemDefinition();
            Druidic_Staff_of_Fire.Name = "Druidic Staff of Fire";
            Druidic_Staff_of_Fire.Category = ItemCategory.Magics;
            Druidic_Staff_of_Fire.Prefab = "VAStaff_Druid_Fire";
            Druidic_Staff_of_Fire.Icon = "fire_staff_druidic";
            Druidic_Staff_of_Fire.CraftedAt = "piece_workbench";
            Druidic_Staff_of_Fire.CraftAmount = 1;
            Druidic_Staff_of_Fire.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 24, Min =  0, Max =  48 } },
                { ItemStat.fire, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  120 } },
                { ItemStat.fire_per_level, new ItemStatConfig{ Default_value = 6, Min =  0, Max =  50 } },
                { ItemStat.blunt, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  200 } },
                { ItemStat.blunt_per_level, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 20, Min =  0, Max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  500 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  150 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 35, Min =  0, Max =  50 } },
                { ItemStat.primary_attack_eitr, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
            };
            Druidic_Staff_of_Fire.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "ElderBark", Amount = 20, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "SurtlingCore", Amount = 4, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "TrophySurtling", Amount = 2, UpgradeCost = 1 },
                }
            };
            Loader.AddDefinition(Druidic_Staff_of_Fire);

            // Soulstealer
            ItemDefinition Soulstealer = new ItemDefinition();
            Soulstealer.Name = "Soulstealer";
            Soulstealer.Category = ItemCategory.Magics;
            Soulstealer.Prefab = "VASoulStealer";
            Soulstealer.Icon = "soulstealer";
            Soulstealer.CraftedAt = "piece_magetable";
            Soulstealer.CraftAmount = 1;
            Soulstealer.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  300 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  50 } },
                { ItemStat.spirit, new ItemStatConfig{ Default_value = 100, Min =  0, Max =  300 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  300 } },
                { ItemStat.block_armor, new ItemStatConfig{ Default_value = 3, Min =  0, Max =  150 } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 100, Min =  0, Max =  300 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min =  0, Max =  150 } },
                { ItemStat.crossbow_reload_speed, new ItemStatConfig{ Default_value = 2f, Min =  0.01f, Max =  3.5f } },
                { ItemStat.crossbow_reload_stamina_drain, new ItemStatConfig{ Default_value = 0, Min =  0, Max =  50 } },
                { ItemStat.primary_attack_percent_health_cost, new ItemStatConfig{ Default_value = 12, Min =  0, Max =  50 } },
                { ItemStat.primary_attack_flat_health_cost, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  120 } },
                { ItemStat.primary_attack_health_returned, new ItemStatConfig{ Default_value = 10, Min =  0, Max =  50 } },
                { ItemStat.primary_attack_projectile_count, new ItemStatConfig { Default_value = 2, Min =  1, Max =  10, IsInt = true } },
                { ItemStat.projectile_velocity, new ItemStatConfig{ Default_value = 200, Min =  0, Max =  300 } },
            };
            Soulstealer.Recipe = new RecipeDefinition
            {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "FlametalNew", Amount = 18, UpgradeCost = 10 },
                    new RecipeIngredient { Prefab = "Blackwood", Amount = 24, UpgradeCost = 12 },
                    new RecipeIngredient { Prefab = "GemstoneRed", Amount = 2, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "DvergrNeedle", Amount = 1, UpgradeCost = 0 },
                    new RecipeIngredient { Prefab = "Bronze", Amount = 0, UpgradeCost = 6 },
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
            bonepick.Prefab = "VABlood_Bones_pickaxe";
            bonepick.Icon = "blood_bone_pickaxe";
            bonepick.CraftedAt = "forge";
            bonepick.CraftAmount = 1;
            bonepick.ReqStationlevel = 1;
            bonepick.ModifableStats = new Dictionary<ItemStat, ItemStatConfig> {
                { ItemStat.pierce, new ItemStatConfig{ Default_value = 26, Min = 0, Max = 200 } },
                { ItemStat.pierce_per_level, new ItemStatConfig{ Default_value = 4, Min = 0, Max = 50 } },
                { ItemStat.spirit, new ItemStatConfig{ Default_value = 6, Min = 0, Max = 200 } },
                { ItemStat.spirit_per_level, new ItemStatConfig{ Default_value = 2, Min = 0, Max = 50 } },
                { ItemStat.pickaxe, new ItemStatConfig{ Default_value = 32, Min = 0, Max = 200 } },
                { ItemStat.pickaxe_per_level, new ItemStatConfig{ Default_value = 6, Min = 0, Max = 50 } },
                { ItemStat.attack_force, new ItemStatConfig{ Default_value = 50, Min = 0, Max = 100 } },
                { ItemStat.primary_attack_stamina, new ItemStatConfig{ Default_value = 6, Min = 0, Max = 50 } },
                { ItemStat.primary_attack_flat_health_cost, new ItemStatConfig{ Default_value = 4, Min = 0, Max = 50 } },
                { ItemStat.primary_attack_percent_health_cost, new ItemStatConfig{ Default_value = 0, Min = 0, Max = 50 } },
                { ItemStat.secondary_attack_stamina, new ItemStatConfig{ Default_value = 4, Min = 0, Max = 50 } },
                { ItemStat.secondary_attack_flat_health_cost, new ItemStatConfig{ Default_value = 6, Min = 0, Max = 50 } },
                { ItemStat.secondary_attack_percent_health_cost, new ItemStatConfig{ Default_value = 0, Min = 0, Max = 100 } },
                { ItemStat.tool_level, new ItemStatConfig{ Default_value = 1, Min = 0, Max = 5, IsInt = true } },
                { ItemStat.durability, new ItemStatConfig{ Default_value = 200, Min = 0, Max = 800 } },
                { ItemStat.durability_per_level, new ItemStatConfig{ Default_value = 50, Min = 0, Max = 200 } },
            };
            bonepick.Recipe = new RecipeDefinition {
                RecipeItems = new List<RecipeIngredient> {
                    new RecipeIngredient { Prefab = "RoundLog", Amount = 12, UpgradeCost = 8 },
                    new RecipeIngredient { Prefab = "BoneFragments", Amount = 20, UpgradeCost = 14 },
                    new RecipeIngredient { Prefab = "Bronze", Amount = 4, UpgradeCost = 2 },
                    new RecipeIngredient { Prefab = "TrophySkeleton", Amount = 2, UpgradeCost = 0 },
                }
            };
            Loader.AddDefinition(bonepick);
        }

        private void LoadNonCraftables()
        {
            // Arrow resources
            NonCraftablePrefab("Assets/Custom/Weapons/Arrows/VAbow_projectile_ancient.Prefab");
            NonCraftablePrefab("Assets/Custom/Weapons/Arrows/VAbow_projectile_bone.Prefab");
            NonCraftablePrefab("Assets/Custom/Weapons/Bows/projectiles/blood_projectile.Prefab");
            NonCraftablePrefab("Assets/Custom/Weapons/Arrows/VAbow_projectile_boltBronze.Prefab");
            NonCraftablePrefab("Assets/Custom/Weapons/Arrows/VAbow_projectile_boltFrost.Prefab");
            NonCraftablePrefab("Assets/Custom/Weapons/Arrows/VAbow_projectile_boltObsidian.Prefab");
            NonCraftablePrefab("Assets/Custom/Weapons/Arrows/VAbow_projectile_boltPoison.Prefab");
            NonCraftablePrefab("Assets/Custom/Weapons/Arrows/VAbow_projectile_boltSurtling.Prefab");
            NonCraftablePrefab("Assets/Custom/Weapons/Arrows/VAbow_projectile_greenmetal.Prefab");
            NonCraftablePrefab("Assets/Custom/Weapons/Arrows/VAbow_projectile_surtlingfire.Prefab");
            NonCraftablePrefab("Assets/Custom/Weapons/Arrows/VAbow_projectile_boltWood.Prefab");
            NonCraftablePrefab("Assets/Custom/Weapons/Arrows/VAbow_projectile_boltCorewood.Prefab");
            NonCraftablePrefab("Assets/Custom/Weapons/Arrows/VAbow_projectile_chitin.Prefab");
            NonCraftablePrefab("Assets/Custom/Weapons/Arrows/VAbow_projectile_needle.Prefab");
            // Spear projectiles
            NonCraftablePrefab("Assets/Custom/Weapons/Spears/VAspearblackmetal_projectile.Prefab");
            NonCraftablePrefab("Assets/Custom/Weapons/Spears/VAspearmoder_projectile.Prefab");

            // Magic projectiles
            //new NonCraftablePrefab(EmbeddedResourceBundle, "Assets/Custom/Weapons/Magics/projectiles/staff_ice_projectile.Prefab");
            NonCraftablePrefab("Assets/Custom/Weapons/Magics/projectiles/staff_poison_projectile.Prefab");
            NonCraftablePrefab("Assets/Custom/Weapons/Magics/projectiles/staff_spirit_projectile.Prefab");
            // new NonCraftablePrefab(EmbeddedResourceBundle, "Assets/Custom/Weapons/Magics/projectiles/vfx_poison_explosion.Prefab");
            NonCraftablePrefab("Assets/Custom/Weapons/Magics/projectiles/vfx_spirit_explosion.Prefab");

            // Status effects
            NonCraftableItem("Assets/Custom/statuses/VABloodBuff.asset");
            NonCraftableItem("Assets/Custom/statuses/VAModerShield.asset");
            NonCraftableItem("Assets/Custom/statuses/VAQueen_buff.asset");
            NonCraftableItem("Assets/Custom/statuses/VAVineshield_resistance.asset");
        }

        private static void NonCraftableItem(string full_path) {
            SE_Stats status_effect = ValheimArmory.EmbeddedResourceBundle.LoadAsset<SE_Stats>($"{full_path}");
            CustomStatusEffect customEffect = new CustomStatusEffect(status_effect, fixReference: false); ;
            ItemManager.Instance.AddStatusEffect(customEffect);
        }

        public static void NonCraftablePrefab(String full_path) {
            GameObject game_obj = ValheimArmory.EmbeddedResourceBundle.LoadAsset<GameObject>($"{full_path}");
            CustomPrefab prefab_obj = new CustomPrefab(game_obj, true);
            PrefabManager.Instance.AddPrefab(prefab_obj);
        }
    }
}