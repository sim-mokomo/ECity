﻿using System;
using System.Linq;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MokomoGames.UI
{
    public class UISoulListPage : MonoBehaviour, IPage
    {
        [SerializeField] private Button backButton;
        [SerializeField] private TextMeshProUGUI hasSoulNum;
        [SerializeField] private Button homeButton;
        [SerializeField] private UISoulDetailPage soulDetailPage;
        [SerializeField] private UICellScroll soulCellScroll;
        [SerializeField] private UITab tab;
        private UserSoulList _userSoulList;
        public event Action OnTappedHomeButton;

        private void Awake()
        {
            tab.OnChangedTab += tabElement =>
            {
                soulCellScroll.DestroyCells();
                var showSouls = tabElement.TabType == UITab.TabType.Battle
                    ? _userSoulList.GetBattleSouls()
                    : _userSoulList.GetMaterialSouls();
                
                UpdateHasSoulNum(showSouls.Count());
                soulCellScroll.MakeCells(showSouls.ToList(), soul =>
                {
                    soulDetailPage.Show(true);
                    soulDetailPage.Begin(soul);
                });
            };
            tab.Begin(firstFocusTab: UITab.TabType.Battle);

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

        public void Begin()
        {
            
        }

        public void SetData(UserSoulList userSoulList)
        {
            this._userSoulList = userSoulList;
        }

        private void UpdateHasSoulNum(int currentCount)
        {
            var hasSoulCapacity = 999;
            hasSoulNum.text = $"{currentCount}/{hasSoulCapacity}";
        }
    }
}