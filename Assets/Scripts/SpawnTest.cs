using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTest : MonoBehaviour
{
    public RoomTemplateSO roomTemplateSO;

    private List<SpawnableObjectsByLevel<EnemyInfoSO>> testLevelSpawnList;
    private RandomSpawnableObject<EnemyInfoSO> randomEnemyHelperClass;
    private List<GameObject> instantiatedEnemyList = new List<GameObject> ();

    private void OnEnable()
    {
        StaticEventHandler.OnRoomChanged += StaticEventHandler_OnRoomChanged;
    }
    private void OnDisable()
    {
        StaticEventHandler.OnRoomChanged -= StaticEventHandler_OnRoomChanged;
    }

    private void StaticEventHandler_OnRoomChanged(RoomChangedEventArgs roomChangedEventArgs)
    {
        if(instantiatedEnemyList!= null && instantiatedEnemyList.Count>0)
        {
            foreach(GameObject enemy in instantiatedEnemyList)
            {
                Destroy(enemy);
            }
        }
        RoomTemplateSO roomTemplateSO = DungeonBuilder.Instance.GetRoomTemplate(roomChangedEventArgs.room.templateID);
        if(roomTemplateSO != null)
        {
            testLevelSpawnList = roomTemplateSO.enemiesByLevelList;

            randomEnemyHelperClass = new RandomSpawnableObject<EnemyInfoSO>(testLevelSpawnList);
        }

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            EnemyInfoSO enemyDetails = randomEnemyHelperClass.GetItem();

            if (enemyDetails != null)
            {
                instantiatedEnemyList.Add(Instantiate(enemyDetails.enemyPrefab, HelperUtilities.GetSpawnPositionNearestToPlayer(HelperUtilities.GetMouseWorldPosition()), Quaternion.identity));
            }

        }
    }

}
