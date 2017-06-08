using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Hearts;

namespace Playing.Tests.Decks.Cards.Hearts
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class SevenOfHeartsTests
        : BaseCardTests <SevenOfHearts>
    {
        public SevenOfHeartsTests()
            : base("7H",
                   "Seven of Hearts",
                   CardRank.Seven)
        {
        }
    }
}