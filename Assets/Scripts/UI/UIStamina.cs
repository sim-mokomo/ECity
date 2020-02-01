using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MokomoGames
{
    public class UIStamina : MonoBehaviour
    {
        [SerializeField] private Slider valueSlider;
        [SerializeField] private Button recoveryButton;
        [SerializeField] private TextMeshProUGUI toRemainingTimeText;
        [SerializeField] private TextMeshProUGUI currentValueText;

        public event Action OnTapedRecoveryButton;
        
        private void Awake()
        {
            recoveryButton.onClick.AddListener( () => OnTapedRecoveryButton?.Invoke() );
        }

        public void SetCurrentValue(uint stamina,uint maxStamina)
        {
            currentValueText.text = $"{stamina}/{maxStamina}";
            valueSlider.maxValue = maxStamina;
            valueSlider.value = stamina;
        }

        public void SetRecoveryTime(uint hours,uint minutes)
        {
            toRemainingTimeText.text = $"あと{hours:00}:{minutes:00}";
        }
    }
}
