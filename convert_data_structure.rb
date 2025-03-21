target =  '
new JotunnItem(
                new Dictionary<ItemMetadata, string>() {
                    { ItemMetadata.name, "Goblin king knuckles" },
                    { ItemMetadata.catagory, "Fists" },
                    { ItemMetadata.prefab, "VAFist_Yagluth" },
                    { ItemMetadata.sprite, "yagluth_fists" },
                    { ItemMetadata.craftedAt, "forge" }
                },
                new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {
                    { ItemStat.amount, new Tuple<float, float, float, bool>(1, 1, 1, false) },
                    { ItemStat.block_armor, new Tuple<float, float, float, bool>(5, 0, 48, true) },
                    { ItemStat.slash, new Tuple<float, float, float, bool>(80, 0, 120, true) },
                    { ItemStat.slash_per_level, new Tuple<float, float, float, bool>(4, 0, 50, true) },
                    { ItemStat.blunt, new Tuple<float, float, float, bool>(0, 0, 120, true) },
                    { ItemStat.blunt_per_level, new Tuple<float, float, float, bool>(0, 0, 50, true) },
                    { ItemStat.fire, new Tuple<float, float, float, bool>(25, 0, 120, true) },
                    { ItemStat.fire_per_level, new Tuple<float, float, float, bool>(5, 0, 50, true) },
                    { ItemStat.attack_force, new Tuple<float, float, float, bool>(20, 0, 150, true) },
                    { ItemStat.primary_attack_stamina, new Tuple<float, float, float, bool>(12, 1, 50, true) },
                    { ItemStat.secondary_attack_stamina, new Tuple<float, float, float, bool>(36, 1, 50, true) },
                    { ItemStat.durability, new Tuple<float, float, float, bool>(300, 0, 600, true) },
                    { ItemStat.durability_per_level, new Tuple<float, float, float, bool>(50, 0, 150, true) },
                },
                new Dictionary<string, Tuple<int, int>>()
                {
                    { "BlackMetal", new Tuple<int, int>(4, 2) },
                    { "Iron", new Tuple<int, int>(6, 3) },
                    { "YagluthDrop", new Tuple<int, int>(2, 0) },
                    { "TrophyGoblinKing", new Tuple<int, int>(1, 0) },
                    { "Tar", new Tuple<int, int>(0, 3) },
                    { "LinenThread", new Tuple<int, int>(0, 2) }
                },
                new Dictionary<ItemSettings, int>
                {
                    { ItemSettings.stationRequiredLevel, 4 }
                }
            );
'

output = []
obj_name = ""
target.split("\n").each do |line|
    line = line.strip
    next if ["new Dictionary<ItemMetadata, string>() {", "new JotunnItem("].include?(line)

    if line.include?("ItemStat") && line != "new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {"
        next if line.include?("ItemStat.amount")
        statline = line.split(",")
        stat_type = statline[0].gsub("{","").strip
        stats = line.split("(")[1].split(")")[0].split(",")
        output << "                { #{stat_type}, new ItemStatConfig{ default_value = #{stats[0]}, min = #{stats[1]}, max = #{stats[2]} } },"
        next
    end

    if line.include?("new Tuple<int, int>")
        prefab = line.split("\"")[1]
        res = line.split("(")[1].split(")")[0].split(",")
        output << "                    new RecipeIngredient { prefab = \"#{prefab}\", amount = #{res[0].strip}, upgradeCost = #{res[1].strip} },"
        next
    end

    if line.include?("new Dictionary<ItemSettings, int>")
        output << "                }"
        output << "};"
        output << "Loader.AddDefinition(#{obj_name});"
        break
    end

    if line.include?("new Dictionary<string, Tuple<int, int>>()")
        output << "            };"
        output << "#{obj_name}.recipe = new RecipeDefinition {"
        output << "recipeItems = new List<RecipeIngredient> {"
        next
    end

    if line.include?("ItemMetadata.name")
        name = line.split("\"")[1]
        obj_name = name.gsub(" ","_")
        output << "ItemDefinition #{obj_name} = new ItemDefinition();"
        output << "#{obj_name}.Name = \"#{name}\";"
        next
    end
    if line.include?("ItemMetadata.catagory")
        category = line.split("\"")[1]
        output << "#{obj_name}.Category = ItemCategory.#{category};"
        next
    end
    if line.include?("ItemMetadata.prefab")
        prefab = line.split("\"")[1]
        output << "#{obj_name}.prefab = \"#{prefab}\";"
        next
    end
    if line.include?("ItemMetadata.sprite")
        icon = line.split("\"")[1]
        output << "#{obj_name}.icon = \"#{icon}\";"
        next
    end
    if line.include?("ItemMetadata.craftedAt")
        crafting = line.split("\"")[1]
        output << "#{obj_name}.craftedAt = \"#{crafting}\";"
        output << "#{obj_name}.craftAmount = 20;"
        
        target.split("/n").each do |lline|
            if line.include?("ItemSettings.stationRequiredLevel")
                level = lline.split(",")[1]
                output << "#{obj_name}.reqStationlevel = #{level.strip};"
                break
            end
        end
    end
    if line == "new Dictionary<ItemStat, Tuple<float, float, float, bool>>() {"
        output << "#{obj_name}.modifableStats = new Dictionary<ItemStat, ItemStatConfig> {"
        next
    end
end

output.each do |line|
    puts line
end