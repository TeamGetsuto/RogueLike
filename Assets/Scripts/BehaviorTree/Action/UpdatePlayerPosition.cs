using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePlayerPosition : ActionNode
{
    Vector2 myPosition;
    protected override void OnStart()
    {
        myPosition = context.transform.position;
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
