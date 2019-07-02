using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Button backToMainMenuButton;
    public GameObject optionsMenu;

    public void Awake()
    {
        backToMainMenuButton.onClick.AddListener(BackToMainMenu);
    }

        public void BackToMainMenu()
    {
        optionsMenu.SetActive(false);
    }
}
