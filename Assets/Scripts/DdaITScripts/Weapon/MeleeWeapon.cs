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
            // ���� Controller�� ������ �ƹ��͵� �׸��� �ʰ� ����
            return;
        }
        // ����� ���� ����
        Gizmos.color = Color.red;

        // ���� �ڽ��� �߽� ��ġ ���
        Vector2 attackOrigin = (Vector2)transform.position + (Controller.LookDirection * attackBoxSize.x);

        // ���� �ڽ��� ���̾����������� �׸���
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
