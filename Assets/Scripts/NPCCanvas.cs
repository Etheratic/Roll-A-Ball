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




    private void Start()
    {
        TogglePanel(false);

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

       
    }
    
 
    
    public void ClosePanel()
    {
        TogglePanel(false);
        Time.timeScale = 1.0f;
        
    }
}
