using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonsRoom : RoomBase
{
    [SerializeField] EnemyBase EnemySkeleton;

    private PlayerController _playerController;

    public void Start()
    {
        _playerController = Object.FindAnyObjectByType<PlayerController>();
        
    }

    public void SpawnSkeleton()
    {
        if (_playerController._facingDirection == Direction.North)
        {
            var skeletonInstance = Instantiate(EnemySkeleton, transform);
            skeletonInstance.transform.localPosition = new Vector3(0, 0.1f, 2);
            skeletonInstance.transform.Rotate(0, 180, 0);
        }
        else if (_playerController._facingDirection == Direction.East)
        {
            var skeletonInstance = Instantiate(EnemySkeleton, transform);
            skeletonInstance.transform.localPosition = new Vector3(2, 0.1f, 0);
            skeletonInstance.transform.Rotate(0, -90, 0);
        }
        else if (_playerController._facingDirection == Direction.South)
        {
            var skeletonInstance = Instantiate(EnemySkeleton, transform);
            skeletonInstance.transform.localPosition = new Vector3(0, 0.1f, -2);
        }
        else if (_playerController._facingDirection == Direction.West)
        {
            var skeletonInstance = Instantiate(EnemySkeleton, transform);
            skeletonInstance.transform.localPosition = new Vector3(-2, 0.1f, 0);
            skeletonInstance.transform.Rotate(0, 90, 0);
        }

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
            _isSearched = true;
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
