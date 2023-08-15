using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.UI;
using TMPro;

public class Points : MonoBehaviour
{
    public int points;
    public GameObject pointPanel;
    public TMP_Text pointText;

    
    public void increasepoints()
    {
        points += 1;
    }

    public void decreasepoints()
    {
        points -= 1;
    }

    public void checkPoints()
    {
       pointText.text = points.ToString();
    }
  
}
