using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.Cards.Diamonds;

namespace Playing.Tests.Decks.Cards.Diamonds
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class JackOfDiamondsTests
        : BaseClubsTests <JackOfDiamonds>
    {
        public JackOfDiamondsTests()
            : base("JD")
        {
        }
    }
}