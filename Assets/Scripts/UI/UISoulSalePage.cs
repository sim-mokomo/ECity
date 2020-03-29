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
        private UserSoulList userSoulList;
        private IEnumerable<UISoulCell> cells;
        public IEnumerable<UISoulCell> Cells => cells;
        public IEnumerable<UISoulCell> ActivateCells => Cells.Where(x => x.Showing);
        public event Action OnTappedSelectingClearButton;
        public event Action OnTappedSaleButton;

        public override void Show(bool show)
        {
            gameObject.SetActive(show);
        }

        public override PageRepository.PageType PageType => PageRepository.PageType.SoulSale;

        public override event Action OnTappedHomeButton;
        public event Action<Soul> OnTappedSoulCellIcon; 

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
                cells = _cellScroll.MakeCells(showSouls.ToList(), OnTappedSoulCellIcon);
                foreach (var cell in cells)
                {
                    cell.Selecting(false);
                }
                //TODO: 売却対象として選択できるように
                //TODO: 魂ごとに、「売却額」「売却カルマ」を定義する
            };

            backButton.onClick.AddListener(() => gameObject.SetActive(false));
            homeButton.onClick.AddListener(() =>
            {
                _cellScroll.DestroyCells();
                gameObject.SetActive(false);
                OnTappedHomeButton?.Invoke();
            });
            
            selectingClearButton.onClick.AddListener(() => OnTappedSelectingClearButton?.Invoke());
            saleButton.onClick.AddListener(() => OnTappedSaleButton?.Invoke());

            UpdateHasShizukuNum(0);
            UpdateHasKarumaNum(0);
            UpdateAcquisionShizukuNum(0);
            UpdateAcquisionKarumaNum(0);
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