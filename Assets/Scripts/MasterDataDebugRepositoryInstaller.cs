using MokomoGames;
using Zenject;

public class MasterDataDebugRepositoryInstaller : Installer<MasterDataDebugRepositoryInstaller>
{
    public override void InstallBindings()
    {
        Container
            .Bind<IMasterDataRepository>()
            .To<MasterDataDebugRepository>()
            .AsCached();
    }
}