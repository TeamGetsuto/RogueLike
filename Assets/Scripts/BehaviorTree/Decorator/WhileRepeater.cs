using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhileRepeater : DecorateNode
{
    public bool whileCondition;
    protected override void OnStart()
    {
        whileCondition = blackboard.condition;
    }

    protected override void OnStop()
    {

    }

    protected override State OnUpDate()
    {
        if (whileCondition)
        {
            child.UpDate();
            return State.Running;
        }

        return State.Failure;
    }
}
