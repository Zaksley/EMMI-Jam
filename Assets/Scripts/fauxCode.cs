using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fauxCode : MonoBehaviour
{
    // Start is called before the first frame update
    private gameManager manager;
    void Start()
    {
        manager = GameObject.Find("dontDestroy").gameObject.GetComponent<dontDestroy>().save.GetComponent<gameManager>();
        Debug.Log(manager);
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown("space"))
        {
            manager.nextGame();
        } 

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("ouai");
            manager.victory();
        }

        if (Input.GetKey(KeyCode.Z))
        {
            manager.defeat();
        } 
    }
}
