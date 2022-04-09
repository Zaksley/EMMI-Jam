using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosSpawn : MonoBehaviour
{
    [SerializeField] private float radius = 2.0f;

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.blue; 
        Gizmos.DrawSphere(transform.position, radius); 
    }
}
