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
    public GameObject carSprite;


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
        mainCamera.transform.Translate(Vector3.up * Time.deltaTime * speed);

        //MOVEMENT
        if(transform.position.x == carSprite.transform.position.x) {
            if (Input.GetKeyDown(KeyCode.RightArrow)) { //LE JOUEUR VA À DROITE
                if (transform.position == rightLane.transform.position) { // si on est déjà à droite
                    //bruit de blocage + crash
                    StartCoroutine(carSprite.GetComponent<CarSprite>().LoseLife());
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
                    //bruit de blocage + crash
                    StartCoroutine(carSprite.GetComponent<CarSprite>().LoseLife());
                    //Debug.Log("Nombre de vie : " + carSprite.GetComponent<CarSprite>().lives);
                }
            }
        }

    }
    

}
