using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SearchPlayer : ActionNode
{
    private CircleCollider2D enemySearchRange;
    public LayerMask playerLayer;
    protected override void OnStart()
    {
        enemySearchRange = context.circleCollider2d;
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpDate()
    {
        blackboard.isEnemyFindPlayer = enemySearchRange.IsTouchingLayers(playerLayer);

        //if (blackboard.isEnemyFindPlayer)
        //{
        //    return State.Success;
        //}

        //return State.Failure;

        return State.Success;
    }
}
