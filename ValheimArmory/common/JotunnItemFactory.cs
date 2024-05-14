using BepInEx.Configuration;
using HarmonyLib;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using UnityEngine;
using static ItemDrop;
using static UnityEngine.EventSystems.EventTrigger;
using Logger = Jotunn.Logger;

namespace ValheimArmory.common
{
    class JotunnItemFactory
    {
        enum Catagories
        {
            Arrows,
            Atgeirs,
            Axes,
            Hammers,
            Shields,
            Swords,
            Spears,
            Daggers,
            Maces,
            Fists,
            Pickaxes,
            Magics
        }
        enum DamageTypes
        {
            blunt,
            pierce,
            slash,
            fire,
            spirit,
            lightning,
            frost,
            poison,
            chop
        }

        public static AssetBundle Assets;

        public JotunnItemFactory(AssetBundle EmbeddedResourceBundle)
        {
            Assets = EmbeddedResourceBundle;
        }

        public class JotunnItem
        {
            Dictionary<String, String> ItemMetadata;
            Dictionary<String, Tuple<float, float, float, bool>> ItemData;
            Dictionary<String, bool> ItemToggles;
            Dictionary<String, Tuple<int, int>> RecipeData;
            Dictionary<String, int> ItemSettings;
            GameObject ItemPrefab;
            Sprite ItemSprite;

            Dictionary<String, ConfigEntry<float>> ItemDataConfigs = new Dictionary<String, ConfigEntry<float>>() { };
            Dictionary<String, Tuple<int, int>> UpdatedRecipeData = new Dictionary<string, Tuple<int, int>>() { };

            ConfigEntry<Boolean> CraftableConfig;
            ConfigEntry<int> StationRequiredLevel;
            ConfigEntry<String> CraftedAt;
            ConfigEntry<String> RecipeConfig;

            CustomItem ItemCI;
            static String ItemRecipeName;

            public JotunnItem(
            Dictionary<String, String> metadata,
            Dictionary<String, Tuple<float, float, float, bool>> itemdata,
            Dictionary<String, bool> itemtoggles,
            Dictionary<String, Tuple<int, int>> recipedata,
            Dictionary<String, int> itemsettings = null
            )
            {
                // Set defaults up
                if (itemsettings == null) itemsettings = new Dictionary<String, int>();

                // class object attribute assignment
                ItemMetadata = metadata;
                ItemData = itemdata;
                ItemToggles = itemtoggles;
                RecipeData = recipedata;
                ItemSettings = itemsettings;

                // Add the internal short name
                ItemMetadata["short_item_name"] = string.Join("", metadata["name"].Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));

                // Add universal defaults
                if (!ItemToggles.ContainsKey("enabled")) { ItemToggles.Add("enabled", true); }
                if (!ItemToggles.ContainsKey("craftable")) { ItemToggles.Add("craftable", true); }
                if (!ItemSettings.ContainsKey("stationRequiredLevel")) { ItemSettings.Add("stationRequiredLevel", 1); }

                // Init and load configuration values
                InitItemConfigs();

                // Skip this item if the configuration is set to disable it (only checked on startup)
                if (ItemToggles["enabled"] == false) { return; }

                // Set asset references
                ItemPrefab = Assets.LoadAsset<GameObject>($"Assets/Custom/Weapons/{ItemMetadata["catagory"]}/{ItemMetadata["prefab"]}.prefab");
                ItemSprite = Assets.LoadAsset<Sprite>($"Assets/Custom/Icons/{ItemMetadata["sprite"]}.png");

                // Initial item creation
                InitialItemSetup();
            }

            private void InitItemConfigs()
            {
                // Populate defaults if they don't exist
                // Enabling/Disabling the item is ONLY done at startup, not on the fly
                ItemToggles["enabled"] = VAConfig.BindServerConfig($"{ItemMetadata["catagory"]} - {ItemMetadata["name"]}", $"{ItemMetadata["short_item_name"]}-enabled", ItemToggles["enabled"], $"Enable/Disable the {ItemMetadata["name"]}.").Value;
                // Set the item to be craftable or not.
                CraftableConfig = VAConfig.BindServerConfig($"{ItemMetadata["catagory"]} - {ItemMetadata["name"]}", $"{ItemMetadata["short_item_name"]}-craftable", ItemToggles["craftable"], $"Enable/Disable the crafting recipe for {ItemMetadata["name"]}.");
                ItemToggles["craftable"] = CraftableConfig.Value;
                CraftableConfig.SettingChanged += RecipeConfig_SettingChanged;
                // Set crafting station level required
                StationRequiredLevel = VAConfig.BindServerConfig($"{ItemMetadata["catagory"]} - {ItemMetadata["name"]}", $"{ItemMetadata["short_item_name"]}-stationRequiredLevel", ItemSettings["stationRequiredLevel"], $"Sets the required minimum crafting station level to craft {ItemMetadata["name"]}", true, 1, 4);
                ItemSettings["stationRequiredLevel"] = StationRequiredLevel.Value;
                StationRequiredLevel.SettingChanged += RecipeConfig_SettingChanged;

                // Set where the recipe can be crafted
                CraftedAt = VAConfig.BindServerConfig($"{ItemMetadata["catagory"]} - {ItemMetadata["name"]}", $"{ItemMetadata["short_item_name"]}-CraftedAt", ItemMetadata["craftedAt"], $"Where the recipe is crafted at, eg: 'forge', 'piece_workbench', 'blackforge', 'piece_artisanstation'.");
                ItemMetadata["craftedAt"] = CraftedAt.Value;
                CraftedAt.SettingChanged += RecipeConfig_SettingChanged;

                // Setup Item config modifiers
                foreach (KeyValuePair<string, Tuple<float, float, float, bool>> entry in ItemData)
                {
                    // Skip this entry if the flag is set for it to be disabled, it is not configurable
                    if (entry.Value.Item4 == false) { continue; }
                    ItemDataConfigs.Add(entry.Key, VAConfig.BindServerConfig($"{ItemMetadata["catagory"]} - {ItemMetadata["name"]}", $"{ItemMetadata["short_item_name"]}-{entry.Key}", entry.Value.Item1, $"{entry.Key} ({entry.Value.Item2}-{entry.Value.Item3}) Value", true, entry.Value.Item2, entry.Value.Item3));
                    
                }
                // Wire up the event watch
                foreach (KeyValuePair<string, ConfigEntry<float>> idc_entry in ItemDataConfigs)
                {
                    idc_entry.Value.SettingChanged += ItemConfig_SettingChanged;
                }

            }

            private void InitialItemSetup()
            {
                CreateAndUpdateRecipe();
                RequirementConfig[] recipe = new RequirementConfig[UpdatedRecipeData.Count];
                int recipe_index = 0;
                foreach (KeyValuePair<string, Tuple<int, int>> entry in UpdatedRecipeData)
                {
                    recipe[recipe_index] = new RequirementConfig { Item = entry.Key, Amount = entry.Value.Item1, AmountPerLevel = entry.Value.Item2 };
                    recipe_index++;
                }

                ItemConfig itemcfg = new ItemConfig()
                {
                    Amount = (int)ItemData["amount"].Item1,
                    CraftingStation = $"{ItemMetadata["craftedAt"]}",
                    MinStationLevel = ItemSettings["stationRequiredLevel"],
                    Enabled = ItemToggles["craftable"],
                    Icons = new[] { ItemSprite },
                    Requirements = recipe
                };

                ItemManager.Instance.AddItem(new CustomItem(ItemPrefab, fixReference: true, itemcfg));
                ItemRecipeName = itemcfg.GetRecipe().name;
                ItemCI = ItemManager.Instance.GetItem(ItemPrefab.gameObject.name);
                foreach (KeyValuePair<string, ConfigEntry<float>> idc_entry in ItemDataConfigs)
                {
                    // Run an attribute update once we have a config value bound & the item exists
                    ItemConfigModifier(idc_entry.Key, ItemDataConfigs[idc_entry.Key].Value, ItemCI.ItemDrop);
                }
            }

            private void ItemConfig_SettingChanged(object sender, EventArgs e)
            {
                ConfigEntry<float> sendEntry = (ConfigEntry<float>)sender;
                String target_attribute = sendEntry.Definition.Key.Split('-')[1];
                Logger.LogInfo($"ItemConfigUpdate triggered: {target_attribute}");
                // Update the parent gameobject
                ItemConfigModifier(target_attribute, sendEntry.Value, ItemCI.ItemDrop);

                // Get and update all of the in-scene game objects
                var objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == ItemMetadata["prefab"]);
                foreach( GameObject go in objects)
                {
                    Logger.LogInfo($"Found {go.name}");
                    ItemConfigModifier(target_attribute, sendEntry.Value, go.GetComponent<ItemDrop>());
                }

                // Update all instances that are in the backpack
                foreach (ItemDrop.ItemData user_item in Player.m_localPlayer.m_inventory.GetAllItems())
                {
                    if(user_item.m_dropPrefab.name != ItemMetadata["prefab"]) { continue; }

                    ItemDataConfigModifier(target_attribute, sendEntry.Value, user_item);
                }
            }



            private void RecipeConfig_SettingChanged(object sender, EventArgs e)
            {
                RequirementConfig[] recipe = new RequirementConfig[UpdatedRecipeData.Count];
                int recipe_index = 0;
                Logger.LogInfo("Validating and building requirementsConfig");
                foreach (KeyValuePair<string, Tuple<int, int>> entry in UpdatedRecipeData)
                {
                Logger.LogInfo($"Checking entry {entry.Key}");
                    if (PrefabManager.Instance.GetPrefab(entry.Key) == null) {
                        Logger.LogInfo($"{entry.Key} is not a valid prefab, skipping recipe update.");
                        return;
                    }
                    recipe[recipe_index] = new RequirementConfig { Item = entry.Key, Amount = entry.Value.Item1, AmountPerLevel = entry.Value.Item2 };
                    recipe_index++;
                }
                Logger.LogInfo("Creating custom recipe");
                CustomRecipe updatedCustomRecipe = new CustomRecipe(new RecipeConfig()
                {
                    Name = $"{ItemPrefab.gameObject.name}_recipe",
                    Amount = (int)ItemData["amount"].Item1,
                    CraftingStation = CraftedAt.Value,
                    MinStationLevel = StationRequiredLevel.Value,
                    Enabled = CraftableConfig.Value,
                    Requirements = recipe
                });

                Logger.LogInfo("Checking craftable toggle.");
                // Enable/disable recipe
                if (ItemToggles["craftable"])
                {
                    Logger.LogInfo("Updating Recipe.");
                    // Add the recipe
                    ItemCI.Recipe = updatedCustomRecipe;

                    
                    // Update the recipe if it does not exist
                    CustomRecipe curCrecipe = ItemManager.Instance.GetRecipe(ItemRecipeName);
                    if (curCrecipe != null && curCrecipe.Recipe != updatedCustomRecipe.Recipe)
                    {
                        Logger.LogInfo("Updating Registered Recipe");
                        // This can be replaced once ItemManger supports simply removing the recipe and/or updating the recipe in the objectDB
                        HashSet<CustomRecipe> hashsetRecipes = AccessTools.Field(typeof(ItemManager), "Recipes").GetValue(ItemManager.Instance) as HashSet<CustomRecipe>;
                        // We dont use the removeRecipe here because it removes the recipe from the DB also, which we want to avoid, at least until the Add recipe adds to DB outside of awake
                        // ItemManager.Instance.RemoveRecipe(ItemRecipeName);
                        // ItemManager.Instance.AddRecipe(updatedCustomRecipe);
                        // Logger.LogInfo("Updating Recipe in Object DB");

                        int arindex = ObjectDB.instance.m_recipes.IndexOf(curCrecipe.Recipe);
                        if (arindex > -1) {
                            CustomRecipe targetRecipe = updatedCustomRecipe;
                            if (targetRecipe != null)
                            {
                                Logger.LogInfo("Recipe found in the ObjectDB, updating...");
                                // Update the DB
                                //activeRecipe.m_resources = updatedCustomRecipe.Recipe.m_resources;

                                // Resolve the recipe to ingame items.
                                foreach (var res in targetRecipe.Recipe.m_resources)
                                {
                                    var prefab = ObjectDB.instance.GetItemPrefab(res.m_resItem.name.Replace("JVLmock_", ""));
                                    if (prefab != null)
                                    {
                                        res.m_resItem = prefab.GetComponent<ItemDrop>();
                                    }
                                }
                                //Logger.LogInfo($"Recipe set: {targetRecipe}");

                                ObjectDB.instance.m_recipes[arindex].m_resources = targetRecipe.Recipe.m_resources;
                            }
                            else
                            {
                                Logger.LogWarning("Recipe not found in the ObjectDB.");
                            }
                        }

                        if (hashsetRecipes != null && hashsetRecipes.Contains(curCrecipe))
                        {
                            Logger.LogInfo("Replacing old recipe from ItemManager");
                            hashsetRecipes.Remove(curCrecipe);
                            hashsetRecipes.Add(new CustomRecipe(updatedCustomRecipe.Recipe, false, false));
                        }
                    }
                    // Update the tracked recipe name incase it changed
                    ItemRecipeName = updatedCustomRecipe.Recipe.name;
                    ItemManager.Instance.AddRecipe(updatedCustomRecipe);
                }
                else
                {
                    // Remove the recipe if this is not craftable
                    ItemManager.Instance.RemoveRecipe(updatedCustomRecipe);
                }
                Logger.LogInfo("Finished Recipe updates.");
            }

            // Adapted from Probablykory - for retrieval of a recipe from the live objectDB
            // https://github.com/probablykory/valheim-mods/blob/main/MoreCrossbows/Extensions.cs#L40
            static private Recipe GetRecipeFromDB(Recipe recipe)
            {
                int index = ObjectDB.instance.m_recipes.IndexOf(recipe);
                if (index > -1)
                {
                    return ObjectDB.instance.m_recipes[index];
                }
                string name = recipe.ToString();
                return ObjectDB.instance.m_recipes.FirstOrDefault(r => name.Equals(r.ToString()));
            }


            private void CreateAndUpdateRecipe()
            {
                // default recipe config
                String recipe_cfg_default = "";
                foreach (KeyValuePair<string, Tuple<int, int>> entry in RecipeData)
                {
                    if (recipe_cfg_default.Length > 0) { recipe_cfg_default += "|"; }
                    recipe_cfg_default += $"{entry.Key},{entry.Value.Item1},{entry.Value.Item2}";
                }
                RecipeConfig = VAConfig.BindServerConfig($"{ItemMetadata["catagory"]} - {ItemMetadata["name"]}", $"{ItemMetadata["short_item_name"]}-recipe", recipe_cfg_default, $"Recipe to craft and upgrade costs. Find item ids: https://valheim.fandom.com/wiki/Item_IDs, at most 4 costs. Format: resouce_id,craft_cost,upgrade_cost eg: Wood,8,2|Iron,12,4|LeatherScraps,4,0", true);
                RecipeConfigUpdater(RecipeConfig.Value);
                RecipeConfig.SettingChanged += RecipeConfig_SettingChanged;
            }

            private void ItemConfigModifier(String target_attribute, float updatedValue, ItemDrop itemDropScript)
            {
                ItemDataConfigModifier(target_attribute, updatedValue, itemDropScript.m_itemData);
            }

            private void ItemDataConfigModifier(String target_attribute, float updatedValue, ItemDrop.ItemData itemData)
            {

                switch (target_attribute)
                {
                    // Standard Dmg types
                    case "slash":
                        itemData.m_shared.m_damages.m_slash = updatedValue;
                        break;
                    case "slash_per_level":
                        itemData.m_shared.m_damagesPerLevel.m_slash = updatedValue;
                        break;
                    case "blunt":
                        itemData.m_shared.m_damages.m_blunt = updatedValue;
                        break;
                    case "blunt_per_level":
                        itemData.m_shared.m_damagesPerLevel.m_blunt = updatedValue;
                        break;
                    case "pierce":
                        itemData.m_shared.m_damages.m_pierce = updatedValue;
                        break;
                    case "pierce_per_level":
                        itemData.m_shared.m_damagesPerLevel.m_pierce = updatedValue;
                        break;
                    // Special Damage Types
                    case "pickaxe":
                        itemData.m_shared.m_damages.m_pickaxe = updatedValue;
                        break;
                    case "pickaxe_per_level":
                        itemData.m_shared.m_damagesPerLevel.m_pickaxe = updatedValue;
                        break;
                    case "chop":
                        itemData.m_shared.m_damages.m_chop = updatedValue;
                        break;
                    case "chop_per_level":
                        itemData.m_shared.m_damagesPerLevel.m_chop = updatedValue;
                        break;
                    case "attack_force":
                        itemData.m_shared.m_attackForce = updatedValue;
                        break;
                    // Elemental Damage Types
                    case "fire":
                        itemData.m_shared.m_damages.m_fire = updatedValue;
                        break;
                    case "fire_per_level":
                        itemData.m_shared.m_damagesPerLevel.m_fire = updatedValue;
                        break;
                    case "lightning":
                        itemData.m_shared.m_damages.m_lightning = updatedValue;
                        break;
                    case "lightning_per_level":
                        itemData.m_shared.m_damagesPerLevel.m_lightning = updatedValue;
                        break;
                    case "frost":
                        itemData.m_shared.m_damages.m_frost = updatedValue;
                        break;
                    case "frost_per_level":
                        itemData.m_shared.m_damagesPerLevel.m_frost = updatedValue;
                        break;
                    case "poison":
                        itemData.m_shared.m_damages.m_poison = updatedValue;
                        break;
                    case "poison_per_level":
                        itemData.m_shared.m_damagesPerLevel.m_poison = updatedValue;
                        break;
                    case "spirit":
                        itemData.m_shared.m_damages.m_spirit = updatedValue;
                        break;
                    case "spirit_per_level":
                        itemData.m_shared.m_damagesPerLevel.m_spirit = updatedValue;
                        break;
                    // Block and parry
                    case "block":
                        itemData.m_shared.m_blockPower = updatedValue;
                        break;
                    case "block_per_level":
                        itemData.m_shared.m_blockPowerPerLevel = updatedValue;
                        break;
                    case "parry":
                        itemData.m_shared.m_timedBlockBonus = updatedValue;
                        break;
                    case "block_force":
                        itemData.m_shared.m_deflectionForce = updatedValue;
                        break;
                    case "block_force_per_level":
                        itemData.m_shared.m_deflectionForcePerLevel = updatedValue;
                        break;
                    // Costs for attack types
                    case "primary_attack_stamina":
                        itemData.m_shared.m_attack.m_attackStamina = updatedValue;
                        break;
                    case "primary_attack_eitr":
                        itemData.m_shared.m_attack.m_attackEitr = updatedValue;
                        break;
                    case "primary_attack_flat_health_cost":
                        itemData.m_shared.m_attack.m_attackHealth = updatedValue;
                        break;
                    case "primary_attack_percent_health_cost":
                        itemData.m_shared.m_attack.m_attackHealthPercentage = updatedValue;
                        break;
                    case "secondary_attack_stamina":
                        itemData.m_shared.m_secondaryAttack.m_attackStamina = updatedValue;
                        break;
                    case "secondary_attack_eitr":
                        itemData.m_shared.m_secondaryAttack.m_attackEitr = updatedValue;
                        break;
                    case "secondary_attack_flat_health_cost":
                        itemData.m_shared.m_secondaryAttack.m_attackHealth = updatedValue;
                        break;
                    case "secondary_attack_percent_health_cost":
                        itemData.m_shared.m_secondaryAttack.m_attackHealthPercentage = updatedValue;
                        break;
                    // Speed Modifiers
                    case "movement_speed":
                        itemData.m_shared.m_movementModifier = (float)updatedValue / 100f;
                        break;
                    case "bow_draw_speed":
                        itemData.m_shared.m_attack.m_drawDurationMin = ItemData["bow_draw_speed"].Item1 * (updatedValue / 100);
                        break;
                    case "crossbow_reload_speed":
                        itemData.m_shared.m_attack.m_reloadTime = ItemData["crossbow_reload_speed"].Item1 * (updatedValue / 100);
                        break;
                    case "draw_stamina_drain":
                        itemData.m_shared.m_attack.m_drawStaminaDrain = updatedValue;
                        break;
                    // Item Modifiers
                    case "durability":
                        itemData.m_shared.m_maxDurability = updatedValue;
                        break;
                    case "durability_per_level":
                        itemData.m_shared.m_durabilityPerLevel = updatedValue;
                        break;
                    case "max_item_level":
                        itemData.m_shared.m_maxQuality = (int)updatedValue;
                        break;
                    case "amount":
                        // we don't modify the amount as an item attribute, its for recipes.
                        break;

                    default:
                        Logger.LogWarning($"{target_attribute} was not modified, ensure the pattern is correct.");
                        break;
                }
            }

            private void RecipeConfigUpdater(String rawrecipe)
            {
                String[] RawRecipeEntries = rawrecipe.Split('|');
                // Logger.LogInfo($"{RawRecipeEntries.Length} {string.Join(", ", RawRecipeEntries)}");
                Dictionary<String, Tuple<int, int>> updated_recipe = new Dictionary<String, Tuple<int, int>>();
                // we only clear out the default recipe if there is recipe data provided, otherwise we will continue to use the default recipe
                // TODO: Add a sanity check to ensure that recipe formatting is correct
                if (RawRecipeEntries.Length >= 1)
                {
                    foreach (String recipe_entry in RawRecipeEntries)
                    {
                        //Logger.LogInfo($"{recipe_entry}");
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
                        if (VAConfig.EnableDebugMode.Value == true)
                        {
                            Logger.LogInfo($"prefab: {recipe_segments[0]} c:{recipe_segments[1]} u:{recipe_segments[2]}");
                        }
                        updated_recipe.Add(recipe_segments[0], new Tuple<int, int>(Int32.Parse(recipe_segments[1]), Int32.Parse((recipe_segments[2]))));
                    }
                    //Logger.LogInfo("Done parsing recipe");
                    foreach (KeyValuePair<string, Tuple<int, int>> entry in updated_recipe)
                    {
                        UpdatedRecipeData.Add(entry.Key, entry.Value);
                    }
                    //Logger.LogInfo("Set UpdatedRecipe");
                    if (VAConfig.EnableDebugMode.Value == true) {
                        String recipe_string = "";
                        foreach (KeyValuePair<string, Tuple<int, int>> entry in updated_recipe)
                        {
                            recipe_string += $" {entry.Key} c:{entry.Value.Item1} u:{entry.Value.Item2}";
                        }
                        Logger.LogInfo($"Updated recipe:{recipe_string}"); 
                    }
                }
                else
                {
                    Logger.LogWarning($"Invalid recipe: {rawrecipe}. defaults will be used. Check your prefab names.");
                    UpdatedRecipeData = RecipeData;
                }
            }
        }




    }
}
