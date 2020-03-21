using MokomoGames.Protobuf;

namespace MokomoGames
{
    public interface IMasterDataRepository
    {
        bool AllLoaded { get; }
        RankTable RankTable { get; }
        SoulTable SoulTable { get; }
        SoulLevelTable SoulLevelTable { get; }
        NormalSkillTable NormalSkillTable { get; }
        NormalSkillLevelTable NormalSkillLevelTable { get; }
        ReaderSkillTable ReaderSkillTable { get; }
        void LoadAllTable();
    }
}