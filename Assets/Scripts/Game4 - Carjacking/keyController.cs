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
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.GetComponent<SpriteRenderer>().sprite = keySprites[0];
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.GetComponent<SpriteRenderer>().sprite = keySprites[1];
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.GetComponent<SpriteRenderer>().sprite = keySprites[2];
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.GetComponent<SpriteRenderer>().sprite = keySprites[3];
        }
        
    }
}
