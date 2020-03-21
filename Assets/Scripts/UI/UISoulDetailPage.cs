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
        private Soul _soul;
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
                    _soul.UserData.Guid,
                    _soul.UserData.Favorite);
                _soul.UserData.Favorite = response.Favorite;
                _favoriteButton.UpdateIcon(_soul.UserData.Favorite);
            };

            backButton.onClick.AddListener(() => { OnTappedBackButton?.Invoke(); });
        }

        public void Begin(Soul soul)
        {
            subNameText.text = soul.Config.AnotherName;
            mainNameText.text = soul.Config.Name;
            rarityUI.Show(soul.Config.Rarity);

            levelText.text = $"{soul.LevelTableRecord.Level}/{999}";
            hpText.text = $"{soul.LevelTableRecord.Hp}";
            attackText.text = $"{soul.LevelTableRecord.Power}";
            recoveryPowerText.text = $"{soul.LevelTableRecord.RecoveryPower}";
            costText.text = $"{soul.Config.Cost}";

            elementIcon.sprite = SpriteResourcesProvider.GetAttributeIcon(soul.Config.Attribute);
            elementNameText.text = soul.Config.Attribute.GetName();
            expGauge.SetRemainingValue($"{soul.GetRemainingLevelExp()}");
            expGauge.SetRemainingSliderValue(
                soul.UserData.TotalLevelExp,
                soul.GetTotalNeedLevelExp());

            normalSkillNameText.text = soul.NormalSkillTableRecord.Name;
            normalSkillContentText.text = soul.NormalSkillTableRecord.Description;
            normalSkillLevelText.text = soul.NormalSkillLevelTableRecord.Level.ToString();
            normalSkillGauge.SetRemainingValue($"{soul.GetRemainingNormalSkillExp()}");
            normalSkillGauge.SetRemainingSliderValue(
                soul.UserData.TotalSkillExp,
                soul.GetTotalNeedNormalSkillLevelExp());
            normalSkillChargeTurnText.text = $"ターン:{soul.NormalSkillTableRecord.BaseTurn}";

            readerSkillNameText.text = soul.ReaderSkillTableRecord.Name;
            readerSkillContentText.text = soul.ReaderSkillTableRecord.Description;

            noText.text = $"{soul.Config.No}";
            typeText.text = $"{soul.Config.SoulType.GetName()}";

            _soul = soul;
        }

        public void Show(bool show)
        {
            gameObject.SetActive(show);
        }
    }
}