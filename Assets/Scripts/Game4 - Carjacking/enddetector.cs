using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class enddetector : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip loose; 
    public float volume=1f;

    public detector detect;

     void OnTriggerEnter2D(Collider2D infoCollision) // le type de la variable est Collision
    {
        audioSource.PlayOneShot(loose, volume);
        //volume = 0f;
        //StartCoroutine(detect.gameOver());
        if (detect.numberLifes > 0){
            
            if (detect.numberLifes == 2){
                Debug.Log("t");
                detect.GetComponent<SpriteRenderer>().sprite = detect.circleSprites[10 + detect.language];
            }
            else{
                Debug.Log("t2");
                detect.GetComponent<SpriteRenderer>().sprite = detect.circleSprites[12 + detect.language];
            }
            detect.numberLifes --;
            //Debug.Log("test2");
            //Debug.Log("test2" + detect.numberLifes);
        }
        else {
            //Debug.Log("test");
            //Debug.Log("test" + detect.numberLifes);
            volume = 0f;
            StartCoroutine(detect.gameOver());
        }
    }

}
