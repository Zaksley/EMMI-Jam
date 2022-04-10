using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCars : MonoBehaviour
{
    [SerializeField] private GameObject carLeft;
    [SerializeField] private GameObject carRight;
    [SerializeField] private bool right;

    void Start()
    {
        if (right)  InvokeRepeating("SpawnRight", 2f, 2f); 
        else        InvokeRepeating("SpawnLeft", 2f, 2f); 
    }

    void Update()
    {
        
    }
    
    void SpawnRight()
    {
        Instantiate(carRight, transform.position, Quaternion.identity); 
    }

    void SpawnLeft()
    {
        Instantiate(carLeft, transform.position, Quaternion.identity); 
    }
}
