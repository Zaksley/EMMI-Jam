using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public int numberGame;
    public int numberTransition;
    public int lastTransition;
    //public int lastGame;

    public bool UpPressed;
    public bool RightPressed;
    public bool LeftPressed; 
    public bool DownPressed; 

    public bool UpPressedAnytime; 
    public bool RightPressedAnytime;
    public bool LeftPressedAnytime;
    public bool DownPressedAnytime; 
    public bool isAzerty; 

    private void Start() 
    {
        isAzerty = false; 
    }

    private void Update() 
    {
        // Unchanged
        RightPressed = Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D); 
        DownPressed = Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S); 

        RightPressedAnytime = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D); 
        DownPressedAnytime = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S); 

        if (isAzerty) 
        {
            UpPressed = Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z); 
            LeftPressed = Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Q); 

            UpPressedAnytime = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z); 
            LeftPressedAnytime = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q); 
        }
        else 
        {
            UpPressed = Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W); 
            LeftPressed = Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A); 

            UpPressedAnytime = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W); 
            LeftPressedAnytime = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A); 
        }
    }
    
    
    public void victory()
    {
        //lastTransition = 1
        if (numberGame == 1)
        {
            numberTransition = 2;
            SceneManager.LoadScene("Transition2");
        }

        if (numberGame == 2)
        {
            numberTransition = 6;
            SceneManager.LoadScene("Transition6");
        }

        if (numberGame == 3)
        {
            if (lastTransition == 10)
            {
                numberTransition = 4;
                SceneManager.LoadScene("Transition4");
            }
            if (lastTransition == 14)
            {
                numberTransition = 8;
                SceneManager.LoadScene("Transition8");
            }
        }

        if (numberGame == 4)
        {
            if (lastTransition == 1)
            {
                numberTransition = 10;
                SceneManager.LoadScene("Transition10");
            }
            if (lastTransition == 6)
            {
                numberTransition = 14;
                SceneManager.LoadScene("Transition14");
            }
        }


        if (numberGame == 5)
        {
            if (lastTransition == 9)
            {
                numberTransition = 12;
                SceneManager.LoadScene("Transition12");
            }
            if (lastTransition == 13)
            {
                numberTransition = 16;
                SceneManager.LoadScene("Transition16");
            }
        }
        
    }

    public void defeat()
    {
        if (numberGame == 1)
        {
            numberTransition = 1;
            SceneManager.LoadScene("Transition1");
        }

        else{
            if (numberGame == 2)
            {
                numberTransition = 5;
                SceneManager.LoadScene("Transition5");
            }

            else{
                if (numberGame == 3)
                {
                    if (lastTransition == 10)
                    {
                        numberTransition = 3;
                        SceneManager.LoadScene("Transition3");
                    }
                    if (lastTransition == 14)
                    {
                        numberTransition = 7;
                        SceneManager.LoadScene("Transition7");
                    }
                }

                else{
                    if (numberGame == 4)
                        {
                            if (lastTransition == 1)
                            {
                                numberTransition = 9;
                                SceneManager.LoadScene("Transition9");
                            }
                            if (lastTransition == 6)
                            {
                                numberTransition = 13;
                                SceneManager.LoadScene("Transition13");
                            }
                        }
                    else {
                        if (numberGame == 5)
                        {
                            if (lastTransition == 9)
                            {
                                numberTransition = 11;
                                SceneManager.LoadScene("Transition11");
                            }
                            if (lastTransition == 13)
                            {
                                numberTransition = 15;
                                SceneManager.LoadScene("Transition15");
                            }
                        }
                    }
                }
            }
        }
    }

    public void nextGame()
    {
        if (numberTransition == 0)
        {
            lastTransition = 0;
            numberGame = 1;
            SceneManager.LoadScene("safe");
        }

        else{
            if (numberTransition == 1)
            {
                lastTransition = 1;
                numberGame = 4;
                SceneManager.LoadScene("Jeu4");
            }

            else{
                if (numberTransition == 2)
                {
                    lastTransition = 2;
                    numberGame = 2;
                    SceneManager.LoadScene("Jeu2");
                }

                else{
                    if (numberTransition == 3)
                    {
                        lastTransition = 3;
                        numberTransition = 100;
                        SceneManager.LoadScene("Crédits");
                    }

                    else{
                        if (numberTransition == 4)
                        {
                            lastTransition = 4;
                            numberTransition = 100;
                            SceneManager.LoadScene("Crédits");
                        }

                        else{
                            if (numberTransition == 5)
                            {
                                lastTransition = 5;
                                numberTransition = 100;
                                SceneManager.LoadScene("Crédits");
                            }

                            else{
                                if (numberTransition == 6)
                                {
                                    lastTransition = 6;
                                    numberGame = 4;
                                    SceneManager.LoadScene("Jeu4");
                                }

                                else{
                                    if (numberTransition == 7)
                                    {
                                        lastTransition = 7;
                                        numberTransition = 100;
                                        SceneManager.LoadScene("Crédits");
                                    }

                                    else{
                                        if (numberTransition == 8)
                                        {
                                            lastTransition = 8;
                                            numberTransition = 100;
                                            SceneManager.LoadScene("Crédits");
                                        }

                                        else{
                                            if (numberTransition == 100)
                                            {
                                                lastTransition = -1;
                                                numberTransition = 0;
                                                SceneManager.LoadScene("Beginning");
                                            }

                                            else
                                            {
                                                if (numberTransition == 9)
                                                {
                                                    lastTransition = 9;
                                                    numberGame = 5;
                                                    SceneManager.LoadScene("Game5");
                                                }
                                                else{
                                                    if (numberTransition == 10)
                                                    {
                                                        lastTransition = 10;
                                                        numberGame = 3;
                                                        SceneManager.LoadScene("Jeu3");
                                                    }
                                                    else{
                                                        if (numberTransition ==11)
                                                        {
                                                            lastTransition = 11;
                                                            numberTransition = 100;
                                                            SceneManager.LoadScene("Crédits");
                                                        }
                                                        else {
                                                            if (numberTransition ==12)
                                                                {
                                                                    lastTransition = -1;
                                                                    numberTransition = 100;
                                                                    SceneManager.LoadScene("Crédits");
                                                                }
                                                            else {
                                                                if (numberTransition ==13)
                                                                {
                                                                    lastTransition = 13;
                                                                    numberGame = 5;
                                                                    SceneManager.LoadScene("Game5");
                                                                }
                                                                else {
                                                                    if (numberTransition ==14)
                                                                    {
                                                                        lastTransition = 14;
                                                                        numberGame = 3;
                                                                        SceneManager.LoadScene("Jeu3");
                                                                    }  
                                                                    else{
                                                                        if (numberTransition ==15)
                                                                        {
                                                                            lastTransition = -1;
                                                                            numberTransition = 100;
                                                                            SceneManager.LoadScene("Crédits");
                                                                        }    
                                                                        else{
                                                                            if (numberTransition ==16)
                                                                            {
                                                                                lastTransition = 16;
                                                                                numberTransition = 100;
                                                                                SceneManager.LoadScene("Crédits");
                                                                            }    
                                                                        }
                                                                    }  
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

    }

}
