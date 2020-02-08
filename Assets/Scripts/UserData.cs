using System.Collections;
using System.Collections.Generic;
using PlayFab.ClientModels;
using UnityEngine;

public class UserData
{
    public string PlayFabId { get; private set; }

    public UserData(string playFabId)
    {
        this.PlayFabId = playFabId;
    }
}
