using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpController : MonoBehaviour

{
    public GameObject TextCanvas;
    public bool togglePanel;



    void Start()
    {
        togglePanel = true;

    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
           togglePanel = false;

        }
    }

   

}