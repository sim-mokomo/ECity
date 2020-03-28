using System;
using MokomoGames;
using MokomoGames.UI;
using UnityEngine;
using UnityEngine.UI;
using TouchType = MokomoGames.TouchType;

public class UISoulListMenu : UIMenuList
{
    [SerializeField] private Button artifactButton;
    [SerializeField] private Button soulListButton;

    private void Awake()
    {
        soulListButton.onClick.AddListener(() =>  RequestPage(PageRepository.PageType.SoulList));
        artifactButton.onClick.AddListener(() =>  RequestPage(PageRepository.PageType.None));
    }

    public override void Tick()
    {
        base.Tick();

        if (CommonInput.GetTouch() == TouchType.Began)
            if (!CommonInput.IsTouchedUI<UISoulListMenu>())
                OnRequestedClose?.Invoke();
    }
}