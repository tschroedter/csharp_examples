using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.Cards.Spades;

namespace Playing.Tests.Decks.Cards.Spades
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class FiveOfSpadesTests
        : BaseClubsTests<FiveOfSpades>
    {
        public FiveOfSpadesTests()
            : base("5S")
        {
        }
    }
}