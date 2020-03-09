using System;
using System.Collections;
using System.Collections.Generic;
using MokomoGames.Protobuf;
using UniRx.Async;
using UnityEngine;

public interface IPlayerSaveDataRepository
{
    UniTask<PlayerSaveData> GetPlayerSaveData();
    UniTask<RecoveryFuelByYukichiResponse> RecoveryFuelByYukichi();
    UniTask<RecoveryStaminaByWaitTimeResponse> RecoveryStaminaByWaitTime();
    UniTask<GetUserSoulDataListResponse> GetUserSoulDataList();
}
