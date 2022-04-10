using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip falseClip;
    public AudioClip validateClip;
    public AudioClip doorOpen;
    public float volume=0.5f;
    public NumbersController nc;
    public void PlaySound()
    {
        
    }

    void OnMouseDown()
    {
        // Destroy the gameObject after clicking on it
        
        if (nc.checkCode()) {
            audioSource.PlayOneShot(validateClip, volume);
            audioSource.PlayOneShot(doorOpen, volume);
        }
        else {
            audioSource.PlayOneShot(falseClip, volume);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
