using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatLoop : MonoBehaviour
{
    //Reference to the other classes 
    public EnemyBase _enemy;
    private PlayerBase _player;
    private PlayerController _playerController;
    public State _state;

    public bool _isCombatActive;
    /*private bool _enemyTurn = false;
    private bool _playerTurn = true;*/

    public enum State
    {
        waitingForPlayer,
        busy,
    }

    public void Setup()
    {
        _state = State.waitingForPlayer;
        /*_enemyTurn = false;
        _playerTurn = true;*/
        
    }

    public void Start()
    {
        // Find th object type of the classes needed 
        _enemy = Object.FindAnyObjectByType<EnemyBase>();
        _player = Object.FindAnyObjectByType<PlayerBase>();
        _playerController = Object.FindAnyObjectByType<PlayerController>();
        _state = State.waitingForPlayer;
        
    }

    public void Awake()
    {
        
    }

    public void OnCombatStarted()
    {
        Debug.Log("Combat Started");
        while (_isCombatActive)
        {
            if (_state == State.waitingForPlayer)
            {
                PlayerTurn();
                _state = State.busy;
            }
            else if (_state == State.busy)
            {
                EnemyTurn();
                _state = State.waitingForPlayer;
            }
        }
    }

    public void CombatRound()
    {
        
        
    }

    

    public void EnemyTurn()
    {
        if (_state == State.busy)
        {
            Debug.Log("Enemy Turn Begins");
            _enemy.DoAttack();
            Debug.Log($"Enemy dealt {_enemy.attackDamage} points of damage");
            _player.currentHealth -= _enemy.attackDamage;
            if (_player.currentHealth <= 0)
            {
                _isCombatActive = false;
                Debug.Log("CombatOver");
                Destroy(_enemy);
            }
            Debug.Log("Enemy Turn Ends");

            /*_enemyTurn = false;
            _playerTurn = true;*/
        }

    }

    public void PlayerTurn()
    {
        if(_state == State.waitingForPlayer)
        {
            Debug.Log("Player Turn Begins");
            _state = State.busy;
            if (Input.GetKeyDown(KeyCode.M))
            {
                _enemy.enemyCurrentHp -= _player.attackDamage;
                Debug.Log($"Player dealt {_player.attackDamage} points of damage");
                Debug.Log("Player Turn Ends");
                //_state = State.busy;
                if (_enemy.enemyCurrentHp <= 0)
                {
                    _isCombatActive = false;
                    Debug.Log("CombatOver");
                    Destroy(_enemy);
                }
                _state = State.busy;
                /*_playerTurn = false;
                _enemyTurn = true;*/
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                _player.currentHealth += _player.healPlayer;
                Debug.Log($"Player healed {_player.healPlayer} HP");
                Debug.Log("Player Turn Ends");
                //_state = State.busy;
                /*_playerTurn = false;
                _enemyTurn = true;*/
            }
        } 
    }

}
