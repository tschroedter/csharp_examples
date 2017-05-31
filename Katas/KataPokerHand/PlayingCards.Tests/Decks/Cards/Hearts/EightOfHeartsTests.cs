using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.Cards.Hearts;

namespace Playing.Tests.Decks.Cards.Hearts
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class EightOfHeartsTests
        : BaseClubsTests<EightOfHearts>
    {
        public EightOfHeartsTests()
            : base("8H")
        {
        }
    }
}