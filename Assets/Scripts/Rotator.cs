using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed = 1.0f;


    void Update()
    {
        //rotating

        transform.Rotate(new Vector3(0, 0.01f, 0) * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }

}
