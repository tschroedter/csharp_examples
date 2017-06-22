using System.Collections.Generic;
using KataPokerHand.Logic.Integration.Tests.Steps.Common;
using PlayinCards.Interfaces.Decks.Cards;
using TechTalk.SpecFlow;

namespace KataPokerHand.Logic.Integration.Tests.Steps
{
    [Binding]
    public class TheTwoOfAKindShouldBeStep
        : BaseStep
    {
        [Then(@"the TwoOfAkind should be '(.*)'")]
        public void ThenTheTwoOfAkindShouldBe(string cardsAsString)
        {
            List <ICard> cards = ConvertCardsStringsToList(cardsAsString);

            AssertCards(Info.TwoOfAKind,
                        cards,
                        "TwoOfAKind");
        }
    }
}