using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class NPCCanvas : MonoBehaviour
{
    public PlayerController playerController;
    public TMP_Text nameText;
    public TMP_Text dialoguetext;
    public Image characterImage;
    public GameObject npcPanel;
    public TMP_Text answer1Text, answer2Text, answer3Text;
    public GameObject correct;
    public GameObject wrong;
    public float delaytime;



    private void Start()
    {
        TogglePanel(false);
        correct.SetActive(false);   
        wrong.SetActive(false);
    }

    public void UpdateCanvas(string name,string dialogue,Sprite image, string correct, string incorrect1, string incorrect2)
    {
        TogglePanel(true);
        nameText.text = name;
        dialoguetext.text = dialogue;
        characterImage.sprite = image;
        answer1Text.text = correct;
        answer2Text.text = incorrect1;
        answer3Text.text = incorrect2;

       
    }

    private void TogglePanel(bool npcPanelState)
    {
        npcPanel.SetActive(npcPanelState);
        if (npcPanelState == true)
            Time.timeScale = 0;
        else 
            Time.timeScale = 1;
    }
    
  
    
    public void ClosePanel()
    {
        TogglePanel(false);
        playerController.CheckPickups();
        
    }

    public void rightAnswer()
    {
      correct.SetActive(true);
        StartCoroutine(WaitToCloseRight());
    }

    public void wrongAnswer()
    {
        wrong.SetActive(true);
        StartCoroutine(WaitToCloseWrong());
    }

    IEnumerator WaitToCloseRight()
    {
        yield return new WaitForSecondsRealtime(delaytime);
        correct.SetActive(false);
    }
    IEnumerator WaitToCloseWrong()
    {
        yield return new WaitForSecondsRealtime(delaytime);
        wrong.SetActive(false);
    }

}
