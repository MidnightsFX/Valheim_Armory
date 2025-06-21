using BepInEx;
using BepInEx.Configuration;
using System.IO;
using ValheimArmory.common;

namespace ValheimArmory
{
    class VAConfig
    {
        public static ConfigFile cfg;
        public static ConfigEntry<bool> EnableDebugMode;
        public static ConfigEntry<float> HybridWeaponBloodMagicSkillIncrease;
        public static ConfigEntry<bool> VanillaHammersHavePrimaryAttack;
        public static ConfigEntry<bool> ModHammersHavePrimaryAttack;
        public static ConfigEntry<float> StagbreakerPrimaryAttackStamina;
        public static ConfigEntry<float> IronSledgePrimaryAttackStamina;
        public static ConfigEntry<float> DemolisherPrimaryAttackStamina;
        public static ConfigEntry<bool> VanillaAbyssalKnifeBluntDamageConvert;
        public static ConfigEntry<float> AbyssalKnifeBlunt;
        public static ConfigEntry<float> AbyssalKnifeBluntPerLevel;
        public static ConfigEntry<float> BloodHungerRegen;
        public static ConfigEntry<float> QueenHealthRegen;
        public static ConfigEntry<float> QueenEitrRegen;

        public static ConfigEntry<int> InMemoryModificationsPerTick;

        public VAConfig(ConfigFile Config)
        {
            // ensure all the config values are created
            cfg = Config;
            cfg.SaveOnConfigSet = false;
            CreateConfigValues(Config);
            Logger.toggleDebug(); // Read the debug logging and set that now that its created and bound
        }

        public static void SaveOnSet(bool enabled)
        {
            cfg.SaveOnConfigSet = enabled;
            cfg.Save();
        }

        // Create Configuration and load it.
        private void CreateConfigValues(ConfigFile Config)
        {
            // Debugmode
            EnableDebugMode = Config.Bind("Client config", "EnableDebugMode", false,
                new ConfigDescription("Enables Debug logging for Valheim Armory.",
                null,
                new ConfigurationManagerAttributes { IsAdvanced = true }));
            EnableDebugMode.SettingChanged += Logger.enableDebugLogging;
            HybridWeaponBloodMagicSkillIncrease = BindServerConfig("Blood Magic Hybrid Weapons", "HybridWeaponBloodMagicSkillIncrease", 1f, "How much experiance should one usage of a blood magic hybrid weapon provide?", true, 0f, 4f);
            VanillaHammersHavePrimaryAttack = BindServerConfig("Vanilla Weapons", "VanillaHammersHavePrimaryAttack", true, "Enables a primary swing for vanilla sledges. Moves the slam to a secondary attack.");
            ModHammersHavePrimaryAttack = BindServerConfig("Vanilla Weapons", "ModHammersHavePrimaryAttack", true, "Enables a primary swing for mod weapons, disabling makes mod added hammers like vanilla sledges.");
            StagbreakerPrimaryAttackStamina = BindServerConfig("Vanilla Weapons", "StagbreakerPrimaryAttackStamina", 6f, "Stamina cost of the basic attack when enabled for the stagbreaker.", true, 1, 30);
            StagbreakerPrimaryAttackStamina.SettingChanged += WeaponModifier.OnConfigStagbreakerValueChanged;
            IronSledgePrimaryAttackStamina = BindServerConfig("Vanilla Weapons", "IronSledgePrimaryAttackStamina", 10f, "Stamina cost of the basic attack when enabled for the iron sledge.", true, 1, 30);
            IronSledgePrimaryAttackStamina.SettingChanged += WeaponModifier.OnConfigIronSledgeValueChanged;
            DemolisherPrimaryAttackStamina = BindServerConfig("Vanilla Weapons", "DemolisherPrimaryAttackStamina", 14f, "Stamina cost of the basic attack when enabled for the demolisher.", true, 1, 30);
            DemolisherPrimaryAttackStamina.SettingChanged += WeaponModifier.OnConfigDemolisherValueChanged;
            VanillaAbyssalKnifeBluntDamageConvert = BindServerConfig("Vanilla Weapons", "VanillaAbyssalKnifeBluntDamageConvert", true, "Removes slash damage from the abyssal knife and adds blunt damage instead.");
            AbyssalKnifeBlunt = BindServerConfig("Vanilla Weapons", "AbyssalKnifeBlunt", 20f, "Blunt damage for the abyssal knife", true, 0, 40);
            AbyssalKnifeBluntPerLevel = BindServerConfig("Vanilla Weapons", "AbyssalKnifeBluntPerLevel", 1f, "Blunt damage per level for the abyssal knife", true, 0, 10);
            AbyssalKnifeBlunt.SettingChanged += WeaponModifier.OnConfigAbyssalKnifeValueChanged;
            AbyssalKnifeBluntPerLevel.SettingChanged += WeaponModifier.OnConfigAbyssalKnifeValueChanged;

            BloodHungerRegen = BindServerConfig("Status Effects", "BloodHungerRegen", 2f, "How strong the hp regen effect for blood weapons is (2 is 200% regen).", true, 0f, 5f);
            BloodHungerRegen.SettingChanged += StatusModifiers.OnConfigBloodChanged;
            QueenHealthRegen = BindServerConfig("Status Effects", "QueenHealthRegen", 1.3f, "How strong the hp regen effect for the queen is (1 is 100% additional regen).", true, 0f, 5f);
            QueenHealthRegen.SettingChanged += StatusModifiers.OnConfigQueenHealthRegenChanged;
            QueenEitrRegen = BindServerConfig("Status Effects", "QueenEitrRegen", 2.5f, "How strong the eitr regen effect for the queen is (2 is 200% additional regen).", true, 0f, 5f);
            QueenEitrRegen.SettingChanged += StatusModifiers.OnConfigQueenHealthRegenChanged;

            InMemoryModificationsPerTick = BindServerConfig("General", "InMemoryModificationsPerTick", 10, "How many modifications should be processed per tick.", true, 1, 100);
        }

        internal static void SetupMainFileWatcher() {
            // Setup a file watcher to detect changes to the config file
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Path = Path.GetDirectoryName(cfg.ConfigFilePath);
            // Ignore changes to other files
            watcher.Filter = "MidnightsFX.ValheimArmory.cfg";
            watcher.Changed += OnConfigFileChanged;
            watcher.SynchronizingObject = ThreadingHelper.SynchronizingObject;
            watcher.EnableRaisingEvents = true;
        }

        private static void OnConfigFileChanged(object sender, FileSystemEventArgs e) {
            // We only want the config changes being allowed if this is a server (ie in game in a hosted world or dedicated ideally)
            if (ZNet.instance.IsServer() == false) {
                return; 
            }
            // Handle the config file change event
            Logger.LogInfo("Configuration file has been changed, reloading settings.");
            cfg.Reload();
            // Optionally, you can call a method to handle specific changes
            // HandleConfigChanges();
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
        public static ConfigEntry<string> BindServerConfig(string catagory, string key, string value, string description, bool advanced = false, AcceptableValueList<string> allowed_values = null)
        {
            AcceptableValueList<string> allowed = allowed_values;
            return cfg.Bind(catagory, key, value,
                new ConfigDescription(description, allowed,
                new ConfigurationManagerAttributes { IsAdminOnly = true, IsAdvanced = advanced })
                );
        }
    }
}
