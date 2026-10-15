using BepInEx.Configuration;
using HarmonyLib;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using UnityEngine;

namespace ValheimArmory.patches
{
    // Lets each item need a different crafting station level to be repaired than to be crafted. Vanilla has no repair
    // level of its own: InventoryGui.CanRepair checks the station against the recipe's m_minStationLevel, the crafting
    // level, and the tooltip's repair level line shows that same field. Both reads are swapped for RequiredLevel, so the
    // recipe itself is never changed, crafting and upgrading are unaffected, and a config change applies on the next check.
    // EpicLoot draws its own tooltip for magic items (MagicTooltip) and reads m_minStationLevel itself, so an enchanted
    // item's tooltip still shows the crafting level; the repair check is ours either way.
    public static class RepairStationLevel
    {
        // Item prefab -> its repair level config. Keyed by the ObjectDB prefab that every ItemData.m_dropPrefab points at,
        // same as ProjectileAdrenaline.
        private static readonly Dictionary<GameObject, ConfigEntry<int>> RepairLevels = new Dictionary<GameObject, ConfigEntry<int>>();

        internal static void Register(ItemDrop item, ConfigEntry<int> repairLevel)
        {
            RepairLevels[item.gameObject] = repairLevel;
        }

        // Station level needed to repair this item: its configured repair level, or the crafting level when that is 0 or
        // the item is not one of ours. CanRepair counts any station above level 4 as 4, which is why the config stops there.
        public static int RequiredLevel(Recipe recipe, ItemDrop.ItemData item)
        {
            if (item != null && item.m_dropPrefab != null && RepairLevels.TryGetValue(item.m_dropPrefab, out ConfigEntry<int> repairLevel) && repairLevel.Value > 0) {
                return repairLevel.Value;
            }
            return recipe.m_minStationLevel;
        }

        // Replaces `recipe.m_minStationLevel` with `RequiredLevel(recipe, item)`: the recipe is already on the stack, so the
        // item is pushed after it and the field read becomes the call. If a game update changes the method so the read is
        // not found, nothing is replaced and repairs keep using the crafting level.
        private static IEnumerable<CodeInstruction> ReadRepairLevel(IEnumerable<CodeInstruction> instructions, OpCode loadItem, string method)
        {
            FieldInfo minStationLevel = AccessTools.Field(typeof(Recipe), nameof(Recipe.m_minStationLevel));
            MethodInfo requiredLevel = AccessTools.Method(typeof(RepairStationLevel), nameof(RequiredLevel));
            int replaced = 0;
            foreach (CodeInstruction instruction in instructions) {
                if (instruction.LoadsField(minStationLevel)) {
                    yield return new CodeInstruction(loadItem).MoveLabelsFrom(instruction);
                    yield return new CodeInstruction(OpCodes.Call, requiredLevel);
                    replaced++;
                    continue;
                }
                yield return instruction;
            }
            if (replaced != 1) {
                Logger.LogWarning($"Expected one recipe station level read in {method}, found {replaced}. Repair station level configs may not apply.");
            }
        }

        [HarmonyPatch(typeof(InventoryGui), nameof(InventoryGui.CanRepair))]
        public static class RepairCheck
        {
            // CanRepair(ItemData item) is an instance method, so the item is argument 1.
            public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                return ReadRepairLevel(instructions, OpCodes.Ldarg_1, nameof(InventoryGui.CanRepair));
            }
        }

        [HarmonyPatch(typeof(ItemDrop.ItemData), nameof(ItemDrop.ItemData.GetTooltip), new[] { typeof(ItemDrop.ItemData), typeof(int), typeof(bool), typeof(float), typeof(int), typeof(bool) })]
        public static class RepairLevelTooltip
        {
            // The static GetTooltip(ItemData item, ...) overload builds every item tooltip; the item is argument 0.
            public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                return ReadRepairLevel(instructions, OpCodes.Ldarg_0, nameof(ItemDrop.ItemData.GetTooltip));
            }
        }
    }
}
