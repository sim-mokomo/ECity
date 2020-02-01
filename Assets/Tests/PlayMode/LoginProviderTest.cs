using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using MokomoGames;

namespace Tests
{
    public class LoginProviderTest
    {
        [UnityTest]
        public IEnumerator LoginProviderTestWithEnumeratorPasses()
        {
            LoginProvider.LoginByEditor(customId: "LoginProviderTest",
                result =>
                {
                    Assert.IsNotNull(result);
                },
                error => { });
            yield return null;
        }
    }
}
