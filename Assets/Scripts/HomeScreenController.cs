using System.Collections;
using System.Collections.Generic;
using MokomoGames;
using MokomoGames.Protobuf;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using Zenject;

public class HomeScreenController : MonoBehaviour
{
    [SerializeField] private UIHeader headerUi;
    private StaminaRecoveryTimeController staminaRecoveryTimeController;
    private PlayerSaveData saveData;
    [Inject] private IPlayerSaveDataRepository _playerSaveDataRepository;

    public void Begin()
    {
        staminaRecoveryTimeController = new StaminaRecoveryTimeController(10,_playerSaveDataRepository);
        staminaRecoveryTimeController.OnRecoveriedStamina += () =>
        {
            saveData.Stamina += 1;
            Refresh(saveData);
        };
        staminaRecoveryTimeController.OnClock += () =>
        {
            headerUi.SetStaminaTime(
                staminaRecoveryTimeController.Minutes,
                staminaRecoveryTimeController.Seconds);
        };
        staminaRecoveryTimeController.Begin();
        
        _playerSaveDataRepository.GetPlayerSaveData(responseSaveData =>
        {
            saveData = responseSaveData;
            Refresh(saveData);
        });
    }

    public void Tick()
    {
        
    }

    public void End()
    {
        
    }

    private void Refresh(PlayerSaveData save)
    {
        headerUi.SetStamina(save.Stamina,999);
        headerUi.SetCoinNum(save.Coin);
        headerUi.SetMizuNum(save.Mizu);
        headerUi.SetYukichiNum(save.Yukichi);
    }
}
