using System.Collections.Generic;
using KataPokerHand.Logic.Integration.Tests.Steps.Common;
using PlayinCards.Interfaces.Decks.Cards;
using TechTalk.SpecFlow;

namespace KataPokerHand.Logic.Integration.Tests.Steps
{
    [Binding]
    public class TheOtherCardsShouldBeStep
        : BaseStep
    {
        [Then(@"the OtherCards should be '(.*)'")]
        public void ThenTheOtherCardsShouldBe(string cardsAsString)
        {
            List <ICard> cards = ConvertCardsStringsToList(cardsAsString);

            AssertCards(Info.OtherCards,
                        cards,
                        "OtherCards");
        }
    }
}