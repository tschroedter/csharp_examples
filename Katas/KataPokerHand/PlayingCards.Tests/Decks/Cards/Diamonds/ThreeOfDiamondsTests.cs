using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Diamonds;

namespace Playing.Tests.Decks.Cards.Diamonds
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class ThreeOfDiamondsTests
        : BaseCardTests <ThreeOfDiamonds>
    {
        public ThreeOfDiamondsTests()
            : base("3D",
                   CardRank.Three)
        {
        }
    }
}