using System.Linq;
using MokomoGames.Protobuf;

namespace MokomoGames
{
    public class Soul
    {
        private readonly IMasterDataRepository _masterDataRepository;

        public Soul(UserSoulData userData, IMasterDataRepository masterDataRepository)
        {
            UserData = userData;
            Config = masterDataRepository.SoulTable.Records.FirstOrDefault(x => x.No == UserData.SoulNo);
            _masterDataRepository = masterDataRepository;
            NormalSkillTableRecord =
                masterDataRepository.NormalSkillTable.Records.FirstOrDefault(x => x.No == Config.NormalSkillId);
            ReaderSkillTableRecord =
                masterDataRepository.ReaderSkillTable.Records.FirstOrDefault(x => x.No == Config.ReaderSkillId);
            LevelTableRecord = GetLevelRecord(masterDataRepository.SoulLevelTable, UserData.TotalLevelExp);
            NormalSkillLevelTableRecord = GetNormalSkillLevelRecord(masterDataRepository.NormalSkillLevelTable,
                UserData.TotalSkillExp);
        }

        public SoulTableRecord Config { get; }

        public UserSoulData UserData { get; }

        public SoulLevelTableRecord LevelTableRecord { get; }

        public NormalSkillTableRecord NormalSkillTableRecord { get; }

        public NormalSkillLevelTableRecord NormalSkillLevelTableRecord { get; }

        public ReaderSkillTableRecord ReaderSkillTableRecord { get; }

        private SoulLevelTableRecord GetLevelRecord(SoulLevelTable soulLevelTable, uint totalLevelExp)
        {
            var totalExp = 0u;
            var res = new SoulLevelTableRecord
            {
                Hp = 1,
                Level = 1,
                No = 1,
                Power = 1,
                RecoveryPower = 1,
                NeedNextLevelExp = 200
            };
            foreach (var record in soulLevelTable.Records
                .Where(x => x.No == UserData.SoulNo))
            {
                res = record;
                totalExp += record.NeedNextLevelExp;
                if (totalExp >= totalLevelExp) break;
            }

            return res;
        }

        private NormalSkillLevelTableRecord GetNormalSkillLevelRecord(NormalSkillLevelTable normalSkillLevelTable,
            uint totalSkillExp)
        {
            var totalExp = 0u;
            var res = new NormalSkillLevelTableRecord();
            foreach (var record in normalSkillLevelTable.Records)
            {
                res = record;
                totalExp += record.NeedNextLevelExp;
                if (totalExp >= totalSkillExp) break;
            }

            return res;
        }

        public uint GetRemainingLevelExp()
        {
            return GetTotalNeedLevelExp() - UserData.TotalLevelExp;
        }

        public uint GetTotalNeedLevelExp()
        {
            var records = _masterDataRepository.SoulLevelTable.Records
                .Where(x => x.No == LevelTableRecord.No)
                .Where(x => x.Level <= LevelTableRecord.Level);
            var totalExp = records.Any() ? records.Sum(x => x.NeedNextLevelExp) : 200;
            return 200;
        }

        public uint GetRemainingNormalSkillExp()
        {
            return GetTotalNeedNormalSkillLevelExp() - UserData.TotalSkillExp;
        }

        public uint GetTotalNeedNormalSkillLevelExp()
        {
            return (uint) _masterDataRepository.NormalSkillLevelTable.Records
                .Where(x => x.Level <= NormalSkillLevelTableRecord.Level)
                .Sum(x => x.NeedNextLevelExp);
        }
    }
}