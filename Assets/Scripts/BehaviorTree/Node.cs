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

    public State state = State.Running;
    public bool isStart = false;
    public string guid;
    public Vector2 pos;

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

    protected abstract void OnStart();
    protected abstract State OnUpDate();
    protected abstract void OnStop();


}