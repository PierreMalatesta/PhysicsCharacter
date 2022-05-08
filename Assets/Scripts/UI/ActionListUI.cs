using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionListUI : MonoBehaviour
{
    public ActionList actionList;
    public ActionUI prefab;
    public Player player;


    LayoutGroup layoutGroup;
    ContentSizeFitter contentSizeFitter;

    // Start is called before the first frame update 
    void Start()
    {
        layoutGroup = GetComponent<LayoutGroup>();
        contentSizeFitter = GetComponent<ContentSizeFitter>();
        StartCoroutine(UpdateUI());

        actionList.onChanged.AddListener(() => { StartCoroutine(UpdateUI()); });

        //player = actionList.GetComponent<Player>();
        //foreach (Action a in actionList.actions)
        //{
        //    // make this a child of ours on creation.  
        //    // Don't worry about specifying a position as the LayotGroup handles  that
        //    ActionUI ui = Instantiate(prefab, transform);
        //    ui.SetAction(a);
        //    ui.Init(player);
        //}
        //yield return new WaitForEndOfFrame();

        //GetComponent<ContentSizeFitter>().enabled = false;
        //GetComponent<LayoutGroup>().enabled = false;
    }

    IEnumerator UpdateUI()
    {
        contentSizeFitter.enabled = true;
        layoutGroup.enabled = true;
        yield return new WaitForEndOfFrame();

        player = actionList.GetComponent<Player>();
        yield return new WaitForEndOfFrame();

        contentSizeFitter.enabled = false;
        layoutGroup.enabled = false;
    }
}
