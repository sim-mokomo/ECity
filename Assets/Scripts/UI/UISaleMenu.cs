using System;
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
            souleSaleButton.onClick.AddListener(() => RequestPage(PageType.SoulSale));
            artifactSaleButton.onClick.AddListener(() => RequestPage(PageType.None));
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