using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorRunner : MonoBehaviour
{
    public BehaviorTree tree;

    Context context;
    // Start is called before the first frame update
    void Start()
    {
        context = CreateBTContext();
        tree = tree.Clone();
        tree.Bind(context);
    }

    // Update is called once per frame
    void Update()
    {
        if (tree)
        {
            tree.UpDate();
        }
    }

    Context CreateBTContext()
    {
        return Context.CreateFromGameObject(gameObject);
    }
}
