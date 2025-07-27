using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcTrigger : BaseTrigger
{
    [SerializeField] private GameObject UpperTextUI;
    [SerializeField] private GameObject BigTextUI;
    bool interact = false;
    public override void EnterTrigger(PlayerController player)
    {
        //��ȭâ Ŭ���ҷ��� ��ȣ�ۿ�Ű�� �����ÿ�
        UpperTextUI.SetActive(true);
    }

    public override void ExitTrigger(PlayerController player)
    {
        UpperTextUI.SetActive(false);
        if (interact) {
            BigTextUI.SetActive(false);
            interact = false;
        }
    }

    public override void Interact(PlayerController player)
    {
        //���� ��ȭ �α� ����
        if (!interact) {
            BigTextUI.SetActive(true);
            interact = true;
        }else
        {
            BigTextUI.SetActive(false);
            interact = false;
        }
    }
}
