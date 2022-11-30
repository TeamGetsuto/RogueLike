using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_GetPlayerPos : ActionNode
{
    protected override void OnStart()
    {
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpDate()
    {
        blackboard.playerPosition = context.player.transform.position;
        return State.Success;
    }
}
