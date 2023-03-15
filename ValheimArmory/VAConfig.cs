
using Logger = Jotunn.Logger;
using BepInEx.Configuration;
using System;

namespace ValheimArmory
{
    class VAConfig
    {
        public VAConfig(ConfigFile Config)
        {
            // ensure all the config values are created
            CreateConfigValues(Config);
            file = Config;
        }

        public ConfigFile file;
        public ConfigEntry<bool> EnableDebugMode;

        // Create Configuration and load it.
        private void CreateConfigValues(ConfigFile Config)
        {
            Logger.LogInfo("Config Values bound.");
            Config.SaveOnConfigSet = true;

            // Debugmode
            CreateDebugConfig(Config);
            // CreateCompatabilityMode(Config);

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
