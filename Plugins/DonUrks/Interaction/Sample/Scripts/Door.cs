using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DonUrks.Interaction.Sample
{
    public class Door : MonoBehaviour
    {
        public Transform pivot;

        void OnInteractionFinished(InteractableTrigger interactableTrigger)
        {
            transform.RotateAround(pivot.position, new Vector3(0, 1, 0), 90);
        }
    }
}