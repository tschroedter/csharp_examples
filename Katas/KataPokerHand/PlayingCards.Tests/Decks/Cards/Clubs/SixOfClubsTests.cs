using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.Cards.Clubs;

namespace Playing.Tests.Decks.Cards.Clubs
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class SixOfClubsTests
        : BaseClubsTests <SixOfClubs>
    {
        public SixOfClubsTests()
            : base("6C")
        {
        }
    }
}