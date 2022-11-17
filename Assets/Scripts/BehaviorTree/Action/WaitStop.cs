using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitStop : ActionNode
{
    Rigidbody2D physics2d;
    protected override void OnStart()
    {
        physics2d = context.physics2d;
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpDate()
    {
        if(physics2d.velocity.magnitude > 0.1f) 
        {
            return State.Running;
        }

        return State.Success;
    }
}
