using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.Decks.Cards.Clubs;
using NUnit.Framework;

namespace KataPokerHand.Logic.Tests.Decks.Cards.Clubs
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class FourOfClubsTests
        : BaseClubsTests <FourOfClubs>
    {
        public FourOfClubsTests()
            : base("4C")
        {
        }
    }
}