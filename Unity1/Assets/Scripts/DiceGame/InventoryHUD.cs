using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryHUD : MonoBehaviour
{
    private PlayerInventory _inventory;

    [SerializeField] private GameObject _SlotPrefab;

    [SerializeField] private Transform ContentParent;

    public void Start()
    {
        /*_inventory = FindAnyObjectByType<PlayerInventory>();

        if (_inventory != null)
        {
            //RefreshInventory();
        }
        else
        {
            Debug.LogWarning("Inventory reference not set");
        }*/
    }

    private void OnEnable()
    {
        _inventory = FindAnyObjectByType<PlayerInventory>();

        if (_inventory != null)
        {
            //RefreshInventory();
        }
        else
        {
            Debug.LogWarning("Inventory reference not set");
        }
        RefreshInventory();
    }

    public void RefreshInventory()
    {
        foreach (Transform child in ContentParent)
        {
            Destroy(child.gameObject);
        }
        

        foreach (ItemBase item in _inventory.currentInventory)
        {
            GameObject newSlot = Instantiate(_SlotPrefab, ContentParent);
            Text itemName = newSlot.transform.Find("ItemName").GetComponent<Text>();
            itemName.text = item.itemName;
            if(item._isConsumable == false)
            {
                Text itemDescription = newSlot.transform.Find("ItemDescription").GetComponent<Text>();
                itemDescription.text = $"Max Damage: { item.maxAttackDamage.ToString()} Durabulity: {item.durability.ToString()}";
            }
            else if (item._isConsumable == true)
            {
                Text itemDescription = newSlot.transform.Find("ItemDescription").GetComponent<Text>();
                itemDescription.text = $"Max Health: {item.maxHealth.ToString()}";
            }
        }
    }


    



}

