using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using MokomoGames;
using MokomoGames.Protobuf;
using UniRx.Async;
using UnityEngine;
using Zenject;

public class PlayerSaveDataContainer
{
    private PlayerSaveData _playerSaveData;
    private IMasterDataRepository _masterDataRepository;
    private IPlayerSaveDataRepository _playerSaveDataRepository;
    private IEnumerable<UserSoulDataContainer> _userSoulDataContainers;

    public IEnumerable<UserSoulDataContainer> UserSoulDataContainers => _userSoulDataContainers;

    public PlayerSaveDataContainer(IMasterDataRepository masterDataRepository,IPlayerSaveDataRepository playerSaveDataRepository)
    {
        this._masterDataRepository = masterDataRepository;
        this._playerSaveDataRepository = playerSaveDataRepository;
    }

    public async UniTask Load()
    {
        _playerSaveData = await _playerSaveDataRepository.GetPlayerSaveData();
        _userSoulDataContainers = new List<UserSoulDataContainer>();
        var saveSoulDataList = await _playerSaveDataRepository.GetUserSoulDataList();
        _userSoulDataContainers = saveSoulDataList.Souls.Select(x =>
            new UserSoulDataContainer(x, _masterDataRepository, _playerSaveDataRepository));
    }

    public IEnumerable<UserSoulDataContainer> GetMaterialSoul()
    {
        return _userSoulDataContainers
            .Where(x => x.BaseConfig.SoulType.IsMaterial());
    }

    public IEnumerable<UserSoulDataContainer> GetBattleSoul()
    {
        return _userSoulDataContainers
            .Where(x => !x.BaseConfig.SoulType.IsMaterial());
    }

    public bool IsMaxFuel => _playerSaveData.Stamina >= GetMaxFuel();
    public uint Fuel
    {
        get => _playerSaveData.Stamina;
        set => _playerSaveData.Stamina = value;
    }
    
    public uint Rank
    {
        get => _playerSaveData.Rank;
        set => _playerSaveData.Rank = value;
    }
    
    public uint Exp
    {
        get => _playerSaveData.Exp;
        set => _playerSaveData.Exp = value;
    }
    
    public uint Coin
    {
        get => _playerSaveData.Coin;
        set => _playerSaveData.Coin = value;
    }
    
    public uint Mizu
    {
        get => _playerSaveData.Mizu;
        set => _playerSaveData.Mizu = value;
    }
    
    public uint Yukichi
    {
        get => _playerSaveData.Yukichi;
        set => _playerSaveData.Yukichi = value;
    }

    public uint GetNeedNextRankExp()
    {
        var record = _masterDataRepository.RankTable.Records.FirstOrDefault(x => x.Rank == _playerSaveData.Rank);
        return record.NeedNextRankExp;
    }

    public uint GetMaxFuel()
    {
        var record =_masterDataRepository.RankTable.Records.FirstOrDefault(x => x.Rank == _playerSaveData.Rank);
        return record.MaxFuel;
    }
}