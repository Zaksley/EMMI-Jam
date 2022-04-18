using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



public class changeImage : MonoBehaviour
{
    [SerializeField] Sprite fr; 
    [SerializeField] Sprite en; 
    private gameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("dontDestroy").gameObject.GetComponent<dontDestroy>().save.GetComponent<gameManager>();


        if (manager.isFrench) 
        {
            gameObject.GetComponent<Image>().overrideSprite = fr; 
        }
        else
        {
            gameObject.GetComponent<Image>().overrideSprite = en; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
