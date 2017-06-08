using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Diamonds;

namespace Playing.Tests.Decks.Cards.Diamonds
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class KingOfDiamondsTests
        : BaseCardTests <KingOfDiamonds>
    {
        public KingOfDiamondsTests()
            : base("KD",
                   "King of Diamonds",
                   CardRank.King)
        {
        }
    }
}