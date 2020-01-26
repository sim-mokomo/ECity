using System;
using System.Collections;
using System.Collections.Generic;
using MokomoGames;
using UnityEngine;

public class UIStaminaController : MonoBehaviour
{
    [SerializeField] private UIRecoveryStaminaDialog recoveryStaminaDialog;
    [SerializeField] private UIStamina uiStamina;

    private void Awake()
    {
        uiStamina.OnTapedRecoveryButton += () => { recoveryStaminaDialog.Open(); };
        recoveryStaminaDialog.OnTappedCloseButton += () => { recoveryStaminaDialog.Close(); };
    }
}
