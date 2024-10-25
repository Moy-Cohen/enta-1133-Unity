using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private RoomBase[] RoomPrefabs;
    [SerializeField] private float RoomSize = 1;

    private const int mapSize = 9;
    readonly Dictionary<Vector2, RoomBase> _rooms = new();
    public Dictionary<Vector2, RoomBase> Rooms => _rooms;
    


    public void CreateMap()
    {
        for (int x = 0; x < mapSize; x++)
        {
            for (int z = 0; z < mapSize; z++)
            {

                //Last week's code
                /*var mapRoomRepresentation = GameObject.CreatePrimitive(PrimitiveType.Cube);
                mapRoomRepresentation.transform.position = new Vector3(x, 0, z);*/


                Vector2 coords = new Vector2(x * RoomSize, z * RoomSize);

                var roomInstance = Instantiate(RoomPrefabs[Random.Rrange(0, RoomPrefabs.Length)], transform);

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

    private RoomBase FindRoom(Vector2 currentRoom, Direction direction)
    {

    }

}
