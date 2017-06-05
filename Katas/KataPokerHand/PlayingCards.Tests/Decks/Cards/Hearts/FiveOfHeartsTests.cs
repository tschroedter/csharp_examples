using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Hearts;

namespace Playing.Tests.Decks.Cards.Hearts
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class FiveOfHeartsTests
        : BaseCardTests <FiveOfHearts>
    {
        public FiveOfHeartsTests()
            : base("5H",
                   CardRank.Five)
        {
        }
    }
}