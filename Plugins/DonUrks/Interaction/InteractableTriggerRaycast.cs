using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DonUrks.Interaction
{
    public class InteractableTriggerRaycast : InteractableTrigger
    {
        public Transform interactableRayStart;
        public float interactableRayLength = 1;

        void Update()
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(this.interactableRayStart.position, this.interactableRayStart.forward, out hitInfo, this.interactableRayLength, interactableLayerMask))
            {
                this.CurrentInteractable = hitInfo.collider.transform.GetComponent<Interactable>();
            }
            else
            {
                this.CurrentInteractable = null;
            }
        }

        void OnDrawGizmos()
        {
            if (this.interactableRayStart)
            {
                Gizmos.color = Color.blue;

                Vector3 end = this.interactableRayStart.forward * this.interactableRayLength;
                Gizmos.DrawLine(this.interactableRayStart.position, this.interactableRayStart.position + end);
            }
        }
    }
}