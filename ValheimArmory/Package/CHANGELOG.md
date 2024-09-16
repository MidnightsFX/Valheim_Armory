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