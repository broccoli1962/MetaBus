using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    [SerializeField] private float healthChangeDelay = 0.5f;
    private float timeSinceLastChange = float.MaxValue;

    public BaseController controller;
    public AnimationHandler animation;
    public float CurrentHealth { get; private set; }
    public float MaxHealth => controller.Health;

    private Action<float, float> OnChangeHealth;

    private void Awake()
    {
        controller = GetComponent<BaseController>();
        animation = GetComponent<AnimationHandler>();
    }

    private void Start()
    {
        CurrentHealth = controller.Health;
    }

    private void Update()
    {
        if (timeSinceLastChange < healthChangeDelay)
        {
            timeSinceLastChange += Time.deltaTime;
            if (timeSinceLastChange >= healthChangeDelay)
            {
                animation.InvincibilityEnd();
            }
        }
    }

    public bool ChangeHealth(float change)
    {
        if (change == 0) return false;

        CurrentHealth += change;
        CurrentHealth = CurrentHealth > MaxHealth ? MaxHealth : CurrentHealth;
        CurrentHealth = CurrentHealth < 0 ? 0 : CurrentHealth;

        OnChangeHealth?.Invoke(CurrentHealth, MaxHealth);

        if(change < 0)
        {
            animation.Damage();
        }

        if(CurrentHealth <= 0f)
        {
            Death();
        }

        return true;
    }

    private void Death() {
        controller.Death();
    }

    public void AddHealthChangeEvent(Action<float, float> change)
    {
        OnChangeHealth += change;
    }

    public void RemoveHealthChangeEvent(Action<float, float> change) {
        OnChangeHealth -= change;
    }
}
