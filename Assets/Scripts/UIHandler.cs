using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [HideInInspector]
    public GameObject gameUI;
    [HideInInspector]
    public Text scoreText;
    [HideInInspector]
    public GameObject endGameUI;
    [HideInInspector]
    public Text endGameText;

    public void DisplayGameScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void DisplayEndGameText(int score, int highscore)
    {
        gameUI.SetActive(false);
        endGameUI.SetActive(true);
        endGameText.text = "Your score is: " + score +
            "\nYour highscore is: " + highscore;
    }

    void Start () {
        gameUI = GameObject.Find("Game UI");
        scoreText = GameObject.Find("Score text").GetComponent<Text>();

        endGameUI = GameObject.Find("End game UI");
        endGameText = GameObject.Find("End game text").GetComponent<Text>();
        endGameUI.SetActive(false);
    }
}
