using System.Collections;
using System.Collections.Generic;
using MokomoGames;
using UnityEngine;
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
