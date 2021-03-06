using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Diamonds;

namespace Playing.Tests.Decks.Cards.Diamonds
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class SixOfDiamondsTests
        : BaseCardTests <SixOfDiamonds>
    {
        public SixOfDiamondsTests()
            : base("6D",
                   "Six of Diamonds",
                   CardRank.Six)
        {
        }
    }
}