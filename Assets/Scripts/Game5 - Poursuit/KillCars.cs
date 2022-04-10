using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCars : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("in");
        if (other.gameObject.CompareTag("Car"))
        {
            Destroy(other.gameObject); 
        }
    }
}
