using BepInEx.Logging;
using System;

namespace ValheimArmory.common
{
    internal static class Logger
    {

        public static LogLevel Level = LogLevel.Info;

        public static void enableDebugLogging(object sender, EventArgs e)
        {
            if (VAConfig.EnableDebugMode.Value) {
                Level = LogLevel.Debug;
            } else {
                Level = LogLevel.Info;
            }
            // set log level
        }

        public static void toggleDebug()
        {
            if (VAConfig.EnableDebugMode.Value)
            {
                Level = LogLevel.Debug;
            } else {
                Level = LogLevel.Info;
            }
            // set log level
        }

        public static void LogDebug(string message)
        {
            if (Level >= LogLevel.Debug) {
                ValheimArmory.Log.LogInfo(message);
            }
        }
        public static void LogInfo(string message)
        {
            if (Level >= LogLevel.Info)
            {
                ValheimArmory.Log.LogInfo(message);
            }
        }

        public static void LogWarning(string message)
        {
            if (Level >= LogLevel.Warning)
            {
                ValheimArmory.Log.LogWarning(message);
            }
        }

        public static void LogError(string message)
        {
            if (Level >= LogLevel.Error)
            {
                ValheimArmory.Log.LogError(message);
            }
        }
    }
}
