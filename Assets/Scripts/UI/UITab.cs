using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class UITab : MonoBehaviour
    {
        public enum TabType
        {
            Battle,
            Material
        }

        [SerializeField] private List<UITabElement> _tabElements;
        private ColorBlock selectingColorBlock;
        private ColorBlock unSelectingColorBlock;
        public event Action<UITabElement> OnChangedTab;
        private UITabElement GetTab(TabType tabType) => _tabElements.FirstOrDefault(x => x.TabType == tabType);

        [Serializable]
        public class UITabElement
        {
            [SerializeField] private TabType _tabType;
            [SerializeField] private Toggle _toggle;

            public Toggle Toggle => _toggle;
            public TabType TabType => _tabType;
        }

        private void Awake()
        {
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

            foreach (var tabElement in _tabElements)
            {
                tabElement.Toggle.onValueChanged.AddListener((isOn) =>
                {
                    if (tabElement.Toggle.isOn == isOn)
                    {
                        UpdateFocusTabColor(tabElement.TabType);
                        OnChangedTab?.Invoke(tabElement);
                    }
                });
            }
        }

        public void Begin(TabType firstFocusTab)
        {
            var focusTab = GetTab(firstFocusTab);
            focusTab.Toggle.isOn = true;
        }

        public void UpdateFocusTabColor(TabType tabType)
        {
            var focusTab = GetTab(tabType);
            focusTab.Toggle.colors = selectingColorBlock;

            var unFocusTabs = _tabElements.Where(x => x != focusTab);
            unFocusTabs.ToList().ForEach( x => x.Toggle.colors = unSelectingColorBlock);
        }
    }
}