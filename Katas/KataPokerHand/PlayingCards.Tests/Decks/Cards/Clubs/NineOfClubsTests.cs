using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.Cards.Clubs;

namespace Playing.Tests.Decks.Cards.Clubs
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class NineOfClubsTests
        : BaseClubsTests <NineOfClubs>
    {
        public NineOfClubsTests()
            : base("9C")
        {
        }
    }
}