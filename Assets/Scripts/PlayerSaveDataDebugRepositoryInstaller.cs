using Zenject;

namespace MokomoGames
{
    public class PlayerSaveDataDebugRepositoryInstaller : Installer<PlayerSaveDataDebugRepositoryInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IPlayerSaveDataRepository>()
                .To<PlayerSaveDataDebugRepository>()
                .AsCached();
        }
    }
}