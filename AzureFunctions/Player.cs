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
    public static class Player
    {
        public static string CurrentPlayerId(FunctionContext<dynamic> context)
        {
            return context.CallerEntityProfile.Lineage.MasterPlayerAccountId;
        }

        [FunctionName("getPlayerSaveData")]
        public static async Task<dynamic> GetPlayerSaveData(
            [HttpTrigger(AuthorizationLevel.Function,"get", "post", Route = null)] HttpRequestMessage req,
            ILogger log)
        {
            var context = await FunctionContext<dynamic>.Create(req);
            var args = context.FunctionArgument;
            context.PreparePlayFabAPI();
            
            var userDataResponse = await PlayFabServerAPI.GetUserDataAsync(new GetUserDataRequest()
            {
                PlayFabId = CurrentPlayerId(context),
                Keys = new List<string>()
                {
                    "stamina",
                    "yukichi",
                    "coin",
                    "mizu",
                    "rank",
                    "exp"
                }
            });
            var userDataResponseDic = userDataResponse.Result.Data;

            var rankValue = userDataResponseDic.ContainsKey("rank") ? uint.Parse(userDataResponseDic["rank"].Value) : 0;
            var rankTable = await GetRankTableInstanceAsync();
            var rankRecord = rankTable.Records.FirstOrDefault(x => x.Rank == rankValue);

            var staminaValue = userDataResponseDic.ContainsKey("stamina") ? uint.Parse(userDataResponseDic["stamina"].Value) : rankRecord.MaxFuel;
            var yukichiValue = userDataResponseDic.ContainsKey("yukichi") ? uint.Parse(userDataResponseDic["yukichi"].Value) : 0;
            var coinValue = userDataResponseDic.ContainsKey("coin") ? uint.Parse(userDataResponseDic["coin"].Value) : 0;
            var mizuValue = userDataResponseDic.ContainsKey("mizu") ? uint.Parse(userDataResponseDic["mizu"].Value) : 0;
            var expValue = userDataResponseDic.ContainsKey("exp") ? uint.Parse(userDataResponseDic["exp"].Value) : 0;

            var playerSaveData = new PlayerSaveData()
            {
                Stamina = staminaValue,
                Coin = coinValue,
                Mizu = mizuValue,
                Rank = rankValue,
                Yukichi = yukichiValue,
                Exp = expValue,
            };

            var saveDataResponse = new GetPlayerSaveDataResponse()
            {
                SaveData = playerSaveData
            };
            return JsonFormatter.Default.Format(saveDataResponse);
        }

        const UInt32 RecoveriedStaminaValuePerTime = 1u; 

        [FunctionName("recoveryStaminaByWaitTime")]
        public static async Task<dynamic> RecoveryStaminaByWaitTime(
            [HttpTrigger(AuthorizationLevel.Function,"get", "post", Route = null)] HttpRequestMessage req,
            ILogger log)
        {
            var context = await FunctionContext<dynamic>.Create(req);
            var args = context.FunctionArgument;
            context.PreparePlayFabAPI();
            
            string json = args["json"];
            var request = RecoveryStaminaByWaitTimeRequest.Parser.ParseJson(json);
            if(request == null)
            {
                return null;
            }

            var currentPlayerId = CurrentPlayerId(context);
            var saveData = await GetUserDataElement<PlayerSaveData>(currentPlayerId);
            saveData.Stamina += RecoveriedStaminaValuePerTime;
            await UpdateUserDataElement<PlayerSaveData>(currentPlayerId,saveData);

            var retResponse = new RecoveryStaminaByWaitTimeResponse()
            {
                RecoveriedStamina = saveData.Stamina
            };
            
            return JsonFormatter.Default.Format(retResponse);
        }

        public static async Task<T> GetUserDataElement<T>(string masterPlayerAccountId) where T :class,IMessage<T>,new()
        {
            var getUserDataRequest = new GetUserDataRequest()
            {
                PlayFabId = masterPlayerAccountId
            };
            var userDataResponse = await PlayFabServerAPI.GetUserDataAsync(getUserDataRequest);

            var key = typeof(T).ToString();
            if(!userDataResponse.Result.Data.ContainsKey(key))
            {
                return null;
            }

            var classValue = userDataResponse.Result.Data[key];
            var json = classValue.Value;
            var parser = new MessageParser<T>(()=> new T());
            var instance = parser.ParseJson(json);
            return instance;
        }

        public static async Task UpdateUserDataElement<T>(string masterPlayerAccountId,T obj) where T :class,IMessage<T>,new()
        {
            var updateUserDataRequest = new UpdateUserDataRequest()
            {
                PlayFabId = masterPlayerAccountId,
                Data = new Dictionary<string, string>
                {
                    {typeof(T).ToString(),JsonFormatter.Default.Format(obj)}
                }
            };
            var userDataResponse = await PlayFabServerAPI.UpdateUserDataAsync(updateUserDataRequest);
        }

        [FunctionName("recoveryFuelByYukichi")]
        public static async Task<dynamic> RecoveryFuelByYukichi(
            [HttpTrigger(AuthorizationLevel.Function,"get", "post", Route = null)] HttpRequestMessage req,
            ILogger log)
        {
            var context = await FunctionContext<dynamic>.Create(req);
            var args = context.FunctionArgument;
            context.PreparePlayFabAPI();

            var rankTable = await GetRankTableInstanceAsync();
            var playerId = CurrentPlayerId(context);
            var saveData = await GetUserDataElement<PlayerSaveData>(playerId);
            saveData.Stamina += rankTable.Records.FirstOrDefault(x => x.Rank == saveData.Rank).MaxFuel;
            saveData.Yukichi--;
            await UpdateUserDataElement<PlayerSaveData>(playerId,saveData);

            var response = new RecoveryFuelByYukichiResponse()
            {
                Fuel = saveData.Stamina
            };
            return JsonFormatter.Default.Format(response);
        }
        

        [FunctionName("getRankTable")]
        public static async Task<dynamic> GetRankTable(
            [HttpTrigger(AuthorizationLevel.Function,"get", "post", Route = null)] HttpRequestMessage req,
            ILogger log)
        {
            var context = await FunctionContext<dynamic>.Create(req);
            var args = context.FunctionArgument;

            InitializePlayFabSettings(context);
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
