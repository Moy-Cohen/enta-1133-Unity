using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    int mapSize = 9;
    public int MapSize => mapSize;


    public Map()
    {
        CreateMap();
        VisualizeMap();

    }

    private void CreateMap()
    {

    }

    private void VisualizeMap()
    {
        for (int x = 0 ; x < mapSize; x++)
        {
            for (int z = 0 ; z < mapSize; z++)
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
    }

    

}
