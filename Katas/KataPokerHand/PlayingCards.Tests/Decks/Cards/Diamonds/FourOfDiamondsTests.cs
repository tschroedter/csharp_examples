using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.Cards.Diamonds;

namespace Playing.Tests.Decks.Cards.Diamonds
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class FourOfDiamondsTests
        : BaseClubsTests <FourOfDiamonds>
    {
        public FourOfDiamondsTests()
            : base("4D")
        {
        }
    }
}