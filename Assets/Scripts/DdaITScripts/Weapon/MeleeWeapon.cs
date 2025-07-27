using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class MeleeWeapon : BaseWeapon
{
    public Vector2 attackBoxSize = Vector2.zero;

    protected override void Awake()
    {
        base.Awake();
        attackBoxSize = attackBoxSize * WeaponSize;
    }
    public override void Attack()
    {
        base.Attack();

        RaycastHit2D hit = Physics2D.BoxCast(
            transform.position + (Vector3)Controller.LookDirection * attackBoxSize.x,
            attackBoxSize, 0, Vector2.zero, 1, target);
        Debug.Log(hit.collider);
        if(hit.collider != null)
        {
            ResourceController resource = hit.collider.GetComponent<ResourceController>();
            if(resource != null)
            {
                resource.ChangeHealth(-Power);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (Controller == null)
        {
            // 아직 Controller가 없으면 아무것도 그리지 않고 종료
            return;
        }
        // 기즈모 색상 설정
        Gizmos.color = Color.red;

        // 공격 박스의 중심 위치 계산
        Vector2 attackOrigin = (Vector2)transform.position + (Controller.LookDirection * attackBoxSize.x);

        // 공격 박스를 와이어프레임으로 그리기
        Gizmos.DrawWireCube(attackOrigin, attackBoxSize);
    }


    public override void Rotate(bool isLeft)
    {
        if (isLeft)
            transform.eulerAngles = new Vector3(0, 180, 0);
        else
            transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
