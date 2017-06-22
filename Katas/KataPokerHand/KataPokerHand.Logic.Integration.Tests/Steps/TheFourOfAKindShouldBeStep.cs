using System.Collections.Generic;
using KataPokerHand.Logic.Integration.Tests.Steps.Common;
using PlayinCards.Interfaces.Decks.Cards;
using TechTalk.SpecFlow;

namespace KataPokerHand.Logic.Integration.Tests.Steps
{
    [Binding]
    public class TheFourOfAKindShouldBeStep
        : BaseStep
    {
        [Then(@"the FourOfAKind should be '(.*)'")]
        public void ThenTheFourOfAKindShouldBe(string cardsAsString)
        {
            List <ICard> cards = ConvertCardsStringsToList(cardsAsString);

            AssertCards(Info.FourOfAKind,
                        cards,
                        "FourOfAKind");
        }
    }
}