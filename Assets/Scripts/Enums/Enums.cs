public enum Orientation
{
    north, //ñk
    east,  //ìå
    south, //ìÏ
    west,  //êº
    none
}

public enum GameState
{
    gameStarted,
    playingLevel,
    engagingEnemies,
    bossStage,
    engagingBoss,
    levelCompleted,
    gameWon,
    gameLost,
    gamePaused,
    dungeonOverviewMap,
    restartGame
}

public enum AimDirection
{
    UpRight,
    Up,
    UpLeft,
    Right,
    Left,
    DownRight,
    Down,
    DownLeft
}
