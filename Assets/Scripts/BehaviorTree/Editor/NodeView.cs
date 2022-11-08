using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;

public class NodeView : UnityEditor.Experimental.GraphView.Node
{
    public Action<NodeView> OnNodeSelected;
    public Node node;
    public Port input;
    public Port output;

    public NodeView(Node node)// : base("Asset/Scripts/BehaviorTree/Editor/UIBuilder/NodeView.uxml")
    {
        this.node = node;
        this.title = node.name;
        this.viewDataKey = node.guid;

        style.left = node.pos.x;
        style.top = node.pos.y;

        CreateInputPorts();
        CreateOutputPorts();
    }

    private void CreateInputPorts()
    {
        if(node is ActionNode)
        {
            input = InstantiatePort(Orientation.Vertical, Direction.Input, Port.Capacity.Single, typeof(bool)); 
        }
        else if(node is CompositeNode)
        {
            input = InstantiatePort(Orientation.Vertical, Direction.Input, Port.Capacity.Single, typeof(bool));
        }
        else if(node is DecorateNode)
        {
            input = InstantiatePort(Orientation.Vertical, Direction.Input, Port.Capacity.Single, typeof(bool));
        }
        else if (node is RootNode)
        {
            
        }

        if (input != null)
        {
            input.portName = "";
            inputContainer.Add(input);
        }
    }

    private void CreateOutputPorts()
    {
        if (node is ActionNode)
        {
            
        }
        else if (node is CompositeNode)
        {
            output = InstantiatePort(Orientation.Vertical, Direction.Output, Port.Capacity.Multi, typeof(bool));
        }
        else if (node is DecorateNode)
        {
            output = InstantiatePort(Orientation.Vertical, Direction.Output, Port.Capacity.Single, typeof(bool));
        }
        else if (node is RootNode)
        {
            output = InstantiatePort(Orientation.Vertical, Direction.Output, Port.Capacity.Single, typeof(bool));
        }

        if (output != null)
        {
            output.portName = "";
            outputContainer.Add(output);
        }
    }


    //エディター上の位置の上書き
    public override void SetPosition(Rect newPos)
    {
        base.SetPosition(newPos);
        node.pos.x = newPos.xMin;
        node.pos.y = newPos.yMin;
    }

    public override void OnSelected()
    {
        base.OnSelected();
        if(OnNodeSelected != null)
        {
            OnNodeSelected.Invoke(this);
        }
    }
}
