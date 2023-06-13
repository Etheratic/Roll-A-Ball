using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5.0f;
    private Rigidbody rb;
    private int pickupCount;
    private Timer timer;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //get the number of pickups in our scene
        pickupCount = GameObject.FindGameObjectsWithTag("Pick Up").Length;
        //Run the check pickups function
        CheckPickups();
        //get the timer object
        timer = FindObjectOfType<Timer>();
        timer.StartTimer();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement * speed);

    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pick Up") ;
        {
            Destroy(other.gameObject);
            //decrement the pickup count
            pickupCount -= 1;
            //Run the check pickups function
            CheckPickups();

        }
    }

    void CheckPickups()
    {
        print("Pickup Count: " + pickupCount);

        if (pickupCount == 0)
        {
            timer.StopTimer();
            print("yay you won!, your time was " + timer.GetTime());

        }

    }



    
    
    


}



    


   





