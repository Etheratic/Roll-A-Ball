using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5.0f;
    private Rigidbody rb;
    private int pickupCount;
    private Timer timer;
    private bool gameOver = false;
    GameObject resetPoint;
    bool resetting = false;
    Color originalColour;

    [Header("UI")]
    public GameObject inGamePanel;
    public GameObject winPanel;
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public TMP_Text winTimeText;

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

        //Turn on our in Game Panel
        inGamePanel.SetActive(true);

        //Turn off our win panel
        winPanel.SetActive(false);

        //setting up reset point
        resetPoint = GameObject.Find("Reset Point");
        originalColour = GetComponent<Renderer>().material.color;

        Time.timeScale = 1;





    }

    private void Update()
    {
        //display timer in timer text
        timerText.text = "Time: " + timer.GetTime().ToString("F2");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if(gameOver == false)
        {

            if (resetting)
                return;

            //detect movement inputs

            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            //apply force

            Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
            rb.AddForce(movement * speed);




        }
        
        


    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pick Up")
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
        //Display amount of pickups on ours screen

        scoreText.text = "Pick Ups Left: " + pickupCount;

        //display win screen if pickups = 0

        if (pickupCount == 0)
        {
            WinGame();
          
        }


    }

    void WinGame()
    {

        //set the gameOver to try
        gameOver = true;
        //stop the timer
        timer.StopTimer();
        //turn on our win panel
        winPanel.SetActive(true);
        //turn off our ingame panel
        inGamePanel.SetActive(false);
        //display the timer on the win time text
        winTimeText.text = "your time was: " + timer.GetTime().ToString("F2");

        //set the velocity of the rigidbody to 0
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
       


    }


    //temporary, will be removed for A2

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene
            (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);


    }
    
    public void QuitGame()
    {
        Application.Quit();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            StartCoroutine(ResetPlayer());
        }



    }

    public IEnumerator ResetPlayer()

    {
        resetting = true;
        GetComponent<Renderer>().material.color = Color.black;
        rb.velocity = Vector3.zero;
        Vector3 startPos = transform.position;
        float resetSpeed = 2f;
        var i = 0.0f;
        var rate = 1.0f / resetSpeed;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.position = Vector3.Lerp(startPos, resetPoint.transform.position, i);
            yield return null;
        }
        GetComponent<Renderer>().material.color = originalColour;
        resetting = false;
    }



}



    
    
    






    


   





