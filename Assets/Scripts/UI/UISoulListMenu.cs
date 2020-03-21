using MokomoGames;
using MokomoGames.UI;
using UnityEngine;
using UnityEngine.UI;
using TouchType = MokomoGames.TouchType;

public class UISoulListMenu : UIMenuList
{
    [SerializeField] private Button artifactButton;
    [SerializeField] private Button soulListButton;
    [SerializeField] private UISoulListPage soulListPage;

    private void Awake()
    {
        soulListButton.onClick.AddListener(() =>
        {
            soulListPage.gameObject.SetActive(true);
            soulListPage.Begin();
        });
    }

    public override void Tick()
    {
        base.Tick();
        if (soulListPage.gameObject.activeSelf)
            return;

        if (CommonInput.GetTouch() == TouchType.Began)
            if (!CommonInput.IsTouchedUI<UISoulListMenu>())
            {
                OnRequestedClose?.Invoke();
                Close();
            }
    }
}