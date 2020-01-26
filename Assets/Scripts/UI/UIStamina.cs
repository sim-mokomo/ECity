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
        [SerializeField] private Slider _valueSlider;
        [SerializeField] private Button _recoveryButton;
        [SerializeField] private TextMeshProUGUI _toRemainingTimeText;
        [SerializeField] private TextMeshProUGUI _currentValueText;

        public event Action OnTapedRecoveryButton;
        
        private void Awake()
        {
            _recoveryButton.onClick.AddListener( () => OnTapedRecoveryButton?.Invoke() );
            SetCurrentValue(stamina: 60,maxStamina: 83);
            SetRecoveryTime(1,3);
        }

        public void SetCurrentValue(int stamina,int maxStamina)
        {
            _currentValueText.text = $"{stamina}/{maxStamina}";
            _valueSlider.maxValue = maxStamina;
            _valueSlider.value = stamina;
        }

        public void SetRecoveryTime(int hours,int minutes)
        {
            _toRemainingTimeText.text = $"あと{hours:00}:{minutes:00}";
        }
    }
}
