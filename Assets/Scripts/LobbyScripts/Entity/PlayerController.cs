using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : BaseController
{
    private Animator playerAnim;

    private BaseTrigger trigger;
    private RuntimeAnimatorController originAnim;
    private float originSpeed;
    
    public bool isRide {  get; set; } = false;

    protected override void Awake()
    {
        base.Awake();
        playerAnim = GetComponentInChildren<Animator>();

        if (playerAnim != null) {
            originAnim = playerAnim.runtimeAnimatorController;
        }
        originSpeed = Speed;
    }

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
        else if (isRide && inputValue.isPressed) {
            StopRide();
        }
    }

    public void StartRide(RuntimeAnimatorController rideAnim, float rideSpeed)
    {
        if (playerAnim != null)
        {
            playerAnim.runtimeAnimatorController = rideAnim;
        }
        Speed = rideSpeed;
        isRide = true;
    }
    public void StopRide()
    {
        if (playerAnim != null) {
            playerAnim.runtimeAnimatorController = originAnim;
        }
        Speed = originSpeed;
        isRide = false;
    }

    public void SelectSkin(RuntimeAnimatorController skin)
    {
        if (playerAnim != null) {
            playerAnim.runtimeAnimatorController = skin;
            originAnim = skin;
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
