﻿using System;
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
        public readonly uint RecoverySeconds = 180;
        public uint Minutes => recoveryTimer.CurrentSecond / 60;
        public uint Seconds => recoveryTimer.CurrentSecond % 60;
        [Inject] private IPlayerSaveDataRepository _playerSaveDataRepository;

        public event Action OnRecoveriedStamina;
        public event Action OnClock;

        public StaminaRecoveryTimeController(IPlayerSaveDataRepository playerSaveDataRepository)
        {
            _playerSaveDataRepository = playerSaveDataRepository;
        }
        
        public void Begin()
        {
            recoveryTimer = CreateRecoveryTimer();
            recoveryTimer.Play();
        }
        
        private Timer CreateRecoveryTimer()
        {
            var timer = new Timer(RecoverySeconds);
            timer.OnEnded += () =>
            {
                recoveryTimer = CreateRecoveryTimer();
                recoveryTimer.Play();
                _playerSaveDataRepository.RecoveryStaminaByWaitTime();
                OnRecoveriedStamina?.Invoke();
            };
            timer.OnClocked += (_) => OnClock?.Invoke();
            return timer;
        }
    }
}
