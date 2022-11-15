using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// デバッグログノード
/// デバッグメッセージの表示
/// </summary>
namespace shirasu
{
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
            return State.Success;
        }
        protected override void OnStop()
        {
            Debug.Log($"OnStop{message}");
        }
    }
}
