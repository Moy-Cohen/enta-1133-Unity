using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatLoop : MonoBehaviour
{
    //Reference to the other classes 
    public EnemyBase _enemy;
    private PlayerBase _player;
    private PlayerController _playerController;

    public bool _isCombatActive = false;
    private bool _enemyTurn = true;
    private bool _playerTurn = false;


    public void Start()
    {
        // Find th object type of the classes needed 
        _enemy = Object.FindAnyObjectByType<EnemyBase>();
        _player = Object.FindAnyObjectByType<PlayerBase>();
        _playerController = Object.FindAnyObjectByType<PlayerController>();
    }

    public void Update()
    {
        if(_isCombatActive == true)
        {
            
            _playerController._isRotating = true;
            _playerController._isMoving = true;
            CombatRound();
        }
        
        
    }

    public void CombatRound()
    {
        if (_enemyTurn == true && _playerTurn == false)
        {
            EnemyTurn();
        }
        if (_playerTurn == true && _enemyTurn == false)
        {
            PlayerTurn();
        }
        if (_enemy.enemyCurrentHp <= 0 || _player.currentHealth <= 0)
        {
            _isCombatActive = false;
            Debug.Log("CombatOver");
        }
    }

    

    public void EnemyTurn()
    {
        _enemy.DoAttack();
        _enemyTurn = false;
        _playerTurn = true;
    }

    public void PlayerTurn()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            _enemy.enemyCurrentHp -= _player.attackDamage;
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            _player.currentHealth += _player.healPlayer;
        }
        _playerTurn = false;
        _enemyTurn = true;

    }




}
