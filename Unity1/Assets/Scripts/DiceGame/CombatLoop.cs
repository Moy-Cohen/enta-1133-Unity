using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatLoop : MonoBehaviour
{
    private EnemyBase _enemy;
    private PlayerBase _player;
    private PlayerController _playerController;

    public bool _isCombatActive = false;


    public void Start()
    {
        _enemy = Object.FindAnyObjectByType<EnemyBase>();
        _player = Object.FindAnyObjectByType<PlayerBase>();
        _playerController = Object.FindAnyObjectByType<PlayerController>();
    }

    public void Update()
    {
        do
        {
            CombatRound();
        }
        while (_isCombatActive == true);
    }

    public void CombatRound()
    {
        
    }

    public void EnemyTurn()
    {
        _enemy.DoAttack();
    }

    public void PlayerTurn()
    {
        
    }

    
}
