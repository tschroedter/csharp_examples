using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.Cards.Diamonds;
using PlayinCards.Interfaces.Decks.Cards;

namespace Playing.Tests.Decks.Cards.Diamonds
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class EightOfDiamondsTests
        : BaseCardTests <EightOfDiamonds>
    {
        public EightOfDiamondsTests()
            : base("8D", CardRank.Eight)
        {
        }
    }
}