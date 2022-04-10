using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoController : MonoBehaviour
{
    private float time;

    void Update()
    {
        time += Time.deltaTime;
        if (time > 4f) {
            gameObject.SetActive(false);
        }
    }
}
