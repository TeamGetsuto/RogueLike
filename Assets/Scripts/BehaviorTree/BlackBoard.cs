using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BlackBoard
{
    //------------------------------------
    // sample
    public Vector3 moveToPosition;
    public GameObject moveToObject;
    //sample
    //------------------------------------

    [Header("RandomDirection")]
    public Vector2 moveDirection;

    //------------------------------------
    //Enemy
    //------------------------------------
    [Header("Enemy")]
    public bool isEnemyFindPlayer;
    public Vector2 enemyGoalPos;

    //------------------------------------
    //bool
    //------------------------------------
    public bool condition;
}
