var stamina = "stamina";
handlers.updatePlayerSaveData = function (args, context) {
    var staminaVal = args[stamina];
    server.UpdateUserData({
        PlayFabId: currentPlayerId,
        Data: { stamina: staminaVal.toString() }
    });
};
handlers.getPlayerSaveData = function (args, context) {
    var res = server.GetUserData({
        PlayFabId: currentPlayerId
    });
    var saveData = new PlayerSaveData(Number(res.Data[stamina].Value));
    return JSON.stringify(saveData);
};
handlers.updateStamina = function (args, context) {
    var diff = args["diff"];
    var res = server.GetUserData({
        PlayFabId: currentPlayerId
    });
    var calcedStamina = Number(res.Data["stamina"].Value) + diff;
    server.UpdateUserData({
        PlayFabId: currentPlayerId,
        Data: { stamina: calcedStamina.toString() }
    });
};
