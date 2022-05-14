using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarManager : MonoBehaviour
{

    public GameObject prefab;

    public static HealthBarManager instance;

    // Use this for initialization
    void Awake()
    {
        instance = this;
    }

    public void AddHealthBar(PlayerStats ch)
    {
        // make a healthbar for the character we've passed in
        GameObject go = Instantiate(prefab);
        go.transform.parent = transform;
        HealthBar hb = go.GetComponent<HealthBar>();
        hb.ch = ch;
    }
}
