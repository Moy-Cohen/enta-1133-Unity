using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private ItemBase[] TreasurePrefabs;
    public List<ItemBase> currentInventory = new List<ItemBase>();

    private PlayerController _playerController;
    //private ItemBase _itemBase;

    void Start()
    {
        _playerController = FindAnyObjectByType<PlayerController>();
        StartingInventory();
    }

    public void StartingInventory()
    {
        for(int x = 0; x < 3; x++)
        {
            var startingWeapon = Instantiate(TreasurePrefabs[4]);
            startingWeapon.transform.position = _playerController.transform.position;
            currentInventory.Add(startingWeapon);
        }
        for(int x = 0;x < 5; x++)
        {
            var startingPotion = Instantiate(TreasurePrefabs[0]);
            startingPotion.transform.position = _playerController.transform.position;
            currentInventory.Add(startingPotion);
        }

       
    }


    public void TreasureSearch()
    {
        for (int x = 0; x < 3; x++)
        {
            var treasureInstance = Instantiate(TreasurePrefabs[Random.Range(0, TreasurePrefabs.Length)]);
            /*treasureInstance.transform.position = new Vector3(_playerController.transform.position.x + 1, _playerController.transform.position.y, _playerController.transform.position.z + 1);
            currentInventory.Add(treasureInstance);*/

            if (_playerController._facingDirection == Direction.North)
            {
                //var treasureInstance = Instantiate(TreasurePrefabs[Random.Range(0, TreasurePrefabs.Length)]);
                treasureInstance.transform.position = new Vector3(_playerController.transform.position.x, 1, _playerController.transform.position.z + 1.5f);
                treasureInstance.transform.Rotate(0, 180, 0);
                currentInventory.Add(treasureInstance);
                //Destroy(treasureInstance);
            }
            else if (_playerController._facingDirection == Direction.East)
            {
                //var treasureInstance = Instantiate(TreasurePrefabs[Random.Range(0, TreasurePrefabs.Length)]);
                treasureInstance.transform.position = new Vector3(_playerController.transform.position.x + 1.5f, 0.1f, _playerController.transform.position.z);
                treasureInstance.transform.Rotate(0, -90, 0);
                currentInventory.Add(treasureInstance);
                //Destroy(treasureInstance);
            }
            else if (_playerController._facingDirection == Direction.South)
            {
                //var treasureInstance = Instantiate(TreasurePrefabs[Random.Range(0, TreasurePrefabs.Length)]);
                treasureInstance.transform.position = new Vector3(_playerController.transform.position.x, 0.1f, _playerController.transform.position.z - 1.5f);
                currentInventory.Add(treasureInstance);
                //Destroy(treasureInstance);
            }
            else if (_playerController._facingDirection == Direction.West)
            {
                //var treasureInstance = Instantiate(TreasurePrefabs[Random.Range(0, TreasurePrefabs.Length)]);
                treasureInstance.transform.position = new Vector3(_playerController.transform.position.x - 1.5f, 0.1f, _playerController.transform.position.z);
                treasureInstance.transform.Rotate(0, 90, 0);
                currentInventory.Add(treasureInstance);
                //Destroy(treasureInstance);
            }

            Destroy(treasureInstance);

        }
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            foreach (ItemBase item in currentInventory)
            {
                Debug.Log(item.itemName);
            }
        }
    }
}
