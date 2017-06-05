using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Clubs;

namespace Playing.Tests.Decks.Cards.Clubs
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class JackOfClubsTests
        : BaseCardTests <JackOfClubs>
    {
        public JackOfClubsTests()
            : base("JC",
                   CardRank.Jack)
        {
        }
    }
}