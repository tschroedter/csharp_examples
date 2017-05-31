using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.Cards.Diamonds;

namespace Playing.Tests.Decks.Cards.Diamonds
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class EightOfDiamondsTests
        : BaseClubsTests<EightOfDiamonds>
    {
        public EightOfDiamondsTests()
            : base("8D")
        {
        }
    }
}