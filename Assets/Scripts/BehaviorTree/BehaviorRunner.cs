using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorRunner : MonoBehaviour
{
    BehaviorTree tree;
    // Start is called before the first frame update
    void Start()
    {
        tree = ScriptableObject.CreateInstance<BehaviorTree>();

        var log1 = ScriptableObject.CreateInstance<Debugger>();
        log1.message = "HelloWorld_111";

        var pause = ScriptableObject.CreateInstance<WaitNode>();
        pause.waitTime = 1.0f;

        var log2 = ScriptableObject.CreateInstance<Debugger>();
        log2.message = "HelloWorld_222";

        var log3 = ScriptableObject.CreateInstance<Debugger>();
        log3.message = "HelloWorld_333";

        var sequence = ScriptableObject.CreateInstance<Sequencer>();
        sequence.children.Add(log1);
        sequence.children.Add(pause);
        sequence.children.Add(log2);
        sequence.children.Add(pause);
        sequence.children.Add(log3);
        sequence.children.Add(pause);

        var loop = ScriptableObject.CreateInstance<Repeater>();
        loop.child = sequence;

        tree.root = loop;
    }

    // Update is called once per frame
    void Update()
    {
        tree.UpDate();
    }
}
