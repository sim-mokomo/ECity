using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MokomoGames;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;

public class MainGameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI loginIdText;
    [SerializeField] private HomeScreenController homeScreenController;

    private void Start()
    {
        void OnLoggedIn(LoginResult result)
        {
            loginIdText.text = $"ID:{result.PlayFabId}";
            homeScreenController.Begin();
        }

        void OnError(PlayFabError error)
        {
        }

#if UNITY_EDITOR
        LoginProvider.LoginByEditor(customId: "TestUser1", OnLoggedIn, OnError);
#elif UNITY_ANDROID || UNITY_IPHONE
        LoginProvider.LoginByMobile(OnLoggedIn, OnError);
#endif
    }
}
