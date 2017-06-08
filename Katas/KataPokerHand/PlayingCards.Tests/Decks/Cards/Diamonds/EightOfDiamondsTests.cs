using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Diamonds;

namespace Playing.Tests.Decks.Cards.Diamonds
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class EightOfDiamondsTests
        : BaseCardTests <EightOfDiamonds>
    {
        public EightOfDiamondsTests()
            : base("8D",
                   "Eight of Diamonds",
                   CardRank.Eight)
        {
        }
    }
}