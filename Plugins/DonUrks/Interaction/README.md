# Interaction for Unity
A Unity3D package for triggering and handling interactions in player range.

## Features
- Trigger interactions from your code
- Trigger duration
- Raycast interaction range check ("is the door in front of the player?"
- Messages to your components on events like "InteractionComplete"
- UI Component for showing interaction specific icons when in range
- Sample scene with player, door and pickupable

## Install
Download and install the Unity package file or copy the Plugins directory from this repository to your project.

## Sample
Open the Interaction/Sample/SampleScene and press play.

## Components
### Interactable
- Component for the gameobject you want to interact with
- Method call events on every component of the gameobject:
	- OnInteractionFinished(InteractableTrigger interactableTrigger)
	- OnInteractionStarted(InteractableTrigger interactableTrigger)
	- OnInteractionAborted(InteractableTrigger interactableTrigger)

### InteractableTrigger
- Abstract component for triggering the interaction
- Use Trigger() to start the interaction in range
- Use the interactableLayerMask property to config the layers to interact with
- Use the OnInteractableChange property as delegate InteractableChange(Interactable interactable) for callback if the current interactable in range changes (for example: see InteractableHUD)

### InteractableTriggerRaycast
- InteractableTrigger Component for limited length raycast range check
- Use property interactableRayStart for raycast origin
- Use property interactableRayLength for raycast length

### InteractableTriggerColliderOnTrigger
- InteractableTrigger Component for OnTriggerEnter and OnTriggerExit
- Use collider of choice
- Dont forget to set "Is Trigger" flag on collider
- With layeer check

### InteractableHUD
- Component for showing the interaction icon filled by remaining duration timer