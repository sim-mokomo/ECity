using System;
using Zenject;

namespace MokomoGames
{
    public class StaminaRecoveryTimeController
    {
        private readonly uint recoveriedDiff = 1;
        public readonly uint RecoverySeconds = 180;
        [Inject] private IPlayerSaveDataRepository _playerSaveDataRepository;
        private Timer recoveryTimer;

        public StaminaRecoveryTimeController(IPlayerSaveDataRepository playerSaveDataRepository)
        {
            _playerSaveDataRepository = playerSaveDataRepository;
        }

        public uint Minutes => recoveryTimer.CurrentSecond / 60;
        public uint Seconds => recoveryTimer.CurrentSecond % 60;

        public event Action<uint> OnRecoveriedStamina;
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
                OnRecoveriedStamina?.Invoke(recoveriedDiff);
            };
            timer.OnClocked += _ => OnClock?.Invoke();
            return timer;
        }
    }
}