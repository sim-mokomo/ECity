using System;
using System.Collections.Generic;
using System.Linq;

namespace MokomoGames
{
    public class UserSoulDataContainerList
    {
        private readonly IEnumerable<UserSoulDataContainer> _containers;

        public UserSoulDataContainerList(IEnumerable<UserSoulDataContainer> containers)
        {
            _containers = containers;
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