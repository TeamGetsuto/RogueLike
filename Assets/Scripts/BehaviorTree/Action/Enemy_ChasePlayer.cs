using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ChasePlayer : ActionNode
{
    public float moveSpeed = 3.0f;
    protected override void OnStart()
    {
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpDate()
    {
        Vector2 moveDir = blackboard.enemyToPlayerDist.normalized;
        context.transform.Translate(moveDir * moveSpeed * Time.deltaTime);

        return State.Success;
    }
}
