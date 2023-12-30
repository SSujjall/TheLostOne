using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public bool isPaused;


    public void Resume()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
        SceneManager.LoadScene("GameScene");
    }

    public void exitGame()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                SceneManager.LoadScene("PauseMenu");
                isPaused = true;
            }
        }
    }
}
