using System;
using MokomoGames;
using MokomoGames.UI;
using UnityEngine;
using UnityEngine.UI;
using TouchType = MokomoGames.TouchType;

public class UISoulListMenu : UIMenuList
{
    [SerializeField] private Button soulListButton;
    [SerializeField] private Button artifactButton;

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