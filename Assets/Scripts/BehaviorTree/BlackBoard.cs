using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BlackBoard
{
    public Vector3 moveToPosition;
    public GameObject moveToObject;

    //-----------------------------------------
    //Poison Slime Property
    //-----------------------------------------
    public Vector2 playerPosition;
    public Vector2 enemyToPlayerDist;
    public bool isEnemyActive;
    public bool canEnemyAttack;
}
