const staminaKey = "stamina";

handlers.updatePlayerSaveData = (args, context) => {
    const staminaVal : number = args[staminaKey];
    
    server.UpdateUserData({
        PlayFabId: currentPlayerId,
        Data: {stamina : staminaVal.toString()}
    })
};

handlers.getPlayerSaveData = (args,context) => {
    const res = server.GetUserData({
        PlayFabId: currentPlayerId
    });
    
    const saveData = new PlayerSaveData(
        Number(res.Data[staminaKey].Value)
    );
    return JSON.stringify(saveData);
};

handlers.updateStamina = (args,context) => 
{
    const diff : number = args["diff"];
    const res = server.GetUserData({
        PlayFabId: currentPlayerId
    });
    
    const calcedStamina : number = 
        Number(res.Data[staminaKey].Value) + diff;
    
    server.UpdateUserData({
        PlayFabId: currentPlayerId,
        Data:{stamina: calcedStamina.toString()}
    })
};