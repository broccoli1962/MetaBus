using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : BaseController
{
    private Camera cam;
    private string gameSceneText;
    private bool inRange = false;

    protected override void Start()
    {
        base.Start();
        cam = Camera.main;
    }


    void OnMove(InputValue inputValue)
    {
        movementDirection = inputValue.Get<Vector2>();
        movementDirection = movementDirection.normalized;
    }

    void OnInteract(InputValue inputValue) {
        if (inRange) {
            SceneManager.LoadScene(gameSceneText);
        }
        else
        {
            Debug.LogError($"Not Found {gameSceneText} Scene");
        }
    }

    public void ChangeGameScene(string gameText, bool inRange)
    {
        this.inRange = inRange;
        gameSceneText = gameText;
    }
}
