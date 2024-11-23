using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonsRoom : RoomBase
{
    [SerializeField] EnemyBase EnemySkeleton;


    public void Start()
    {
        
    }

    public void SpawnSkeleton()
    {
        var skeletonInstance = Instantiate(EnemySkeleton, transform);
        skeletonInstance.transform.localPosition = new Vector3(0, 0.1f, -2);
    }
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
        SpawnSkeleton();
    }

    public override void OnRoomExited()
    {
        Debug.Log("Skeletons Room Exited");
    }
}
