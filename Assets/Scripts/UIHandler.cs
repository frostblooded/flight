using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [HideInInspector]
    public GameObject gameTextUI;
    [HideInInspector]
    public GameObject scoreText;
    [HideInInspector]
    public GameObject gameInfoText;
    [HideInInspector]
    public GameObject endGameUI;
    [HideInInspector]
    public GameObject endGameText;
    [HideInInspector]
    public GameObject statisticsPanel;

    public void DisplayGameScore(int score)
    {
        scoreText.GetComponent<Text>().text = score.ToString();
    }

    public void DisplayInfo(string info)
    {
        gameInfoText.GetComponent<Text>().text = info;
    }

    public void DisplayEndGameText(int score, int highscore)
    {
        gameTextUI.SetActive(false);
        endGameUI.SetActive(true);
        endGameText.GetComponent<Text>().text = "Your score is: " + score;
    }

    public void OpenStatisticsPanel()
    {
        // Toggle if the panel is active
        statisticsPanel.SetActive(!statisticsPanel.activeSelf);
        Time.timeScale = statisticsPanel.activeSelf ? 0 : 1f;

        // TODO: find a better way for the panel opening to work
        endGameUI.SetActive(!endGameUI.activeSelf);
        endGameUI.SetActive(!endGameUI.activeSelf);
    }

    void Start () {
        gameTextUI = GameObject.Find("Game text UI");
        scoreText = GameObject.Find("Score text");
        gameInfoText = GameObject.Find("Game info text");

        endGameUI = GameObject.Find("End game UI");
        endGameText = GameObject.Find("End game text");
        endGameUI.SetActive(false);

        statisticsPanel = GameObject.Find("Statistics panel");
        statisticsPanel.SetActive(false);
    }
}
