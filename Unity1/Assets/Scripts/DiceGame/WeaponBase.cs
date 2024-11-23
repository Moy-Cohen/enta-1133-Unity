using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : ItemBase
{
    [SerializeField] int maxAttackDamage = 0;
    [SerializeField] int durability = 0;
    

    public int DealDamage()
    {
        return 0;
    }
}
