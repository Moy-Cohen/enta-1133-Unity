using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameHUD : MonoBehaviour
{
    private UIManager _uiManager;
    private PlayerBase _player;

    [SerializeField] public Image Healthbar;
    [SerializeField] private Text Timer;

    private bool _gamePaused = false;
    private float _timer = 0.0f;

    public void Start()
    {
        _uiManager = Object.FindAnyObjectByType<UIManager>();
        _player = Object.FindAnyObjectByType<PlayerBase>();
        if (_player == null)
        {
            Debug.LogError("player is not found");
        }

        Timer.text = "Timer Paused";
        Timer.color = Color.red;
    }

    public void OnStartGame()
    {
        _gamePaused = false;
        Healthbar.fillAmount = 1;
    }

    public void Update()
    {
        if (_gamePaused)
        {
            return;
        }

        _timer += Time.deltaTime;
        Timer.text = $"{_timer,0:0.000}";
    }


    public void OnGamePaused()
    {
        _gamePaused = true;
    }

    public void OnHealthChange(float currentHealth, float maxHealth)
    {
        float imageFill = _player.currentHealth / _player.maxHealth;
        Healthbar.fillAmount = imageFill;
    }
    
}
