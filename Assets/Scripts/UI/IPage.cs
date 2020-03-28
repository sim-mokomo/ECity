using System;

namespace MokomoGames.UI
{
    public interface IPage
    {
        bool Showing { get; }
        void Begin();
        void Show(bool show);
        PageRepository.PageType PageType { get; }   
        event Action OnTappedHomeButton;
    }

    public interface ISoulPage : IPage
    {
        void SetData(UserSoulList userSoulList);
    }
}
