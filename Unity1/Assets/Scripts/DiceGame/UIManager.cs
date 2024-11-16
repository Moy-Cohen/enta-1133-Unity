using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
   private void ButtonStartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelTesting");
    }
}
