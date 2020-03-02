using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MokomoGames.UI
{
    public class UISoulListPage : MonoBehaviour,IPage
    {
        [SerializeField] private Button backButton;
        [SerializeField] private Button homeButton;

        public event Action OnTappedHomeButton;

        private void Awake()
        {
            backButton.onClick.AddListener( () => gameObject.SetActive(false));
            homeButton.onClick.AddListener( () =>
            {
                gameObject.SetActive(false);
                OnTappedHomeButton?.Invoke();
            });
        }
    }
}
