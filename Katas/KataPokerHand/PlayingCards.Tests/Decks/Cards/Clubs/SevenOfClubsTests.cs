using System.Diagnostics.CodeAnalysis;
using PlayingCards.Decks.Cards.Clubs;
using NUnit.Framework;

namespace Playing.Tests.Decks.Cards.Clubs
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class SevenOfClubsTests
        : BaseClubsTests <SevenOfClubs>
    {
        public SevenOfClubsTests()
            : base("7C")
        {
        }
    }
}