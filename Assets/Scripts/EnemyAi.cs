using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    Ragdoll ragdoll;
    public float enemyHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ragdoll = GetComponent<Ragdoll>();
    }

    // Update is called once per frame
    void Update()
    {

        agent.speed = 10;
        agent.angularSpeed = 240;
        agent.acceleration = 32;
        agent.stoppingDistance = 4;

        if (ragdoll.RagdollOn == false)
        {
            agent.SetDestination(player.transform.position);
            agent.isStopped = false;
        }


        else
            agent.isStopped = true;

 
    }
}
