using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Diamonds;

namespace Playing.Tests.Decks.Cards.Diamonds
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class TwoOfDiamondsTests
        : BaseCardTests <TwoOfDiamonds>
    {
        public TwoOfDiamondsTests()
            : base("2D", CardRank.Two)
        {
        }
    }
}