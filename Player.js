"use strict";
exports.__esModule = true;
require("./PlayFab/CloudScript");
var PlayerSaveData_1 = require("./PlayerSaveData");
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
    var saveData = new PlayerSaveData_1.PlayerSaveData(Number(res.Data[stamina].Value));
    return JSON.stringify(saveData);
};
