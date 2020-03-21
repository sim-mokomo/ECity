using System;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MokomoGames.UI
{
    public class UISoulDetailPage : MonoBehaviour
    {
        [SerializeField] private UIFavoriteButton _favoriteButton;
        [Inject] private IPlayerSaveDataRepository _playerSaveDataRepository;
        private UserSoulDataContainer _soulDataContainer;
        [SerializeField] private TextMeshProUGUI attackText;

        [SerializeField] private Button backButton;
        [SerializeField] private TextMeshProUGUI costText;

        [SerializeField] private Image elementIcon;

        // 属性アイコン
        [SerializeField] private TextMeshProUGUI elementNameText;
        [SerializeField] private UIGaugeWithUpperLabel expGauge;

        [SerializeField] private Button favoriteButton;

        // パラメータ群
        [SerializeField] private TextMeshProUGUI hpText;

        // レベル
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private TextMeshProUGUI mainNameText;
        [SerializeField] private TextMeshProUGUI normalSkillChargeTurnText;
        [SerializeField] private TextMeshProUGUI normalSkillContentText;
        [SerializeField] private UIGaugeWithUpperLabel normalSkillGauge;

        [SerializeField] private TextMeshProUGUI normalSkillLevelText;

        // ノーマルスキル
        [SerializeField] private TextMeshProUGUI normalSkillNameText;

        // タイプ
        [SerializeField] private TextMeshProUGUI noText;
        [SerializeField] private UIStars rarityUI;

        [SerializeField] private TextMeshProUGUI readerSkillContentText;

        // リーダースキル
        [SerializeField] private TextMeshProUGUI readerSkillNameText;

        [SerializeField] private TextMeshProUGUI recoveryPowerText;

        // 名前
        [SerializeField] private TextMeshProUGUI subNameText;
        [SerializeField] private TextMeshProUGUI typeText;
        public event Action OnTappedBackButton;

        private void Awake()
        {
            _favoriteButton.OnTappedIcon += async () =>
            {
                var response = await _playerSaveDataRepository.UpdateUserSoulDataFavorite(
                    _soulDataContainer.UserSoulData.Guid,
                    _soulDataContainer.UserSoulData.Favorite);
                _soulDataContainer.UserSoulData.Favorite = response.Favorite;
                _favoriteButton.UpdateIcon(_soulDataContainer.UserSoulData.Favorite);
            };

            backButton.onClick.AddListener(() => { OnTappedBackButton?.Invoke(); });
        }

        public void Begin(UserSoulDataContainer soulDataContainer)
        {
            subNameText.text = soulDataContainer.BaseConfig.AnotherName;
            mainNameText.text = soulDataContainer.BaseConfig.Name;
            rarityUI.Show(soulDataContainer.BaseConfig.Rarity);

            levelText.text = $"{soulDataContainer.LevelTableRecord.Level}/{999}";
            hpText.text = $"{soulDataContainer.LevelTableRecord.Hp}";
            attackText.text = $"{soulDataContainer.LevelTableRecord.Power}";
            recoveryPowerText.text = $"{soulDataContainer.LevelTableRecord.RecoveryPower}";
            costText.text = $"{soulDataContainer.BaseConfig.Cost}";

            elementIcon.sprite = SpriteResourcesProvider.GetAttributeIcon(soulDataContainer.BaseConfig.Attribute);
            elementNameText.text = soulDataContainer.BaseConfig.Attribute.GetName();
            expGauge.SetRemainingValue($"{soulDataContainer.GetRemainingLevelExp()}");
            expGauge.SetRemainingSliderValue(
                soulDataContainer.UserSoulData.TotalLevelExp,
                soulDataContainer.GetTotalNeedLevelExp());

            normalSkillNameText.text = soulDataContainer.NormalSkillTableRecord.Name;
            normalSkillContentText.text = soulDataContainer.NormalSkillTableRecord.Description;
            normalSkillLevelText.text = soulDataContainer.NormalSkillLevelTableRecord.Level.ToString();
            normalSkillGauge.SetRemainingValue($"{soulDataContainer.GetRemainingNormalSkillExp()}");
            normalSkillGauge.SetRemainingSliderValue(
                soulDataContainer.UserSoulData.TotalSkillExp,
                soulDataContainer.GetTotalNeedNormalSkillLevelExp());
            normalSkillChargeTurnText.text = $"ターン:{soulDataContainer.NormalSkillTableRecord.BaseTurn}";

            readerSkillNameText.text = soulDataContainer.ReaderSkillTableRecord.Name;
            readerSkillContentText.text = soulDataContainer.ReaderSkillTableRecord.Description;

            noText.text = $"{soulDataContainer.BaseConfig.No}";
            typeText.text = $"{soulDataContainer.BaseConfig.SoulType.GetName()}";

            _soulDataContainer = soulDataContainer;
        }

        public void Show(bool show)
        {
            gameObject.SetActive(show);
        }
    }
}