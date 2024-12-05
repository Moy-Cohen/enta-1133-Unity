//using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private MapManager GameMapPrefab;
    [SerializeField] private PlayerController PlayerPrefab;

    private MapManager _gameMap;
    private PlayerController _playerController;
    private PlayerBase _playerData;
    private CombatRoom _combatRoom;
    public UIManager UiManager;

    public void Start()
    {
        UiManager = Object.FindAnyObjectByType<UIManager>();
        Debug.Log("GameManager Start Begins");
        // Zero our manager position
        transform.position = Vector3.zero;
        SetupMap();
        SpawnPlayer();
        StartGame();
        UiManager.Setup();
        UiManager.SetupMenus(_playerData);
    }

    private void SetupMap()
    {
        Debug.Log("GameManager SetupMap begins");
        //Create instance of MapManager
        _gameMap = Instantiate(GameMapPrefab, transform);
        _gameMap.transform.position = Vector3.zero;
        //Create the map
        _gameMap.CreateMap();
        
        

        Debug.Log("GameManager Setup Map Complete");
    }

    private void SpawnPlayer()
    {
        Debug.Log("GameManager SpawnPlayer begins");
        // After the map gets created select a random room
        var randomStartingRoom = _gameMap.Rooms.ElementAt(Random.Range(0, _gameMap.Rooms.Keys.Count));
        // Create the player
        _playerController = Instantiate(PlayerPrefab, transform);
        // Set the player initial position in the random starting room selected
        _playerController.transform.position = new Vector3(randomStartingRoom.Key.x, 1, randomStartingRoom.Key.y);
        // Call the player setup function
        _playerController.Setup();
        _playerData = _playerController.GetComponent<PlayerBase>();
        Debug.Log("GameManager SpawnPlayer Complete");
    }

    // Update is called once per frame
    public void StartGame()
    {
        Debug.Log("GameManager StartGame Begins");
        Debug.Log("GameManager StartGame Complete");
    }
}
