using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : ActionNode
{
    Transform transform;
    public float speed = 3;
    protected override void OnStart()
    {
        transform = context.transform;
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpDate()
    {
        if (blackboard.keyCodeWdown)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            return State.Running;
        }
        else if (blackboard.keyCodeSdown)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            return State.Running;
        }
        return State.Failure;
    }
}
