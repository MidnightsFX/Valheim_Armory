
using Logger = Jotunn.Logger;
using BepInEx.Configuration;

namespace ValheimAdditions
{
    class ValheimAdditionsConfig
    {
        public ValheimAdditionsConfig(ConfigFile Config)
        {
            // ensure all the config values are created
            CreateConfigValues(Config);
        }

        // accessible server configs, values are all server sided to prevent schisms such as a client trying to set high dmg
        // Config for GreenMetalArrow
        public ConfigEntry<bool> GreenMetalArrowConfigEnabled;
        public ConfigEntry<int>  GreenMetalArrowBluntDamage;
        public ConfigEntry<int>  GreenMetalArrowPierceDamage;

        // Config for SurtlingFireArrow
        public ConfigEntry<bool> SurtlingFireArrowConfigEnabled;
        public ConfigEntry<int>  SurtlingFireArrowPierceDamage;
        public ConfigEntry<int>  SurtlingFireArrowFireDamage;

        // Config for BoneArrow
        public ConfigEntry<bool> BoneArrowConfigEnabled;
        public ConfigEntry<int>  BoneArrowPierceDamage;

        //Config for AncientWoodArrow
        public ConfigEntry<bool> AncientWoodArrowConfigEnabled;
        public ConfigEntry<int> AncientWoodArrowPierceDamage;

        //Config for ChitinArrow
        public ConfigEntry<bool> ChitinArrowConfigEnabled;
        public ConfigEntry<int> ChitinArrowSlashDamage;
        public ConfigEntry<int> ChitinArrowPierceDamage;

        // Config for WoodBolt
        public ConfigEntry<bool> WoodBoltConfigEnabled;
        public ConfigEntry<int> WoodBoltPierceDamage;

        // Config for Bronze Crossbow
        public ConfigEntry<bool> BronzeCrossbowConfigEnabled;
        public ConfigEntry<int> BronzeCrossbowPierceDamage;

        // Config for SerpentBuckler
        public ConfigEntry<bool> SerpentBucklerConfigEnabled;
        public ConfigEntry<int> SerpentBucklerBlockPowerBase;

        // Config for AbyssalSword
        public ConfigEntry<bool> AbyssalSwordConfigEnabled;
        public ConfigEntry<int> AbyssalSwordBluntDamage;
        public ConfigEntry<int> AbyssalSwordSlashDamage;

        // Config for RoyalAbyssalAtgeir
        public ConfigEntry<bool> RoyalAbyssalAtgeirConfigEnabled;
        public ConfigEntry<int> RoyalAbyssalAtgeirPierceDamage;
        public ConfigEntry<int> RoyalAbyssalAtgeirSlashDamage;
        public ConfigEntry<int> RoyalAbyssalAtgeirSpiritDamage;

        // Config for AntlerAtgeir
        public ConfigEntry<bool> AntlerAtgeirConfigEnabled;
        public ConfigEntry<int> AntlerAtgeirModel;
        public ConfigEntry<int> AntlerAtgeirPierceDamage;

        // Config for BlackmetalSledge
        public ConfigEntry<bool> BlackmetalSledgeConfigEnabled;
        public ConfigEntry<int> BlackmetalSledgeBluntDamage;
        public ConfigEntry<int> BlackmetalSledgeLightningDamage;

        // Config for Artisan Table Upgrades
        public ConfigEntry<bool> ArtisanTableUpgrade1ConfigEnabled;

        public ConfigEntry<bool> EnableDebugMode;


        // misc - unimplented
        // public ConfigEntry<bool> EnabledThunderHammerConfig;
        
        

        // Create Configuration and load it.
        private void CreateConfigValues(ConfigFile Config)
        {
            Logger.LogInfo("Config Values bound.");
            Config.SaveOnConfigSet = true;

            // TODO config file formatting and sectioning

            // Items
            CreateGreenMetalArrowConfig(Config);
            CreateSurtlingFireArrowConfig(Config);
            CreateBoneArrowConfig(Config);
            CreateAncientWoodArrowConfig(Config);
            CreateChitinArrowConfig(Config);
            CreateWoodBoltConfig(Config);
            CreateBronzeCrossbowConfig(Config);
            CreateSerpentBucklerConfig(Config);
            CreateAbyssalSwordConfig(Config);
            CreateRoyalAbyssalAtgeirConfig(Config);
            CreateAntlerAtgeirConfig(Config);
            CreateBlackmetalSledgeConfig(Config);

            // Pieces
            CreateArtisanTableConfig(Config);

            // Debugmode
            CreateDebugConfig(Config);

            if (EnableDebugMode.Value == true)
            {
                Logger.LogInfo("Config Entries are as follows:");
                ConfigEntryBase[] configs = Config.GetConfigEntries();
                    foreach (ConfigEntryBase entry in configs)
                {
                    Logger.LogInfo($"{entry.Definition} - {entry.BoxedValue}");
                }
                    
            }
        }

        // Helper to bind configs for bool types
        private ConfigEntry<bool> BindServerConfig(ConfigFile config_file, string catagory, string key, bool value, string description, bool advanced = false)
        {
            return config_file.Bind(catagory, key, value,
                new ConfigDescription(description,
                null,
                new ConfigurationManagerAttributes { IsAdminOnly = true, IsAdvanced = advanced })
                );
        }

        // Helper to bind configs for int types
        private ConfigEntry<int> BindServerConfig(ConfigFile config_file, string catagory, string key, int value, string description, bool advanced = false, int valmin = 0, int valmax = 90)
        {
            return config_file.Bind(catagory, key, value,
                new ConfigDescription(description,
                new AcceptableValueRange<int>(valmin, valmax),
                new ConfigurationManagerAttributes { IsAdminOnly = true, IsAdvanced = advanced })
                );
        }

        // Configuration values for GreenMetalArrows
        private void CreateGreenMetalArrowConfig(ConfigFile Config)
        {
            GreenMetalArrowConfigEnabled = BindServerConfig(Config, "Arrows - Green Metal Arrow", "EnableGreenMetalArrow", true, "Enable/Disable the GreenMetal Arrow.");
            GreenMetalArrowBluntDamage = BindServerConfig(Config, "Arrows - Green Metal Arrow", "GreenMetalArrowBluntDamage", 15, "Blunt Damage value.", true);
            GreenMetalArrowPierceDamage =  BindServerConfig(Config, "Arrows - Green Metal Arrow", "GreenMetalArrowPierceDamage", 70, "Blunt Damage value.", true, 0, 150);
        }

        // Configuration values for SurtlingFireArrows
        private void CreateSurtlingFireArrowConfig(ConfigFile Config)
        {
            SurtlingFireArrowConfigEnabled = BindServerConfig(Config, "Arrows - Surtling Fire Arrow", "EnableSurtlingFireArrow", true, "Enable the Surtling Fire Arrow.");
            SurtlingFireArrowFireDamage = BindServerConfig(Config, "Arrows - Surtling Fire Arrow", "SurtlingFireArrowFireDamage", 45, "Fire Damage value.", true);
            SurtlingFireArrowPierceDamage = BindServerConfig(Config, "Arrows - Surtling Fire Arrow", "SurtlingFireArrowPierceDamage", 45, "Pierce Damage value.", true);
        }

        // Configuration values for BoneArrows
        private void CreateBoneArrowConfig(ConfigFile Config)
        {
            BoneArrowConfigEnabled = BindServerConfig(Config, "Arrows - Bone Arrow", "EnableBoneArrow", true, "Enable the Bone Arrow.");
            BoneArrowPierceDamage = BindServerConfig(Config, "Arrows - Bone Arrow", "BoneArrowPierceDamage", 28, "Pierce Damage value.", true);
        }

        // Configuration values for AncientWoodArrow
        private void CreateAncientWoodArrowConfig(ConfigFile Config)
        {
            AncientWoodArrowConfigEnabled = BindServerConfig(Config, "Arrows - Ancient Wood Arrow", "EnableAncientWoodArrow", true, "Enable the Ancient Wood Arrow.");
            AncientWoodArrowPierceDamage = BindServerConfig(Config, "Arrows - Ancient Wood Arrow", "AncientWoodArrowPierceDamage", 48, "Pierce Damage value.", true);
        }

        // Configuration values for ChitinArrow
        private void CreateChitinArrowConfig(ConfigFile Config)
        {
            ChitinArrowConfigEnabled = BindServerConfig(Config, "Arrows - Chitin Arrow", "ChitinArrowConfigEnabled", true, "Enable the Chitin Arrow.");
            ChitinArrowPierceDamage = BindServerConfig(Config, "Arrows - Chitin Arrow", "ChitinArrowPierceDamage", 32, "Pierce Damage value.", true);
            ChitinArrowSlashDamage = BindServerConfig(Config, "Arrows - Chitin Arrow", "ChitinArrowSlashDamage", 22, "Slash Damage value.", true);
        }

        // Configuration values for WoodBolt
        private void CreateWoodBoltConfig(ConfigFile Config)
        {
            WoodBoltConfigEnabled = BindServerConfig(Config, "Arrows - Wood Bolt", "EnableWoodBolt", true, "Enable the Wood bolt.");
            WoodBoltPierceDamage = BindServerConfig(Config, "Arrows - Wood Bolt", "WoodBoltPierceDamage", 28, "Pierce Damage value.", true);
        }

        // Configuration values for Bronze Crossbow
        private void CreateBronzeCrossbowConfig(ConfigFile Config)
        {
            BronzeCrossbowConfigEnabled = BindServerConfig(Config, "Weapon - Bronze Crossbow", "EnableBronzeCrossbow", true, "Enable the Bronze Crossbow.");
            BronzeCrossbowPierceDamage = BindServerConfig(Config, "Weapon - Bronze Crossbow", "BronzeCrossbowPierceDamage", 100, "Pierce Damage value.", true, 0, 300);
        }

        // Configuration values for SerpentBuckler
        private void CreateSerpentBucklerConfig(ConfigFile Config)
        {
            SerpentBucklerConfigEnabled = BindServerConfig(Config, "Shield - Serpent Buckler", "EnableSerpentBuckler", true, "Enable the Serpent Scale Buckler Shield.");
            SerpentBucklerBlockPowerBase = BindServerConfig(Config, "Shield - Serpent Buckler", "SerpentBucklerBlockPowerBase", 48, "Base shield blocking value, base value can be increased by tempering (6 per level).", true);
        }

        // Configuration values for AbyssalSword
        private void CreateAbyssalSwordConfig(ConfigFile Config)
        {
            AbyssalSwordConfigEnabled = BindServerConfig(Config, "Weapon - Abyssal Sword", "EnableAbyssalSword", true, "Enable the Abyssal Sword (chitin sword).");
            AbyssalSwordBluntDamage = BindServerConfig(Config, "Weapon - Abyssal Sword", "AbyssalSwordBluntDamage", 25, "Blunt Damage value.", true);
            AbyssalSwordSlashDamage = BindServerConfig(Config, "Weapon - Abyssal Sword", "AbyssalSwordSlashDamage", 35, "Slash Damage value.", true);
        }

        // Configuration values for RoyalAbyssalAtgeir
        private void CreateRoyalAbyssalAtgeirConfig(ConfigFile Config)
        {
            RoyalAbyssalAtgeirConfigEnabled = BindServerConfig(Config, "Weapon - Royal Abyssal Atgeir", "EnableRoyalAbyssalAtgeir", true, "Enable the Royal Abyssal Atgeir (chitin atgeir).");
            RoyalAbyssalAtgeirPierceDamage = BindServerConfig(Config, "Weapon - Royal Abyssal Atgeir", "RoyalAbyssalAtgeirPierceDamage", 65, "Pierce Damage value.", true);
            RoyalAbyssalAtgeirSlashDamage = BindServerConfig(Config, "Weapon - Royal Abyssal Atgeir", "RoyalAbyssalAtgeirSlashDamage", 35, "Slash Damage value.", true);
            RoyalAbyssalAtgeirSpiritDamage = BindServerConfig(Config, "Weapon - Royal Abyssal Atgeir", "RoyalAbyssalAtgeirSpiritDamage", 25, "Spirit Damage value.", true);
        }

        // Configuration values for RoyalAbyssalAtgeir
        private void CreateAntlerAtgeirConfig(ConfigFile Config)
        {
            AntlerAtgeirConfigEnabled = BindServerConfig(Config, "Weapon - Antler Atgeir", "EnableAntlerAtgeir", true, "Enable the Antler Atgeir.");
            // TODO: defaulting and support for acceptable value range templating
            AntlerAtgeirModel = Config.Bind("Weapon - Antler Atgeir", "AntlerAtgeirModel", 1,
                new ConfigDescription("Model to use for the antler atgeir, valid values: 1 (standard), 2 (no attachment), 3 (lightning added).", new AcceptableValueRange<int>(1, 3),
                new ConfigurationManagerAttributes { IsAdminOnly = true, IsAdvanced = true }));
            AntlerAtgeirPierceDamage = BindServerConfig(Config, "Weapon - Antler Atgeir", "AntlerAtgeirSlashDamage", 25, "Slash Damage value.", true);
        }

        // Configuration values for BlackmetalSledge
        private void CreateBlackmetalSledgeConfig(ConfigFile Config)
        {
            BlackmetalSledgeConfigEnabled = BindServerConfig(Config, "Weapon - Blackmetal Sledge", "Enable BlackmetalSledge", true, "Enable the Blackmetal Sledge.");
            BlackmetalSledgeBluntDamage = BindServerConfig(Config, "Weapon - Blackmetal Sledge", "BlackmetalSledgeBluntDamage", 112, "Blunt Damage value.", true);
            BlackmetalSledgeLightningDamage = BindServerConfig(Config, "Weapon - Blackmetal Sledge", "BlackmetalSledgeLightningDamage", 45, "Lightning Damage value.", true);
        }

        // Configuration values for Artisan Table Upgrades
        private void CreateArtisanTableConfig(ConfigFile Config)
        {
            ArtisanTableUpgrade1ConfigEnabled = BindServerConfig(Config, "Pieces - Artisan Table", "EnableArtisanTableUpgrade1", true, "Enables the first level upgrade for the artisan table.");
        }

        private void CreateDebugConfig(ConfigFile Config)
        {
            // consider client config helper
            EnableDebugMode = Config.Bind("Client config", "EnableDebugMode", false,
                new ConfigDescription("Enables Debug logging for Valhiem Additions.", 
                null, 
                new ConfigurationManagerAttributes { IsAdvanced = true }));
        }
    }
}
