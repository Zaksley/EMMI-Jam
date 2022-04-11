using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public GameObject rightLane;
    public GameObject middleLane;
    public GameObject leftLane;
    private GameObject mainCamera;
    public float speed;
    public GameObject carSprite;
    public float turnSize;
    public float acceleration;
    public AudioSource audioSource;
    public AudioClip left;
    public AudioClip right;
    public AudioClip crash;

    public float volume=1f;


    void Start()
    {
        transform.position = middleLane.transform.position;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        //GO FORWARD
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        rightLane.transform.position = new Vector3(rightLane.transform.position.x, transform.position.y, rightLane.transform.position.z);
        middleLane.transform.position = new Vector3(middleLane.transform.position.x, transform.position.y, middleLane.transform.position.z);
        leftLane.transform.position = new Vector3(leftLane.transform.position.x, transform.position.y, leftLane.transform.position.z);
        mainCamera.transform.position = new Vector3(0, middleLane.transform.position.y + 2, -10);
        speed = speed * acceleration;

        //MOVEMENT
        if(transform.position.x == carSprite.transform.position.x) {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) { //LE JOUEUR VA À DROITE
                audioSource.PlayOneShot(right, volume);
                StartCoroutine(TurnAnimation(-1f));
                if (transform.position == rightLane.transform.position) { // si on est déjà à droite
                    //bruit de blocage
                    audioSource.PlayOneShot(crash, volume = 1f);
                    StartCoroutine(carSprite.GetComponent<CarSprite>().LoseLife());
                } else if (transform.position == middleLane.transform.position) { // si on est au milieu
                    transform.position = rightLane.transform.position;
                } else if (transform.position == leftLane.transform.position) { //si on est à gauche
                    transform.position = middleLane.transform.position;
                }
            } else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Q)) { // LE JOUEUR VA À GAUCHE
                audioSource.PlayOneShot(left, volume);
                StartCoroutine(TurnAnimation(1f));
                if (transform.position == rightLane.transform.position) { // si on est à droite
                    transform.position = middleLane.transform.position;
                } else if (transform.position == middleLane.transform.position) { // si on est au milieu
                    transform.position = leftLane.transform.position;
                } else if (transform.position == leftLane.transform.position) { //si on est déjà à gauche
                    //bruit de blocage
                    audioSource.PlayOneShot(crash, volume = 1f);
                    StartCoroutine(carSprite.GetComponent<CarSprite>().LoseLife());
                }
            }
        }
    }

    public IEnumerator TurnAnimation(float angle) {
        carSprite.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180 + (angle * turnSize - angle * turnSize/2)));
        yield return new WaitForSeconds(.1f);
        carSprite.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180 + angle));
        yield return new WaitForSeconds(.1f);
        carSprite.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180 + (angle * turnSize - angle * turnSize/2)));
        yield return new WaitForSeconds(.1f);
        carSprite.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
    }
    

}
