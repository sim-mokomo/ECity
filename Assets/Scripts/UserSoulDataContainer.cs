using System.Linq;
using MokomoGames.Protobuf;

namespace MokomoGames
{
    public class UserSoulDataContainer
    {
        private UserSoulData _userSoulData;
        private SoulTableRecord _baseConfig;
        private SoulLevelTableRecord _levelTableRecord;
        private IMasterDataRepository _masterDataRepository;
        private NormalSkillTableRecord _normalSkillTableRecord;
        private NormalSkillLevelTableRecord _normalSkillLevelTableRecord;
        private ReaderSkillTableRecord _readerSkillTableRecord;
        public SoulTableRecord BaseConfig => _baseConfig;
        public UserSoulData UserSoulData => _userSoulData;
        public SoulLevelTableRecord LevelTableRecord => _levelTableRecord;
        public NormalSkillTableRecord NormalSkillTableRecord => _normalSkillTableRecord;
        public NormalSkillLevelTableRecord NormalSkillLevelTableRecord => _normalSkillLevelTableRecord;
        public ReaderSkillTableRecord ReaderSkillTableRecord => _readerSkillTableRecord;

        public UserSoulDataContainer(UserSoulData userSoulData,IMasterDataRepository masterDataRepository,IPlayerSaveDataRepository playerSaveDataRepository)
        {
            _userSoulData = userSoulData;
            _baseConfig = masterDataRepository.SoulTable.Records.FirstOrDefault(x => x.No == _userSoulData.SoulNo);
            _masterDataRepository = masterDataRepository;
            _normalSkillTableRecord =
                masterDataRepository.NormalSkillTable.Records.FirstOrDefault(x => x.No == BaseConfig.NormalSkillId);
            _readerSkillTableRecord =
                masterDataRepository.ReaderSkillTable.Records.FirstOrDefault(x => x.No == BaseConfig.ReaderSkillId);
            _levelTableRecord = GetLevelRecord(masterDataRepository.SoulLevelTable,_userSoulData.TotalLevelExp);
            _normalSkillLevelTableRecord = GetNormalSkillLevelRecord(masterDataRepository.NormalSkillLevelTable,
                _userSoulData.TotalSkillExp);
        }

        private SoulLevelTableRecord GetLevelRecord(SoulLevelTable soulLevelTable,uint totalLevelExp)
        {
            var totalExp = 0u;
            var res = new SoulLevelTableRecord()
            {
                Hp = 1,
                Level = 1,
                No = 1,
                Power = 1,
                RecoveryPower = 1,
                NeedNextLevelExp = 200
            };
            foreach (var record in soulLevelTable.Records
                .Where(x => x.No == _userSoulData.SoulNo))
            {
                res = record;
                totalExp += record.NeedNextLevelExp;
                if (totalExp >= totalLevelExp)
                {
                    break;
                }
            }
            return res;
        }
        
        private NormalSkillLevelTableRecord GetNormalSkillLevelRecord(NormalSkillLevelTable normalSkillLevelTable,uint totalSkillExp)
        {
            var totalExp = 0u;
            var res = new NormalSkillLevelTableRecord();
            foreach (var record in normalSkillLevelTable.Records)
            {
                res = record;
                totalExp += record.NeedNextLevelExp;
                if (totalExp >= totalSkillExp)
                {
                    break;
                }
            }
            return res;
        }

        public uint GetRemainingLevelExp()
        {
            return GetTotalNeedLevelExp() - _userSoulData.TotalLevelExp;
        }
        
        public uint GetTotalNeedLevelExp()
        {
            var records = _masterDataRepository.SoulLevelTable.Records
                .Where(x => x.No == _levelTableRecord.No)
                .Where(x => x.Level <= _levelTableRecord.Level);
            var totalExp= records.Any() ? records.Sum(x => x.NeedNextLevelExp) : 200;
            return 200;
        }

        public uint GetRemainingNormalSkillExp()
        {
            return GetTotalNeedNormalSkillLevelExp() - _userSoulData.TotalSkillExp;
        }

        public uint GetTotalNeedNormalSkillLevelExp()
        {
            return (uint)_masterDataRepository.NormalSkillLevelTable.Records
                .Where(x => x.Level <= _normalSkillLevelTableRecord.Level)
                .Sum(x => x.NeedNextLevelExp);
        }
    }
}