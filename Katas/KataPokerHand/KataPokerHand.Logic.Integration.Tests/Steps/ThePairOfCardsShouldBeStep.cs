using System.Collections.Generic;
using KataPokerHand.Logic.Integration.Tests.Steps.Common;
using PlayinCards.Interfaces.Decks.Cards;
using TechTalk.SpecFlow;

namespace KataPokerHand.Logic.Integration.Tests.Steps
{
    [Binding]
    public class ThePairOfCardsShouldBeStep
        : BaseStep
    {
        [Then(@"the PairOfCards should be '(.*)'")]
        public void ThenThePairOfCardsShouldBe(string cardsAsString)
        {
            List <ICard> cards = ConvertCardsStringsToList(cardsAsString);

            AssertCards(Info.PairOfCards,
                        cards,
                        "PairOfCards");
        }
    }
}