using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Spades;

namespace Playing.Tests.Decks.Cards.Spades
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class QueenOfSpadesTests
        : BaseCardTests <QueenOfSpades>
    {
        public QueenOfSpadesTests()
            : base("QS",
                   "Queen of Spades",
                   CardRank.Queen)
        {
        }
    }
}