using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb; 


    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed; 
    private Vector2 moveDirection; 



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    private void ProcessInputs()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal"); 
        moveDirection.y = Input.GetAxisRaw("Vertical"); 
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs(); 
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

}
