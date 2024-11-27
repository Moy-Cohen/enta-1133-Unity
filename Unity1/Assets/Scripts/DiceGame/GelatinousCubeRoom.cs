using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GelatinousCubeRoom : RoomBase
{

    [SerializeField] EnemyBase EnemySlime;

    private PlayerController _playerController;


    public void Start()
    {
        _playerController = Object.FindAnyObjectByType<PlayerController>();
    }

    public void SpawnSlime()
    {
        if (_playerController._facingDirection == Direction.North)
        {
            var slimeInstance = Instantiate(EnemySlime, transform);
            slimeInstance.transform.localPosition = new Vector3(0, 0.1f, 1.5f);
            slimeInstance.transform.Rotate(0, 180, 0);
        }
        else if (_playerController._facingDirection == Direction.East)
        {
            var slimeInstance = Instantiate(EnemySlime, transform);
            slimeInstance.transform.localPosition = new Vector3(1.5f, 0.1f, 0);
            slimeInstance.transform.Rotate(0, -90, 0);
        }
        else if (_playerController._facingDirection == Direction.South)
        {
            var slimeInstance = Instantiate(EnemySlime, transform);
            slimeInstance.transform.localPosition = new Vector3(0, 0.1f, -1.5f);
        }
        else if (_playerController._facingDirection == Direction.West)
        {
            var slimeInstance = Instantiate(EnemySlime, transform);
            slimeInstance.transform.localPosition = new Vector3(-1.5f, 0.1f, 0);
            slimeInstance.transform.Rotate(0, 90, 0);
        }
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
            _isSearched = true;
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
