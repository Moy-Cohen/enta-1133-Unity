using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatRoom : RoomBase
{
    [SerializeField] private EnemyBase[] EnemyPrefabs;

   

    public void Start()
    {
        
    }

    public override void SetRoomLocation(Vector2 coordinates)
    {
        base.SetRoomLocation(coordinates);
    }

    public override void OnRoomEntered()
    {
        Debug.Log("Combat Room Entered");
    }

    public override void OnRoomSearched()
    {
        Debug.Log("Combat Room Searched");
    }

    public override void OnRoomExited()
    {
        Debug.Log("Combat Room Exited");
    }
}
