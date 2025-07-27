using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : BaseController
{
    private Transform target;
    private PlayerController player;

    [SerializeField] private float followRange = 15f;

    protected override void Awake()
    {
        base.Awake();
        player = FindObjectOfType<PlayerController>();
        if(player is null)
        {
            Debug.LogError("타겟 확인 불가능");
        }
        Init(player.transform);
    }
    public void Init(Transform target)
    {
        this.target = target;
    }

    protected float DistanceTarget()
    {
        return Vector2.Distance(transform.position, target.position);
    }
    protected Vector2 DirectionTarget()
    {
        return (target.position - transform.position).normalized;
    }

    protected override void Handler()
    {
        base.Handler();

        if (WeaponHandler == null || target == null)
        {
            movementDirection = Vector2.zero;
            return;
        }

        float distance = DistanceTarget();
        Vector2 direction = DirectionTarget();

        isAttacking = false;

        if (distance <= followRange) {
            lookDirection = direction;

            if (distance < WeaponHandler.WeaponRange) {
                int layerMaskTarget = WeaponHandler.target;
                RaycastHit2D hit = Physics2D.Raycast(transform.position,
                    direction,WeaponHandler.WeaponRange * 1.5f,
                    (1<<LayerMask.NameToLayer("Level"))|layerMaskTarget);

                if (hit.collider != null && layerMaskTarget == (layerMaskTarget | (1 << hit.collider.gameObject.layer)))
                {
                    isAttacking = true;
                }

                movementDirection = Vector2.zero;
                return;
            }
            movementDirection = direction;
        }
    }
}
