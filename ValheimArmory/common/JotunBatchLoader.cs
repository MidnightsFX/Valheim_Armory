using HarmonyLib;
using System;
using System.Collections.Generic;

namespace ValheimArmory.common
{
    class JotunBatchLoader
    {
        List<ItemDefinition> resourceDefinitions = new List<ItemDefinition>();

        public bool BatchSetup(bool reverse_order = true) {
            // Since configs are ordered by when they are connected this allows us to add things in the order they are defined.
            if (reverse_order){
                resourceDefinitions.Reverse();
            }
            WireConfigDefs();
            VAConfig.SaveOnSet(true);


            return true;
        }

        public bool AddDefinitions(ItemDefinition itemdef) {
            //if (resourceDefinitions.Contains(itemdef)) {
            //    return true;
            //}
            resourceDefinitions.Add(itemdef);
            return true;
        }

        public bool WireConfigDefs() { 
            // Ensure save on set is false, we will save at the end of this process.
            foreach (ItemDefinition itemdef in resourceDefinitions) {
                itemdef.DisplayName = string.Join("", itemdef.Name.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
                itemdef.enabled = VAConfig.BindServerConfig($"{itemdef.Category} - {itemdef.Name}", $"{itemdef.DisplayName}-enabled", itemdef.enabled, $"Enable/Disable the {itemdef.Name}. Items set to Disabled will not be loaded.").Value;
                // Skip over all loading of items that are disabled.
                if (!itemdef.enabled) { continue; }
                itemdef.craftable = VAConfig.BindServerConfig($"{itemdef.Category} - {itemdef.Name}", $"{itemdef.DisplayName}-craftable", itemdef.craftable, $"Enable/Disable the crafting recipe for {itemdef.Name}.").Value;
                itemdef.reqStationlevel = VAConfig.BindServerConfig($"{itemdef.Category} - {itemdef.Name}", $"{itemdef.DisplayName}-stationRequiredLevel", itemdef.reqStationlevel, $"Sets the required minimum crafting station level to craft {itemdef.Name}", true, 1, 4).Value;
                
                foreach(ItemStatConfig stat in itemdef.modifableStats) {
                    if (!stat.configurable) { continue; }
                    stat.value = VAConfig.BindServerConfig($"{itemdef.Category} - {itemdef.Name}", $"{itemdef.DisplayName}-{stat.stat}", stat.value, $"Value for {stat.stat} on {itemdef.Name}", true, stat.min, stat.max).Value;
                }

                string[] recipe = new string[] { };
                foreach (RecipeIngredient ingredient in itemdef.recipe) {
                    recipe.AddItem($"{ingredient.prefab},{ingredient.amount},{ingredient.upgradeCost}");
                }
                itemdef.recipeConfig = VAConfig.BindServerConfig($"{itemdef.Category} - {itemdef.Name}", $"{itemdef.DisplayName}-recipe", String.Join("|", recipe), $"Recipe for {itemdef.Name}").Value;
                string[] recipeConfig = itemdef.recipeConfig.Split('|');
                itemdef.updatedRecipe.Clear();
                // Likely need some level of validation handling here or to modularize this
                foreach (string ingredient in recipeConfig) {
                    string[] ingredientConfig = ingredient.Split(',');
                    RecipeIngredient recipeIngredient = new RecipeIngredient();
                    recipeIngredient.prefab = ingredientConfig[0];
                    recipeIngredient.amount = int.Parse(ingredientConfig[1]);
                    recipeIngredient.upgradeCost = int.Parse(ingredientConfig[2]);
                    itemdef.updatedRecipe.AddItem(recipeIngredient);
                }
            }
            return true;
        }

        public bool BatchAddItems()
        {
            foreach (ItemDefinition itemdef in resourceDefinitions) {
                if (!itemdef.enabled) { continue; }
                // Add item to game
            }
            return true;
        }
    }
}
