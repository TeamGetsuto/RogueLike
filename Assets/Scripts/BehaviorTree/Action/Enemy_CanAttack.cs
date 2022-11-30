using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_CanAttack : ActionNode
{
    protected override void OnStart()
    {

    }

    protected override void OnStop()
    {

    }

    protected override State OnUpDate()
    {
        if (blackboard.canEnemyAttack)
        {
            return State.Success;
        }

        return State.Failure;
    }
}
