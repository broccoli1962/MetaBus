using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class BaseTrigger : MonoBehaviour
{
    public abstract void EnterTrigger(PlayerController player);
    public abstract void ExitTrigger(PlayerController player);
    public abstract void Interact(PlayerController player);
}
