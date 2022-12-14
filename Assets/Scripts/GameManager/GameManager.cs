using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class GameManager : SingletoneMonobehaviour<GameManager>
{
    #region Header DUNGEON LEVELS
    [Space(10)]
    [Header("ダンジョンのレベル")]
    #endregion Header DUNGEON LEVELS

    #region Tooltip
    [Tooltip("このダンジョンのレベル")]
    #endregion Tooltip

    [SerializeField] private List<DungeonLevelSO> dungeonLevelList;

    #region Tooltip
    [Tooltip("テストレベル")]
    #endregion Tooltip

    [SerializeField] private int currentDungeonLevelListIndex = 0;

    [HideInInspector] public GameState gameState;
    [HideInInspector] public GameState previousGameState;

    private Room currentRoom;
    private Room previousRoom;

    /// <summary>
    /// 
    /// </summary>
    public GameObject player;
    [HideInInspector] GameObject playerObject;
    public Cinemachine.CinemachineTargetGroup group;
    /// <summary>
    /// 
    /// </summary>

    // Start is called before the first frame update
    private void Start()
    {
        previousGameState = GameState.gameStarted;
        gameState = GameState.gameStarted;
        SpawnPlayer();
    }

    // Update is called once per frame
    private void Update()
    {
        HandleGameState();

        if(Input.GetKeyDown(KeyCode.R))
        {
            gameState = GameState.gameStarted;
        }
    }

    private void HandleGameState()
    {
        switch (gameState)
        {
            case GameState.gameStarted:

                PlayDungeonLevel(currentDungeonLevelListIndex);

                gameState = GameState.playingLevel;

                SpawnPlayer();

                break;
        }

    }

    private void PlayDungeonLevel(int dungeonLevelListIndex)
    {
        bool dungeonBuiltSuccessfully = DungeonBuilder.Instance.GenerateDungeon(dungeonLevelList[dungeonLevelListIndex]);



        if (!dungeonBuiltSuccessfully)
        {
            Debug.LogError("ダンジョン生成が失敗しました");
        }
    }

    void SpawnPlayer()
    {
        if(playerObject != null)
        {
            group.RemoveMember(playerObject.transform);
            Destroy(playerObject);
        }

        playerObject = Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);

        group.AddMember(playerObject.transform, 1, 5);
    }

    private void OnEnable()
    {
        StaticEventHandler.OnRoomChanged += StaticEventHandler_OnRoomChanged;
    }

    private void OnDisable()
    {
        // Unsubscribe from room changed event
        StaticEventHandler.OnRoomChanged -= StaticEventHandler_OnRoomChanged;
    }

    /// <summary>
    /// Handle room changed event
    /// </summary>
    private void StaticEventHandler_OnRoomChanged(RoomChangedEventArgs roomChangedEventArgs)
    {
        SetCurrentRoom(roomChangedEventArgs.room);
    }

    public void SetCurrentRoom(Room room)
    {
        previousRoom = currentRoom;
        currentRoom = room;
    }

    public Room GetCurrentRoom()
    {
        return currentRoom;
    }

    public DungeonLevelSO GetCurrentDungeonLevel()
    {
        return dungeonLevelList[currentDungeonLevelListIndex];
    }

    #region Validation
#if UNITY_EDITOR
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckEnumerableValues(this, nameof(dungeonLevelList), dungeonLevelList);
    }
#endif
    #endregion Validation


}
