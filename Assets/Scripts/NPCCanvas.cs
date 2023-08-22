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
    public int points;
    public Points pointManager;
    public List<Transform> answers;

    private void Start()
    {
        //have the panels invisible when the game is started
        TogglePanel(false);
        correct.SetActive(false);   
        wrong.SetActive(false);
    }

    public void UpdateCanvas(string name,string dialogue,Sprite image, string correct, string incorrect1, string incorrect2)
    {
        //defining all the types of information being fed in
        TogglePanel(true);
        nameText.text = name;
        dialoguetext.text = dialogue;
        characterImage.sprite = image;
        answer1Text.text = correct;
        answer2Text.text = incorrect1;
        answer3Text.text = incorrect2;

        ShuffleList(answers);

        answers[0].SetSiblingIndex(0);
        answers[1].SetSiblingIndex(1);
        answers[2].SetSiblingIndex(2);       
    }

    private void TogglePanel(bool npcPanelState)
    {
        //freeze time if the player is interacting with a npc
        npcPanel.SetActive(npcPanelState);
        if (npcPanelState == true)
            Time.timeScale = 0;
        else 
            Time.timeScale = 1;
    }
            
    public void ClosePanel()
    {
        //close panel
        TogglePanel(false);
        playerController.CheckPickups();
        
    }

    public void rightAnswer()
    {
        //increase point count if button is pressed
      correct.SetActive(true);
        StartCoroutine(WaitToCloseRight());
        pointManager.IncreasePoints();
    
    }

    public void wrongAnswer()
    {
        wrong.SetActive(true);
        StartCoroutine(WaitToCloseWrong());
        pointManager.DecreasePoints();
        // print("working");
    }

    //have the right and wrong panel dissappear after a delay
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

    /// <summary>
    /// Shuffles a list using Unity's Random
    /// </summary>
    /// <typeparam name="T">The data type</typeparam>
    /// <param name="_list">The list to shuffle</param>
    /// <returns></returns>
    public List<T> ShuffleList<T>(List<T> _list)
    {
        for (int i = 0; i < _list.Count; i++)
        {
            T temp = _list[i];
            int randomIndex = UnityEngine.Random.Range(i, _list.Count);
            _list[i] = _list[randomIndex];
            _list[randomIndex] = temp;
        }
        return _list;
    }

}
