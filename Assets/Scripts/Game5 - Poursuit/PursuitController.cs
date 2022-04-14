using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitController : MonoBehaviour
{
    private  float goSide = 0f;
    
    [SerializeField] private float timeMove = 0.3f; 
    private float currentTimeMove; 
    private bool canMove; 
    [SerializeField] private float moveY = 0.5f; 
    [SerializeField] private float moveX = 0.5f;
    private Vector3 translationUp; 
    private Vector3 translationSide; 

    public Animator animator; 
    private gameManager manager; 

    // Start is called before the first frame update
    void Start()
    {
        translationUp = new Vector3(0, moveY, 0); 
        currentTimeMove = 0f; 

        manager = GameObject.Find("dontDestroy").gameObject.GetComponent<dontDestroy>().save.GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        **   DEBUG **
        */
        if (Input.GetKeyDown(KeyCode.P)) manager.victory(); 
        else if (Input.GetKeyDown(KeyCode.M)) manager.defeat();

        setupMove(); 

        // Move side or up
        if (canMove)
        {
            if (manager.RightPressed)       goSide = 1f; 
            else if (manager.LeftPressed)   goSide = -1f; 
            else                            goSide = 0; 

            if (manager.UpPressed)
            {
                animator.SetFloat("Speed", 1f);
                Move(translationUp); 
                currentTimeMove = timeMove; 
            }
            else if (goSide != 0)
            {
                translationSide = new Vector3(moveX * goSide, 0, 0);
                Move(translationSide); 
                currentTimeMove = timeMove; 
            }
        }

        
        if (manager.UpPressed)   animator.SetFloat("Speed", 1f);
        else                     animator.SetFloat("Speed", 0);
        

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

    void Move(Vector3 t) 
    {
        transform.Translate(t, Space.World); 
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Car") || other.gameObject.CompareTag("Tree"))
        {
            manager.defeat();
        }
        else if (other.gameObject.CompareTag("Win"))
        {
            manager.victory(); 
        }
    }
}
