using System.Collections.Generic;
using KataPokerHand.Logic.Integration.Tests.Steps.Common;
using PlayinCards.Interfaces.Decks.Cards;
using TechTalk.SpecFlow;

namespace KataPokerHand.Logic.Integration.Tests.Steps
{
    [Binding]
    public class TheSecondPairOfCardsShouldBeStep
        : BaseStep
    {
        [Then(@"the SecondPairOfCards should be '(.*)'")]
        public void ThenTheSecondPairOfCardsShouldBe(string cardsAsString)
        {
            List <ICard> cards = ConvertCardsStringsToList(cardsAsString);

            AssertCards(Info.SecondPairOfCards,
                        cards,
                        "SecondPairOfCards");
        }
    }
}