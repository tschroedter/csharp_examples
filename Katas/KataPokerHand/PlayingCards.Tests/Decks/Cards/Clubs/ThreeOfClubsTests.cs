using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.Cards.Clubs;

namespace Playing.Tests.Decks.Cards.Clubs
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class ThreeOfClubsTests
        : BaseClubsTests <ThreeOfClubs>
    {
        public ThreeOfClubsTests()
            : base("3C")
        {
        }
    }
}