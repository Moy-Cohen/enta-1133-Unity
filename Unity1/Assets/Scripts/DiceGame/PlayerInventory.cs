using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private ItemBase[] TreasurePrefabs;
    private List<ItemBase> currentInventory = new List<ItemBase>();

    private PlayerController _playerController;

    void Start()
    {
        _playerController = FindAnyObjectByType<PlayerController>();
        StartingInventory();
    }

    public void StartingInventory()
    {
        for(int x = 0; x < 3; x++)
        {
            var startingWeapon = Instantiate(TreasurePrefabs[Random.Range(0, TreasurePrefabs.Length)]);
            startingWeapon.transform.position = _playerController.transform.position;
            currentInventory.Add(startingWeapon);
        }
        for(int x = 0;x < 5; x++)
        {
            var startingPotion = Instantiate(TreasurePrefabs[Random.Range(0, TreasurePrefabs.Length)]);
            startingPotion.transform.position = _playerController.transform.position;
        }

        Debug.Log(currentInventory.Count);
    }


    public void TreasureSearch()
    {
        for (int x = 0; x < 3; x++)
        {
            var treasureInstance = Instantiate(TreasurePrefabs[Random.Range(0, TreasurePrefabs.Length)]);
            treasureInstance.transform.position = new Vector3(_playerController.transform.position.x + 1, _playerController.transform.position.y, _playerController.transform.position.z + 1);

        }
    }
    
}
