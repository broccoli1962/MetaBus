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
        //대화창 클릭할려면 상호작용키를 누르시오
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
        //대충 대화 로그 띄우기
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
