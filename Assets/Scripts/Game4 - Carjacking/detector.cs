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
 
    int nbArrow = -1;
    Collider2D info;
    private gameManager manager;

    public Sprite[] circleSprites;

    public bool block;

    float y_begin = 44f;
    float intervalle = 2.86f;
    //int number_arows =  20;

    public GameObject[] arrows; 
    void Start()
    {
        block = false;
        Debug.Log(info);
        manager = GameObject.Find("dontDestroy").gameObject.GetComponent<dontDestroy>().save.GetComponent<gameManager>();
        spawn_keys();
    }

    // Update is called once per frame
    void Update()
    {
        if (block) {
            return;
        }


        if (info != null)
        {
            if (manager.UpPressed && nbArrow==0 && !block)
            {
                Destroy(info.gameObject);
                numberOfArrow-=1;
                this.GetComponent<SpriteRenderer>().sprite = circleSprites[1];
                audioSource.PlayOneShot(good, volume);
            } else if (manager.UpPressed && nbArrow!=0 && !block) {
                StartCoroutine(gameOver());
            }

            if (manager.RightPressed && nbArrow==1 && !block)
            {
                Destroy(info.gameObject);
                numberOfArrow-=1;
                this.GetComponent<SpriteRenderer>().sprite = circleSprites[2];
                audioSource.PlayOneShot(good, volume);
            } else if (manager.RightPressed && nbArrow!=1 && !block) {
                StartCoroutine(gameOver());
            }

            if (manager.DownPressed && nbArrow==2 && !block)
            {
                Destroy(info.gameObject);
                numberOfArrow-=1;
                this.GetComponent<SpriteRenderer>().sprite = circleSprites[3];
                audioSource.PlayOneShot(good, volume);
            } else if (manager.DownPressed && nbArrow!=2 && !block) {
                StartCoroutine(gameOver());
            }

            if (manager.LeftPressed && nbArrow==3 && !block)
            {
                Destroy(info.gameObject);
                numberOfArrow-=1;
                this.GetComponent<SpriteRenderer>().sprite = circleSprites[4];
                audioSource.PlayOneShot(good, volume);
            } else if (manager.LeftPressed && nbArrow!= 3 && !block) {
                StartCoroutine(gameOver());
            }
        }

        if (numberOfArrow == 0)
        {
                audioSource.PlayOneShot(win, volume);
                manager.victory();         
        }
        
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
    
    public IEnumerator gameOver(){
        if (!block) {
            block = true;
            this.GetComponent<SpriteRenderer>().sprite = circleSprites[5];
            yield return new WaitForSeconds(2f);
            manager.defeat();
        }

    }

    void spawn_keys(){
        int i;
        int randInt;
        for (i=0;i<numberOfArrow - 1; i++){
            randInt = Random.Range(0, 4);
            GameObject instantiatedObject = Instantiate(arrows[randInt],new Vector3(5f,y_begin + i*intervalle,0f),Quaternion.identity);
        }
    }
}
