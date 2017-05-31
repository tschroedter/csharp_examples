using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.Cards.Hearts;

namespace Playing.Tests.Decks.Cards.Hearts
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class QueenOfHeartsTests
        : BaseClubsTests <QueenOfHearts>
    {
        public QueenOfHeartsTests()
            : base("QH")
        {
        }
    }
}