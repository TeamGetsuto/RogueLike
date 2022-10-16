using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "�����^�C�v���X�g", menuName = "ScriptableObjects/�_���W����/�����^�C�v-���X�g")]
public class RoomNodeTypeListSO : ScriptableObject
{
    #region �����^�C�v���X�g
    [Space(10)]
    [Header("�����^�C�v���X�g")]
    #endregion
    #region Tooltip
    [Tooltip("�S�Ă�Roo��NodeTypeSO��������ɂ���Ă��������BENUM�̑���Ɏg���Ă��܂�")]
    #endregion
    public List<RoomNodeTypeSO> list;

    #region Validation
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckEnumerableValues(this, nameof(list), list);
    }
    #endregion

}
