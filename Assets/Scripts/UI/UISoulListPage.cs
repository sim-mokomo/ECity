using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MokomoGames.UI
{
    public class UISoulListPage : MonoBehaviour,IPage
    {
        [SerializeField] private Button backButton;
        [SerializeField] private Button homeButton;

        [SerializeField] private GameObject cellRow;
        [SerializeField] private GameObject contentRoot;
        [SerializeField] private UISoulCell soulCellPrefab;
        [Inject] private IMasterDataRepository _masterDataRepository;
        public event Action OnTappedHomeButton;

        private void Awake()
        {
            backButton.onClick.AddListener( () => gameObject.SetActive(false));
            homeButton.onClick.AddListener( () =>
            {
                gameObject.SetActive(false);
                OnTappedHomeButton?.Invoke();
            });
        public void Begin()
        {
            const int cellNumPerRow = 6;
            var records = _masterDataRepository.SoulTable.Records;
            var rowNum = Mathf.CeilToInt((float)records.Count / cellNumPerRow);
            for (int i = 0; i < rowNum; i++)
            {
                var row = Instantiate(cellRow);
                row.transform.SetParent(contentRoot.transform);
                row.transform.localScale = Vector3.one;
                for (int j = 0; j < row.transform.childCount; j++)
                {
                    var index = i * cellNumPerRow + j;
                    var soulCell = row.transform.GetChild(j).gameObject.GetComponent<UISoulCell>();
                    var inRange = index < records.Count;
                    soulCell.Show(inRange);
                    if (!inRange)
                        continue;
                    var soulData = records[index];
                    Debug.Log(soulCell.gameObject.name);
                }
            }
        }
        }
    }
}
