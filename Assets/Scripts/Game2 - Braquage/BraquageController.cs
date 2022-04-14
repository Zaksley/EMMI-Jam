using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class BraquageController : MonoBehaviour
{

    private gameManager manager;
    private int nbLingots = 0;
    [SerializeField] int needLingots = 50;

    [SerializeField] private float startTime = 50f; 
    private float currentTime; 

    [SerializeField]  private Image fillTime;
    [SerializeField]  private Image fillLingot;
    [SerializeField]  private float timeTutorial = 2.0f;
    public bool started = false;

    public AudioSource audioSource;
    public AudioClip lingot;


    void Start()
    {
        manager = GameObject.Find("dontDestroy").gameObject.GetComponent<dontDestroy>().save.GetComponent<gameManager>();

        currentTime = timeTutorial;
        fillLingot.fillAmount = 0; 
        fillTime.fillAmount = startTime;
    }

void Update()
    {

        /*
        **   DEBUG **
        */
        if (Input.GetKeyDown(KeyCode.P)) manager.victory(); 
        else if (Input.GetKeyDown(KeyCode.M)) manager.defeat();

        if (started)
        {
            currentTime -= 1 * Time.deltaTime; 

            if (currentTime <= 0)
            {
                currentTime = 0; 
                manager.defeat();
            }

            double time = (float) currentTime / (float) startTime;
            double lingots = (float) nbLingots / (float) needLingots; 

            fillTime.fillAmount = (float) time; 
            fillLingot.fillAmount = (float) lingots; 
        }
        else 
        {
            currentTime -= 1 * Time.deltaTime; 
            if (currentTime <= 0)
            {
                currentTime = startTime; 
                started = true; 
            }
        }
    }   

    public void getLingot(int value)
    {
        nbLingots += value;
        if (nbLingots >= needLingots)
        {
            manager.victory();
        }
    }

    public void addTime(float timeValue)
    {
        float calculatedTime = currentTime + timeValue; 
        currentTime = (calculatedTime > startTime) ? startTime : calculatedTime; 
    }
}
