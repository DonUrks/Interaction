using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DonUrks.Interaction.Sample
{
    public class Player : MonoBehaviour
    {
        public float translateSpeed;
        public float rotateSpeed;

        public InteractableTrigger interactableTrigger;

        void Update()
        {
            var move = Time.deltaTime * translateSpeed * Input.GetAxis("Vertical");
            transform.Translate(new Vector3(0, 0, move), Space.Self);

            var angle = Time.deltaTime * rotateSpeed * Input.GetAxis("Horizontal");
            transform.Rotate(new Vector3(0, 1, 0), angle);

            if (Input.GetMouseButtonDown(0))
            {
                interactableTrigger.Trigger();
            }
        }
    }
}