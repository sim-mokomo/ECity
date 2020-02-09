var staminaKey = "stamina";
var chipColumnName = "chip";
handlers.updatePlayerSaveData = function (args, context) {
    var staminaVal = args[staminaKey];
    server.UpdateUserData({
        PlayFabId: currentPlayerId,
        Data: { stamina: staminaVal.toString() }
    });
};
handlers.getPlayerSaveData = function (args, context) {
    var res = server.GetUserData({
        PlayFabId: currentPlayerId
    });
    var saveData = new PlayerSaveData(Number(res.Data[staminaKey].Value));
    return JSON.stringify(saveData);
};
handlers.updateStamina = function (args, context) {
    var diff = args["diff"];
    var res = server.GetUserData({
        PlayFabId: currentPlayerId
    });
    var calcedStamina = Number(res.Data[staminaKey].Value) + diff;
    server.UpdateUserData({
        PlayFabId: currentPlayerId,
        Data: { stamina: calcedStamina.toString() }
    });
};
