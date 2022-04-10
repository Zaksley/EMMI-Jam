using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class enddetector : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip loose; 
    public float volume=1f;


    public detector detect;
    void Start()
    {
        
    }

     void OnTriggerEnter2D(Collider2D infoCollision) // le type de la variable est Collision
    {
        audioSource.PlayOneShot(loose, volume);
        StartCoroutine(detect.gameOver());
        Debug.Log("dead");
    }

}
