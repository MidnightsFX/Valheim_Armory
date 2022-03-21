// Kitbashed Item recipes for Valheim Additions


using BepInEx;
using Jotunn.Managers;
using Jotunn.Utils;
using System;
using Logger = Jotunn.Logger;
using UnityEngine;
using Jotunn.Entities;
using Jotunn.Configs;
using System.Collections.Generic;
using BepInEx.Configuration;

namespace ValheimAdditions
{
    internal class Kitbashed : MonoBehaviour
    {
        private void SerpentScaleRoundShield_kitbash()
        {
            var simpleKitbashPiece = new CustomPiece("piece_simple_kitbash", true, "Hammer");
            // var piece = simpleKitbashPiece.Piece;
            // piece.m_icon = testSprite; // TODO get an icon
            simpleKitbashPiece.FixReference = true;
            PieceManager.Instance.AddPiece(simpleKitbashPiece);
            KitbashManager.Instance.AddKitbash(simpleKitbashPiece.PiecePrefab, new KitbashConfig
            {
                Layer = "piece",
                KitbashSources = new List<KitbashSourceConfig>
            {
                new KitbashSourceConfig
                {
                    Name = "eye_1",
                    SourcePrefab = "Ruby",
                    SourcePath = "attach/model",
                    Position = new Vector3(0.528f, 0.1613345f, -0.253f),
                    Rotation = Quaternion.Euler(0, 180, 0f),
                    Scale = new Vector3(0.02473f, 0.05063999f, 0.05064f)
                },
                new KitbashSourceConfig
                {
                    Name = "eye_2",
                    SourcePrefab = "Ruby",
                    SourcePath = "attach/model",
                    Position = new Vector3(0.528f, 0.1613345f, 0.253f),
                    Rotation = Quaternion.Euler(0, 180, 0f),
                    Scale = new Vector3(0.02473f, 0.05063999f, 0.05064f)
                },
                new KitbashSourceConfig
                {
                    Name = "mouth",
                    SourcePrefab = "draugr_bow",
                    SourcePath = "attach/bow",
                    Position = new Vector3(0.53336f, -0.315f, -0.001953f),
                    Rotation = Quaternion.Euler(-0.06500001f, -2.213f, -272.086f),
                    Scale = new Vector3(0.41221f, 0.41221f, 0.41221f)
                }
            }
            });
        }
        
    }
}
