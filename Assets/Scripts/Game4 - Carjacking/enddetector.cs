using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enddetector : MonoBehaviour
{
    // Start is called before the first frame update

    public detector detect;
    void Start()
    {
        
    }

     void OnTriggerEnter2D(Collider2D infoCollision) // le type de la variable est Collision
    {
        StartCoroutine(detect.gameOver());
        Debug.Log("dead");
    }

}
