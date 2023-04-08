
using Logger = Jotunn.Logger;
using BepInEx.Configuration;
using System;

namespace ValheimArmory
{
    class VAConfig
    {
        public ConfigFile file;
        public ConfigEntry<bool> EnableDebugMode;
        public VAConfig(ConfigFile Config)
        {
            // ensure all the config values are created
            CreateConfigValues(Config);
            file = Config;
        }

        // Create Configuration and load it.
        private void CreateConfigValues(ConfigFile Config)
        {
            Config.SaveOnConfigSet = true;

            // Debugmode
            EnableDebugMode = Config.Bind("Client config", "EnableDebugMode", false,
                new ConfigDescription("Enables Debug logging for Valheim Armory.",
                null,
                new ConfigurationManagerAttributes { IsAdvanced = true }));
        }
    }
}
