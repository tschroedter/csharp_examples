using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.Cards.Diamonds;

namespace Playing.Tests.Decks.Cards.Diamonds
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class NineOfDiamondsTests
        : BaseClubsTests<NineOfDiamonds>
    {
        public NineOfDiamondsTests()
            : base("9D")
        {
        }
    }
}