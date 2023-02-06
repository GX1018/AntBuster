using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class GData
{
    public const string SCENE_NAME_TITLE = "01.TitleScene";
    public const string SCENE_NAME_PLAY = "02.PlayScene";
    public const string SCENE_NAME_PLAY2 = "03.Stage2Scene";
    public const string SCENE_NAME_CLEAR = "04.ClearScene";
    public const string SCENE_NAME_GAMEOVER = "05.GameOverScene";
    public const string SCENE_NAME_Debug = "99.DebugScene";

    public const string OBJ_NAME_CURRENT_LEVEL = "Level_1";
}

public enum PuzzleType
{
    NONE = -1, 
    PUZZLE_BIG_TRIANGLE
}       // PuzzleType
