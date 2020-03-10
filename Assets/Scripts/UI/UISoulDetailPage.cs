using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace MokomoGames.UI
{
    public class UISoulDetailPage : MonoBehaviour
    {
        // 属性アイコン
        [SerializeField] private TextMeshProUGUI elementNameText;
        [SerializeField] private Image elementIcon;
        // パラメータ群
        [SerializeField] private TextMeshProUGUI hpText;
        [SerializeField] private TextMeshProUGUI recoveryPowerText;
        [SerializeField] private TextMeshProUGUI attackText;
        [SerializeField] private TextMeshProUGUI costText;
        // レベル
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private UIGaugeWithUpperLabel expGauge;
        // ノーマルスキル
        [SerializeField] private TextMeshProUGUI normalSkillNameText;
        [SerializeField] private UIGaugeWithUpperLabel normalSkillGauge;
        [SerializeField] private TextMeshProUGUI normalSkillLevelText;
        [SerializeField] private TextMeshProUGUI normalSkillContentText;
        [SerializeField] private TextMeshProUGUI normalSkillChargeTurnText;
        // リーダースキル
        [SerializeField] private TextMeshProUGUI readerSkillNameText;
        [SerializeField] private TextMeshProUGUI readerSkillContentText;
        // 名前
        [SerializeField] private TextMeshProUGUI subNameText;
        [SerializeField] private TextMeshProUGUI mainNameText;
        [SerializeField] private UIStars rarityUI;
        // タイプ
        [SerializeField] private TextMeshProUGUI noText;
        [SerializeField] private TextMeshProUGUI typeText;
        [SerializeField] private Button favoriteButton;

        [SerializeField] private Button backButton;
        public event Action OnTappedBackButton;

        private void Awake()
        {
            favoriteButton.onClick.AddListener(() =>
            {
                //TODO: identity id を元にお気に入り登録をする
            });
            
            backButton.onClick.AddListener(() =>
            {
                OnTappedBackButton?.Invoke();
            });
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
        }

        public void Show(bool show)
        {
            gameObject.SetActive(show);
        }
    }
}
