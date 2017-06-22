using KataPokerHand.Logic.Integration.Tests.Steps.Common;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using TechTalk.SpecFlow;

namespace KataPokerHand.Logic.Integration.Tests.Steps
{
    [Binding]
    public class TheHighestCardShouldBeStep
        : BaseStep
    {
        [Then(@"the HighestCard should be '(.*)'")]
        public void ThenTheHighestCardShouldBe(string cardAsString)
        {
            ICard expected = StringToCard.ToCard(cardAsString);

            Assert.AreEqual(expected.ToString(),
                            Info.HighestCard.ToString()); // todo implement equals for Cards
        }
    }
}