using System;
using System.Collections.Generic;
using System.Linq;
using PlayFab.ClientModels;
using TMPro;
using UniRx.Async;
using UniRx.Async.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace MokomoGames.UI
{
    public class UISoulSalePage : Page, ISoulPage
    {
        [SerializeField] private UICellScroll _cellScroll;
        [SerializeField] private Button backButton;
        [SerializeField] private Button homeButton;
        [SerializeField] private Button selectingClearButton;
        [SerializeField] private Button saleButton;
        [SerializeField] private UIHasNumSolidLabel soulHasNumSolidLabel;
        [SerializeField] private UITab tab;
        [SerializeField] private TextMeshProUGUI shizukuHasNum;
        [SerializeField] private TextMeshProUGUI karumaHasNum;
        [SerializeField] private TextMeshProUGUI acquisitionShizukNum;
        [SerializeField] private TextMeshProUGUI acquisitionKarumaNum;
        [SerializeField] private UISoulDetailPage soulDetailPage;
        private UserSoulList userSoulList;
        private IEnumerable<UISoulCell> cells;
        public IEnumerable<UISoulCell> Cells => cells;
        public IEnumerable<UISoulCell> ActivateCells => Cells.Where(x => x.Showing);
        public event Action OnTappedSelectingClearButton;
        public event Action OnTappedSaleButton;
        public override event Action OnTappedHomeButton;
        public event Action<UITabElement> OnChangedTab; 

        public override void Show(bool show)
        {
            gameObject.SetActive(show);
        }

        public override PageRepository.PageType PageType => PageRepository.PageType.SoulSale;
        
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
            backButton.onClick.AddListener(() => gameObject.SetActive(false));
            homeButton.onClick.AddListener(() =>
            {
                _cellScroll.DestroyCells();
                gameObject.SetActive(false);
                OnTappedHomeButton?.Invoke();
            });
            
            tab.OnChangedTab += (tabElement) => OnChangedTab?.Invoke(tabElement);
            selectingClearButton.onClick.AddListener(() => OnTappedSelectingClearButton?.Invoke());
            saleButton.onClick.AddListener(() => OnTappedSaleButton?.Invoke());

            UpdateHasShizukuNum(0);
            UpdateHasKarumaNum(0);
            UpdateAcquisionShizukuNum(0);
            UpdateAcquisionKarumaNum(0);
        }

        public IEnumerable<UISoulCell> MakeIcons(IEnumerable<Soul> souls)
        {
            _cellScroll.DestroyCells();

            soulHasNumSolidLabel.UpdateHasNum((uint) souls.Count(), 9999);
            cells = _cellScroll.MakeCells(souls.ToList());
            foreach (var cell in cells)
            {
                cell.Selecting(false);
                cell.OnLongClick += (soul) =>
                {
                    soulDetailPage.Show(true);
                    soulDetailPage.Begin(soul);
                    soulDetailPage.OnTappedBackButton += () => { soulDetailPage.Show(false); };
                };
            }

            return cells;
        }

        public void UpdateSelecting(List<Soul> souls)
        {
            foreach (var cell in ActivateCells)
            {
                cell.Selecting(souls.FirstOrDefault(soul => soul.Equals(cell.Soul)) != null);
            }
        }

        public void UpdateHasShizukuNum(uint shizuku)
        {
            shizukuHasNum.text = $"{0}";
        }
        public void UpdateHasKarumaNum(uint karuma)
        {
            karumaHasNum.text = $"{0}";
        }

        public void UpdateAcquisionShizukuNum(uint shizuku)
        {
            acquisitionShizukNum.text = $"{shizuku}";
        }
        
        public void UpdateAcquisionKarumaNum(uint karuma)
        {
            acquisitionKarumaNum.text = $"{karuma}";
        }
    }
}