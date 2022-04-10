using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detector : MonoBehaviour
{
    // Start is called before the first frame update

    public int numberOfArrow;

    int numberOfRestantArrow;
 
    int nbArrow = -1;
    Collider2D info;
    void Start()
    {
        numberOfRestantArrow = numberOfArrow;
        Debug.Log(info);
    }

    // Update is called once per frame
    void Update()
    {
        if (info != null)
        {
            if (Input.GetKey(KeyCode.UpArrow) && nbArrow==0)
            {
                Destroy(info.gameObject);
                //numberOfRestantArrow-=1;
                numberOfArrow-=1;
            }

            if (Input.GetKey(KeyCode.RightArrow) && nbArrow==1)
            {
                Destroy(info.gameObject);
                numberOfArrow-=1;
                //numberOfRestantArrow-=1;
                //this.GetComponent<SpriteRenderer>().sprite = keySprites[1];
            }

            if (Input.GetKey(KeyCode.DownArrow) && nbArrow==2)
            {
                Destroy(info.gameObject);
                numberOfArrow-=1;
                //numberOfRestantArrow-=1;
                //this.GetComponent<SpriteRenderer>().sprite = keySprites[2];
            }

            if (Input.GetKey(KeyCode.LeftArrow) && nbArrow==3)
            {
                Destroy(info.gameObject);
                numberOfArrow-=1;
                //numberOfRestantArrow-=1;
                //this.GetComponent<SpriteRenderer>().sprite = keySprites[3];
            }
        }

        if (numberOfRestantArrow == 0)
        {
            if (numberOfArrow <= 0)
            {
                Debug.Log("victoire");
            }
            else
            {
                Debug.Log("deafeat");
            }
                
        }

        Debug.Log(numberOfRestantArrow);
        Debug.Log(numberOfArrow);
        
    }
    void OnTriggerEnter2D(Collider2D infoCollision) // le type de la variable est Collision
    {
        info = infoCollision;
        if (infoCollision.gameObject.tag == "upArrow")
            {
                nbArrow = 0;
            }

        if (infoCollision.gameObject.tag == "rightArrow")
            {
                nbArrow = 1;
            }

        if (infoCollision.gameObject.tag == "downArrow")
            {
                nbArrow = 2;
            }
            
        if (infoCollision.gameObject.tag == "leftArrow")
            {
                nbArrow = 3;
            }
    }

    private void OnTriggerExit2D(Collider2D other) {
        numberOfRestantArrow-=1;
    }
    
}
