using Zenject;

namespace MokomoGames
{
    public class PlayerSaveDataRepositoryInstaller : Installer<PlayerSaveDataRepositoryInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IPlayerSaveDataRepository>()
                .To<PlayerSaveDataRepository>()
                .AsCached();
        }
    }
}