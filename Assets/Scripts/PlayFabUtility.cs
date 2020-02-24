using System;
using System.Collections.Generic;
using Google.Protobuf;
using UnityEngine;
using PlayFab;
using PlayFab.CloudScriptModels;

namespace MokomoGames
{
    public class PlayFabUtility
    {
        public static PlayFab.CloudScriptModels.EntityKey CreateEntityKey()
        {
            return new PlayFab.CloudScriptModels.EntityKey()
            {
                Id = MainGameController.UserDataContainer.PlayFabAuthenticationContext.EntityId,
                Type = MainGameController.UserDataContainer.PlayFabAuthenticationContext.EntityType
            };
        }

        public static void ExecuteFunction<T>(string functionName, Dictionary<string, string> functionParameter,Action<T> callBack) where T : IMessage<T>,new()
        {
            PlayFabCloudScriptAPI.ExecuteFunction(
                new ExecuteFunctionRequest()
                {
                    Entity = CreateEntityKey(),
                    FunctionName = functionName,
                    FunctionParameter = functionParameter,
                    GeneratePlayStreamEvent = true
                },
                result =>
                {
                    var json = result.FunctionResult.ToString();
                    Debug.Log(json);
                    var parser = new MessageParser<T>( () => new T());
                    var response = parser.ParseJson(json);
                    callBack?.Invoke(response);
                },
                GenerateErrorReport);
        }
        
        public static void GenerateErrorReport(PlayFabError error)
        {
            Debug.Log($"Opps Something went wrong: {error.GenerateErrorReport()}");
            Debug.Log(error.HttpCode);
            Debug.Log(error.HttpStatus);
            if(error.ErrorDetails == null)
                return;
            foreach (var detail in error.ErrorDetails)
            {
                Debug.Log($"{detail.Key}/{detail.Value}");
            }
        }
    }
}