using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("exit");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void StartGame() 
    {
        SceneManager.LoadScene("OpeningScene");
    }

    void Update()
    {
        Debug.Log("hello");
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }
}
