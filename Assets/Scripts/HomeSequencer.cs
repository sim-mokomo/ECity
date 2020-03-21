using System;
using System.Linq;
using MokomoGames.UI;
using MokomoGames.Users;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MokomoGames
{
    public class HomeSequencer : MonoBehaviour, ISequencer
    {
        [Inject] private IMasterDataRepository _masterDataRepository;
        private readonly UIMenuListContainer _menuListContainer = new UIMenuListContainer();
        [Inject] private IPlayerSaveDataRepository _playerSaveDataRepository;
        private UserSoulDataContainerList _userSoulDataContainerList;
        [SerializeField] private UIFillWarningStaminaDialog fillWarningStaminaDialog;

        [SerializeField] private UIHeader headerUi;
        [SerializeField] private UIRankConfirm rankConfirm;
        [SerializeField] private UIRecoveryStaminaDialog recoveryStaminaDialog;
        [SerializeField] private UISoulLaboMenu soulLaboMenu;
        [SerializeField] private Button soulLaboToggle;
        [SerializeField] private UISoulListMenu soulListMenu;
        [SerializeField] private UISoulListPage soulListPage;
        private StaminaRecoveryTimeController staminaRecoveryTimeController;
        private User user;
        public MasterSequencer.SequencerType Type => MasterSequencer.SequencerType.Home;
        public event Action<MasterSequencer.SequencerType, bool, Func<bool>> OnLeave;

        public async void Begin()
        {
            Display(true);

            user = await _playerSaveDataRepository.GetPlayerSaveData();
            var soulDataList = await _playerSaveDataRepository.GetUserSoulDataList();
            _userSoulDataContainerList = new UserSoulDataContainerList(soulDataList.Souls, _masterDataRepository);
            soulListPage.SetData(_userSoulDataContainerList);
            Refresh(user);

            staminaRecoveryTimeController = new StaminaRecoveryTimeController(_playerSaveDataRepository);
            staminaRecoveryTimeController.OnRecoveriedStamina += recoveriedDiff =>
            {
                user = UserService.CreateRecoveriedStaminaUserByTime(user, recoveriedDiff);
                Refresh(user);
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

            headerUi.OnTap += () =>
            {
                rankConfirm.gameObject.SetActive(true);
                rankConfirm.SetCurrentRank(user.Rank);
                rankConfirm.SetExpGauge(user.NeedNextRankExp - user.RankExp, user.NeedNextRankExp);
                rankConfirm.SetStaminaGauge(
                    staminaRecoveryTimeController.Minutes,
                    staminaRecoveryTimeController.Seconds,
                    staminaRecoveryTimeController.RecoverySeconds);
            };
            headerUi.StaminaUi.OnTapedRecoveryButton += () =>
            {
                recoveryStaminaDialog.Initialize(user.Stamina, user.MaxFuel, user.Yukichi);
                recoveryStaminaDialog.Open();
            };
            headerUi.OnRelease += () => { rankConfirm.gameObject.SetActive(false); };

            recoveryStaminaDialog.OnTappedCloseButton += recoveryStaminaDialog.Close;
            recoveryStaminaDialog.OnTappedNoButton += recoveryStaminaDialog.Close;
            recoveryStaminaDialog.OnTappedYesButton += () =>
            {
                fillWarningStaminaDialog.Open();
                fillWarningStaminaDialog.ShowMaxFuelMessage(user.IsMaxFuel);
                if (!user.IsMaxFuel)
                {
                    _playerSaveDataRepository.RecoveryFuelByYukichi();
                    user = UserService.CreateRecoveriedStaminaUserByYukichi(user);
                    Refresh(user);
                }

                fillWarningStaminaDialog.SetStamina(user.Stamina, user.MaxFuel);
                fillWarningStaminaDialog.SetYukichiNum(user.Yukichi);
                recoveryStaminaDialog.Close();
            };
            fillWarningStaminaDialog.OnTappedClose += fillWarningStaminaDialog.Close;
            fillWarningStaminaDialog.OnTappedConfirm += fillWarningStaminaDialog.Close;

            soulLaboToggle.onClick.AddListener(() => { _menuListContainer.Add(soulLaboMenu); });
            soulLaboMenu.ListButton.onClick.AddListener(() => { _menuListContainer.Add(soulListMenu); });

            foreach (var page in GetComponentsInChildren<IPage>())
            {
                page.OnTappedHomeButton -= ReleaseAllMenuList;
                page.OnTappedHomeButton += ReleaseAllMenuList;
            }

            soulLaboMenu.Close();
            soulListMenu.Close();
            recoveryStaminaDialog.gameObject.SetActive(false);
            fillWarningStaminaDialog.gameObject.SetActive(false);
            soulListPage.gameObject.SetActive(false);
        }

        public void Tick()
        {
            headerUi.Tick();
            _menuListContainer.Tick();
        }

        public void End()
        {
            Display(false);
        }

        public void Display(bool show)
        {
            gameObject.SetActive(show);
        }

        public void ReleaseAllMenuList()
        {
            _menuListContainer.RemoveAll();
        }

        private void Refresh(User user)
        {
            headerUi.SetStamina(user.Stamina, user.MaxFuel);
            headerUi.SetCoinNum(user.Coin);
            headerUi.SetMizuNum(user.Mizu);
            headerUi.SetYukichiNum(user.Yukichi);
            headerUi.SetRank(user.Rank, user.RankExp, user.NeedNextRankExp);
        }
    }
}