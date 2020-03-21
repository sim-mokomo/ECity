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

        [Inject] private IMasterDataRepository _masterDataRepository;
        [Inject] private IPlayerSaveDataRepository _playerSaveDataRepository;
        private List<UISoulCell> _soulCells = new List<UISoulCell>();
        [SerializeField] private Button backButton;
        [SerializeField] private GameObject cellRow;
        [SerializeField] private RectTransform contentRoot;
        [SerializeField] private TextMeshProUGUI hasSoulNum;
        [SerializeField] private Button homeButton;
        [SerializeField] private Toggle materialToggle;
        private ColorBlock selectingColorBlock;
        [SerializeField] private UISoulCell soulCellPrefab;
        [SerializeField] private UISoulDetailPage soulDetailPage;
        [SerializeField] private Toggle soulToggle;
        [SerializeField] private ToggleGroup toggleGroup;
        private ColorBlock unSelectingColorBlock;
        private UserSoulList _userSoulList;
        [SerializeField] private VerticalLayoutGroup verticalRoot;
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
                DestroyCells();
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

        private List<UISoulCell> MakeCells(List<Soul> records)
        {
            const int cellNumPerRow = 6;
            var rowNum = Mathf.CeilToInt((float) records.Count / cellNumPerRow);
            var soulCells = new List<UISoulCell>();
            for (var i = 0; i < rowNum; i++)
            {
                var row = Instantiate(cellRow);
                row.transform.SetParent(verticalRoot.transform);
                row.transform.localScale = Vector3.one;
                for (var j = 0; j < row.transform.childCount; j++)
                {
                    var index = i * cellNumPerRow + j;
                    var soulCell = row.transform.GetChild(j).gameObject.GetComponent<UISoulCell>();
                    soulCells.Add(soulCell);
                    var inRange = index < records.Count;
                    soulCell.Show(inRange);
                    if (!inRange)
                        continue;
                    var soulData = records[index];
                    soulCell.Begin(soulData);
                    soulCell.OnTappedIcon += OnTappedSoulCellIcon;
                }
            }

            var height = rowNum * soulCells[0]?.Height ?? 0f;
            height += verticalRoot.spacing;
            contentRoot.sizeDelta = new Vector2(contentRoot.sizeDelta.x, height);
            return soulCells;
        }

        private void OnTappedSoulCellIcon(Soul soul)
        {
            soulDetailPage.Show(true);
            soulDetailPage.Begin(soul);
        }

        private void DestroyCells()
        {
            for (var i = 0; i < verticalRoot.transform.childCount; i++)
            {
                var obj = verticalRoot.transform.GetChild(i).gameObject;
                Destroy(obj);
            }
        }

        private void OnChangedTab(bool isOn)
        {
            UpdateTabColor(CurrentTab);

            if (CurrentTab == Tab.Material)
            {
                DestroyCells();

                var materials = _userSoulList.ExistMaterialSouls
                    ? _userSoulList.GetMaterialSouls()
                    : UserSoulList.Empty;
                UpdateHasSoulNum(materials.Count());
                MakeCells(materials.ToList());
            }
            else if (CurrentTab == Tab.Soul)
            {
                DestroyCells();
                var souls = _userSoulList.ExistBattleSouls
                    ? _userSoulList.GetBattleSouls()
                    : UserSoulList.Empty;
                UpdateHasSoulNum(souls.Count());
                MakeCells(souls.ToList());
            }
        }

        private void UpdateTabColor(Tab focusTab)
        {
            soulToggle.colors = focusTab == Tab.Soul ? selectingColorBlock : unSelectingColorBlock;
            materialToggle.colors = focusTab == Tab.Material ? selectingColorBlock : unSelectingColorBlock;
        }
    }
}