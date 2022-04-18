using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class changeSprite : MonoBehaviour
{
    [SerializeField] Sprite fr; 
    [SerializeField] Sprite en; 
    private gameManager manager;

    private SpriteRenderer spriteRenderer; 

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("dontDestroy").gameObject.GetComponent<dontDestroy>().save.GetComponent<gameManager>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        if (manager.isFrench) 
        {
            spriteRenderer.sprite = fr; 
        }
        else
        {
            spriteRenderer.sprite = en; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
