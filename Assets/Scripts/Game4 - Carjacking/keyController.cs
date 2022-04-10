using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyController : MonoBehaviour
{
    // Start is called before the first frame update

    public Sprite[] keySprites;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
