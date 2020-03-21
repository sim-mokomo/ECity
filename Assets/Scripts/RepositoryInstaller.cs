using UnityEngine;
using Zenject;

namespace MokomoGames
{
    public class RepositoryInstaller : MonoInstaller
    {
        [SerializeField] private bool useDebugMasterRepo;
        [SerializeField] private bool useDebugPlayerRepo;

        public override void InstallBindings()
        {
            if (useDebugPlayerRepo)
                PlayerSaveDataDebugRepositoryInstaller.Install(Container);
            else
                PlayerSaveDataRepositoryInstaller.Install(Container);

            if (useDebugMasterRepo)
                MasterDataDebugRepositoryInstaller.Install(Container);
            else
                MasterDataRepositoryInstaller.Install(Container);
        }
    }
}