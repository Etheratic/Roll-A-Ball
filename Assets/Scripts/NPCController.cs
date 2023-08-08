using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{

    public string characterName;
    public string characterDialogue;
    public string correctAnwser;
    public string incorrectAnswer1;
    public string incorrectAnswer2;
    public Sprite characterImage;
    private NPCCanvas npcCanvas;


    // Start is called before the first frame update
    void Start()
    {
        npcCanvas = FindObjectOfType<NPCCanvas>();  
    }

    public void StartNPC()
    {

        npcCanvas.UpdateCanvas(characterName, characterDialogue, characterImage, correctAnwser, incorrectAnswer1,incorrectAnswer2);
    }

    
}
