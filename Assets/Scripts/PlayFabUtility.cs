using System;
using System.Collections.Generic;
using Google.Protobuf;
using PlayFab;
using PlayFab.CloudScriptModels;
using UniRx.Async;
using UnityEngine;

namespace MokomoGames
{
    public class PlayFabUtility
    {
        private static EntityKey CreateEntityKey()
        {
            return new EntityKey
            {
                Id = MainGameController.UserDataContainer.PlayFabAuthenticationContext.EntityId,
                Type = MainGameController.UserDataContainer.PlayFabAuthenticationContext.EntityType
            };
        }

        public static void ExecuteFunction<T>(string functionName, Dictionary<string, string> functionParameter,
            Action<T> callBack) where T : IMessage<T>, new()
        {
            PlayFabCloudScriptAPI.ExecuteFunction(
                new ExecuteFunctionRequest
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
                    var parser = new MessageParser<T>(() => new T());
                    var response = parser.ParseJson(json);
                    callBack?.Invoke(response);
                },
                GenerateErrorReport);
        }

        public static UniTask<T> ExecuteFunctionAsync<T>(string functionName,
            Dictionary<string, string> functionParameter) where T : IMessage<T>, new()
        {
            var taskCompletionSource = new UniTaskCompletionSource<T>();
            ExecuteFunction<T>(functionName, functionParameter,
                message => { taskCompletionSource.TrySetResult(message); });
            return taskCompletionSource.Task;
        }

        private static void GenerateErrorReport(PlayFabError error)
        {
            Debug.Log($"Opps Something went wrong: {error.GenerateErrorReport()}");
            Debug.Log(error.HttpCode);
            Debug.Log(error.HttpStatus);
            if (error.ErrorDetails == null)
                return;
            foreach (var detail in error.ErrorDetails) Debug.Log($"{detail.Key}/{detail.Value}");
        }
    }
}