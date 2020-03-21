using System;
using System.Collections.Generic;
using System.Linq;
using MokomoGames.Protobuf;

namespace MokomoGames
{
    public class UserSoulDataContainerList
    {
        private readonly IEnumerable<UserSoulDataContainer> _containers;

        public UserSoulDataContainerList(IEnumerable<UserSoulDataContainer> containers)
        {
            _containers = containers;
        }

        public UserSoulDataContainerList(IEnumerable<UserSoulData> userSoulDatas,
            IMasterDataRepository masterDataRepository)
        {
            _containers = userSoulDatas.Select(x => new UserSoulDataContainer(x, masterDataRepository));
        }

        public bool ExistMaterialSouls => GetMaterialSouls().Any();
        public bool ExistBattleSouls => GetBattleSouls().Any();
        public static IEnumerable<UserSoulDataContainer> Empty => Array.Empty<UserSoulDataContainer>();

        public IEnumerable<UserSoulDataContainer> GetMaterialSouls()
        {
            return _containers.Where(x => x.BaseConfig.SoulType.IsMaterial());
        }

        public IEnumerable<UserSoulDataContainer> GetBattleSouls()
        {
            return _containers.Where(x => !x.BaseConfig.SoulType.IsMaterial());
        }
    }
}