using System;
using System.Collections.Generic;
using MokomoGames.Protobuf;
using UI;
using UnityEngine;
using UnityEngine.UI;
using Attribute = MokomoGames.Protobuf.Attribute;

namespace MokomoGames.UI
{
    public class UISoulCell : MonoBehaviour
    {
        public float Height => _rectTransform.rect.height;
        public float Width => _rectTransform.rect.width;
        private RectTransform _rectTransform;
        [SerializeField] private Image attributeIcon;
        [SerializeField] private Image attributeBackgroundImage;
        [SerializeField] private Image characterIcon;
        [SerializeField] private UIStars stars;
        [SerializeField] private Button characterIconButton;
        private UserSoulDataContainer _soulDataContainer;
        public event Action<UserSoulDataContainer> OnTappedIcon;
        
        //TODO: sprite に置き換えられる予定
        private static readonly Dictionary<Attribute,Color> attributeColorTable = new Dictionary<Attribute, Color>()
        {
            {Attribute.Fire,new Color(1f, 0.33f, 0.33f)},
            {Attribute.Water,new Color(0.38f, 0.39f, 1f)},
            {Attribute.Wood,new Color(0.41f, 1f, 0.42f)},
            {Attribute.Light,new Color(1f, 0.76f, 0.25f)},
            {Attribute.Shadow,new Color(0.89f, 0.37f, 1f)},
        };
        
        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            characterIconButton.onClick.AddListener( () => OnTappedIcon?.Invoke(_soulDataContainer));
        }

        public void Begin(UserSoulDataContainer soulDataContainer)
        {
            attributeIcon.sprite = SpriteResourcesProvider.GetAttributeIcon(soulDataContainer.BaseConfig.Attribute);
            characterIcon.sprite = SpriteResourcesProvider.GetCharacterIcon(soulDataContainer.BaseConfig.CharacterIconName);
            attributeColorTable.TryGetValue(soulDataContainer.BaseConfig.Attribute,out var backgroundColor);
            attributeBackgroundImage.color = backgroundColor; 
            stars.Show(soulDataContainer.BaseConfig.Rarity);

            _soulDataContainer = soulDataContainer;
        }
        
        public void Show(bool show)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                child.gameObject.SetActive(show);
            }
        }
    }
}