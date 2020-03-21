using System;
using Zenject;

namespace MokomoGames
{
    public class StaminaRecoveryTimeController
    {
        public readonly uint RecoverySeconds = 180;
        [Inject] private IPlayerSaveDataRepository _playerSaveDataRepository;
        private Timer recoveryTimer;

        public StaminaRecoveryTimeController(IPlayerSaveDataRepository playerSaveDataRepository)
        {
            _playerSaveDataRepository = playerSaveDataRepository;
        }

        public uint Minutes => recoveryTimer.CurrentSecond / 60;
        public uint Seconds => recoveryTimer.CurrentSecond % 60;

        public event Action OnRecoveriedStamina;
        public event Action OnClock;

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
            timer.OnClocked += _ => OnClock?.Invoke();
            return timer;
        }
    }
}