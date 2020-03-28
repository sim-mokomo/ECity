﻿using System;
using System.Collections.Generic;
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
        [Inject] private IPlayerSaveDataRepository _playerSaveDataRepository;
        [SerializeField] private UIFillWarningStaminaDialog fillWarningStaminaDialog;
        [SerializeField] private UIHeader headerUi;
        [SerializeField] private UIRankConfirm rankConfirm;
        [SerializeField] private UIRecoveryStaminaDialog recoveryStaminaDialog;
        [SerializeField] private UISoulListPage soulListPage;
        [SerializeField] private UISoulSalePage soulSalePage;
        [SerializeField] private NestedMenuController nestedMenuController;
        private UserSoulList _userSoulList;
        private User user;
        private StaminaRecoveryTimeController staminaRecoveryTimeController;
        public MasterSequencer.SequencerType Type => MasterSequencer.SequencerType.Home;
        public event Action<MasterSequencer.SequencerType, bool, Func<bool>> OnLeave;

        public async void Begin()
        {
            Display(true);

            user = await _playerSaveDataRepository.GetPlayerSaveData();
            var soulDataList = await _playerSaveDataRepository.GetUserSoulDataList();
            _userSoulList = new UserSoulList(soulDataList.Souls, _masterDataRepository);
            soulListPage.SetData(_userSoulList);
            soulSalePage.SetData(_userSoulList);            
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

            foreach (var page in GetComponentsInChildren<IPage>())
            {
                page.OnTappedHomeButton -= nestedMenuController.Release;
                page.OnTappedHomeButton += nestedMenuController.Release;
            }
            
            foreach (var menu in nestedMenuController.NestedMenuConfigrations.Select(x => x.MenuList))
            {
                menu.OnRequest += OnRequest;
                menu.OnRequestedClose += () => menu.Close();
                menu.Close();
            }

            recoveryStaminaDialog.gameObject.SetActive(false);
            fillWarningStaminaDialog.gameObject.SetActive(false);
            soulListPage.gameObject.SetActive(false);
            soulSalePage.gameObject.SetActive(false);
        }

        private void OnRequest(UIMenuList.PageType type)
        {
            switch (type)
            {
                case UIMenuList.PageType.SoulList:
                    soulListPage.gameObject.SetActive(true);
                    soulListPage.Begin();
                    break;
                case UIMenuList.PageType.SoulSale:
                    soulSalePage.gameObject.SetActive(true);
                    soulSalePage.Begin();
                    break;
                case UIMenuList.PageType.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public void Tick()
        {
            headerUi.Tick();
            if (!soulListPage.gameObject.activeSelf && !soulSalePage.gameObject.activeSelf)
            {
                nestedMenuController.Tick();
            }
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