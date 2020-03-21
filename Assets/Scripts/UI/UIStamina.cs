using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MokomoGames
{
    public class UIStamina : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI currentValueText;
        [SerializeField] private TextMeshProUGUI maxValueText;
        [SerializeField] private Button recoveryButton;
        [SerializeField] private TextMeshProUGUI toRemainingTimeText;
        [SerializeField] private Slider valueSlider;

        public event Action OnTapedRecoveryButton;

        private void Awake()
        {
            valueSlider.interactable = false;
            recoveryButton.onClick.AddListener(() => OnTapedRecoveryButton?.Invoke());
        }

        public void SetCurrentValue(uint stamina, uint maxStamina)
        {
            currentValueText.text = $"{stamina}";
            currentValueText.color = stamina > maxStamina ? Color.cyan : Color.white;
            maxValueText.text = $"/{maxStamina}";
            valueSlider.maxValue = maxStamina;
            valueSlider.value = stamina;
        }

        public void SetRecoveryTime(uint minutes, uint seconds)
        {
            toRemainingTimeText.text = $"あと{minutes:00}:{seconds:00}";
        }
    }
}