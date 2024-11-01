//using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private MapManager GameMapPrefab; 

    private MapManager _gameMap;

    public void Start()
    {
        Debug.Log("GameManager Start");
        // Zero our manager position
        transform.position = Vector3.zero;

        //Create instance of MapManager
        _gameMap = Instantiate(GameMapPrefab, transform);
        _gameMap.transform.position = Vector3.zero;
        //Create the map
        _gameMap.CreateMap();

        Debug.Log("GameManager Map Created");

        StartGame();
    }

    // Update is called once per frame
    public void StartGame()
    {
        Debug.Log("Hello World");

        var randomStartingRoom = _gameMap.Rooms.ElementAt(Random.Range(0, _gameMap.Rooms.Keys.Count));
        // Set the camera to the spawn room
        Camera.main.transform.position = new Vector3(randomStartingRoom.Key.x, 2.5f, randomStartingRoom.Key.y);

    }
}
