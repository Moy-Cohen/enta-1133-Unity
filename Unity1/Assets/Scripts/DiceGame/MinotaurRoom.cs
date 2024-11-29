using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurRoom : RoomBase
{
    [SerializeField] EnemyBase EnemyMinotaur;
    private CombatLoop _combatLoop;

    private PlayerController _playerController;

    public void Start()
    {
        _playerController = Object.FindAnyObjectByType<PlayerController>();
        _combatLoop = Object.FindAnyObjectByType<CombatLoop>();
    }

    public void SpawnMinotaur()
    {
        if (_playerController._facingDirection == Direction.North)
        {
            var minotaurInstance = Instantiate(EnemyMinotaur, transform);
            minotaurInstance.transform.localPosition = new Vector3(0, 0.1f, 2);
            minotaurInstance.transform.Rotate(0, 180, 0);
        }
        else if (_playerController._facingDirection == Direction.East)
        {
            var minotaurInstance = Instantiate(EnemyMinotaur, transform);
            minotaurInstance.transform.localPosition = new Vector3(2, 0.1f, 0);
            minotaurInstance.transform.Rotate(0, -90, 0);
        }
        else if (_playerController._facingDirection == Direction.South)
        {
            var minotaurInstance = Instantiate(EnemyMinotaur, transform);
            minotaurInstance.transform.localPosition = new Vector3(0, 0.1f, -2);
        }
        else if (_playerController._facingDirection == Direction.West)
        {
            var minotaurInstance = Instantiate(EnemyMinotaur, transform);
            minotaurInstance.transform.localPosition = new Vector3(-2, 0.1f, 0);
            minotaurInstance.transform.Rotate(0, 90, 0);
        }

    }
    public override void SetRoomLocation(Vector2 coordinates)
    {
        base.SetRoomLocation(coordinates);
    }

    public override void OnRoomEntered()
    {
        Debug.Log("Minotaur Room Entered");
    }

    public override void OnRoomSearched()
    {
        if(_isSearched == false)
        {
            Debug.Log("Minotaur Room Searched");
            SpawnMinotaur();
            _isSearched = true;
        }
        else
        {
            Debug.Log("Minotaur Room Was Searched Already");
        }

    }

    public override void OnRoomExited()
    {
        Debug.Log("Minotaur Room Exited");
    }
}
