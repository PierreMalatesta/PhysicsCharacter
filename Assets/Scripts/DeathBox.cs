using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG;

public class DeathBox : MonoBehaviour
{
    private Animator animator = null;
    public List<Rigidbody> rigidbodies = new List<Rigidbody>();
    CharacterController cc;

    public bool RagdollOn
    {
        get { return !animator.enabled; }
        set
        {
            animator.enabled = !value;
            cc.enabled = !value;
            foreach (Rigidbody r in rigidbodies)
                r.isKinematic = !value;
        }
    }

    // Use this for initialization 
    void Start()
    {
        rigidbodies.AddRange(GetComponentsInChildren<Rigidbody>());

        foreach (Rigidbody body in rigidbodies)
        {
            RagdollPart part = body.gameObject.AddComponent<RagdollPart>();

        }
        animator = GetComponent<Animator>();
        RagdollOn = false;

        cc = GetComponent<CharacterController>();
    }


}
