using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Diamonds;

namespace Playing.Tests.Decks.Cards.Diamonds
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class FiveOfDiamondsTests
        : BaseCardTests <FiveOfDiamonds>
    {
        public FiveOfDiamondsTests()
            : base("5D",
                   "Five of Diamonds",
                   CardRank.Five)
        {
        }
    }
}