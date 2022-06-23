using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    public class RagdollPart : MonoBehaviour
    {
        public Ragdoll ragdoll;

        private void OnCollisionEnter(Collision collision)
        {
            //Test for the corrext tag/layer
            ragdoll.RagdollOn = true;
        }
    }
}
