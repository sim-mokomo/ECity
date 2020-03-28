using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace MokomoGames.UI
{
    public class UISoulSalePage : MonoBehaviour, IPage,ISoulPage
    {
        private UserSoulList userSoulList;
        [SerializeField] private Button backButton;
        [SerializeField] private Button homeButton;
        [SerializeField] private UITab tab;
        [SerializeField] private UICellScroll _cellScroll;
        [SerializeField] private UIHasNumSolidLabel soulHasNumSolidLabel;
        public void Show(bool show)
        {
            gameObject.SetActive(show);
        }

        public PageRepository.PageType PageType => PageRepository.PageType.SoulSale;

        public event Action OnTappedHomeButton;

        public void SetData(UserSoulList userSoulList)
        {
            this.userSoulList = userSoulList;
        }

        private void Awake()
        {
            tab.OnChangedTab += tabElement =>
            {
                _cellScroll.DestroyCells();
                var showSouls = tabElement.TabType == UITab.TabType.Battle
                    ? userSoulList.GetBattleSouls()
                    : userSoulList.GetMaterialSouls();
                
                soulHasNumSolidLabel.UpdateHasNum((uint)showSouls.Count(),9999);
                _cellScroll.MakeCells(showSouls.ToList(), soul =>
                {
                    //TODO: 売却対象として選択できるように
                });
            };
            
            backButton.onClick.AddListener( () => gameObject.SetActive(false));
            homeButton.onClick.AddListener(() =>
            {
                _cellScroll.DestroyCells();
                gameObject.SetActive(false);
                OnTappedHomeButton?.Invoke();
            });
        }

        public bool Showing => gameObject.activeSelf;

        public void Begin()
        {
            tab.Begin(UITab.TabType.Battle);
        }
    }
}