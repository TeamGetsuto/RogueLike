using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToDirection : ActionNode
{
    public float moveSpeed;
    public float maxVelocity;
    Rigidbody2D rig2d;
    
    protected override void OnStart()
    {
        rig2d = context.physics2d;
    }

    protected override void OnStop()
    {
       
    }

    protected override State OnUpDate()
    {
        rig2d.AddForce(blackboard.moveDirection * moveSpeed * Time.deltaTime);

        if(rig2d.velocity.magnitude < maxVelocity)
        {
            return State.Running;
        }

        return State.Success;
    }
}
