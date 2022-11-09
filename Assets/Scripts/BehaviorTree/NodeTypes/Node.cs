using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

/// <summary>
/// �m�[�h�̒��ۃN���X
/// </summary>
public abstract class Node : ScriptableObject
{
    // ���s���A�����A���s�̃X�e�[�g
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

    //Start - UpDate - Stop �̏��ŏ�������
    public State UpDate()
    {
        //Start���Ă��Ȃ��Ȃ�Start
        if (!isStart)
        {
            OnStart();
            isStart = true;
        }

        //UpDate
        state = OnUpDate();

        //UpDate������/���s�ŏI��
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