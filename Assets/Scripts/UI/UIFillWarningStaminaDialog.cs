using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MokomoGames.UI
{
    public class UIFillWarningStaminaDialog : MonoBehaviour,IOpenable
    {
        [SerializeField] private UIStamina uiStamina;
        [SerializeField] private UIHasYukichi hasYukichi;
        [SerializeField] private Button ConfirmButton;
        [SerializeField] private Button CloseButton;
        [SerializeField] private TextMeshProUGUI contentText;
        private const string fillMessage = "燃料はすでに満タンです!\n使用をキャンセルしました。";
        private const string recoveryMessage = "燃料が満タンになりました!";
        
        public event Action OnTappedConfirm;
        public event Action OnTappedClose;

        private void Awake()
        {
            ConfirmButton.onClick.AddListener( () => OnTappedConfirm?.Invoke());
            CloseButton.onClick.AddListener( () => OnTappedClose?.Invoke());
        }

        public void ShowMaxFuelMessage(bool isMaxFuel)
        {
            contentText.text = isMaxFuel ? fillMessage : recoveryMessage;
        }

        public void SetStamina(uint currentFuel, uint maxFuel)
        {
            uiStamina.SetCurrentValue(currentFuel,maxFuel);
        }

        public void SetYukichiNum(uint yukichiNum)
        {
            hasYukichi.SetYukichiNum(yukichiNum);
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}
