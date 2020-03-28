using System;

namespace MokomoGames.UI
{
    public interface IPage
    {
        bool Showing { get; }
        PageRepository.PageType PageType { get; }
        void Begin();
        void Show(bool show);
        event Action OnTappedHomeButton;
    }

    public interface ISoulPage : IPage
    {
        void SetData(UserSoulList userSoulList);
    }
}