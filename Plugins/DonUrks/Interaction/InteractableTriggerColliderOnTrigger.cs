using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DonUrks.Interaction
{
    public class InteractableTriggerColliderOnTrigger : InteractableTrigger
    {
        private void OnTriggerEnter(Collider other)
        {
            if (((1 << other.gameObject.layer) & interactableLayerMask) != 0)
            {
                var interactable = other.transform.GetComponent<Interactable>();
                if (CurrentInteractable == null && interactable != null)
                {
                    CurrentInteractable = interactable;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (((1 << other.gameObject.layer) & interactableLayerMask) != 0)
            {
                var interactable = other.transform.GetComponent<Interactable>();
                if (CurrentInteractable == interactable)
                {
                    CurrentInteractable = null;
                }
            }
        }
    }
}