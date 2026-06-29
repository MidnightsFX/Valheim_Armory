using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ValheimArmory;

namespace ValheimArmory.Common {
    internal static class ConfigChangeDebouncer {
        // Latest action to run per key (the changed ConfigEntry instance).
        private static readonly Dictionary<object, Action> pendingActions = new Dictionary<object, Action>();
        // Time (Time.realtimeSinceStartup) at which each key's action should fire.
        private static readonly Dictionary<object, float> fireAt = new Dictionary<object, float>();
        // Keys with a coroutine already waiting, so we don't start a second one.
        private static readonly HashSet<object> running = new HashSet<object>();

        // Schedules action to run after ValConfig.ConfigApplyDelay seconds. Re-calling with the same
        // key before it fires replaces the action and resets the timer (true debounce + coalesce).
        // A delay <= 0 applies immediately (lets admins disable the delay).
        internal static void Schedule(object key, Action action) {
            float delay = ValConfig.ConfigApplyDelay != null ? ValConfig.ConfigApplyDelay.Value : 0f;
            if (delay <= 0f) {
                action();
                return;
            }
            pendingActions[key] = action;
            fireAt[key] = Time.realtimeSinceStartup + delay;
            if (running.Contains(key)) { return; }
            running.Add(key);
            BepInEx.ThreadingHelper.Instance.StartCoroutine(Run(key));
        }

        private static IEnumerator Run(object key) {
            // Wait until the entry has been idle for the full delay; re-scheduling pushes fireAt out.
            while (fireAt.TryGetValue(key, out float at) && Time.realtimeSinceStartup < at) {
                yield return null;
            }
            pendingActions.TryGetValue(key, out Action action);
            pendingActions.Remove(key);
            fireAt.Remove(key);
            running.Remove(key);
            action?.Invoke();
        }
    }
}
