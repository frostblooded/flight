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
    
    private Transform treeHolder;
    private bool waitingToStart = true;

    IEnumerable CreateTrees()
    {
        while (true)
        {
            Vector3 newTreePosition = new Vector2(Tree.CreationX, 0);
            Instantiate(treePrefab, newTreePosition, Quaternion.identity, treeHolder);
            yield return new WaitForSeconds(SecondsBetweenTrees);
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
        if (waitingToStart)
        {
            Time.timeScale = 0;
            uiHandler.DisplayInfo("Press anywhere to start");
        } else
        {
            uiHandler.gameInfoText.SetActive(false);
        }

        treeHolder = new GameObject("Trees").transform;
        StartCoroutine("CreateTrees");
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Update () {
        if(waitingToStart && Input.anyKey)
        {
            Time.timeScale = 1;
            uiHandler.gameInfoText.SetActive(false);
        }
	}
}
