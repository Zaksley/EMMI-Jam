using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngotCollision : MonoBehaviour
{
    private new BoxCollider2D collider; 
    private GameObject spawner;
    public int index; 

    void Start()
    {
        collider = GetComponent<BoxCollider2D>(); 
        spawner = GameObject.Find("IngotGenerator"); 
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {   
        if (other.gameObject.CompareTag("Player"))
        {
            spawner.GetComponent<SpawnIngot>().addLocation(index); 
            Destroy(gameObject);
        }
    }
}
