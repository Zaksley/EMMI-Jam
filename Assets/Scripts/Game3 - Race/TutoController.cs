using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoController : MonoBehaviour
{
    private float time;
    [SerializeField] private float showTime;

    void Update()
    {
        time += Time.deltaTime;
        if (time > showTime) {
            gameObject.SetActive(false);
        }
    }
}
