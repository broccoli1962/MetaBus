using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlappyController : MonoBehaviour
{
    Rigidbody2D rigid2d;

    [SerializeField] private float power;
    [SerializeField] private float forwadSpeed;
    public bool isDead = false;

    bool isFlap = false;

    FlappyManager flappyManager;

    private void Start()
    {
        flappyManager = FlappyManager.Instance;
        rigid2d = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        if (isDead) {
            //Dead;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
                if (rigid2d.gravityScale == 0)
                {
                    power = 4;
                    forwadSpeed = 6f;
                    rigid2d.gravityScale = 1;
                }
                isFlap = true;
            }
        }
    }

    public void FixedUpdate()
    {
        if (isDead) return;

        Vector3 velocity = rigid2d.velocity;
        velocity.x = forwadSpeed;

        if (isFlap)
        {
            velocity.y += power;
            isFlap = false;
        }

        rigid2d.velocity = velocity;

        float angle = Mathf.Clamp((rigid2d.velocity.y * 10), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0 , angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isDead) return;

        isDead = true;

        flappyManager.GameOver();
    }
}
