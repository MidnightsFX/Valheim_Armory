using BepInEx.Configuration;
using System;
using System.IO;
using ValheimArmory.common;
using ValheimArmory.Common;

namespace ValheimArmory
{
    class ValConfig
    {
        public static ConfigFile cfg;
        public static ConfigEntry<bool> EnableDebugMode;
        public static ConfigEntry<bool> LoadPrefabsOnServer;
        public static ConfigEntry<float> HybridWeaponBloodMagicSkillIncrease;
        public static ConfigEntry<bool> VanillaHammersHavePrimaryAttack;
        public static ConfigEntry<bool> ModHammersHavePrimaryAttack;
        public static ConfigEntry<float> StagbreakerPrimaryAttackStamina;
        public static ConfigEntry<float> IronSledgePrimaryAttackStamina;
        public static ConfigEntry<float> DemolisherPrimaryAttackStamina;
        public static ConfigEntry<float> GoldSledgePrimaryAttackStamina;
        public static ConfigEntry<string> SledgeStance;
        internal static readonly AcceptableValueList<string> allowedSledgeStances = new AcceptableValueList<string>(new string[] { "TwoHandedAxe", "Sledge" });
        public static ConfigEntry<bool> VanillaAbyssalKnifeBluntDamageConvert;
        public static ConfigEntry<bool> EnableVanillaSpear;
        public static ConfigEntry<bool> EnableVanillaFlintAxe;
        public static ConfigEntry<float> AbyssalKnifeBlunt;
        public static ConfigEntry<float> AbyssalKnifeBluntPerLevel;
        public static ConfigEntry<float> BloodHungerRegen;
        public static ConfigEntry<float> QueenHealthRegen;
        public static ConfigEntry<float> QueenEitrRegen;

        public static ConfigEntry<int> InMemoryModificationsPerTick;
        public static ConfigEntry<float> ConfigApplyDelay;
        public static ConfigEntry<float> ConfigPollIntervalSeconds;

        // How long a burst of setting changes has to go quiet before the config file is written.
        private const float SaveDelaySeconds = 1f;
        private static bool savePending = false;

        public ValConfig(ConfigFile Config)
        {
            // ensure all the config values are created
            cfg = Config;
            cfg.SaveOnConfigSet = false;
            CreateConfigValues(Config);
            Logger.toggleDebug(); // Read the debug logging and set that now that its created and bound
        }

        // Called once plugin setup has finished binding. SaveOnConfigSet stays off from then on.
        //
        // With it on, BepInEx rewrites the whole file (every item's entries, several hundred KB) synchronously
        // for each value that changes. A server config sync, or an admin closing Configuration Manager after
        // editing a few weapons, changes dozens of entries in one frame - that was dozens of full rewrites in
        // that frame, on the server and on every client. Changes now mark the file dirty and it is written
        // once, after they settle.
        internal static void EnableDeferredSave()
        {
            cfg.SaveOnConfigSet = false;
            cfg.SettingChanged += (_, _) => {
                savePending = true;
                ConfigChangeDebouncer.Schedule(cfg, SavePending, SaveDelaySeconds);
            };
        }

        // Writes the file if anything changed since the last write. The plugin also calls this on shutdown,
        // since a write still waiting on its delay would otherwise be lost when the game closes.
        internal static void SavePending()
        {
            if (savePending == false) { return; }
            savePending = false;
            try {
                Save();
            } catch (IOException e) {
                // Most likely another program has the file open. Leave it pending for the next change or shutdown.
                savePending = true;
                Logger.LogWarning($"Could not write the config file, will retry: {e.Message}");
            }
        }

        // Writes the file and re-stamps the watcher, so our own write is not taken for an external edit and
        // reloaded on the next poll.
        internal static void Save()
        {
            cfg.Save();
            ConfigFileWatcher.RefreshStamp(cfg.ConfigFilePath);
        }

        // Runs a SettingChanged handler through ConfigChangeDebouncer instead of on every change. These
        // handlers rewrite item data on every copy of a weapon, and the stock Configuration Manager slider
        // changes the value on each frame of a drag. Keyed on the handler (delegates to the same method
        // compare equal), so entries that share one - the two abyssal knife values, the two queen regen
        // values - settle into a single run.
        internal static void OnChangeDebounced<T>(ConfigEntry<T> entry, EventHandler handler)
        {
            entry.SettingChanged += (sender, args) => ConfigChangeDebouncer.Schedule(handler, () => handler(sender, args));
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

            // Deliberately not an admin (server synced) config: it is read during Awake, on the machine it
            // applies to, long before a server sync could arrive, and a client always loads its own prefabs.
            LoadPrefabsOnServer = Config.Bind("Server config", "LoadPrefabsOnServer", false,
                new ConfigDescription("Registers Valheim Armory's item prefabs on a dedicated server. Off by default since the server neither renders nor modifies them; enable it when another server side mod has to resolve Valheim Armory items (spawn/loot tables, admin spawn commands). Takes effect on server restart.",
                null,
                new ConfigurationManagerAttributes { IsAdvanced = true }));
            HybridWeaponBloodMagicSkillIncrease = BindServerConfig("Blood Magic Hybrid Weapons", "HybridWeaponBloodMagicSkillIncrease", 1f, "How much experiance should one usage of a blood magic hybrid weapon provide?", true, 0f, 4f);
            VanillaHammersHavePrimaryAttack = BindServerConfig("Vanilla Weapons", "VanillaHammersHavePrimaryAttack", true, "Enables a primary swing for vanilla sledges. Moves the slam to a secondary attack.");
            ModHammersHavePrimaryAttack = BindServerConfig("Vanilla Weapons", "ModHammersHavePrimaryAttack", true, "Enables a primary swing for mod weapons, disabling makes mod added hammers like vanilla sledges.");
            StagbreakerPrimaryAttackStamina = BindServerConfig("Vanilla Weapons", "StagbreakerPrimaryAttackStamina", 6f, "Stamina cost of the basic attack when enabled for the stagbreaker.", true, 1, 30);
            OnChangeDebounced(StagbreakerPrimaryAttackStamina, WeaponModifier.OnConfigStagbreakerValueChanged);
            IronSledgePrimaryAttackStamina = BindServerConfig("Vanilla Weapons", "IronSledgePrimaryAttackStamina", 10f, "Stamina cost of the basic attack when enabled for the iron sledge.", true, 1, 30);
            OnChangeDebounced(IronSledgePrimaryAttackStamina, WeaponModifier.OnConfigIronSledgeValueChanged);
            DemolisherPrimaryAttackStamina = BindServerConfig("Vanilla Weapons", "DemolisherPrimaryAttackStamina", 14f, "Stamina cost of the basic attack when enabled for the demolisher.", true, 1, 30);
            OnChangeDebounced(DemolisherPrimaryAttackStamina, WeaponModifier.OnConfigDemolisherValueChanged);
            GoldSledgePrimaryAttackStamina = BindServerConfig("Vanilla Weapons", "GoldSledgePrimaryAttackStamina", 14f, "Stamina cost of the basic attack when enabled for the bloodgold sledge, including its blood/lightning and frost/fire variants.", true, 1, 30);
            OnChangeDebounced(GoldSledgePrimaryAttackStamina, WeaponModifier.OnConfigGoldSledgeValueChanged);
            SledgeStance = BindServerConfig("Vanilla Weapons", "SledgeStance", "TwoHandedAxe", "How sledges are held while idle, for both the vanilla and the mod added ones. TwoHandedAxe holds them like a battleaxe, matching how they swing here. Sledge is the vanilla sledge stance.", false, allowedSledgeStances);
            OnChangeDebounced(SledgeStance, WeaponModifier.OnConfigSledgeStanceChanged);
            VanillaAbyssalKnifeBluntDamageConvert = BindServerConfig("Vanilla Weapons", "VanillaAbyssalKnifeBluntDamageConvert", true, "Removes slash damage from the abyssal knife and adds blunt damage instead.");
            AbyssalKnifeBlunt = BindServerConfig("Vanilla Weapons", "AbyssalKnifeBlunt", 20f, "Blunt damage for the abyssal knife", true, 0, 40);
            AbyssalKnifeBluntPerLevel = BindServerConfig("Vanilla Weapons", "AbyssalKnifeBluntPerLevel", 1f, "Blunt damage per level for the abyssal knife", true, 0, 10);
            OnChangeDebounced(AbyssalKnifeBlunt, WeaponModifier.OnConfigAbyssalKnifeValueChanged);
            OnChangeDebounced(AbyssalKnifeBluntPerLevel, WeaponModifier.OnConfigAbyssalKnifeValueChanged);
            EnableVanillaSpear = BindServerConfig("Vanilla Weapons", "VanillaFlintSpearCraftable", false, "Disables or enables crafting of the vanilla spear, to be used in conjuction with the VA flint spear.");
            EnableVanillaSpear.SettingChanged += WeaponModifier.OnConfigChangeModifyVanillaFlintSpear;
            EnableVanillaFlintAxe = BindServerConfig("Vanilla Weapons", "VanillaFlintAxeCraftable", false, "Disables or enables crafting of the vanilla flint axe, to be used in conuction with the VA flint axe.");
            EnableVanillaFlintAxe.SettingChanged += WeaponModifier.OnConfigChangeModifyVanillaFlintAxe;


            BloodHungerRegen = BindServerConfig("Status Effects", "BloodHungerRegen", 2f, "How strong the hp regen effect for blood weapons is (2 is 200% regen).", true, 0f, 5f);
            OnChangeDebounced(BloodHungerRegen, StatusModifiers.OnConfigBloodChanged);
            QueenHealthRegen = BindServerConfig("Status Effects", "QueenHealthRegen", 1.3f, "How strong the hp regen effect for the queen is (1 is 100% additional regen).", true, 0f, 5f);
            OnChangeDebounced(QueenHealthRegen, StatusModifiers.OnConfigQueenHealthRegenChanged);
            QueenEitrRegen = BindServerConfig("Status Effects", "QueenEitrRegen", 2.5f, "How strong the eitr regen effect for the queen is (2 is 200% additional regen).", true, 0f, 5f);
            OnChangeDebounced(QueenEitrRegen, StatusModifiers.OnConfigQueenHealthRegenChanged);

            InMemoryModificationsPerTick = BindServerConfig("General", "InMemoryModificationsPerTick", 10, "How many modifications should be processed per tick.", true, 1, 100);
            ConfigApplyDelay = BindServerConfig("Config", "Config Apply Delay", 1f, "Delay in seconds before a changed config entry is applied in-game. Coalesces a burst of rapid edits (typing, file reloads, server sync) into a single apply. Set to 0 to apply instantly.", true, 0f, 10f);
            ConfigPollIntervalSeconds = BindServerConfig("Config", "Config Poll Interval", 30f, "Seconds between checks for edits to this mod's config file while a world is running. Lower reacts faster to a hand edit, higher does less disk work.", true, 1f, 300f);
        }

        // Watches the config file for edits made outside the game. Only a server reloads (see
        // OnMainConfigFileChanged). Call after the plugin's logger is set, since registering logs.
        internal static void SetupMainFileWatcher() {
            ConfigFileWatcher.Register(cfg.ConfigFilePath, OnMainConfigFileChanged);
            ConfigFileWatcher.Initialize();
        }

        // A client must not reload: Jotunn has already replaced its in-memory values with the server's, and
        // a reload would put back whatever this machine has on disk.
        private static void OnMainConfigFileChanged(string _) {
            if (ZNet.instance == null || ZNet.instance.IsServer() == false) { return; }
            Logger.LogInfo("Configuration file has been changed, reloading settings.");
            cfg.Reload();
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
