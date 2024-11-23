using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpidersRoom : RoomBase
{

    [SerializeField] EnemyBase EnemySpider;


    public void Start()
    {
        
    }

    public void SpawnSpiders()
    {
        var spiderInstance = Instantiate(EnemySpider, transform);
        spiderInstance.transform.localPosition = new Vector3(0, 0.1f, -1.5f);
        
    }
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
        SpawnSpiders();
    }

    public override void OnRoomExited()
    {
        Debug.Log("Spiders Room Exited");
    }
}
