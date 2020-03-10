using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Google.Protobuf;
using MokomoGames;
using MokomoGames.Protobuf;
using UniRx.Async;
using UnityEngine;

namespace MokomoGames
{
    public class MasterDataDebugRepository : IMasterDataRepository
    {
        private RankTable _rankTable;
        private SoulTable _soulTable;
        private NormalSkillTable _normalSkillTable;
        private ReaderSkillTable _readerSkillTable;
        private SoulLevelTable _soulLevelTable;
        private NormalSkillLevelTable _normalSkillLevelTable;
        
        public RankTable RankTable => _rankTable;
        public SoulTable SoulTable => _soulTable;
        public NormalSkillTable NormalSkillTable => _normalSkillTable;
        public ReaderSkillTable ReaderSkillTable => _readerSkillTable;
        public SoulLevelTable SoulLevelTable => _soulLevelTable;
        public NormalSkillLevelTable NormalSkillLevelTable => _normalSkillLevelTable;

        public bool AllLoaded =>
            RankTable != null &&
            SoulTable != null &&
            NormalSkillTable != null &&
            ReaderSkillTable != null &&
            SoulLevelTable != null &&
            NormalSkillLevelTable != null;

        public void LoadAllTable()
        {
            _rankTable = RankTable.Parser.ParseJson(File.ReadAllText("./Assets/Debug/Json/RankTable.json"));
            _soulTable = SoulTable.Parser.ParseJson(File.ReadAllText("./Assets/Debug/Json/SoulTable.json"));
            _normalSkillTable = NormalSkillTable.Parser.ParseJson(File.ReadAllText("./Assets/Debug/Json/NormalSkillTable.json"));
            _readerSkillTable = ReaderSkillTable.Parser.ParseJson(File.ReadAllText("./Assets/Debug/Json/ReaderSkillTable.json"));
            _soulLevelTable = SoulLevelTable.Parser.ParseJson(File.ReadAllText("./Assets/Debug/Json/SoulLevelTable.json"));
            _normalSkillLevelTable = NormalSkillLevelTable.Parser.ParseJson(File.ReadAllText("./Assets/Debug/Json/NormalSkillLevelTable.json"));
        }
    }
}
