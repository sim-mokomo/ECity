using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MokomoGames;
using UnityEngine;
using UnityEngine.UI;
using TouchType = MokomoGames.TouchType;

public class UISoulListMenu : UIMenuList
{
    [SerializeField] private Button soulListButton;
    [SerializeField] private Button artifactButton;
    
    public override void Tick()
    {
        base.Tick();
        if (CommonInput.GetTouch() == TouchType.Began)
        {
            if (!CommonInput.IsTouchedUI<UISoulListMenu>())
            {
                Close();
            }
        }
    }
}
