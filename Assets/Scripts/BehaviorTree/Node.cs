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
    public Vector2 position;
    public BehaviorTree tree;
    public NodeTypeList list;

    //Start - UpDate - Stop �̏��ŏ�������
    public State UpDate()
    {
        //Start���Ă��Ȃ��Ȃ�Start
        if(!isStart)
        {
            OnStart();
            isStart = true;
        }

        //UpDate
        state = OnUpDate();

        //UpDate������/���s�ŏI��
        if(state == State.Failure || state == State.Success)
        {
            OnStop();
            isStart = false;
        }

        return state;
    }

    protected abstract void OnStart();
    protected abstract State OnUpDate();
    protected abstract void OnStop();


    #region Editor Code
#if UNITY_EDITOR

    public GUIStyle style;
    public GUIStyle selected;

    [HideInInspector] public Rect rect;
    [HideInInspector] public bool isSelected = false;

    /// <summary>
    /// ������
    /// </summary>
    public void Initialise(Rect rect, BehaviorTree tree, NodeTypeList nodeType)
    {
        this.rect = rect;
        this.guid = Guid.NewGuid().ToString();
        this.name = "�m�[�h";
        this.tree = tree;
        
        //�����̃^�C�v�����[�h����
        list = GameResources.Instance.nodeTypeList;
    }

    /// <summary>
    /// �`��
    /// </summary>
    /// <param name="nodeStyle"></param>
    public void Draw(GUIStyle nodeStyle)
    {
        //����`�悷��
        GUILayout.BeginArea(rect, nodeStyle);
        //�ύX���m�F����
        EditorGUI.BeginChangeCheck();
    }
#endif
        #endregion Editor Code
    }
