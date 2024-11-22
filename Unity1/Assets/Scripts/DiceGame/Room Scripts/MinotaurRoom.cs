using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurRoom : RoomBase
{
    [SerializeField] EnemyBase EnemyMinotaur;


    public void Start()
    {
        
    }

    public void SpawnMinotaur()
    {
        var minotaurInstance = Instantiate(EnemyMinotaur, transform);
        minotaurInstance.transform.localPosition = new Vector3(0, 0 , -2);
    }
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
        SpawnMinotaur();
    }

    public override void OnRoomExited()
    {
        Debug.Log("Minotaur Room Exited");
    }
}
