using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MokomoGames
{
    public class StaminaRecoveryTimeController
    {        
        private Timer recoveryTimer;
        private const uint RecoverySeconds = 10;
        public uint Minutes => recoveryTimer.CurrentSecond / 60;
        public uint Seconds => recoveryTimer.CurrentSecond % 60;

        public event Action OnRecoveriedStamina;
        public event Action OnClock;
        
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
                PlayerSaveDataRepository.UpdateStamina(diff: 1, () =>
                {
                    OnRecoveriedStamina?.Invoke();
                });
            };
            timer.OnClocked += (_) => OnClock?.Invoke();
            return timer;
        }
    }
}
