using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Hearts;

namespace Playing.Tests.Decks.Cards.Hearts
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class FourOfHeartsTests
        : BaseCardTests <FourOfHearts>
    {
        public FourOfHeartsTests()
            : base("4H",
                   CardRank.Four)
        {
        }
    }
}