using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollPoker : MonoBehaviour
{
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //this is used to click to make something happen
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000, -1, QueryTriggerInteraction.Ignore))
            {
                Ragdoll ragdoll = hit.collider.GetComponent<Ragdoll>();
                if (ragdoll)
                    ragdoll.RagdollOn = true;
            }
        }
    }
}
