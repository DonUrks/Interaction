using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DonUrks.Interaction
{
    public class InteractableHUD : MonoBehaviour
    {
        public InteractableTrigger interactableTrigger;

        public UnityEngine.UI.Image loader;

        private Interactable interactable;

        private void Start()
        {
            this.interactableTrigger.OnInteractableChange += OnInteractableChange;
            this.gameObject.SetActive(false);
        }

        private void OnInteractableChange(Interactable interactable)
        {
            this.interactable = interactable;

            this.loader.fillAmount = 1.0f;
            if (this.interactable)
            { 
                this.loader.sprite = this.interactable.spriteIcon;
                this.gameObject.SetActive(true);
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            if (this.interactable != null && this.interactable.Interact)
            {
                this.loader.fillAmount = (this.interactable.InteractTime / this.interactable.duration);
            }
        }
    }
}