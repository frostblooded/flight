using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [HideInInspector]
    public GameObject gameUI;
    [HideInInspector]
    public GameObject scoreText;
    [HideInInspector]
    public GameObject gameInfoText;
    [HideInInspector]
    public GameObject endGameUI;
    [HideInInspector]
    public GameObject endGameText;

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
        gameUI.SetActive(false);
        endGameUI.SetActive(true);
        endGameText.GetComponent<Text>().text = "Your score is: " + score +
            "\nYour highscore is: " + highscore;
    }

    void Start () {
        gameUI = GameObject.Find("Game UI");
        scoreText = GameObject.Find("Score text");
        gameInfoText = GameObject.Find("Game info text");

        endGameUI = GameObject.Find("End game UI");
        endGameText = GameObject.Find("End game text");
        endGameUI.SetActive(false);
    }
}
