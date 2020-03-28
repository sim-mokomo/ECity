using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MokomoGames.UI
{
    public class UICellScroll : MonoBehaviour
    {
        [SerializeField] private GameObject cellRow;
        [SerializeField] private RectTransform contentRoot;
        [SerializeField] private VerticalLayoutGroup verticalRoot;

        public List<UISoulCell> MakeCells(List<Soul> records, Action<Soul> OnTappedSoulCellIcon)
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
            height += verticalRoot.padding.top;
            contentRoot.sizeDelta = new Vector2(contentRoot.sizeDelta.x, height);

            return soulCells;
        }

        public void DestroyCells()
        {
            foreach (var child in verticalRoot.transform.Childs()) Destroy(child.gameObject);
        }
    }
}