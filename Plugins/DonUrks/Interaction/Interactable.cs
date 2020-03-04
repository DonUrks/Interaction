using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DonUrks.Interaction
{ 
    public class Interactable : MonoBehaviour
    {
        public float duration = 2.0f;
        public bool destroyGameobject = false;
        public bool destroyInteractableOnFinish = false;
        public Sprite spriteIcon;

        public float InteractTime { get; private set; } = 0;
        public bool Interact { get; private set; } = false;

        private InteractableTrigger interactableTrigger;

        private void Update()
        {
            if (this.Interact)
            {
                this.InteractTime -= Time.deltaTime;
                if (this.InteractTime <= 0)
                {
                    this.Interact = false;
                    this.SendMessage("OnInteractionFinished", interactableTrigger, SendMessageOptions.DontRequireReceiver);
                    if (destroyGameobject)
                    {
                        GameObject.Destroy(this.gameObject);
                    }

                    if(destroyInteractableOnFinish)
                    {
                        Destroy(this);
                    }
                }
            }
        }

        public void StartInteraction(InteractableTrigger interactableTrigger)
        {
            if (!this.Interact)
            {
                this.Interact = true;
                this.InteractTime = this.duration;
                this.interactableTrigger = interactableTrigger;

                this.SendMessage("OnInteractionStarted", interactableTrigger, SendMessageOptions.DontRequireReceiver);
            }
        }

        public void AbortInteraction()
        {
            if (this.Interact)
            {
                this.Interact = false;
                this.SendMessage("OnInteractionAborted", interactableTrigger, SendMessageOptions.DontRequireReceiver);
                this.interactableTrigger = null;
            }
        }
    }
}