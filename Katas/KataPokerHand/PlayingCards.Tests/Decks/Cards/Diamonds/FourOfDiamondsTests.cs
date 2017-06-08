using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Diamonds;

namespace Playing.Tests.Decks.Cards.Diamonds
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class FourOfDiamondsTests
        : BaseCardTests <FourOfDiamonds>
    {
        public FourOfDiamondsTests()
            : base("4D",
                   "Four of Diamonds",
                   CardRank.Four)
        {
        }
    }
}