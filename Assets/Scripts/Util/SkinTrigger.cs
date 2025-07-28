using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinTrigger : BaseTrigger
{
    [SerializeField] private GameObject SkinUI;
    [SerializeField] List<RuntimeAnimatorController> animators = new List<RuntimeAnimatorController>();
    [SerializeField] List<Image> images = new List<Image>();

    [SerializeField] private Animator animator;

    PlayerController playerController;
    [SerializeField] private int selectSkinNum = 0;

    public Image image;
    public Button leftButton;
    public Button rightButton;
    public Button selectButton;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void Start()
    {
        selectButton.onClick.AddListener(OnSelected);
        leftButton.onClick.AddListener(OnLeft);
        rightButton.onClick.AddListener(OnRight);
    }

    public override void EnterTrigger(PlayerController player)
    {
    }

    public override void ExitTrigger(PlayerController player)
    {
        SkinUI.SetActive(false);
    }

    public override void Interact(PlayerController player)
    {
        SkinUI.SetActive(true);
    }

    public void OnSelected()
    {
        playerController.SelectSkin(animators[selectSkinNum]);
    }

    public void OnLeft()
    {
        selectSkinNum--;
        if(selectSkinNum < 0)
        {
            selectSkinNum = animators.Count-1;
        }
        animator.runtimeAnimatorController = animators[selectSkinNum];
        image = images[selectSkinNum];        
    }

    public void OnRight()
    {
        selectSkinNum++;
        if(selectSkinNum > animators.Count-1)
        {
            selectSkinNum = 0;
        }
        animator.runtimeAnimatorController = animators[selectSkinNum];
        image = images[selectSkinNum];
    }
}
