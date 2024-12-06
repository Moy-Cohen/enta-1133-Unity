using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GelatinousCubeRoom : RoomBase
{

    [SerializeField] EnemyBase EnemySlime;


    private CombatLoop _combatLoop;
    private PlayerController _playerController;

    private EnemyBase _currEnemey;
    public void Start()
    {
        _playerController = Object.FindAnyObjectByType<PlayerController>();
        _combatLoop = Object.FindAnyObjectByType<CombatLoop>();
    }

    public void SpawnSlime()
    {
        var slimeInstance = Instantiate(EnemySlime, transform);
        if (_playerController._facingDirection == Direction.North)
        {
            
            slimeInstance.transform.localPosition = new Vector3(0, 0.1f, 1.5f);
            slimeInstance.transform.Rotate(0, 180, 0);
        }
        else if (_playerController._facingDirection == Direction.East)
        {
            
            slimeInstance.transform.localPosition = new Vector3(1.5f, 0.1f, 0);
            slimeInstance.transform.Rotate(0, -90, 0);
        }
        else if (_playerController._facingDirection == Direction.South)
        {
            slimeInstance.transform.localPosition = new Vector3(0, 0.1f, -1.5f);
        }
        else if (_playerController._facingDirection == Direction.West)
        {
            slimeInstance.transform.localPosition = new Vector3(-1.5f, 0.1f, 0);
            slimeInstance.transform.Rotate(0, 90, 0);
        }
        _combatLoop._enemy = slimeInstance;
    }
    public override void SetRoomLocation(Vector2 coordinates)
    {
        base.SetRoomLocation(coordinates);
    }

    public override void OnRoomEntered()
    {
        Debug.Log("Gelatinous Cube Room Entered");
    }

    public override void OnRoomSearched()
    {
        if (_isSearched == false)
        {
            Debug.Log("Gelatinous Cube Room Searched");
            SpawnSlime();
            _combatLoop.Setup();
            _isSearched = true;
            _combatLoop._isCombatActive = true;
            _combatLoop._state = CombatLoop.State.waitingForPlayer;
            _combatLoop.OnCombatStarted();
        }
        else
        {
            Debug.Log("Gelatinous Cube Room Was Searched Already");
        }

    }

    public override void OnRoomExited()
    {
        Debug.Log("Gelatinous Cube Room Exited");
    }
}
