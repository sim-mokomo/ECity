using System;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.UI;
using Attribute = MokomoGames.Protobuf.Attribute;

namespace MokomoGames.UI
{
    public class UISoulCell : MonoBehaviour
    {
        //TODO: sprite に置き換えられる予定
        private static readonly Dictionary<Attribute, Color> attributeColorTable = new Dictionary<Attribute, Color>
        {
            {Attribute.Fire, new Color(1f, 0.33f, 0.33f)},
            {Attribute.Water, new Color(0.38f, 0.39f, 1f)},
            {Attribute.Wood, new Color(0.41f, 1f, 0.42f)},
            {Attribute.Light, new Color(1f, 0.76f, 0.25f)},
            {Attribute.Shadow, new Color(0.89f, 0.37f, 1f)}
        };

        private RectTransform _rectTransform;
        private UserSoulDataContainer _soulDataContainer;
        [SerializeField] private Image attributeBackgroundImage;
        [SerializeField] private Image attributeIcon;
        [SerializeField] private Image characterIcon;
        [SerializeField] private Button characterIconButton;
        [SerializeField] private UIStars stars;
        public float Height => _rectTransform.rect.height;
        public float Width => _rectTransform.rect.width;
        public event Action<UserSoulDataContainer> OnTappedIcon;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            characterIconButton.onClick.AddListener(() => OnTappedIcon?.Invoke(_soulDataContainer));
        }

        public void Begin(UserSoulDataContainer soulDataContainer)
        {
            attributeIcon.sprite = SpriteResourcesProvider.GetAttributeIcon(soulDataContainer.BaseConfig.Attribute);
            characterIcon.sprite =
                SpriteResourcesProvider.GetCharacterIcon(soulDataContainer.BaseConfig.CharacterIconName);
            attributeColorTable.TryGetValue(soulDataContainer.BaseConfig.Attribute, out var backgroundColor);
            attributeBackgroundImage.color = backgroundColor;
            stars.Show(soulDataContainer.BaseConfig.Rarity);

            _soulDataContainer = soulDataContainer;
        }

        public void Show(bool show)
        {
            for (var i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                child.gameObject.SetActive(show);
            }
        }
    }
}