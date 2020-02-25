using MokomoGames.Protobuf;
using UniRx.Async;

namespace MokomoGames
{
    public interface IMasterDataRepository
    {
        bool AllLoaded { get; }
        RankTable RankTable { get; }
        void LoadAllTable();
    }
}