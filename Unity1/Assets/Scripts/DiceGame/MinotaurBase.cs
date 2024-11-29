using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurBase : EnemyBase
{
    private UIManager _uiManager;

    public bool _isAlive = true;

    public void Start()
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
}
