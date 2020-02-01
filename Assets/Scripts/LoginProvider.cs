using System;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

namespace MokomoGames
{
    public class LoginProvider
    {
        public static void LoginByEditor(string customId,Action<LoginResult> onLoggedIn, Action<PlayFabError> onError = null)
        {
            PlayFabClientAPI.ForgetAllCredentials ();
            var loginRequest = new LoginWithCustomIDRequest
            {
                CustomId = customId,
                CreateAccount = true,
            };
            PlayFabClientAPI.LoginWithCustomID (loginRequest, onLoggedIn, onError);
        }

        public static void LoginByMobile (Action<LoginResult> onLoggedIn, Action<PlayFabError> onError = null)
        {
    #if UNITY_ANDROID
            AndroidJavaClass clsUnity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
            AndroidJavaObject objActivity = clsUnity.GetStatic<AndroidJavaObject> ("currentActivity");
            AndroidJavaObject objResolver = objActivity.Call<AndroidJavaObject> ("getContentResolver");
            AndroidJavaClass clsSecure = new AndroidJavaClass ("android.provider.Settings$Secure");
            var android_id = clsSecure.CallStatic<string> ("getString", objResolver, "android_id");
            var loginRequest = new LoginWithAndroidDeviceIDRequest
            {
                AndroidDeviceId = android_id,
                CreateAccount = true,
            };
            PlayFabClientAPI.LoginWithAndroidDeviceID (loginRequest, OnLoggedIn, OnError);
    #elif UNITY_IPHONE
            var loginRequest = new LoginWithIOSDeviceIDRequest
            {
                DeviceId = UnityEngine.iOS.Device.vendorIdentifier,
                CreateAccount = true,
            };
            PlayFabClientAPI.LoginWithIOSDeviceID (loginRequest, OnLoggedIn, OnError);
    #endif
        }
    }
}
