using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Hearts;

namespace Playing.Tests.Decks.Cards.Hearts
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class ThreeOfHeartsTests
        : BaseCardTests <ThreeOfHearts>
    {
        public ThreeOfHeartsTests()
            : base("3H",
                   "Three of Hearts",
                   CardRank.Three)
        {
        }
    }
}