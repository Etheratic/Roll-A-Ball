using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject door;
    public GameObject unlocked;
    public GameObject key;
    public SoundController soundController;

    // Start is called before the first frame update
    void Start()
    {
        unlocked.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(door);
        unlocked.SetActive(true);
        StartCoroutine(WaitToCloseUnlocked());
    }

    IEnumerator WaitToCloseUnlocked()
    {
        yield return new WaitForSecondsRealtime(1);
        unlocked.SetActive(false);
      Destroy(key);
    }
}
