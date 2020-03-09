using System.Linq;
using MokomoGames.Protobuf;

namespace MokomoGames
{
    public class UserSoulDataContainer
    {
        private UserSoulData _userSoulData;
        private SoulTableRecord _baseConfig;
        private SoulLevelTableRecord _levelTableRecord;
        public SoulTableRecord BaseConfig => _baseConfig;

        public UserSoulDataContainer(UserSoulData userSoulData,IMasterDataRepository masterDataRepository,IPlayerSaveDataRepository playerSaveDataRepository)
        {
            _userSoulData = userSoulData;
            _baseConfig = masterDataRepository.SoulTable.Records.FirstOrDefault(x => x.No == _userSoulData.SoulNo);

            var soulLevelRecords = masterDataRepository.SoulLevelTable.Records;
            var totalExp = 0u;
            foreach (var record in soulLevelRecords)
            {
                totalExp += record.NeedNextLevelExp;
                if (totalExp <= _userSoulData.TotalLevelExp)
                {
                    _levelTableRecord = record;
                }
            }

            _levelTableRecord = soulLevelRecords.FirstOrDefault(x =>
                x.No == _userSoulData.SoulNo && x.Level == _levelTableRecord.Level);
        }
    }
}