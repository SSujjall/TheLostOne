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
    public void NewGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("GameScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public static implicit operator MainMenu(PauseMenu v)
    {
        throw new NotImplementedException();
    }
}
