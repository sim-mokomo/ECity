using System;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;


namespace MokomoGames
{
    public class PlayerSaveDataRepository
    {
        public static void UpdatePlayerSaveData(PlayerSaveData playerSaveData,Action onEndUpdate)
        {
            var saveDic = playerSaveData.ToSaveDic();
            PlayFabClientAPI.ExecuteCloudScript(
                new ExecuteCloudScriptRequest()
                {
                    FunctionName = "updatePlayerSaveData",
                    FunctionParameter = saveDic,
                    GeneratePlayStreamEvent = true,
                },
                result => { onEndUpdate?.Invoke(); },
                error => { });
        }
        
        public static void GetPlayerSaveData(PlayerSaveData playerSaveData,Action<PlayerSaveData> onEndGetSaveData)
        {
            PlayFabClientAPI.ExecuteCloudScript
            (
                new ExecuteCloudScriptRequest()
                {
                    FunctionName = "getPlayerSaveData",
                    GeneratePlayStreamEvent = true,
                },
                scriptResult =>
                {
                    JsonUtilityExtensions.FunctionResult2Instance<PlayerSaveData>(scriptResult.FunctionResult,playerSaveData);
                    onEndGetSaveData?.Invoke(playerSaveData);
                },
                error => { }
            );
        }

        public static void UpdateStamina(int diff,Action onEndUpdate)
        {
            PlayFabClientAPI.ExecuteCloudScript(
                new ExecuteCloudScriptRequest()
                {
                    FunctionName = "updateStamina",
                    FunctionParameter = new Dictionary<string,int>(){{"diff",diff}},
                    GeneratePlayStreamEvent = true,
                },
                result => { onEndUpdate?.Invoke(); },
                error => { });
        }
    }
}
