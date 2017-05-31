using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.Cards.Spades;

namespace Playing.Tests.Decks.Cards.Spades
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class NineOfSpadesTests
        : BaseClubsTests<NineOfSpades>
    {
        public NineOfSpadesTests()
            : base("9S")
        {
        }
    }
}