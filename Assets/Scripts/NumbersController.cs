using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class NumbersController : MonoBehaviour
{

    public GameObject Number1; 
    public GameObject Number2; 
    public GameObject Number3; 
    public GameObject Number4; 

    private TMP_Text Text1; 
    private TMP_Text Text2;
    private TMP_Text Text3; 
    private TMP_Text Text4; 

    private List<TMP_Text> Texts; 
    [SerializeField] private string code = "6417"; 
    private string testCode; 

    private int turn; 
    [SerializeField] private int maxNumbers = 4; 

    private float currentTime = 0f; 
    [SerializeField] private float flashTime = 0.05f; 
    private bool flashIndicator = false; 
    private int nbFlash = 0;
    [SerializeField] private int MaxNbFlash = 3; 

    // Start is called before the first frame update
    void Start()
    {   
        testCode = ""; 

        turn = 0; 
        Text1 = Number1.GetComponentInChildren<TextMeshPro>(); 
        Text2 = Number2.GetComponentInChildren<TextMeshPro>(); 
        Text3 = Number3.GetComponentInChildren<TextMeshPro>(); 
        Text4 = Number4.GetComponentInChildren<TextMeshPro>(); 

        Texts = new List<TMP_Text>() {Text1, Text2, Text3, Text4}; 
    }

    void Update() 
    {
        if (nbFlash > 0)
        {
            if(flashIndicator)
            {
                disableText();
            }
            else
            {
                enableText(); 
            }
        }

    }
    
    public void UpdateText(int number) 
    {
        if (turn < maxNumbers) 
        {
            string snumber = number.ToString(); 
            Texts[turn].text = snumber; 
            turn++; 
            addTextCode(snumber);
        }
    }


    public void DeleteText()
    {
        if (turn > 0)
        {
            turn--;
            Texts[turn].text = "*"; 
            deleteTextCode(); 
        }
    }

    // handle string code 
    private void addTextCode(string number)
    {
        if (testCode.Length < maxNumbers)
            testCode += number; 
    }

    private void deleteTextCode()
    {
        if (testCode.Length > 0)
            testCode = testCode.Remove(testCode.Length - 1);
    }

    public void checkCode()
    {
        if (string.Equals(testCode, code))
        {
            // Change scene
            Debug.Log("Je me barre au niveau 2");
        }
        else 
        {
            // TODO: Display error 
            // Sound erreur 
            errorCode();

        }
    }

    private void disableText()
    {
        currentTime -= 1 * Time.deltaTime; 

        // End disable
        if (currentTime <= 0f)
        {
            currentTime = 0f; 
            flashIndicator = false; 
            setText(true); 
            if (nbFlash > 0) nbFlash--; 
        }
    }

    private void enableText()
    {
        currentTime += 1 * Time.deltaTime;

        // End enable
        if (currentTime >= flashTime)
        {
            currentTime = flashTime; 
            flashIndicator = true; 
            setText(false);
        }
    }

    private void setText(bool enableText)
    {
        for(int i=0; i<Texts.Count; i++)
        {
            Texts[i].GetComponentInParent<MeshRenderer>().enabled = enableText; 
        }
    }

    private void errorCode()
    {
        nbFlash = MaxNbFlash;
        flash(); 
    }

    private void flash()
    {
        setText(false);
        currentTime = flashTime;
        flashIndicator = true; 
    }
}
