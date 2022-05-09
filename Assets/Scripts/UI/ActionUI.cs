using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActionUI : MonoBehaviour
{
    public Power power;
     PlayerStats player;

    [Header("Child Components")]
    public Image icon;
    public TextMeshProUGUI nameTag;
    public TextMeshProUGUI descriptionTag;

    //List<ActionUI> uis = new List<ActionUI>();




    public void SetAction(Power a)
    {
        power = a;
        if (nameTag)
            nameTag.text = power.name;
        if (descriptionTag)
            descriptionTag.text = power.description;
        if (icon)
        {
            icon.sprite = power.icon;
            icon.color = power.color;
        }
    }

    public void Init(PlayerStats p)
    {
        // store the player ref for use in our lambda function below 
        player = p;
        // find the button wherever we've placed it in the prefab 
        // for more complicated types of prefabs with multiple buttons, we'd make this a public member
                // and hook it up in the Unity editor 
                Button button = GetComponentInChildren<Button>(); 
        if (button)
            button.onClick.AddListener(() => { power.Apply(player, player.target); }); 
    } 
}
