using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Google.Protobuf;
using PlayFab;
using PlayFab.ClientModels;
using MokomoGames.Protobuf;
using PlayFab.CloudScriptModels;
using PlayFab.Json;
using UnityEngine;

namespace MokomoGames
{
    public class PlayerSaveDataRepository
    {
        public static void GetPlayerSaveData(Action<PlayerSaveData> onEndGetSaveData)
        {
            PlayFabCloudScriptAPI.ExecuteFunction(
                new ExecuteFunctionRequest()
                {
                    Entity = PlayFabUtility.CreateEntityKey(),
                    FunctionName = "getPlayerSaveData",
                    FunctionParameter = null,
                    GeneratePlayStreamEvent = true
                },
                result =>
                {
                    Debug.Log(result.FunctionResult.ToString());
                    var response = GetPlayerSaveDataResponse.Parser.ParseJson(result.FunctionResult.ToString());
                    onEndGetSaveData?.Invoke(response.SaveData);
                },
                PlayFabUtility.GenerateErrorReport);
        }
    }
}