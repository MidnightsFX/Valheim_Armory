using Jotunn.Configs;
using System;
using System.Collections.Generic;

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
        primary_attack_health_returned,
        primary_attack_damage_bonus_per_missing_hp,
        primary_attack_projectile_count,
        primary_attack_force_multiply,
        secondary_attack_stamina,
        secondary_attack_eitr,
        secondary_attack_force_multiply,
        secondary_attack_flat_health_cost,
        secondary_attack_percent_health_cost,
        movement_speed,
        bow_draw_speed,
        crossbow_reload_speed,
        crossbow_reload_stamina_drain,
        draw_stamina_drain,
        projectile_velocity,
        projectile_accuracy_max,
        durability,
        durability_per_level,
        max_item_level,
        amount,
        tool_level
    }

    enum ItemCategory
    {
        Arrows,
        Atgeirs,
        Axes,
        Hammers,
        Shields,
        Swords,
        Bows,
        Spears,
        Knives,
        Maces,
        Fists,
        Pickaxes,
        Magics
    }
    class ItemDefinition
    {
        // Metadata
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public ItemCategory Category { get; set; }
        public string prefab { get; set; }
        public string icon { get; set; }

        // configurable
        public string craftedAt { get; set; }
        public BepInEx.Configuration.ConfigEntry<string> craftedAt_cfg { get; set; }
        public bool craftable { get; set; } = true;
        public BepInEx.Configuration.ConfigEntry<bool> craftable_cfg { get; set; }
        public int reqStationlevel { get; set; }
        public BepInEx.Configuration.ConfigEntry<int> stationlvl_cfg { get; set; }
        public int craftAmount { get; set; }
        public BepInEx.Configuration.ConfigEntry<int> craftAmount_cfg { get; set; }
        public Dictionary<ItemStat, ItemStatConfig> modifableStats { get; set; }
        public Dictionary<HitData.DamageType, HitCustomDamageMod> damageMods { get; set; }

        public RecipeDefinition recipe { get; set; }
    }

    class HitCustomDamageMod
    {
        public bool configurable { get; set; } = true;
        public HitData.DamageModifier damageModifier { get; set; }
        public BepInEx.Configuration.ConfigEntry<string> dmgModcfg { get; set; }
    }

    class ItemStatConfig {
        public bool configurable { get; set; } = true;
        public bool isInt { get; set; } = false;
        public float default_value { get; set; }
        public BepInEx.Configuration.ConfigEntry<float> cfg { get; set; }
        public BepInEx.Configuration.ConfigEntry<int> cfgInt { get; set; }
        public float min { get; set; } = 0f;
        public float max { get; set; } = 400f;
    }

    class RecipeDefinition
    {
        public BepInEx.Configuration.ConfigEntry<string> recipeConfig { get; set; }
        public List<RecipeIngredient> recipeItems { get; set; }
        public List<RequirementConfig> recipeReqs { get; set; }
        public Recipe resolvedRecipe { get; set; }
    }

    class RecipeIngredient {
        public string prefab { get; set; }
        public int amount { get; set; }
        public int upgradeCost { get; set; } = 0;
    }
}
