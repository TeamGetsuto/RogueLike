public enum Orientation
{
    north, //�k
    east,  //��
    south, //��
    west,  //��
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
