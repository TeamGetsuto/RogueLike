using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Selector : CompositeNode
{
    protected int current;
    protected override void OnStart()
    {
        current = 0;
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpDate()
    {
        for(int i = current; i < children.Count; i++)
        {
            current = i;
            var child = children[current];

            switch (child.UpDate())
            {
                case State.Success:
                    return State.Success;
                case State.Running:
                    return State.Running;
                case State.Failure:
                    continue;
            }
        }

        return State.Failure;
    }
}
