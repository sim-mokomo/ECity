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
        public RankTable RankTable => _rankTable;

        public bool AllLoaded => RankTable != null;

        public void LoadAllTable()
        {
            PlayFabUtility.ExecuteFunction<RankTable>("getRankTable", null, table => { _rankTable = table; });
            //_rankTable = await PlayFabUtility.ExecuteFunctionAsync<RankTable>("getRankTable",null);
        }
    }
}
