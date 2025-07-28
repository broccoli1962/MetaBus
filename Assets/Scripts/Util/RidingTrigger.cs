using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RidingTrigger : BaseTrigger
{
    [SerializeField] private GameObject ridingUI;
    [SerializeField] private float rideSpeed = 5f;
    private Animator ridingAnim;

    private void Awake()
    {
        ridingAnim = GetComponentInChildren<Animator>();
    }

    public override void EnterTrigger(PlayerController player)
    {
        ridingUI.SetActive(true);
    }

    public override void ExitTrigger(PlayerController player)
    {
        ridingUI.SetActive(false);
    }

    public override void Interact(PlayerController player)
    {
        if (!player.isRide && ridingAnim != null) {
            player.StartRide(ridingAnim.runtimeAnimatorController, rideSpeed);
        }
    }
}
