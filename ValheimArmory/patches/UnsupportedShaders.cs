using HarmonyLib;
using Jotunn.Managers;
using System.Collections.Generic;
using UnityEngine;
using ValheimArmory.Common;

namespace ValheimArmory.patches
{
    // Keeps this mod's effects from drawing pink when another mod loads a copy of a shader they use that this graphics card
    // cannot run. Most of the particle materials here (arrow trails, the sparkle on dropped items, weapon glows) use Jotunn
    // mock shaders, which Jotunn resolves by name to the last loaded shader of that name it finds, without checking that the
    // shader runs here. ChebsNecromancy's asset bundle carries copies of built-in shaders such as
    // "Legacy Shaders/Particles/Alpha Blended" compiled for OpenGL and Vulkan only, so on DirectX our materials could be
    // given one of those and draw pink (chebs-necromancy issue #296). After each pass where Jotunn resolves mocks, any of our
    // materials left on a shader that cannot run is moved to a loaded shader of the same name that can.
    public static class UnsupportedShaders
    {
        // Every prefab this mod makes: those in its asset bundle and the runtime made copies of them (DualWeapons).
        private static List<GameObject> prefabs;
        // Shader names already reported as having no working copy, so each is logged once.
        private static readonly HashSet<string> reportedMissing = new HashSet<string>();
        // Unity's stand in for a material with no usable shader. Jotunn puts a material with it in each empty material
        // slot, such as the first slot of the particle effects here that only draw trails. That slot is never drawn and
        // the shader never runs anywhere, so there is nothing to switch or report.
        private const string ErrorShader = "Hidden/InternalErrorShader";

        // Runs after Jotunn registers items and resolves their mocks, in the main menu and in a world.
        internal static void Fix()
        {
            if (GUIManager.IsHeadless()) { return; }
            if (prefabs == null) { prefabs = CollectPrefabs(); }

            Dictionary<string, Shader> working = null;
            Dictionary<string, int> moved = new Dictionary<string, int>();
            foreach (Material material in CurrentMaterials()) {
                if (material == null || material.shader == null || material.shader.isSupported) { continue; }
                string name = material.shader.name;
                if (name == ErrorShader) { continue; }
                // Only built when something needs it, which is never on a normal install.
                if (working == null) { working = WorkingShadersByName(); }
                if (working.TryGetValue(name, out Shader shader) == false) {
                    if (reportedMissing.Add(name)) {
                        Logger.LogWarning($"Shader {name} used by Valheim Armory cannot run on this graphics card and no working copy of it is loaded, effects using it may look pink.");
                    }
                    continue;
                }
                material.shader = shader;
                moved.TryGetValue(name, out int count);
                moved[name] = count + 1;
            }
            foreach (KeyValuePair<string, int> entry in moved) {
                Logger.LogInfo($"Shader {entry.Key} on {entry.Value} Valheim Armory materials cannot run on this graphics card, likely a copy loaded by another mod. Switched them to a working copy.");
            }
        }

        private static List<GameObject> CollectPrefabs()
        {
            List<GameObject> found = new List<GameObject>(JotunBatchLoader.Assets.LoadAllAssets<GameObject>());
            foreach (ItemDefinition itemdef in JotunBatchLoader.resourceDefinitions) {
                if (itemdef.GeneratedPrefab != null) { found.Add(itemdef.GeneratedPrefab); }
            }
            return found;
        }

        // Read again on every pass. When Jotunn resolves a prefab's mocks it reads each renderer's material property,
        // which swaps the material for a copy, and gives the copy the resolved shader. Items are resolved in the main
        // menu, but projectiles and their hit effects only once a world loads, so materials kept from an earlier pass
        // would miss their copies.
        private static HashSet<Material> CurrentMaterials()
        {
            HashSet<Material> found = new HashSet<Material>();
            foreach (GameObject prefab in prefabs) {
                if (prefab == null) { continue; }
                // ParticleSystemRenderer lists its trail material here too. Only the shared materials are read, reading
                // material or materials would make yet more copies.
                foreach (Renderer renderer in prefab.GetComponentsInChildren<Renderer>(true)) {
                    foreach (Material material in renderer.sharedMaterials) {
                        if (material != null) { found.Add(material); }
                    }
                }
            }
            return found;
        }

        private static Dictionary<string, Shader> WorkingShadersByName()
        {
            Dictionary<string, Shader> working = new Dictionary<string, Shader>();
            foreach (Shader shader in Resources.FindObjectsOfTypeAll<Shader>()) {
                if (shader.isSupported && working.ContainsKey(shader.name) == false) {
                    working.Add(shader.name, shader);
                }
            }
            return working;
        }

        // Jotunn resolves the mocks it could not resolve during item registration once the world starts loading, which can
        // also hand out a shader that cannot run, so check again after it.
        [HarmonyPatch(typeof(ZoneSystem), nameof(ZoneSystem.Start))]
        public static class AfterLateMockPass
        {
            [HarmonyPriority(Priority.Last)]
            public static void Postfix()
            {
                Fix();
            }
        }
    }
}
