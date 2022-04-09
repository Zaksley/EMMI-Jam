using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class BraquageController : MonoBehaviour
{

    private gameManager manager;
    private int nbLingots = 0;
    [SerializeField] int needLingots = 50;

    [SerializeField] private float startTime = 60f; 
    private float currentTime; 

    [SerializeField]  private Image fillTime;
    [SerializeField]  private Image fillLingot;


    void Start()
    {
        // manager = GameObject.Find("dontDestroy").gameObject.GetComponent<dontDestroy>().save.GetComponent<gameManager>();

        currentTime = startTime;
        needLingots = 10;
    }

void Update()
    {
        currentTime -= 1 * Time.deltaTime; 

        // Loose
        if (currentTime <= 0)
        {
            currentTime = 0; 
            //manager.defeat();
        }

        double time = (float) currentTime / (float) startTime;
        double lingots = (float) nbLingots / (float) needLingots; 

        fillTime.fillAmount = (float) time; 
        fillLingot.fillAmount = (float) lingots; 
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
        float calculatedTime = currentTime + timeValue; 
        currentTime = (calculatedTime > startTime) ? startTime : calculatedTime; 
    }
}
