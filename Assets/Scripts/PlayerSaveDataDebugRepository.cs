using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MokomoGames;
using MokomoGames.Protobuf;
using UniRx.Async;
using UnityEngine;
using Zenject;

public class PlayerSaveDataDebugRepository : IPlayerSaveDataRepository
{
    [Inject] private IMasterDataRepository _masterDataRepository;
    [Inject] private IPlayerSaveDataRepository _playerSaveDataRepository;

    public UniTask<PlayerSaveData> GetPlayerSaveData()
    {
        return new UniTask<PlayerSaveData>(new PlayerSaveData()
        {
            Coin = 100,
            Mizu = 56,
            Stamina = 10,
            Yukichi = 2,
            Exp = 6,
            Rank = 1
        });
    }

    public UniTask<RecoveryFuelByYukichiResponse> RecoveryFuelByYukichi()
    {
        return new UniTask<RecoveryFuelByYukichiResponse>(new RecoveryFuelByYukichiResponse()
        {
            Fuel = 100,
        });
    }

    public UniTask<RecoveryStaminaByWaitTimeResponse> RecoveryStaminaByWaitTime()
    {
        return new UniTask<RecoveryStaminaByWaitTimeResponse>(new RecoveryStaminaByWaitTimeResponse()
        {
            RecoveriedStamina = 1
        });
    }

    public UniTask<GetUserSoulDataListResponse> GetUserSoulDataList()
    {
        var soulList = _masterDataRepository.SoulTable.Records.Select(x => new UserSoulData()
        {
            Guid = Guid.NewGuid().ToString(),
            SoulNo = x.No,
            TotalLevelExp = 1,
            TotalSkillExp = 1,
        });
        return new UniTask<GetUserSoulDataListResponse>(new GetUserSoulDataListResponse(){Souls = { soulList}});
    }

    public UniTask<UpdateUserSoulDataFavoriteResponse> UpdateUserSoulDataFavorite(string guid,bool favorite)
    {
        favorite = !favorite;
        return new UniTask<UpdateUserSoulDataFavoriteResponse>(new UpdateUserSoulDataFavoriteResponse(){Favorite = favorite});
    }
}
