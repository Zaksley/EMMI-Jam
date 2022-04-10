using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTree : MonoBehaviour
{
    [SerializeField] private Sprite[] trees; 
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = trees[Random.Range(0, trees.Length)]; 

    }
}
