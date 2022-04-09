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
            if (lastTransition == 1)
            {
                numberTransition = 4;
                SceneManager.LoadScene("Transition4");
            }
            if (lastTransition == 6)
            {
                numberTransition = 8;
                SceneManager.LoadScene("Transition8");
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

        if (numberGame == 2)
        {
            numberTransition = 5;
            SceneManager.LoadScene("Transition5");
        }

        if (numberGame == 3)
        {
            if (lastTransition == 1)
            {
                numberTransition = 3;
                SceneManager.LoadScene("Transition3");
            }
            if (lastTransition == 6)
            {
                numberTransition = 7;
                SceneManager.LoadScene("Transition7");
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

        if (numberTransition == 1)
        {
            lastTransition = 1;
            numberGame = 3;
            SceneManager.LoadScene("Jeu3");
        }

        if (numberTransition == 2)
        {
            lastTransition = 2;
            numberGame = 2;
            SceneManager.LoadScene("Jeu2");
        }

        if (numberTransition == 3)
        {
            lastTransition = 3;
            numberTransition = 100;
            SceneManager.LoadScene("End");
        }

        if (numberTransition == 4)
        {
            lastTransition = 4;
            numberTransition = 100;
            SceneManager.LoadScene("End");
        }

        if (numberTransition == 5)
        {
            lastTransition = 5;
            numberTransition = 100;
            SceneManager.LoadScene("End");
        }

        if (numberTransition == 6)
        {
            lastTransition = 6;
            numberGame = 3;
            SceneManager.LoadScene("Jeu3");
        }
        
        if (numberTransition == 7)
        {
            lastTransition = 7;
            numberTransition = 100;
            SceneManager.LoadScene("End");
        }

        if (numberTransition == 8)
        {
            lastTransition = 8;
            numberTransition = 100;
            SceneManager.LoadScene("End");
        }

        if (numberTransition == 100)
        {
            lastTransition = -1;
            numberTransition = 0;
            SceneManager.LoadScene("Beginning");
        }
    }

}
