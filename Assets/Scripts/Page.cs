using System;
using MokomoGames.UI;
using UnityEngine;

namespace MokomoGames
{
    public abstract class Page: MonoBehaviour,IPage
    {
        public abstract bool Showing { get; }
        public abstract void Begin();
        public abstract void Show(bool show);
        public abstract PageRepository.PageType PageType { get; }
        public abstract event Action OnTappedHomeButton;
    }
}