using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float SecondsBetweenTrees = 1;
    public GameObject treePrefab;
    public UIHandler uiHandler;
    public GameObject musicPlayerPrefab;
    public AudioPlayer audioPlayer;
    
    private Transform treeHolder;
    private bool waitingToStart = true;

    void CreateTrees()
    {
        Vector3 newTreePosition = new Vector2(Tree.CreationX, 0);
        Instantiate(treePrefab, newTreePosition, Quaternion.identity, treeHolder);
    }

    /// <summary>
    /// Updates the statistics of the player if necessary
    /// </summary>
    /// <returns>The high score after it has been updated</returns>
    private int UpdateStatistics(Player player)
    {
        int currentHighscore = PlayerPrefs.GetInt(StatisticsPanel.HighscorePrefsName, 0);
        int currentDeaths = PlayerPrefs.GetInt(StatisticsPanel.DeathsPrefsName, 0);
        int currentTimePlayed = PlayerPrefs.GetInt(StatisticsPanel.TimePlayedPrefsName, 0);

        PlayerPrefs.SetInt(StatisticsPanel.DeathsPrefsName, currentDeaths + 1);
        PlayerPrefs.SetFloat(StatisticsPanel.TimePlayedPrefsName, currentTimePlayed + Time.time);

        if (player.score > currentHighscore)
        {
            PlayerPrefs.SetInt(StatisticsPanel.HighscorePrefsName, player.score);
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

    public void TryAgainButtonClicked()
    {
        audioPlayer.PlayButtonPressSound();
        RestartScene();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartMusic()
    {
        if(GameObject.Find("Audio Player") == null)
        {
            GameObject audioPlayerObject = Instantiate(musicPlayerPrefab);
            audioPlayerObject.name = "Audio Player";
            audioPlayer = audioPlayerObject.GetComponent<AudioPlayer>();
        }
        else
        {
            audioPlayer = GameObject.FindObjectOfType<AudioPlayer>();
        }
    }

    private void Start()
    {
        if (waitingToStart)
        {
            Time.timeScale = 0;
            uiHandler.DisplayInfo("Press anywhere to start");
        } else
        {
            uiHandler.gameInfoText.SetActive(false);
        }

        treeHolder = new GameObject("Trees").transform;
        InvokeRepeating("CreateTrees", 0, SecondsBetweenTrees);
        StartMusic();
    }

    void Update () {
        if(waitingToStart && Input.anyKey)
        {
            Time.timeScale = 1;
            uiHandler.gameInfoText.SetActive(false);
            waitingToStart = false;
        }
	}
}
