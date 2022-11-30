using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ActiveSelect : ActionNode
{
    protected override void OnStart()
    {
        blackboard.isEnemyActive = context.gameObject.activeSelf;
    }

    protected override void OnStop()
    {

    }

    protected override State OnUpDate()
    {
        if(!blackboard.isEnemyActive)
        {
            return State.Failure;
        }

        return State.Success;
    }
}
