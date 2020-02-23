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
        [FunctionName("getPlayerSaveData")]
        public static async Task<dynamic> GetPlayerSaveData(
            [HttpTrigger(AuthorizationLevel.Function,"get", "post", Route = null)] HttpRequestMessage req,
            ILogger log)
        {
            var context = await FunctionContext<dynamic>.Create(req);

            var args = context.FunctionArgument;

            PlayFabSettings.staticSettings.DeveloperSecretKey = context.ApiSettings.DeveloperSecretKey;
            PlayFabSettings.staticSettings.TitleId = context.ApiSettings.TitleId;
            
            var getUserDataRequest = new GetUserDataRequest()
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
    }

}
