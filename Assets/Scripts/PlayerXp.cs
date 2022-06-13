using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXp : MonoBehaviour
{
    PlayerStats playerStats;
    XpBar xpBar;

    //make xp for player
    public float playerXpAmount = 0;
    private float xpGained = 100;

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        xpBar = FindObjectOfType<XpBar>();
    }

    private void Update()
    {
        //if the enemy dies increase the xp by 100
        if (playerStats.target.health <= 0)
        {
            playerXpAmount = xpGained;

            //make slider call that value
            xpBar.IncrementProgress(playerXpAmount);
        }
    }
}
