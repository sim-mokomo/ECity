using MokomoGames;
using UnityEngine;
using UnityEngine.UI;
using TouchType = MokomoGames.TouchType;

public class UISoulLaboMenu : UIMenuList
{
    [SerializeField] private Button listButton;
    [SerializeField] private Button saleButton;

    public Button ListButton => listButton;
    public Button SaleButton => saleButton;

    public override void Tick()
    {
        base.Tick();
        if (CommonInput.GetTouch() == TouchType.Began)
            if (!CommonInput.IsTouchedUI<UISoulLaboMenu>())
                OnRequestedClose?.Invoke();
    }
}