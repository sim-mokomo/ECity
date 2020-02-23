using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class UserDataContainer
{
    public string PlayFabId { get; }
    public PlayFabAuthenticationContext PlayFabAuthenticationContext { get; }

    public UserDataContainer(string playFabId,PlayFabAuthenticationContext playFabAuthenticationContext = null)
    {
        PlayFabId = playFabId;
        PlayFabAuthenticationContext = playFabAuthenticationContext;
    }
}
