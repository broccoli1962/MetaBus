using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyManager : MonoBehaviour
{
    static FlappyManager instance;
    public static FlappyManager Instance { get { return instance; } }

    FlappyUI flappyUI;
    FlappyController controller;

    private int score = 0;
    private int bestScore = 0;
    private string bestScoreKey = "FlappyBird";

    private void Awake()
    {
        instance = this;
        flappyUI = FindObjectOfType<FlappyUI>();
        controller = FindObjectOfType<FlappyController>();

        bestScore = PlayerPrefs.GetInt(bestScoreKey);
        flappyUI.UpdateBestScoreText(bestScore);
    }

    public void GameOver()
    {
        PlayerPrefs.SetInt(bestScoreKey, bestScore);
        flappyUI.SetResultUI(score, bestScore);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OutGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void AddScore(int score)
    {
        this.score += score;
        if(this.score >= bestScore)
        {
            bestScore = this.score;
            flappyUI.UpdateBestScoreText(bestScore);
        }
        flappyUI.UpdateInGameScore(this.score);
    }
}
