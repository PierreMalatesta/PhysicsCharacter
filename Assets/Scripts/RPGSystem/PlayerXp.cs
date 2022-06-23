using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace RPG
{
    public class PlayerXp : MonoBehaviour
    {
        PlayerStats playerStats;

        public static int level;
        public TextMeshProUGUI levelText;

        public static PlayerXp instance;

        //make xp for player
        public float playerXpAmount = 0;
        public bool maxFill = false;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            playerStats = GetComponent<PlayerStats>();
            levelText = FindObjectOfType<TextMeshProUGUI>();

            level = 1;
        }

        private void Update()
        {
            levelText.text = "Level: " + level;
        }

        public void AddXp(float xpGained)
        {
            //if the enemy dies increase the xp by 100 NOTE this is only works if they are targeted
            playerXpAmount += xpGained;

            if (playerXpAmount >= 1000)
            {
                playerXpAmount -= 1000;
                level++;
                maxFill = true;
            }
        }
    }
}
