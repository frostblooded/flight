using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [HideInInspector]
    public GameObject duringGameUI;
    [HideInInspector]
    public GameObject scoreText;
    [HideInInspector]
    public GameObject infoText;
    [HideInInspector]
    public GameObject afterGameUI;
    [HideInInspector]
    public GameObject scoreResultText;
    [HideInInspector]
    public GameObject statisticsWindow;

    public void DisplayGameScore(int score)
    {
        scoreText.GetComponent<Text>().text = score.ToString();
    }

    public void DisplayInfo(string info)
    {
        infoText.GetComponent<Text>().text = info;
    }

    public void DisplayEndGameText(int score, int highscore)
    {
        duringGameUI.SetActive(false);
        afterGameUI.SetActive(true);
        scoreResultText.GetComponent<Text>().text = "Your score is: " + score;
    }

    public void OpenStatisticsPanel()
    {
        AudioManager.instance.PlayButtonPressSound();

        // Toggle if the panel is active
        statisticsWindow.SetActive(!statisticsWindow.activeSelf);
        Time.timeScale = statisticsWindow.activeSelf ? 0 : 1f;
    }

    public void TryAgainButtonClicked()
    {
        AudioManager.instance.PlayButtonPressSound();

        // Restart current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MuteButtonPressed()
    {
        AudioListener.pause = !AudioListener.pause;
        AudioManager.instance.PlayButtonPressSound();
    }

    void Start () {
        duringGameUI = GameObject.Find("During game UI");
        scoreText = GameObject.Find("Score text");
        infoText = GameObject.Find("Info text");

        afterGameUI = GameObject.Find("After game UI");
        scoreResultText = GameObject.Find("Score result text");
        afterGameUI.SetActive(false);

        statisticsWindow = GameObject.Find("Statistics window");
        statisticsWindow.SetActive(false);
    }
}
