using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatLoop : MonoBehaviour
{
    //Reference to the other classes 
    public EnemyBase _enemy;
    private PlayerBase _player;
    private PlayerController _playerController;
    private State _state;

    public bool _isCombatActive = false;
    private bool _enemyTurn = false;
    private bool _playerTurn = true;

    private enum State
    {
        waitingForPlayer,
        busy,
    }

    public void Setup()
    {
        _state = State.waitingForPlayer;
        _enemyTurn = false;
        _playerTurn = true;
    }

    public void Start()
    {
        // Find th object type of the classes needed 
        _enemy = Object.FindAnyObjectByType<EnemyBase>();
        _player = Object.FindAnyObjectByType<PlayerBase>();
        _playerController = Object.FindAnyObjectByType<PlayerController>();
        _state = State.waitingForPlayer;
    }

    public void Update()
    {
        if(_isCombatActive == true)
        {
            CombatRound();
        }
        

    }

    public void CombatRound()
    {
        if (_state == State.waitingForPlayer)
        {
            _state = State.busy;
            PlayerTurn();
        }
        else if (_state == State.busy)
        {
            _state = State.waitingForPlayer;
            EnemyTurn();
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
        Debug.Log($"Enemy dealt {_enemy.attackDamage} points of damage");
        _enemyTurn = false;
        _playerTurn = true;
    }

    public void PlayerTurn()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            _enemy.enemyCurrentHp -= _player.attackDamage;
            Debug.Log($"Player dealt {_player.attackDamage} points of damage");
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            _player.currentHealth += _player.healPlayer;
            Debug.Log($"Player healed {_player.healPlayer} HP");
        }
        _playerTurn = false;
        _enemyTurn = true;

    }




}
