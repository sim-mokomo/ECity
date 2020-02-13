"use strict";
exports.__esModule = true;
var UserData_pb_1 = require("./protos/src/UserData_pb");
var staminaKey = "stamina";
var chipKey = "chip";
handlers.updatePlayerSaveData = function (args, context) {
    var staminaVal = args[staminaKey];
    server.UpdateUserData({
        PlayFabId: currentPlayerId,
        Data: { stamina: staminaVal.toString() }
    });
};
handlers.getPlayerSaveData = function (args, context) {
    var res = server.GetUserData({ PlayFabId: currentPlayerId });
    var saveData = new UserData_pb_1.PlayerSaveData();
    saveData.setStamina(Number(res.Data[staminaKey].Value));
    var response = new UserData_pb_1.GetPlayerSaveDataResponse();
    response.setSavedata(saveData);
    return response.serializeBinary();
};
handlers.updateStamina = function (args, context) {
    var request = UserData_pb_1.UpdateStaminaRequest.deserializeBinary(args);
    var currentStamina = updateNumberElement(staminaKey, request.getDiff(), currentPlayerId);
    var response = new UserData_pb_1.UpdateStaminaResponse();
    response.setCurrentstamina(currentStamina);
    return response.serializeBinary();
};
handlers.updateChip = function (args, context) {
    var diff = args["diff"];
    updateNumberElement(chipKey, diff, currentPlayerId);
};
function updateNumberElement(key, diff, playfabId) {
    var res = server.GetUserData({
        PlayFabId: playfabId
    });
    var data;
    var resValue = res.Data[key] == null ? diff : Number(res.Data[key].Value) + diff;
    data[key] = resValue;
    server.UpdateUserData({ PlayFabId: playfabId, Data: data });
    return resValue;
}
