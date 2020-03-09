using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MokomoGames.Protobuf;
using TMPro;
using UniRx.Async;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MokomoGames.UI
{
    public class UISoulListPage : MonoBehaviour,IPage
    {
        [SerializeField] private Button backButton;
        [SerializeField] private Button homeButton;
        [SerializeField] private ToggleGroup toggleGroup;
        [SerializeField] private Toggle soulToggle;
        [SerializeField] private Toggle materialToggle;
        [SerializeField] private GameObject cellRow;
        [SerializeField] private RectTransform contentRoot;
        [SerializeField] private VerticalLayoutGroup verticalRoot;
        [SerializeField] private UISoulCell soulCellPrefab;
        [SerializeField] private TextMeshProUGUI hasSoulNum;
        private List<UISoulCell> _soulCells = new List<UISoulCell>();
        private Tab CurrentTab => soulToggle.isOn == true ? Tab.Soul : Tab.Material;
        private ColorBlock selectingColorBlock;
        private ColorBlock unSelectingColorBlock;
        private PlayerSaveDataContainer _playerSaveDataContainer;
        [Inject] private IPlayerSaveDataRepository _playerSaveDataRepository;
        [Inject] private IMasterDataRepository _masterDataRepository;
        public event Action OnTappedHomeButton;
        
        public enum Tab
        {
            Soul,
            Material,
        }
        
        private void Awake()
        {
            foreach (var toggle in toggleGroup.GetComponentsInChildren<Toggle>())
            {
                toggle.onValueChanged.RemoveListener(OnChangedTab);
                toggle.onValueChanged.AddListener(OnChangedTab);
            }

            backButton.onClick.AddListener( () => gameObject.SetActive(false));
            homeButton.onClick.AddListener( () =>
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
        }

        public void Begin()
        {
            soulToggle.isOn = true;
        }

        public void Prepare(PlayerSaveDataContainer _playerSaveDataContainer)
        {
            this._playerSaveDataContainer = _playerSaveDataContainer;
        }

        private void UpdateHasSoulNum(int currentCount)
        {
            var hasSoulCapacity = 999;
            hasSoulNum.text = $"{currentCount}/{hasSoulCapacity}";
        }

        private List<UISoulCell> MakeCells(List<UserSoulDataContainer> records)
        {
            const int cellNumPerRow = 6;
            var rowNum = Mathf.CeilToInt((float)records.Count / cellNumPerRow);
            var soulCells = new List<UISoulCell>();
            for (int i = 0; i < rowNum; i++)
            {
                var row = Instantiate(cellRow);
                row.transform.SetParent(verticalRoot.transform);
                row.transform.localScale = Vector3.one;
                for (int j = 0; j < row.transform.childCount; j++)
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
                }
            }

            var height = rowNum * soulCells[0]?.Height ?? 0f;
            height += verticalRoot.spacing;
            contentRoot.sizeDelta = new Vector2(contentRoot.sizeDelta.x,height);
            return soulCells;
        }

        private void DestroyCells()
        {
            for (int i = 0; i < verticalRoot.transform.childCount; i++)
            {
                var obj = verticalRoot.transform.GetChild(i).gameObject;
                Destroy(obj);
            }
        }

        private void OnChangedTab(bool isOn)
        {
            soulToggle.colors = soulToggle.isOn == isOn ? selectingColorBlock : unSelectingColorBlock;
            materialToggle.colors = materialToggle.isOn == isOn ? selectingColorBlock : unSelectingColorBlock;

            if (CurrentTab == Tab.Material)
            {
                DestroyCells();
                var materials = _playerSaveDataContainer.GetMaterialSoul();
                UpdateHasSoulNum(materials.Count());
                MakeCells(materials.ToList());
            }
            else if(CurrentTab == Tab.Soul)
            {
                DestroyCells();
                var souls = _playerSaveDataContainer.GetBattleSoul();
                UpdateHasSoulNum(souls.Count());
                MakeCells(souls.ToList());
            }
        }
    }
}
