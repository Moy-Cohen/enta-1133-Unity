using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpidersRoom : RoomBase
{

    [SerializeField] EnemyBase EnemySpider;

    private CombatLoop _combatLoop;
    private PlayerController _playerController;
    private EnemyBase _currEnemy;

    public void Start()
    {
        _playerController = Object.FindAnyObjectByType<PlayerController>();
        _combatLoop = Object.FindAnyObjectByType<CombatLoop>();
        
    }

    public void SpawnSpiders()
    {
        var spiderInstance = Instantiate(EnemySpider, transform);
        if (_playerController._facingDirection == Direction.North)
        {
            
            spiderInstance.transform.localPosition = new Vector3(0, 0.1f, 1.5f);
            spiderInstance.transform.Rotate(0, 180, 0);
        }
        else if (_playerController._facingDirection == Direction.East)
        {
            spiderInstance.transform.localPosition = new Vector3(1.5f, 0.1f, 0);
            spiderInstance.transform.Rotate(0, -90, 0);
        }
        else if (_playerController._facingDirection == Direction.South)
        {
            spiderInstance.transform.localPosition = new Vector3(0, 0.1f, -1.5f); 
        }
        else if (_playerController._facingDirection == Direction.West)
        {
            spiderInstance.transform.localPosition = new Vector3(-1.5f, 0.1f, 0);
            spiderInstance.transform.Rotate(0, 90, 0);
        }

        _combatLoop._enemy = spiderInstance;
    }
    public override void SetRoomLocation(Vector2 coordinates)
    {
        base.SetRoomLocation(coordinates);
    }

    public override void OnRoomEntered()
    {
        Debug.Log("Spiders Room Entered");
    }

    public override void OnRoomSearched()
    {
        if(_isSearched == false)
        {
            Debug.Log("Spiders Room Searched");
            SpawnSpiders();
            _combatLoop.Setup();
            _isSearched = true;
            _combatLoop._isCombatActive = true;
            _combatLoop._state = CombatLoop.State.waitingForPlayer;
            _combatLoop.OnCombatStarted();
            
        }
        else
        {
            Debug.Log("Spiders Room Was Searched Already");
        }

    }

    public override void OnRoomExited()
    {
        Debug.Log("Spiders Room Exited");
    }
}
