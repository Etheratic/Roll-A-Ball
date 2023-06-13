using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;


    
    void Start()
    {
        //set the offset of the cammer based on the player
        offset = transform.position - player.transform.position;
    }

    
    void LateUpdate()
    {
        //Get the cameras transform position to be that of the players transform position
        transform.position = player.transform.position + offset;
 
    }
}
