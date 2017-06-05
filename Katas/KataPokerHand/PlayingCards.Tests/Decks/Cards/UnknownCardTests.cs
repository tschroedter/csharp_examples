using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.Cards;
using PlayinCards.Interfaces.Decks.Cards;

namespace Playing.Tests.Decks.Cards
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class UnknownCardTests
        : BaseCardTests <UnknownCard>
    {
        public UnknownCardTests()
            : base("UU", CardRank.Unknown)
        {
        }
    }
}