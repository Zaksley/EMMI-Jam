using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSprite : MonoBehaviour
{
    public GameObject movePoint;
    public float step;
    public int lives = 3;
    private gameManager manager;
    public bool justLost = false;
    public bool isBlinking = false;
    SpriteRenderer carSprite;
    Color defaultColor;
    public GameObject mainCamera;


    void Start() {
        manager = GameObject.Find("dontDestroy").gameObject.GetComponent<dontDestroy>().save.GetComponent<gameManager>();
        carSprite = GetComponent<SpriteRenderer>();
        defaultColor = carSprite.color;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePoint.transform.position, step * Time.deltaTime);
        //FINAL GAME OVER
        if (lives == 0) {
            manager.defeat();
        }
        
        if (isBlinking) StartCoroutine(Blink());

    }
        void OnTriggerEnter2D(Collider2D collision) {
        //LOSE
        if (collision.tag == "Obstacle") {
            StartCoroutine(LoseLife());
        }

        //WIN
        if (collision.tag == "Win") {
            manager.victory();

        }

    }

    public IEnumerator Blink() {
        isBlinking = false;
        carSprite.color = new Color(1, 1, 1, 0); 
        yield return new WaitForSeconds(0.15f);
        carSprite.color = defaultColor;
    }

    public IEnumerator LoseLife() {
        if (justLost == false) {
            lives--;
            justLost = true;
            StartCoroutine(mainCamera.GetComponent<CameraShake>().Shake(1f, 0.1f));
            isBlinking = true;
            yield return new WaitForSeconds(0.25f);
            isBlinking = true;
            yield return new WaitForSeconds(0.25f);
            isBlinking = true;
            yield return new WaitForSeconds(0.25f);
            isBlinking = true;
            yield return new WaitForSeconds(0.25f);
            justLost = false;
        }
        yield return null;
    }


}
