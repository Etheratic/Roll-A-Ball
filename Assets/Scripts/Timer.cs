using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float currentTime;
    private bool timing;

    //start timer
    public void StartTimer()
    {
        timing = true;
    }
 
    //stop timer
    public void StopTimer()
    {
        timing = false;

    }

    //set current time to Gettime title
    public float GetTime()
    {
        return currentTime;
    }




    void Update()

        //timer according delta time
    {
        if(timing == true)
        {
            currentTime += Time.deltaTime;
        }

       
    }
}
