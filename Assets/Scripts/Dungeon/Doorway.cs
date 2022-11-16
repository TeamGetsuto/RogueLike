using UnityEngine;

[System.Serializable]
public class Doorway
{
    public Vector2Int position;
    public Orientation orientation;
    public GameObject doorPrefab;

    #region Header
    [Header("•”‰®‚Ì¶ã‚Ì’¸“_")]
    #endregion
    public Vector2Int doorwayStartCopyPosition;
    #region Header
    [Header("•”‰®‚ÌL‚³")]
    #endregion
    public int doorwayCopyTileWidth;
    #region Header
    [Header("•”‰®‚Ì‚‚³")]
    #endregion
    public int doorwayCopyTileHeight;

    [HideInInspector]
    public bool isConnected = false;
    [HideInInspector]
    public bool isUnavailable = false;


}
