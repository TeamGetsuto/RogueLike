using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BlackBoard
{
    //-----------------------------------------------
    //sample
    //-----------------------------------------------
    public Vector3 moveToPosition;
    public GameObject moveToObject;
    //-----------------------------------------------


    //-----------------------------------------------
    //Enemy AI use this property to find player
    //-----------------------------------------------
    public Vector2 playerPosition;


    #region EnemyAI

    public bool isEnemyActive;
    public bool canEnemyAttack;
    public Vector2 enemyToPlayerDist;

    #endregion
}
