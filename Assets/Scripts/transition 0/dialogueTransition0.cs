using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueTransition0 : MonoBehaviour
{
    // Start is called before the first frame update
    
    int language = 1;
    public Dialogue[] dialogues;
    public Dialogue[] dialogues_en;
    public bool nextDialogue;
    int numberDialogue;
    private gameManager manager;
    bool disableSpace;
    int length;
   
    void Start()
    {
        disableSpace = false;
        manager = GameObject.Find("dontDestroy").gameObject.GetComponent<dontDestroy>().save.GetComponent<gameManager>();
        nextDialogue = false;
        numberDialogue=0;
        if (dialogues.Length > numberDialogue)
        {
            if (language == 0){
                DialogueManager.instance.startDialogue(dialogues[0]);
            }
            else{
                DialogueManager.instance.startDialogue(dialogues_en[0]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            manager.nextGame(); 
            return; 
        }


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

            if (language == 0){
                length = dialogues.Length;
            }
            else{
                length = dialogues_en.Length;
            }
            
            if (length > numberDialogue)
            {
                
                if (language == 0)  DialogueManager.instance.startDialogue(dialogues[numberDialogue]);
                else DialogueManager.instance.startDialogue(dialogues_en[numberDialogue]);
            }

            else 
            {
                manager.nextGame();
                return; 
            }
        }
    }

    void ableSpace()
    {
        disableSpace = false;
    }
}
