using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpidersRoom : RoomBase
{
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
        Debug.Log("Spiders Room Searched");
    }

    public override void OnRoomExited()
    {
        Debug.Log("Spiders Room Exited");
    }
}
