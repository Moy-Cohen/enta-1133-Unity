using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    private InGameHUD _inGameHud;
    private UIManager _uiManager;
    private EnemyBase _enemyBase;


    [SerializeField] public float maxHealth = 50;
    [SerializeField] public float currentHealth = 50;

    public void Start()
    {
        _inGameHud = Object.FindAnyObjectByType<InGameHUD>();
        _uiManager = Object.FindAnyObjectByType<UIManager>();
        _enemyBase = Object.FindAnyObjectByType<EnemyBase>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            currentHealth -= 5;
            Debug.Log(currentHealth.ToString());
            OnDamageTaken();
        }

        if (currentHealth <= 0)
        {
            _uiManager.OpenGameLostMenu();
        }
    }

    public void OnDamageTaken()
    {
        _inGameHud.OnHealthChange(currentHealth,maxHealth);
    }


    
}
