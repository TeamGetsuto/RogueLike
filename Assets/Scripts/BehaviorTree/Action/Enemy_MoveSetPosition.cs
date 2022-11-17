using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_MoveSetPosition : ActionNode
{
    //2�_�Ԃ��ړ�
    public Vector2 currentPos;  //���ݒn

    public float moveSpeed;     //�ړ����x

    protected override void OnStart()
    {
        
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpDate()
    {
        Debug.Log(blackboard.isEnemyFindPlayer);

        if (blackboard.isEnemyFindPlayer)
        {
            return State.Failure;
        }

        currentPos = context.transform.position;
        Vector2 moveVector = blackboard.enemyGoalPos - currentPos;
        
        if(moveVector.magnitude > 0.1f)
        {
            context.transform.Translate(moveVector.normalized * moveSpeed * Time.deltaTime);
            return State.Running;
        }

        return State.Success;
    }
}
