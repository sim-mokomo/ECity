using System;
using System.Collections;
using System.Collections.Generic;
using MokomoGames;
using MokomoGames.UI;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

namespace MokomoGames
{
    public class UIRecoveryStaminaDialog : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI hasYukichiNumText;
        [SerializeField] private UIStamina stamina;
        [SerializeField] private TextMeshProUGUI consumeYukichi;
        [SerializeField] private Button lawButton;
        [SerializeField] private Button yesButton;
        [SerializeField] private Button noButton;
        [SerializeField] private Button closeButton;

        public event Action OnTappedLawButton;
        public event Action OnTappedNoButton;
        public event Action OnTappedYesButton;
        public event Action OnTappedCloseButton;

        private void Awake()
        {
            lawButton.onClick.AddListener( () => OnTappedLawButton?.Invoke());
            noButton.onClick.AddListener( () => OnTappedNoButton?.Invoke());
            yesButton.onClick.AddListener( () => OnTappedYesButton?.Invoke());
            closeButton.onClick.AddListener( () => OnTappedCloseButton?.Invoke());
        }
        

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

        public void Initialize(uint currentStamina,uint maxStamina,uint yukichiNum,uint consumeYukichiNum=1)
        {
            stamina.SetCurrentValue(currentStamina,maxStamina);
            hasYukichiNumText.text = $"{yukichiNum}";
            consumeYukichi.text = $"{consumeYukichiNum}枚";
        }
    }
}
