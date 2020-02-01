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
                    var saveData = new PlayerSaveData(stamina:100);
                    PlayerSaveDataRepository.UpdatePlayerSaveData(saveData, () =>
                    {
                       PlayerSaveDataRepository.GetPlayerSaveData(PlayerSaveData.Empty, gotSaveData =>
                       {
                            Assert.Equals(saveData,gotSaveData);
                       });
                    });
                },
                error => { });           
            yield return null;
        }
    }
}
