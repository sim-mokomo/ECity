using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MokomoGames.UI
{
    public class UISoulListPage : Page, ISoulPage
    {
        private UserSoulList _userSoulList;
        [SerializeField] private Button backButton;
        [SerializeField] private TextMeshProUGUI hasSoulNum;
        [SerializeField] private Button homeButton;
        [SerializeField] private UICellScroll soulCellScroll;
        [SerializeField] private UISoulDetailPage soulDetailPage;
        [SerializeField] private UIHasNumSolidLabel soulHasNumSolidLabel;
        [SerializeField] private UITab tab;

        public override void Show(bool show)
        {
            gameObject.SetActive(show);
        }

        public override PageRepository.PageType PageType => PageRepository.PageType.SoulList;

        public override event Action OnTappedHomeButton;

        public override bool Showing => gameObject.activeSelf;

        public override void Begin()
        {
            tab.Begin(UITab.TabType.Battle);
        }

        public void SetData(UserSoulList userSoulList)
        {
            _userSoulList = userSoulList;
        }

        private void Awake()
        {
            tab.OnChangedTab += tabElement =>
            {
                soulCellScroll.DestroyCells();
                var showSouls = tabElement.TabType == UITab.TabType.Battle
                    ? _userSoulList.GetBattleSouls()
                    : _userSoulList.GetMaterialSouls();

                soulHasNumSolidLabel.UpdateHasNum((uint) showSouls.Count(), 9999);
                var cells = soulCellScroll.MakeCells(showSouls.ToList());
                foreach (var cell in cells)
                {
                    cell.OnClick += soul =>
                    {
                        soulDetailPage.Show(true);
                        soulDetailPage.Begin(soul);
                    };

                    cell.OnLongClick += (soul) => {};
                }
            };

            backButton.onClick.AddListener(() => gameObject.SetActive(false));
            homeButton.onClick.AddListener(() =>
            {
                soulCellScroll.DestroyCells();
                gameObject.SetActive(false);
                OnTappedHomeButton?.Invoke();
            });

            soulDetailPage.OnTappedBackButton += () => soulDetailPage.Show(false);
            soulDetailPage.Show(false);
        }
    }
}