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
    private MasterSequencer masterSequencer;
    public static UserData UserData { get; private set; }

    private void Start()
    {
        masterSequencer = FindObjectOfType<MasterSequencer>();
        masterSequencer.AllDisplay(false);

        void OnLoggedIn(LoginResult result)
        {
            UserData = new UserData(result.PlayFabId);
        }

        void OnError(PlayFabError error)
        {
        }

#if UNITY_EDITOR
        LoginProvider.LoginByEditor(customId: "TestUser1", OnLoggedIn, OnError);
#elif UNITY_ANDROID || UNITY_IPHONE
        LoginProvider.LoginByMobile(OnLoggedIn, OnError);
#endif
        masterSequencer.ChangeSequenceWithLoading(
            () => UserData != null,
            MasterSequencer.SequencerType.Title);
    }

    private void Update()
    {
        masterSequencer.Tick();
    }
}