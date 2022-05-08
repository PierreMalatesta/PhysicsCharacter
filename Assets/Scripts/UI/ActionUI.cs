using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActionUI : MonoBehaviour
{
    public Action action;
    Player player;

    [Header("Child Components")]
    public Image icon;
    public TextMeshProUGUI nameTag;
    public TextMeshProUGUI descriptionTag;

    //List<ActionUI> uis = new List<ActionUI>();

    private void Start()
    {
        SetAction(action);

    }

    //private void Update()
    //{
    //    // step through the dictionary, and remove any uis associated with actions no longer in our list
    //    for (int i = 0; i < actionList.actions.Length; i++)
    //    {
    //        // if we need to add another UI to our list, create it here 
    //        if (i >= uis.Count)
    //        {
    //            // make this a child of ours on creation.  
    //            // Don't worry about specifying a position as the LayoutGroup handles that
    //            uis.Add(Instantiate(prefab, transform));

    //            // pass the player ref through and hook up any buttons 
    //            uis[i].Init(player);
    //        }
    //        uis[i].gameObject.SetActive(true);
    //        uis[i].SetAction(actionList.actions[i]);
    //        // make sure they all appear in order again 
    //        uis[i].transform.SetAsLastSibling();
    //    }

    //    // disable any remaining UIs if the list has shrunk on us 
    //    for (int i = actionList.actions.Length; i < uis.Count; i++)
    //        uis[i].gameObject.SetActive(false);
    //}

    public void SetAction(Action a)
    {
        action = a;
        if (nameTag)
            nameTag.text = action.actionName;
        if (descriptionTag)
            descriptionTag.text = action.description;
        if (icon)
        {
            icon.sprite = action.icon;
            icon.color = action.color;
        }
    }

    public void Init(Player p)
    {
        // store the player ref for use in our lambda function below 
        player = p;
        // find the button wherever we've placed it in the prefab 
        // for more complicated types of prefabs with multiple buttons, we'd make this a public member
                // and hook it up in the Unity editor 
                Button button = GetComponentInChildren<Button>(); 
        if (button)
            button.onClick.AddListener(() => { player.DoAction(action); }); 
    } 
}
