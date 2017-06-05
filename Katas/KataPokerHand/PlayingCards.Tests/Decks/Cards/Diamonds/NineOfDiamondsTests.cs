using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.Cards.Diamonds;
using PlayinCards.Interfaces.Decks.Cards;

namespace Playing.Tests.Decks.Cards.Diamonds
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class NineOfDiamondsTests
        : BaseCardTests <NineOfDiamonds>
    {
        public NineOfDiamondsTests()
            : base("9D", CardRank.Nine)
        {
        }
    }
}