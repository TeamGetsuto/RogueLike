using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//�m�[�h���I�u�W�F�N�g�ɃA�N�Z�X�ł���悤�V�F�A

public class Context
{
    //���̑��g���������̂�K�X�ǉ����Ă�������

    public GameObject gameObject;
    public Transform transform;
    public Rigidbody physics;
    public SphereCollider sphereCollider;
    public BoxCollider boxCollider;
    public CapsuleCollider capsuleCollider;
    public NavMeshAgent agent;
    public Animator animator;
    public CharacterController characterController;

    //���̑��g���������̂�K�X�ǉ����Ă�������

    public static Context CreateFromGameObject(GameObject obj)
    {
        Context context = new Context();

        {   //���̑��g���������̂�K�X�ǉ����Ă�������

            context.gameObject = obj;
            context.transform = obj.transform;
            context.physics = obj.GetComponent<Rigidbody>();
            context.sphereCollider = obj.GetComponent<SphereCollider>();
            context.boxCollider = obj.GetComponent<BoxCollider>();
            context.capsuleCollider = obj.GetComponent<CapsuleCollider>();
            context.agent = obj.GetComponent<NavMeshAgent>();
            context.animator = obj.GetComponent<Animator>();
            context.characterController = obj.GetComponent<CharacterController>();

            //���̑��g���������̂�K�X�ǉ����Ă�������
        }

        return context;
    }
}
