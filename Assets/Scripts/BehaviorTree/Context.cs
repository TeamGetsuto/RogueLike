using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//ノードがオブジェクトにアクセスできるようシェア

public class Context
{
    //その他使いたいものを適宜追加してください

    public GameObject gameObject;
    public Transform transform;
    public Rigidbody physics;
    public SphereCollider sphereCollider;
    public BoxCollider boxCollider;
    public CapsuleCollider capsuleCollider;
    public NavMeshAgent agent;
    public Animator animator;
    public CharacterController characterController;

    //その他使いたいものを適宜追加してください

    public static Context CreateFromGameObject(GameObject obj)
    {
        Context context = new Context();

        {   //その他使いたいものを適宜追加してください

            context.gameObject = obj;
            context.transform = obj.transform;
            context.physics = obj.GetComponent<Rigidbody>();
            context.sphereCollider = obj.GetComponent<SphereCollider>();
            context.boxCollider = obj.GetComponent<BoxCollider>();
            context.capsuleCollider = obj.GetComponent<CapsuleCollider>();
            context.agent = obj.GetComponent<NavMeshAgent>();
            context.animator = obj.GetComponent<Animator>();
            context.characterController = obj.GetComponent<CharacterController>();

            //その他使いたいものを適宜追加してください
        }

        return context;
    }
}
