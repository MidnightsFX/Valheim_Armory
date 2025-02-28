using HarmonyLib;
using Jotunn.Configs;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ValheimArmory.common
{
    static class JotunBatchLoader
    {
        internal static List<ItemDefinition> resourceDefinitions = new List<ItemDefinition>();
        public static AssetBundle Assets;

        public static bool BatchSetup(bool reverse_order = true) {
            // Since configs are ordered by when they are connected this allows us to add things in the order they are defined.
            if (reverse_order){
                resourceDefinitions.Reverse();
            }
            WireConfigDefs();
            VAConfig.SaveOnSet(true);


            return true;
        }

        public static bool AddDefinitions(ItemDefinition itemdef) {
            //if (resourceDefinitions.Contains(itemdef)) {
            //    return true;
            //}
            resourceDefinitions.Add(itemdef);
            return true;
        }

        public static bool WireConfigDefs() { 
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
                    stat.updatedValue = VAConfig.BindServerConfig($"{itemdef.Category} - {itemdef.Name}", $"{itemdef.DisplayName}-{stat.stat}", stat.value, $"Value for {stat.stat} on {itemdef.Name}", true, stat.min, stat.max).Value;
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

        public static bool BatchAddItems()
        {
            foreach (ItemDefinition itemdef in resourceDefinitions) {
                if (!itemdef.enabled) { continue; }
                // Add item to game
                GameObject ItemPrefab = Assets.LoadAsset<GameObject>($"Assets/Custom/Weapons/{itemdef.Category}/{itemdef.prefab}.prefab");
                Sprite ItemSprite = Assets.LoadAsset<Sprite>($"Assets/Custom/Icons/{itemdef.icon}.png");
                ItemDrop ItemD = ItemPrefab.GetComponent<ItemDrop>();
                foreach(var modstat in itemdef.modifableStats) {
                    if (modstat.updatedValue == modstat.value) { continue; }
                    ItemDataConfigModifier(modstat.stat, modstat.value, ItemD.m_itemData);
                }
                List<RequirementConfig> recipe = new List<RequirementConfig>();
                foreach (var ingredient in itemdef.updatedRecipe) {
                    recipe.Add(new RequirementConfig { Item = ingredient.prefab, Amount = ingredient.amount, AmountPerLevel = ingredient.upgradeCost });
                }
                ItemConfig itemcfg = new ItemConfig() {
                    Amount = itemdef.craftAmount,
                    CraftingStation = $"{itemdef.craftedAt}",
                    MinStationLevel = itemdef.reqStationlevel,
                    Enabled = itemdef.craftable,
                    Icons = new[] { ItemSprite },
                    Requirements = recipe.ToArray()
                };
            }
            return true;
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
                case ItemStat.tool_level:
                    itemData.m_shared.m_toolTier = (int)updatedValue;
                    break;
                default:
                    break;
            }
        }
    }
}
