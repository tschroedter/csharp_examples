using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Spades;

namespace Playing.Tests.Decks.Cards.Spades
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class FiveOfSpadesTests
        : BaseCardTests <FiveOfSpades>
    {
        public FiveOfSpadesTests()
            : base("5S", CardRank.Five)
        {
        }
    }
}