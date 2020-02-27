using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MokomoGames
{
    public class RepositoryInstaller : MonoInstaller
    {
        [SerializeField] private bool useDebugPlayerRepo;
        [SerializeField] private bool useDebugMasterRepo;
        public override void InstallBindings()
        {
            if (useDebugPlayerRepo)
            {
                PlayerSaveDataDebugRepositoryInstaller.Install(Container);
            }
            else
            {
                PlayerSaveDataRepositoryInstaller.Install(Container);
            }

            if (useDebugMasterRepo)
            {
                MasterDataDebugRepositoryInstaller.Install(Container);
            }
            else
            {
                MasterDataRepositoryInstaller.Install(Container);
            }
        }
    }
}
