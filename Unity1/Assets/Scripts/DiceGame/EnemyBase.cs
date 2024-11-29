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


    private PlayerBase _playerBase;
    //Enemy attacks and do random damage between 0 and the max damage

    public void SetUp()
    {
        _playerBase = Object.FindAnyObjectByType<PlayerBase>();
    }

    public void DoAttack()
    {
        int attackDamage = Random.Range(0, enemyMaxAttackDamage);
        _playerBase.currentHealth -= attackDamage;
    }

}
