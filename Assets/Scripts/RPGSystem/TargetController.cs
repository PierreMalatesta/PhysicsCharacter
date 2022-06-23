using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace RPG
{
    public class TargetController : MonoBehaviour
    {
        Camera cam;
        //the current focused enemy
        EnemyInView target;
        Image image;
        public PlayerStats player;

        bool lockedOn;

        //keeps track of which enemy is the current target
        public int lockedEnemy;

        //List of nearby enemies
        public static List<EnemyInView> nearByEnemies = new List<EnemyInView>();

        public static TargetController instance;

        private void Awake()
        {
            // I am the one and only taregt controller!
            instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            cam = Camera.main;
            image = gameObject.GetComponent<Image>();

            lockedOn = false;
            lockedEnemy = 0;
        }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetKeyDown(KeyCode.F) && !lockedOn)
            {
                if (nearByEnemies.Count >= 1)
                {
                    lockedOn = true;
                    image.enabled = true;

                    //lock on first enemy by default
                    lockedEnemy = 0;
                    target = nearByEnemies[lockedEnemy];
                }
            }
            else if (Input.GetKeyDown(KeyCode.F) && lockedOn || nearByEnemies.Count == 0)
            {
                lockedOn = false;
                image.enabled = false;
                lockedEnemy = 0;
                target = null;
            }

            //press X to switch targets
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (lockedEnemy == nearByEnemies.Count - 1)
                {
                    //if end of list has been reached start over
                    lockedEnemy = 0;
                    target = nearByEnemies[lockedEnemy];

                }
                else
                {
                    //Move to next enemy in list
                    lockedEnemy++;
                    target = nearByEnemies[lockedEnemy];
                }
            }

            if (lockedOn)
            {
                target = nearByEnemies[lockedEnemy];

                //Determine Crosshair location depending on target
                gameObject.transform.position = cam.WorldToScreenPoint(target.transform.position);

                player.target = target.GetComponentInParent<PlayerStats>();

                //rotate crosshair
                //gameObject.transform.Rotate(new Vector3(0, 0, -1));
            }
        }

        //if Ondeath() is true or ragdoll is true then dont lock onto that enemy
        public void TargetDisable(EnemyInView died)
        {
            // take the dead enemy out of our list to cycle through
            nearByEnemies.Remove(died);

            // if we were targetting them, turn off the crosshairs
            if (target == died)
            {
                lockedEnemy -= 1;
                image.enabled = false;

                //this is so it dosent throw a range exception error, if the list goes too negative
                if (lockedEnemy >= -1)
                    lockedEnemy = 0;
            }
        }
    }
}
