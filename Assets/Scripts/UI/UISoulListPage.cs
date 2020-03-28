using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MokomoGames.UI
{
    public class UISoulListPage : MonoBehaviour, IPage
    {
        public enum Tab
        {
            Soul,
            Material
        }

        [SerializeField] private Button backButton;
        [SerializeField] private TextMeshProUGUI hasSoulNum;
        [SerializeField] private Button homeButton;
        [SerializeField] private Toggle materialToggle;
        private ColorBlock selectingColorBlock;
        [SerializeField] private UISoulDetailPage soulDetailPage;
        [SerializeField] private Toggle soulToggle;
        [SerializeField] private ToggleGroup toggleGroup;
        private ColorBlock unSelectingColorBlock;
        private UserSoulList _userSoulList;
        [SerializeField] private UICellScroll soulCellScroll;
        private Tab CurrentTab => soulToggle.isOn ? Tab.Soul : Tab.Material;
        public event Action OnTappedHomeButton;

        private void Awake()
        {
            foreach (var toggle in toggleGroup.GetComponentsInChildren<Toggle>())
            {
                toggle.onValueChanged.RemoveListener(OnChangedTab);
                toggle.onValueChanged.AddListener(OnChangedTab);
            }

            backButton.onClick.AddListener(() => gameObject.SetActive(false));
            homeButton.onClick.AddListener(() =>
            {
                soulCellScroll.DestroyCells();
                gameObject.SetActive(false);
                OnTappedHomeButton?.Invoke();
            });

            selectingColorBlock = new ColorBlock();
            selectingColorBlock.colorMultiplier = 1f;
            selectingColorBlock.normalColor = Color.yellow;
            selectingColorBlock.highlightedColor = Color.yellow;
            selectingColorBlock.pressedColor = Color.yellow;
            selectingColorBlock.selectedColor = Color.yellow;

            unSelectingColorBlock = new ColorBlock();
            unSelectingColorBlock.colorMultiplier = 1f;
            unSelectingColorBlock.normalColor = Color.gray;
            unSelectingColorBlock.highlightedColor = Color.gray;
            unSelectingColorBlock.pressedColor = Color.gray;
            unSelectingColorBlock.selectedColor = Color.gray;

            soulDetailPage.OnTappedBackButton += () => soulDetailPage.Show(false);
            soulDetailPage.Show(false);
        }

        public void Begin()
        {
            soulToggle.isOn = true;
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


        private void OnChangedTab(bool isOn)
        {
            UpdateTabColor(CurrentTab);

            if (CurrentTab == Tab.Material)
            {
                soulCellScroll.DestroyCells();

                var materials = _userSoulList.ExistMaterialSouls
                    ? _userSoulList.GetMaterialSouls()
                    : UserSoulList.Empty;
                UpdateHasSoulNum(materials.Count());
                soulCellScroll.MakeCells(materials.ToList(), TappedSoulCellIcon);
            }
            else if (CurrentTab == Tab.Soul)
            {
                soulCellScroll.DestroyCells();
                var souls = _userSoulList.ExistBattleSouls
                    ? _userSoulList.GetBattleSouls()
                    : UserSoulList.Empty;
                UpdateHasSoulNum(souls.Count());
                soulCellScroll.MakeCells(souls.ToList(),TappedSoulCellIcon);
            }
        }

        private void UpdateTabColor(Tab focusTab)
        {
            soulToggle.colors = focusTab == Tab.Soul ? selectingColorBlock : unSelectingColorBlock;
            materialToggle.colors = focusTab == Tab.Material ? selectingColorBlock : unSelectingColorBlock;
        }
    }
}