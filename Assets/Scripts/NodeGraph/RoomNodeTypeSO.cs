using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "�����^�C�v", menuName = "ScriptableObjects/�_���W����/�����^�C�v")]
public class RoomNodeTypeSO : ScriptableObject
{
    public string roomNodeTypeName;

    #region Header
    [Header("�O���t�G�f�B�^�[�Ō����邩�ǂ���")]
    #endregion
    public bool displayInNodeGraphEditor = true;
    #region Header
    [Header("�o�H�ł���")]
    #endregion
    public bool isCorridor;
    #region Header
    [Header("�㉺�o�H�ł���")]
    #endregion
    public bool isCorridorNS;
    #region Header
    [Header("���E�o�H�ł���")]
    #endregion
    public bool isCorridorEW;
    #region Header
    [Header("�����ł���")]
    #endregion
    public bool isEntrance;
    #region Header
    [Header("�{�X�̕����ł���")]
    #endregion
    public bool isBossRoom;
    #region Header
    [Header("�^�C�v�́u�Ȃ��v�ɂ���K�v������ł���")]
    #endregion
    public bool isNone;

    #region Validation
#if UNITY_EDITOR
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckEmptyString(this, nameof(roomNodeTypeName), roomNodeTypeName);
    }
#endif
    #endregion
}
