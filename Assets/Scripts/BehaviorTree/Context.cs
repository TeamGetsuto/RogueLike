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
    public Rigidbody2D physics2d;
    public SphereCollider sphereCollider;
    public CircleCollider2D circleCollider2d;
    public BoxCollider boxCollider;
    public BoxCollider2D boxCollider2d;
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
            context.physics2d = obj.GetComponent<Rigidbody2D>();
            context.sphereCollider = obj.GetComponent<SphereCollider>();
            context.circleCollider2d= obj.GetComponent<CircleCollider2D>();
            context.boxCollider = obj.GetComponent<BoxCollider>();
            context.boxCollider2d= obj.GetComponent<BoxCollider2D>();
            context.capsuleCollider = obj.GetComponent<CapsuleCollider>();
            context.agent = obj.GetComponent<NavMeshAgent>();
            context.animator = obj.GetComponent<Animator>();
            context.characterController = obj.GetComponent<CharacterController>();

            //その他使いたいものを適宜追加してください
        }

        return context;
    }
}
