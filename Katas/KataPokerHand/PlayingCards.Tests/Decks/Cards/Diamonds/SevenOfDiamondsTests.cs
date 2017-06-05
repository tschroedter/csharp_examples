using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Diamonds;

namespace Playing.Tests.Decks.Cards.Diamonds
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class SevenOfDiamondsTests
        : BaseCardTests <SevenOfDiamonds>
    {
        public SevenOfDiamondsTests()
            : base("7D",
                   CardRank.Seven)
        {
        }
    }
}