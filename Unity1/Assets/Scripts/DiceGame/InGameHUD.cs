using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameHUD : MonoBehaviour
{
    private UIManager _uiManager;
    private PlayerBase _player;

    [SerializeField] public Image Healthbar;
    [SerializeField] private Text Timer;
    [SerializeField] private TextMeshProUGUI _healthText;
    private bool _gamePaused = false;
    private float _timer = 0.0f;

    public void Setup()
    {
        _uiManager = Object.FindAnyObjectByType<UIManager>();
        _player = Object.FindAnyObjectByType<PlayerBase>();
        //if (_player != null)
        //{
        //    Debug.LogError("player is not found");
        //}
        if(Timer != null)
        {
            Timer.text = "Timer Paused";
            Timer.color = Color.red;

        }
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
        if(Timer != null)
        Timer.text = $"{_timer,0:0.000}";
    }


    public void OnGamePaused()
    {
        _gamePaused = true;
    }

    public void OnHealthChange(float currentHealth, float maxHealth)
    {
        //_healthText.text = currentHealth.ToString();
        Healthbar.fillAmount = _player.currentHealth / _player.maxHealth;
         
    }
    
}
