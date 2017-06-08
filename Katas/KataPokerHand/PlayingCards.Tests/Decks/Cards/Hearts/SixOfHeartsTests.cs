using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Hearts;

namespace Playing.Tests.Decks.Cards.Hearts
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class SixOfHeartsTests
        : BaseCardTests <SixOfHearts>
    {
        public SixOfHeartsTests()
            : base("6H",
                   "Six of Hearts",
                   CardRank.Six)
        {
        }
    }
}