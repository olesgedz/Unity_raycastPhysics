﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button newGameButton;
    public Button loadGameButton;
    public Button exitButton;

    public string newGameSceneName;

    public GameObject optionsMenu;

    public void Awake()
    {
        newGameButton.onClick.AddListener(NewGame);
        loadGameButton.onClick.AddListener(OpenLoadGameMenu);
        exitButton.onClick.AddListener(ExitGame);
        optionsMenu.SetActive(false);
    }

    public void NewGame()
    {
        //SceneManager.LoadScene(newGameSceneName);
        FindObjectOfType<ProgressSceneLoader>().LoadScene(newGameSceneName);
    }

    public void OpenLoadGameMenu()
    {
        optionsMenu.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
