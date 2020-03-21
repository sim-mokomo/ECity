using MokomoGames;
using Zenject;

public class MasterDataRepositoryInstaller : Installer<MasterDataRepositoryInstaller>
{
    public override void InstallBindings()
    {
        Container
            .Bind<IMasterDataRepository>()
            .To<MasterDataRepository>()
            .AsCached();
    }
}