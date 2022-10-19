using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;


public class BehaviorTreeEditor : EditorWindow
{
    public Node repeater;
    public Node sequencer;
    public Node debugger;

    //レイアウト
    private const float nodeWidth = 160f;
    private const float nodeHeight = 75f;
    private const int nodePadding = 25;
    private const int nodeBorder = 12;

    //線の太さ
    private const float connectingLineWidth = 3f;
    private const float connectingLineArrowSize = 6f;

    //グリッド
    private const float gridLarge = 100f;
    private const float gridSmall = 25f;

    private static BehaviorTree currentTree;
    private Node currentNode = null;
    private NodeTypeList nodeTypeList;

    private Vector2 treeOffset;
    private Vector2 treeDrag;

    [MenuItem("BehaviorTreeEditor/Editor ...")]
    private static void OpenWindow()
    {
        GetWindow<BehaviorTreeEditor>("BehaviorTreeEditor");
    }

    #region 起動時と終了時の処理
    private void OnEnable()
    {
        Selection.selectionChanged += InspectorSelectionChanged;

        //通常時のノード
        //Repeater
        repeater.style = new GUIStyle();
        repeater.style.normal.background = EditorGUIUtility.Load("node1") as Texture2D;
        repeater.style.normal.textColor = Color.magenta;
        repeater.style.padding = new RectOffset(nodePadding, nodePadding, nodePadding, nodePadding);
        repeater.style.border = new RectOffset(nodeBorder, nodeBorder, nodeBorder, nodeBorder);

        //sequencer
        sequencer.style = new GUIStyle();
        sequencer.style.normal.background = EditorGUIUtility.Load("node1") as Texture2D;
        sequencer.style.normal.textColor = Color.magenta;
        sequencer.style.padding = new RectOffset(nodePadding, nodePadding, nodePadding, nodePadding);
        sequencer.style.border = new RectOffset(nodeBorder, nodeBorder, nodeBorder, nodeBorder);

        //Debugger
        debugger.style = new GUIStyle();
        debugger.style.normal.background = EditorGUIUtility.Load("node1") as Texture2D;
        debugger.style.normal.textColor = Color.magenta;
        debugger.style.padding = new RectOffset(nodePadding, nodePadding, nodePadding, nodePadding);
        debugger.style.border = new RectOffset(nodeBorder, nodeBorder, nodeBorder, nodeBorder);

        //選択時のノード
        //Repeater
        repeater.selected = new GUIStyle();
        repeater.selected.normal.background = EditorGUIUtility.Load("node1") as Texture2D;
        repeater.selected.normal.textColor = Color.magenta;
        repeater.selected.padding = new RectOffset(nodePadding, nodePadding, nodePadding, nodePadding);
        repeater.selected.border = new RectOffset(nodeBorder, nodeBorder, nodeBorder, nodeBorder);

        //sequencer
        sequencer.selected = new GUIStyle();
        sequencer.selected.normal.background = EditorGUIUtility.Load("node1") as Texture2D;
        sequencer.selected.normal.textColor = Color.magenta;
        sequencer.selected.padding = new RectOffset(nodePadding, nodePadding, nodePadding, nodePadding);
        sequencer.selected.border = new RectOffset(nodeBorder, nodeBorder, nodeBorder, nodeBorder);

        //Debugger
        debugger.selected = new GUIStyle();
        debugger.selected.normal.background = EditorGUIUtility.Load("node1") as Texture2D;
        debugger.selected.normal.textColor = Color.magenta;
        debugger.selected.padding = new RectOffset(nodePadding, nodePadding, nodePadding, nodePadding);
        debugger.selected.border = new RectOffset(nodeBorder, nodeBorder, nodeBorder, nodeBorder);

        nodeTypeList = GameResources.Instance.nodeTypeList;
    }

    private void OnDisable()
    {
        Selection.selectionChanged -= InspectorSelectionChanged;
    }
    #endregion

    private void InspectorSelectionChanged()
    {
        BehaviorTree tree = Selection.activeObject as BehaviorTree;

        if(tree != null)
        {
            currentTree = tree;
            GUI.changed = true;
        }
    }

    /// <summary>
    /// BehaviorTreeをダブルクリックでエディターを展開
    /// </summary>
    /// <param name="instanceID"></param>
    /// <param name="line"></param>
    /// <returns></returns>
    [OnOpenAsset(10)] //UnityEditor.Callbacks
    public static bool OnDoubleClickedAsset(int instanceID, int line)
    {
        BehaviorTree tree = EditorUtility.InstanceIDToObject(instanceID) as BehaviorTree;

        if(tree != null)
        {
            OpenWindow();

            currentTree = tree;
            return true;
        }

        return false;
    }

    /// <summary>
    /// エディターの描画
    /// </summary>
    private void OnGUI()
    {
        //ツリーをすでに選んでいるとき
        if(currentTree != null)
        {
            //グリッド線の描画
            DrawBackgroundGrid(gridSmall, 0.2f, Color.gray);
            DrawBackgroundGrid(gridLarge, 0.2f, Color.gray);

            //ノードの描画
            DrawNodes();
        }
    }

    /// <summary>
    /// ノードの描画
    /// </summary>
    private void DrawNodes()
    {
        foreach (Node node in currentTree.nodes)
        {
            if (node.isSelected)
            {
                node.Draw(node.style);
            }
            else
            {
                node.Draw(node.selected);
            }
        }

        GUI.changed = true;
    }

    //グリッドの描画
    private void DrawBackgroundGrid(float gridSize, float gridOpacity, Color gridColor)
    {
        int verticalCount = Mathf.CeilToInt((position.width + gridSize) / gridSize);
        int horizontalCount = Mathf.CeilToInt((position.height + gridSize) / gridSize);

        Handles.color = new Color(gridColor.r, gridColor.g, gridColor.b, gridOpacity);

        treeOffset += treeDrag * 0.5f;

        Vector3 gridOffset = new Vector3(treeOffset.x % gridSize, treeOffset.y % gridSize, 0);

        for (int i = 0; i < verticalCount; i++)
        {
            Handles.DrawLine(new Vector3(gridSize * i, -gridSize, 0f) + gridOffset, new Vector3(gridSize * i, position.height + gridSize, 0f) + gridOffset);
        }

        for (int j = 0; j < horizontalCount; j++)
        {
            Handles.DrawLine(new Vector3(-gridSize, gridSize * j, 0f) + gridOffset, new Vector3(position.width + gridSize, gridSize * j, 0f) + gridOffset);
        }

        Handles.color = Color.white;
    }
}
