using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    protected Rigidbody2D rigid2d;

    [SerializeField] private SpriteRenderer characterRender;
    [SerializeField] private Transform pivot;

    [Range(0, 100)][SerializeField] private int health = 10;
    public int Health { get => health; set => health = Mathf.Clamp(value, 0, 100); }

    [Range(0, 20)][SerializeField] private float speed = 3f;
    public float Speed { get => speed; set => speed = Mathf.Clamp(value, 0, 20); }

    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get { return lookDirection; } }

    [SerializeField] private BaseWeapon weaponPrefab;
    protected BaseWeapon WeaponHandler;
    protected AnimationHandler animation;

    protected bool isAttacking;
    private float timeSinceLastAttack = float.MaxValue;

    protected virtual void Awake()
    {
        rigid2d = GetComponent<Rigidbody2D>();
        animation = GetComponent<AnimationHandler>();

        if(weaponPrefab != null)
        {
            WeaponHandler = Instantiate(weaponPrefab, pivot);
        }
        else
        {
            WeaponHandler = GetComponentInChildren<BaseWeapon>();
        }
    }

    protected virtual void Update()
    {
        Handler();
        Rotate(LookDirection);
        AttackDelay();
    }

    protected virtual void FixedUpdate()
    {
        Move(movementDirection);
    }

    protected virtual void Handler()
    {
        
    }

    private void AttackDelay()
    {
        if (WeaponHandler == null)
            return;

        if(timeSinceLastAttack <= WeaponHandler.Delay)
        {
            timeSinceLastAttack += Time.deltaTime;
        }

        if(isAttacking && timeSinceLastAttack > WeaponHandler.Delay)
        {
            timeSinceLastAttack = 0;
            Attack();
        }
    }

    public virtual void Attack()
    {
        if (LookDirection != Vector2.zero) {
            WeaponHandler?.Attack();
        }
    }

    private void Move(Vector2 direction)
    {
        direction = direction * Speed;
        rigid2d.velocity = direction;
        animation.Move(direction);
    }

    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90;
        characterRender.flipX = isLeft;

        if(pivot != null)
        {
            pivot.rotation= Quaternion.Euler(0f, 0f, rotZ);
        }

        WeaponHandler?.Rotate(isLeft);
    }

    public virtual void Death()
    {

    }
}
