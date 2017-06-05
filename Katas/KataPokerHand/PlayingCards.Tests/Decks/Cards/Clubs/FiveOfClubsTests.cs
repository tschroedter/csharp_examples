using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Clubs;

namespace Playing.Tests.Decks.Cards.Clubs
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class FiveOfClubsTests
        : BaseCardTests <FiveOfClubs>
    {
        public FiveOfClubsTests()
            : base("5C",
                   CardRank.Five)
        {
        }
    }
}