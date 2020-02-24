using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace MokomoGames
{
    public class StaminaRecoveryTimeController
    {        
        private Timer recoveryTimer;
        private uint RecoverySeconds;
        public uint Minutes => recoveryTimer.CurrentSecond / 60;
        public uint Seconds => recoveryTimer.CurrentSecond % 60;
        [Inject] private IPlayerSaveDataRepository _playerSaveDataRepository;

        public event Action OnRecoveriedStamina;
        public event Action OnClock;

        public StaminaRecoveryTimeController(uint recoverySeconds,IPlayerSaveDataRepository playerSaveDataRepository)
        {
            RecoverySeconds = recoverySeconds;
            _playerSaveDataRepository = playerSaveDataRepository;
        }
        
        public void Begin()
        {
            recoveryTimer = CreateRecoveryTimer();
            recoveryTimer.Play();

            OnRecoveriedStamina += () =>
            {
                recoveryTimer = CreateRecoveryTimer();
                recoveryTimer.Play();
            };
        }
        
        private Timer CreateRecoveryTimer()
        {
            var timer = new Timer(RecoverySeconds);
            timer.OnEnded += () =>
            {
                _playerSaveDataRepository.RecoveryStaminaByWaitTime(null);
                OnRecoveriedStamina?.Invoke();
            };
            timer.OnClocked += (_) => OnClock?.Invoke();
            return timer;
        }
    }
}
