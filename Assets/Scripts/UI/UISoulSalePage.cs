using System;
using UnityEngine;

namespace MokomoGames.UI
{
    public class UISoulSalePage : MonoBehaviour, IPage
    {
        public enum Tab
        {
            Soul,
            Material
        }

        public event Action OnTappedHomeButton;
    }
}