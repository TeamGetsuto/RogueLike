using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SetPosition : ActionNode
{
    public Vector2 direction;
    public float moveRange;
    protected override void OnStart()
    {
        blackboard.enemyGoalPos = direction.normalized * moveRange;
        direction *= -1;
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpDate()
    {
        return State.Success;
    }
}
