using System.IO;
using MokomoGames.Protobuf;

namespace MokomoGames
{
    public class MasterDataDebugRepository : IMasterDataRepository
    {
        public RankTable RankTable { get; private set; }

        public SoulTable SoulTable { get; private set; }

        public NormalSkillTable NormalSkillTable { get; private set; }

        public ReaderSkillTable ReaderSkillTable { get; private set; }

        public SoulLevelTable SoulLevelTable { get; private set; }

        public NormalSkillLevelTable NormalSkillLevelTable { get; private set; }

        public bool AllLoaded =>
            RankTable != null &&
            SoulTable != null &&
            NormalSkillTable != null &&
            ReaderSkillTable != null &&
            SoulLevelTable != null &&
            NormalSkillLevelTable != null;

        public void LoadAllTable()
        {
            RankTable = RankTable.Parser.ParseJson(File.ReadAllText("./Assets/Debug/Json/RankTable.json"));
            SoulTable = SoulTable.Parser.ParseJson(File.ReadAllText("./Assets/Debug/Json/SoulTable.json"));
            NormalSkillTable =
                NormalSkillTable.Parser.ParseJson(File.ReadAllText("./Assets/Debug/Json/NormalSkillTable.json"));
            ReaderSkillTable =
                ReaderSkillTable.Parser.ParseJson(File.ReadAllText("./Assets/Debug/Json/ReaderSkillTable.json"));
            SoulLevelTable =
                SoulLevelTable.Parser.ParseJson(File.ReadAllText("./Assets/Debug/Json/SoulLevelTable.json"));
            NormalSkillLevelTable =
                NormalSkillLevelTable.Parser.ParseJson(
                    File.ReadAllText("./Assets/Debug/Json/NormalSkillLevelTable.json"));
        }
    }
}