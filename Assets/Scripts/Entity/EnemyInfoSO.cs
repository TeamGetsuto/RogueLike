using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "“G_", menuName = "ScriptableObjects/Entity/“G")]
public class EnemyInfoSO : ScriptableObject
{
    public GameObject prefab;

    public string           enemyTypeName;
    public int              HP;
    public int              attackDamage;
    public float            defence; 
    public bool             isInvincible;
    public int              stunResistance;
    public BehaviorTree     templateTree;
}
