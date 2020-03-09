using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MokomoGames.Protobuf;
using MokomoGames.UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MokomoGames
{
    public class HomeSequencer : MonoBehaviour, ISequencer
    {
        public MasterSequencer.SequencerType Type => MasterSequencer.SequencerType.Home;
        
        [SerializeField] private UIHeader headerUi;
        [SerializeField] private UIRankConfirm rankConfirm;
        [SerializeField] private UIFillWarningStaminaDialog fillWarningStaminaDialog;
        [SerializeField] private UIRecoveryStaminaDialog recoveryStaminaDialog;
        [SerializeField] private Button soulLaboToggle;
        [SerializeField] private UISoulLaboMenu soulLaboMenu;
        [SerializeField] private UISoulListMenu soulListMenu;
        [SerializeField] private UISoulListPage soulListPage;
        [Inject] private IPlayerSaveDataRepository _playerSaveDataRepository;
        [Inject] private IMasterDataRepository _masterDataRepository;
        private StaminaRecoveryTimeController staminaRecoveryTimeController;
        private PlayerSaveDataContainer _playerSaveDataContainer;
        private UIMenuListContainer _menuListContainer = new UIMenuListContainer();
        public event Action<MasterSequencer.SequencerType, bool, Func<bool>> OnLeave;

        public async void Begin()
        {
            Display(true);
            
            _playerSaveDataContainer = new PlayerSaveDataContainer(_masterDataRepository,_playerSaveDataRepository);
            await _playerSaveDataContainer.Load();
            soulListPage.Prepare(_playerSaveDataContainer);
            Refresh(_playerSaveDataContainer);

            staminaRecoveryTimeController = new StaminaRecoveryTimeController(_playerSaveDataRepository);
            staminaRecoveryTimeController.OnRecoveriedStamina += () =>
            {
                _playerSaveDataContainer.Fuel += 1;
                Refresh(_playerSaveDataContainer);
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
                rankConfirm.SetCurrentRank(_playerSaveDataContainer.Rank);
                rankConfirm.SetExpGauge(
                    _playerSaveDataContainer.GetNeedNextRankExp() - _playerSaveDataContainer.Exp ,
                    _playerSaveDataContainer.GetNeedNextRankExp());
                rankConfirm.SetStaminaGauge(
                    staminaRecoveryTimeController.Minutes,
                    staminaRecoveryTimeController.Seconds,
                    staminaRecoveryTimeController.RecoverySeconds);
            };
            headerUi.StaminaUi.OnTapedRecoveryButton += () =>
            {
                recoveryStaminaDialog.Initialize(
                        _playerSaveDataContainer.Fuel,
                        _playerSaveDataContainer.GetMaxFuel(),
                        _playerSaveDataContainer.Yukichi,
                        1
                    );
                recoveryStaminaDialog.Open();
            };
            headerUi.OnRelease += () => { rankConfirm.gameObject.SetActive(false); };
            
            recoveryStaminaDialog.OnTappedCloseButton += recoveryStaminaDialog.Close;
            recoveryStaminaDialog.OnTappedNoButton += recoveryStaminaDialog.Close;
            recoveryStaminaDialog.OnTappedYesButton += () =>
            {
                fillWarningStaminaDialog.Open();
                fillWarningStaminaDialog.ShowMaxFuelMessage(_playerSaveDataContainer.IsMaxFuel);
                if (!_playerSaveDataContainer.IsMaxFuel)
                {
                    
                    _playerSaveDataContainer.Fuel += _playerSaveDataContainer.GetMaxFuel();
                    _playerSaveDataContainer.Yukichi--;
                    _playerSaveDataRepository.RecoveryFuelByYukichi();
                    Refresh(_playerSaveDataContainer);
                }
                fillWarningStaminaDialog.SetStamina(_playerSaveDataContainer.Fuel,_playerSaveDataContainer.GetMaxFuel());
                fillWarningStaminaDialog.SetYukichiNum(_playerSaveDataContainer.Yukichi);
                recoveryStaminaDialog.Close();
            };
            fillWarningStaminaDialog.OnTappedClose += fillWarningStaminaDialog.Close;
            fillWarningStaminaDialog.OnTappedConfirm += fillWarningStaminaDialog.Close;
            
            soulLaboToggle.onClick.AddListener(() =>
            {
                _menuListContainer.Add(soulLaboMenu);
            });
            soulLaboMenu.ListButton.onClick.AddListener(() =>
            {
                _menuListContainer.Add(soulListMenu);
            });
            
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

        public void ReleaseAllMenuList()
        {
            _menuListContainer.RemoveAll();
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
        
        private void Refresh(PlayerSaveDataContainer saveDataContainer)
        {
            headerUi.SetStamina(
                saveDataContainer.Fuel,
                saveDataContainer.GetMaxFuel());
            headerUi.SetCoinNum(saveDataContainer.Coin);
            headerUi.SetMizuNum(saveDataContainer.Mizu);
            headerUi.SetYukichiNum(saveDataContainer.Yukichi);
            headerUi.SetRank(
                saveDataContainer.Rank,
                saveDataContainer.Exp,
                saveDataContainer.GetNeedNextRankExp());
        }
    }
}