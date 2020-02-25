using System;
using System.Collections;
using System.Collections.Generic;
using MokomoGames.Protobuf;
using UnityEngine;
using Zenject;

namespace MokomoGames
{
    public class HomeSequencer : MonoBehaviour, ISequencer
    {
        public MasterSequencer.SequencerType Type => MasterSequencer.SequencerType.Home;
        
        [SerializeField] private UIHeader headerUi;
        [Inject] private IPlayerSaveDataRepository _playerSaveDataRepository;
        private StaminaRecoveryTimeController staminaRecoveryTimeController;
        private PlayerSaveData saveData;
        public event Action<MasterSequencer.SequencerType, bool, Func<bool>> OnLeave;
        
        public void Begin()
        {
            Display(true);

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
            Display(false);
        }

        public void Display(bool show)
        {
            gameObject.SetActive(show);
        }
        
        private void Refresh(PlayerSaveData save)
        {
            headerUi.SetStamina(save.Stamina,999);
            headerUi.SetCoinNum(save.Coin);
            headerUi.SetMizuNum(save.Mizu);
            headerUi.SetYukichiNum(save.Yukichi);
        }
    }
}