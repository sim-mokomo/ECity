import {
        UpdateStaminaRequest,
        UpdateStaminaResponse,
        GetPlayerSaveDataResponse,
        PlayerSaveData
} from "./protos/src/UserData_pb";


const staminaKey = "stamina";
const chipKey = "chip";

handlers.updatePlayerSaveData = (args, context) => {
    const staminaVal : number = args[staminaKey];
    
    server.UpdateUserData({
        PlayFabId: currentPlayerId,
        Data: {stamina : staminaVal.toString()}
    })
};

handlers.getPlayerSaveData = (args,context) => {
    const res = server.GetUserData({PlayFabId: currentPlayerId});
    
    const saveData = new PlayerSaveData();
    saveData.setStamina(Number(res.Data[staminaKey].Value));
    
    const response = new GetPlayerSaveDataResponse();
    response.setSavedata(saveData);
    
    return response.serializeBinary();
};

handlers.updateStamina = (args,context) => 
{
    const request = UpdateStaminaRequest.deserializeBinary(args);
    const currentStamina = updateNumberElement(staminaKey,request.getDiff(),currentPlayerId);
    const response = new UpdateStaminaResponse();
    response.setCurrentstamina(currentStamina);
    return response.serializeBinary();
};

handlers.updateChip = (args,context) => 
{
    const diff : number = args["diff"];
    updateNumberElement(chipKey,diff,currentPlayerId)
};

function updateNumberElement(key:string,diff:number,playfabId:string) : number{
    const res = server.GetUserData({
        PlayFabId: playfabId
    });
    
    let data: { [index: number]: string; };
    const resValue : number = res.Data[key] == null ? diff : Number(res.Data[key].Value) + diff;
    data[key] = resValue;
    server.UpdateUserData({PlayFabId:playfabId ,Data: data});
    
    return resValue;
}