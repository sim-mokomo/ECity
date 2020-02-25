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
            Coin = 100,
            Mizu = 56,
            Stamina = 10,
            Yukichi = 2,
            Exp = 6,
            Rank = 1
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
