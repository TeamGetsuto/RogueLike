using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "�m�[�h�^�C�v���X�g", menuName = "BehaviorTreeEditor/NodeTypeList ...")]
public class NodeTypeList : ScriptableObject
{
    #region �m�[�h�^�C�v���X�g
    [Space(10)]
    [Header("�m�[�h�^�C�v���X�g")]
    #endregion
    #region Tooltip
    [Tooltip("�S�Ă�NodeType��ǉ����Ă��������BENUM�̑���Ɏg���Ă��܂�")]
    #endregion
    public List<Node> nodeList;

    #region Validation
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckEnumerableValues(this, nameof(nodeList), nodeList);
    }
    #endregion
}
