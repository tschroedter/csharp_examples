using System.Collections.Generic;
using System.Linq;
using KataPokerHand.Logic.Integration.WinnerPhaser.Tests.Steps.Common;
using PlayinCards.Interfaces.Decks.Cards;
using TechTalk.SpecFlow;

namespace KataPokerHand.Logic.Integration.WinnerPhaser.Tests.Steps
{
    [Binding]
    public class PlayerHoldsTheFollowingCardsStep
        : BaseStep
    {
        [Given(@"player '(.*)' holds the following cards '(.*)'")]
        public void GivenPlayerHoldsTheFollowingCards(string player,
                                                      string cardsAsText)
        {
            string[] singleCards = cardsAsText.Split(',');

            IEnumerable <ICard> listOfCards = singleCards.Select(singleCard => StringToCard.ToCard(singleCard));

            Cards [ player ] = listOfCards;
        }
    }
}