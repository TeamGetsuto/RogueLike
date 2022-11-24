using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDelay : ActionNode
{
    Animator anim;
    protected override void OnStart()
    {
        anim = context.animator;
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpDate()
    {
        return State.Success;
    }
}
