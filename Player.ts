import "./PlayFab/CloudScript"
const staminaColumnName : string = "stamina";

handlers.updatePlayerSaveData = (args, context) => {
    const stamina : number = args[staminaColumnName];
    
    server.UpdateUserData({
        PlayFabId: currentPlayerId,
        Data: {staminaColumnName : stamina.toString()}
    })
};

handlers.getPlayerSaveData = (args,context) => {
    const res = server.GetUserData({
        PlayFabId: currentPlayerId
    });
    
    return JSON.stringify(res.Data);
};