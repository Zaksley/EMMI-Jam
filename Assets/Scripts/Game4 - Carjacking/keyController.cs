using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyController : MonoBehaviour
{

    public Sprite[] keySprites;
    public GameObject detector;
    private gameManager manager;

    private void Start() 
    {
        manager = GameObject.Find("dontDestroy").gameObject.GetComponent<dontDestroy>().save.GetComponent<gameManager>();
    }

    void Update()
    {
        if (detector.GetComponent<detector>().block) { //bloque le tournage de la poignée si le joueur a perdu
            return;
        }
        if (manager.UpPressed)
        {
            this.GetComponent<SpriteRenderer>().sprite = keySprites[0];
        }

        if (manager.RightPressed)
        {
            this.GetComponent<SpriteRenderer>().sprite = keySprites[1];
        }

        if (manager.DownPressed)
        {
            this.GetComponent<SpriteRenderer>().sprite = keySprites[2];
        }

        if (manager.LeftPressed)
        {
            this.GetComponent<SpriteRenderer>().sprite = keySprites[3];
        }
        
    }
}
