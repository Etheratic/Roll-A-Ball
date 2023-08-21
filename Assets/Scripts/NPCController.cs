using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NPCController : MonoBehaviour
{

    public string characterName;
    public string characterDialogue;
    public string correctAnwser;
    public string incorrectAnswer1;
    public string incorrectAnswer2;
    public Sprite characterImage;
    private NPCCanvas npcCanvas;
    private PlayerController playerController;
    
   

    // Start is called before the first frame update
    void Start()
    {
        npcCanvas = FindObjectOfType<NPCCanvas>();  
    }

    public void StartNPC()
    {
        //inputing all the text info for the npc dialogue
        npcCanvas.UpdateCanvas(characterName, characterDialogue, characterImage, correctAnwser, incorrectAnswer1,incorrectAnswer2);
        GetComponent<Collider>().enabled = false;
        
    }
}
