"use strict";
exports.__esModule = true;
require("./PlayFab/CloudScript");
var staminaColumnName = "stamina";
handlers.updatePlayerSaveData = function (args, context) {
    var stamina = args[staminaColumnName];
    server.UpdateUserData({
        PlayFabId: currentPlayerId,
        Data: { staminaColumnName: stamina.toString() }
    });
};
handlers.getPlayerSaveData = function (args, context) {
    var res = server.GetUserData({
        PlayFabId: currentPlayerId
    });
    return JSON.stringify(res.Data);
};
