using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonsRoom : RoomBase
{
    [SerializeField] EnemyBase EnemySkeleton;

    private PlayerController _playerController;
    private CombatLoop _combatLoop;
    private EnemyBase _currentSkeleton;

    public void Start()
    {
        _playerController = Object.FindAnyObjectByType<PlayerController>();
        _combatLoop = Object.FindAnyObjectByType<CombatLoop>();
    }

    public void SpawnSkeleton()
    {
        var skeletonInstance = Instantiate(EnemySkeleton, transform);
        if (_playerController._facingDirection == Direction.North)
        {
            skeletonInstance.transform.localPosition = new Vector3(0, 0.1f, 2);
            skeletonInstance.transform.Rotate(0, 180, 0);
        }
        else if (_playerController._facingDirection == Direction.East)
        {
            skeletonInstance.transform.localPosition = new Vector3(2, 0.1f, 0);
            skeletonInstance.transform.Rotate(0, -90, 0);
        }
        else if (_playerController._facingDirection == Direction.South)
        {
            skeletonInstance.transform.localPosition = new Vector3(0, 0.1f, -2);
        }
        else if (_playerController._facingDirection == Direction.West)
        {
            
            skeletonInstance.transform.localPosition = new Vector3(-2, 0.1f, 0);
            skeletonInstance.transform.Rotate(0, 90, 0);
        }
        _combatLoop._enemy = skeletonInstance;
    }
    public override void SetRoomLocation(Vector2 coordinates)
    {
        base.SetRoomLocation(coordinates);
    }

    public override void OnRoomEntered()
    {
        Debug.Log("Skeletons Room Entered");
    }

    public override void OnRoomSearched()
    {
        if(_isSearched == false)
        {
            Debug.Log("Skeletons Room Searched");
            SpawnSkeleton();
            _combatLoop.Setup();
            _isSearched = true;
            _combatLoop._isCombatActive = true;
            _combatLoop._state = CombatLoop.State.waitingForPlayer;
            _combatLoop.OnCombatStarted();
        }
        else
        {
            Debug.Log("Skeletons Room Was Searched Already");
        }
        
    }

    public override void OnRoomExited()
    {
        Debug.Log("Skeletons Room Exited");
    }
}
