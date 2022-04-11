using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInView : MonoBehaviour
{
    Camera cam;
    //only allow enemy to be added once
    bool addOnlyOnce;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        addOnlyOnce = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Create a Vector3 with dimensions based on the camera point of view
        Vector3 enemyPosition = cam.WorldToViewportPoint(gameObject.transform.position);

        //if the X and Y values are between 0 and 1 the enemy is on screen
        bool onScreen = enemyPosition.z > 0 && enemyPosition.x > 0 && enemyPosition.x < 1 && enemyPosition.y > 0 && enemyPosition.y < 1;

        //if the enemy is on screen add it to the list of nearby enemies only once
        if (onScreen && addOnlyOnce)
        {
            addOnlyOnce = false;
            TargetController.nearByEnemies.Add(this);
        }
    }
}
