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
    private gameManager manager;

    public Sprite[] circleSprites;
    void Start()
    {
        numberOfRestantArrow = numberOfArrow;
        Debug.Log(info);
        manager = GameObject.Find("dontDestroy").gameObject.GetComponent<dontDestroy>().save.GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (info != null)
        {
            if (Input.GetKey(KeyCode.UpArrow) && nbArrow==0)
            {
                Destroy(info.gameObject);
                numberOfArrow-=1;
                this.GetComponent<SpriteRenderer>().sprite = circleSprites[1];
            }

            if (Input.GetKey(KeyCode.RightArrow) && nbArrow==1)
            {
                Destroy(info.gameObject);
                numberOfArrow-=1;
                //numberOfRestantArrow-=1;
                this.GetComponent<SpriteRenderer>().sprite = circleSprites[2];
            }

            if (Input.GetKey(KeyCode.DownArrow) && nbArrow==2)
            {
                Destroy(info.gameObject);
                numberOfArrow-=1;
                //numberOfRestantArrow-=1;
                this.GetComponent<SpriteRenderer>().sprite = circleSprites[3];
            }

            if (Input.GetKey(KeyCode.LeftArrow) && nbArrow==3)
            {
                Destroy(info.gameObject);
                numberOfArrow-=1;
                //numberOfRestantArrow-=1;
                this.GetComponent<SpriteRenderer>().sprite = circleSprites[4];
            }
        }

        if (numberOfArrow == 0)
        {
                manager.victory();         
        }

        //Debug.Log(numberOfRestantArrow);
        //Debug.Log(numberOfArrow);
        
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

    public void theEnd(){
        Debug.Log("defeat");
        this.GetComponent<SpriteRenderer>().sprite = circleSprites[5];
        //Time.timeScale = 0;
        manager.Invoke("defeat", 2f);
    }
    
    public IEnumerator gameOver(){
        Debug.Log("defeeeeat");
        this.GetComponent<SpriteRenderer>().sprite = circleSprites[5];
        //Time.timeScale = 0;
        yield return new WaitForSeconds(2f);
        Debug.Log("teststtt");
        manager.defeat();
        //yield return new WaitForSeconds(2f);
    }
}
