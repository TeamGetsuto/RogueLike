using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ChasePlayer : ActionNode
{

    protected override void OnStart()
    {
        
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpDate()
    {
        Debug.Log(blackboard.isEnemyFindPlayer);

        if (blackboard.isEnemyFindPlayer)
        {
            return State.Success;
        }

        return State.Failure;
    }
}
