using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MoveToPosition : ActionNode
{
    public float speed = 3;
    public float stoppingDist = 0.1f;
    public bool updateRotation = true;
    public float acceleration = 20.0f;
    public float tolerance = 1.0f;

    protected override void OnStart()
    {
        context.agent.stoppingDistance = stoppingDist;
        context.agent.acceleration = acceleration;
        context.agent.speed = speed;
        context.agent.destination = blackboard.moveToPosition;
        context.agent.updateRotation = updateRotation;
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpDate()
    {
        if(context.agent.pathPending)
        {
            return State.Running;
        }

        if(context.agent.remainingDistance < tolerance)
        {
            return State.Success;
        }

        if(context.agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathInvalid)
        {
            return State.Failure;
        }

        return State.Running;
    }
}
