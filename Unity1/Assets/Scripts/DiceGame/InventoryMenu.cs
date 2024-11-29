using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    private UIManager _uiManager;

    private void Start()
    {
        _uiManager = Object.FindAnyObjectByType<UIManager>();
    }
    public void CloseInventoryButton()
    {
        gameObject.SetActive(false);
        _uiManager.OpenInGameHUD();
    }
}
