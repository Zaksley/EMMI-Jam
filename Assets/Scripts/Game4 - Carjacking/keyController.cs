using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyController : MonoBehaviour
{

    public Sprite[] keySprites;
    public GameObject detector;

    void Update()
    {
        if (detector.GetComponent<detector>().block) { //bloque le tournage de la poignée si le joueur a perdu
            return;
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z))
        {
            this.GetComponent<SpriteRenderer>().sprite = keySprites[0];
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            this.GetComponent<SpriteRenderer>().sprite = keySprites[1];
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            this.GetComponent<SpriteRenderer>().sprite = keySprites[2];
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Q))
        {
            this.GetComponent<SpriteRenderer>().sprite = keySprites[3];
        }
        
    }
}
