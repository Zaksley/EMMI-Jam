using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleNumbers : MonoBehaviour
{

    [SerializeField] private float sizeBox = 1.1f;
    [SerializeField] private float boxOffsetX = -2f;
    [SerializeField] private float boxOffsetY = 2f;

    private List<BoxCollider2D> boxes = new List<BoxCollider2D>(); 
    public AudioSource audioSource;
    public float volume=0.5f;
    [SerializeField] private Sprite[] digicodes; 
    private int digicodeValidate = 10;
    private int digicodeDelete = 11; 
    [SerializeField] private float durationChangeSprite = 0.5f;
    private float changeSprite = 0f;  
    public AudioClip digitSound; 
    public AudioClip soundDelete; 

    private NumbersController controller; 

    [SerializeField] private BoxCollider2D validate;
    [SerializeField] private BoxCollider2D delete; 

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<NumbersController>(); 

        int count = 0;
        boxes = new List<BoxCollider2D>(); 

        for(int i=-1; i<2; i++)
        {
            for(int j=-1; j<2; j++)
            {
                BoxCollider2D box = gameObject.AddComponent<BoxCollider2D>(); 
                box.offset = new Vector2(j*(sizeBox+0.2f) + boxOffsetX, -i*(sizeBox+0.085f) + boxOffsetY); 
                box.size = new Vector2(sizeBox+0.1f, sizeBox); 

                boxes.Add(box);
                count++; 
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cubeRay = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D cubeHit = Physics2D.Raycast(cubeRay, Vector2.zero);

        if (cubeHit && Input.GetMouseButtonDown(0))
        {
            for(int i=0; i<boxes.Count; i++)
            {
                if (GameObject.ReferenceEquals(boxes[i], cubeHit.collider))
                {  
                    audioSource.PlayOneShot(digitSound, volume);
                    controller.UpdateText(i+1);
                    ChangeSprite(i+1);
                }
            }

            if (GameObject.ReferenceEquals(validate, cubeHit.collider))
            {
                controller.checkCode(); 
                ChangeSprite(digicodeValidate);
            }
            else if (GameObject.ReferenceEquals(delete, cubeHit.collider))
            {
                audioSource.PlayOneShot(soundDelete, volume);
                controller.DeleteText();
                ChangeSprite(digicodeDelete); 
            }
        }

        if (changeSprite <= 0 && (GetComponent<SpriteRenderer>().sprite != digicodes[0]))
        {
            GetComponent<SpriteRenderer>().sprite = digicodes[0]; 
        }
        else 
        {
            changeSprite -= 1 * Time.deltaTime; 
        }

    }

    void ChangeSprite(int index)
    {
        GetComponent<SpriteRenderer>().sprite = digicodes[index];
        changeSprite = durationChangeSprite; 
    }
}
