import "./PlayFab/CloudScript"
import {PlayerSaveData} from "./PlayerSaveData";

const stamina : string = "stamina";

handlers.updatePlayerSaveData = (args, context) => {
    const staminaVal : number = args[stamina];
    
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
        Number(res.Data[stamina].Value)
    );
    return JSON.stringify(saveData);
};