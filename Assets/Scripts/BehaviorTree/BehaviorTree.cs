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

    //ÉmÅ[ÉhÇÃí«â¡
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

    //ÉmÅ[ÉhÇÃçÌèú
    public void DeleatNode(Node node)
    {
        nodes.Remove(node);
        AssetDatabase.RemoveObjectFromAsset(node);
        AssetDatabase.SaveAssets();
    }

    public void AddChild(Node parent, Node child)
    {
        DecorateNode decorater = parent as DecorateNode;
        if(decorater)
        {
            decorater.child = child;
        }

        RootNode rootNode = parent as RootNode;
        if(rootNode)
        {
            rootNode.child = child;
        }

        CompositeNode composite = parent as CompositeNode;
        if(composite)
        {
            composite.children.Add(child);
        }
    }

    public void RemoveChild(Node parent, Node child)
    {
        DecorateNode decorater = parent as DecorateNode;
        if (decorater)
        {
            decorater.child = null;
        }

        RootNode rootNode = parent as RootNode;
        if (rootNode)
        {
            rootNode.child = null;
        }

        CompositeNode composite = parent as CompositeNode;
        if (composite)
        {
            composite.children.Remove(child);
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

    public BehaviorTree Clone()
    {
        BehaviorTree tree = Instantiate(this);
        tree.root = tree.root.Clone();
        return tree;
    }
}