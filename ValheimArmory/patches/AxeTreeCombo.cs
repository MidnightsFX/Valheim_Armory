using BepInEx.Configuration;
using HarmonyLib;

namespace ValheimArmory.patches
{
    // Lets axes keep their attack combo going while chopping trees. Vanilla axes, dual axes and greataxes
    // (and Armory's, which copy them) set m_resetChainIfHit to Tree, so every swing that lands on a tree
    // starts the combo over and only the first swing of the chain is ever used on wood.
    //
    // The Tree flag is cleared on the swing's own Attack rather than on the item: Humanoid.StartAttack
    // clones the weapon's attack for every swing, so the shared item data is never touched and a config
    // change applies from the next swing on, with nothing to re-apply to items already in the world.
    public static class AxeTreeCombo
    {
        private const string Section = "Tree Chopping";

        public static ConfigEntry<bool> AxesKeepCombo;
        public static ConfigEntry<bool> DualAxesKeepCombo;
        public static ConfigEntry<bool> GreataxesKeepCombo;

        internal static void BindConfig()
        {
            AxesKeepCombo = ValConfig.BindServerConfig(Section, "AxesKeepComboOnTrees", false, "One handed axes keep their attack combo going when they hit a tree, instead of starting over at the first swing. Applies to vanilla and mod added axes.");
            DualAxesKeepCombo = ValConfig.BindServerConfig(Section, "DualAxesKeepComboOnTrees", false, "Dual axes keep their attack combo going when they hit a tree, instead of starting over at the first swing. Applies to vanilla and mod added dual axes.");
            GreataxesKeepCombo = ValConfig.BindServerConfig(Section, "GreataxesKeepComboOnTrees", false, "Greataxes (battleaxes) keep their attack combo going when they hit a tree, instead of starting over at the first swing. Applies to vanilla and mod added greataxes.");
        }

        // Dual axes and greataxes are both two handed axes, so the dual axes are told apart by their animation.
        private static ConfigEntry<bool> EntryFor(ItemDrop.ItemData weapon)
        {
            if (weapon == null || weapon.m_shared.m_skillType != Skills.SkillType.Axes) { return null; }
            if (weapon.m_shared.m_attack.m_attackAnimation == "dualaxes") { return DualAxesKeepCombo; }
            switch (weapon.m_shared.m_itemType) {
                case ItemDrop.ItemData.ItemType.OneHandedWeapon:
                    return AxesKeepCombo;
                case ItemDrop.ItemData.ItemType.TwoHandedWeapon:
                case ItemDrop.ItemData.ItemType.TwoHandedWeaponLeft:
                    return GreataxesKeepCombo;
            }
            return null;
        }

        // DoMeleeAttack is where the chain is reset on a tree hit, and it runs for the attacker only, which
        // reads the admin's synced value.
        [HarmonyPatch(typeof(Attack), nameof(Attack.DoMeleeAttack))]
        public static class KeepComboOnTreeHit
        {
            public static void Prefix(Attack __instance)
            {
                if ((__instance.m_resetChainIfHit & DestructibleType.Tree) == DestructibleType.None) { return; }
                ConfigEntry<bool> keepCombo = EntryFor(__instance.m_weapon);
                if (keepCombo == null || keepCombo.Value == false) { return; }
                __instance.m_resetChainIfHit &= ~DestructibleType.Tree;
            }
        }
    }
}
