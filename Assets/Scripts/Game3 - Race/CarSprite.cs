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
    public AudioSource audioSource;
    public AudioClip win;
    public AudioClip loose;
    public AudioClip crash;
    public AudioClip carTouched;
    public float volume=0.5f;
    public GameObject mainCamera;

    public GameObject[] tire;

    public GameObject defeatScene;
    public GameObject blackScreen;


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

            StartCoroutine(GameOver());

        }
        
        if (isBlinking) StartCoroutine(Blink());

    }
    
    void OnTriggerEnter2D(Collider2D collision) {
        //LOSE
        if (collision.tag == "Obstacle") {
            audioSource.PlayOneShot(carTouched, volume);
            StartCoroutine(LoseLife());
            StartCoroutine(DestroyObstacle(collision.gameObject));
        }

        //WIN
        if (collision.tag == "Win") {
            StartCoroutine(Win());
        }

    }

    public IEnumerator Blink() {
        isBlinking = false;
        carSprite.color = new Color(1, 1, 1, 0); 
        yield return new WaitForSeconds(0.15f);
        carSprite.color = defaultColor;
    }

    public IEnumerator DestroyObstacle(GameObject obstacle) {
        obstacle.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0, 0, 1); 
        yield return new WaitForSeconds(0.15f);
        obstacle.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.15f);
        obstacle.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0, 0, 1); 
        yield return new WaitForSeconds(0.15f);
        obstacle.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        Destroy(obstacle);
    }

    public IEnumerator LoseLife() {
        if (justLost == false) {
            lives--;
            justLost = true;
            Destroy(tire[lives]);
            movePoint.GetComponent<CarController>().speed = 9.5f;
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

    public IEnumerator GameOver() {
        audioSource.PlayOneShot(loose, volume);
        audioSource.PlayOneShot(crash, volume);
        yield return new WaitForSeconds(1f);
        defeatScene.SetActive(true);
        gameObject.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(2f);
        volume = 0;
        manager.defeat();
        yield return null;
    }

    public IEnumerator Win() {
        audioSource.PlayOneShot(win, volume);
        yield return new WaitForSeconds(1f);
        manager.victory();
        yield return null;
    }

}
