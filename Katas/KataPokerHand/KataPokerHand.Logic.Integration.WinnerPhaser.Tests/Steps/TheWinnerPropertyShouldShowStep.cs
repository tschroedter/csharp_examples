using System;
using KataPokerHand.Logic.Integration.WinnerPhaser.Tests.Steps.Common;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Ranking;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace KataPokerHand.Logic.Integration.WinnerPhaser.Tests.Steps
{
    [Binding]
    public class TheWinnerPropertyShouldShowStep
        : BaseStep
    {
        [Then(@"the winner property should show '(.*)'")]
        public void ThenTheWinnerPropertyShouldShow(string winnerStatusAsText)
        {
            var status = ( WinnerStatus ) Enum.Parse(typeof( WinnerStatus ),
                                                     winnerStatusAsText);

            Assert.AreEqual(status,
                            Phaser.Winner);
        }
    }
}