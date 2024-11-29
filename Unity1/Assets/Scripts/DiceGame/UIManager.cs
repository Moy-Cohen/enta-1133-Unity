using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Layouts;

    private enum MenuLayouts
    {
        MainMenu = 0,
        GamePlay = 1,
        InGameHUD = 2,
        InventoryUI = 3,
        PauseMenu = 4,
        GameLost = 5,
        GameWon = 6,
    }

    private void SetupMenus(PlayerBase player)
    {
        //_inGameHud.Setup();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("pressed E");
            OpenInventoryUI();
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("pressed Escape");
            OpenPauseMenu();
        }
    }
    private void SetLayout(MenuLayouts layout)
    {
        for(int i = 0; i < Layouts.Length; i++)
        {
            Layouts[i].SetActive((int)layout == i);
        }
    }

    public void OpenMainMenu()
    {
        SetLayout(MenuLayouts.MainMenu);
    }

    public void OpenGamePlayMenu()
    {
        SetLayout(MenuLayouts.GamePlay);
    }

    public void OpenInGameHUD()
    {
        SetLayout(MenuLayouts.InGameHUD);
    }

    public void OpenInventoryUI()
    {
        SetLayout(MenuLayouts.InventoryUI);
    }

    public void OpenPauseMenu()
    {
        SetLayout(MenuLayouts.PauseMenu);
    }

    public void OpenGameLostMenu()
    {
        SetLayout(MenuLayouts.GameLost);
    }

    public void OpenGameWonMenu()
    {
        SetLayout(MenuLayouts.GameWon);
    }
}
