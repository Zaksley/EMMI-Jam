using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class CountDownTimer : MonoBehaviour
{
    
    private float currentTime = 0f;
    private float displayTime = 0f;
    [SerializeField] private float startingTime = 30f;
    [SerializeField] private float introductionTime = 3f;
    [SerializeField] private float instructionTime = 5f; 
    [SerializeField] private GameObject UItext1; 
    [SerializeField] private GameObject UItext2;     
    [SerializeField] private NumbersController numbers;

    [SerializeField] TMP_Text countdown;
    private gameManager manager;
    private bool start = false;

    void Start()
    {
        currentTime = startingTime; 
        displayTime = currentTime; 
        countdown.text = displayTime.ToString("N1"); 
        manager = GameObject.Find("dontDestroy").gameObject.GetComponent<dontDestroy>().save.GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
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
            {
                currentTime = 0; 
                manager.defeat();
            }
        }
        else
        {
                // Intro 
            introductionTime -= 1 * Time.deltaTime; 
            if (introductionTime <= 0)
            {
                start = true; 
            }
        }

            // Instruction 
        if (instructionTime >= 0) instructionTime -= Time.deltaTime; 
        else 
        {
            if (UItext1.GetComponent<SpriteRenderer>().enabled && UItext2.GetComponent<SpriteRenderer>().enabled)
            {
                UItext1.GetComponent<SpriteRenderer>().enabled = false;
                UItext2.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
           
    }
}
