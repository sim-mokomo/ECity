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

        public List<UISoulCell> MakeCells(List<Soul> souls)
        {
            var cells = new List<UISoulCell>();
            
            foreach (var soul in souls)
            {
                var cell = Instantiate(cellPrefab,gridLayoutGroup.transform);
                cell.Show(true);
                cell.Begin(soul);
                cells.Add(cell);
            }

            gridLayoutGroup.constraintCount = Mathf.CeilToInt(cellNumPerRow);
            gridLayoutGroup.cellSize = cells[0].Size;
            var height = 0f;
            height += (cellNumPerRow - 1) * (gridLayoutGroup.spacing.y / 2);
            height += (cells.Count / cellNumPerRow) * cells[0]?.Height ?? 0f;
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