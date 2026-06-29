using Jotunn.Configs;
using System;
using System.Collections.Generic;

namespace ValheimArmory.Common {
    enum ItemStat {
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

    enum ItemCategory {
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
    class ItemDefinition {
        // Metadata
        public string Name {
            get; set;
        }
        public string DisplayName {
            get; set;
        }
        public ItemCategory Category {
            get; set;
        }
        public string Prefab {
            get; set;
        }
        public string Icon {
            get; set;
        }

        // configurable
        public string CraftedAt {
            get; set;
        }
        public BepInEx.Configuration.ConfigEntry<string> CraftedAtCfg {
            get; set;
        }
        public bool Craftable { get; set; } = true;
        public BepInEx.Configuration.ConfigEntry<bool> CraftableCfg {
            get; set;
        }
        public int ReqStationlevel {
            get; set;
        }
        public BepInEx.Configuration.ConfigEntry<int> StationLVLCfg {
            get; set;
        }
        public int CraftAmount {
            get; set;
        }
        public BepInEx.Configuration.ConfigEntry<int> CraftAmountCfg {
            get; set;
        }
        public Dictionary<ItemStat, ItemStatConfig> ModifableStats {
            get; set;
        }
        public Dictionary<HitData.DamageType, HitCustomDamageMod> DamageMods {
            get; set;
        }

        public RecipeDefinition Recipe {
            get; set;
        }
    }

    class HitCustomDamageMod {
        public bool Configurable { get; set; } = true;
        public HitData.DamageModifier DamageModifier {
            get; set;
        }
        public BepInEx.Configuration.ConfigEntry<string> DmgModCfg {
            get; set;
        }
    }

    class ItemStatConfig {
        public bool Configurable { get; set; } = true;
        public bool IsInt { get; set; } = false;
        public float Default_value {
            get; set;
        }
        public BepInEx.Configuration.ConfigEntry<float> Cfg {
            get; set;
        }
        public BepInEx.Configuration.ConfigEntry<int> CfgInt {
            get; set;
        }
        public float Min { get; set; } = 0f;
        public float Max { get; set; } = 400f;
    }

    class RecipeDefinition {
        public BepInEx.Configuration.ConfigEntry<string> RecipeConfig {
            get; set;
        }
        public List<RecipeIngredient> RecipeItems {
            get; set;
        }
        public List<RequirementConfig> RecipeReqs {
            get; set;
        }
        public Recipe ResolvedRecipe {
            get; set;
        }
    }

    class RecipeIngredient {
        public string Prefab {
            get; set;
        }
        public int Amount {
            get; set;
        }
        public int UpgradeCost { get; set; } = 0;
    }
}
