using System;
using System.Linq;
using MokomoGames.UI;
using MokomoGames.Users;
using UnityEngine;
using Zenject;

namespace MokomoGames
{
    public class HomeSequencer : MonoBehaviour, ISequencer
    {
        [Inject] private IMasterDataRepository _masterDataRepository;
        private PageRepository _pageRepository;
        [Inject] private IPlayerSaveDataRepository _playerSaveDataRepository;
        private UserSoulList _userSoulList;
        [SerializeField] private UIFillWarningStaminaDialog fillWarningStaminaDialog;
        [SerializeField] private UIHeader headerUi;
        [SerializeField] private NestedMenuController nestedMenuController;
        [SerializeField] private UIRankConfirm rankConfirm;
        [SerializeField] private UIRecoveryStaminaDialog recoveryStaminaDialog;
        [SerializeField] private UISoulSaleConfirm _soulSaleConfirm;
        private SoulSaleApplicationService _soulSaleApplicationService;
        private StaminaRecoveryTimeController staminaRecoveryTimeController;
        private User user;
        public MasterSequencer.SequencerType Type => MasterSequencer.SequencerType.Home;
        public event Action<MasterSequencer.SequencerType, bool, Func<bool>> OnLeave;

        public async void Begin()
        {
            Display(true);

            user = await _playerSaveDataRepository.GetPlayerSaveData();
            var soulDataList = await _playerSaveDataRepository.GetUserSoulDataList();
            _userSoulList = new UserSoulList(soulDataList.Souls, _masterDataRepository);

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

            nestedMenuController.Entry();

            _pageRepository = FindObjectOfType<PageRepository>();
            foreach (var soulPage in _pageRepository.SoulPages) soulPage.SetData(_userSoulList);

            foreach (var page in _pageRepository.Pages)
            {
                page.OnTappedHomeButton -= nestedMenuController.Release;
                page.OnTappedHomeButton += nestedMenuController.Release;
                page.Show(false);
            }

            foreach (var menu in nestedMenuController.NestedMenuConfigrations.Select(x => x.MenuList))
            {
                menu.OnRequest += pageType =>
                {
                    var page = _pageRepository.GetPage(pageType);
                    if (page == null)
                        return;
                    page.Show(true);
                    page.Begin();
                };
                menu.OnRequestedClose += () => menu.Close();
                menu.Close();
            }

            var soulSalePage = _pageRepository.GetPage(PageRepository.PageType.SoulSale) as UISoulSalePage;
            _soulSaleApplicationService = new SoulSaleApplicationService(
                _soulSaleConfirm,
                _userSoulList,
                soulSalePage,
                _playerSaveDataRepository,
                _masterDataRepository,
                user);

            recoveryStaminaDialog.gameObject.SetActive(false);
            fillWarningStaminaDialog.gameObject.SetActive(false);
        }

        public void Tick()
        {
            headerUi.Tick();
            _soulSaleApplicationService.Tick();
            if (_pageRepository != null && !_pageRepository.SoulPages.Any(x => x.Showing)) nestedMenuController.Tick();
        }

        public void End()
        {
            Display(false);
        }

        public void Display(bool show)
        {
            gameObject.SetActive(show);
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