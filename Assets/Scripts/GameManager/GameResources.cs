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

    #region Header Materials
    [Space(10)]
    [Header("MATERIALS")]
    #endregion
    #region ツールチップ
    [Tooltip("Dimmed Material")]
    #endregion

    public Material dimmedMaterial;

}
