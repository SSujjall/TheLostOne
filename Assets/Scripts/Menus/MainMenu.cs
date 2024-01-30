using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance { get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public bool isPaused;

    public void StartNewGame()
    {
        Time.timeScale = 1.0f;
        isPaused = true;
        SceneManager.LoadScene("GameScene");
    }

    public void ResumeGame()
    {
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!isPaused)
            {
                ResumeGame();
            }
        }
    }
}
