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
        Debug.Log("Treasure Room Searched");
        for (int x = 0; x < 3; x++)
        {
            var treasureInstance = Instantiate(TreasurePrefabs[Random.Range(0, TreasurePrefabs.Length)]);
            treasureInstance.transform.localPosition = new Vector3(1, 1, x);
        }

    }

    public override void OnRoomExited()
    {
        Debug.Log("Treasure Room Exited");
    }
}
