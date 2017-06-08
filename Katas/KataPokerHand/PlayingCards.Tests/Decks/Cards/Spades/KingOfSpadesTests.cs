using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Spades;

namespace Playing.Tests.Decks.Cards.Spades
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class KingOfSpadesTests
        : BaseCardTests <KingOfSpades>
    {
        public KingOfSpadesTests()
            : base("KS",
                   "King of Spades",
                   CardRank.King)
        {
        }
    }
}