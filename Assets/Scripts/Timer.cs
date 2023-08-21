using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float currentTime;
    public float bestTime;
    private bool timing;
    
    SceneController sceneController;

    [Header("UI Countdown Panel")]
    public GameObject countdownPanel;
    public Text countdownText;

    [Header("UI In Game Panel")]
    public Text timerText;

    [Header("UI Game Over Panel")]
    public GameObject timesPanel;
    public Text myTimeResult;
    public Text bestTimeResult;

    void Start()
    {
        timesPanel.SetActive(false);
        countdownPanel.SetActive(false);
        timerText.text = "";
        sceneController = FindObjectOfType<SceneController>();
    }

    void Update()
    {
        //the number of points in the timer and how it connects to realtime
        if(timing)
        {
            currentTime += Time.deltaTime;
            timerText.text = currentTime.ToString("F3");
        }
    }

    
    public IEnumerator StartCountdown()
    {
        yield return new WaitForEndOfFrame();
        if (PlayerPrefs.HasKey("BestTime"))
            bestTime = PlayerPrefs.GetFloat("BestTime" + sceneController.GetSceneName());
        else
            bestTime = 1000f;

        //display the countdown panels
        countdownPanel.SetActive(true);
        countdownText.text = "3";
        yield return new WaitForSeconds(1);
        countdownText.text = "2";
        yield return new WaitForSeconds(1);
        countdownText.text = "1";
        yield return new WaitForSeconds(1);
        countdownText.text = "GO!";
        yield return new WaitForSeconds(1);
        StartTimer();
        countdownPanel.SetActive(false);
    }

    public void StartTimer()
    {
        //begin timing
        currentTime = 0;
        timing = true;
    }

    public void StopTimer()
    {
        //stop timing and display the said time
        timing = false;
        timesPanel.SetActive(true);
        myTimeResult.text = currentTime.ToString("F3");
        bestTimeResult.text = bestTime.ToString("F3");

        // replace olde best time with new best time with new text.
        if (currentTime <= bestTime)
        {
            bestTime = currentTime;
            PlayerPrefs.SetFloat("BestTime" + sceneController.GetSceneName(), bestTime);
            bestTimeResult.text = bestTime.ToString("F3") + "!! NEW BEST !!";
        }
    }
    public bool IsTiming()
    {
        return timing;
    }
}
