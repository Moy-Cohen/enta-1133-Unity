using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureRoom : RoomBase
{

    [SerializeField] private ItemBase[] TreasurePrefabs;

    private PlayerInventory _inventory;

    public void Start()
    {
        _inventory = FindAnyObjectByType<PlayerInventory>();
    }

    public override void SetRoomLocation(Vector2 coordinates)
    {
        base.SetRoomLocation(coordinates);
    }

    public override void OnRoomEntered()
    {
        Debug.Log("Treasure Room Entered");
        
    }

    public override void OnRoomSearched()
    {
        //Spawn 3 treasure items at random if the room has not been searched yet 
        if (_isSearched == false)
        {
            Debug.Log("Treasure Room Searched");
            _inventory.TreasureSearch();
            _isSearched = true;
        }
        //If the room has been searched display a room searched message
        else
        {
            Debug.Log("Treasure Room Was Searched Already");
        }
    }

    public override void OnRoomExited()
    {
        Debug.Log("Treasure Room Exited");
    }
}
