using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName ="部屋_", menuName = "ScriptableObjects/ダンジョン/部屋")]
public class RoomTemplateSO : ScriptableObject
{
    [SerializeField] public string guid;
    #region Header Room PREFAB

    [Space(10)]
    [Header("部屋 PREFAB")]

    #endregion

    #region Tooltip
    [Tooltip("この部屋のすべてのタイルやオブジェクトの情報を持っている")]

    #endregion　Tooltip

    public GameObject prefab;

    [HideInInspector] public GameObject previousPrefab;

    #region Header Room PREFAB

    [Space(10)]
    [Header("部屋 設定")]

    #endregion

    #region Tooltip
    [Tooltip("この部屋のタイプ")]

    #endregion　Tooltip

    public RoomNodeTypeSO roomNodeType;

    #region Tooltip
    [Tooltip("この部屋の大きさ「左下」")]

    #endregion　Tooltip

    public Vector2Int lowerBounds;

    #region Tooltip
    [Tooltip("この部屋の大きさ「右上」")]

    #endregion　Tooltip

    public Vector2Int upperBounds;

    #region Tooltip
    [Tooltip("この部屋の出入口 / 出入口は3マスの幅が必要です")]

    #endregion　Tooltip

    [SerializeField] public List<Doorway> doorwayList;

    #region Tooltip
    [Tooltip("この部屋の○○を発生する場所「敵、アイテムなど」")]

    #endregion　Tooltip

    public Vector2Int[] spawnPositionArray;

    #region Header ENEMY DETAILS
    [Space(10)]
    [Header("ENEMY DETAILS")]
    #endregion Header ENEMY DETAILS

    public List<SpawnableObjectsByLevel<EnemyInfoSO>> enemiesByLevelList;

    public List<RoomEnemySpawnParameters> roomEnemySpawnParametersList;


    public List<Doorway> GetDoorwayList()
    {
        return doorwayList;
    }

    #region Validation

#if UNITY_EDITOR

    private void OnValidate()
    {
        
        if(guid == " " || previousPrefab != prefab )
        {
            guid = GUID.Generate().ToString();
            previousPrefab = prefab;
            EditorUtility.SetDirty(this);
        }
        HelperUtilities.ValidateCheckEnumerableValues(this, nameof(doorwayList), doorwayList);

        HelperUtilities.ValidateCheckEnumerableValues(this, nameof(spawnPositionArray), spawnPositionArray);


    }

#endif

    #endregion
}
