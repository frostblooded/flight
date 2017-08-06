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

    public void EndGame(Player player)
    {
        int highscore = PlayerPrefsManager.UpdateStatistics(player);
        uiHandler.DisplayEndGameText(player.score, highscore);
        Destroy(player.gameObject);
    }

    private void MakeGameHarder()
    {
        Time.timeScale += Constants.DifficultyIncrease;
        Console.WriteLine("Time scale set to {0}", Time.timeScale);
    }

    public void OnScoreGained(int score)
    {
        if(score % Constants.PointsPerDifficulty == 0)
        {
            MakeGameHarder();
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
            uiHandler.infoText.SetActive(false);
        }

        treeHolder = new GameObject("Trees").transform;
        InvokeRepeating("CreateTrees", 0, Constants.SecondsBetweenTrees);
    }

    void Update () {
        // Player should jump is required because we only want
        // input below the y for jumping
        if(waitingToStart && Player.PlayerShouldJump())
        {
            Time.timeScale = 1;
            uiHandler.infoText.SetActive(false);
            waitingToStart = false;
        }
	}
}
