using BepInEx.Configuration;
using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;

namespace ValheimArmory.patches
{
    public static class ProjectileAdrenaline
    {
        // Item prefab -> adrenaline its projectiles grant on hit.
        // Keyed by the ObjectDB prefab that every ItemData.m_dropPrefab points at, same as HybridBloodWeapon.
        private static readonly Dictionary<GameObject, ConfigEntry<float>> ProjectileItems = new Dictionary<GameObject, ConfigEntry<float>>();

        // Registered from ItemStat.projectile_adrenaline as items are added
        internal static void Register(ItemDrop item, ConfigEntry<float> adrenaline)
        {
            ProjectileItems[item.gameObject] = adrenaline;
        }

        // Set on each spawned projectile rather than on the projectile prefab: the blood bows and Soul Stealer share one
        // projectile, each staff pair shares one, and the druid fire/ice staves fire vanilla projectiles. Editing the prefab
        // would let one item's config overwrite another's, or change vanilla weapons.
        [HarmonyPatch(typeof(Projectile), nameof(Projectile.Setup))]
        public static class SetProjectileAdrenaline
        {
            public static void Postfix(Projectile __instance, ItemDrop.ItemData item, ItemDrop.ItemData ammo)
            {
                // Mirrors Attack.ProjectileAttackTriggered: ammo that carries its own projectile replaces the weapon's.
                ItemDrop.ItemData source = ammo != null && ammo.m_shared.m_attack.m_attackProjectile != null ? ammo : item;
                if (source == null || source.m_dropPrefab == null) { return; }
                if (!ProjectileItems.TryGetValue(source.m_dropPrefab, out ConfigEntry<float> adrenaline)) { return; }
                __instance.m_adrenaline = adrenaline.Value;
            }
        }
    }
}
