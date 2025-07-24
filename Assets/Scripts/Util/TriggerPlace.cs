using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TriggerPlace : MonoBehaviour
{
    [SerializeField] private GameObject IaT;
    [SerializeField] private TextMeshProUGUI gameText;

    PlayerController player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IaT.SetActive(true);

            player = collision.GetComponent<PlayerController>();
            if (player != null) {
                player.ChangeGameScene(gameText.text, true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IaT.SetActive(false);

            player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                player.ChangeGameScene(gameText.text, false);
            }
        }
    }
}
