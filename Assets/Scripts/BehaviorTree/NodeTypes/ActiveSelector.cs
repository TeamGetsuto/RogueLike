using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSelector : CompositeNode
{
    public GameObject obj;
    protected override void OnStart()
    {
        
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpDate()
    {
        return State.Success;
    }
}
