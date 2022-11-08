using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ダンジョンレベル_", menuName = "ScriptableObjects/ダンジョン/ダンジョンレベル")]
public class DungeonLevelSO : ScriptableObject
{
    #region Basic Details
    [Space(10)]
    [Header("基本情報")]
    #endregion Basic Details

    #region Tooltip
    [Tooltip("レベルの名前")]
    #endregion

    public string levelName;

    #region Room templates for level
    [Space(10)]
    [Header("レベルで使える部屋")]
    #endregion Room templates for level

    #region Tooltip
    [Tooltip("このレベルで生成できる部屋を入れてください")]
    #endregion

    public List<RoomTemplateSO> roomTemplateList;

    #region Room Node Graphs for level
    [Space(10)]
    [Header("レベル生成に使うノードグラフ")]
    #endregion Room Node Graphs for level

    #region Tooltip
    [Tooltip("使えるノードグラフを設定してください")]
    #endregion

    public List<RoomNodeGraphSO> roomNodeGraphList;

    #region Validation

#if UNITY_EDITOR

    private void OnValidate()
    {
        HelperUtilities.ValidateCheckEmptyString(this, nameof(levelName), levelName);
        if (HelperUtilities.ValidateCheckEnumerableValues(this, nameof(roomTemplateList), roomTemplateList))
            return;
        if (HelperUtilities.ValidateCheckEnumerableValues(this, nameof(roomNodeGraphList), roomNodeGraphList))
            return;

        bool isEWCorridor = false;
        bool isNSCorridor = false;
        bool isEntrance = false;

        foreach(RoomTemplateSO roomTemplateSO in roomTemplateList)
        {
            if (roomTemplateSO == null)
                return;
            if (roomTemplateSO.roomNodeType.isCorridorEW)
                isEWCorridor = true;
            if (roomTemplateSO.roomNodeType.isCorridorNS)
                isNSCorridor = true;
            if (roomTemplateSO.roomNodeType.isEntrance)
                isEntrance = true;
        }

        if(isEWCorridor == false)
        {
            Debug.Log(this.name.ToString() + "では左右経路がありません");
        }
        if (isNSCorridor == false)
        {
            Debug.Log(this.name.ToString() + "では上下経路がありません");
        }
        if (isEntrance == false)
        {
            Debug.Log(this.name.ToString() + "では出入口がありません");
        }



        foreach (RoomNodeGraphSO roomNodeGraph in roomNodeGraphList)
        {
            if (roomNodeGraph == null)
               return;

            foreach(RoomNodeSO roomNodeSO in roomNodeGraph.roomNodelist)
            {
                if (roomNodeSO == null)
                    continue;

                if(roomNodeSO.roomNodeType.isEntrance || roomNodeSO.roomNodeType.isCorridorEW || roomNodeSO.roomNodeType.isCorridorNS || roomNodeSO.roomNodeType.isCorridor || roomNodeSO.roomNodeType.isNone)
                    continue;

                bool isRoomNodeTypeFound = false;

                foreach(RoomTemplateSO roomTemplateSO in roomTemplateList)
                {
                    if (roomTemplateSO == null)
                        continue;

                    if(roomTemplateSO.roomNodeType == roomNodeSO.roomNodeType)
                    {
                        isRoomNodeTypeFound = true;
                        break;
                    }
                }

                if (!isRoomNodeTypeFound)
                    Debug.Log(this.name.ToString() + "での" + roomNodeSO.roomNodeType.name.ToString() + "の部屋タイプは" + roomNodeGraph.name.ToString() + "で設定されていません");
            }


        }

    }

#endif

    #endregion Validation

}
