using Logger = Jotunn.Logger;
using UnityEngine;
using Jotunn.Configs;
using Jotunn.Utils;
using Jotunn.Entities;
using Jotunn.Managers;
using System;

namespace ValheimArmory
{
    class ValheimArmoryPieces
    {
        public ValheimArmoryPieces(AssetBundle EmbeddedResourceBundle, VAConfig cfg)
        {
            if (VAConfig.EnableDebugMode.Value == true)
            {
                // Logger.LogInfo("Loading Pieces.");
            }

            //AddArtisanTableUpgrades(EmbeddedResourceBundle, cfg);

        }

        // Adds Upgrade pieces to the artisan table allowing items crafted there to be upgraded
        /** private void AddArtisanTableUpgrades(AssetBundle EmbeddedResourceBundle, VAConfig cfg)
        {
            if (VAConfig.ArtisanTableUpgrade1ConfigEnabled.Value == false) {
                if (VAConfig.EnableDebugMode.Value == true) { Logger.LogWarning("Artisan Table Upgrade1 not loaded."); }
            } else {
                try {
                    Sprite sprite = EmbeddedResourceBundle.LoadAsset<Sprite>("Assets/Custom/Icons/artisan_upgrade1_large.png");
                    PieceConfig ArtisanUpgrade1 = new PieceConfig();
                    ArtisanUpgrade1.Name = "Experimental Equipment";
                    ArtisanUpgrade1.Icon = sprite;
                    ArtisanUpgrade1.PieceTable = "Hammer";
                    ArtisanUpgrade1.Category = "Crafting";
                    ArtisanUpgrade1.ExtendStation = "piece_artisanstation";
                    ArtisanUpgrade1.Requirements = new[]
                    {
                        new RequirementConfig { Item = "BlackMetal", Amount = 8, Recover = true },
                        new RequirementConfig { Item = "Iron", Amount = 6, Recover = true },
                        new RequirementConfig { Item = "FineWood", Amount = 6, Recover = true },
                        new RequirementConfig { Item = "DragonTear", Amount = 1, Recover = true },
                    };

                    PieceManager.Instance.AddPiece(new CustomPiece(EmbeddedResourceBundle, "VAartisan_ext1", fixReference: true, ArtisanUpgrade1));
                    Logger.LogInfo("Artisan Table Upgrade1 loaded.");
                } catch (Exception ex) {
                    Logger.LogError("Error loading Artisan Table Upgrade1");
                    Logger.LogError(ex);
                }
            }

            
        } **/

        
    }
}
