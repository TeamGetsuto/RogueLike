using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDirection : ActionNode
{
    public Vector2 min = Vector2.one * -1;
    public Vector2 max = Vector2.one * 1;
    protected override void OnStart()
    {
        
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpDate()
    {
        float x = Random.Range(min.x, max.x);
        float y = Random.Range(min.y, max.y);

        blackboard.moveDirection = new Vector2(x, y).normalized;

        return State.Success;
    }

}
