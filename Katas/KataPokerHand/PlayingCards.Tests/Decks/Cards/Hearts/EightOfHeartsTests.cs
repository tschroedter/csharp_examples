using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.Cards.Hearts;
using PlayinCards.Interfaces.Decks.Cards;

namespace Playing.Tests.Decks.Cards.Hearts
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class EightOfHeartsTests
        : BaseCardTests <EightOfHearts>
    {
        public EightOfHeartsTests()
            : base("8H", CardRank.Eight)
        {
        }
    }
}