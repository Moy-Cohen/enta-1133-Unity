using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureRoom : RoomBase
{

    [SerializeField] private ItemBase[] TreasurePrefabs;
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
            for (int x = 0; x < 3; x++)
            {
                var treasureInstance = Instantiate(TreasurePrefabs[Random.Range(0, TreasurePrefabs.Length)]);
                treasureInstance.transform.localPosition = new Vector3(1, 1, x);
                
            }
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
