using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Clubs;

namespace Playing.Tests.Decks.Cards.Clubs
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class SixOfClubsTests
        : BaseCardTests <SixOfClubs>
    {
        public SixOfClubsTests()
            : base("6C",
                   CardRank.Six)
        {
        }
    }
}