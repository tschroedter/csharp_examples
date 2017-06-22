using System.Collections.Generic;
using KataPokerHand.Logic.Integration.Tests.Steps.Common;
using PlayinCards.Interfaces.Decks.Cards;
using TechTalk.SpecFlow;

namespace KataPokerHand.Logic.Integration.Tests.Steps
{
    [Binding]
    public class TheFirstPairOfCardsShouldBeStep
        : BaseStep
    {
        [Then(@"the FirstPairOfCards should be '(.*)'")]
        public void ThenTheFirstPairOfCardsShouldBe(string cardsAsString)
        {
            List <ICard> cards = ConvertCardsStringsToList(cardsAsString);

            AssertCards(Info.FirstPairOfCards,
                        cards,
                        "FirstPairOfCards");
        }
    }
}