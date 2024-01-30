using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject creditsCanvas;
    public void StartGame()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Credits()
    {
        creditsCanvas.SetActive(true);
    }

    public void BackMainMenu()
    {
        creditsCanvas.SetActive(false);
    }
}
