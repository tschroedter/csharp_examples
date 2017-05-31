using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.Cards.Diamonds;

namespace Playing.Tests.Decks.Cards.Diamonds
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class TwoOfDiamondsTests
        : BaseClubsTests <TwoOfDiamonds>
    {
        public TwoOfDiamondsTests()
            : base("2D")
        {
        }
    }
}