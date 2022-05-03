using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUI : MonoBehaviour {

    // this key and subsequent codes fire off the powers
    public KeyCode startKey;
    // sibling Character component
    PlayerStats ch;

	// Use this for initialization
	void Start () {
        ch = GetComponent<PlayerStats>();
	}
	
	// Update is called once per frame
	void Update () {

        // check each key to see if the powers been activated
        for (int i = 0; i < ch.powers.Length; i++)
        {
            if (Input.GetKeyDown(startKey + i))
            {
                Debug.Log(ch.powers[i].name);
                ch.powers[i].Apply(ch, ch.target);
            }
        }

        // TODO - make a button for each power that can also activate it, in a separate class somewhere
	}
}
