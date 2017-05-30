using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.Decks.Cards.Clubs;
using NUnit.Framework;

namespace KataPokerHand.Logic.Tests.Decks.Cards.Clubs
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