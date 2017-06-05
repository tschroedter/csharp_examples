using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Clubs;

namespace Playing.Tests.Decks.Cards.Clubs
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class QueenOfClubsTests
        : BaseCardTests <QueenOfClubs>
    {
        public QueenOfClubsTests()
            : base("QC",
                   CardRank.Queen)
        {
        }
    }
}