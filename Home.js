handlers.updateTimeWhenLeaving = function (args, context) {
    var data = new Date();
    var formatedTime = data.getFullYear() + "_" + (data.getMonth() + 1) + "_" + data.getDate() + "_" + data.getHours() + "_" + data.getMinutes() + "_" + data.getSeconds();
    server.UpdateUserData({
        PlayFabId: currentPlayerId,
        Data: { timeWhenLeaving: formatedTime }
    });
};
