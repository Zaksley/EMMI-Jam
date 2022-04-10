using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitController : MonoBehaviour
{

    private float goUp = 0f; 
    
    private float timeMove = 0.2f; 
    private float currentTimeMove; 
    private bool canMove; 
    [SerializeField] private float moveY = 0.5f; 
    private Vector3 translation; 

    // Start is called before the first frame update
    void Start()
    {
        translation = new Vector3(0, moveY, 0); 
        currentTimeMove = 0f; 
    }

    // Update is called once per frame
    void Update()
    {
        goUp = Input.GetAxisRaw("Vertical"); 

        setupMove(); 

        if (canMove && (goUp == 1))
        {
            Move(); 
            currentTimeMove = timeMove; 
        }

    }

    void setupMove()
    {
        if (currentTimeMove > 0)
        {
            currentTimeMove -= 1 * Time.deltaTime;
            canMove = false; 
        }
        else 
        {
            canMove = true; 
        }
    }

    void Move() 
    {
        transform.Translate(translation, Space.World); 
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("test");
        if (other.gameObject.CompareTag("Car"))
        {
            Debug.Log("player dead");
        }
    }
}
