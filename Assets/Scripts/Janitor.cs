using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Janitor : MonoBehaviour
{

    public GameObject dialogue;
    public GameObject door;
    public GameObject unlockedPanel;

    // Start is called before the first frame update
    void Start()
    {
        dialogue.SetActive(false);
        unlockedPanel.SetActive(false);
    }

   
    void closepanel()
    {
        dialogue.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        //turn on dialogue on trigger
        dialogue.SetActive(true);
        GameObject.Destroy(door);
        unlockedPanel.SetActive(true);
        StartCoroutine(WaitToCloseUnlocked());
       
    }

    IEnumerator WaitToCloseUnlocked()
    {
        yield return new WaitForSecondsRealtime(1);
        unlockedPanel.SetActive(false);

    }
   

}
