using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DonUrks.Interaction.Sample
{
    public class Pickupable : MonoBehaviour
    {
        void Update()
        {
            transform.Rotate(new Vector3(0, 1, 0), Time.deltaTime * 100);
        }
    }
}
