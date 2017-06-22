using System.Collections.Generic;
using KataPokerHand.Logic.Integration.Tests.Steps.Common;
using PlayinCards.Interfaces.Decks.Cards;
using TechTalk.SpecFlow;

namespace KataPokerHand.Logic.Integration.Tests.Steps
{
    [Binding]
    public class TheThreeOfAKindShouldBeStep
        : BaseStep
    {
        [Then(@"the ThreeOfAkind should be '(.*)'")]
        public void ThenTheThreeOfAkindShouldBe(string cardsAsString)
        {
            List <ICard> cards = ConvertCardsStringsToList(cardsAsString);

            AssertCards(Info.ThreeOfAKind,
                        cards,
                        "ThreeOfAKind");
        }
    }
}