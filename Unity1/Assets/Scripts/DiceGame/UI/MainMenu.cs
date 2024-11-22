using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void ButtonStartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelTesting");
        gameObject.SetActive(false);
        
    }
}
