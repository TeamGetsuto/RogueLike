using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_UpdatePosition : ActionNode
{
    Vector2 myPosition;
    protected override void OnStart()
    {
        myPosition = context.gameObject.transform.position;
        blackboard.playerPosition = myPosition;
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpDate()
    {
        return State.Success;
    }
}
