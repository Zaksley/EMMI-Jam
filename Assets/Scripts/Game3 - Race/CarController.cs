using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public GameObject rightLane;
    public GameObject middleLane;
    public GameObject leftLane;
    private GameObject mainCamera;
    public int speed;
    private gameManager manager;
    public int lives = 3;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = middleLane.transform.position;
        manager = GameObject.Find("dontDestroy").gameObject.GetComponent<dontDestroy>().save.GetComponent<gameManager>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        //GO FORWARD
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        rightLane.transform.position = new Vector3(rightLane.transform.position.x, transform.position.y, rightLane.transform.position.z);
        middleLane.transform.position = new Vector3(middleLane.transform.position.x, transform.position.y, middleLane.transform.position.z);
        leftLane.transform.position = new Vector3(leftLane.transform.position.x, transform.position.y, leftLane.transform.position.z);
        mainCamera.transform.Translate(Vector3.up * Time.deltaTime * speed);


        //MOVEMENT
        if (Input.GetKeyDown(KeyCode.RightArrow)) { //LE JOUEUR VA À DROITE
            if (transform.position == rightLane.transform.position) { // si on est déjà à droite
                //bruit de blocage ?
            } else if (transform.position == middleLane.transform.position) { // si on est au milieu
                transform.position = rightLane.transform.position;
            } else if (transform.position == leftLane.transform.position) { //si on est à gauche
                transform.position = middleLane.transform.position;
            }
        } else if (Input.GetKeyDown(KeyCode.LeftArrow)) { // LE JOUEUR VA À GAUCHE
            if (transform.position == rightLane.transform.position) { // si on est à droite
                transform.position = middleLane.transform.position;
            } else if (transform.position == middleLane.transform.position) { // si on est au milieu
                transform.position = leftLane.transform.position;
            } else if (transform.position == leftLane.transform.position) { //si on est déjà à gauche
                //bruit de blocage ?
            }
        }

        //FINAL GAME OVER
        if (lives == 0) {
            manager.defeat();
        }

    }
    
    void OnTriggerEnter2D(Collider2D collision) {
        //LOSE
        if (collision.tag == "Obstacle") {
            lives -= 1;
            Debug.Log("Nombre de vie : " + lives);

        }

        //WIN
        if (collision.tag == "Win") {
            Debug.Log("bravooo");
            manager.victory();

        }
    }
}
