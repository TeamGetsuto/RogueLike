using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu()]
public class BehaviorTree : ScriptableObject
{
    public Node root;
    public Node.State treeState = Node.State.Running;

    public List<Node> nodes = new List<Node>();

    public Node.State UpDate()
    {
        if(root.state == Node.State.Running)
        {
            treeState = root.UpDate();
        }

        return treeState;
    }

    //ノードの追加
    public Node CreateNode(System.Type type)
    {
        Node node = ScriptableObject.CreateInstance(type) as Node;
        node.name = type.Name;
        node.guid = GUID.Generate().ToString();
        nodes.Add(node);

        AssetDatabase.AddObjectToAsset(node, this);
        AssetDatabase.SaveAssets();

        return node;
    }

    //ノードの削除
    public void DeleatNode(Node node)
    {
        nodes.Remove(node);
        AssetDatabase.RemoveObjectFromAsset(node);
        AssetDatabase.SaveAssets();
    }

    public void AddChild(Node parent, Node child)
    {

    }

    public void RemoveChild(Node parent, Node child)
    {

    }

    //public List<Node> GetChildren(Node parent)
    {

    }

}