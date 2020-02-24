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
            PlayFabUtility.ExecuteFunction<GetPlayerSaveDataResponse>(
                functionName: "getPlayerSaveData",
                functionParameter: null,
                callBack: response => { onEndGetSaveData?.Invoke(response.SaveData); });
        }
    }
}