using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] public InGameHUD _inGameHUD;
    public void ButtonStartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelTesting");
        gameObject.SetActive(false);

        
    }

    public void ButtonQuitGame()
    {
        Application.Quit();
    }

    public void PlayAgainButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenuScene");
        gameObject.SetActive(false);
    }

}
