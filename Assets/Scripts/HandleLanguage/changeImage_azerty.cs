using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



public class changeImage_azerty : MonoBehaviour
{
    [SerializeField] Sprite azerty; 
    [SerializeField] Sprite qwerty; 
    private gameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("dontDestroy").gameObject.GetComponent<dontDestroy>().save.GetComponent<gameManager>();

    }

    private void Update() 
    {
        if (manager.isAzerty) 
        {
            gameObject.GetComponent<Image>().overrideSprite = azerty; 
        }
        else
        {
            gameObject.GetComponent<Image>().overrideSprite = qwerty; 
        }
    }
}
