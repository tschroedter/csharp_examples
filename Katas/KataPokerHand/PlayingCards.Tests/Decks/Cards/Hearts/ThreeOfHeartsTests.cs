using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.Cards.Hearts;
using PlayinCards.Interfaces.Decks.Cards;

namespace Playing.Tests.Decks.Cards.Hearts
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class ThreeOfHeartsTests
        : BaseCardTests <ThreeOfHearts>
    {
        public ThreeOfHeartsTests()
            : base("3H", CardRank.Three)
        {
        }
    }
}