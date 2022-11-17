using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyS : ActionNode
{
    protected override void OnStart()
    {
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpDate()
    {
        if (Input.GetKey(KeyCode.S))
        {
            blackboard.keyCodeSdown = true;
            return State.Running;
        }
        else
        {
            blackboard.keyCodeSdown = false;
            return State.Failure;
        }
    }
}
