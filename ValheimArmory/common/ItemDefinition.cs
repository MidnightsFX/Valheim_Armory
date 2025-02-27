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
        Spears,
        Daggers,
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
        public string Description { get; set; }
        public string prefab { get; set; }
        public string craftedAt { get; set; }
        
        // configurable
        public bool enabled { get; set; } = true;
        public bool craftable { get; set; } = true;
        public int reqStationlevel { get; set; }
        public List<ItemStatConfig> modifableStats { get; set; }
        public List<RecipeIngredient> recipe { get; set; }
        public List<RecipeIngredient> updatedRecipe { get; set; }
        public string recipeConfig { get; set; }
    }

    class ItemStatConfig {
        public bool configurable { get; set; }
        public ItemStat stat { get; set; }
        public float value { get; set; }
        public float min { get; set; } = 0f;
        public float max { get; set; } = 400f;
    }

    class RecipeIngredient {
        public string prefab { get; set; }
        public int amount { get; set; }
        public int upgradeCost { get; set; }
    }
}
