using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    
    [SerializeField] private Transform target; 


    void Update()
    {
        transform.position = new Vector3(transform.position.x, target.transform.position.y, transform.position.z); 
    }

}
