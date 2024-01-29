using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void StartGame()
    {
        // Validar en cuanto se haya completado el juego.
        // SceneManager.LoadScene("GameplayScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
