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
    [HideInInspector]
    public bool gameHasEnded = false;

    private const string HighscorePrefsName = "highscore";

    private DateTime? lastTreesCreatedAt;
    private Transform treeHolder;

    private void CreateTree()
    {
        // If enought seconds have passed since the last tree was created,
        // create a new tree now.
        // The variable starts as null, so that it can be detected to start
        // creating trees immediately when the game starts.
        if(lastTreesCreatedAt == null
            || lastTreesCreatedAt.Value.AddSeconds(SecondsBetweenTrees) < DateTime.Now)
        {
            Vector3 newTreePosition = new Vector2(Tree.CreationX, 0);
            Instantiate(treePrefab, newTreePosition, Quaternion.identity, treeHolder);

            lastTreesCreatedAt = DateTime.Now;
        }
    }

    /// <summary>
    /// Updates the highscore of the player if necessary
    /// </summary>
    /// <returns>The high score after it has been updated</returns>
    private int UpdateHighscore(int score)
    {
        int currentHighscore = PlayerPrefs.GetInt(HighscorePrefsName, 0);

        if (score > currentHighscore)
        {
            PlayerPrefs.SetInt(HighscorePrefsName, score);
            PlayerPrefs.Save();
            return score;
        }

        return currentHighscore;
    }

    public void EndGame(Player player)
    {
        int highscore = UpdateHighscore(player.score);
        uiHandler.DisplayEndGameText(player.score, highscore);
        gameHasEnded = true;
        Destroy(player.gameObject);
    }

    private void Start()
    {
        treeHolder = new GameObject("Trees").transform;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Update () {
        CreateTree();
	}
}
