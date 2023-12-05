# Attaching Weapons & Armor

There are two primary ways to attach weapons and armor in Valheim, the use of an _attach_ empty in unity (described below) and _attach_skin_ which allows attachment for more complex objects and multiple attachment points.

## Table of Contents
1. [Simple Attach](#simple_attach)
2. [Skinned Mesh usage](#skinned_mesh_usage)
    1. [Setup](#skinned_mesh_setup)
    2. [Rigging and Adjusting](#skinned_mesh_rigging_and_adjusting)
    3. [Exporting to .fbx](#skinned_mesh_export_to_fbx)

## Simple attach <a name="simple_attach"></a>

If you are here looking to attach a new simple shield, or weapon to your character you should likely use an _attach_ object. This pattern can be seen throughout the Valheim codebase from a ripped unity project. The game determines where to attach your object based on the item type in the item drop script.
<details>
  <summary>Example Simple Attach</summary>

![simple_attach_usage](https://i.imgur.com/A7Q5bVI.png)

</details>

This simple attach requires an empty object called _attach_ with your desired mesh as a child. It is also suggested you ensure that colliders are included here so that your mesh will interact with the world.

For more complex weapons or armor you will need to use a skinned mesh through _attach_skin_. Which is described in detail below.

## Skinned Mesh usage <a name="skinned_mesh_usage"></a>
Skinned Meshes allow rigging your mesh to the character avatar. This gives you a much finer grain level of control for attaching your items to the character, but requires a bit of work up front.

### Setup <a name="skinned_mesh_setup"></a>


1. Build a basic rig from [this video](https://youtu.be/49UwGWslQeY) (Thanks Hugo!)
    - Ensure proper bone reordering
    - Do not delete any attachment spots you intend to use at some point for armor/weapons
    - Hide all attachment spots you intend to use
    - Save this setup in blender
    - You can add empties (the plain objects here) by being in object mode -> Add -> Empty -> Plain Axis
<details>
  <summary>Adding Empties in Blender</summary>

![simple_attach_usage](https://i.imgur.com/E971932.png)

</details>

2. Build the weapon or armor you want to use (you probably already have this if you are here!)

### Rigging and Adjusting <a name="skinned_mesh_rigging_and_adjusting"></a>
1. With your basic rig, import your weapon or armor that you want to use
    - Organizing your objects like below will make export and usage much easier 

        ![blender_rig_overview](https://i.imgur.com/RMr49pQ.png)
    - Note that the bodies are kept in this rig but are hidden from view, this is to allow easy alignment for the model hands or body parts when attaching your object

2. Setup a **Child Of Constraint** between your attachable object and its target location. In the above example "weapon_left" has a constraint with the _LeftHand_Attach_ object. Notice that scale is not inherited for the child constraint in this case. This will allow you to scale your weapon/armor as you normally would see fit.

    ![child_of_constraint](https://i.imgur.com/dGQW0SQ.png)

    If your weapon/armor does not snap to the attachment point after setting this modifier click "set inverse" then "clear inverse", your item should now have snapped to the attachment point.

3. Setting up the armature modifier
    * In order to setup an armature constraint which will transfer kinetics to your attached piece you will first need to create a vertext group with all pieces of the model selected. If you have multiple models or models attached to different parts, each attachment area will need its own vertext group. Vertext groups should use the same name (and casing) as their target bone attachment. All bones are listed in the Armature, in the example we are attaching a weapon so we are attaching to the _LeftHand_. Vertext groups are found on object properties by selecting the parent empty or directly selecting the mesh.

        ![vertext_group_example](https://i.imgur.com/nKH2Hz4.png)
    
    * With the vertext group in place you simple need to apply an **armature modifier** and tell it to bind to the vertex groups

        ![armature_modifier](https://i.imgur.com/YEqLnTU.png)


4. (Optional) Adjust your model placement by unhiding the body and BodyFem to determine fit

### Exporting to .fbx <a name="skinned_mesh_export_to_fbx"></a>

There are a number of important things to take note of when exporting.
* Ensure leaf bones are not added
* Only export selected objects

    ![export_settings](https://i.imgur.com/7HLKDvB.png)

When you are ready to export hide the body and bodyFem, and select all objects by right clicking on the scene collection and hitting "select objects".

<details>
  <summary>Select Objects</summary>

![select_objects_menu](https://i.imgur.com/vFiWFDq.png)

Once all objects are selected, your hierarchy should look like this.

![select_objects_menu](https://i.imgur.com/UwCwkYV.png)

</details>



Now proceed to export. You should get an .fbx attach_skin containing the armature and your rigged items.

Unpack this completely to make changes to it in unity and add it to your item. This can be used in conjunction with standard _attach_ eg: 

![added_to_game_object](https://i.imgur.com/54ApN9J.png)

Notes:
* Using Child of and mirroring the size of the parent object will not prevent you from scaling the weapons themselves- and will put the selected object exactly on the attachment point (but likely won't be the right rotation etc), you can still resize the object & rotate/move it etc as needed.
* If you are adding a particle system in unity to a skinned mesh system, you will need to set the particle system to use the `skinned mesh renderer` under `shape`
