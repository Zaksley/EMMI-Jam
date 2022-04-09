using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class CountDownTimer : MonoBehaviour
{
    
    private float currentTime = 0f;
    private float displayTime = 0f;
    [SerializeField] private float startingTime = 30f;
    [SerializeField] private NumbersController numbers;

    [SerializeField] TMP_Text countdown;

    void Start()
    {
        currentTime = startingTime; 
        displayTime = currentTime; 
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime; 
        
        // Update time
        if (numbers.win)
        {
            return;
        }

        displayTime = currentTime;
        countdown.text = displayTime.ToString("N1"); 

        // Loose
        if (currentTime <= 0)
            currentTime = 0; 
    }
}
