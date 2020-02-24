using System;
using System.Collections;
using System.Collections.Generic;
using MokomoGames.Protobuf;
using UnityEngine;

public class PlayerSaveDataDebugRepository : IPlayerSaveDataRepository
{
    public void GetPlayerSaveData(Action<PlayerSaveData> onEnd)
    {
        onEnd?.Invoke( new PlayerSaveData()
        {
            Coin = 1,
            Mizu = 1,
            Stamina = 1,
            Yukichi = 1,
        });
    }

    public void RecoveryStaminaByWaitTime(Action<RecoveryStaminaByWaitTimeResponse> onEnd)
    {
        onEnd?.Invoke(new RecoveryStaminaByWaitTimeResponse()
        {
            RecoveriedStamina = 2
        });
    }
}
