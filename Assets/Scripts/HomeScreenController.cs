﻿using System.Collections;
using System.Collections.Generic;
using MokomoGames;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class HomeScreenController : MonoBehaviour
{
    [SerializeField] private UIHeader headerUi;
    private StaminaRecoveryTimeController staminaRecoveryTimeController;

    public void Begin()
    {
        staminaRecoveryTimeController = new StaminaRecoveryTimeController();
        staminaRecoveryTimeController.OnRecoveriedStamina += RefreshStamina;
        staminaRecoveryTimeController.OnClock += () =>
        {
            headerUi.SetStaminaTime(
                staminaRecoveryTimeController.Minutes,
                staminaRecoveryTimeController.Seconds);
        };
        staminaRecoveryTimeController.Begin();
        
        RefreshStamina();
    }

    public void Tick()
    {
        
    }

    public void End()
    {
        
    }

    private void RefreshStamina()
    {
        PlayerSaveDataRepository.GetPlayerSaveData(playerSaveData =>
        {
            headerUi.SetStamina(
                stamina:(uint)playerSaveData.Stamina, 
                maxStamina: 999
                );
        });
    }
}
