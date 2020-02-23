using UnityEngine;
using PlayFab;

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