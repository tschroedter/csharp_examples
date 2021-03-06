using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Spades;

namespace Playing.Tests.Decks.Cards.Spades
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class TwoOfSpadesTests
        : BaseCardTests <TwoOfSpades>
    {
        public TwoOfSpadesTests()
            : base("2S",
                   "Two of Spades",
                   CardRank.Two)
        {
        }
    }
}