using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RPG;

//tells script to play later if we wanted to play it before for example we would put -100
[DefaultExecutionOrder(100)]
public class ActionListUI : MonoBehaviour
{
    public ActionUI prefab;
    public PlayerStats player;


    LayoutGroup layoutGroup;
    ContentSizeFitter contentSizeFitter;

    // Start is called before the first frame update 
    void Start()
    {
        layoutGroup = GetComponent<LayoutGroup>();
        contentSizeFitter = GetComponent<ContentSizeFitter>();
        StartCoroutine(UpdateUI());

        //actionList.onChanged.AddListener(() => { StartCoroutine(UpdateUI()); });

        foreach (Power a in player.powers)
        {
            // make this a child of ours on creation.  
            // Don't worry about specifying a position as the LayotGroup handles  that
            ActionUI ui = Instantiate(prefab, transform);
            ui.SetAction(a);
            ui.Init(player);
        }
        //yield return new WaitForEndOfFrame();

        //GetComponent<ContentSizeFitter>().enabled = false;
        //GetComponent<LayoutGroup>().enabled = false;
    }

    IEnumerator UpdateUI()
    {
        contentSizeFitter.enabled = true;
        layoutGroup.enabled = true;
        yield return new WaitForEndOfFrame();

        //player = actionList.GetComponent<Player>();
        yield return new WaitForEndOfFrame();

        contentSizeFitter.enabled = false;
        layoutGroup.enabled = false;
    }

    void Init()
    {

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
    }
}
