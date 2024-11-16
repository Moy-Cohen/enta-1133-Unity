using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GelatinousCubeRoom : RoomBase
{

    [SerializeField] EnemyBase EnemySlime;


    public void Start()
    {
        SpawnSlime();
    }

    public void SpawnSlime()
    {
        var slimeInstance = Instantiate(EnemySlime, transform);
        slimeInstance.transform.localPosition = new Vector3(0, 0, -2);
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
        Debug.Log("Gelatinous Cube Room Searched");
    }

    public override void OnRoomExited()
    {
        Debug.Log("Gelatinous Cube Room Exited");
    }
}
