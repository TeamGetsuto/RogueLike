using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorRunner : MonoBehaviour
{
    public BehaviorTree tree;
    // Start is called before the first frame update
    void Start()
    {
       tree = tree.Clone();
    }

    // Update is called once per frame
    void Update()
    {
        tree.UpDate();
    }
}
