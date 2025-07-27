using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class FlappyUI : MonoBehaviour
{
    public GameObject resultUI;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI InGameScoreText;

    [SerializeField] private Button restartButton;
    [SerializeField] private Button backButton;

    private void Start()
    {
        resultUI.SetActive(false);
        restartButton.onClick.AddListener(OnClickRestartButton);
        backButton.onClick.AddListener(OnClickBackButton);
    }

    public void OnClickRestartButton()
    {
        FlappyManager.Instance.RestartGame();
    }

    public void OnClickBackButton()
    {
        FlappyManager.Instance.OutGame();
    }

    public void SetResultUI(int score, int bestScore)
    {
        resultUI.SetActive(true);
        scoreText.text = score.ToString();
        bestScoreText.text = bestScore.ToString();
    }

    public void UpdateInGameScore(int score)
    {
        InGameScoreText.text = score.ToString();
    }

    public void UpdateBestScoreText(int score)
    {
        bestScoreText.text = score.ToString();
    }
}
