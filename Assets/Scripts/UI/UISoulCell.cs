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
        private Soul _soul;
        [SerializeField] private Image attributeBackgroundImage;
        [SerializeField] private Image attributeIcon;
        [SerializeField] private Image characterIcon;
        [SerializeField] private Button characterIconButton;
        [SerializeField] private UIStars stars;
        [SerializeField] private UICheckMark _checkMark;
        [SerializeField] private Image grayOutImage;
        public float Height => _rectTransform.rect.height;
        public float Width => _rectTransform.rect.width;
        public Soul Soul => _soul;

        public event Action<Soul> OnTappedIcon;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            characterIconButton.onClick.AddListener(() => OnTappedIcon?.Invoke(_soul));
        }

        public void Begin(Soul soul)
        {
            attributeIcon.sprite = SpriteResourcesProvider.GetAttributeIcon(soul.Config.Attribute);
            characterIcon.sprite =
                SpriteResourcesProvider.GetCharacterIcon(soul.Config.CharacterIconName);
            attributeColorTable.TryGetValue(soul.Config.Attribute, out var backgroundColor);
            attributeBackgroundImage.color = backgroundColor;
            stars.Show(soul.Config.Rarity);

            _soul = soul;
        }

        public void Show(bool show)
        {
            for (var i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                child.gameObject.SetActive(show);
            }
        }

        public void Selecting(bool selecting)
        {
            grayOutImage.gameObject.SetActive(selecting);
            _checkMark.gameObject.SetActive(selecting);
        }
    }
}