using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MokomoGames.UI
{
    public class UICellScroll : MonoBehaviour
    {
        [SerializeField] private UISoulCell cellPrefab;
        [SerializeField] private RectTransform contentRoot;
        [SerializeField] private GridLayoutGroup gridLayoutGroup;
        [SerializeField] private int cellNumPerRow;

        public List<UISoulCell> MakeCells(List<Soul> souls, Action<Soul> OnTappedSoulCellIcon)
        {
            var cells = new List<UISoulCell>();
            
            foreach (var soul in souls)
            {
                var cell = Instantiate(cellPrefab,gridLayoutGroup.transform);
                cell.Show(true);
                cell.Begin(soul);
                cell.OnTappedIcon += OnTappedSoulCellIcon;
                cells.Add(cell);
            }

            gridLayoutGroup.constraintCount = Mathf.CeilToInt((float) souls.Count / cellNumPerRow);
            gridLayoutGroup.cellSize = cells[0].Size;
            var height = 0f;
            height += (cellNumPerRow - 1) * (gridLayoutGroup.spacing.y / 2);
            height += gridLayoutGroup.constraintCount * cells[0]?.Height ?? 0f;
            height += gridLayoutGroup.padding.top;
            contentRoot.sizeDelta = new Vector2(contentRoot.sizeDelta.x, height);

            return cells;
        }

        public void DestroyCells()
        {
            foreach (var child in gridLayoutGroup.transform.Childs()) Destroy(child.gameObject);
        }
    }
}