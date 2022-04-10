using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCars : MonoBehaviour
{
    [SerializeField] private GameObject carLeft;
    [SerializeField] private GameObject carRight;
    [SerializeField] private bool right;
    [SerializeField] private float time; 
    [SerializeField] private float offTimeDown; 
    [SerializeField] private float offTimeUp; 


    private float elapsedTime = 0.0f; 
    private float timeLimit; 


    void Start()
    {
        timeLimit = time; 
    }

    void Update()
    {
            
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= timeLimit)
        {
            elapsedTime = 0;
            timeLimit = time + Random.Range(-offTimeDown, offTimeUp);

            if (right)  SpawnRight(); 
            else        SpawnLeft(); 
        }
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
