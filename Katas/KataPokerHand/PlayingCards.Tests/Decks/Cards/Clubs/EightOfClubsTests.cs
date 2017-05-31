using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.Cards.Clubs;

namespace Playing.Tests.Decks.Cards.Clubs
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class EightOfClubsTests
        : BaseClubsTests <EightOfClubs>
    {
        public EightOfClubsTests()
            : base("8C")
        {
        }
    }
}