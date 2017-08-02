using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    public static float PlayerJumpForce = 11;

    // How much Y below the top of the screen should input
    // for jump be handled
    public static float JumpInputBelowScreenTopY = 70;

    public const string HighscorePrefsName = "highscore";
    public const string DeathsPrefsName = "deaths";
    public const string TimePlayedPrefsName = "timePlayed";

    public static float SecondsBetweenTrees = 1.5f;
    public static float TreeCreationX = 20;
    public static float TreeMoveSpeed = 0.15f;
    public static float TreeTopComponentMinY = 3;
    public static float TreeTopComponentMaxY = 7;
    public static float DistanceBetweenTreeComponentsY = 3.75f;
    public static float DestroyTreesLeftOfX = -20f;
}
