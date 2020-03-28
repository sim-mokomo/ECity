using UnityEngine;
using UnityEngine.UI;

namespace MokomoGames.UI
{
    public class UISaleMenu : UIMenuList
    {
        [SerializeField] private Button artifactSaleButton;
        [SerializeField] private Button souleSaleButton;

        private void Awake()
        {
            souleSaleButton.onClick.AddListener(() =>
            {
                //TODO: 魂売却ページを開く
            });

            artifactSaleButton.onClick.AddListener(() =>
            {
                //TODO: artifact売却ページに飛ぶ
            });
        }

        public override void Tick()
        {
            base.Tick();
            if (CommonInput.GetTouch() == TouchType.Began)
                if (!CommonInput.IsTouchedUI<UISaleMenu>())
                    OnRequestedClose?.Invoke();
        }
    }
}