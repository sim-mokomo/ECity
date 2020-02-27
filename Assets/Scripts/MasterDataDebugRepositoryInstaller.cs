using System.Collections;
using System.Collections.Generic;
using MokomoGames;
using UnityEngine;
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
