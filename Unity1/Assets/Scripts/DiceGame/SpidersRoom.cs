using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpidersRoom : RoomBase
{

    [SerializeField] EnemyBase EnemySpider;

    private PlayerController _playerController;

    public void Start()
    {
        _playerController = Object.FindAnyObjectByType<PlayerController>();
        
    }

    public void SpawnSpiders()
    {
        if (_playerController._facingDirection == Direction.North)
        {
            var spiderInstance = Instantiate(EnemySpider, transform);
            spiderInstance.transform.localPosition = new Vector3(0, 0.1f, 1.5f);
            spiderInstance.transform.Rotate(0, 180, 0);
        }
        else if (_playerController._facingDirection == Direction.East)
        {
            var spiderInstance = Instantiate(EnemySpider, transform);
            spiderInstance.transform.localPosition = new Vector3(1.5f, 0.1f, 0);
            spiderInstance.transform.Rotate(0, -90, 0);
        }
        else if (_playerController._facingDirection == Direction.South)
        {
            var spiderInstance = Instantiate(EnemySpider, transform);
            spiderInstance.transform.localPosition = new Vector3(0, 0.1f, -1.5f); 
        }
        else if (_playerController._facingDirection == Direction.West)
        {
            var spiderInstance = Instantiate(EnemySpider, transform);
            spiderInstance.transform.localPosition = new Vector3(-1.5f, 0.1f, 0);
            spiderInstance.transform.Rotate(0, 90, 0);
        }


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
            _isSearched = true;
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
