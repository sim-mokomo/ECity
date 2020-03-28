using System;
using System.Collections.Generic;
using System.Linq;
using MokomoGames.Protobuf;

namespace MokomoGames
{
    public class UserSoulList
    {
        private readonly IEnumerable<Soul> _souls;

        public UserSoulList(IEnumerable<Soul> souls)
        {
            _souls = souls;
        }

        public UserSoulList(IEnumerable<UserSoulData> userSoulDatas,
            IMasterDataRepository masterDataRepository)
        {
            _souls = userSoulDatas.Select(x => new Soul(x, masterDataRepository));
        }

        public bool ExistMaterialSouls => GetMaterialSouls().Any();
        public bool ExistBattleSouls => GetBattleSouls().Any();
        public static IEnumerable<Soul> Empty => Array.Empty<Soul>();

        public IEnumerable<Soul> GetMaterialSouls()
        {
            var souls = _souls.Where(x => x.Config.SoulType.IsMaterial());
            if (!souls.Any())
                return Empty;
            return souls;
        }

        public IEnumerable<Soul> GetBattleSouls()
        {
            var souls = _souls.Where(x => !x.Config.SoulType.IsMaterial());
            if (!souls.Any())
                return Empty;
            return _souls;
        }
    }
}