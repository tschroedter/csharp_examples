using KataPokerHand.Logic.Integration.Tests.Steps.Common;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using TechTalk.SpecFlow;

namespace KataPokerHand.Logic.Integration.Tests.Steps
{
    [Binding]
    public class TheRankShouldBeStep
        : BaseStep
    {
        [Then(@"the Rank should be '(.*)'")]
        public void ThenTheCardRankShouldBe(string cardRankAsString)
        {
            CardRank expected = StringToCardRank.ToCardRank(cardRankAsString);

            Assert.AreEqual(expected,
                            Info.Rank);
        }
    }
}