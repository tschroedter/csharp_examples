using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.Cards;

namespace Playing.Tests.Decks.Cards
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class UnknownCardTests
        : BaseClubsTests <UnknownCard>
    {
        public UnknownCardTests()
            : base("UU")
        {
        }
    }
}