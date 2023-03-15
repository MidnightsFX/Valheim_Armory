
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
            LoadShields(EmbeddedResourceBundle, cfg);
        }

        private void LoadArrows(AssetBundle EmbeddedResourceBundle, VAConfig cfg)
        {
            // Greenmetal Arrows
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg.file,
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
                cfg.file,
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
                cfg.file,
                new Dictionary<string, string>() {
                    { "name", "Surtling Fire Arrow" },
                    { "catagory", "Arrows" },
                    { "prefab", "VAarrow_surtling_fire" },
                    { "sprite", "ancient_arrow" },
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
                cfg.file,
                new Dictionary<string, string>() {
                    { "name", "Ancient Wood Arrow" },
                    { "catagory", "Arrows" },
                    { "prefab", "VAarrowancient" },
                    { "sprite", "surtlingcore_arrow" },
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
                cfg.file,
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
                cfg.file,
                new Dictionary<string, string>() {
                    { "name", "Wood Bolt" },
                    { "catagory", "Arrows" },
                    { "prefab", "VABoltWood" },
                    { "sprite", "bolt_wood" },
                    { "craftedAt", "piece_artisanstation" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(20, 1, 100, true) },
                    { "pierce", new Tuple<float, float, float, bool>(28, 0, 200, true) }
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(8, 0) }
                }
            );
        }

        private void LoadBows(AssetBundle EmbeddedResourceBundle, VAConfig cfg)
        {
            // Bronze Crossbow
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg.file,
                new Dictionary<string, string>() {
                    { "name", "Bronze Crossbow" },
                    { "catagory", "Bows" },
                    { "prefab", "VACrossbowBronze" },
                    { "sprite", "bronze_crossbow_upright" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "pierce", new Tuple<float, float, float, bool>(100, 0, 300, true) },
                    { "block", new Tuple<float, float, float, bool>(14, 0, 60, true) }
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "FineWood", new Tuple<int, int>(8, 8) },
                    { "Bronze", new Tuple<int, int>(6, 3) },
                    { "Guck", new Tuple<int, int>(4, 2) },
                    { "DragonTear", new Tuple<int, int>(1, 0) },
                }
            );
        }

        private void LoadSwords(AssetBundle EmbeddedResourceBundle, VAConfig cfg)
        {
            // Chitin Sword
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg.file,
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
                    { "slash", new Tuple<float, float, float, bool>(35, 0, 120, true) }
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "LeatherScraps", new Tuple<int, int>(3, 2) },
                    { "Bronze", new Tuple<int, int>(2, 1) },
                    { "Chitin", new Tuple<int, int>(8, 4) },
                }
            );

            // Bronze Greatsword
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg.file,
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
                    { "block", new Tuple<float, float, float, bool>(12, 0, 60, true) }
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
                cfg.file,
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
                    { "block", new Tuple<float, float, float, bool>(24, 0, 60, true) }
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Bronze", new Tuple<int, int>(25, 8) },
                    { "RoundLog", new Tuple<int, int>(8, 2) }
                }
            );

            // Silver Greatsword
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg.file,
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
                    { "block", new Tuple<float, float, float, bool>(38, 0, 60, true) }
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
                cfg.file,
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
                    { "chop", new Tuple<float, float, float, bool>(65, 0, 200, true) },
                    { "block", new Tuple<float, float, float, bool>(12, 0, 60, true) }
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Bronze", new Tuple<int, int>(25, 6) },
                    { "RoundLog", new Tuple<int, int>(8, 2) },
                    { "LeatherScraps", new Tuple<int, int>(4, 2) }
                }
            );

            // Blackmetal Battleaxe
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg.file,
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
                    { "chop", new Tuple<float, float, float, bool>(120, 0, 300, true) },
                    { "fire", new Tuple<float, float, float, bool>(70, 0, 160, true) },
                    { "block", new Tuple<float, float, float, bool>(52, 0, 60, true) }
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
                cfg.file,
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
                    { "lightning", new Tuple<float, float, float, bool>(45, 0, 120, true) },
                    { "block", new Tuple<float, float, float, bool>(48, 0, 60, true) }
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
        }

        private void LoadAtgeirs(AssetBundle EmbeddedResourceBundle, VAConfig cfg)
        {
            // Antler Atgeir
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg.file,
                new Dictionary<string, string>() {
                    { "name", "Antler Atgeir" },
                    { "catagory", "Atgeirs" },
                    { "prefab", "VAatgeir_antler" },
                    { "sprite", "antler_atgeir_large" },
                    { "craftedAt", "piece_workbench" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "slash", new Tuple<float, float, float, bool>(25, 0, 90, true) },
                    { "lightning", new Tuple<float, float, float, bool>(5, 0, 25, true) },
                    { "block", new Tuple<float, float, float, bool>(12, 0, 60, true) }
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "Wood", new Tuple<int, int>(24, 8) },
                    { "HardAntler", new Tuple<int, int>(4, 2) },
                    { "Resin", new Tuple<int, int>(4, 2) }
                }
            );

            // Royal Abyssal Atgeir
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg.file,
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
                    { "slash", new Tuple<float, float, float, bool>(35, 0, 120, true) },
                    { "spirit", new Tuple<float, float, float, bool>(25, 0, 120, true) },
                    { "block", new Tuple<float, float, float, bool>(28, 0, 60, true) }
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
            // Bronze Crossbow
            new ValArmoryItem(
                EmbeddedResourceBundle,
                cfg.file,
                new Dictionary<string, string>() {
                    { "name", "Serpent Scale Buckler" },
                    { "catagory", "Shields" },
                    { "prefab", "VAserpent_buckler" },
                    { "sprite", "serpentscale_shield2" },
                    { "craftedAt", "forge" }
                },
                new Dictionary<string, Tuple<float, float, float, bool>>() {
                    { "amount", new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { "block", new Tuple<float, float, float, bool>(48, 0, 120, true) }
                },
                new Dictionary<string, bool>() { },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "SerpentScale", new Tuple<int, int>(6, 4) },
                    { "FineWood", new Tuple<int, int>(3, 1) },
                    { "Iron", new Tuple<int, int>(3, 2) }
                }
            );
        }
    }

    class ValArmoryItem
    {
        String[] allowed_catagories = {"Arrows", "Atgeirs", "Axes", "Bows", "Hammers", "Shields", "Swords" };
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
            ConfigFile cfg,
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
            // needed metadata - item name without spaces
            metadata["short_item_name"] = string.Join("", metadata["name"].Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));

            // create config
            CreateConfigValues(cfg, metadata, itemdata, itemtoggles);
            // load assets
            GameObject prefab = EmbeddedResourceBundle.LoadAsset<GameObject>($"Assets/Custom/Weapons/{metadata["catagory"]}/{metadata["prefab"]}.prefab");
            Sprite sprite = EmbeddedResourceBundle.LoadAsset<Sprite>($"Assets/Custom/Icons/{metadata["sprite"]}.png");
            // modify item/recipe
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
            AddRecipeForAsset($"VA{metadata["short_item_name"]}", prefab, itemcfg);
        }

        /// <summary>
        ///  Creates configuration values with automated segmentation on weapon type
        /// </summary>
        /// <param name="Config"></param>
        /// <param name="metadata"></param>
        /// <param name="itemdata"></param>
        /// <param name="itemtoggles"></param>
        private void CreateConfigValues(ConfigFile Config, Dictionary<String, String> metadata, Dictionary<String, Tuple<float, float, float, bool>> itemdata, Dictionary<String, bool> itemtoggles)
        {
            BindServerConfig(Config, $"{metadata["catagory"]} - {metadata["name"]}", $"{metadata["short_item_name"]}Enable", true, $"Enable/Disable the {metadata["name"]}.");
            foreach (KeyValuePair<string, bool> entry in itemtoggles)
            {
                BindServerConfig(Config, $"{metadata["catagory"]} - {metadata["name"]}", $"{metadata["short_item_name"]}{entry.Key}", entry.Value, $"{entry.Key} enable(true)/disable(false).", true);
            }
            foreach (KeyValuePair<string, Tuple<float, float, float, bool>> entry in itemdata)
            {
                // Skip this entry if the flag is set for it to be disabled
                if (entry.Value.Item4 == false) { continue; }
                // allow overrides of the min/max damage values passthrough like before
                // allow overrides for advanced section or not, Everything besides enable/disable defaults to advanced currently
                String description;
                int max_value = 200;
                int min_value = 0;
                if (damage_types.Contains(entry.Key)) { description = $"{entry.Key} ({min_value}-{max_value}) Damage Value"; } else { description = $"{entry.Key} ({min_value}-{max_value}) Value"; }
                BindServerConfig(Config, $"{metadata["catagory"]} - {metadata["name"]}", $"{metadata["short_item_name"]}{entry.Key}", entry.Value.Item1, $"{description}", true, entry.Value.Item2, entry.Value.Item3);
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
        /// Helper to bind configs for int types
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
                    case "pierce":
                        item.m_shared.m_damages.m_pierce = entry.Value.Item1;
                    break;
                    case "slash":
                        item.m_shared.m_damages.m_slash = entry.Value.Item1;
                    break;
                    case "attackforce":
                        item.m_shared.m_attackForce = entry.Value.Item1;
                    break;
                    // Harvesting Values
                    case "pickaxe":
                        item.m_shared.m_damages.m_pickaxe = entry.Value.Item1;
                    break;
                    case "chop":
                        item.m_shared.m_damages.m_chop = entry.Value.Item1;
                    break;
                    // Elemental Damage types
                    case "fire":
                        item.m_shared.m_damages.m_fire = entry.Value.Item1;
                    break;
                    case "lightning":
                        item.m_shared.m_damages.m_lightning = entry.Value.Item1;
                    break;
                    case "spirit":
                        item.m_shared.m_damages.m_spirit = entry.Value.Item1;
                    break;
                    case "frost":
                        item.m_shared.m_damages.m_frost = entry.Value.Item1;
                    break;
                    case "poison":
                        item.m_shared.m_damages.m_poison = entry.Value.Item1;
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

                    default:
                    break;
                }
            }
        }


    }
}
