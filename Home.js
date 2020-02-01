handlers.updateTimeWhenLeaving = function (args, context) {
    var data = new Date();
    var formatedTime = data.getUTCFullYear() + "_" + (data.getUTCMonth() + 1) + "_" + data.getUTCDate() + "_" + data.getUTCHours() + "_" + data.getUTCMinutes() + "_" + data.getUTCSeconds();
    server.UpdateUserData({
        PlayFabId: currentPlayerId,
        Data: { timeWhenLeaving: formatedTime }
    });
};
