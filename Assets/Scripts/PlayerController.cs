using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5.0f;
    public Rigidbody rb;
    private int pickupCount;

    //contollers
    SoundController soundController;

    private bool gameOver = false;
    public bool isTalking;
    GameObject resetPoint;
    bool resetting = false;
    Color originalColour;
    CameraController cameraController;
    GameController gameController;
    private Timer timer;
 private NPCController npcController;
    public Points points;


    [Header("UI")]
    public GameObject inGamePanel;
    public GameObject winPanel;
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public TMP_Text winTimeText;
    public GameObject npcPanel;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //get the number of pickups in our scene
        pickupCount = GameObject.FindGameObjectsWithTag("Pick Up").Length;
        //Run the check pickups function
        CheckPickups();
        //get the timer object
        
        isTalking = false;

        //Turn on our in Game Panel
        inGamePanel.SetActive(true);

        //Turn off our win panel
        winPanel.SetActive(false);

        soundController = FindObjectOfType<SoundController>();

        //setting up reset point
        resetPoint = GameObject.Find("Reset Point");
        originalColour = GetComponent<Renderer>().material.color;

        cameraController = FindObjectOfType<CameraController>();

        Time.timeScale = 1;

        gameController = FindObjectOfType<GameController>();
        timer = FindObjectOfType<Timer>();
        if (gameController.gameType == GameType.SpeedRun)
            StartCoroutine(timer.StartCountdown());


       
    }

    private void Update()
    {
        if(isTalking)
        {
           
        }
        else
        {
            rb.drag = 0.1f;
        }
    }
 

    // Update is called once per frame
    void FixedUpdate()
    {
     

        if (gameController.gameType == GameType.SpeedRun && !timer.IsTiming())
            return;

        if (gameOver)
            return;

        if (resetting)
            return;

        //detect movement inputs
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        //apply force
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
       
        if (cameraController.cameraStyle == CameraStyle.Free)
        {
            //rotates the player to the direction of the camera
            transform.eulerAngles = Camera.main.transform.eulerAngles;
            //translates the input vectors into coordinates
            movement = transform.TransformDirection(movement);
        }
        rb.AddForce(movement * speed);
    }

    public void CheckPickups()
    {
        //Display amount of pickups on ours screen
        scoreText.text = "Students Hidden: " + pickupCount;
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
        //turn on our win panel
        winPanel.SetActive(true);
        //turn off our ingame panel
        inGamePanel.SetActive(false);

        soundController.PlayWinSound();
      
        //set the velocity of the rigidbody to 0
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        if (gameController.gameType == GameType.SpeedRun)
            timer.StopTimer();

        points.CheckPoints();
        

    }


   

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

        if (collision.gameObject.GetComponent<NPCController>() != null)
        {
            collision.gameObject.GetComponent<NPCController>().StartNPC();
            //decrement the pickup count
            pickupCount -= 1;
            //Run the check pickups function
            //CheckPickups();
            //turn isTalking on
            soundController.PlayPickupSound();
        }

        if(collision.gameObject.CompareTag("Wall"))
        {
            soundController.PlayCollisionSound(collision.gameObject);
        }
    }

  




    public IEnumerator ResetPlayer()

    {
        //moving the player back to reset point when in contact with the reset zone. 
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



    
    
    






    


   





