using System;
using UnityEngine;
using UnityEngine.UI;

namespace MokomoGames.UI
{
    [Serializable]
    public class UITabElement
    {
        [SerializeField] private UITab.TabType _tabType;
        [SerializeField] private Toggle _toggle;

        public Toggle Toggle => _toggle;
        public UITab.TabType TabType => _tabType;
    }
}