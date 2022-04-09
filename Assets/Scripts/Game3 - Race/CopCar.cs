using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopCar : MonoBehaviour
{
    public GameObject thiefCar;
    public float step;

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, thiefCar.transform.position, step * Time.deltaTime);
    }
}
