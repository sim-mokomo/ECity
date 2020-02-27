using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MokomoGames.Protobuf;
using MokomoGames.UI;
using UnityEngine;
using Zenject;

namespace MokomoGames
{
    public class HomeSequencer : MonoBehaviour, ISequencer
    {
        public MasterSequencer.SequencerType Type => MasterSequencer.SequencerType.Home;
        
        [SerializeField] private UIHeader headerUi;
        [SerializeField] private UIRankConfirm rankConfirm;
        [Inject] private IPlayerSaveDataRepository _playerSaveDataRepository;
        [Inject] private IMasterDataRepository _masterDataRepository;
        private StaminaRecoveryTimeController staminaRecoveryTimeController;
        private PlayerSaveData saveData;
        public event Action<MasterSequencer.SequencerType, bool, Func<bool>> OnLeave;
        
        public void Begin()
        {
            Display(true);

            staminaRecoveryTimeController = new StaminaRecoveryTimeController(_playerSaveDataRepository);
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
                rankConfirm.SetStaminaGauge(
                    staminaRecoveryTimeController.Minutes,
                    staminaRecoveryTimeController.Seconds,
                    staminaRecoveryTimeController.RecoverySeconds);
            };
            staminaRecoveryTimeController.Begin();
            
            _playerSaveDataRepository.GetPlayerSaveData(responseSaveData =>
            {
                saveData = responseSaveData;
                Refresh(saveData);
            });

            headerUi.OnTap += () =>
            {
                var rankRecord = _masterDataRepository.RankTable.Records.FirstOrDefault(x => x.Rank == saveData.Rank);
                rankConfirm.gameObject.SetActive(true);
                rankConfirm.SetCurrentRank(rankRecord.Rank);
                rankConfirm.SetExpGauge(rankRecord.NeedNextRankExp - saveData.Exp ,rankRecord.NeedNextRankExp);
                rankConfirm.SetStaminaGauge(
                    staminaRecoveryTimeController.Minutes,
                    staminaRecoveryTimeController.Seconds,
                    staminaRecoveryTimeController.RecoverySeconds);
            };

            headerUi.OnRelease += () => { rankConfirm.gameObject.SetActive(false); };
        }

        public void Tick()
        {
            headerUi.Tick();
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
            var rankRecord = _masterDataRepository.RankTable.Records.FirstOrDefault(x => x.Rank == saveData.Rank);
            headerUi.SetStamina(save.Stamina,rankRecord.MaxFuel);
            headerUi.SetCoinNum(save.Coin);
            headerUi.SetMizuNum(save.Mizu);
            headerUi.SetYukichiNum(save.Yukichi);
            headerUi.SetRank(save.Rank,save.Exp,rankRecord.NeedNextRankExp);
        }
    }
}