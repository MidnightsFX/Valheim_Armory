using BepInEx.Configuration;
using ValheimArmory.common;

namespace ValheimArmory
{
    class VAConfig
    {
        public static ConfigFile cfg;
        public static ConfigEntry<bool> EnableDebugMode;
        public static ConfigEntry<float> HybridWeaponBloodMagicSkillIncrease;
        public static ConfigEntry<bool> VanillaHammersHavePrimaryAttack;
        public static ConfigEntry<float> StagbreakerPrimaryAttackStamina;
        public static ConfigEntry<float> IronSledgePrimaryAttackStamina;
        public static ConfigEntry<float> DemolisherPrimaryAttackStamina;
        public VAConfig(ConfigFile Config)
        {
            // ensure all the config values are created
            cfg = Config;
            cfg.SaveOnConfigSet = true;
            CreateConfigValues(Config);
            
        }

        // Create Configuration and load it.
        private void CreateConfigValues(ConfigFile Config)
        {
            // Debugmode
            EnableDebugMode = Config.Bind("Client config", "EnableDebugMode", false,
                new ConfigDescription("Enables Debug logging for Valheim Armory.",
                null,
                new ConfigurationManagerAttributes { IsAdvanced = true }));
            HybridWeaponBloodMagicSkillIncrease = BindServerConfig("Blood Magic Hybrid Weapons", "HybridWeaponBloodMagicSkillIncrease", 1f, "How much experiance should one usage of a blood magic hybrid weapon provide?", true, 0f, 4f);
            VanillaHammersHavePrimaryAttack = BindServerConfig("Vanilla Weapons", "VanillaHammersHavePrimaryAttack", true, "Enables a primary swing for vanilla sledges. Moves the slam to a secondary attack.");
            StagbreakerPrimaryAttackStamina = BindServerConfig("Vanilla Weapons", "StagbreakerPrimaryAttackStamina", 6f, "Stamina cost of the basic attack when enabled for the stagbreaker.", true, 1, 30);
            StagbreakerPrimaryAttackStamina.SettingChanged += WeaponModifier.OnConfigStagbreakerValueChanged;
            IronSledgePrimaryAttackStamina = BindServerConfig("Vanilla Weapons", "IronSledgePrimaryAttackStamina", 10f, "Stamina cost of the basic attack when enabled for the iron sledge.", true, 1, 30);
            IronSledgePrimaryAttackStamina.SettingChanged += WeaponModifier.OnConfigIronSledgeValueChanged;
            DemolisherPrimaryAttackStamina = BindServerConfig("Vanilla Weapons", "DemolisherPrimaryAttackStamina", 14f, "Stamina cost of the basic attack when enabled for the demolisher.", true, 1, 30);
            DemolisherPrimaryAttackStamina.SettingChanged += WeaponModifier.OnConfigDemolisherValueChanged;
        }

        /// <summary>
        ///  Helper to bind configs for bool types
        /// </summary>
        /// <param name="config_file"></param>
        /// <param name="catagory"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="description"></param>
        /// <param name="advanced"></param>
        /// <returns></returns>
        public static ConfigEntry<bool> BindServerConfig(string catagory, string key, bool value, string description, bool advanced = false)
        {
            return cfg.Bind(catagory, key, value,
                new ConfigDescription(description,
                null,
                new ConfigurationManagerAttributes { IsAdminOnly = true, IsAdvanced = advanced })
                );
        }

        /// <summary>
        /// Helper to bind configs for int types
        /// </summary>
        /// <param name="config_file"></param>
        /// <param name="catagory"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="description"></param>
        /// <param name="advanced"></param>
        /// <param name="valmin"></param>
        /// <param name="valmax"></param>
        /// <returns></returns>
        public static ConfigEntry<int> BindServerConfig(string catagory, string key, int value, string description, bool advanced = false, int valmin = 0, int valmax = 150)
        {
            return cfg.Bind(catagory, key, value,
                new ConfigDescription(description,
                new AcceptableValueRange<int>(valmin, valmax),
                new ConfigurationManagerAttributes { IsAdminOnly = true, IsAdvanced = advanced })
                );
        }

        /// <summary>
        /// Helper to bind configs for float types
        /// </summary>
        /// <param name="config_file"></param>
        /// <param name="catagory"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="description"></param>
        /// <param name="advanced"></param>
        /// <param name="valmin"></param>
        /// <param name="valmax"></param>
        /// <returns></returns>
        public static ConfigEntry<float> BindServerConfig(string catagory, string key, float value, string description, bool advanced = false, float valmin = 0, float valmax = 150)
        {
            return cfg.Bind(catagory, key, value,
                new ConfigDescription(description,
                new AcceptableValueRange<float>(valmin, valmax),
                new ConfigurationManagerAttributes { IsAdminOnly = true, IsAdvanced = advanced })
                );
        }
        /// <summary>
        /// Helper to bind configs for strings
        /// </summary>
        /// <param name="config_file"></param>
        /// <param name="catagory"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="description"></param>
        /// <param name="advanced"></param>
        /// <returns></returns>
        public static ConfigEntry<string> BindServerConfig(string catagory, string key, string value, string description, bool advanced = false)
        {
            return cfg.Bind(catagory, key, value,
                new ConfigDescription(description, null,
                new ConfigurationManagerAttributes { IsAdminOnly = true, IsAdvanced = advanced })
                );
        }
    }
}
