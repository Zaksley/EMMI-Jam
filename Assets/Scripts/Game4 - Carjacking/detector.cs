using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detector : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip win;
    public AudioClip good; 
    public float volume=1f;

    public int numberOfArrow;

    int numberOfRestantArrow;
 
    int nbArrow = -1;
    Collider2D info;
    private gameManager manager;

    public Sprite[] circleSprites;

    bool block;
    void Start()
    {
        block = false;
        numberOfRestantArrow = numberOfArrow;
        Debug.Log(info);
        manager = GameObject.Find("dontDestroy").gameObject.GetComponent<dontDestroy>().save.GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(block);
        if (block) {
            return;
        }
        if (info != null)
        {
            if (Input.GetKey(KeyCode.UpArrow) && nbArrow==0 && !block)
            {
                Destroy(info.gameObject);
                numberOfArrow-=1;
                this.GetComponent<SpriteRenderer>().sprite = circleSprites[1];
                audioSource.PlayOneShot(good, volume);
            }

            if (Input.GetKey(KeyCode.RightArrow) && nbArrow==1 && !block)
            {
                Destroy(info.gameObject);
                numberOfArrow-=1;
                //numberOfRestantArrow-=1;
                this.GetComponent<SpriteRenderer>().sprite = circleSprites[2];
                audioSource.PlayOneShot(good, volume);
            }

            if (Input.GetKey(KeyCode.DownArrow) && nbArrow==2 && !block)
            {
                Destroy(info.gameObject);
                numberOfArrow-=1;
                //numberOfRestantArrow-=1;
                this.GetComponent<SpriteRenderer>().sprite = circleSprites[3];
                audioSource.PlayOneShot(good, volume);
            }

            if (Input.GetKey(KeyCode.LeftArrow) && nbArrow==3 && !block)
            {
                Destroy(info.gameObject);
                numberOfArrow-=1;
                //numberOfRestantArrow-=1;
                this.GetComponent<SpriteRenderer>().sprite = circleSprites[4];
                audioSource.PlayOneShot(good, volume);
            }
        }

        if (numberOfArrow == 0)
        {
                audioSource.PlayOneShot(win, volume);
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
        if (!block) {
            block = true;
            Debug.Log("defeeeeat");
            this.GetComponent<SpriteRenderer>().sprite = circleSprites[5];
            //Time.timeScale = 0;
            yield return new WaitForSeconds(2f);
            Debug.Log("teststtt");
            manager.defeat();
        }

        //yield return new WaitForSeconds(2f);
    }
}
