using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

/// <summary>
/// ノードの抽象クラス
/// </summary>
public abstract class Node : ScriptableObject
{
    // 実行中、成功、失敗のステート
    public enum State
    {
        Success,
        Running,
        Failure
    }

    [HideInInspector] public State state = State.Running;
    [HideInInspector] public bool isStart = false;
    [HideInInspector] public string guid;
    [HideInInspector] public Vector2 pos;
    [HideInInspector] public BlackBoard blackboard;
    [HideInInspector] public AiAgent agent;
    [TextArea] public string description;

    //Start - UpDate - Stop の順で処理を回す
    public State UpDate()
    {
        //StartしていないならStart
        if (!isStart)
        {
            OnStart();
            isStart = true;
        }

        //UpDate
        state = OnUpDate();

        //UpDateが成功/失敗で終了
        if (state == State.Failure || state == State.Success)
        {
            OnStop();
            isStart = false;
        }

        return state;
    }

    public virtual Node Clone()
    {
        return Instantiate(this);
    }

    protected abstract void OnStart();
    protected abstract State OnUpDate();
    protected abstract void OnStop();


}