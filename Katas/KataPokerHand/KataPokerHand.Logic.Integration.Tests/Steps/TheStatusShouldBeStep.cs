using System;
using KataPokerHand.Logic.Integration.Tests.Steps.Common;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace KataPokerHand.Logic.Integration.Tests.Steps
{
    [Binding]
    public class TheStatusShouldBeStep
        : BaseStep
    {
        [Then(@"the status should be '(.*)'")]
        public void ThenTheStatusShouldBe(string statusAsString)
        {
            var info = ( IPlayerHandInformation ) ScenarioContext.Current [ "IPlayerHandInformation" ];

            var expected = ( Status ) Enum.Parse(typeof( Status ),
                                                 statusAsString);

            Assert.AreEqual(expected,
                            info.Status);
        }
    }
}