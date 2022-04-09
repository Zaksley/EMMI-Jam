using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleNumbers : MonoBehaviour
{

    float sizeBox = 1.1f;

    private List<BoxCollider2D> boxes; 

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
                box.offset = new Vector2(j*sizeBox, -i*sizeBox); 
                box.size = new Vector2(sizeBox, sizeBox); 

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
                    controller.UpdateText(i+1);
                }
            }

            if (GameObject.ReferenceEquals(validate, cubeHit.collider))
            {
                controller.checkCode(); 
            }
            else if (GameObject.ReferenceEquals(delete, cubeHit.collider))
            {
                controller.DeleteText();
            }
        }
 
    }

    /* DEBUG
    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.green; 

        for(int i=0; i<boxes.Count; i++)
        {
            Gizmos.DrawCube(boxes[i].transform.position, new Vector3(sizeBox, sizeBox, 0f));
        }
    }*/
    
}
