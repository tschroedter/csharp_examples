using System;
using KataPokerHand.Logic.Integration.WinnerPhaser.Tests.Steps.Common;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace KataPokerHand.Logic.Integration.WinnerPhaser.Tests.Steps
{
    [Binding]
    public class TheWinnerShouldHaveWonWithAStep
        : BaseStep
    {
        [Then(@"the winner should have won with status '(.*)'")]
        public void ThenTheWinnerShouldHaveWonWithA(string statusAsText)
        {
            var status = ( Status ) Enum.Parse(typeof( Status ),
                                               statusAsText);

            Assert.AreEqual(status,
                            Phaser.WinnerInformation.Status);
        }
    }
}