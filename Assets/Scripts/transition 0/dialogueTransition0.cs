using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueTransition0 : MonoBehaviour
{
    // Start is called before the first frame update
   
    public Dialogue[] dialogues;
    public bool nextDialogue;
    int numberDialogue;
    private gameManager manager;
    bool disableSpace;
   
    void Start()
    {
        disableSpace = false;
        manager = GameObject.Find("dontDestroy").gameObject.GetComponent<dontDestroy>().save.GetComponent<gameManager>();
        nextDialogue = false;
        numberDialogue=0;
        if (dialogues.Length > numberDialogue)
        {
            DialogueManager.instance.startDialogue(dialogues[0]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && !disableSpace)
        {
           DialogueManager.instance.DisplayNextSentence();
           disableSpace = true;
           Invoke("ableSpace", 0.5f);
        } 
        if (nextDialogue)
        {
            nextDialogue = false;
            numberDialogue+=1;
            if (dialogues.Length > numberDialogue)
            {
                DialogueManager.instance.startDialogue(dialogues[numberDialogue]);
            }
            else 
            {
                manager.nextGame();
            }
        }
    }

    void ableSpace()
    {
        disableSpace = false;
    }
}
