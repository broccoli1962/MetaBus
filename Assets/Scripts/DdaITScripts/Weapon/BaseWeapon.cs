using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    [SerializeField] private float delay = 1f;
    public float Delay { get => delay; set => delay = value; }
    
    [SerializeField] private float weaponSize = 1f;
    public float WeaponSize { get => weaponSize; set => weaponSize = value; }
    
    [SerializeField] private float power = 1f;
    public float Power { get => power; set => power = value; }

    [SerializeField] private float speed = 1f;
    public float Speed { get => speed; set => speed = value; }

    [SerializeField] private float weaponRange = 1f;
    public float WeaponRange { get => weaponRange; set => weaponRange = value; }

    public LayerMask target;

    private static readonly int IsAttack = Animator.StringToHash("IsAttack");

    public BaseController Controller { get; private set; }
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    protected virtual void Awake()
    {
        Controller = GetComponentInParent<BaseController>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
        transform.localScale = Vector3.one * weaponSize;
    }

    public virtual void Attack()
    {
        AttackAnimation();
    }

    public virtual void Rotate(bool isLeft)
    {
        spriteRenderer.flipY = isLeft;
    }

    public void AttackAnimation()
    {
        animator.SetTrigger(IsAttack);
    }
}
