using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyW : ActionNode
{
    protected override void OnStart()
    {
    }

    protected override void OnStop()
    {

    }

    protected override State OnUpDate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            blackboard.keyCodeWdown = true;
            return State.Running;
        }
        else
        {
            blackboard.keyCodeWdown = false;
            return State.Failure;
        }
    }
}
