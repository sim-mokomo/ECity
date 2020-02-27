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
        public RankTable RankTable => _rankTable;

        public bool AllLoaded => RankTable != null;

        public void LoadAllTable()
        {
            _rankTable = RankTable.Parser.ParseJson(File.ReadAllText("./Assets/Debug/Json/RankTable.json"));
            //PlayFabUtility.ExecuteFunction<RankTable>("getRankTable", null, table => { _rankTable = table; });
            //_rankTable = await PlayFabUtility.ExecuteFunctionAsync<RankTable>("getRankTable",null);
        }
    }
}
