using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ノードタイプリスト", menuName = "BehaviorTreeEditor/NodeTypeList ...")]
public class NodeTypeList : ScriptableObject
{
    #region ノードタイプリスト
    [Space(10)]
    [Header("ノードタイプリスト")]
    #endregion
    #region Tooltip
    [Tooltip("全てのNodeTypeを追加してください。ENUMの代わりに使っています")]
    #endregion
    public List<Node> nodeList;

    #region Validation
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckEnumerableValues(this, nameof(nodeList), nodeList);
    }
    #endregion
}
