using System;
using UnityEngine;
using UnityEngine.UI;

namespace MokomoGames.UI
{
    public class UIFavoriteButton : MonoBehaviour
    {
        [SerializeField] private Image facoriteIcon;
        [SerializeField] private Button favoriteButton;
        [SerializeField] private Sprite lockSprite;
        [SerializeField] private Sprite unlockSprite;
        public event Action OnTappedIcon;

        private void Awake()
        {
            favoriteButton.onClick.AddListener(() => OnTappedIcon?.Invoke());
        }

        public void UpdateIcon(bool favorite)
        {
            facoriteIcon.sprite = favorite ? lockSprite : unlockSprite;
        }
    }
}