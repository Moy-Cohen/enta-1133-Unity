using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuUI : MonoBehaviour
{
    private UIManager _uiManager;

    private void Start()
    {
        _uiManager = Object.FindAnyObjectByType<UIManager>();
    }
    public void ContinueButton()
    {
        gameObject.SetActive(false);
        _uiManager.OpenInGameHUD();
    }
}
