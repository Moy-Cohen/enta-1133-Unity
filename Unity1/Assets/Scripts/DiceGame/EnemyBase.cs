using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    


    [SerializeField] int enemyMaxHp = 0;
    [SerializeField] int enemyCurrentHp = 0;
    [SerializeField] int enemyMaxAttackDamage = 0;
    [SerializeField] int enemySpeed = 0;
    
    public virtual int DoAttack()
    {

        return 0;
    }
}
