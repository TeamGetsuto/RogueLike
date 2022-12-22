using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BlackBoard
{
    public Vector3 moveToPosition;
    public GameObject moveToObject;

    //-----------------------------------------
    //Enemy shared property
    //-----------------------------------------
    public string enemyTypeName;
    public int HP;
    public int attackDamage;
    public float defence;
    public bool isInvincible;
    public int stunResistance;
    //-----------------------------------------
    //-----------------------------------------

    #region Poison Slime
    //-----------------------------------------
    //Poison Slime Property
    //-----------------------------------------
    public Vector2 playerPosition;
    public Vector2 enemyToPlayerDist;
    public bool isEnemyActive;
    public bool canEnemyAttack;
    //-----------------------------------------
    //-----------------------------------------
    #endregion
}
