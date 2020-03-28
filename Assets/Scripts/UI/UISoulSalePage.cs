using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace MokomoGames.UI
{
    public class UISoulSalePage : Page, ISoulPage
    {
        [SerializeField] private UICellScroll _cellScroll;
        [SerializeField] private Button backButton;
        [SerializeField] private Button homeButton;
        [SerializeField] private UIHasNumSolidLabel soulHasNumSolidLabel;
        [SerializeField] private UITab tab;
        private UserSoulList userSoulList;

        public override void Show(bool show)
        {
            gameObject.SetActive(show);
        }

        public override PageRepository.PageType PageType => PageRepository.PageType.SoulSale;

        public override event Action OnTappedHomeButton;

        public void SetData(UserSoulList userSoulList)
        {
            this.userSoulList = userSoulList;
        }

        public override bool Showing => gameObject.activeSelf;

        public override void Begin()
        {
            tab.Begin(UITab.TabType.Battle);
        }

        private void Awake()
        {
            tab.OnChangedTab += tabElement =>
            {
                _cellScroll.DestroyCells();
                var showSouls = tabElement.TabType == UITab.TabType.Battle
                    ? userSoulList.GetBattleSouls()
                    : userSoulList.GetMaterialSouls();

                soulHasNumSolidLabel.UpdateHasNum((uint) showSouls.Count(), 9999);
                _cellScroll.MakeCells(showSouls.ToList(), soul =>
                {
                    //TODO: 売却対象として選択できるように
                });
            };

            backButton.onClick.AddListener(() => gameObject.SetActive(false));
            homeButton.onClick.AddListener(() =>
            {
                _cellScroll.DestroyCells();
                gameObject.SetActive(false);
                OnTappedHomeButton?.Invoke();
            });
        }
    }
}