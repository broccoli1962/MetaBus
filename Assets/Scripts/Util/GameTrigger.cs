using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTrigger : BaseTrigger
{
    [SerializeField] private GameObject imageAndtext;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private string sceneName;

    private int bestScore = 0;

    public void Start()
    {
        bestScore = PlayerPrefs.GetInt(sceneName, 0);
        bestScoreText.text = bestScore.ToString();
    }

    public override void EnterTrigger(PlayerController player)
    {
        imageAndtext.SetActive(true);
    }

    public override void ExitTrigger(PlayerController player)
    {
        imageAndtext.SetActive(false);
    }

    public override void Interact(PlayerController player)
    {
        GameManager.Instance.SavePlayerPosition(player.transform.position);
        GameManager.Instance.playerLocation = player.transform.position;
        SceneManager.LoadScene(sceneName);
    }
}