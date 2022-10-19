using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResources : MonoBehaviour
{
    private static GameResources instance;

    public static GameResources Instance
    {
        get
        {
            if(instance == null)
            {
                instance = Resources.Load<GameResources>("GameResources");
            }
            return instance;
        }
    }


    #region Header ダンジョン
    [Space(10)]
    [Header("ダンジョン")]
    #endregion
    #region ツールチップ
    [Tooltip("RoomNodeTypeListSOを使ってください")]
    #endregion

    public RoomNodeTypeListSO roomNodeTypeList;


    /// <summary>
    /// 以下、白築追記
    /// </summary>
    #region BehaviorTree
    [Tooltip("Behaviortree用に追記")]
    #endregion

    public NodeTypeList nodeTypeList;

}
