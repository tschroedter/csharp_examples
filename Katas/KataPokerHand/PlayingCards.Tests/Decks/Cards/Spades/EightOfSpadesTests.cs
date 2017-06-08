using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Spades;

namespace Playing.Tests.Decks.Cards.Spades
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class EightOfSpadesTests
        : BaseCardTests <EightOfSpades>
    {
        public EightOfSpadesTests()
            : base("8S",
                   "Eight of Spades",
                   CardRank.Eight)
        {
        }
    }
}