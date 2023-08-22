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
  
    public void IncreasePoints()
    {
        //increase points
        points += 1;
    }

    public void DecreasePoints()
    {
        //decrease points by 1, this is being used anymore
        points -= 1;
    }

    public void CheckPoints()
    {
        //convert point to text
        StartCoroutine(WaitToCheckPoints());
    }
    IEnumerator WaitToCheckPoints()
    {
        yield return new WaitForEndOfFrame();
        pointText.text = points.ToString();
    }
}
