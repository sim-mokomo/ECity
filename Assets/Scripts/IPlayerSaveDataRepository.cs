using System;
using System.Collections;
using System.Collections.Generic;
using MokomoGames.Protobuf;
using UnityEngine;

public interface IPlayerSaveDataRepository
{
    void GetPlayerSaveData(Action<PlayerSaveData> onEnd);
    void RecoveryStaminaByWaitTime(Action<RecoveryStaminaByWaitTimeResponse> onEnd);
}
