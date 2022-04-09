using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngotCollision : MonoBehaviour
{
    private new BoxCollider2D collider; 
    private GameObject spawner;
    private GameObject controller;

    [SerializeField] private int valueLingot = 1;
    [SerializeField] private float timeLingot = 5f; 
    public int index; 

    void Start()
    {
        collider = GetComponent<BoxCollider2D>(); 
        spawner = GameObject.Find("IngotGenerator"); 
        controller = GameObject.Find("BraquageController"); 
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {   
        if (other.gameObject.CompareTag("Player"))
        {
            spawner.GetComponent<SpawnIngot>().addLocation(index); 
            controller.GetComponent<BraquageController>().getLingot(valueLingot);
            controller.GetComponent<BraquageController>().addTime(timeLingot);
            Destroy(gameObject);
        }
    }
}
