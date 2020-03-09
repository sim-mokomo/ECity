using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Google.Protobuf;
using PlayFab;
using PlayFab.ClientModels;
using MokomoGames.Protobuf;
using PlayFab.CloudScriptModels;using PlayFab.Json;
using UniRx.Async;
using UnityEngine;

namespace MokomoGames
{
    public class PlayerSaveDataRepository : IPlayerSaveDataRepository
    {
        public async UniTask<PlayerSaveData> GetPlayerSaveData()
        {
            var response = await PlayFabUtility.ExecuteFunctionAsync<GetPlayerSaveDataResponse>
            (
                functionName:"getPlayerSaveData",
                functionParameter: null
            );
            return response.SaveData;
        }

        public async UniTask<RecoveryFuelByYukichiResponse> RecoveryFuelByYukichi()
        {
            var response = await PlayFabUtility.ExecuteFunctionAsync<RecoveryFuelByYukichiResponse>
            (
                functionName: "recoveryFuelByYukichi",
                functionParameter: null
            );
            return response;
        }

        public async UniTask<RecoveryStaminaByWaitTimeResponse> RecoveryStaminaByWaitTime()
        {
            var response = await PlayFabUtility.ExecuteFunctionAsync<RecoveryStaminaByWaitTimeResponse>
            (
                functionName: "recoveryStaminaByWaitTime",
                functionParameter: null
            );
            return response;
        }

        public async UniTask<GetUserSoulDataListResponse> GetUserSoulDataList()
        {
            var response = await PlayFabUtility.ExecuteFunctionAsync<GetUserSoulDataListResponse>
            (
                functionName: "getUserSoulDataList",
                functionParameter: null
            );
            return response;
        }
    }
}