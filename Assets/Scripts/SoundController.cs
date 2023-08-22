using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip pickupSound;
    public AudioClip winSound;
    public AudioClip rightAnwser;
    public AudioClip wrongAnwser;
    public AudioClip keySound;
    AudioSource audioSource;
    

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPickupSound()
    {
        PlaySound(pickupSound);
    }
    public void PlayWinSound()
    {
        PlaySound(winSound);
    }
    public void PlayRightAnwser()
    {
        PlaySound(rightAnwser);
    }

    public void PlayWrongAnwser()
    {
        PlaySound(wrongAnwser);
    }

    public void PlayKeySound()
    {
        PlaySound(keySound);
    }

    void PlaySound(AudioClip _newSound)
    {
        //set the audiosources AudioClip to be the passed in sound
        audioSource.clip = _newSound;
        //Play the audiosource
        audioSource.Play();
    }

    public void PlayCollisionSound(GameObject _go)
    {
        //check to see if the collided object has an audiosource
        //this is a failsafe in case we forgot to attach one to our wall
        if (_go.GetComponent<AudioSource>() != null)
        {
            //play the audio on the wall object
            _go.GetComponent<AudioSource>().Play();
        }
    }
}
