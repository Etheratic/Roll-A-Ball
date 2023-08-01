using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CameraStyle {Fixed, Free}

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public CameraStyle cameraStyle;
    public Transform pivot;
    public float rotationSpeed = 1f;

    private Vector3 offset;
    private Vector3 pivotOffset;


    
    void Start()
    {

        //the offset of the pivot from the player
        pivotOffset = pivot.position - player.transform.position;

        //set the offset of the camera based on the player
        offset = transform.position - player.transform.position;

    }

    
    void LateUpdate()
    {
        //if we are using the fixed camera mide

        if (cameraStyle == CameraStyle.Fixed)
        {
            //Get the cameras transform position to be that of the players transform position
            transform.position = player.transform.position + offset;

        }
        
        //if we are using the free camera mode
        if (cameraStyle == CameraStyle.Free)
        {
            //make the pivot position follow the player
            pivot.transform.position = player.transform.position + pivotOffset;
            //work out the angle from the mouse input as a quaternion
            Quaternion turnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);
            //modify the offset by the turn angle
            offset = turnAngle * offset;
            //set the camera position to that of the pivot plus the offset
            transform.position = pivot.transform.position + offset;
            //make the camera look at the pivot
            transform.LookAt(pivot);

        }
 
    }
}
