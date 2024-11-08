using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonsRoom : RoomBase
{
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
        Debug.Log("Skeletons Room Searched");
    }

    public override void OnRoomExited()
    {
        Debug.Log("Skeletons Room Exited");
    }
}
