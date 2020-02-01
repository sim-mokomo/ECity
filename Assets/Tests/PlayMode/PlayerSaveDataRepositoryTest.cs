using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using MokomoGames;

namespace Tests
{
    public class PlayerSaveDataRepositoryTest
    {
        [UnityTest]
        public IEnumerator PlayerSaveDataRepositoryWithEnumeratorPasses()
        {
            LoginProvider.LoginByEditor(customId:"PlayerSaveDataRepository",
                result =>
                {
                    var playerSaveData = new PlayerSaveData(stamina:100);
                    PlayerSaveDataRepository.UpdatePlayerSaveData(playerSaveData, () =>
                    {
                        var prevSaveData = new PlayerSaveData(stamina: 0);
                       PlayerSaveDataRepository.GetPlayerSaveData(prevSaveData);
                       Assert.Equals(prevSaveData,playerSaveData);
                    });
                },
                error => { });           
            yield return null;
        }
    }
}
