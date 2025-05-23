﻿using BepInEx.Configuration;
using HarmonyLib;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static InventoryGrid;

namespace ValheimArmory.common
{
    enum ItemStat
    {
        slash,
        slash_per_level,
        blunt,
        blunt_per_level,
        pierce,
        pierce_per_level,
        pickaxe,
        pickaxe_per_level,
        chop,
        chop_per_level,
        attack_force,
        fire,
        fire_per_level,
        lightning,
        lightning_per_level,
        frost,
        frost_per_level,
        poison,
        poison_per_level,
        spirit,
        spirit_per_level,
        block_armor,
        block_armor_per_level,
        parry,
        block_force,
        block_force_per_level,
        primary_attack_stamina,
        primary_attack_eitr,
        primary_attack_flat_health_cost,
        primary_attack_percent_health_cost,
        secondary_attack_stamina,
        secondary_attack_eitr,
        secondary_attack_flat_health_cost,
        secondary_attack_percent_health_cost,
        movement_speed,
        bow_draw_speed,
        crossbow_reload_speed,
        crossbow_reload_stamina_drain,
        draw_stamina_drain,
        projectile_velocity,
        durability,
        durability_per_level,
        max_item_level,
        amount,
        tool_level
    }

    enum ItemToggles
    {
        enabled,
        craftable,
    }

    enum ItemMetadata
    {
        name,
        prefab,
        sprite,
        catagory,
        craftedAt,
        shortName
    }

    enum ItemSettings
    {
        stationRequiredLevel
    }

    class JotunnItemFactory
    {

        public static AssetBundle Assets;
        internal static readonly AcceptableValueList<string> allowedModifiers = new AcceptableValueList<string>(new string[] 
            { 
                HitData.DamageModifier.Normal.ToString(), 
                HitData.DamageModifier.VeryWeak.ToString(), 
                HitData.DamageModifier.Weak.ToString(), 
                HitData.DamageModifier.VeryWeak.ToString(), 
                HitData.DamageModifier.Resistant.ToString(), 
                HitData.DamageModifier.VeryResistant.ToString(), 
                HitData.DamageModifier.Immune.ToString() 
            });

        public JotunnItemFactory(AssetBundle EmbeddedResourceBundle)
        {
            Assets = EmbeddedResourceBundle;
        }

        public class JotunnItem : MonoBehaviour
        {
            Dictionary<ItemMetadata, String> ItemMdata;
            Dictionary<ItemStat, Tuple<float, float, float, bool>> ItemData;
            Dictionary<ItemToggles, bool> ItemToggles;
            Dictionary<String, Tuple<int, int>> RecipeData;
            Dictionary<ItemSettings, int> ItemSettings;
            Dictionary<HitData.DamageType, HitData.DamageModifier> ItemModifiers;
            GameObject ItemPrefab;
            Sprite ItemSprite;
            ZNetView nview;

            Dictionary<String, ConfigEntry<float>> ItemDataConfigs = new Dictionary<String, ConfigEntry<float>>() { };
            Dictionary<String, Tuple<int, int>> UpdatedRecipeData = new Dictionary<string, Tuple<int, int>>() { };
            Dictionary<HitData.DamageType, ConfigEntry<string>> ItemModifiersConfigs = new Dictionary<HitData.DamageType, ConfigEntry<string>>() { };

            ConfigEntry<Boolean> CraftableConfig;
            ConfigEntry<int> StationRequiredLevel;
            ConfigEntry<String> CraftedAt;
            ConfigEntry<float> CraftAmount;
            ConfigEntry<String> RecipeConfig;

            CustomItem ItemCI;
            String ItemRecipeName;

            public JotunnItem(
            Dictionary<ItemMetadata, String> metadata,
            Dictionary<ItemStat, Tuple<float, float, float, bool>> itemdata,
            Dictionary<String, Tuple<int, int>> recipedata,
            Dictionary<ItemSettings, int> itemsettings = null,
            Dictionary<ItemToggles, bool> itemtoggles = null,
            Dictionary<HitData.DamageType, HitData.DamageModifier> itemModifiers = null
            )
            {
                // Set defaults up
                if (itemsettings == null) itemsettings = new Dictionary<ItemSettings, int>();
                if (itemModifiers == null) itemModifiers = new Dictionary<HitData.DamageType, HitData.DamageModifier>();
                if (itemtoggles == null) itemtoggles = new Dictionary<ItemToggles, bool>();

                // class object attribute assignment
                ItemMdata = metadata;
                ItemData = itemdata;
                ItemToggles = itemtoggles;
                RecipeData = recipedata;
                ItemSettings = itemsettings;
                ItemModifiers = itemModifiers;

                // Add the internal short name
                ItemMdata[ItemMetadata.shortName] = string.Join("", metadata[ItemMetadata.name].Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));

                // Add universal defaults
                if (!ItemToggles.ContainsKey(common.ItemToggles.enabled)) { ItemToggles.Add(common.ItemToggles.enabled, true); }
                if (!ItemToggles.ContainsKey(common.ItemToggles.craftable)) { ItemToggles.Add(common.ItemToggles.craftable, true); }
                if (!ItemSettings.ContainsKey(common.ItemSettings.stationRequiredLevel)) { ItemSettings.Add(common.ItemSettings.stationRequiredLevel, 1); }

                // Init and load configuration values
                InitItemConfigs();

                // Skip this item if the configuration is set to disable it (only checked on startup)
                if (ItemToggles[common.ItemToggles.enabled] == false) {
                    // Remove items that are not known
                    // This case is generally hit when there is a disconnect between what the client knows and the server knows as added items
                    ItemManager.Instance.RemoveItem(ItemMdata[ItemMetadata.prefab]);
                    return;
                }

                // Set asset references
                ItemPrefab = Assets.LoadAsset<GameObject>($"Assets/Custom/Weapons/{ItemMdata[ItemMetadata.catagory]}/{ItemMdata[ItemMetadata.prefab]}.prefab");
                ItemSprite = Assets.LoadAsset<Sprite>($"Assets/Custom/Icons/{ItemMdata[ItemMetadata.sprite]}.png");

                // Initial item creation
                InitialItemSetup();
            }

            private void InitItemConfigs()
            {
                // Populate defaults if they don't exist
                // Enabling/Disabling the item is ONLY done at startup, not on the fly
                ItemToggles[common.ItemToggles.enabled] = VAConfig.BindServerConfig($"{ItemMdata[ItemMetadata.catagory]} - {ItemMdata[ItemMetadata.name]}", $"{ItemMdata[ItemMetadata.shortName]}-enabled", ItemToggles[common.ItemToggles.enabled], $"Enable/Disable the {ItemMdata[ItemMetadata.name]}.").Value;
                // Set the item to be craftable or not.
                CraftableConfig = VAConfig.BindServerConfig($"{ItemMdata[ItemMetadata.catagory]} - {ItemMdata[ItemMetadata.name]}", $"{ItemMdata[ItemMetadata.shortName]}-craftable", ItemToggles[common.ItemToggles.craftable], $"Enable/Disable the crafting recipe for {ItemMdata[ItemMetadata.name]}.");
                ItemToggles[common.ItemToggles.craftable] = CraftableConfig.Value;
                CraftableConfig.SettingChanged += RecipeConfig_SettingChanged;
                // Set crafting station level required
                StationRequiredLevel = VAConfig.BindServerConfig($"{ItemMdata[ItemMetadata.catagory]} - {ItemMdata[ItemMetadata.name]}", $"{ItemMdata[ItemMetadata.shortName]}-stationRequiredLevel", ItemSettings[common.ItemSettings.stationRequiredLevel], $"Sets the required minimum crafting station level to craft {ItemMdata[ItemMetadata.name]}", true, 1, 4);
                ItemSettings[common.ItemSettings.stationRequiredLevel] = StationRequiredLevel.Value;
                StationRequiredLevel.SettingChanged += RecipeConfig_SettingChanged;

                // Set where the recipe can be crafted
                CraftedAt = VAConfig.BindServerConfig($"{ItemMdata[ItemMetadata.catagory]} - {ItemMdata[ItemMetadata.name]}", $"{ItemMdata[ItemMetadata.shortName]}-CraftedAt", ItemMdata[ItemMetadata.craftedAt], $"Where the recipe is crafted at, eg: 'forge', 'piece_workbench', 'blackforge', 'piece_artisanstation'.");
                ItemMdata[ItemMetadata.craftedAt] = CraftedAt.Value;
                CraftedAt.SettingChanged += RecipeConfig_SettingChanged;

                foreach (KeyValuePair<HitData.DamageType, HitData.DamageModifier> entry in ItemModifiers)
                {
                    // Skip this entry if the flag is set for it to be disabled, it is not configurable
                    ItemModifiersConfigs.Add(entry.Key, VAConfig.BindServerConfig($"{ItemMdata[ItemMetadata.catagory]} - {ItemMdata[ItemMetadata.name]}", $"{ItemMdata[ItemMetadata.shortName]}-{entry.Key}-DamageModifier", entry.Value.ToString(), $"Sets a damage modifer for {ItemMdata[ItemMetadata.shortName]} to the damage type {entry.Key.ToString()}", true, allowedModifiers));
                }
                // Wire up the event watch
                foreach (KeyValuePair<HitData.DamageType, ConfigEntry<string>> itc_entry in ItemModifiersConfigs)
                {
                    itc_entry.Value.SettingChanged += ItemModifierConfig_SettingChanged;
                }

                // Setup Item config modifiers
                foreach (KeyValuePair<ItemStat, Tuple<float, float, float, bool>> entry in ItemData)
                {
                    // Skip this entry if the flag is set for it to be disabled, it is not configurable
                    if (entry.Value.Item4 == false) { continue; }
                    if (entry.Key == ItemStat.amount)
                    {
                        CraftAmount = VAConfig.BindServerConfig($"{ItemMdata[ItemMetadata.catagory]} - {ItemMdata[ItemMetadata.name]}", $"{ItemMdata[ItemMetadata.shortName]}-{entry.Key}", entry.Value.Item1, $"{entry.Key} ({entry.Value.Item2}-{entry.Value.Item3}) Value", true, entry.Value.Item2, entry.Value.Item3);
                        CraftAmount.SettingChanged += RecipeConfig_SettingChanged;
                    } else
                    {
                        ItemDataConfigs.Add(entry.Key.ToString(), VAConfig.BindServerConfig($"{ItemMdata[ItemMetadata.catagory]} - {ItemMdata[ItemMetadata.name]}", $"{ItemMdata[ItemMetadata.shortName]}-{entry.Key}", entry.Value.Item1, $"{entry.Key} ({entry.Value.Item2}-{entry.Value.Item3}) Value", true, entry.Value.Item2, entry.Value.Item3));
                    }
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
                foreach (KeyValuePair<string, Tuple<int, int>> entry in UpdatedRecipeData) {
                    recipe[recipe_index] = new RequirementConfig { Item = entry.Key, Amount = entry.Value.Item1, AmountPerLevel = entry.Value.Item2 };
                    recipe_index++;
                }
                int craftedAmountDefault = (int)ItemData[ItemStat.amount].Item1;
                if (ItemData[ItemStat.amount].Item4 == true)
                {
                    // Logger.LogDebug($"Updating configurable crafting amount {CraftAmount.Value}");
                    craftedAmountDefault = (int)CraftAmount.Value;
                }
                ItemConfig itemcfg = new ItemConfig()
                {
                    Amount = craftedAmountDefault,
                    CraftingStation = $"{ItemMdata[ItemMetadata.craftedAt]}",
                    MinStationLevel = ItemSettings[common.ItemSettings.stationRequiredLevel],
                    Enabled = ItemToggles[common.ItemToggles.craftable],
                    Icons = new[] { ItemSprite },
                    Requirements = recipe
                };

                ItemManager.Instance.AddItem(new CustomItem(ItemPrefab, fixReference: true, itemcfg));
                ItemRecipeName = itemcfg.GetRecipe().name;
                ItemCI = ItemManager.Instance.GetItem(ItemPrefab.gameObject.name);
                nview = ItemPrefab.gameObject.GetComponent<ZNetView>();
                // Apply all item stat changes and damage modifiers
                foreach (KeyValuePair<string, ConfigEntry<float>> idc_entry in ItemDataConfigs)
                {
                    // Run an attribute update once we have a config value bound & the item exists
                    ItemConfigModifier((ItemStat)Enum.Parse(typeof(ItemStat), idc_entry.Key), ItemDataConfigs[idc_entry.Key].Value, ItemCI.ItemDrop);
                }
                foreach (KeyValuePair<HitData.DamageType, ConfigEntry<string>> tmc_entry in ItemModifiersConfigs)
                {
                    HitData.DamageModifier modifier = (HitData.DamageModifier)Enum.Parse(typeof(HitData.DamageModifier), tmc_entry.Value.Value);
                    SetItemDamageModifier(modifier, tmc_entry.Key, ItemCI.ItemDrop.m_itemData);
                }
            }

            private void ItemConfig_SettingChanged(object sender, EventArgs e)
            {
                // Logger.LogDebug($"ItemConfigChange Triggered.");
                ConfigEntry<float> sendEntry = (ConfigEntry<float>)sender;
                String target_attribute = sendEntry.Definition.Key.Split('-')[1];
                ItemStat t_attribute = (ItemStat)Enum.Parse(typeof(ItemStat), target_attribute);
                // Logger.LogDebug($"ItemConfigUpdate triggered: {target_attribute}");
                // Update the parent gameobject
                ItemConfigModifier(t_attribute, sendEntry.Value, ItemCI.ItemDrop);

                // Get and update all of the in-scene game objects
                IEnumerable<GameObject> objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name.StartsWith(ItemMdata[ItemMetadata.prefab]));
                // Logger.LogDebug($"Found in scene objects: {objects.Count()}");
                StartCoroutine(UpdateItemDataConfigModifierAsync(objects, t_attribute, sendEntry.Value));
                // Logger.LogDebug($"Checking for the local player.");
                // we don't update the backpack items if the znet isn't valid, because they will get updated from the parent item
                if ((bool)nview && Player.m_localPlayer != null)
                {
                    // Logger.LogDebug($"Modifying items within the players inventory.");
                    // Update all instances that are in the backpack
                    foreach (ItemDrop.ItemData user_item in Player.m_localPlayer.m_inventory.GetAllItems())
                    {
                        if (user_item == null) { continue; }
                        if (user_item.m_dropPrefab.name != ItemMdata[ItemMetadata.prefab]) { continue; }

                        // Logger.LogDebug($"{user_item.m_shared.m_name} found in the players backpack, updating.");
                        ItemDataConfigModifier(t_attribute, sendEntry.Value, user_item);
                    }
                }
                // Logger.LogDebug($"Finished modifying ItemConfig setting.");
            }



            private void RecipeConfig_SettingChanged(object sender, EventArgs e)
            {
                // Only update the recipe items themselves if we are sent a recipe item update, otherwise this is a station or amount update
                if (sender.GetType() == typeof(ConfigEntry<string>))
                {
                    ConfigEntry<string> sendEntry = (ConfigEntry<string>)sender;
                    String target_attribute = sendEntry.Definition.Key.Split('-')[1];
                    if (target_attribute == "CraftedAt") {
                       GameObject craftedAtCheck = PrefabManager.Instance.GetPrefab(sendEntry.Value);
                        if (craftedAtCheck == null) {
                            Logger.LogWarning($"CraftedAt prefab ({sendEntry.Value}) is not valid, recipe will not update.");
                            return;
                        }
                    } else {
                        Logger.LogDebug($"Recieved new recipe config {sendEntry.Value}");
                        // Nothing to do if the recipe is invalid, its just going to be reset to its current recipe
                        if (RecipeConfigUpdater(sendEntry.Value) == false) { return; }
                    }

                }

                RequirementConfig[] recipe = new RequirementConfig[UpdatedRecipeData.Count];
                int recipe_index = 0;
                Logger.LogDebug("Validating and building requirementsConfig");
                foreach (KeyValuePair<string, Tuple<int, int>> entry in UpdatedRecipeData)
                {
                    if (PrefabManager.Instance.GetPrefab(entry.Key) == null) {
                        Logger.LogDebug($"{entry.Key} is not a valid prefab, skipping recipe update.");
                        return;
                    }
                    Logger.LogDebug($"Checking entry {entry.Key} c:{entry.Value.Item1} u:{entry.Value.Item2}");
                    recipe[recipe_index] = new RequirementConfig { Item = entry.Key, Amount = entry.Value.Item1, AmountPerLevel = entry.Value.Item2 };
                    recipe_index++;
                }
                int craftAmount = (int)ItemData[ItemStat.amount].Item1;
                if (CraftAmount != null) { craftAmount = (int)CraftAmount.Value; }
                CustomRecipe updatedCustomRecipe = new CustomRecipe(new RecipeConfig()
                {
                    Name = $"Recipe_{ItemPrefab.gameObject.name}",
                    Amount = craftAmount,
                    CraftingStation = CraftedAt.Value,
                    MinStationLevel = StationRequiredLevel.Value,
                    Enabled = CraftableConfig.Value,
                    Requirements = recipe,
                });
                Logger.LogDebug($"Looking for existing recipe with name: {ItemRecipeName}");
                CustomRecipe curCrecipe = ItemManager.Instance.GetRecipe(ItemRecipeName);

                Logger.LogDebug("Checking craftable toggle.");
                // Enable/disable recipe
                if (ItemToggles[common.ItemToggles.craftable])
                {
                    Logger.LogDebug("Updating Recipe.");
                    // Add the recipe
                    ItemCI.Recipe = updatedCustomRecipe;

                    
                    // Update the recipe
                    //if (curCrecipe != null) 
                    //{
                    //    Logger.LogDebug($"Current recipe found: \nname:{curCrecipe.Recipe.name}\namount:{curCrecipe.Recipe.m_amount}\ncraftedAt:{curCrecipe.Recipe.m_craftingStation.name}\nminStationLevel:{curCrecipe.Recipe.m_minStationLevel}\nrecipeFor:{curCrecipe.Recipe.m_item}\nrepairStation:{curCrecipe.Recipe.m_repairStation}\n");
                    //    foreach (var res in curCrecipe.Recipe.m_resources)
                    //    {
                    //        Logger.LogDebug($"{res.m_resItem.name} req:{res.m_amount} u:{res.m_amountPerLevel}");
                    //    }
                    //}
                    if (curCrecipe != null && curCrecipe.Recipe != updatedCustomRecipe.Recipe)
                    {
                        HashSet<CustomRecipe> hashsetRecipes = AccessTools.Field(typeof(ItemManager), "Recipes").GetValue(ItemManager.Instance) as HashSet<CustomRecipe>;
                        Logger.LogDebug("Updating Registered Recipe");

                        //ItemManager.Instance.RemoveRecipe(curCrecipe);
                        //ItemManager.Instance.AddRecipe(updatedCustomRecipe);
                        // hashsetRecipes.Add(updatedCustomRecipe);
                        if (hashsetRecipes != null)
                        {
                            hashsetRecipes.Remove(curCrecipe);
                            hashsetRecipes.Add(updatedCustomRecipe);
                        }

                        // int current_recipe_i = ObjectDB.instance.m_recipes.IndexOf(curCrecipe.Recipe);
                        ObjectDB.instance.m_recipes.Remove(curCrecipe.Recipe);
                        ObjectDB.instance.m_recipes.Add(updatedCustomRecipe.Recipe);
                        int current_recipe_i = ObjectDB.instance.m_recipes.IndexOf(updatedCustomRecipe.Recipe);

                        //ObjectDB.instance.m_recipes[current_recipe_i].m_minStationLevel = updatedCustomRecipe.Recipe.m_minStationLevel;
                        // Logger.LogDebug("Updating required resources");
                        ObjectDB.instance.m_recipes[current_recipe_i].m_resources = updatedCustomRecipe.Recipe.m_resources;
                        //ObjectDB.instance.m_recipes[current_recipe_i].m_amount = updatedCustomRecipe.Recipe.m_amount;
                        foreach (var res in ObjectDB.instance.m_recipes[current_recipe_i].m_resources)
                        {
                            // Logger.LogDebug($"Recipe resource {res.m_resItem.name} {res.m_amount} updating..");
                            var prefab = ObjectDB.instance.GetItemPrefab(res.m_resItem.name.Replace("JVLmock_", ""));
                            if (prefab != null) {
                                res.m_resItem = prefab.GetComponent<ItemDrop>();
                                // Logger.LogDebug($"{res.m_resItem.name} itemdrop set");
                            }
                        }
                        try
                        {
                            // Logger.LogDebug("Attaching existing item references to recipe");
                            CraftingStation craftable_at = PrefabManager.Instance.GetPrefab(updatedCustomRecipe.Recipe.m_craftingStation.name.Replace("JVLmock_", ""))?.GetComponent<CraftingStation>();
                            ObjectDB.instance.m_recipes[current_recipe_i].m_craftingStation = craftable_at;
                            ObjectDB.instance.m_recipes[current_recipe_i].m_repairStation = craftable_at;
                            ObjectDB.instance.m_recipes[current_recipe_i].m_item = PrefabManager.Instance.GetPrefab(ItemPrefab.gameObject.name)?.GetComponent<ItemDrop>();
                        } catch { }
                    } else
                    {
                        ItemManager.Instance.AddRecipe(updatedCustomRecipe);
                    }
                }
                else
                {
                    // Remove the recipe if this is not craftable
                    ItemManager.Instance.RemoveRecipe(updatedCustomRecipe);
                }
                if (VAConfig.EnableDebugMode.Value == true)
                {
                    Logger.LogDebug("Finished Recipe updates.");
                    int new_recipe_index = ObjectDB.instance.m_recipes.IndexOf(updatedCustomRecipe.Recipe);
                    if (new_recipe_index == -1)
                    {
                        // Logger.LogDebug("Updated recipe not found in the object DB.");
                    }
                    int old_recipe_index = ObjectDB.instance.m_recipes.IndexOf(curCrecipe.Recipe);
                    if (old_recipe_index > -1 )
                    {
                        // Logger.LogDebug("Old recipe still found in the object DB, removing.");
                        Recipe oldRecipe = ObjectDB.instance.m_recipes[old_recipe_index];
                        // Logger.LogDebug($"Old recipe found: \nname:{oldRecipe.name}\namount:{oldRecipe.m_amount}\ncraftedAt:{oldRecipe.m_craftingStation.name}\nminStationLevel:{oldRecipe.m_minStationLevel}");
                        //foreach (var res in oldRecipe.m_resources)
                        //{
                        //    Logger.LogDebug($"{res.m_resItem.name} req:{res.m_amount} u:{res.m_amountPerLevel}");
                        //}

                    }
                    if (new_recipe_index != -1)
                    {
                        Recipe currentRecipe = ObjectDB.instance.m_recipes[new_recipe_index];
                        Logger.LogDebug($"Current recipe found: \nname:{currentRecipe.name}\namount:{currentRecipe.m_amount}\ncraftedAt:{currentRecipe.m_craftingStation.name}\nminStationLevel:{currentRecipe.m_minStationLevel}\nrecipeFor:{currentRecipe.m_item}\nrepairStation:{currentRecipe.m_repairStation.name}\n");
                        foreach (var res in currentRecipe.m_resources)
                        {
                            Logger.LogDebug($"{res.m_resItem.name} req:{res.m_amount} u:{res.m_amountPerLevel}");
                        }
                    }
                }
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
                RecipeConfig = VAConfig.BindServerConfig($"{ItemMdata[ItemMetadata.catagory]} - {ItemMdata[ItemMetadata.name]}", $"{ItemMdata[ItemMetadata.shortName]}-recipe", recipe_cfg_default, $"Recipe to craft and upgrade costs. Find item ids: https://valheim.fandom.com/wiki/Item_IDs, at most 4 costs. Format: resouce_id,craft_cost,upgrade_cost eg: Wood,8,2|Iron,12,4|LeatherScraps,4,0", true);
                if (RecipeConfigUpdater(RecipeConfig.Value, true) == false)
                {
                    // Logger.LogWarning($"{ItemMdata[ItemMetadata.name]} has an invalid recipe. The default will be used instead.");
                    RecipeConfigUpdater(recipe_cfg_default, true);
                }
                RecipeConfig.SettingChanged += RecipeConfig_SettingChanged;
            }

            private void ItemConfigModifier(ItemStat target_attribute, float updatedValue, ItemDrop itemDropScript)
            {
                ItemDataConfigModifier(target_attribute, updatedValue, itemDropScript.m_itemData);
            }

            private void ItemModifierConfig_SettingChanged(object sender, EventArgs e)
            {
                // Logger.LogDebug($"ItemModifierConfig Triggered.");
                ConfigEntry<string> sendEntry = (ConfigEntry<string>)sender;
                String target_attribute = sendEntry.Definition.Key.Split('-')[1];
                HitData.DamageType type = (HitData.DamageType)Enum.Parse(typeof(HitData.DamageType), target_attribute);
                HitData.DamageModifier modifier = (HitData.DamageModifier)Enum.Parse(typeof(HitData.DamageModifier), sendEntry.Value);
                SetItemDamageModifier(modifier, type, ItemCI.ItemDrop.m_itemData);

                // Get and update all of the in-scene game objects
                IEnumerable<GameObject> objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name.StartsWith(ItemMdata[ItemMetadata.prefab]));
                StartCoroutine(UpdateItemDamageConfigModifierAsync(objects, modifier, type));
                // Logger.LogDebug($"Checking for the local player.");
                // we don't update the backpack items if the znet isn't valid, because they will get updated from the parent item
                if ((bool)nview && Player.m_localPlayer != null)
                {
                    // Logger.LogDebug($"Modifying items within the players inventory.");
                    // Update all instances that are in the backpack
                    foreach (ItemDrop.ItemData user_item in Player.m_localPlayer.m_inventory.GetAllItems())
                    {
                        if (user_item == null) { continue; }
                        if (user_item.m_dropPrefab.name != ItemMdata[ItemMetadata.prefab]) { continue; }

                        // Logger.LogDebug($"{user_item.m_shared.m_name} found in the players backpack, updating.");
                        SetItemDamageModifier(modifier, type, user_item);
                    }
                }
                // Logger.LogDebug($"Finished modifying ItemDamageModifier setting.");
            }

            static IEnumerator UpdateItemDamageConfigModifierAsync(IEnumerable<GameObject> objects, HitData.DamageModifier dmg_mod, HitData.DamageType dmg_type)
            {
                int concurrent_updates = VAConfig.InMemoryModificationsPerTick.Value;
                int update_num = 0;
                foreach (GameObject go in objects) {
                    if (update_num >= concurrent_updates)
                    {
                        yield return new WaitForSeconds(0.5f);
                        update_num = 0;
                    }
                    ItemDrop id = null;
                    if (go.TryGetComponent<ItemDrop>(out id)){
                        SetItemDamageModifier(dmg_mod, dmg_type, id.m_itemData);
                    }
                }
            }

            static IEnumerator UpdateItemDataConfigModifierAsync(IEnumerable<GameObject> objects, ItemStat t_attribute, float updated_value)
            {
                int concurrent_updates = VAConfig.InMemoryModificationsPerTick.Value;
                int update_num = 0;
                foreach (GameObject go in objects)
                {
                    if (update_num >= concurrent_updates)
                    {
                        yield return new WaitForSeconds(0.5f);
                        update_num = 0;
                    }
                    ItemDrop id = null;
                    if (go.TryGetComponent<ItemDrop>(out id))
                    {
                        // Logger.LogDebug($"{go.name} updating attribute {target_attribute}");
                        ItemDataConfigModifier(t_attribute, updated_value, id.m_itemData);
                    }
                }
            }

            private static void SetItemDamageModifier(HitData.DamageModifier modifier, HitData.DamageType type, ItemDrop.ItemData itemData)
            {
                List<HitData.DamageModPair> temp = itemData.m_shared.m_damageModifiers.Where(entry => entry.m_type != type).ToList();
                if (temp.Count == 0) {
                    itemData.m_shared.m_damageModifiers.Clear();
                    itemData.m_shared.m_damageModifiers.Add(new HitData.DamageModPair() { m_modifier = modifier, m_type = type } );
                } else {
                    temp.Add(new HitData.DamageModPair() { m_modifier = modifier, m_type = type });
                    itemData.m_shared.m_damageModifiers = temp;
                }
            }

            private static void ItemDataConfigModifier(ItemStat target_attribute, float updatedValue, ItemDrop.ItemData itemData)
            {
                if (itemData == null) { return; }
                // Logger.LogDebug($"Updating {target_attribute} to {updatedValue}");
                switch (target_attribute)
                {
                    // Standard Dmg types
                    case ItemStat.slash:
                        itemData.m_shared.m_damages.m_slash = updatedValue;
                        break;
                    case ItemStat.slash_per_level:
                        itemData.m_shared.m_damagesPerLevel.m_slash = updatedValue;
                        break;
                    case ItemStat.blunt:
                        itemData.m_shared.m_damages.m_blunt = updatedValue;
                        break;
                    case ItemStat.blunt_per_level:
                        itemData.m_shared.m_damagesPerLevel.m_blunt = updatedValue;
                        break;
                    case ItemStat.pierce:
                        itemData.m_shared.m_damages.m_pierce = updatedValue;
                        break;
                    case ItemStat.pierce_per_level:
                        itemData.m_shared.m_damagesPerLevel.m_pierce = updatedValue;
                        break;
                    // Special Damage Types
                    case ItemStat.pickaxe:
                        itemData.m_shared.m_damages.m_pickaxe = updatedValue;
                        break;
                    case ItemStat.pickaxe_per_level:
                        itemData.m_shared.m_damagesPerLevel.m_pickaxe = updatedValue;
                        break;
                    case ItemStat.chop:
                        itemData.m_shared.m_damages.m_chop = updatedValue;
                        break;
                    case ItemStat.chop_per_level:
                        itemData.m_shared.m_damagesPerLevel.m_chop = updatedValue;
                        break;
                    case ItemStat.attack_force:
                        itemData.m_shared.m_attackForce = updatedValue;
                        break;
                    // Elemental Damage Types
                    case ItemStat.fire:
                        itemData.m_shared.m_damages.m_fire = updatedValue;
                        break;
                    case ItemStat.fire_per_level:
                        itemData.m_shared.m_damagesPerLevel.m_fire = updatedValue;
                        break;
                    case ItemStat.lightning:
                        itemData.m_shared.m_damages.m_lightning = updatedValue;
                        break;
                    case ItemStat.lightning_per_level:
                        itemData.m_shared.m_damagesPerLevel.m_lightning = updatedValue;
                        break;
                    case ItemStat.frost:
                        itemData.m_shared.m_damages.m_frost = updatedValue;
                        break;
                    case ItemStat.frost_per_level:
                        itemData.m_shared.m_damagesPerLevel.m_frost = updatedValue;
                        break;
                    case ItemStat.poison:
                        itemData.m_shared.m_damages.m_poison = updatedValue;
                        break;
                    case ItemStat.poison_per_level:
                        itemData.m_shared.m_damagesPerLevel.m_poison = updatedValue;
                        break;
                    case ItemStat.spirit:
                        itemData.m_shared.m_damages.m_spirit = updatedValue;
                        break;
                    case ItemStat.spirit_per_level:
                        itemData.m_shared.m_damagesPerLevel.m_spirit = updatedValue;
                        break;
                    // Block and parry
                    case ItemStat.block_armor:
                        itemData.m_shared.m_blockPower = updatedValue;
                        break;
                    case ItemStat.block_armor_per_level:
                        itemData.m_shared.m_blockPowerPerLevel = updatedValue;
                        break;
                    case ItemStat.parry:
                        itemData.m_shared.m_timedBlockBonus = updatedValue;
                        break;
                    case ItemStat.block_force:
                        itemData.m_shared.m_deflectionForce = updatedValue;
                        break;
                    case ItemStat.block_force_per_level:
                        itemData.m_shared.m_deflectionForcePerLevel = updatedValue;
                        break;
                    // Costs for attack types
                    case ItemStat.primary_attack_stamina:
                        itemData.m_shared.m_attack.m_attackStamina = updatedValue;
                        break;
                    case ItemStat.primary_attack_eitr:
                        itemData.m_shared.m_attack.m_attackEitr = updatedValue;
                        break;
                    case ItemStat.primary_attack_flat_health_cost:
                        itemData.m_shared.m_attack.m_attackHealth = updatedValue;
                        break;
                    case ItemStat.primary_attack_percent_health_cost:
                        itemData.m_shared.m_attack.m_attackHealthPercentage = updatedValue;
                        break;
                    case ItemStat.secondary_attack_stamina:
                        itemData.m_shared.m_secondaryAttack.m_attackStamina = updatedValue;
                        break;
                    case ItemStat.secondary_attack_eitr:
                        itemData.m_shared.m_secondaryAttack.m_attackEitr = updatedValue;
                        break;
                    case ItemStat.secondary_attack_flat_health_cost:
                        itemData.m_shared.m_secondaryAttack.m_attackHealth = updatedValue;
                        break;
                    case ItemStat.secondary_attack_percent_health_cost:
                        itemData.m_shared.m_secondaryAttack.m_attackHealthPercentage = updatedValue;
                        break;
                    // Speed Modifiers
                    case ItemStat.movement_speed:
                        itemData.m_shared.m_movementModifier = updatedValue;
                        break;
                    case ItemStat.bow_draw_speed:
                        itemData.m_shared.m_attack.m_drawDurationMin = updatedValue;
                        break;
                    case ItemStat.crossbow_reload_speed:
                        itemData.m_shared.m_attack.m_reloadTime = updatedValue;
                        break;
                    case ItemStat.crossbow_reload_stamina_drain:
                        itemData.m_shared.m_attack.m_reloadStaminaDrain = updatedValue;
                        break;
                    case ItemStat.draw_stamina_drain:
                        itemData.m_shared.m_attack.m_drawStaminaDrain = updatedValue;  
                        break;
                    case ItemStat.projectile_velocity:
                        itemData.m_shared.m_attack.m_projectileVel = updatedValue;
                        break;
                    // Item Modifiers
                    case ItemStat.durability:
                        itemData.m_shared.m_maxDurability = updatedValue;
                        break;
                    case ItemStat.durability_per_level:
                        itemData.m_shared.m_durabilityPerLevel = updatedValue;
                        break;
                    case ItemStat.max_item_level:
                        itemData.m_shared.m_maxQuality = (int)updatedValue;
                        break;
                    case ItemStat.amount:
                        // we don't modify the amount as an item attribute, its for recipes.
                        break;
                    case ItemStat.tool_level:
                        itemData.m_shared.m_toolTier = (int)updatedValue;
                        break;
                    default:
                        break;
                }
            }

            private bool RecipeConfigUpdater(String rawrecipe, bool startup = false)
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
                        if (recipe_segments.Length != 3)
                        {
                            // Logger.LogWarning($"{recipe_entry} is invalid, it does not have enough segments. Proper format is: PREFABNAME,CRAFT_COST,UPGRADE_COST eg: Wood,8,1");
                            return false;
                        }
                        // Add a sanity check to ensure the prefab we are trying to use exists
                        if (startup == false)
                        {
                            if (PrefabManager.Instance.GetPrefab(recipe_segments[0]) == null)
                            {
                                // Logger.LogWarning($"{recipe_segments[0]} is an invalid prefab and does not exist.");
                                return false;
                            }
                        }
                        if (recipe_segments[0].Length == 0 || recipe_segments[1].Length == 0 || recipe_segments[2].Length == 0)
                        {
                            Logger.LogWarning($"{recipe_entry} is invalid, one segment does not have enough data. Proper format is: PREFABNAME,CRAFT_COST,UPGRADE_COST eg: Wood,8,1");
                            return false;
                        }

                        // Logger.LogDebug($"prefab: {recipe_segments[0]} c:{recipe_segments[1]} u:{recipe_segments[2]}");
                        updated_recipe.Add(recipe_segments[0], new Tuple<int, int>(Int32.Parse(recipe_segments[1]), Int32.Parse((recipe_segments[2]))));
                    }
                    //Logger.LogInfo("Done parsing recipe");
                    UpdatedRecipeData.Clear();
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
                        // Logger.LogDebug($"Updated recipe:{recipe_string}");
                    }
                    return true;
                }
                else
                {
                    // Logger.LogWarning($"Invalid recipe: {rawrecipe}. defaults will be used. Check your prefab names.");
                    UpdatedRecipeData = RecipeData;
                    
                }
                return false;
            }
        }




    }
}
