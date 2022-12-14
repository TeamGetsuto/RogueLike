using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Settings
{
    #region UNITS
    public const float pixelsPerUnit = 16f;
    public const float tileSizePixels = 16f;
    #endregion

    #region Dungeon Build Settings

    public const int maxDungeonRebuildAttemptsForRoomGraph = 1000;
    public const int maxDungeonBuildAttempts = 10;
    public const float doorUnlockDelay = 1f;

    #endregion

    #region Player Tags
    public const string playerTag = "Player";
    public const string playerWeapon = "playerWeapon";
    #endregion

    #region Room SETTING
    public const int maxChildCorridors = 3; //最大ノードの子供の数


    #endregion
}
