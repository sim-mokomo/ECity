using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MokomoGames.UI
{
    public class UIFavoriteButton : MonoBehaviour
    {
        [SerializeField] private Sprite lockSprite;
        [SerializeField] private Sprite unlockSprite;
        [SerializeField] private Button favoriteButton;
        [SerializeField] private Image facoriteIcon;
        public event Action OnTappedIcon;

        private void Awake()
        {
            favoriteButton.onClick.AddListener( () => OnTappedIcon?.Invoke() );   
        }

        public void UpdateIcon(bool favorite)
        {
            facoriteIcon.sprite = favorite ? lockSprite : unlockSprite;
        }
    }
}
