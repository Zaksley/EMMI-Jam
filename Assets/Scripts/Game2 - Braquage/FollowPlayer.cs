using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    
    [SerializeField] private Transform target; 

    private float xMin = -4.8f;
    private float xMax = 4.85f;
    private float yMax = 2.63f;
    private float yMin = -2.63f;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
        Mathf.Clamp(target.position.x, xMin, xMax),
        Mathf.Clamp(target.position.y, yMin, yMax),
        transform.position.z  
        );
    }
}
