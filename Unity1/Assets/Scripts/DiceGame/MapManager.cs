using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private RoomBase[] RoomPrefabs;
    [SerializeField] private float RoomSize = 9;
    [SerializeField] private MinotaurRoom minotaurRoom;

    // Map size is this number squared
    private const int mapSize = 9;
    readonly Dictionary<Vector2, RoomBase> _rooms = new();
    public Dictionary<Vector2, RoomBase> Rooms => _rooms;
    

    // Creates map using the prefab rooms
    public void CreateMap()
    {
        int randomX;
        int randomZ;

        // Added variables for conditioning a specific room 
        randomX = Random.Range(0, mapSize);
        randomZ = Random.Range(0, mapSize);

        // Map creation Random rooms from the room prefabs list
        for (int x = 0; x < mapSize; x++)
        {
            for (int z = 0; z < mapSize; z++)
            {
                Vector2 coords = new Vector2(x * RoomSize, z * RoomSize);
                RoomBase roomInstance;

                // This if statement conditions so that only one minotaurRoom Spawns in th map 
                if (x == randomX && z == randomZ)
                {
                    roomInstance = Instantiate(minotaurRoom, transform);
                }
                else
                {
                    roomInstance = Instantiate(RoomPrefabs[Random.Range(0, RoomPrefabs.Length)], transform);
                }

                roomInstance.SetRoomLocation(coords);
                _rooms.Add(coords, roomInstance);
            }
        }

        foreach (var roomByCoordinate in _rooms)
        {
            RoomBase northRoom = FindRoom(roomByCoordinate.Key, Direction.North);
            RoomBase eastRoom = FindRoom(roomByCoordinate.Key, Direction.East);
            RoomBase southRoom = FindRoom(roomByCoordinate.Key, Direction.South);
            RoomBase westRoom = FindRoom(roomByCoordinate.Key, Direction.West);

            roomByCoordinate.Value.SetRooms(northRoom, eastRoom, southRoom, westRoom);

        }
    }

    // Finds the next room in a direction from an existing room 
    
    private RoomBase FindRoom(Vector2 currentRoom, Direction direction)
    {
        RoomBase room = null;
        Vector2 nextRoomCoordinates = new Vector2(-1, -1);
        switch (direction)
        {
            case Direction.North:
                nextRoomCoordinates = currentRoom + (Vector2.up * RoomSize);
                break;
            case Direction.East:
                nextRoomCoordinates = currentRoom + (Vector2.right * RoomSize);
                break;
            case Direction.South:
                nextRoomCoordinates = currentRoom + (Vector2.down * RoomSize);
                break;
            case Direction.West:
                nextRoomCoordinates = currentRoom + (Vector2.left * RoomSize);
                break;
        }

        if (_rooms.TryGetValue(nextRoomCoordinates, out var nextRoom))
        {
            room = nextRoom;
        }

        return room;
    
    }

}
