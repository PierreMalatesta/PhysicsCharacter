using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBrain : MonoBehaviour
{
    //make a timer
    private float timer;


    PlayerStats playerStats;
    Power power;

    private void Start()
    {
        timer = 5;
        playerStats = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        //countdown timer
        timer-= Time.deltaTime;

        //if timer is less than or equal to 0
        if (timer <= 0)
        {
            Power[] powers = playerStats.powers;

            //randomly choose powers using random.range
            int randomPower = Random.Range(0, powers.Length);

            power = powers[randomPower];

            //call apply
            power.Apply(playerStats, playerStats.target);

            timer = 5;
        }


    }

}
