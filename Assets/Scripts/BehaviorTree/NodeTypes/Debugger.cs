using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// デバッグログノード
/// デバッグメッセージの表示
/// </summary>
public class Debugger : ActionNode
{
    public string message;
    protected override void OnStart()
    {
        Debug.Log($"OnStart{message}");
    }
    protected override State OnUpDate()
    {
        Debug.Log($"OnUpDate{message}");

        Debug.Log($"BlackBoard:{blackboard.moveToPosition}");
        blackboard.moveToPosition.x += 1;

        return State.Success;
    }
    protected override void OnStop()
    {
        Debug.Log($"OnStop{message}");
    }
}
