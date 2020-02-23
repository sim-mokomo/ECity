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

        public static void InitializePlayFabSettings(FunctionContext<dynamic> context)
        {
            PlayFabSettings.staticSettings.DeveloperSecretKey = context.ApiSettings.DeveloperSecretKey;
            PlayFabSettings.staticSettings.TitleId = context.ApiSettings.TitleId;
        }

        [FunctionName("getPlayerSaveData")]
        public static async Task<dynamic> GetPlayerSaveData(
            [HttpTrigger(AuthorizationLevel.Function,"get", "post", Route = null)] HttpRequestMessage req,
            ILogger log)
        {
            var context = await FunctionContext<dynamic>.Create(req);
            var args = context.FunctionArgument;

            InitializePlayFabSettings(context);
            
            {
                PlayFabId = context.CallerEntityProfile.Lineage.MasterPlayerAccountId,
            };

            var userDataResponse = await PlayFabServerAPI.GetUserDataAsync(getUserDataRequest);
            var saveDataResponse = new GetPlayerSaveDataResponse()
            {
                Stamina = uint.Parse(userDataResponse.Result.Data["stamina"].Value)
            };

            return JsonFormatter.Default.Format(saveDataResponse);
        }

        public static async Task<T> GetUserDataElement<T>(string masterPlayerAccountId) where T :class,IMessage<T>,new()
        {
            var getUserDataRequest = new GetUserDataRequest()
            {
                PlayFabId = masterPlayerAccountId
            };
            var userDataResponse = await PlayFabServerAPI.GetUserDataAsync(getUserDataRequest);
            var classValue = userDataResponse.Result.Data[typeof(T).ToString()];
            if(classValue != null)
            {
                var json = classValue.Value;
                var parser = new MessageParser<T>(()=> new T());
                var instance = parser.ParseJson(json);
                return instance;
            }
            return null;
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

        
    }

}
