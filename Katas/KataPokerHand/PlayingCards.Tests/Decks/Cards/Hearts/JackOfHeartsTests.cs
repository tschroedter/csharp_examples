using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Hearts;

namespace Playing.Tests.Decks.Cards.Hearts
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class JackOfHeartsTests
        : BaseCardTests <JackOfHearts>
    {
        public JackOfHeartsTests()
            : base("JH",
                   CardRank.Jack)
        {
        }
    }
}