using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : ItemBase
{
    //Weapons Stats
    [SerializeField] int maxAttackDamage = 0;
    [SerializeField] int durability = 0;
    
    //Deal damage between 1 and the max attack damage 
    public virtual int DealDamage()
    {
        int damageDealt = Random.Range(0, maxAttackDamage);
        return damageDealt;
    }
}
