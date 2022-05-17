using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10;

    // fields for the caster and power
    public GameObject _power;
    //public GameObject _caster;

    Power power;
    PlayerStats caster;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move forwards along our forward axis
        _power.transform.position = transform.forward * speed;
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
