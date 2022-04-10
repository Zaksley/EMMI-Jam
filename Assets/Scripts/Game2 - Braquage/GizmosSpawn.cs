using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosSpawn : MonoBehaviour
{
    [SerializeField] private float radius = 2.0f;
    [SerializeField] private bool blue; 

    private void OnDrawGizmos() 
    {

        if (blue) Gizmos.color = Color.blue; 
        else Gizmos.color = Color.green; 
        
        Gizmos.DrawSphere(transform.position, radius); 
    }
}
