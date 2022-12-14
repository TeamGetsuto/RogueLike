using UnityEngine;

[System.Serializable]
public class Doorway
{
    public Vector2Int position;
    public Orientation orientation;
    public GameObject doorPrefab;

    #region Header
    [Header("部屋の左上の頂点")]
    #endregion
    public Vector2Int doorwayStartCopyPosition;
    #region Header
    [Header("部屋の広さ")]
    #endregion
    public int doorwayCopyTileWidth;
    #region Header
    [Header("部屋の高さ")]
    #endregion
    public int doorwayCopyTileHeight;

    [HideInInspector]
    public bool isConnected = false;
    [HideInInspector]
    public bool isUnavailable = false;


}
