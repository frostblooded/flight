using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatisticsPanel : MonoBehaviour {
    [HideInInspector]
    public GameObject timePlayedValue;
    [HideInInspector]
    public GameObject deathsCountValue;
    [HideInInspector]
    public GameObject highscoreValue;

    public void OnCloseButtonPressed()
    {
        AudioManager.instance.PlayButtonPressSound();
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        timePlayedValue = transform.Find("Time played value").gameObject;
        deathsCountValue = transform.Find("Deaths count value").gameObject;
        highscoreValue = transform.Find("Highscore value").gameObject;

        float timePlayed = PlayerPrefs.GetInt(Constants.TimePlayedPrefsName, 0);
        int deaths = PlayerPrefs.GetInt(Constants.DeathsPrefsName, 0);
        float highscore = PlayerPrefs.GetInt(Constants.HighscorePrefsName, 0);

        int minutesPlayed = (int)(timePlayed / 60);
        int secondsPlayed = (int)(timePlayed % 60);
        string timePlayedString = string.Format("{0:D2}:{1:D2} minutes", minutesPlayed, secondsPlayed);

        timePlayedValue.GetComponent<Text>().text = timePlayedString;
        deathsCountValue.GetComponent<Text>().text = deaths.ToString();
        highscoreValue.GetComponent<Text>().text = highscore.ToString();
    }
}
