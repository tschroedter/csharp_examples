using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.Cards.Clubs;

namespace Playing.Tests.Decks.Cards.Clubs
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class FiveOfClubsTests
        : BaseClubsTests <FiveOfClubs>
    {
        public FiveOfClubsTests()
            : base("5C")
        {
        }
    }
}