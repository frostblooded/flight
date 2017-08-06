using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    public static float PlayerJumpForce = 11;

    public static int PointsPerDifficulty = 5;
    public static float DifficultyIncrease = 0.2f;

    public static float PlayerJumpSoundMinPitch = 0.8f;
    public static float PlayerJumpSoundMaxPitch = 1.5f;

    public const string HighscorePrefsName = "highscore";
    public const string AttemptsPrefsName = "attempts";
    public const string TimePlayedPrefsName = "timePlayed";
    public const string TotalJumpsPrefsName = "totalJumps";

    public static float SecondsBetweenTrees = 1.5f;
    public static float TreeCreationX = 20;
    public static float TreeMoveSpeed = 0.15f;
    public static float TreeTopComponentMinY = 3;
    public static float TreeTopComponentMaxY = 7;
    public static float DistanceBetweenTreeComponentsY = 3.75f;
    public static float DestroyTreesLeftOfX = -20f;
}
