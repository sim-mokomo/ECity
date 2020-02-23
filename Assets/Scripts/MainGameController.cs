using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Google.Protobuf;
using UnityEngine;
using MokomoGames;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using MokomoGames.Protobuf;

public class MainGameController : MonoBehaviour
{
    private MasterSequencer masterSequencer;
    public static UserDataContainer UserDataContainer { get; private set; }

    private void Start()
    {
        masterSequencer = FindObjectOfType<MasterSequencer>();
        masterSequencer.AllDisplay(false);

        void OnLoggedIn(LoginResult result)
        {
            UserDataContainer = new UserDataContainer(result.PlayFabId,result.AuthenticationContext);
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
            () => UserDataContainer != null,
            MasterSequencer.SequencerType.Title);
    }

    private void Update()
    {
        masterSequencer.Tick();
    }
}