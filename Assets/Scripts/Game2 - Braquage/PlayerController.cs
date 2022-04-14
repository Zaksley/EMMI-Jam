using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb; 


    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed; 
    private Vector2 moveDirection; 
    private gameManager manager;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        manager = GameObject.Find("dontDestroy").gameObject.GetComponent<dontDestroy>().save.GetComponent<gameManager>();
    
    }

    private void ProcessInputs()
    {
        moveDirection.x = 0;
        moveDirection.y = 0;

        if (manager.UpPressedAnytime)           moveDirection.y = 1f;
        else if (manager.DownPressedAnytime)    moveDirection.y = -1f;

        if (manager.RightPressedAnytime)        moveDirection.x = 1f;
        else if (manager.LeftPressedAnytime)    moveDirection.x = -1f;

    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs(); 
        MoveAnimation();
    }
    void FixedUpdate() 
    {
        Move(); 
    }

    private void Move() 
    {
        if (moveDirection.x != 0 && moveDirection.y != 0)
        {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, 0);
        }
        else 
        {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        }
        
    }

    public void MoveAnimation() {
        if (moveDirection.x != 0 || moveDirection.y != 0) //is running
        {
            GetComponent<Animator>().SetBool("isRunning", true);
            GetComponent<Animator>().SetFloat("RX", moveDirection.x);
            GetComponent<Animator>().SetFloat("RY", moveDirection.y);
            GetComponent<Animator>().SetFloat("IX", moveDirection.x);
            GetComponent<Animator>().SetFloat("IY", moveDirection.y);

        } else { //is idle
            GetComponent<Animator>().SetBool("isRunning", false);
        }
    }

}
