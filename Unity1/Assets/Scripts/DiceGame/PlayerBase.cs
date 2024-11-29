using JetBrains.Annotations;
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
    public int attackDamage = 10;
    public int healPlayer = 15;

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
            currentHealth -= 10;
            Debug.Log(currentHealth.ToString());
            OnDamageTaken();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            currentHealth += 10;
            if (currentHealth >= maxHealth)
            {
                currentHealth = maxHealth;
            }
            Debug.Log(currentHealth.ToString());
            OnHeal();
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

    public void OnHeal()
    {
        _inGameHud.OnHealthChange(currentHealth, maxHealth);
    }

    public void Attack()
    {
        
    }

    public void Heal()
    {

    }
    
}
