using MokomoGames.Protobuf;
using MokomoGames.Users;
using UniRx.Async;

public interface IPlayerSaveDataRepository
{
    UniTask<User> GetPlayerSaveData();
    User toModel(UserData data);
    UserData toData(User user);

    UniTask<RecoveryFuelByYukichiResponse> RecoveryFuelByYukichi();
    UniTask<RecoveryStaminaByWaitTimeResponse> RecoveryStaminaByWaitTime();
    UniTask<GetUserSoulDataListResponse> GetUserSoulDataList();
    UniTask<UpdateUserSoulDataFavoriteResponse> UpdateUserSoulDataFavorite(string guid, bool favorite);
}