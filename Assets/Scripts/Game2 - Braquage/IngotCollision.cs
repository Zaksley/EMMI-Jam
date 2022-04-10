using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IngotCollision : MonoBehaviour
{
    private new BoxCollider2D collider; 
    private GameObject spawner;
    private GameObject controller;

    [SerializeField] private int valueLingot = 1;
    // [SerializeField] private float timeLingot = 5.0f; 
    
    [SerializeField] private GameObject prefabText; 
    [SerializeField] private GameObject player; 
    public int index; 
    [SerializeField] private Vector3 offSet; 

    void Start()
    {
        collider = GetComponent<BoxCollider2D>(); 
        spawner = GameObject.Find("IngotGenerator"); 
        controller = GameObject.Find("BraquageController"); 
        player = GameObject.Find("Player"); 

        offSet = new Vector3(2.5f, 1.5f, 0);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {   
        if (other.gameObject.CompareTag("Player"))
        {
            spawner.GetComponent<SpawnIngot>().addLocation(index); 
            controller.GetComponent<BraquageController>().getLingot(valueLingot);
            //controller.GetComponent<BraquageController>().addTime(timeLingot);
            ShowMoney(); 
            Destroy(gameObject);
        }
    }

    private void ShowMoney()
    {
        GameObject prefab = Instantiate(prefabText, player.transform.position + offSet, Quaternion.identity);
        prefab.GetComponentInChildren<TextMeshPro>().text = "$20 000";
    }
}
