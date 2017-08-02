using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject treePrefab;
    public UIHandler uiHandler;
    public GameObject musicPlayerPrefab;
    
    private Transform treeHolder;
    private bool waitingToStart = true;

    void CreateTrees()
    {
        Vector3 newTreePosition = new Vector2(Constants.TreeCreationX, 0);
        Instantiate(treePrefab, newTreePosition, Quaternion.identity, treeHolder);
    }

    /// <summary>
    /// Updates the statistics of the player if necessary
    /// </summary>
    /// <returns>The high score after it has been updated</returns>
    private int UpdateStatistics(Player player)
    {
        int currentHighscore = PlayerPrefs.GetInt(Constants.HighscorePrefsName, 0);
        int currentDeaths = PlayerPrefs.GetInt(Constants.DeathsPrefsName, 0);
        int currentTimePlayed = PlayerPrefs.GetInt(Constants.TimePlayedPrefsName, 0);

        PlayerPrefs.SetInt(Constants.DeathsPrefsName, currentDeaths + 1);
        PlayerPrefs.SetFloat(Constants.TimePlayedPrefsName, currentTimePlayed + Time.time);

        if (player.score > currentHighscore)
        {
            PlayerPrefs.SetInt(Constants.HighscorePrefsName, player.score);
            PlayerPrefs.Save();
            return player.score;
        }

        PlayerPrefs.Save();
        return currentHighscore;
    }

    public void EndGame(Player player)
    {
        int highscore = UpdateStatistics(player);
        uiHandler.DisplayEndGameText(player.score, highscore);
        Destroy(player.gameObject);
    }

    private void Start()
    {
        if (waitingToStart)
        {
            Time.timeScale = 0;
            uiHandler.DisplayInfo("Press anywhere to start");
        } else
        {
            uiHandler.infoText.SetActive(false);
        }

        treeHolder = new GameObject("Trees").transform;
        InvokeRepeating("CreateTrees", 0, Constants.SecondsBetweenTrees);
    }

    void Update () {
        if(waitingToStart && Input.anyKey)
        {
            Time.timeScale = 1;
            uiHandler.infoText.SetActive(false);
            waitingToStart = false;
        }
	}
}
