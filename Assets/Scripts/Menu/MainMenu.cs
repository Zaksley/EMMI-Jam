using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{


    public void StartGame() {
        StartCoroutine(StartGameCoroutine());
    }

    public void QuitGame() {
        StartCoroutine(QuitGameCoroutine());
    }

    public void ShowCredits() {
        StartCoroutine(ShowCreditsCoroutine());
    }

    public IEnumerator StartGameCoroutine() {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Beginning");
    }

    public IEnumerator QuitGameCoroutine() {
        yield return new WaitForSeconds(0.5f);
        Application.Quit();
    }

    public IEnumerator ShowCreditsCoroutine() {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Crédits");
    }
}
