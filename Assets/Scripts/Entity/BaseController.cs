using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    protected Rigidbody2D rigid2d;

    [SerializeField] private SpriteRenderer characterRender;
    [SerializeField] private Transform pivot;

    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get { return lookDirection; } }

    protected virtual void Awake()
    {
        rigid2d = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        Rotate(movementDirection);
    }

    protected virtual void FixedUpdate()
    {
        Move(movementDirection);
    }

    private void Move(Vector2 direction)
    {
        direction = direction * 5f;
        rigid2d.velocity = direction;
    }

    private void Rotate(Vector2 direction)
    {
        if (direction != Vector2.zero) {
            float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            bool isLeft = Mathf.Abs(rotZ) > 90;

            characterRender.flipX = isLeft;
        }
    }
}
