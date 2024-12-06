using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{

    
    // Enemy stats
    [SerializeField] public int enemyMaxHp = 0;
    [SerializeField] public int enemyCurrentHp = 0;
    [SerializeField] public int enemyMaxAttackDamage = 0;
    public int attackDamage = 0;

    private PlayerBase _playerBase;
  

    public virtual void Start()
    {
        _playerBase = Object.FindAnyObjectByType<PlayerBase>();
        
    }

    //Enemy attacks and do random damage between 0 and the max damage
    public virtual void DoAttack()
    {
        attackDamage = Random.Range(0, enemyMaxAttackDamage);
        
        
    }

}
