using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    public class Projectile : MonoBehaviour
    {
        public float speed = 10;

        // fields for the caster and power
        public GameObject g_Power;
        //public GameObject _caster;

        public Power power;
        public PlayerStats caster;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // move forwards along our forward axis
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            PlayerStats target = other.GetComponentInChildren<PlayerStats>();
            if (target)
            {
                // apply to the target
                power.ApplyToTarget(caster, target);

                // destroy ourselves
                Destroy(gameObject);
            }
        }
    }
}
