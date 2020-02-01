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
    private LoginResult loginResult = null;

    private void Start()
    {
        void OnLoggedIn(LoginResult result)
        {
            loginResult = result;
            loginIdText.text = $"ID:{result.PlayFabId}";
            StartCoroutine(LoginSequence());
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

    private IEnumerator LoginSequence()
    {
        while (loginResult == null)
        {
            yield return null;
        }
    }
}
