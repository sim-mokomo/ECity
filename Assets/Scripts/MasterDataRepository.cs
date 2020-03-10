using System.Collections;
using System.Collections.Generic;
using MokomoGames;
using MokomoGames.Protobuf;
using UniRx.Async;
using UnityEngine;

namespace MokomoGames
{
    public class MasterDataRepository : IMasterDataRepository
    {
        private RankTable _rankTable;
        private SoulTable _soulTable;
        private SoulLevelTable _soulLevelTable;
        public RankTable RankTable => _rankTable;
        public SoulTable SoulTable => _soulTable;
        public SoulLevelTable SoulLevelTable => _soulLevelTable;
        public NormalSkillTable NormalSkillTable => null;
        public NormalSkillLevelTable NormalSkillLevelTable => null;
        public ReaderSkillTable ReaderSkillTable => null;

        public bool AllLoaded =>
            RankTable != null &&
            SoulTable != null &&
            SoulLevelTable != null;

        public async void LoadAllTable()
        {
            _rankTable = await PlayFabUtility.ExecuteFunctionAsync<RankTable>("getRankTable", null);
            _soulTable = await PlayFabUtility.ExecuteFunctionAsync<SoulTable>("getSoulTable", null);
            _soulLevelTable = await PlayFabUtility.ExecuteFunctionAsync<SoulLevelTable>("getSoulLevelTable", null);
        }
    }
}
