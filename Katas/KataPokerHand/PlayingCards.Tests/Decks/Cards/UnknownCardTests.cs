using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards;

namespace Playing.Tests.Decks.Cards
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class UnknownCardTests
        : BaseCardTests <UnknownCard>
    {
        public UnknownCardTests()
            : base("UU",
                   CardRank.Unknown)
        {
        }
    }
}