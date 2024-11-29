using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurBase : EnemyBase
{
    private UIManager _uiManager;
    private PlayerBase _playerBase;

    public bool _isAlive = true;

    public override void Start()
    {
        _isAlive = true;
        _uiManager = Object.FindAnyObjectByType<UIManager>();
    }

    public void Update()
    {
       if(enemyMaxHp <= 0)
        {
            _isAlive=false;
        }

       if (_isAlive == false)
        {
            _uiManager.OpenGameWonMenu();
        }
    }

    public override void DoAttack()
    {
        int attackDamage = Random.Range(0, enemyMaxAttackDamage);
        _playerBase.currentHealth -= attackDamage;
    }
}
