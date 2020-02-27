using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MokomoGames.UI
{
    public class UIRankConfirm : MonoBehaviour
    {
        [SerializeField] private UIGaugeWithUpperLabel expGauge;
        [SerializeField] private UIGaugeWithUpperLabel staminaGauge;
        [SerializeField] private TextMeshProUGUI currentRankText;
        
        public void SetCurrentRank(uint rank)
        {
            currentRankText.text = rank.ToString();
        }
        
        public void SetExpGauge(uint remainingExp,uint maxExp)
        {
            expGauge.SetRemainingValue($"あと{remainingExp}");
            expGauge.SetRemainingSliderValue(remainingExp,maxExp);
        }

        public void SetStaminaGauge(uint minutes,uint seconds,uint maxRecoverySeconds)
        {
            staminaGauge.SetRemainingValue($"あと{minutes:00}:{seconds:00}");
            staminaGauge.SetRemainingSliderValue(minutes * 60 + seconds,maxRecoverySeconds);
        }
    }
}
