using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager {
    /// <summary>
    /// Updates the statistics of the player if necessary
    /// </summary>
    /// <returns>The high score after it has been updated</returns>
    public static int UpdateStatistics(Player player)
    {
        int currentHighscore = PlayerPrefs.GetInt(Constants.HighscorePrefsName, 0);
        int currentDeaths = PlayerPrefs.GetInt(Constants.AttemptsPrefsName, 0);
        int currentTimePlayed = PlayerPrefs.GetInt(Constants.TimePlayedPrefsName, 0);
        int currentTotalJumps = PlayerPrefs.GetInt(Constants.TotalJumpsPrefsName, 0);

        PlayerPrefs.SetInt(Constants.AttemptsPrefsName, currentDeaths + 1);
        PlayerPrefs.SetInt(Constants.TimePlayedPrefsName, (int)(currentTimePlayed + Time.time));
        PlayerPrefs.SetInt(Constants.TotalJumpsPrefsName, currentTotalJumps + player.jumps);

        if (player.score > currentHighscore)
        {
            PlayerPrefs.SetInt(Constants.HighscorePrefsName, player.score);
            PlayerPrefs.Save();
            return player.score;
        }

        PlayerPrefs.Save();
        return currentHighscore;
    }
}
