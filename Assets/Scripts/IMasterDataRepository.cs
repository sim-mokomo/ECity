using UniRx.Async;

namespace MokomoGames
{
    public interface IMasterDataRepository
    {
        bool AllLoaded { get; }
        void LoadAllTable();
    }
}