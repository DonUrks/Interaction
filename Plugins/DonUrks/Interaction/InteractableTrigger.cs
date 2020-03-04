using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DonUrks.Interaction
{
    public abstract class InteractableTrigger : MonoBehaviour
    {
        public LayerMask interactableLayerMask;

        public delegate void InteractableChange(Interactable interactable);
        public InteractableChange OnInteractableChange;

        public Interactable CurrentInteractable
        {
            get
            {
                return this._currentInteractable;
            }
            protected set
            {
                if ((value == null && _hasInteractable) || (value != _currentInteractable))
                {
                    _currentInteractable?.AbortInteraction();
                    _currentInteractable = value;
                    _hasInteractable = value != null;
                    OnInteractableChange?.Invoke(value);
                }
            }
        }

        private Interactable _currentInteractable;
        private bool _hasInteractable = false;

        public void Trigger()
        {
            if (CurrentInteractable && CurrentInteractable.enabled)
            {
                CurrentInteractable?.StartInteraction(this);
            }
        }
    }
}