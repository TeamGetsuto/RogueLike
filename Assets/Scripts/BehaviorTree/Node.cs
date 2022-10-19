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

    public State state = State.Running;
    public bool isStart = false;
    public string guid;
    public Vector2 position;
    public BehaviorTree tree;
    public NodeTypeList list;

    //Start - UpDate - Stop の順で処理を回す
    public State UpDate()
    {
        //StartしていないならStart
        if(!isStart)
        {
            OnStart();
            isStart = true;
        }

        //UpDate
        state = OnUpDate();

        //UpDateが成功/失敗で終了
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
    /// 初期化
    /// </summary>
    public void Initialise(Rect rect, BehaviorTree tree, NodeTypeList nodeType)
    {
        this.rect = rect;
        this.guid = Guid.NewGuid().ToString();
        this.name = "ノード";
        this.tree = tree;
        
        //部屋のタイプをロードする
        list = GameResources.Instance.nodeTypeList;
    }

    /// <summary>
    /// 描画
    /// </summary>
    /// <param name="nodeStyle"></param>
    public void Draw(GUIStyle nodeStyle)
    {
        //箱を描画する
        GUILayout.BeginArea(rect, nodeStyle);
        //変更を確認する
        EditorGUI.BeginChangeCheck();
    }
#endif
        #endregion Editor Code
    }
