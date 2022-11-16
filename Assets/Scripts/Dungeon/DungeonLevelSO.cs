using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "�_���W�������x��_", menuName = "ScriptableObjects/�_���W����/�_���W�������x��")]
public class DungeonLevelSO : ScriptableObject
{
    #region Basic Details
    [Space(10)]
    [Header("��{���")]
    #endregion Basic Details

    #region Tooltip
    [Tooltip("���x���̖��O")]
    #endregion

    public string levelName;

    #region Room templates for level
    [Space(10)]
    [Header("���x���Ŏg���镔��")]
    #endregion Room templates for level

    #region Tooltip
    [Tooltip("���̃��x���Ő����ł��镔�������Ă�������")]
    #endregion

    public List<RoomTemplateSO> roomTemplateList;

    #region Room Node Graphs for level
    [Space(10)]
    [Header("���x�������Ɏg���m�[�h�O���t")]
    #endregion Room Node Graphs for level

    #region Tooltip
    [Tooltip("�g����m�[�h�O���t��ݒ肵�Ă�������")]
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
            Debug.Log(this.name.ToString() + "�ł͍��E�o�H������܂���");
        }
        if (isNSCorridor == false)
        {
            Debug.Log(this.name.ToString() + "�ł͏㉺�o�H������܂���");
        }
        if (isEntrance == false)
        {
            Debug.Log(this.name.ToString() + "�ł͏o����������܂���");
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
                    Debug.Log(this.name.ToString() + "�ł�" + roomNodeSO.roomNodeType.name.ToString() + "�̕����^�C�v��" + roomNodeGraph.name.ToString() + "�Őݒ肳��Ă��܂���");
            }


        }

    }

#endif

    #endregion Validation

}
