using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_CalcDistToPlayer : ActionNode
{
    Vector2 myPosition;
    Vector2 targetPosition;
    public float attackRange = 0.5f;
    protected override void OnStart()
    {
        
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpDate()
    {
        myPosition = context.transform.position;
        targetPosition = blackboard.playerPosition;

        blackboard.enemyToPlayerDist = targetPosition - myPosition;

        Debug.LogWarning(blackboard.enemyToPlayerDist.magnitude);

        if (blackboard.enemyToPlayerDist.magnitude > attackRange)
        {
            blackboard.canEnemyAttack = false;
        }
        else
        {
            blackboard.canEnemyAttack = true;
        }

        return State.Success;
    }
}
