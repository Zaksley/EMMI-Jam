using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BraquageController : MonoBehaviour
{

    private gameManager manager;
    private int nbLingots = 0;
    [SerializeField] int needLingots = 50;

    [SerializeField] private float startTime = 60f; 
    private float currentTime; 
    private float displayTime;

    void Start()
    {
        // manager = GameObject.Find("dontDestroy").gameObject.GetComponent<dontDestroy>().save.GetComponent<gameManager>();

        currentTime = startTime;
    }

void Update()
    {
        currentTime -= 1 * Time.deltaTime; 

        displayTime = currentTime;
        //countdown.text = displayTime.ToString("N1"); 

        // Loose
        if (currentTime <= 0)
        {
            currentTime = 0; 
            //manager.defeat();
        }
    }

    public void getLingot(int value)
    {
        nbLingots += value;
        if (nbLingots >= needLingots)
        {
            //manager.win();
        }

    }

    public void addTime(float timeValue)
    {
        currentTime += timeValue;

    }
}
