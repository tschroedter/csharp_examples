using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.Cards.Clubs;
using PlayinCards.Interfaces.Decks.Cards;

namespace Playing.Tests.Decks.Cards.Clubs
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class EightOfClubsTests
        : BaseCardTests <EightOfClubs>
    {
        public EightOfClubsTests()
            : base("8C", CardRank.Eight)
        {
        }
    }
}