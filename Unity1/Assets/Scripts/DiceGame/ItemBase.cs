using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{

    [SerializeField] public string itemName;
    [SerializeField] public bool _isConsumable;
    [SerializeField] public  int maxAttackDamage = 0;
    [SerializeField] public  int durability = 0;
    [SerializeField] public int maxHealth = 0;

}
