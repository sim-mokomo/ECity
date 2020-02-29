using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PlayFab;
using PlayFab.Plugins.CloudScript;
using PlayFab.ServerModels;
using PlayFab.ProfilesModels;
using MokomoGames.Protobuf;
using Google.Protobuf;

namespace MokomoGames.Function
{
    public static class MasterData
    {
        [FunctionName("getRankTable")]
        public static async Task<dynamic> GetRankTable(
            [HttpTrigger(AuthorizationLevel.Function,"get", "post", Route = null)] HttpRequestMessage req,
            ILogger log)
        {
            var context = await FunctionContext<dynamic>.Create(req);
            var args = context.FunctionArgument;
            context.PreparePlayFabAPI();

            var titleDataResponse = await PlayFabServerAPI.GetTitleDataAsync(new GetTitleDataRequest());
            var json = titleDataResponse.Result.Data["RankTable"];
            log.LogInformation(json);
            return json;
        }

        public static async Task<RankTable> GetRankTableInstanceAsync()
        {
            var titleDataRequest = await PlayFabServerAPI.GetTitleDataAsync(new GetTitleDataRequest());
            var rankTable = RankTable.Parser.ParseJson(titleDataRequest.Result.Data["RankTable"]);
            return rankTable;
        }
    }
}
