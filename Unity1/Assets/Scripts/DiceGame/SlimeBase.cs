using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBase : EnemyBase
{
    private PlayerBase _playerBase;

    public override void Start()
    {
        _playerBase = FindAnyObjectByType<PlayerBase>();
    }

    public override void DoAttack()
    {
        int attackDamage = Random.Range(0, enemyMaxAttackDamage);
        _playerBase.currentHealth -= attackDamage;
    }
}
