using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MokomoGames
{
    public class RepositoryInstaller : MonoInstaller
    {
        [SerializeField] private bool useDebug;
        public override void InstallBindings()
        {
            if (useDebug)
            {
                PlayerSaveDataDebugRepositoryInstaller.Install(Container);
            }
            else
            {
                PlayerSaveDataRepositoryInstaller.Install(Container);
            }
            
            MasterDataRepositoryInstaller.Install(Container);
        }
    }
}
