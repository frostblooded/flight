using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatisticsPanel : MonoBehaviour {
    public const string HighscorePrefsName = "highscore";
    public const string DeathsPrefsName = "deaths";
    public const string TimePlayedPrefsName = "timePlayed";

    [HideInInspector]
    public GameObject timePlayedValue;
    [HideInInspector]
    public GameObject deathsCountValue;
    [HideInInspector]
    public GameObject highscoreValue;

    private void OnEnable()
    {
        timePlayedValue = GameObject.Find("Time played value");
        deathsCountValue = GameObject.Find("Deaths count value");
        highscoreValue = GameObject.Find("Highscore value");

        float timePlayed = PlayerPrefs.GetFloat(TimePlayedPrefsName, 0);
        int deaths = PlayerPrefs.GetInt(DeathsPrefsName, 0);
        float highscore = PlayerPrefs.GetInt(HighscorePrefsName, 0);

        int minutesPlayed = (int)(timePlayed / 60);
        int secondsPlayed = (int)(timePlayed % 60);
        string timePlayedString = string.Format("{0:D2}:{1:D2} minutes", minutesPlayed, secondsPlayed);

        timePlayedValue.GetComponent<Text>().text = timePlayedString;
        deathsCountValue.GetComponent<Text>().text = deaths.ToString();
        highscoreValue.GetComponent<Text>().text = highscore.ToString();
    }
}
