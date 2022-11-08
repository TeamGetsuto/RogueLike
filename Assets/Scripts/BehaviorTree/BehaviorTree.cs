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
        if (root.state == Node.State.Running)
        {
            treeState = root.UpDate();
        }

        return treeState;
    }

#if UNITY_EDITOR
    //ノードの追加
    public Node CreateNode(System.Type type)
    {
        Node node = ScriptableObject.CreateInstance(type) as Node;
        node.name = type.Name;
        node.guid = GUID.Generate().ToString();

        Undo.RecordObject(this, "Behavior Tree (CreateNode)");

        nodes.Add(node);

        AssetDatabase.AddObjectToAsset(node, this);
        Undo.RegisterCreatedObjectUndo(node, "Behavior Tree (CreateNode)");

        AssetDatabase.SaveAssets();

        return node;
    }

    //ノードの削除
    public void DeleatNode(Node node)
    {
        Undo.RecordObject(this, "Behavior Tree (DeleatNode)");
        nodes.Remove(node);

        //AssetDatabase.RemoveObjectFromAsset(node);
        Undo.DestroyObjectImmediate(node);
        AssetDatabase.SaveAssets();
    }

    //子ノードの追加
    public void AddChild(Node parent, Node child)
    {
        DecorateNode decorater = parent as DecorateNode;
        if(decorater)
        {
            Undo.RecordObject(decorater, "Behavior Tree (AddChild)");
            decorater.child = child;
            EditorUtility.SetDirty(decorater);
        }

        RootNode rootNode = parent as RootNode;
        if(rootNode)
        {
            Undo.RecordObject(rootNode, "Behavior Tree (AddChild)");
            rootNode.child = child;
            EditorUtility.SetDirty(rootNode);
        }

        CompositeNode composite = parent as CompositeNode;
        if(composite)
        {
            Undo.RecordObject(composite, "Behavior Tree (AddChild)");
            composite.children.Add(child);
            EditorUtility.SetDirty(composite);
        }
    }

    //子ノードの削除
    public void RemoveChild(Node parent, Node child)
    {
        DecorateNode decorater = parent as DecorateNode;
        if (decorater)
        {
            Undo.RecordObject(decorater, "Behavior Tree (AddChild)");
            decorater.child = null;
            EditorUtility.SetDirty(decorater);
        }

        RootNode rootNode = parent as RootNode;
        if (rootNode)
        {
            Undo.RecordObject(rootNode, "Behavior Tree (AddChild)");
            rootNode.child = null;
            EditorUtility.SetDirty(rootNode);
        }

        CompositeNode composite = parent as CompositeNode;
        if (composite)
        {
            Undo.RecordObject(composite, "Behavior Tree (AddChild)");
            composite.children.Remove(child);
            EditorUtility.SetDirty(composite);
        }
    }

    public List<Node> GetChildren(Node parent)
    {
        List<Node> children = new List<Node>();

        DecorateNode decorater = parent as DecorateNode;
        if (decorater && decorater.child != null)
        {
            children.Add(decorater.child);
        }

        RootNode rootNode = parent as RootNode;
        if (rootNode && rootNode.child != null)
        {
            children.Add(rootNode.child);
        }

        CompositeNode composite = parent as CompositeNode;
        if (composite)
        {
            return composite.children;
        }

        return children;
    }
#endif

    public void Traverse(Node node, System.Action<Node> visiter)
    {
        if(node)
        {
            visiter.Invoke(node);
            var children = GetChildren(node);
            children.ForEach((n) => Traverse(n, visiter));
        }

    }

    public BehaviorTree Clone()
    {
        BehaviorTree tree = Instantiate(this);
        tree.root = tree.root.Clone();
        tree.nodes = new List<Node>();
        Traverse(tree.root, (n) =>
        {
            tree.nodes.Add(n);
        });
        return tree;
    }
}