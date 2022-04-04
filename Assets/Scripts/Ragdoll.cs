using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Ragdoll : MonoBehaviour
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
            if (cc != null)
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
            part.ragdoll = this;
        }
        animator = GetComponent<Animator>();
        RagdollOn = false;

        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            RagdollOn = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Box")
            RagdollOn = true;
    }

    public void AttackState()
    {
        if (tag == "Enemy")
            RagdollOn = true;
    }
}