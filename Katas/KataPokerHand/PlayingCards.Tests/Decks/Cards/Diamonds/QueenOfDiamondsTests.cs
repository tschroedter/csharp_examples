using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Diamonds;

namespace Playing.Tests.Decks.Cards.Diamonds
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class QueenOfDiamondsTests
        : BaseCardTests <QueenOfDiamonds>
    {
        public QueenOfDiamondsTests()
            : base("QD",
                   CardRank.Queen)
        {
        }
    }
}