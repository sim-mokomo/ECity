using MokomoGames.Protobuf;

namespace MokomoGames
{
    public class MasterDataRepository : IMasterDataRepository
    {
        public RankTable RankTable { get; private set; }

        public SoulTable SoulTable { get; private set; }

        public SoulLevelTable SoulLevelTable { get; private set; }

        public NormalSkillTable NormalSkillTable => null;
        public NormalSkillLevelTable NormalSkillLevelTable => null;
        public ReaderSkillTable ReaderSkillTable => null;

        public bool AllLoaded =>
            RankTable != null &&
            SoulTable != null &&
            SoulLevelTable != null;

        public async void LoadAllTable()
        {
            RankTable = await PlayFabUtility.ExecuteFunctionAsync<RankTable>("getRankTable", null);
            SoulTable = await PlayFabUtility.ExecuteFunctionAsync<SoulTable>("getSoulTable", null);
            SoulLevelTable = await PlayFabUtility.ExecuteFunctionAsync<SoulLevelTable>("getSoulLevelTable", null);
        }
    }
}