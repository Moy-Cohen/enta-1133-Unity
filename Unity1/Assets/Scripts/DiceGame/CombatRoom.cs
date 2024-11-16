using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatRoom : RoomBase
{
    [SerializeField] private EnemyBase[] EnemyPrefabs;

    public void SpawnEnemies()
    {
        for (int i = 0; i < Random.Range(1,3); i++)
        {
            var enemyInstance = Instantiate(EnemyPrefabs[Random.Range(0, EnemyPrefabs.Length)], transform);
            enemyInstance.transform.localPosition = new Vector3(i,0,i);
        }
    }

    public void Start()
    {
        SpawnEnemies();
        Debug.Log("Enemies Ready");
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
