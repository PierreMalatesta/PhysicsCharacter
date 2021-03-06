using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    public class AIBrain : MonoBehaviour
    {
        //make a timer
        public float timer;


        PlayerStats playerStats;
        Power power;
        EnemyAI enemyAI;


        private void Start()
        {
            timer = 5;
            playerStats = GetComponent<PlayerStats>();
            enemyAI = GetComponent<EnemyAI>();
        }

        private void Update()
        {
            //countdown timer
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                timer = 5;

                Power[] powers = playerStats.powers;

                //randomly choose powers using random.range
                int randomPower = Random.Range(0, powers.Length);

                power = powers[randomPower];

                //if distance between enemy and target is greater than range
                if (Vector3.Distance(transform.position, playerStats.target.transform.position) < power.range)
                {
                    //call apply
                    power.Apply(playerStats, playerStats.target);

                    timer = 5;
                }

                else
                {
                    //otherwise if the player is moving
                    enemyAI.agent.isStopped = false;
                    // and check back in a second
                    //timer = 1; 
                }
            }
        }
    }
}
