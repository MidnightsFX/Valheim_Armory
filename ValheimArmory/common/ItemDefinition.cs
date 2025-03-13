using Jotunn.Configs;
using System.Collections.Generic;

namespace ValheimArmory.common
{
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
        public bool enabled { get; set; } = true;
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
        public HitData.DamageModifier damageModifier { get; set; }
        public BepInEx.Configuration.ConfigEntry<string> dmgModcfg { get; set; }
    }

    class ItemStatConfig {
        public bool configurable { get; set; } = true;
        public float default_value { get; set; }
        public BepInEx.Configuration.ConfigEntry<float> cfg { get; set; }
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
