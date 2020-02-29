using PlayFab;
using PlayFab.Plugins.CloudScript;

namespace MokomoGames
{
    public static class FunctionContextExtension
    {
        public static void PreparePlayFabAPI(this FunctionContext<dynamic> context)
        {
            PlayFabSettings.staticSettings.DeveloperSecretKey = context.ApiSettings.DeveloperSecretKey;
            PlayFabSettings.staticSettings.TitleId = context.ApiSettings.TitleId;
        }
    }
}