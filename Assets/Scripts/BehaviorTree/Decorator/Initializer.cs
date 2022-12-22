using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : DecorateNode
{
    [SerializeField] EnemyInfoSO info;
    [SerializeField] bool isInit = false;
    protected override void OnStart()
    {
        if (!isInit)
        {
            //ïœêîÇÃèâä˙âª
            blackboard.enemyTypeName = info.enemyTypeName;
            blackboard.HP = info.HP;
            blackboard.attackDamage = info.attackDamage;
            blackboard.defence = info.defence;
            blackboard.isInvincible = info.isInvincible;
            blackboard.stunResistance = info.stunResistance;

            Debug.Log("Intialize is compleated");
            isInit = true;
        }
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpDate()
    {
        child.UpDate();
        return State.Running;
    }
}
