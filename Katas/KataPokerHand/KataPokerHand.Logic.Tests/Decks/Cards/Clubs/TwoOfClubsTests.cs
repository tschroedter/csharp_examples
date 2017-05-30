using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.Decks.Cards.Clubs;
using NUnit.Framework;

namespace KataPokerHand.Logic.Tests.Decks.Cards.Clubs
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class TwoOfClubsTests
        : BaseClubsTests <TwoOfClubs>
    {
        public TwoOfClubsTests()
            : base("2C")
        {
        }
    }
}