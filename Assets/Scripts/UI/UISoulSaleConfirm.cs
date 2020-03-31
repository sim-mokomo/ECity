using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MokomoGames;
using MokomoGames.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISoulSaleConfirm : MonoBehaviour
{
    private List<UISoulCell> soulCells;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button rejectButton;
    [SerializeField] private Button submitButton;
    [SerializeField] private UIHasYukichi acquisionShizuku;
    [SerializeField] private UIHasYukichi acquisionKaruma;
    [SerializeField] private GridLayoutGroup gridLayoutGroup;

    public event Action OnTappedCloseButton;
    public event Action OnTappedRejectButton;
    public event Action OnSubmitButton;

    private void Awake()
    {
        soulCells = gridLayoutGroup.GetComponentsInChildren<UISoulCell>().ToList();
        closeButton.onClick.AddListener( () => OnTappedCloseButton?.Invoke());
        rejectButton.onClick.AddListener( () => OnTappedRejectButton?.Invoke());
        submitButton.onClick.AddListener(() => OnSubmitButton?.Invoke());
    }

    public void Begin(List<Soul> saleSouls)
    {
        for (int i = 0; i < soulCells.Count; i++)
        {
            var cell = soulCells[i];
            
            var inRange = i < saleSouls.Count;
            cell.Show(inRange);
            if(!inRange)
                continue;

            var soul = saleSouls[i];
            cell.Begin(soul);
        }
        
        acquisionShizuku.SetYukichiNum((uint) saleSouls.Sum(x => x.Config.SaleShizukuNum));
        acquisionKaruma.SetYukichiNum((uint) saleSouls.Sum(x => x.Config.SaleKarumaNum));
    }

    public void Show(bool show)
    {
        gameObject.SetActive(show);
    }
}
