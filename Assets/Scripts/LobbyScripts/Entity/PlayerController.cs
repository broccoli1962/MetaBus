using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : BaseController
{
    private BaseTrigger trigger;

    void Start()
    {
        if(GameManager.Instance.playerLocation != null)
        {
            transform.position = GameManager.Instance.playerLocation;
        }
    }

    void OnMove(InputValue inputValue)
    {
        movementDirection = inputValue.Get<Vector2>();
        movementDirection = movementDirection.normalized;
        lookDirection = movementDirection.normalized;
    }

    void OnInteract(InputValue inputValue) {
        if (inputValue.isPressed && trigger != null)
        {
            trigger.Interact(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TriggerObject"))
        {
            trigger = collision.GetComponent<BaseTrigger>();
            trigger.EnterTrigger(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("TriggerObject"))
        {
            trigger = collision.GetComponent<BaseTrigger>();
            trigger.ExitTrigger(this);
        }
        trigger = null;
    }
}
