using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class CountDownTimer : MonoBehaviour
{
    
    private float currentTime = 0f;
    [SerializeField] private float startingTime = 30f;

    [SerializeField] TMP_Text countdown;

    void Start()
    {
        currentTime = startingTime; 
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime; 
        countdown.text = currentTime.ToString("N1"); 

        if (currentTime <= 0)
            currentTime = 0; 
    }
}
