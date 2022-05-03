using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    PlayerStats ch;

    // Start is called before the first frame update
    void Start()
    {
        ch = GetComponent<PlayerStats>();
    }

    //test 
    public void PunchState()
    {
        for (int i = 0; i < ch.powers.Length; i++)
        {
            Debug.Log(ch.powers[i].name);
            ch.powers[i].Apply(ch, ch.target);
        }      
    }
}
