using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Ragdoll ragdoll;

    // Start is called before the first frame update
    void Start()
    {
        ragdoll = GetComponent<Ragdoll>();
    }

    //test 
    public void AttackState()
    {
        ragdoll.RagdollOn = true;
    }
}
