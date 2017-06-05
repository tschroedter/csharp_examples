using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.Cards.Diamonds;
using PlayinCards.Interfaces.Decks.Cards;

namespace Playing.Tests.Decks.Cards.Diamonds
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class FiveOfDiamondsTests
        : BaseCardTests <FiveOfDiamonds>
    {
        public FiveOfDiamondsTests()
            : base("5D", CardRank.Five)
        {
        }
    }
}