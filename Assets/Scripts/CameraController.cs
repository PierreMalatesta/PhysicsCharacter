using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public float speed = 360;
    public Transform target;
    public float distance = 5;
    public float heightOffset = 0.5f;
    float currentDistance;
    public float relaxSpeed;
    public float zoomSpeed = 5;

    public Toggle InvertCameraToggle;
    int layerMask;

    // Start is called before the first frame update
    void Start()
    {
        currentDistance = distance;
        string[] layers = { "walls" };
        layerMask = LayerMask.GetMask(layers);
    }

    Vector3 GetTargetPosition()
    {
        return target.position + heightOffset * Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
        // right drag rotates the camera 
        if (Input.GetMouseButton(1))
        {
            Vector3 angles = transform.eulerAngles;
            float dx = Input.GetAxis("Mouse Y");
            float dy = Input.GetAxis("Mouse X");

            //invert the camera if the player has requested it
            if (InvertCameraToggle && InvertCameraToggle.isOn)
                dy *= -1;

            // look up and down by rotating around X-axis 
            //do some wrap around to give us a continoues values across the equatorS
            if (angles.x > 180)
                angles.x -= 360;
            angles.x = Mathf.Clamp(angles.x + dx * speed * Time.deltaTime, -70, 70);
            // spin the camera round  
            angles.y += dy * speed * Time.deltaTime;
            transform.eulerAngles = angles;
        }

        // zoom in/out with mouse wheel 
        distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * zoomSpeed, 2, 10); 

        RaycastHit hit;
        if (Physics.Raycast(GetTargetPosition(), -transform.forward, out hit, distance, layerMask))
        {
            // snap the camera right in to where the collision happened 
            currentDistance = hit.distance;
        }
        else
        {
            // relax the camera back to the desired distance 
            currentDistance = Mathf.MoveTowards(currentDistance, distance, Time.deltaTime * relaxSpeed);
        }

        // look at the target point 
        transform.position = GetTargetPosition() - currentDistance * transform.forward;
    }
}
