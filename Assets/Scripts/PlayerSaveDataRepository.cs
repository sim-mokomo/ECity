using System;
using System.Collections.Generic;
using System.Linq;
using Google.Protobuf;
using MokomoGames.Protobuf;
using MokomoGames.Users;
using UniRx.Async;
using Zenject;

namespace MokomoGames
{
    public class PlayerSaveDataRepository : IPlayerSaveDataRepository
    {
        [Inject] private IMasterDataRepository _masterDataRepository;

        public async UniTask<User> GetPlayerSaveData()
        {
            var response = await PlayFabUtility.ExecuteFunctionAsync<GetPlayerSaveDataResponse>
            (
                "getPlayerSaveData",
                new Dictionary<string, string>().JsonDictionary(new GetPlayerSaveDataRequest())
            );
            var user = toModel(response.SaveData);
            return user;
        }

        public User toModel(UserData data)
        {
            var rankTableRecord = _masterDataRepository.RankTable.Records.FirstOrDefault(x => x.Rank == data.Rank);
            return new User(data, rankTableRecord.MaxFuel, rankTableRecord.NeedNextRankExp);
        }

        public UserData toData(User user)
        {
            return user.toData();
        }

        public async UniTask<RecoveryFuelByYukichiResponse> RecoveryFuelByYukichi()
        {
            var response = await PlayFabUtility.ExecuteFunctionAsync<RecoveryFuelByYukichiResponse>
            (
                "recoveryFuelByYukichi",
                new Dictionary<string, string>().JsonDictionary(new RecoveryFuelByYukichiRequest())
            );
            return response;
        }

        public async UniTask<RecoveryStaminaByWaitTimeResponse> RecoveryStaminaByWaitTime()
        {
            var response = await PlayFabUtility.ExecuteFunctionAsync<RecoveryStaminaByWaitTimeResponse>
            (
                "recoveryStaminaByWaitTime",
                new Dictionary<string, string>().JsonDictionary(new RecoveryFuelByYukichiRequest())
            );
            return response;
        }

        public async UniTask<GetUserSoulDataListResponse> GetUserSoulDataList()
        {
            var response = await PlayFabUtility.ExecuteFunctionAsync<GetUserSoulDataListResponse>
            (
                "getUserSoulDataList",
                new Dictionary<string, string>().JsonDictionary(new GetUserSoulDataListRequest())
            );
            return response;
        }

        public UniTask<UpdateUserSoulDataFavoriteResponse> UpdateUserSoulDataFavorite(string guid, bool favorite)
        {
            throw new NotImplementedException();
        }
    }
}