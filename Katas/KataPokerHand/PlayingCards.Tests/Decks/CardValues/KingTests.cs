using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayingCards.Decks.CardValues;

namespace Playing.Tests.Decks.CardValues
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class KingTests
        : BaseCardValueTests <King>
    {
        public KingTests()
            : base('K',
                   "King",
                   new[]
                   {
                       10u
                   })
        {
        }
    }
}