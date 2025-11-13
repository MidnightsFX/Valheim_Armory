**1.25.4**
 ---
 ```
 - Fixes flint spear gaining frost damage on levelup
 ```

**1.25.3**
 ---
 ```
 - Add tool level configuration for all Axe type weapons (already available on pickaxe)
 - Fixes default tool level for flint axe being bronze level not flint level
 - Converted projectile count on soulstealer to whole number config (delete your config file or reset the value to default if you have errors)
 ```

**1.25.2**
 ---
 ```
 - Updates Korean and French translations (thanks bellreco0912-art and Dalkhus)
 - Fixes for bolts not showing up in the bolt category in MyLittleUI
 - Fixes for bolts/arrows from VA not returning ammo from the archery target
 - Localization for new weapons
 ```

**1.25.1**
 ---
 ```
 - Fixes flint axe config
 - Adds primary and secondary force multipliers (knockback) configuration for all modded sledges
 - Adjusts modded sledges knockback to allow primary attacks to keep enemies at arms reach, and slam to send them flying (delete your config if you want the new defaults)
 - Reduces early game maces/hammers default force (knockback)
 ```

**1.25.0**
 ---
 ```
 - Fixes missing woosh sounds for sledges
 - Fixes trail effects not being activated for some axes
 - Adds bonemass dualaxes
 - Added Wood Crossbow
 - Added Silver Crossbow
 - Added Mistlands tower shield
 - Added Soulstealer
 - Fixes texture issue for the blood pick on MacOSX
 - Remodeled a number of flint weapons
    - Flint Spear and Flint axe alternatives are now available and enabled by default (configuration available to disable/enable both)
 ```

**1.24.1**
 ---
 ```
 - Fixes dragonfrost and crystal dualaxes sharing the same config values
 ```

**1.24.0**
 ---
 ```
 - Updated models and textures for all Bonemass Weapons
 - Added Bonerot Blade, Bonerot Axe
 - All Sledges, 2H axes, and tower shields now have a default movement speed penalty of -15% (reduced from -20%) 
 - Added the Iron Crossbow
 - Added Abyssal Dual knives
 - Added Moders Axe and Dualaxe
 - Retuned and rebalanced the bronze arbalest
 - Added missing sound effect to Yagluth fists
 - Updated texture and model of Bonemass Sword, Greatsword and Knife
 ```

**1.23.2**
 ---
 ```
 - Fixed auto pickup for silver knives and copper knives
 - Reduces default resistance of the elder shield for blunt to resistant from veryResistant
 - Ensured that Moders tower shield has no parry multiplier
 ```

**1.23.1**
 ---
 ```
 - Adds missing translations to recently added weapons (community translations are still greatly appreciated!)
 - Fixes some cases where status effects would not be modified by the config
 ```

**1.23.0**
 ---
 ```
 - Added the blackmetal crossbow
 - Added new model variants for the flametal 2H Elemental variants (Shoutout to Mario Zúñiga)
 - Added Faders Spear, Faders sword and Faders greatsword
 - Improves stamina and damage consistency of dualaxes vs the berserker axes
 - Increases default damage of dualaxes at lower tiers to match their 1H variants (delete your config if you want the new defaults)
 - Added configuration options to tune the status effects provided by this mod (blood hunger, and Queens presence)
 - Adds missing sfx to some lightning and nature weapons that were missing it
 - Improves grip on the assassins lightning knives
 - All dual wielded knives now show up on your character when stowed instead of disappearing
 ```

**1.22.7**
 ---
 ```
 - Hotfix to prevent the filewatcher from becoming overreactive when trying to connect to a modded server
 ```

**1.22.6**
 ---
 ```
 - Fixes dragonfrost spear grip
 - Fixes config definitions not being hot reloaded if they are manually edited from the config file while the game/server is running
 ```

**1.22.5**
 ---
 ```
 - Fixes thrown spears disappearing
 - Fixes thrown spears sometimes falling underneath the world or rocks
 ```

**1.22.4**
 ---
 ```
 - Fixes damage/resistance modifiers not being applied initially
 - Fixes combo reset when hitting trees with the blackmarble mace
 ```

**1.22.3**
 ---
 ```
 - Fixes incorrect status buff on blackmetal bow
 ```

**1.22.2**
 ---
 ```
 - Updated Chinese and Traditional Chinese translations
 - Added missing sounds to the blood-bone pickaxe on-hit effects list
 - Prevent error on blood hybrid weapons due to the local player not existing
 ```

**1.22.1**
 ---
 ```
 - Fix for transparent shader issue on Eikythr weapons
 ```

**1.22.0**
 ---
 ```
 - Updated default Chinese translation (delete your old translation in the config folder if you want the new defaults))
 - Adds a Blackmetal bow
 - Increased default deflect force for mod tower shields
 - Fixes a rare error on shutdown when some items would try to revert to their original state as the game is exiting
 - Improved the mounting rotation for the serpent scale buckler
 - Readded missing config for movement speed penalty on some Greataxes
 - Added missing spear throwing sounds for blackmetal and moder spear
 - Fixesx20 multiplier for the goblin kinds knuckles
 - Updated Flametal Knives with customized models based on the evolution chosen
 ```

**1.21.2**
 ---
 ```
 - Shader fix for macOS users for Queen and Vine weapons, and Bolts
 - Shader compatibility improvement for Sky Shatterer
 - Rework of Moders tower shield, potential future changes still planned.
 ```

**1.21.1**
 ---
 ```
 - Particle effect fixes for the spirit staff explosion
 - Grip improvements for all staves
 ```

**1.21.0**
 ---
 ```
 - Many of the model updates are a contribution from @chaseowski, thank you!
 - Added some new Moder weapons and retextured many of the existing moder weapons, more in progress!
    - Added Moders dual knives
    - Updated Moders 1H knife, 1H sword, 2H sword and spear
 - Updated flint weapon models, and textures!
 - Updated many of the english translation default descriptions and names
    - Translation changes will not override existing translations, delete your old translations (BepInEx/config/ValheimArmory/localizations/English.json) if you want the new defaults
 - Shader fixes for particle effects of the poison/spirit staves and arrow trails
 - Fixed flametal 1H axes being very hard to pickup and floating in the air after dropped
 - Removed included VES and EpicLoot configs, these are now available in discord
 ```

**1.20.0**
 ---
 ```
 - Full MacOS support!! Shaders are all now compatible with MacOS
 - All Ashland level weapons now match vanilla shaders
 - Added a blackmetal spear
 - Improved how items are loaded, and configuration is sychronized
    - Server impact from loading the mod is now reduced by ~98%
    - Removed a pattern that could cause lagspikes with new users connect
 - Adds a config folder for ValheimArmory that directly exposes all translations
    - Bepinex/Config/ValheimArmory/localizations
    - All files in here can be edited as you see fit to change localization of the mod
    - New items will automatically be added to existing localizations
    - I still accept community translations! If you want to help improve a translation feel free to submit a PR, open a ticket or just let me know!
- Balance Changes
    - Reduced the default damage of most of the Elders weapons
 ```

**1.19.2**
 ---
 ```
 - Updates limit values for most attacks, blocks, and costs
 - Updated default block values for 2H Jotun axe, 2H flametal axes
 - Fixed stagger, force applied, and damage for the 1H axes
 ```

**1.19.1**
 ---
 ```
 - Updated localizations for the axe update
 - Fixed default recipe for Flametal 1H blood axe (reset or delete your config if needed)
 - Fixes for 1H flametal axes having issues when being removed from itemstands
 ```

**1.19.0**
 ---
 ```
 - Tweaks to the elemental shader to bring it closer to vanilla
 - Added Flametal greataxe and 1H axe
 - Added Flametal primal greataxe and 1H axe
 - Added Flametal lightning greataxe and 1H axe
 - Added Flametal blood greataxe and 1H axe
 - Added single blade variant of the Jotun axe
 - Updated Ukranain translation
 - Fixed config files not being regenerated on startup
 - Fixes crystal axe high attachment point
 ```

**1.18.5**
 ---
 ```
 - Fixed Asset bundle updates not being applied
 - Reduced debug logging options
 - Optimized startup slightly
 ```

**1.18.4**
 ---
 ```
 - Fixed tool tier for the blackmetal dual axes being incorrect
 ```

**1.18.3**
 ---
 ```
 - Fixed auto-pickup for the flametal sledge
 - Brightened up the copper greataxe blade
 - Slight startup optimizations
 - Updated Russian translation
 - Increased damage for 2h Axes secondary attack, slightly decreased stagger damage
 - Increased default block values for the 2h axes (delete your config if you want to use the new defaults)
 ```

**1.18.2**
 ---
 ```
 - Optimized startup slightly
 - Fixed the default damage for the dual blackmetal knives incorrectly having spirit damage
 - Fixed tool tier for the blackmetal dual axes being incorrect
 ```

**1.18.1**
 ---
 ```
 - Fixed Jotun dual axes not being the correct tool level
 - Fixed Jotun dual axes not having poison damage or configuration for poison damage
 ```

**1.18.0**
 ---
 ```
 - Added Silver tier axe and dualaxe
 - Added blackmetal dual axes and a new 2H blackmetal axe
 - Added dual mistlands axes and a new 2H axe
 - Added configuration to remove the primary attack from all mod-added hammers
 - Fixed damage modifiers not being applied
 - Updated all applied damage modifiers to support immunity,veryweak,weak,normal,resistant,veryresistant and runtime configuration
 - Defaulted Herkirs wrath to disabled crafting
 ```

**1.17.2**
 ---
 ```
 - Fixes recipe modification failures for non-modifiable field values
 - Increased block armor for flametal weapons added by this mod
 - Increased attack force for Ashlands sledges
 - Reduced block force and made it configurable for dual axes
 - Updated transaltions for dualaxes
 - Updated some Russian and German translations
 ```

**1.17.1**
 ---
 ```
 - Updated flint axe default slash to 25->30
 - Updated default movespeed penalty for the dualaxes -20% -> -5%
 - Reduced dmg of iron dual axes 65->60
 - Reduced dmg of bronze dual axes 45->40
 - Increased recipe cost for all dual axes
 - Fixed collider for the bronze sledge
 - Added readme docs for current dualaxes
 - Slightly optimized item startup modifications, faster load speeds
 - Updated Polish translation
 ```


 **1.17.0**
 ---
 ```
 - Bog witch update! Jotunn 2.21.2 is required and enforced.
 - Adds an optional conversion for the Abyssal knife which replaces its slash damage with blunt damage
 - Adds configuration to allow tuning the damage provided by the Abyssal knife blunt conversion
 - Removed incorrect spirit damage on moders greatsword
 --- Many configuration defaults were adjusted, they are all adjustable and will not override existing configuration! ---
 - Antler bow: reduced base pierce damage to 26, reduced per level lightning to +1, per level pierce to +2
 - Blackmetal Greatsword: Reduced knockback to 55, increased block to 52, increased stamina cost to 18(+1)/36(+2), added forge level 4 as a requirement
 - Abyssal Sword: Workbench lvl 2 as a requirement
 - Antler sword: base slash reduced to 16, base blunt reduced to 8, base lightning reduced to 6, crafting station lvl 2 as a requirement
 - Vine sword: workbench lvl 2 as a requirment
 - Ice sword: forge lvl 4 requirement, frost per level reduced to +1
 - Moders greatsword: frost per level reduced to +1, attack force increased to 55, block increased to 48, forge lvl 4 requirement
 - Bronze greatsword: block reduced to 16, recipe requires corewood instead of wood
 - Iron greatsword: forge level 2 requirement
 - Silver greatsword: forge level 3 requirement
 - Bonemass greatsword: block increased to 36, attack stamina costs increased to 15 & 30, require lvl 3 forge
 - Yagluth greatsword: fire per level reduced to +1, requires lvl 4 forge
 - Bronze battleaxe: reduced chop to 30, reduced chop per level to 2.5, increased slash per level to 6
 - Antler battleaxe: slash increased to 25, reduced blunt per level to 2, chop reduced to 30, chop per level reduced to 2.5, crafting station lvl 2 required
 - Blackmetal battleaxe: chop decreased to 60, chop per level decreased to 2.5, block increased to 52
 - Flint atgeir: base durability decreased to 125
 - Antler atgeir: pierce per level reduced to 5, lightning per level reduced to +1
 - Abyssal atgeir: requires crafting bench lvl 2
 - Silver atgeir: increased base pierce by 10, increased block to 40, requires forge lvl 3
 - Yagluth atgeir: pierce per level reduced to +3, fire per level reduced to +3, require forge lvl 4
 - Serpent scaled buckler: require forge lvl 3
 - Elder roundshield: require forge lvl 2
 - Moders roundshield: requires forge lvl 4
 - Moders towershield: requires forge lvl 4
 - Wolf silver towershield: requires forge lvl 3
 - 2H blackmetal daggers: requires forge lvl 4
 - Antler 1H dagger: slash reduced to 8, pierce reduced to 8, lighting reduced to 4, lighting per level reduced to +1, requires workbench lvl 2
 - Iron 2H daggers: requires forge lvl 2
 - Iron 1H dagger: requires forge lvl 2
 - Silver 2H daggers: requires forge lvl 3
 - Moders Dagger: requires forge lvl 4
 - Bonemass dagger: requires forge lvl 3
 - Moders spear: requires forge lvl 4
 - Iron fists: requires forge lvl 2
 - Yagluth fists: requires forge lvl 4
 - Elders mace: requires forge lvl 2
 ```

 **1.16.5**
 ---
 ```
 - Updated default damage for the bronze sledge
 - Removed spirit damage from the flametal dual knives
 - Removed incorrect fire damage from the flametal atgeir base
 - Updates a few missing translations for spanish, and german
 ```

 **1.16.4**
 ---
 ```
 - Asset bundle update
 ```

 **1.16.3**
 ---
 ```
 - Updated default stamina and block values for 2H knives that had inconsistent values (blackmetal and meteor)
 - Updated some weapons tool tiers to better match their biomes
 - Updated Japanese translation
 ```

 **1.16.2**
 ---
 ```
 - Fixes for Vanilla hammer modification
 - Configuration for how much stamina vanilla hammers will use on the primary attack
 - Enabled hot-reloading for vanilla stamina weapon cost changes
 ```

 **1.16.1**
 ---
 ```
 - Fixed the flint greataxe acquiring lightning damage on levelup
 - Added translations for all of the recently added weapons
 - Fixed the package icon -_-
 ```


 **1.16.0**
---
```
- Added Moders greatsword
- Added Bronze sledge
- Reduced dust on the blackmetal sledge
- Add optional configuration which enables a primary attack for vanilla sledge hammers and moves the slam to a secondary attack
- Fixes a visual bug with the blood-bone pickaxe
- Asset compression optimizations
- Fixed Flametal atgeirs almost all having extra fire damage
- Added lightning damage to the electric Flametal atgeir
- Enables configuring bow & crossbow stamina drain
- Enables configuring crossbow & bow projectile velocity
- Retexture & remesh Skyshatter
- Added Flametal hammers
```

 **1.15.2**
---
```
- Updated Japanese translation
- Updated Russian translation
- Fixed shader corruption on legacy arrow textures
```

 **1.15.1**
---
```
- Updated Japanese translation
- Updated Russian translation
- Reduced the default lightning damage of Eikythrs bow (per level & base)
```

 **1.15.0**
---
```
- Adds additional sfx to staffs to provide more feedback on cast
- Reduce initial and scaling lightning dmg for eikythrs bow
```

 **1.14.3**
---
```
- ~24% asset size reduction
    - Reduces high rez textures
    - Some model compression and optimizations
    - vfx optimizations
- Fixes blackmetal knives not orienting the right way when unequipped
```

 **1.14.2**
---
```
- Fixes live updates to items that are not currently spawned
- Fixes live updates for some cloned cases that were not covered
- Fixes live updates for items amount
- Fixes live updates for Crafting station validation
```

 **1.14.1**
---
```
- Fixed duplicate lightning atgeir warning
- Updated texture for the bronze crossbow
- Updated texture for Moders crossbow
```

 **1.14.0**
---
```
- Updated model and texture for Ashlands atgeir
- Added variants for Ashlands atgeir
- Fixed character holding location for copper knives
- Fixed flint knives reading the blackmetal knives config
- Removed nature effects from lightning knives
```

 **1.13.0**
---
```
- All daggers have been renamed to knives. Daggers were originally implemented when vanilla game knives had one damage type
  over time vanilla daggers have been upgraded to have two damage types and that made the various daggers redundant
- Updated model and textures for iron knives
- Added a mistlands level 1H knife
- Updated model and textures for the Ashlands flametal knife 1H
- Added elemental variants for the Ashlands flametal knife 1H
- Updated the model and textures for flint 2h knives
- Added Copper 2H knives
- Removed the bronze knives
- Removed the bronze 2H knives
- Updated model and texture of the Iron 2H knives
- Updated the model and texture and of Silver 2H knives
- Added blackmetal 2H knives
- Updated flametal 2h knives model and texture
- Added elemental variants for the Ashlands flametal 2H knife
- Removed Abenaki translation
- Fixed autopickup for the flint greatsword
```

 **1.12.0**
---
```
- Added the carapace blood bow
- Retextured the bronze greatsword
- Retextured the iron greatsword
- Retextured the silver greatsword
- Added the blackmetal greatsword
- Updated druidic ice staff sfx
- Increased animation speed most of the staff animations
- Updated the default spirit staff recipe to require Dverger trophies as an initial crafting cost
- Added a basic fire bolt for the crossbow
- Improved mounting and grip for Yagluths greatsword
- Improved mounting for silver tower shield
```

 **1.11.4**
---
```
- Fixed default recipe for Elder crossbow to require corewood not stone
- Fixed auto-pickup not enabled for queens weapons
- Retextured Bronze Axe
- Changed poison staff projectile explosion vfx
```

 **1.11.3**
---
```
- Converted the blood bone bow to use bowskill for damage calc
- Converted the bloond bone pickaxe to use pickaxe for damage calc
- Added a patch to increase skills for blood hybrid weapons outside of their primary skill
- Reduced visual dust from skyshatter by 50%
- Fixed the default recipe for the bronze arbalest to be plains level
```

 **1.11.2**
---
```
- Fixed Eikythrs sword & skyshatter not auto-picking up
- Added Spirit damage to the blood bone bow
- Added Spirit damage to the bloody pickaxe
- Reduced strictness of version checking for players of un-modded servers
- Fixed needle bolt default recipe
```

 **1.11.1**
---
```
- Exposed durability and durability per level for all weapons/shields
- Fixed internal version to match
```

 **1.11.0**
---
```
- Added the needle bolt
- Reduced size of a number of icons to better match vanilla (more will be done in the future)
- Fixed the grip location on Moders spear
```


 **1.10.1**
---
```
- Fixed autopickup for the flint sword
- Fixed crash related to setting an invalid recipe
- Added more safety checks to recipe parsing
```

 **1.10.0**
---
```
- Improved recipe and item mutations for servers and clients that do not run the same configurations
- Enabled FULL recipe hot reloading, editing recipe configs now reflects in-game actively.
- Added more safety checks to active recipe reloader
- Added more safety checks to active item hotreloader
- Added more safety checks to backpack item mutator
- Added more safety checks for prefab validation of recipes
```

 **1.9.3**
---
```
- Upgraded backing scripts for Ashlands
- Fixed silver tower shields movement penalty being 100x higher than it should be
- Updated the localization for some of the elemental arrows and bolts to be less material specific
- Added more safety fallbacks when a recipe is configured to be invalid
- Added the option to configure blunt damage for fist type weapons
- Added rarity drop chance patch for Epic loot to ensure that chance to roll VA items does not overpower other drops
- Improved Epic loot patches to include recent new weapons
- Fixed missing readme section for 2h ashlands daggers
- Added parry multipler configuration to all shields that use the value. Default existing shields to more normalized parry multiplers (1.5x vs 3.0x)
- Fixed silver hammer, silver shield, moder tower shield, meteor dagger, meteor_2h dagger, meteor atgeir falling through the floor
- Improvements and fixes for hot-reloading recipes and validation of recipes
```

 **1.9.2**
---
```
- Adjusted all boss weapon recipes after Eikthyr to not require additional boss kills for upgrades
- Adjusted early game 2H axes tool teir (damage to trees)

- Fixed the default recipe for Ashlands weapons to use FlametalNew not Flametal
- Fixed silver sledge recipe to use Fenring Trophies and Corewood instead of bonemass materials

- Servers can now enforce removal of items from the configuration (servers adding items at runtime vs the client config is still not supported)
```

  **1.9.1**
---
```
- Bugfix bow draw speed configuration not being applied correctly
- Changed how speed modifiers, drawspeed, and reloadtime are applied
- Updated boxed configuration value ranges for these values to represent the change
- Reduced excess logging, extra logging can be enabled with the client side debug logging config
```

  **1.9.0**
---
```
Added
- Silver tower shield
- Silver sledgehammer
- Ashlands Atgeir
- Ashlands Dagger
- New model for Moders shield

New features
- Hot reloaded configuration!
- All weapon stats are hot-reloaded when changed from the config
- Weapon stats AND recipes will be loaded from the server when a client connects
- Recipes changes require logging out from the world to be fully reloaded.

Balance
- Reduced stamina cost for a few sledge hammers AOE attack slightly
- Added blunt to the druidic ice staff
- Reduced default parry multiplier for moder's shield, now 2x and configurable

Updated to Jotun 2.20.0 (Ashlands)
```

  **1.8.0**
---
```
Adds
- Corewood crossbow bolt, normal wood crossbow bolt now costs wood.
- Moders 1H dagger

New configuration
- Movement speed penalty (adjustable for 2H hammers)
- Crafting table level required (adjustable for all)

Fixes
- Animation grip for Vine sledge
- Animation grip for Queens 1H sword
- Animation grip for moders 1H sword
- Animation grip for 1h silver daggers
- reduced VFX for blackmetal axe darkness
- Improved grip of flint fists
- Improved VFX for queens weapons

BALANCE CONFIGURATION APPLIES TO NEW CONFIG FILES
existing configurations will not be significantly adjusted

Changes
    Arrows
    - Blackmetal Arrow: Updated recipe, converted damage to primarily be blunt
    - Bone Arrow: Increased damage, normalized feather cost, requires crafting station lvl3
    - Surtling fire Arrow: moved to workbench, reduced damage slightly, reduced crafting costs
    - Ancient wood Arrow: reduced damage
    - Chitin Arrow: removed slash damage, added blunt damage, reduced overall cost and damage
    - Wood bolt: reduced damage, changed recipe to cost wood not corewood
    - Bronze bolt: small damage reduction, recipe cost reduction
    - Poison bolt: damage reduction, cost reduction
    - Obsidian bolt: now made at the workbench, tiny damage reduction
    - Frost bolt: large cost reduction, tiny damage reduction
    - Surtling fire bolt: cost reduction, damage reduction
    Bows
    - Bone Blood bow: small damage reduction, recipe cost reduction
    - Antler bow: moved to workbench, significant cost reduction, small increase in damage
    - bronze crossbow: damage increase, durability decrease, recipe cost adjusted
    - Elder crossbow: recipe cost reduction, damage increase, durability decrease
    - Moder crossbow: massive damage increase, slight recipe cost increase, durability decreased
    - Queen bow: damage spread between lightning and poison, lightning VFX added, recipe adjusted
    Swords
    - Chitin sword: moved to workbench, small damage decrease, recipe cost increased
    - Antler sword: moved to workbench, damage per level increased, recipe cost decreased
    - Vine sword: recipe cost decreased, damage decreased
    - Moder sword: recipe cost increased, damage decreased, damage moved to pierce from blunt
    - Bronze greatsword: recipe cost decreased, damage slightly decreased
    - Silver greatsword: recipe cost slightly increased, damage increased
    - Bonemass greatsword: recipe cost increased, slash damage increased, poison decreased
    - Yagluth greatsword: recipe cost decreased, damage slightly decrease, damage per level increased
    - Flint sword: damage decreased slightly, increased damage per level, recipe cost significantly reduced
    - Flint greatsword: damage decreased slightly, massive recipe cost decrease
    - Queen greatsword: damage spread out between poison and lightning, stamina costs slightly increased, recipe adjusted
    - Queen sword: damage spread out between poison and lightning, stamina costs lowered, recipe adjusted
    Axes
    - Flint greataxe: damage slightly decreased, recipe cost massively decreased, tree damage massively increased, stamina costs increased
    - Bronze greataxe: damage slightly decreased, tree damage decreased, recipe cost decreased
    - Antler greataxe: moved to workbench, damage decreased, tree damage increased, recipe costs massively decreased
    - Blackmetal greataxe: damage decreased, recipe costs increased, tree damage reduced, secondary stamina cost increased
    Hammers
    - Blackmetal sledge: damage increased, recipe cost increased, movement speed penalty increased
    - Elder sledge: damage increased, recipe cost increased, movement speed penalty increased
    - Bonemass warhammer: damage decreased, recipe cost increased, movement speed penalty increased
    Atgeirs
    - Flint atgeir: damage increase, stamina cost increase, recipe cost massively decreased
    - Antler atgeir: damage increase, recipe cost decrease, stamina cost increase
    - Chitin atgeir: (renamed from royal to chitin atgeir) spirit damage removed, recipe cost massively reduced, VFX removed, damage reduced
    - Silver atgeir: damage slightly shifted to spirit, recipe cost reduced, stamina cost increased
    - Yagluth atgeir: fire damage per level increased, recipe cost massively reduced
    Shields
    - serpentscale shield: deflection increased, recipe cost decreased, resists pierce
    - elder roundshield: cost decreased, block decreased, very resistant to blunt, removed special player resistances
    - moder roundshield: cost increased, block massively decreased, very resistant to frost, removed special player resistances
    Daggers/knives
    - flint 2h daggers: recipe cost massively decreased, damage slightly increased, stamina cost adjusted
    - antler dagger: recipe cost reduced, damage slightly reduced
    - bronze 2h dagger: recipe cost reduced, damage increased, stamina cost decreased
    - bronze 1h dagger: recipe cost reduced, damage increased
    - iron 2h dagger: recipe cost increased, damage reduced
    - iron 1h dagger: recipe cost increased, damage increased, stamina cost increased
    - silver 2H daggers: recipe cost increased, damage massively increased
    - silver 1h daggers: default uncraftable, damage heavily increased, removed spirit damage, recipe cost increased
    - moder 1h daggers: added, frost damage
    - bonemass dagger: damage decrease, crafting cost decrease, stamina cost increase
    - queens dagger: damage spread between poison and lightning, recipe adjusted
    Spears
    - moder spear: damage adjusted, replaced blunt damage with slash, recipe cost decreased
    Fists
    - flint fists: damage decrease, recipe cost massively reduced
    - bronze fists: damage decrease, recipe costs reduced
    - iron fists: damage decrease, recipe costs reduced
    - yagluth fists: damage decreased, recipe costs massively reduced
    Maces
    - elders mace: damage decreased, weapon costs reduced, stamina costs decreased
    Magic staves
    - poison: decreased recipe costs, large damage increase
    - spirit: decreased recipe costs, large damage increase
    - druidic poison: damage increase, durability decrease, stamina cost increase
    - druidic spirit: massive damage increase, durability decrease, stamina cost increase, recipe now swamp level
    - druidic ice: small damage decrease, durability decrease, recipe cost decrease
    - druidic fire: recipe changed to swamp level, damage increase, durability reduced
    Pickaxe
    - Bone blood pick: no change
```


  **1.7.5**
---
```
- Updated Jotunn for compatability with upcoming Ashlands (2.19.1)
- Updated russian translation
- Reduced size of VFX for the queens weapons
```

  **1.7.4**
---
```
- Fixes Obsidian bolts not moving after being shot
```

  **1.7.3**
---
```
- Weapons now have a 1%-300% configuration option for bow draw duration and crossbow reload duration where applicable
- Updated VES configuration to include all current weapons
- Updated German weapon translation | Thanks Sack3000!
- Reduced the minimum configurable Eitr cost for mistlands level staves to be zero (they can now be used as stamina or no-cost)
```

**1.7.2**
---
```
- Added configuration options to enable stamina cost for non-druidic spirit and poison staffs
- Added rough language translations for all 26 localizations (I still welcome translation improvements!)
- Fixed some shields not being auto-picked up properly
- Fixed some arrows not being auto-picked up properly
- Added unique projectiles for all of the bolts/arrows. This improves compatability with Bow Plugin.
- Added blood magic weapons
    - Blood bone bow, does not cost arrows uses blood for ammo
    - Blood battlepick, very low stamina cost, health cost, increases health regen when wielded. Can mine terrain.
```

**1.7.1**
---
```
- Removed frost damage from the queens sword
- Added Language translations for all remaining untranslated items
    - These translations are generated and are not guarented to be accurate, I still greatly appreciate anyone willing to improve language translations
- Improved Korean language translation (Thanks! 이종윤)
```

**1.7.0**
---
```
- Added Initial Mistland Boss Weapons!
    - Queens Sword, Greatsword, Bow and Dagger
- Improved some balance for Flint weapons
- Optimized more textures, vfx and various other resources (reduced download and memory footprint)
```

**1.6.5**
---
```
- Tune default damage for the obsidian bolt to be lower than blackmetal
- Improved network compatibility for some magic weapons, crossbow bolts and arrows
```

**1.6.4**
---
```
- Updated readme for arrows to be a bit more accurate
- Converted the shkyshatter & elders hammer to warhammers (2H mace + sledge attacks)
```

**1.6.3**
---
```
- Fixes obsidian bolts not colliding with the ground when dropped
```

**1.6.2**
---
```
- Fixes bonemass warhammer smash aoe damage not being spread across the whole radius
```

**1.6.1**
---
```
- Fixed the antler atgeir & flint atgeir having both slash & pierce
- Removed minor resistances from the vine shield
- Added a groundsmash secondary attack for bonemasses warhammer
- Reduced default stamina cost of the primary attack for bonemasses warhammer, and sped it up slightly
- Updated Yagluths fists to have a jump secondary attack
- Remade the abyssal atgiers skin and vfx, now much softer, less shiny
- Added an obsidian bolt for crossbows
- Tuned default damage for the abyssal atgeir to be more in line with other atgeirs (and to upgrade linearly)
```

**1.6.0**
---
```
- Remodelled the skyshatter, updated its VFX! less foggy more soft electric
- Redesigned the elders shield
    - Updated the spirit & poison resistances the shield provides to be major resistances instead of minor ones (holding the shield is now effectively a free poison resist, just don't stash/unequip or you'll have a bad time)
- Added Moders shield
    - Moders shield now provides frost (major) and fire (minor) resistances
- Added Fist weapons (knuckles): Flint, Bronze, Iron, and blackmetal (boss weapon)
- Added Magic staffs! Poison, Spirit, Fire, Ice 
    - these new magic staffs are split into two catagories: pre mistlands and mistlands level and they work slightly differently
    - pre-mistlands staffs have a high stamina cost but no Eitr cost
    - mistland level staffs are stronger, have a low eitr cost and no stamina cost
    - this is all completely configurable if you want them to work differently
- Fixes for some flint weapons not colliding properly with things when dropped
```

**1.5.17**
---
```
- Fixed the default recipe for iron poisoned crossbow bolts to use iron
- Added Flint weapon set (Atgeir, Sword, 2H dagger, Greatsword)
- Added prefab names to readme
```

**1.5.16**
---
```
- Fixed missing shader compilation for Vulkan
```

**1.5.15**
---
```
- Fixed Moders spear missing its trail texture when thrown
- Reduced specular highlights on Moders & Elders weapons, increased darkness of vine textures
- Fixed naming of the elders sledge
```

**1.5.14**
---
```
- Fixed missing weapon trails on a handful of weapons
- Fixed high levels of metallic rendering used on the elders weapons
```

**1.5.13**
---
```
- Fixed autopickup for a few more weapons, really this should be the last time
- Fixed the antler bow getting a NPE when firing
```

**1.5.12**
---
```
- !!CHANGED CONFIG LOCATION!! now MidnightsFX.ValheimArmory.cfg
- Added support for weapons/shields to provide resistances
- Set the Elders shield to provide a poison resistance (and config options to enable/disable)
- Fixed autopickup for a few remaining weapons
- Updated compiled against unity version to 2022.12
- Increased compression of files (download is 25% smaller now)
```

**1.5.11**
---
```
- Fixed auto-pickup for a number of weapons (including dragonfrost spear), it should now work correctly.
```

**1.5.10**
---
```
- Updated english name localization, improving weapon naming to feel more vanilla
```

**1.5.9
---
```
- Fixing missing Epic Loot config files on Thunderstore
- Fixed Elders hammer not having one of its sound effects
- Fixed Elders balance incorrectly having lightning damage and blunt damage instead of just slash and spirit
```

**1.5.8**
---
```
- Fixing arrow text description for arrows including a non-printable control character
- Improving flexibility of crafting station configuration options for all craftable weapons/ammos
```

**1.5.7**
---
```
- Default configuration for Valheim Enchantment System (VES) and Epic Loot now available in the mod folder
- Added Elders sword & mace
- Fixed prefab name for Chitin Atgeir
```

**1.5.6**
---
```
-Fixes for the Elder Hammer & Skyshatter not having sfx hit sounds
```

**1.5.5**
---
```
- Fixes for the spanish translation
- Updates to required version of Jotunn & BepinEx
```

**1.5.4**
---
```
- Added Spanish Translation
- Fixed missing sound effects for Elders hammer
```

**1.5.3**
---
```
- Fixed Chinese Translation not loading properly
```

**1.5.2**
---
```
- Added Chinese translation
```

**1.5.1**
---
```
- Hildirs Update support validated!
- Updated to Jotunn 2.12.7
- Added the option to enable/disable craftable state for all items. This is seperate from enabling the item itself, you can now enable the item to be loaded into the game. 
    But keep it non-craftable, this might be useful if you only want a specific weapon to drop from Epicloot etc.
```

**1.5.0**
---
```
- Added two Yagluth themed weapons
- Added configuration for block to all weapons and shields
- Updated Jotunn to 2.12.4
```

**1.4.0**
---
```
- Added initial bonemass boss weapons!
- First 2H warhammer added, likely slightly overpowered. This weapon acts like a 2H axe or sword, but does blunt damage.
- Added silver Atgeir, this is a direct upgrade between Iron & Blackmetal
- Updates to how localizations are added, better support for multiple languages
- Added Russian translation
```

**1.3.4**
---
```
- Fixed Moders crossbow not being configurable and using the wrong defaults
```

**1.3.3**
---
```
- Fixed wood bolt triggering the invalid recipe warning
- Fixed a particle mock for arrow feathers not resolving on some versions of valheim
- Rebalance of most boss weapons, and a few outlier non-boss weapons. Recipes are slightly more expensive overall and damage is generall down across the board.
    This primarily brings boss weapons in line with the next tier weapon minus a small bit. The balance change is just to the default config values.
    If you want to keep your weapons more powerful continue using your existing config, defaults will only be applied if you do not have a value set (new or deleted config).
```

**1.3.2**
---
```
- Updated German localization
```

**1.3.1**
---
```
- Fixed the antler greataxe being held the wrong way
```

**1.3.0**
---
```
- 3 new weapons based on the Elder
- 3 new weapons based on the Moder
- new crossbow and a handful of new bolts!
- bugfix for the antler dagger not being impacted by gravity
- fixed the default recipe for 1h bronze dagger

```

**1.2.1**
---
```
- Finished current german localization
- Updated the surtling core arrow icon

```

**1.2.0**
---
```
- Added Eikthyr Bow, Dagger, Sword & Greataxe
- Remeshed the Antler Atgeir
- Balance for the Eikthyr weapons is tilted towards overpowered.

```

**1.1.0**
---
```
- Added Daggers
- Added 2H Daggers

- Significant updates to the configuration code, more things are now configurable!
    - Stamina cost for primary and secondary attacks
    - Crafting costs
    - Where things are crafted at
```

**1.0.1**
---
```
- Fixed Iron level sword recipe, should now actually require Iron.
```

**1.0.0**
---
```
- Release! I'm sure its got bugs somewhere
```