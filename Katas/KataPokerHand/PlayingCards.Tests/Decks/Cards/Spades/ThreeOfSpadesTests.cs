using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.Cards.Spades;

namespace Playing.Tests.Decks.Cards.Spades
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class ThreeOfSpadesTests
        : BaseClubsTests<ThreeOfSpades>
    {
        public ThreeOfSpadesTests()
            : base("3S")
        {
        }
    }
}