using HarmonyLib;
using Jotunn.Managers;
using System;
using UnityEngine;

namespace ValheimArmory.patches
{
    // How a dual sword (see DualSwords) looks: the second sword in the left hand and its swing trail, the pair crossed on
    // the ground, on item stands and on the back, and its icon.
    public static class DualSwordVisuals
    {
        // The second sword of a pair crosses the first: turned this many degrees about the blade's flat side, through a
        // point this far along the blade, and lifted this far off it so the two blades do not cut through each other.
        // Every sword's attach has the grip at its origin and the blade along +z, so one setting suits them all.
        private const float CrossAngle = 35f;
        private const float CrossAt = 0.45f;
        private const float CrossLift = 0.02f;
        // In the icon, each sword of the pair is drawn at this fraction of the icon's size, and moved this fraction of it
        // towards its own side.
        private const float IconScale = 0.92f;
        private const float IconShift = 0.05f;

        // The sword's attach only makes the right hand sword. Adds the second sword for the ground (beside attach, under a
        // name VisEquipment, ItemStand and other mods looking for "attach" all pass over) and an attach_back holding both
        // for when the pair is sheathed. attach_back goes first, as VisEquipment takes whichever of the two it reaches
        // first, and stays inactive so it is not also drawn on the ground.
        //
        // The pair is centred on where the sword lies on its own, each sword turned half the crossing angle the opposite
        // way. For the ground that turns attach itself, which only the ground and item stands see: in the hand,
        // VisEquipment resets attach's own position and rotation.
        internal static void AddPairModels(GameObject prefab)
        {
            Transform attach = prefab.transform.Find("attach");
            if (attach == null) {
                Logger.LogWarning($"{prefab.name} has no attach, its pair is not drawn on the ground or the back.");
                return;
            }
            float bladeLength = BladeLength(attach);
            Vector3 firstPosition = CrossPosition(bladeLength, -CrossAngle / 2f, 0f, out Quaternion firstRotation);
            Vector3 secondPosition = CrossPosition(bladeLength, CrossAngle / 2f, CrossLift, out Quaternion secondRotation);

            Transform second = UnityEngine.Object.Instantiate(attach.gameObject, prefab.transform, false).transform;
            second.name = "dual_second";
            second.localPosition = attach.localPosition + attach.localRotation * Vector3.Scale(attach.localScale, secondPosition);
            second.localRotation = attach.localRotation * secondRotation;

            GameObject back = new GameObject("attach_back");
            back.SetActive(false);
            back.transform.SetParent(prefab.transform, false);
            back.transform.SetSiblingIndex(0);
            Transform pivot = new GameObject("pivot").transform;
            pivot.SetParent(back.transform, false);
            AddBackSword(attach, pivot, "sword", firstPosition, firstRotation);
            AddBackSword(attach, pivot, "sword_second", secondPosition, secondRotation);
            foreach (Collider collider in back.GetComponentsInChildren<Collider>(true)) {
                UnityEngine.Object.DestroyImmediate(collider);
            }

            attach.localPosition += attach.localRotation * Vector3.Scale(attach.localScale, firstPosition);
            attach.localRotation *= firstRotation;
        }

        private static void AddBackSword(Transform attach, Transform pivot, string name, Vector3 position, Quaternion rotation)
        {
            Transform sword = UnityEngine.Object.Instantiate(attach.gameObject, pivot, false).transform;
            sword.name = name;
            sword.localPosition = position;
            sword.localRotation = rotation;
            // In the hand, the attach keeps its own scale, so each sword on the back does too.
            sword.localScale = attach.localScale;
        }

        // Where a sword of the pair sits in the attach's own space: turned by angle about its y (the blade's flat side)
        // around the crossing point on the blade, and lifted along y.
        private static Vector3 CrossPosition(float bladeLength, float angle, float lift, out Quaternion rotation)
        {
            rotation = Quaternion.AngleAxis(angle, Vector3.up);
            Vector3 crossing = new Vector3(0f, 0f, CrossAt * bladeLength);
            return crossing - rotation * crossing + Vector3.up * lift;
        }

        // How far the sword reaches along the attach's z. Mesh bounds can be read even from the meshes whose vertices
        // can't be (most of the late vanilla swords).
        private static float BladeLength(Transform attach)
        {
            float length = 0f;
            Matrix4x4 toAttach = attach.worldToLocalMatrix;
            foreach (MeshFilter filter in attach.GetComponentsInChildren<MeshFilter>(true)) {
                if (filter.sharedMesh == null) { continue; }
                Bounds bounds = filter.sharedMesh.bounds;
                Matrix4x4 toAttachFromMesh = toAttach * filter.transform.localToWorldMatrix;
                for (int corner = 0; corner < 8; corner++) {
                    Vector3 point = new Vector3(
                        (corner & 1) == 0 ? bounds.min.x : bounds.max.x,
                        (corner & 2) == 0 ? bounds.min.y : bounds.max.y,
                        (corner & 4) == 0 ? bounds.min.z : bounds.max.z);
                    length = Mathf.Max(length, toAttachFromMesh.MultiplyPoint3x4(point).z);
                }
            }
            return length > 0f ? length : 1f;
        }

        // The sword's icon and its mirror image, crossed, like this mod's dual axe icons. Drawn on the GPU, as vanilla's
        // icons sit in atlases that can't be read on the CPU. Null where it can't be drawn, which leaves the copy with
        // the sword's icon: always on a server, which draws no icons.
        internal static Sprite PairIcon(ItemDrop.ItemData.SharedData sword)
        {
            if (GUIManager.IsHeadless() || sword.m_icons == null || sword.m_icons.Length == 0 || sword.m_icons[0] == null) { return null; }
            Sprite icon = sword.m_icons[0];
            // A sprite packed tight or turned in its atlas has no plain rectangle to copy from.
            if (icon.packed && (icon.packingMode == SpritePackingMode.Tight || icon.packingRotation != SpritePackingRotation.None)) {
                Logger.LogWarning($"The icon of {sword.m_name} is packed in a way that can't be copied, its dual version keeps the sword's icon.");
                return null;
            }
            try {
                return DrawPairIcon(icon);
            } catch (Exception e) {
                Logger.LogWarning($"Could not draw the dual icon for {sword.m_name}, it keeps the sword's icon: {e.Message}");
                return null;
            }
        }

        private static Sprite DrawPairIcon(Sprite icon)
        {
            Texture texture = icon.texture;
            Rect rect = icon.textureRect;
            int size = Mathf.RoundToInt(Mathf.Max(rect.width, rect.height));
            Rect uv = new Rect(rect.x / texture.width, rect.y / texture.height, rect.width / texture.width, rect.height / texture.height);
            Rect mirroredUv = new Rect(uv.xMax, uv.y, -uv.width, uv.height);
            float drawn = size * IconScale;
            float inset = (size - drawn) / 2f;
            float shift = size * IconShift;

            RenderTexture target = RenderTexture.GetTemporary(size, size, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.sRGB);
            RenderTexture previous = RenderTexture.active;
            RenderTexture.active = target;
            try {
                GL.Clear(true, true, Color.clear);
                GL.PushMatrix();
                GL.LoadPixelMatrix(0, size, size, 0);
                // The mirror image underneath and to the right, the sword itself on top and to the left, so the hilts
                // part at the bottom.
                Graphics.DrawTexture(new Rect(inset + shift, inset, drawn, drawn), texture, mirroredUv, 0, 0, 0, 0);
                Graphics.DrawTexture(new Rect(inset - shift, inset, drawn, drawn), texture, uv, 0, 0, 0, 0);
                GL.PopMatrix();
                Texture2D pair = new Texture2D(size, size, TextureFormat.RGBA32, false);
                pair.ReadPixels(new Rect(0, 0, size, size), 0, 0);
                pair.Apply();
                pair.name = $"{icon.name}_dual";
                return Sprite.Create(pair, new Rect(0, 0, size, size), new Vector2(0.5f, 0.5f));
            } finally {
                RenderTexture.active = previous;
                RenderTexture.ReleaseTemporary(target);
            }
        }

        // The second sword. The owner sets the dual sword as the left hand item too, so VisEquipment attaches its attach
        // to LeftHand_Attach. The left hand item goes out in the player's ZDO, so other players draw it without this patch.
        // Animations come from the Humanoid's own items, not from what VisEquipment shows, so the dual axes state is untouched.
        [HarmonyPatch(typeof(Humanoid), nameof(Humanoid.SetupVisEquipment))]
        public static class LeftHandMirror
        {
            public static void Postfix(Humanoid __instance, VisEquipment visEq, bool isRagdoll)
            {
                if (isRagdoll || __instance.m_leftItem != null) { return; }
                ItemDrop.ItemData right = __instance.m_rightItem;
                if (right == null || right.m_dropPrefab == null) { return; }
                int hash = right.m_dropPrefab.name.GetStableHashCode();
                if (DualSwords.DualHashes.Contains(hash) == false) { return; }
                visEq.SetLeftItem(hash, right.m_variant, right.m_quality);
            }
        }

        // Item stands build their visual from attach alone, so the second sword is added to it, where it lies on the
        // ground relative to attach. As its child, it follows the stand's orientation settings and goes when the visual
        // is replaced. The stand calls this every few seconds and only builds a new visual when the item changed, so the
        // sword is only added to a visual that was just made.
        [HarmonyPatch(typeof(ItemStand), nameof(ItemStand.SetVisualItem))]
        public static class ItemStandPair
        {
            public static void Prefix(ItemStand __instance, out GameObject __state)
            {
                __state = __instance.m_visualItem;
            }

            public static void Postfix(ItemStand __instance, int itemHash, int quality, GameObject __state)
            {
                GameObject visual = __instance.m_visualItem;
                if (visual == null || visual == __state || DualSwords.DualHashes.Contains(itemHash) == false) { return; }
                GameObject prefab = ObjectDB.instance.GetItemPrefab(itemHash);
                Transform attach = prefab != null ? prefab.transform.Find("attach") : null;
                Transform second = prefab != null ? prefab.transform.Find("dual_second") : null;
                if (attach == null || second == null) { return; }
                Matrix4x4 attachToSecond = Matrix4x4.TRS(attach.localPosition, attach.localRotation, attach.localScale).inverse
                    * Matrix4x4.TRS(second.localPosition, second.localRotation, second.localScale);
                Transform copy = UnityEngine.Object.Instantiate(second.gameObject, visual.transform, false).transform;
                copy.localPosition = attachToSecond.GetColumn(3);
                copy.localRotation = attachToSecond.rotation;
                copy.localScale = Vector3.one;
                foreach (ParticleIntensityScaler scaler in copy.GetComponentsInChildren<ParticleIntensityScaler>()) {
                    scaler.SetQuality(quality);
                }
            }
        }

        // Swing trails only run on the right hand item unless m_useAllTrails is set, which it is not on players. Runs on
        // every client, from the attack's animation events.
        [HarmonyPatch(typeof(VisEquipment), nameof(VisEquipment.SetWeaponTrails))]
        public static class LeftHandTrails
        {
            public static void Postfix(VisEquipment __instance, bool enabled)
            {
                if (__instance.m_useAllTrails || __instance.m_leftItemInstance == null || DualSwords.DualHashes.Contains(__instance.m_currentLeftItemHash) == false) { return; }
                foreach (MeleeWeaponTrail trail in __instance.m_leftItemInstance.GetComponentsInChildren<MeleeWeaponTrail>()) {
                    trail.Emit = enabled;
                }
            }
        }
    }
}
