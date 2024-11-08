using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurRoom : RoomBase
{
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
        Debug.Log("Minotaur Room Searched");
    }

    public override void OnRoomExited()
    {
        Debug.Log("Minotaur Room Exited");
    }
}
