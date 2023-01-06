
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

        public ConfigEntry<bool> EnableDebugMode;


        // misc - unimplented
        // public ConfigEntry<bool> EnabledThunderHammerConfig;
        
        

        // Create Configuration and load it.
        private void CreateConfigValues(ConfigFile Config)
        {
            Logger.LogInfo("Config Values bound.");
            Config.SaveOnConfigSet = true;
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

            // Debugmode
            CreateDebugConfig(Config);

        }

        // Configuration values for GreenMetalArrows
        private void CreateGreenMetalArrowConfig(ConfigFile Config)
        {
            GreenMetalArrowConfigEnabled = Config.Bind("Server config", "EnableGreenMetalArrow", true,
                new ConfigDescription("Enable the GreenMetal Arrow (ALL configs require mod-reload to take effect).", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));
            GreenMetalArrowBluntDamage = Config.Bind("Server config", "GreenMetalArrowBluntDamage", 15,
                new ConfigDescription("Blunt Damage value, whole number.", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));
            GreenMetalArrowPierceDamage = Config.Bind("Server config", "GreenMetalArrowPierceDamage", 70,
                new ConfigDescription("Pierce Damage value, whole number.", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));
        }

        // Configuration values for SurtlingFireArrows
        private void CreateSurtlingFireArrowConfig(ConfigFile Config)
        {
            SurtlingFireArrowConfigEnabled = Config.Bind("Server config", "EnableSurtlingFireArrow", true,
                new ConfigDescription("Enable the Surtling Fire Arrow (ALL configs require mod-reload to take effect).", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));
            SurtlingFireArrowFireDamage = Config.Bind("Server config", "SurtlingFireArrowFireDamage", 45,
                new ConfigDescription("Fire Damage value, whole number.", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));
            SurtlingFireArrowPierceDamage = Config.Bind("Server config", "SurtlingFireArrowPierceDamage", 35,
                new ConfigDescription("Pierce Damage value, whole number.", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));
        }

        // Configuration values for BoneArrows
        private void CreateBoneArrowConfig(ConfigFile Config)
        {
            BoneArrowConfigEnabled = Config.Bind("Server config", "EnableBoneArrow", true,
                new ConfigDescription("Enable the Bone Arrow (ALL configs require mod-reload to take effect).", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));
            BoneArrowPierceDamage = Config.Bind("Server config", "BoneArrowPierceDamage", 28,
                new ConfigDescription("Pierce Damage value, whole number.", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));
        }

        // Configuration values for AncientWoodArrow
        private void CreateAncientWoodArrowConfig(ConfigFile Config)
        {
            AncientWoodArrowConfigEnabled = Config.Bind("Server config", "EnableAncientWoodArrow", true,
                new ConfigDescription("Enable the Ancient Wood Arrow (ALL configs require mod-reload to take effect).", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));
            AncientWoodArrowPierceDamage = Config.Bind("Server config", "AncientWoodArrowPierceDamage", 48,
                new ConfigDescription("Pierce Damage value, whole number.", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));
        }

        // Configuration values for ChitinArrow
        private void CreateChitinArrowConfig(ConfigFile Config)
        {
            ChitinArrowConfigEnabled = Config.Bind("Server config", "ChitinArrowConfigEnabled", true,
                new ConfigDescription("Enable the Chitin Arrow (ALL configs require mod-reload to take effect).", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));
            ChitinArrowPierceDamage = Config.Bind("Server config", "ChitinArrowPierceDamage", 32,
                new ConfigDescription("Pierce Damage value, whole number.", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));
            ChitinArrowSlashDamage = Config.Bind("Server config", "ChitinArrowSlashDamage", 22,
                new ConfigDescription("Slash Damage value, whole number.", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));
        }

        // Configuration values for WoodBolt
        private void CreateWoodBoltConfig(ConfigFile Config)
        {
            WoodBoltConfigEnabled = Config.Bind("Server config", "EnableWoodBolt", true,
                new ConfigDescription("Enable the Wood bolt (ALL configs require mod-reload to take effect).", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));
            WoodBoltPierceDamage = Config.Bind("Server config", "WoodBoltPierceDamage", 28,
                new ConfigDescription("Pierce Damage value, whole number.", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));
        }

        // Configuration values for Bronze Crossbow
        private void CreateBronzeCrossbowConfig(ConfigFile Config)
        {
            BronzeCrossbowConfigEnabled = Config.Bind("Server config", "EnableBronzeCrossbow", true,
                new ConfigDescription("Enable the Bronze Crossbow (ALL configs require mod-reload to take effect).", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));
            BronzeCrossbowPierceDamage = Config.Bind("Server config", "BronzeCrossbowPierceDamage", 100,
                new ConfigDescription("Pierce Damage value, whole number.", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));
        }

        // Configuration values for SerpentBuckler
        private void CreateSerpentBucklerConfig(ConfigFile Config)
        {
            SerpentBucklerConfigEnabled = Config.Bind("Server config", "EnableSerpentBuckler", true,
                new ConfigDescription("Enable the Serpent Scale Buckler Shield (ALL configs require mod-reload to take effect).", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));
            SerpentBucklerBlockPowerBase = Config.Bind("Server config", "SerpentBucklerBlockPowerBase", 48,
                new ConfigDescription("Shield blocking value, base value can be increased by tempering (6 per level)", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));
        }

        // Configuration values for AbyssalSword
        private void CreateAbyssalSwordConfig(ConfigFile Config)
        {
            AbyssalSwordConfigEnabled = Config.Bind("Server config", "EnableAbyssalSword", true,
                new ConfigDescription("Enable the Abyssal Sword (chitin sword) (ALL configs require mod-reload to take effect).", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));
            AbyssalSwordBluntDamage = Config.Bind("Server config", "AbyssalSwordBluntDamage", 25,
                new ConfigDescription("Blunt Damage value, whole number.", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));
            AbyssalSwordSlashDamage = Config.Bind("Server config", "AbyssalSwordSlashDamage", 35,
                new ConfigDescription("Slash Damage value, whole number.", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));
        }

        // Configuration values for RoyalAbyssalAtgeir
        private void CreateRoyalAbyssalAtgeirConfig(ConfigFile Config)
        {
            RoyalAbyssalAtgeirConfigEnabled = Config.Bind("Server config", "EnableRoyalAbyssalAtgeir", true,
                new ConfigDescription("Enable the Royal Abyssal Atgeir (chitin atgeir) (ALL configs require mod-reload to take effect).", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));
            RoyalAbyssalAtgeirPierceDamage = Config.Bind("Server config", "RoyalAbyssalAtgeirPierceDamage", 65,
                new ConfigDescription("Pierce Damage value, whole number.", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));
            RoyalAbyssalAtgeirSlashDamage = Config.Bind("Server config", "RoyalAbyssalAtgeirSlashDamage", 35,
                new ConfigDescription("Slash Damage value, whole number.", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));
            RoyalAbyssalAtgeirSpiritDamage = Config.Bind("Server config", "RoyalAbyssalAtgeirSpiritDamage", 25,
                new ConfigDescription("Spirit Damage value, whole number.", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));
        }

        private void CreateDebugConfig(ConfigFile Config)
        {
            EnableDebugMode = Config.Bind("Client config", "EnableDebugMode", false,
                new ConfigDescription("Enables Debug logging for Valhiem Additions.", null));
        }
    }
}
