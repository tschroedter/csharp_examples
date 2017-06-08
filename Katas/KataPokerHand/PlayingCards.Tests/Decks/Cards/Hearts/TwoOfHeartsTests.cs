using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Hearts;

namespace Playing.Tests.Decks.Cards.Hearts
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class TwoOfHeartsTests
        : BaseCardTests <TwoOfHearts>
    {
        public TwoOfHeartsTests()
            : base("2H",
                   "Two of Hearts",
                   CardRank.Two)
        {
        }
    }
}