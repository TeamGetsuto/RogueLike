using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName ="����_", menuName = "ScriptableObjects/�_���W����/����")]
public class RoomTemplateSO : ScriptableObject
{
    [SerializeField] public string guid;
    #region Header Room PREFAB

    [Space(10)]
    [Header("���� PREFAB")]

    #endregion

    #region Tooltip
    [Tooltip("���̕����̂��ׂẴ^�C����I�u�W�F�N�g�̏��������Ă���")]

    #endregion�@Tooltip

    public GameObject prefab;

    [HideInInspector] public GameObject previousPrefab;

    #region Header Room PREFAB

    [Space(10)]
    [Header("���� �ݒ�")]

    #endregion

    #region Tooltip
    [Tooltip("���̕����̃^�C�v")]

    #endregion�@Tooltip

    public RoomNodeTypeSO roomNodeType;

    #region Tooltip
    [Tooltip("���̕����̑傫���u�����v")]

    #endregion�@Tooltip

    public Vector2Int lowerBounds;

    #region Tooltip
    [Tooltip("���̕����̑傫���u�E��v")]

    #endregion�@Tooltip

    public Vector2Int upperBounds;

    #region Tooltip
    [Tooltip("���̕����̏o���� / �o������3�}�X�̕����K�v�ł�")]

    #endregion�@Tooltip

    [SerializeField] public List<Doorway> doorwayList;

    #region Tooltip
    [Tooltip("���̕����́����𔭐�����ꏊ�u�G�A�A�C�e���Ȃǁv")]

    #endregion�@Tooltip

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
