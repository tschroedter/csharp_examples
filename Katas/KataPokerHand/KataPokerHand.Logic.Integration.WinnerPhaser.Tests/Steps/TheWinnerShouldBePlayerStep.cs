using System.Collections.Generic;
using KataPokerHand.Logic.Integration.WinnerPhaser.Tests.Steps.Common;
using PlayinCards.Interfaces.Decks.Cards;
using TechTalk.SpecFlow;

namespace KataPokerHand.Logic.Integration.WinnerPhaser.Tests.Steps
{
    [Binding]
    public class TheWinnerShouldBePlayerStep
        : BaseStep
    {
        [Then(@"the winner should be player '(.*)'")]
        public void ThenTheWinnerShouldBePlayer(string playerAsText)
        {
            IEnumerable <ICard> playerCards = Cards [ playerAsText ];
            IEnumerable <ICard> winnerCards = Phaser.WinnerInformation.Cards;

            AssertCards(playerCards,
                        winnerCards,
                        "the winner should be player");
        }
    }
}