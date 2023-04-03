# Rigging & Valheim Skinned mesh

This is intended as a reminder for myself, and hopefully a helpful resource for others!

## Setup
1. Build a basic rig from [this video](https://youtu.be/49UwGWslQeY)
    - Ensure proper bone reordering
    - Do not delete any attachment spots you intend to use at some point for armor/weapons
    - Hide all attachment spots you intend to use
    - Save this setup in blender
    - You can add empties (the plain objects here) by being in object mode -> Add -> Empty -> Plain Axis
2. Build the weapon or armor you want to use

## Rigging and Adjusting
1. With your basic rig, import your weapon or armor that you want to use
    - Organizing your objects like below will make export and usage much easier 

        ![blender_rig_overview](https://i.imgur.com/RMr49pQ.png)
    - Note that the bodies are kept in this rig but are hidden from view, this is to allow easy alignment for the model hands or body parts when attaching your object

2. Setup a **Child Of Constraint** between your attachable object and its target location. In the above example "weapon_left" has a constraint with the _LeftHand_Attach_ object. Notice that scale is not inherited for the child constraint in this case. This will allow you to scale your weapon/armor as you normally would see fit.

    ![child_of_constraint](https://i.imgur.com/dGQW0SQ.png)

3. Setting up the armature modifier
    * In order to setup an armature constraint which will transfer kinetics to your attached piece you will first need to create a vertext group with all pieces of the model selected. If you have multiple models or models attached to different parts, each attachment area will need its own vertext group. Vertext groups should use the same name (and casing) as their target bone attachment. All bones are listed in the Armature, in the example we are attaching a weapon so we are attaching to the _LeftHand_. Vertext groups are found on object properties by selecting the parent empty or directly selecting the mesh.

        ![vertext_group_example](https://i.imgur.com/nKH2Hz4.png)
    
    * With the vertext group in place you simple need to apply an **armature modifier** and tell it to bind to the vertex groups

        ![armature_modifier](https://i.imgur.com/YEqLnTU.png)


4. (Optional) Adjust your model placement by unhiding the body and BodyFem to determine fit

## Exporting to .fbx

There are a number of important things to take note of when exporting.
* Ensure leaf bones are not added
* Only export selected objects

    ![export_settings](https://i.imgur.com/7HLKDvB.png)

When you are ready to export hide the body and bodyFem, and select all objects by right clicking on the scene collection and hitting "select objects". Now proceed to export. You should get an .fbx attach_skin containing the armature and your rigged items.

Unpack this completely to make changes to it in unity and either add the required scripts (znetview, zsync, itemdrop) to get it into the game add the attach_skin to an existing item.